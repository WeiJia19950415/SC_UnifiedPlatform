using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SC_UnifiedPlatform.Auth;
using SC_UnifiedPlatform.Permissions;
using Volo.Abp;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.Identity;

namespace SC_UnifiedPlatform.Controllers;

[RemoteService(Name = "Auth")]
[Route("api/app/auth")]
public class AuthController : SC_UnifiedPlatformController
{
    private readonly IdentityUserManager _userManager;
    private readonly SignInManager<Volo.Abp.Identity.IdentityUser> _signInManager;
    private readonly IPermissionChecker _permissionChecker;
    private readonly IConfiguration _configuration;

    public AuthController(
        IdentityUserManager userManager,
        SignInManager<Volo.Abp.Identity.IdentityUser> signInManager,
        IPermissionChecker permissionChecker,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _permissionChecker = permissionChecker;
        _configuration = configuration;
    }

    /// <summary>
    /// 用户登录接口
    /// </summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResultDto>> LoginAsync([FromBody] LoginInputDto input)
    {
        var user = await _userManager.FindByNameAsync(input.UserName);
        if (user == null)
        {
            throw new UserFriendlyException("用户名或密码错误");
        }
        var isPasswordValid = await _userManager.CheckPasswordAsync(user, input.Password);
        if (!isPasswordValid)
        {
            throw new UserFriendlyException("用户名或密码错误");
        }
        var principal = await _signInManager.CreateUserPrincipalAsync(user);
        var hasLoginPermission = await _permissionChecker.IsGrantedAsync(principal, SC_UnifiedPlatformPermissions.Auth.Login);
        if (!hasLoginPermission)
        {
            throw new UserFriendlyException("您没有登录系统的权限，请联系管理员分配");
        }
        var isFirstLogin = user.GetProperty<bool>("IsFirstLogin");
        if (isFirstLogin)
        {
            return Ok(new LoginResultDto
            {
                RequirePasswordChange = true,
                UserId = user.Id,
                Message = "首次登录系统，请先修改初始密码"
            });
        }
        var token = GenerateJwtToken(user);
        return Ok(new LoginResultDto
        {
            RequirePasswordChange = false,
            UserId = user.Id,
            Token = token,
            Message = "登录成功"
        });
    }

    /// <summary>
    /// 首次登录强制修改密码接口
    /// </summary>
    [HttpPost("first-login-change-password")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResultDto>> FirstLoginChangePasswordAsync([FromBody] FirstLoginChangePasswordInputDto input)
    {
        var user = await _userManager.FindByIdAsync(input.UserId.ToString());
        if (user == null)
        {
            throw new UserFriendlyException("用户不存在或已被删除");
        }
        var isFirstLogin = user.GetProperty<bool>("IsFirstLogin");
        if (!isFirstLogin)
        {
            throw new UserFriendlyException("非法操作：该账户已完成过首次登录修改");
        }
        var removeResult = await _userManager.RemovePasswordAsync(user);
        if (!removeResult.Succeeded)
        {
            throw new UserFriendlyException("旧密码重置失败，请联系系统管理员");
        }

        var addResult = await _userManager.AddPasswordAsync(user, input.NewPassword);
        if (!addResult.Succeeded)
        {
            var errors = string.Join("; ", addResult.Errors);
            throw new UserFriendlyException($"密码更新失败，原因: {errors}");
        }
        user.SetProperty("IsFirstLogin", false);
        await _userManager.UpdateAsync(user);
        var token = GenerateJwtToken(user);
        return Ok(new LoginResultDto
        {
            RequirePasswordChange = false,
            UserId = user.Id,
            Token = token,
            Message = "密码修改成功，已自动为您登录系统"
        });
    }

    /// <summary>
    /// 生成 JWT Token 的私有方法
    /// </summary>
    private string GenerateJwtToken(Volo.Abp.Identity.IdentityUser user)
    {
        var jwtSettings = _configuration.GetSection("Jwt");
        var secretKey = jwtSettings["Key"] ?? "SC_UnifiedPlatform_Super_Long_Secret_Key_2026_Secure_Must_Be_At_Least_32_Bytes!";
        var issuer = jwtSettings["Issuer"] ?? "SC_UnifiedPlatform";
        var audience = jwtSettings["Audience"] ?? "SC_UnifiedPlatform";

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new Claim("TenantId", user.TenantId?.ToString() ?? string.Empty)
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.Now.AddDays(1), // Token 有效期7天
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
using System.ComponentModel.DataAnnotations;

namespace SC_UnifiedPlatform.Auth;

public class LoginInputDto
{
    [Required(ErrorMessage = "用户名不能为空")]
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = "密码不能为空")]
    public string Password { get; set; } = null!;
}
using System;

namespace SC_UnifiedPlatform.Auth;

public class LoginResultDto
{
    /// <summary>
    /// 是否需要强制修改密码（首次登录标志）
    /// </summary>
    public bool RequirePasswordChange { get; set; }

    /// <summary>
    /// 用户ID（首次登录需要修改密码时传给前端暂存）
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// 鉴权成功后的 JWT Token
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// 提示消息
    /// </summary>
    public string? Message { get; set; }
}
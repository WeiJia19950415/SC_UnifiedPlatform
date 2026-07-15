using System;
using System.ComponentModel.DataAnnotations;

namespace SC_UnifiedPlatform.Auth;

public class FirstLoginChangePasswordInputDto
{
    [Required]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "新密码不能为空")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;
}
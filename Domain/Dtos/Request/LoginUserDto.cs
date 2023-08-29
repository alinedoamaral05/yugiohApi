using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Dtos.Request;

public class LoginUserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}

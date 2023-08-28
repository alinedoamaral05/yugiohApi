using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Dtos.Request;

public class LoginUserDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}

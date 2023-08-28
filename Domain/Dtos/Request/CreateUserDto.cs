using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Dtos.Request
{
    public class CreateUserDto
    {
        [Required]
        public string UserName { get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set;}
        [Required]
        [Compare("Password")]
        public string RePassword { get; set;}
    }
}

using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Models;

public class CardType
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
}

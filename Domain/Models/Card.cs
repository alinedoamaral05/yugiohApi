using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Models;

public class Card
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int CardTypeId { get; set; }
    [Required]
    public CardType CardType { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int AttackPoints { get; set; }
    public int? DeffensePoints { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YuGiOhApi.Domain.Models;

[Table("Cards")]
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
    public ICollection<Deck> Decks { get; set; }

    public Card()
    {
        Decks = new List<Deck>();
    }
}
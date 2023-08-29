using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Models;

public class Deck
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int UserId { get; set; }

    public User User { get; set; }

    public ICollection<Card> Cards { get; set; }

    public Deck()
    {
        Cards = new List<Card>();
    }
}

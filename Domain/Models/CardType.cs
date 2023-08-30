using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YuGiOhApi.Domain.Models;

[Table("CardTypes")]
public class CardType
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Type { get; set; }
    public ICollection<Card> Cards { get; set; }

    public CardType()
    {
        Cards = new List<Card>();
    }
}

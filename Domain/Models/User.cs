using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace YuGiOhApi.Domain.Models;

[Table("Users")]
public class User: IdentityUser
{
    public ICollection<Deck> Decks { get; set; }
    public ICollection<Challenge> Challenges { get; set; }

    public User()
    {
        Decks = new List<Deck>();
        Challenges = new List<Challenge>();
    }
}
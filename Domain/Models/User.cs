using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Models;

public class User: IdentityUser
{
    public ICollection<Deck> Decks { get; set; }

    public User()
    {
        Decks = new List<Deck>();
    }
}
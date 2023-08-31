using System.ComponentModel.DataAnnotations;

namespace YuGiOhApi.Domain.Models;

public class Challenge
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string ChallengerUsername { get; set; }
    [Required]
    public string OpponentUsername{ get; set; }
    public int? ChosenChallengerDeckId { get; set; }
    public int? ChosenOpponentDeckId { get; set; }
    [Required]
    public bool Status { get; set; } = false;

    public ICollection<User> Users { get; set; }

    public Challenge()
    {
        Users = new List<User>();
    }

}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Infra.Database.Config.Entity;

public class YugiohContext : IdentityDbContext<User>
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardType> CardTypes { get; set; }
    public DbSet<Deck> Decks { get; set; }

    public YugiohContext(DbContextOptions<YugiohContext> options) : base(options) { }
}

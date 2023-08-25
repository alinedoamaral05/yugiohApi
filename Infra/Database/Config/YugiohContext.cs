using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Infra.Database.Config;

public class YugiohContext: DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardType> CardTypes { get; set; }
    public YugiohContext(DbContextOptions<YugiohContext> options): base(options) {}
}

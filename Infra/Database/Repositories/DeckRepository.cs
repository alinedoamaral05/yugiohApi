using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;

namespace YuGiOhApi.Infra.Database.Repositories;

public class DeckRepository : IRepository<Deck>
{
    private readonly YugiohContext _context;

    public DeckRepository(YugiohContext context)
    {
        _context = context;
    }

    public async Task<Deck> Create(Deck deck)
    {
        await _context.Decks.AddAsync(deck);
        await _context.SaveChangesAsync();

        return deck;
    }

    public async Task Delete(Deck deck)
    {
        _context.Decks.Remove(deck);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Deck>> FindAll()
    {

        var deckList = await _context.Decks.ToListAsync();

        return deckList;
    }

    public async Task<Deck?> FindById(int id)
    {
        var deck = await _context.Decks
        .FirstOrDefaultAsync(deck => deck.Id == id);

        return deck;
    }

    public async Task<Deck> Update(Deck deck)
    {
        _context.Update(deck);
        await _context.SaveChangesAsync();

        return deck;
    }
}
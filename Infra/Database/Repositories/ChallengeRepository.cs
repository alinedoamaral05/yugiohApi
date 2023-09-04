using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;

namespace YuGiOhApi.Infra.Database.Repositories;

public class ChallengeRepository : IChallengerRepository
{
    private readonly YugiohContext _context;

    public ChallengeRepository(YugiohContext context)
    {
        _context = context;
    }
    public async Task<Challenge> Create(Challenge challenge)
    {
        await _context.Challenges.AddAsync(challenge);
        await _context.SaveChangesAsync();

        return challenge;
    }

    public async Task Delete(Challenge type)
    {
        _context.Challenges.Remove(type);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Challenge>> FindAll()
    {
        var challengeList = await _context.Challenges
            .Include(challenge => challenge.Users)
            .ThenInclude(user => user.Decks)
            .ToListAsync();

        return challengeList;
    }

    public async Task<Challenge?> FindById(int id)
    {
        var duel = await _context.Challenges
            .Include(challenge => challenge.Users)
            .ThenInclude(user => user.Decks)
            .FirstOrDefaultAsync(duel => duel.Id == id);

        return duel;
    }

    public async Task<Challenge> Update(Challenge type)
    {
        _context.Challenges.Update(type);
        await _context.SaveChangesAsync();

        return type;
    }

    public async Task<Deck> FindDeckById(int deckId)
    {
        var duel = await _context.Decks
            .FirstOrDefaultAsync(deck => deck.Id == deckId);

        return duel;
    }
}

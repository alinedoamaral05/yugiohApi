using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;

namespace YuGiOhApi.Infra.Database.Repositories;

public class CardTypeRepository : ICardTypeRepository
{
    private readonly YugiohContext _context;

    public CardTypeRepository(YugiohContext context)
    {
        _context = context;
    }

    public async Task<CardType> Create(CardType cardType)
    {
        await _context.CardTypes.AddAsync(cardType);
        await _context.SaveChangesAsync();

        return cardType;
    }

    public async Task Delete(CardType cardType)
    {
        _context.CardTypes.Remove(cardType);
        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<CardType>> FindAll()
    {
        var cardTypeList = await _context.CardTypes.ToListAsync();

        return cardTypeList;
    }

    public async Task<CardType?> FindById(int id)
    {
        var cardType = await _context.CardTypes
            .FirstOrDefaultAsync(cardType => cardType.Id == id);

        return cardType;
    }

    public async Task<CardType> Update(CardType cardType)
    {
        _context.Update(cardType);
        await _context.SaveChangesAsync();

        return cardType;
    }
}

using Microsoft.EntityFrameworkCore;
using System.Text;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.Models;
using YuGiOhApi.Infra.Database.Config.Entity;

namespace YuGiOhApi.Infra.Database.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly YugiohContext _context;

        public CardRepository(YugiohContext context)
        {
            _context = context;
        }

        public async Task<Card> Create(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<int> GetTotalCards()
        {
            return await _context.Cards.CountAsync();
        }

        public async Task Delete(Card card)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Card>> FindAll()
        {            
            var cardList = await _context.Cards.ToListAsync();

            return cardList;
        }

        public async Task<Card?> FindById(int id)
        {
            var card = await _context.Cards
            .FirstOrDefaultAsync(card => card.Id == id);

            return card;
        }

        public async Task<Card> Update(Card card)
        {
            _context.Update(card);
            await _context.SaveChangesAsync();

            return card;
        }

        public async Task<ICollection<Card>> FindCardsById(List<int> cardIds)
        {
            List<Card> cardsList = new List<Card>(); 

            foreach(var card in cardIds)
            {
               cardsList.Add(await 
                   _context
                   .Cards
                   .FirstOrDefaultAsync(carda => carda.Id == card) 
                   ?? throw new BadHttpRequestException($"Id: {card} not exists"));
            }

            return cardsList;
        }

        public async Task<ICollection<Card>> FindByName(string name)
        {
            var lowerCaseName = name.ToLowerInvariant();
            var cardList = await _context.Cards
                .Where(card => card.Name.ToLower().Contains(lowerCaseName))
                .ToListAsync();

            return cardList;
        }

    }
}
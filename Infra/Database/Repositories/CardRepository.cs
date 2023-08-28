using YuGiOhApi.Domain.Dtos.Response;
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

        public Card Create(Card card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();

            return card;
        }

        public void Delete(Card card)
        {
            _context.Cards.Remove(card);
            _context.SaveChanges();
        }

        public ICollection<Card> FindAll()
        {
            var cardList = _context.Cards.ToList();

            return cardList;
        }

        public Card? FindById(int id)
        {
            var card = _context.Cards
            .FirstOrDefault(card => card.Id == id);

            return card;
        }

        public Card Update(Card card)
        {
            _context.Update(card);
            _context.SaveChanges();

            return card;
        }
    }
}
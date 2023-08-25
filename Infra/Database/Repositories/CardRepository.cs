using Microsoft.EntityFrameworkCore;
using YuGiOhApi.Domain.IRepositories;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Infra.Database.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardRepository _context;

        public CardRepository(CardRepository context)
        {
            _context = context;
        }

        public Card Create(Card card)
        {
            _context.Card.Add(card);
            _context.SaveChanges();

            return card;
        }

        public void Delete(Card card)
        {
            _context.Card.Remove(card);
            _context.SaveChanges();
        }

        public ICollection<Card> FindByGamer(int gamerId)
        {
            var cardList = _context.Card.ToList();

            return cardList;
        }

        public Card? FindById(int id)
        {
            var cardById = _context.Card
            .FirstOrDefault(card => card.Id == id);

            return cardById;
        }

        public Card Update(Card card)
        {
            _context.Update(card);
            _context.SaveChanges();
            return card;
        }
    }
}

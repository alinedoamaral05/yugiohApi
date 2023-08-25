using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IRepositories;

public interface ICardRepository
{
    Card Create(Card workout);
    Card Update(Card workout);
    void Delete(Card workout);
    Card? FindById(int id);
    ICollection<Card> FindByGamer(int gamerId);
}

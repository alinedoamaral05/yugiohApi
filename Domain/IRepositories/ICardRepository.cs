using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IRepositories;

public interface ICardRepository
{
    Task<Card> Create(Card workout);
    Task<Card> Update(Card workout);
    Task Delete(Card workout);
    Task<Card?> FindById(int id);
    Task<ICollection<Card>> FindAll();
}

﻿using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Domain.IRepositories;

public interface ICardRepository : IRepository<Card, int>
{
    public Task<ICollection<Card>> FindCardsById(List<int> cardIds);
    public Task<ICollection<Card>> FindByName(string name);
    public Task<int> GetTotalCards();

}
using SimpleMarket.Core.Models;

namespace SimpleMarket.Core.Interfaces.Repositories;

public interface ICardRepository
{
    public Task<List<Card>> GetAllCardsByUser(long userId);
    public Task AddCard(Card card);
    public Task UpdateCard(Card card);
    public Task DeleteCard(long id);
}
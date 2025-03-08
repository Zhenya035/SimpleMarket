using SimpleMarket.Core.Interfaces.Repositories;
using SimpleMarket.Core.Models;

namespace SimpleMarket.Persistance.Repositories;

public class CardRepository : ICardRepository
{
    public Task<List<Card>> GetAllCardsByUser(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddCard(Card card)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCard(Card card)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCard(long id)
    {
        throw new NotImplementedException();
    }
}
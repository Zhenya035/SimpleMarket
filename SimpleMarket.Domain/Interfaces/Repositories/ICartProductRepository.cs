namespace SimpleMarket.Persistance.Repositories;

public interface ICartProductRepository
{
    public Task DeleteCartProduct(long CartId);
}
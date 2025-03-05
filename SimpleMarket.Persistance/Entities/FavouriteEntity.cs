namespace SimpleMarket.Persistance.Entities;

public class FavouriteEntity
{
    public long Id { get; set; }
    
    public long UserId { get; set; }
    public UserEntity User { get; set; } = new UserEntity();
    
    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
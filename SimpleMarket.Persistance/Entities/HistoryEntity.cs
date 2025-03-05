namespace SimpleMarket.Persistance.Entities;

public class HistoryEntity
{
    public long Id { get; set; }
    
    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
    
    public long UserId { get; set; }
    public UserEntity User { get; set; } = new UserEntity();
}
namespace SimpleMarket.Persistance.Entities;

public class ProductEntity
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public List<string> Images { get; set; } = new List<string>();
    
    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = new CategoryEntity();
    
    public List<FeedbackEntity> Feedbacks { get; set; } = new List<FeedbackEntity>();
    
    public List<HistoryEntity> Histories { get; set; } = new List<HistoryEntity>();
    
    public List<FavouriteEntity> Favourites { get; set; } = new List<FavouriteEntity>();
    
    public List<CartEntity> Carts { get; set; } = new List<CartEntity>();
    
}
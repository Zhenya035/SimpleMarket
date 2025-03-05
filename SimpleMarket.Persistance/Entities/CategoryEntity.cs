namespace SimpleMarket.Persistance.Entities;

public class CategoryEntity
{
    public long Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    public List<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
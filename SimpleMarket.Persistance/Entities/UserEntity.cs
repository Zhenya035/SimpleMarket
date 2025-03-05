using SimpleMarket.Persistance.Enams;

namespace SimpleMarket.Persistance.Entities;

public class UserEntity
{
    public long Id { get; set; }
    
    public Role Role { get; set; } = Role.User;
    public string Username { get; set; } = string.Empty;
    public string Sex { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    public List<CardEntity> Cards { get; set; } = new List<CardEntity>();
    
    public List<FeedbackEntity> Feedbacks { get; set; } = new List<FeedbackEntity>();
    
    public List<AddressEntity> Addresses { get; set; } = new List<AddressEntity>();
    
    public long HistoryId { get; set; }
    public HistoryEntity History { get; set; } = new HistoryEntity();
    
    public long FavouriteId { get; set; }
    public FavouriteEntity Favourite { get; set; } = new FavouriteEntity();
    
    public long CartId { get; set; }
    public CartEntity Cart { get; set; } = new CartEntity();
}
using Domain.Entity;

namespace DataAccess.Interfaces;

public interface IWishlistRepository
{
    void AddWishlist(Cake cake);
    
    int RemoveWishlist(Cake cake);
    
    IEnumerable<Wishlist> GetAllWishlists();
}
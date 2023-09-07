using Domain.Entity;

namespace Application.Interfaces;

public interface IWishlistService
{
    void AddWishlist(Cake cake);
    
    int RemoveWishlist(Cake cake);
    
    IEnumerable<Wishlist> GetAllWishlists();
}
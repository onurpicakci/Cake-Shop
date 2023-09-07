using Domain.Entity;

namespace Application.Interfaces;

public interface IWishlistService
{
    void AddWishlist(Cake cake);
    
    void RemoveWishlist(Cake cake);
    
    IEnumerable<Wishlist> GetAllWishlists();
}
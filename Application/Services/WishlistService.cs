using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class WishlistService : IWishlistService
{
    private readonly IWishlistRepository _wishlistRepository;

    public WishlistService(IWishlistRepository wishlistRepository)
    {
        _wishlistRepository = wishlistRepository;
    }

    public void AddWishlist(Cake cake)
    {
        _wishlistRepository.AddWishlist(cake);
    }

    public int RemoveWishlist(Cake cake)
    {
        return _wishlistRepository.RemoveWishlist(cake);
    }

    public IEnumerable<Wishlist> GetAllWishlists()
    {
        return _wishlistRepository.GetAllWishlists();
    }
}
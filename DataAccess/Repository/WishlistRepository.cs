using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;

namespace DataAccess.Repository;

public class WishlistRepository : IWishlistRepository
{
   private readonly CakeShopDbContext _context;

   public WishlistRepository(CakeShopDbContext context)
   {
       _context = context;
   }

   public void AddWishlist(Cake cake)
    {
        var wishlistItem = _context.Wishlists.SingleOrDefault(
            x=> x.CakeId == cake.Id);
        
        if (wishlistItem == null)
        {
            wishlistItem = new Wishlist
            {
                Name = cake.Name,
                Price = cake.Price,
                ImageThumbnailUrl = cake.ImageThumbnailUrl,
                InStock = cake.InStock,
                Cake = cake,
                CakeId = cake.Id
            };
            _context.Wishlists.Add(wishlistItem);
        }
        _context.SaveChanges();
    }

    public int RemoveWishlist(Cake cake)
    {
        var wishlistItem = _context.Wishlists.SingleOrDefault(
            x=> x.CakeId == cake.Id);
        
        var localAmount = 0;
        
        if (wishlistItem != null)
        {
            _context.Wishlists.Remove(wishlistItem);
        }
        _context.SaveChanges();
        return localAmount;
    }

    public IEnumerable<Wishlist> GetAllWishlists()
    {
        return _context.Wishlists.ToList();
    }
}
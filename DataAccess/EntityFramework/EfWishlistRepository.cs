using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;

namespace DataAccess.EntityFramework;

public class EfWishlistRepository : WishlistRepository, IWishlistRepository
{
    public EfWishlistRepository(CakeShopDbContext context) : base(context)
    {
    }
}
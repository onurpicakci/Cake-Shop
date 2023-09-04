using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;

namespace DataAccess.EntityFramework;

public class EfAboutRepository : AboutRepository, IAboutRepository
{
    public EfAboutRepository(CakeShopDbContext context) : base(context)
    {
        
    }
}
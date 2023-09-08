using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;

namespace DataAccess.EntityFramework;

public class EfContactRepository : ContactRepository, IContactRepository
{
    public EfContactRepository(CakeShopDbContext context) : base(context)
    {
    }
}
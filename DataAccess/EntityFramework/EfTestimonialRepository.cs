using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Repository;

namespace DataAccess.EntityFramework;

public class EfTestimonialRepository : TestimonialRepository, ITestimonialRepository
{
    public EfTestimonialRepository(CakeShopDbContext context) : base(context)
    {
        
    }
}
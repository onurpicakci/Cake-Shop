using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class CouponRepository : ICouponRepository
{
    private readonly CakeShopDbContext _context;

    public CouponRepository(CakeShopDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
    {
        return await _context.Coupons.ToListAsync();
    }

    public async Task<Coupon> GetCouponByIdAsync(int id)
    {
        return await _context.Coupons.FindAsync(id);
    }

    public async Task<Coupon> GetCouponByCodeAsync(string code)
    {
        return await _context.Coupons.FirstOrDefaultAsync(c => c.Code == code);
    }

    public async Task<Coupon> CreateCouponAsync(Coupon coupon)
    {
        return (await _context.Coupons.AddAsync(coupon)).Entity; 
    }

    public async Task<Coupon> UpdateCouponAsync(Coupon coupon)
    {
        return _context.Coupons.Update(coupon).Entity;
    }

    public async Task<Coupon> DeleteCouponAsync(int id)
    {
        return _context.Coupons.Remove(await _context.Coupons.FindAsync(id)).Entity;
    }
}
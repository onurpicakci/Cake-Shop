using Domain.Entity;

namespace DataAccess.Interfaces;

public interface ICouponRepository
{
    Task<IEnumerable<Coupon>> GetAllCouponsAsync();
    Task<Coupon> GetCouponByIdAsync(int id);
    Task<Coupon> GetCouponByCodeAsync(string code);
    Task<Coupon> CreateCouponAsync(Coupon coupon);
    Task<Coupon> UpdateCouponAsync(Coupon coupon);
    Task<Coupon> DeleteCouponAsync(int id);
}
using Application.Interfaces;
using DataAccess.Interfaces;
using Domain.Entity;

namespace Application.Services;

public class CouponService : ICouponService
{
    private readonly ICouponRepository _couponRepository;

    public CouponService(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public async Task<IEnumerable<Coupon>> GetAllCouponsAsync()
    {
        return await _couponRepository.GetAllCouponsAsync();
    }

    public async Task<Coupon> GetCouponByIdAsync(int id)
    {
        return await _couponRepository.GetCouponByIdAsync(id);
    }

    public async Task<Coupon> GetCouponByCodeAsync(string code)
    {
        return await _couponRepository.GetCouponByCodeAsync(code);
    }

    public async Task<Coupon> CreateCouponAsync(Coupon coupon)
    {
        return await _couponRepository.CreateCouponAsync(coupon);
    }

    public async Task<Coupon> UpdateCouponAsync(Coupon coupon)
    {
        return await _couponRepository.UpdateCouponAsync(coupon);
    }

    public async Task<Coupon> DeleteCouponAsync(int id)
    {
        return await _couponRepository.DeleteCouponAsync(id);
    }
}
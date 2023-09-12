using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public class CakeShopDbContext : IdentityDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=CakeShop;User Id=sa;Password=myPassw0rd;TrustServerCertificate=True;");
    }
    public DbSet<Cake> Cakes { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<About> Abouts { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    
    public DbSet<Coupon> Coupons { get; set; }
}
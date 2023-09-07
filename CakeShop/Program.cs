using Application.Interfaces;
using Application.Services;
using CakeShop;
using DataAccess.Context;
using DataAccess.EntityFramework;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CakeShopDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICakeRepository, EfCakeRepository>();
builder.Services.AddScoped<ICartItemRepository, EfCartItemRepository>();
builder.Services.AddScoped<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IAboutRepository, EfAboutRepository>();
builder.Services.AddScoped<ITestimonialRepository, EfTestimonialRepository>();
builder.Services.AddScoped<IWishlistRepository, EfWishlistRepository>();

builder.Services.AddScoped<ICakeService, CakeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();

builder.Services.AddScoped<WishlistService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<CakeShopDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cake}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name : "areas",
        pattern : "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});

app.Run();
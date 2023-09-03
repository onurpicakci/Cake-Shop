using Domain.Entity;

namespace CakeShop.ViewModels;

public class CakeListViewModel
{
    public List<Cake> Cakes { get; }
    public string? CurrentCategory { get; }
    
    public CakeListViewModel(List<Cake> cakes, string? currentCategory)
    {
        Cakes = cakes;
        CurrentCategory = currentCategory;
    }
}
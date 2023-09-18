using Domain.Entity;

namespace CakeShop.Areas.Admin.Models;

public class AddCakeViewModel
{
    public Cake Cake { get; set; }
    public List<Category> Categories { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CakeShop.Areas.Identity.Models;

public class UserLoginViewModel
{
    [Microsoft.Build.Framework.Required]
    [Display(Name = "User Name")]
    public string UserName { get; set; }

    [Microsoft.Build.Framework.Required]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Display(Name = "Remember Me")] 
    public bool RememberMe { get; set; }
}
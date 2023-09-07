using System.ComponentModel.DataAnnotations;

namespace CakeShop.Areas.Identity.Models;

public class UserRegisterViewModel
{
    [Required]
    [Display(Name = "User Name")]
    public string UserName { get; set; }
    
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
    
    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Password and Confirm Password must be same")]
    public string ConfirmPassword { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
}
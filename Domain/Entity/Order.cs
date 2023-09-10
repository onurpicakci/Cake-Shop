using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter your first name")]
    [Display(Name = "First Name")]
    [StringLength(50)]
    public string FirstName { get; set; }
    
    [Required (ErrorMessage = "Please enter your last name")]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName { get; set; }
    
    [Required (ErrorMessage = "Please enter your address")]
    [StringLength(100)]
    [Display(Name = "Address Line 1")]
    public string AddressLine1 { get; set; }
    
    [Display(Name = "Address Line 2")]
    public string AddressLine2 { get; set; }
    
    [Required (ErrorMessage = "Please enter your zip code")]
    [Display(Name = "Zip Code")]
    [StringLength(10, MinimumLength = 4)]
    public string ZipCode { get; set; }
    
    [Required (ErrorMessage = "Please enter your city")]
    [StringLength(50)]
    public string City { get; set; }
    
    [StringLength(20)]
    public string State { get; set; }
    
    [Required (ErrorMessage = "Please enter your country")]
    [StringLength(50)]
    public string Country { get; set; }
    
    [Required (ErrorMessage = "Please enter your phone number")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
    
    [Required (ErrorMessage = "Please enter your email")]
    [StringLength(50)]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email")]
    public string Email { get; set; }
    public decimal OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }
}
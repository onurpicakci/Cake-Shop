using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Order
{
    [Key]
    public int Id { get; set; }
    
    public string FirsName { get; set; }
    
    public string LastName { get; set; }
    
    public string AddressLine1 { get; set; }
    
    public string AddressLine2 { get; set; }
    
    public string ZipCode { get; set; }
    
    public string City { get; set; }
    
    public string Country { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
    public decimal OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
    
    public List<OrderDetail>? OrderDetails { get; set; }
}
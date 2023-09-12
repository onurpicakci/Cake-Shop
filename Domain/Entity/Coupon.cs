using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Coupon
{
    [Key]
    public int Id { get; set; }
    
    public string Code { get; set; }
    
    public decimal Discount { get; set; }
    
    public DateTime ExpirationDate { get; set; }
    
    public bool Active { get; set; }
}
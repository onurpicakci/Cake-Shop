using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class OrderDetail
{
    [Key]
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    
    public int CakeId { get; set; }
    
    public int Amount { get; set; }
    
    public decimal Price { get; set; }
    
    public Cake Cake { get; set; } = default!;
    
    public Order Order { get; set; } = default!;
}
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Wishlist
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public string ImageThumbnailUrl { get; set; }
    
    public bool InStock { get; set; }
    
    public Cake Cake { get; set; } = default!;
    
    public int CakeId { get; set; }

}
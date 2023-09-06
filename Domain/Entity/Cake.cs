using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Cake
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string ShortDescription { get; set; }
    
    public string LongDescription { get; set; }
    
    public decimal Price { get; set; }
    
    public string ImageUrl { get; set; }

    public string ImageUrl2 { get; set; }
    
    public string ImageUrl3 { get; set; }
    
    public string ImageUrl4 { get; set; }
    
    public string ImageUrl5 { get; set; }
    
    public string ImageUrl6 { get; set; }
    
    public string ImageThumbnailUrl { get; set; }
    public bool IsCakeOfTheWeek { get; set; }
    
    public bool InStock { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
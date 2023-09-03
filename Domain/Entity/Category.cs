using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Category
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public List<Cake> Cakes { get; set; }

    public string ImageUrl { get; set; }
}
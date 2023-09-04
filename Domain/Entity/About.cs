using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class About
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public string Description { get; set; }

    public string Feature { get; set; }
    
    public string Feature2 { get; set; }
    
    public string Feature3 { get; set; }

    public int FeatureLevel { get; set; }
    
    public int Feature2Level { get; set; }
    
    public int Feature3Level { get; set; }
    
    
}
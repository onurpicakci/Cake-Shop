using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class Testimonial
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Surname { get; set; }

    public string City { get; set; }
    
    public string Message { get; set; }
    
    public string ImageUrl { get; set; }
}
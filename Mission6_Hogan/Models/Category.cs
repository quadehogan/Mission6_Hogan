using System.ComponentModel.DataAnnotations;

namespace Mission6_Hogan.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Hogan.Models;

public class Movie
{
    public int MovieId { get; set; }

    [ForeignKey("Category")]
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public int Year { get; set; }

    public string? Director { get; set; }

    public string? Rating { get; set; }

    public bool Edited { get; set; }

    public string? LentTo { get; set; }

    public bool CopiedToPlex { get; set; }

    public string? Notes { get; set; }
}
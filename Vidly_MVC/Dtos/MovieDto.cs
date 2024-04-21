using System.ComponentModel.DataAnnotations;

namespace Vidly_MVC.Dtos;

public class MovieDto
{
    public int Id { get; set; }

    [Microsoft.Build.Framework.Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Microsoft.Build.Framework.Required]
    public byte GenreId { get; set; }

    public GenreDto? Genre { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime ReleaseDate { get; set; }

    [Range(1, 20)]
    public byte NumberInStock { get; set; }
    
    public byte NumberAvailable { get; set; }
}
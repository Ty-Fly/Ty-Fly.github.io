using System.ComponentModel.DataAnnotations;

namespace WPFWBackend.Features.Blog.CreateBlog;

public sealed record CreateBlogRequest{

    [Required]
    [StringLength(75, MinimumLength = 5,
                ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte titel max 100 characters, minimum of 3
    public string Titel = { get; };

    [Required]
    [StringLength(1000, MinimumLength = 10, 
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte Inhoud max 1000 characters, minimum of 10
    public string Inhoud = { get; };

    [DataType(DateOnly)]
    public DateOnly? Publicatiedaum = { get; };
}
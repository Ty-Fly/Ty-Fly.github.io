using System.ComponentModel.DataAnnotations;

namespace WPFWBackend.Features.Projects.UpdateProject;

public sealed record UpdateProjectRequest
{

    [Required]
    [StringLength(75, MinimumLength = 5,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte titel max 75 characters, minimum of 5
    public string Titel { get; init; } = string.Empty;

    [Required]
    [StringLength(1000, MinimumLength = 10,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte beschrijving max 1000 characters, minimum of 10
    public string Beschrijving { get; init; } = string.Empty;

    [Required]
    [StringLength(25, MinimumLength = 1,
       ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte categorie max 1000 characters, minimum of 1
    public string Categorie { get; init; } = string.Empty;

    [Url(ErrorMessage = "De waarde van {0} moet een geldige URL zijn!")]
    public string? GithubUrl { get; init; }
    
    [Required(ErrorMessage = "{0} is verplicht")]
    public DateOnly? Datum { get; init; }
}
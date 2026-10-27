using System.ComponentModel.DataAnnotations;

namespace WPFWBackend.Features.Project.CreateProject;

public sealed record CreateProjectRequest
{
    [Required]
    [StringLength(1000, MinimumLength = 10,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")]
    public string Titel { get; init; }

    [Required]
    [StringLength(1000, MinimumLength = 10,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")]
    public string Beschrijving { get; init; }

    [Required]
    [StringLength(25, MinimumLength = 1,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {25} karakters lang zijn!")]
    public string Categorie { get; init; }

    [Url(ErrorMessage = "De waarde van {0} moet een geldige URL zijn!")]
    public string? GithubUrl  { get; init; }


    [DataType(DateOnly,
         ErrorMessage = "De waarde van {0} moet tussen de {1} en {2} zijn")]
    public DateOnly? Datum { get; init; }
}
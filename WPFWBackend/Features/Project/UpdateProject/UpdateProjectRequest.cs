namespace WPFWBackend.Features.Project.UpdateProject;
public sealed record UpdateProjectRequest
{

    [Required]
    [StringLength(75, MinimumLength = 5,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte titel max 100 characters, minimum of 3
    public string Titel { get; init; }

    [Required]
    [StringLength(1000, MinimumLength = 10,
        ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte titel max 100 characters, minimum of 3
    public string Beschrijving  { get; init;}

    [Required]
    [StringLength(1000, MinimumLength = 10,
       ErrorMessage = "De waarde van {0} moet tussen de {2} en {1} karakters lang zijn!")] //Aangemaakte titel max 100 characters, minimum of 3
    public string Categorie { get; init; }
}
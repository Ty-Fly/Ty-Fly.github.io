# WPFW
Webprogramming, Frameworks &amp; Usability

## WPFWBackend 

### Technieken en keuzes

| Onderdeel | Keuze |
| --- | --- |
| .NET-versie | .NET 10 |
| API-stijl | **Minimal API**|
| Codestructuur | **Vertical Slice Architecture**: per use case één map met endpoint, handler en DTO's |
| Database | SQL Server (lokaal: SQL Server Express)|
| Database aanmaken | **EF Core-migratie** (`InitialCreate`) |

### Applicatie starten

#### Stap 1

Pas in `appsettings.json` de connectionstring `SQL` aan naar je eigen server:
```json
"ConnectionStrings": {
  "SQL": "Server=<JOUW-PC>\\SQLEXPRESS;Database=WPFW;Trusted_Connection=True;TrustServerCertificate=True"
}
```

#### Stap 2

De database wordt aangemaakt met de bestaande EF Core-migratie `InitialCreate`:

```bash
dotnet ef database update
```

Dit maakt de database `WPFW` met de tabellen `Projects` en `Blogs`. Na een wijziging in een entiteit maak je een nieuwe migratie met `dotnet ef migrations add <Naam>` en voer je opnieuw `dotnet ef database update` uit.

#### Stap 3

De applicatie start je middels HTTPS, door het volgende uit te voeren:

```bash
dotnet run --launch-profile https
```
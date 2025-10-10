# BoodschappenApp (GroceryApp) - Sprint 5

Een applicatie voor het beheren van boodschappenlijsten met uitgebreide product management functionaliteit.

## Functionaliteiten

### Eerdere Sprints
- **UC1-UC3:** Tonen van boodschappenlijsten, boodschappenlijstitems en producten
- **UC4:** Kleur van boodschappenlijst aanpassen
- **UC5:** Producten toevoegen aan boodschappenlijst
- **UC6:** Inlogfunctionaliteit voor gebruikers
- **UC7:** Delen boodschappenlijst
- **UC8:** Zoeken producten
- **UC9:** Registratiescherm
- **UC10:** Product aantal aanpassen in boodschappenlijst (plus/min knoppen)
- **UC11:** Meest verkochte producten tonen
- **UC13:** Aantal klanten per product tonen (alleen voor Admin rol)

### Sprint 5 (Week 6) - Nieuw
- **UC12:** Productcategorieën toevoegen en koppelen aan producten
- **UC14:** Prijzen toevoegen aan producten
- **UC15:** THT (Tenminste Houdbaar Tot) datum toevoegen en beheren

## Development Workflow (GitFlow)

Deze applicatie gebruikt **GitFlow** als branching strategie voor ontwikkeling.

### Branch Structuur

- **`main`** - Productie-klare releases
- **`development`** - Ontwikkel branch
- **`feature/*`** - Nieuwe functionaliteiten (bijv. `feature/UC12-productcategorieen`)
- **`hotfix/*`** - Kritieke fixes voor productie

### Commit Conventies

- **feat:** nieuwe functionaliteit (`feat(UC12): voeg productcategorieën toe`)
- **fix:** bug fix (`fix(UC14): valideer prijs input correct`)
- **docs:** documentatie wijzigingen (`docs: update README voor sprint 5`)

## Test Pipeline

- **Automatische tests** bij elke Pull Request naar `main` of `development`
- **GitHub Actions workflow** in `.github/workflows/maui_unit_tests.yaml`
- Test resultaten beschikbaar als artifact in GitHub Actions

## Versioning

Deze sprint: **v1.4.0** (Minor release - nieuwe functionaliteit)

- **Major:** Breaking changes (bijv. database migratie) → v2.0.0
- **Minor:** Nieuwe functionaliteit (bijv. UC12, UC14, UC15) → v1.4.0
- **Patch:** Bug fixes (bijv. hotfix voor crash) → v1.4.1

## Belangrijke Sprint 5 Features

### UC12: Productcategorieën
- Categorieën aanmaken en beheren
- Producten koppelen aan categorieën
- Categorie-kleuren voor visuele identificatie
- Producten filteren op categorie

### UC14: Prijsinformatie
- Prijzen tonen per product
- Prijsgeschiedenis bijhouden
- Totaalberekening boodschappenlijst

### UC15: THT Datum Management
- THT datum per product
- Waarschuwingen voor verlopen producten
- Sorteren op vervaldatum

## Licentie

MIT License

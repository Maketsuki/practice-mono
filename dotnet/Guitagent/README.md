# Guitagent

Guitagent is a .NET practice assistant for guitarists, built with .NET 10, Aspire, and Blazor.

## Prerequisites

- **.NET 10 SDK**
- **PostgreSQL 18** (Installed via Homebrew recommended)
- **dotnet-ef tool** (Required for migrations)

---

## Getting Started

### 1. Database Setup (macOS)

If you are using Homebrew PostgreSQL:

```bash
# Start the Postgres service
brew services start postgresql@18

# Create the application database
createdb guitagent_db

# Ensure .NET EF tools are installed
dotnet tool install --global dotnet-ef

# Apply migrations to create tables
dotnet ef database update --project Guitagent.Infrastructure --startup-project Guitagent.API
```

### 2. Configuration

The application is configured to use your local macOS username with no password by default. Check `Guitagent.AppHost/appsettings.json` and `Guitagent.API/appsettings.Development.json` to verify the connection string:

```json
"ConnectionStrings": {
  "guitagent-db": "Host=localhost;Database=guitagent_db;Username=markussorjonen;Password="
}
```

### 3. Running the Project

Run the entire distributed application using the Aspire AppHost:

```bash
dotnet run --project Guitagent.AppHost/Guitagent.AppHost.csproj
```

Once running, the terminal will provide a link to the **Aspire Dashboard**, where you can find the URLs for the Web and API services.

---

## Project Structure

- **Guitagent.AppHost**: Orchestration project (.NET Aspire).
- **Guitagent.Web**: Blazor Server-side web application.
- **Guitagent.Web.Client**: Blazor WebAssembly client-side logic.
- **Guitagent.API**: REST API for managing exercises and routines.
- **Guitagent.Infrastructure**: EF Core Data access layer and migrations.
- **Guitagent.Domain**: Shared entities and business logic.
- **Guitagent.Shared**: Shared DTOs and Enums.

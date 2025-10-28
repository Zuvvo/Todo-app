# TodoApp

This is a simple Todo application built with ASP.NET Core (.NET 8) and Entity Framework Core using PostgreSQL as the database, and an Angular 20 frontend with Angular Material for UI components.
	
## Getting Started
	

1. Open the solution in Visual Studio 2022.
2. At the top of the IDE, ensure the run profile is set to **IIS Express**.
3. Make sure the build configuration is set to **Debug** (not Release).
4. Press **F5** or click the **Start Debugging** button to run API.
5. To run the Angular client, open a terminal, navigate to `TodoApplication\TodoApp.Web`, and run the command: **ng serve**.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- Visual Studio 2022 (recommended for development)

### Database Configuration

The application uses a PostgreSQL database.  
You must set the correct connection string in `appsettings.Development.json`:
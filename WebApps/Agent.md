# Web API Project Standards

## 1. Project Structure
- Organize the project into clear folders: Controllers, Models, Data, etc.
- Use a consistent naming convention for files and folders.

## 2. Controller Standards
- Use `[ApiController]` attribute for all controllers to enable automatic model validation.
- Define routes clearly using `[Route]` attributes.
- Use appropriate HTTP verbs (`[HttpGet]`, `[HttpPost]`, etc.) for actions.
- Inject dependencies via constructor injection for better testability.

## 3. Database Configuration
- Use Entity Framework Core for database interactions.
- Configure the database connection string in the `appsettings.json` file instead of hardcoding it in the `Program.cs` file.
- Ensure the database is created if it does not exist during application startup.

## 4. JSON Serialization
- Use Newtonsoft.Json for JSON serialization and configure it to handle reference loops and null values appropriately. Use Microsoft.AspNetCore.Mvc.NewtonsoftJson package rather than just Newtonsoft.Json for this.

## 5. Middleware Configuration
- Configure middleware in the correct order: Static files, Routing, Authorization, etc.
- Use OpenAPI for API documentation in development mode.

## 6. Error Handling
- Implement global error handling to manage exceptions and return appropriate HTTP status codes.

## 7. Security
- Consider using HTTPS redirection in production environments.

## 8. Default Path
- By default have the default '/' path mapped to wwwroot folder's index.html 

## Additional Instructions
- Always place sensitive configurations, such as database connection strings, in the `appsettings.json` file to keep them secure and easily configurable.
- Use below additional packages:
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="9.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.<Sqlite or database provider specific name>" Version="8.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.11">

---
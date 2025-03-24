# TaskApp

TaskApp is a simple ASP.NET Core Web API for managing tasks. It supports creating, retrieving, updating, and deleting task items. This project also includes unit tests for core service logic to ensure reliability and correctness.

## Features

- Create new tasks
- Retrieve all tasks
- Retrieve a task by ID
- Update an existing task
- Delete a task

## Technologies Used

- ASP.NET Core 8.0
- C#
- xUnit for unit testing
- Swagger/OpenAPI for API documentation

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Optional: [Postman](https://www.postman.com/) [Swagger](http://localhost:5134/swagger) for testing endpoints
- Optional: [Visual Studio Code](https://code.visualstudio.com/) or another IDE

### Running the App

1. Clone the repository:

   ```bash
   git clone https://github.com/EliSchweitzer1/TaskApp.git
   cd TaskApp
   ```

2. Run the application:

   ```bash
   dotnet run
   ```

3. The API will be available at:

   ```
   http://localhost:5134
   ```

4. Swagger UI will be available at:

   ```
   http://localhost:5134/swagger
   ```

---

## Configuration

You can define environment-specific configurations using the `appsettings.{Environment}.json` pattern. For example:

### `appsettings.Development.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=TaskApp_Local;User Id=local_user;Password=local_password"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Warning"
    }
  },
  "EnvironmentName": "DEVELOPMENT"
}
```

Run the app with a specific environment using:

```bash
ASPNETCORE_ENVIRONMENT=Development dotnet run
```

---

## Running Tests

Navigate to the `TaskApp.Tests` folder and run:

```bash
cd TaskApp.Tests

dotnet test
```

### What’s Covered

Unit tests are written using xUnit and test the core business logic in the `TaskService`. Covered scenarios include:

- Creating a task assigns an incrementing ID
- Getting all tasks returns the expected number
- Getting a task by ID returns the correct task or null if not found
- Updating a task modifies the correct fields or returns false if the ID doesn't exist
- Deleting a task removes it, or returns false if not found

---
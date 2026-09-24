# dotnet-showcase
# Game Inventory API

A RESTful Web API built with ASP.NET Core demonstrating backend development 
fundamentals. Built as a learning project transitioning from Unity/C# game 
development to .NET backend engineering.

## Features

- Full CRUD REST API with proper HTTP semantics
- JWT authentication with protected endpoints
- Entity Framework Core with SQLite database
- Input validation with Data Annotations
- Global exception handling middleware
- Swagger UI for interactive API documentation
- Unit tests with xUnit and EF Core InMemory provider
- Dockerized with a multi-stage build

## Tech Stack

- .NET 9 / ASP.NET Core
- Entity Framework Core 9
- SQLite
- JWT Bearer Authentication
- Swashbuckle (Swagger UI)
- xUnit
- Docker

## Project Structure
GameInventoryApi/
├── Controllers/ # HTTP layer — routing and status codes
│ ├── AuthController.cs
│ └── InventoryController.cs
├── Data/ # EF Core DbContext
├── Middleware/ # Global exception handling
├── Migrations/ # EF Core database migrations
├── Models/ # Entities and DTOs
├── Services/ # Business logic layer
├── Program.cs # App startup and DI registration
└── Dockerfile # Multi-stage container build

GameInventoryApi.Tests/
└── InventoryServiceTests.cs # 6 unit tests

## API Endpoints

| Method | Endpoint | Auth | Description |
|--------|----------|------|-------------|
| POST | `/auth/login` | None | Returns a JWT token |
| GET | `/inventory` | None | Get all items |
| GET | `/inventory/{id}` | None | Get item by Id |
| POST | `/inventory` | Required | Create an item |
| PUT | `/inventory/{id}` | Required | Update an item |
| DELETE | `/inventory/{id}` | Required | Delete an item |

## Authentication

Login to receive a JWT token:

```json
POST /auth/login
{
  "username": "admin",
  "password": "password123"
}
```

Include the token in subsequent requests:

Authorization: Bearer <your-token>

> ⚠️ Credentials and JWT secret are hardcoded for demo purposes only. 
> Production deployments should use environment variables or a secrets manager.

## Background

This project was built as a structured onboarding exercise after 8 years of 
Unity/C# game development. The domain (game inventory) was chosen deliberately 
to keep focus on learning ASP.NET Core patterns rather than domain logic.

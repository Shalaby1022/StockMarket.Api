# StockMarket API

Welcome to the StockMarket API project! This API provides endpoints for managing comments and stocks in a stock market context. It's built following the n-tier architecture, incorporating various design patterns and best practices to ensure scalability, maintainability, and security.

## Table of Contents

- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Future Features](#future-features)
- [Contributing](#contributing)

## Project Structure

The project is organized into three main components, following the n-tier architecture:

### 1. StockMarket.Api

This layer contains the API controllers responsible for handling HTTP requests related to comments and stocks.

### 2. StockMarket.DataService

This layer includes the data service responsible for interacting with the database. It implements the repository pattern, unit of work, and dependency injection. The components include data models, repositories, and database context.

### 3. StockMarket.Models

This layer defines the data transfer objects (DTOs), data models, and mapping profiles used throughout the project.

## Technologies Used

- **ASP.NET Core Web API**: For building the RESTful API.
- **Entity Framework Core**: For database operations and ORM.
- **JWT Authentication**: As a future feature, implementing secure authentication and authorization mechanisms.
- **Swagger UI**: For API documentation.
- **Automapper**: For object-object mapping.
- **Dependency Injection**: For managing component dependencies.
- **Repository Pattern**: For separating data access logic.
- **Generic Repository**: For providing a generic interface for CRUD operations.
- **Unit of Work**: For coordinating multiple repository operations within a single transaction.
- **Git**: For version control.
- **C#**: Primary programming language.
- **SQL Server**: Database management system.

## Getting Started

To get started with the project, follow these steps:

1. Clone this repository to your local machine.
2. Navigate to the solution file `StockMarket.Api.sln`.
3. Open the solution in Visual Studio or your preferred IDE.
4. Set up your database connection string in `appsettings.json` files in both `StockMarket.Api` and `StockMarket.DataService` projects.
5. Run the Entity Framework Core migrations to create the database schema.
6. Build and run the solution.
7. Access the API endpoints using tools like Postman or Swagger UI.

## Future Features

We have exciting plans for future features:

- **Authentication and Authorization with JWT**: Implementing secure authentication and authorization mechanisms to protect endpoints and manage user access.
- **UI Presentation with Angular**: As a future endeavor, learning Angular to develop a modern, interactive user interface for the API.

Stay tuned for updates as we continue to improve the StockMarket API!

## Contributing

Contributions to the project are welcome! If you have ideas for improvements, bug fixes, or new features, feel free to open an issue or submit a pull request.


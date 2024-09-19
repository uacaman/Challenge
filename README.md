# Project Setup

## Setup

On a Windows machine with Docker Desktop installed, run `build and run.cmd`. This will build a Docker image and execute the container. To access the application, point your browser to [http://localhost:8080](http://localhost:8080).

**Requirements**:
- Docker Desktop
- Visual Studio 2022

## Design Decisions

- **.NET Core 8**: Utilized for its modern features and performance improvements.
- **Autofac**: Chosen as the Dependency Injection (DI) container to manage the selection of appropriate command handlers.
- **Command Design Pattern**: Ideal for REST APIs where each endpoint executes a single command. Commands implement a common interface with an `Execute` method, supporting adherence to S.O.L.I.D principles.
- **Decorator Pattern**: Used to enhance command handler functionality, such as implementing `SaveChanges` from EF Core without coupling the command handler with EF Core-specific details. This pattern is also applicable for managing database transactions or telemetry.
- **EF Core & SQLite**: Selected for ease of deployment and straightforward database management.

## Project Structure

- **Challenge**: The startup project that includes the frontend and controllers responsible for forwarding REST API operations to command handlers.
- **Business**: Contains command handlers that implement business logic.
- **Data**: Manages CRUD operations and database queries. Ensures no EF Core dependencies leak into other projects.
- **Core**: Houses models and interfaces used for Dependency Injection (DI).
- **Test**: Includes unit tests for command handlers.

## Frontend

The user interface is a single page built with HTML and JavaScript using jQuery. It is designed to be responsive for a smoother user experience, giving the impression of faster API operations by immediately updating the interface. In case of a failure, the UI is reloaded to reflect the latest state.

On the first visit, a random GUID is generated and used to link tasks in the database to the browser. This allows users to leave the page and return to their tasks.

### Available Commands

- List Tasks
- Add Task
- Complete Task
- Purge Completed Tasks
- Edit Task

## Notes

- The frontend and backend are combined in a single project for simplicity in deployment. Ideally, these should be separated into two distinct projects and deployed in a Docker Compose environment.
- For development, Swagger UI can be accessed at `/swagger/index.html`.

## EF Core Migrations Operations

```bash
Add-Migration InitialCreate -Project Data
Update-Database -Project Data

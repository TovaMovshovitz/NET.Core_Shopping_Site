# NET.Core_Shopping_Site

## Description and Structure
This is a household goods shop site
The project was written with ASP.NET Core 7.0
Its structure is based on REST API, and arranged into 4 layers : UI Layer, Controllers, Bussiness and Data layer.

- UI Layer: This layer handles the presentation and user interface aspects of the API.
- controller: The controller acts as an intermediary between the client and the underlying business logic. It receives requests from the  client, extracts the necessary data from the request, and delegates the execution to the appropriate service or business logic layer.
- Business Layer: The business logic resides in this layer, where various operations and workflows are implemented.
- Repository: The repository layer is responsible for performing database operations, such as CRUD operations and data retrieval.

The layers correspond with each other through Dependency Injection, and through the global Entities project.
DTO entities were also used, in order to prevent circular dependency between the objects and provide encapsulation.
The conversion from entities to DTO object and vice versa was activated with AutoMapper.
The connection to the database via EntitiesFramework of Microsoft, was created by database first.

Integrated Error Handling by middleware, through logging first to file.

Scalability - Async/await programming patterns have been utilized throughout the project to improve performance and responsiveness. Asynchronous operations are employed wherever appropriate to avoid blocking threads and improve the overall system throughput.

The project uses Swagger.

## Error Handling
Comprehensive error handling has been implemented throughout the server-side code and client code. All errors are appropriately handled and logged using the NLog library. A dedicated error handling middleware has been created to centralize the error handling process and ensure consistent error responses.

## Configuration
A configurator has been implemented to handle future changes efficiently. This approach enables easy modification of various settings and configurations without requiring significant code modifications.

## AutoMapper
The project utilizes AutoMapper, a mapping library, to simplify and automate the process of mapping objects between layers. This helps in reducing manual mapping code and improves development productivity

## Installation
1. Clone the repository to your local machine.
2. Run the application.

## Usage
1. Open a Application pages or use swagger.
2. Navigate to the API endpoints to interact with the application.


## Dependencies
### Frameworks
- ASP.NET Core 7.0
### Packages
- Entity Framework Core
- NLog
- zxcvbn-core
- Swashbuckle

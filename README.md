# Pizza Store Management API with Authentication System

### Description
This project provides a RESTful API for managing a pizza store, including toppings management, order handling, and payment processing via credit card and cash. It features a user authentication system.

### Technologies
- **ASP.NET Core**: Primary framework for building the API
- **Entity Framework Core**: Database management
- **C#**: Main programming language
- **Swagger/OpenAPI**: API documentation and testing

### User Documentation
#### Usage
Provides a RESTful API for pizza management, including:
- **GET /api/pizza**: Retrieve a list of all pizzas.
- **POST /api/pizza**: Create a new pizza.
- **PUT /api/pizza/{id}**: Update an existing pizza by ID.
- **DELETE /api/pizza/{id}**: Delete an existing pizza by ID.

### Authentication and Authorization
#### User System Usage
The system includes authentication and authorization for users with different permissions:
- **POST /api/login**: Authenticate a user and generate an authentication token.

### Installation and Execution
#### System Requirements
- .NET Core SDK 3.1 or above
- Visual Studio 2019 or Visual Studio Code

#### Installation Instructions
1. Clone the repository and open the project in your development environment.
2. Edit appsettings.json with appropriate settings (e.g., database connection string).
3. Export and run the API using dotnet CLI or Visual Studio.

### Maintenance and Support
#### Additional Features
Describe additional functionality such as alert events or common troubleshooting file.

### Acknowledgements and Conclusion
Describe the project's achievements, original source or contributors, and fixes and enhancements to improve the user experience.

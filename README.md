# Azure Function EFCore Demo

This Azure Functions project demonstrates how to use Entity Framework Core to perform CRUD operations in a serverless environment. The project includes functions to retrieve, add, update, and delete stock information using an HTTP-triggered approach.

## Prerequisites

- **Azure Subscription**: Ensure you have an active Azure subscription to deploy and run the Azure Functions.

## Setup Instructions

1. **Database Connection**: Update the `ShareDataContext` class in the `DataContext` folder with your database connection string.

    ```csharp
    // In ShareDataContext.cs
    optionsBuilder.UseSqlServer("your_connection_string_here");
    ```

2. **Entity Framework Migrations**: If the database does not exist, you may need to apply Entity Framework migrations to create the required tables. Open a command prompt in the project directory and run the following commands:

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

3. **Azure Functions Configuration**: Make sure to configure the Azure Functions settings, including the database connection string, in the Azure Portal or using local settings for local development.

## Functions Overview

### 1. GetAllPortfolio

- **Endpoint**: `GET` or `POST` request to the function URL.
- **Description**: Retrieves all stock information including associated transactions from the database.

### 2. AddShare

- **Endpoint**: `POST` request to the function URL.
- **Description**: Adds a new stock to the database. Provide stock details in the request body as JSON.

### 3. Update

- **Endpoint**: `POST` request to the function URL.
- **Description**: Updates an existing stock in the database. Provide updated stock details in the request body as JSON.

### 4. Delete

- **Endpoint**: `POST` request to the function URL.
- **Description**: Deletes an existing stock from the database. Provide the stock ID in the request body as JSON.


## Usage

Local Development:

Run the project locally using Visual Studio or the func CLI.
Test the functions using tools like Postman or cURL.

## Deployment to Azure:

Publish the function app to your Azure subscription.
Ensure the required configuration settings are set in the Azure Portal.

## Known Issues

None reported.

## Contributions

Contributions are welcome! Please create an issue or pull request for any improvements or bug fixes.

## License

This project is licensed under the MIT License.

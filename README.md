# UK Parliament - Product Team Home Exercise for Developer

## Dependencies
Please ensure you have the following installed:
* .NET 8 SDK (you may need to ensure your Visual Studio installation is fully up to date)

## Postman
* I have provided pre-populated Postman queries to demonstrate functionality - open Postman and then import the ToDolist_postman_collection.json file - there is a variable for portNumber which will need to be updated to whatever port number you are running the API on locally for these to work

## Introduction

Thank you for taking part in our home exercise. We've provided a template solution to minimize setup and allow you to focus on the core task.

### Getting Started

1. **Clone this repository** and open the solution in Visual Studio.
2. **Set `UKParliament.CodeTest.WebApi` as the startup project.**
3. **Build and run the solution.**
4. Follow the instructions below and refer to the assessment criteria while completing the test.

The solution includes:

- **Web API Project**: A basic Todo List API controller with Swagger/OpenAPI documentation.
- **Services Project**: For housing any services you may require.
- **Data Project**: Includes an in-memory database context and a `Todo` entity. You can seed initial data by uncommenting the relevant code.
- **Tests Project**: For adding your unit tests.

## Submitting Your Test

1. Host your completed solution on GitHub (or another Git-based hosting platform).
2. Provide us with a link to the repository so we can review your solution.

## Test Instructions

### Objective

The goal of this task is to develop the back-end component of a simple to-do list management application. You will build a .NET Core Web API that allows users to perform CRUD (Create, Read, Update, Delete) operations on to-do items. 

This task is focused **exclusively on back-end development**. You do **not** need to implement any front-end or user interface. Instead, think of this Web API as a component that would power a web front-end or a mobile application in a real-world scenario. The API you build should be flexible, well-structured, and adhere to RESTful conventions, making it easy for a front-end developer to consume.

Your responsibilities include designing and implementing the necessary API endpoints, creating the underlying services and data access layers, and writing unit tests to ensure the quality and reliability of your code. While the API should be designed with front-end integration in mind, **your task is solely to build the back-end logic**.

### Requirements

1. **Extend the `ToDo` Entity**:
    - Add the following properties:
      - `Id` (Guid or int)
      - `Title` (string, required, max length 100)
      - `Description` (string, optional, max length 500)
      - `IsCompleted` (bool)
      - `DueDate` (DateTime, optional)
      - (Feel free to add any other properties you deem useful)

2. **Implement API Features**:
    - Create a new to-do item.
    - Retrieve a list of all to-do items.
    - Retrieve a single to-do item by ID.
    - Update an existing to-do item.
    - Delete a to-do item.
    - Mark a to-do item as completed.

3. **Technical Requirements**:
    - .NET Core 8 for the Web API.
    - Entity Framework Core (EF Core) for data access. An in-memory database is pre-configured in the project.
    - Follow RESTful API principles.
    - Write unit tests for your controller and service classes.
    - Implement basic error handling (e.g., handling not found items, validation errors).
    - Use Dependency Injection (DI) to manage dependencies.
    - Adhere to SOLID principles.
    - Track your progress using Git, and ensure your final solution is hosted in a Git repository (e.g., GitHub).


### Assessment criteria

Find the assessment criteria we will use to review your completed test below. You should aim to satisfy all the points on it.

| Assessment area | Assessment criteria |
| ----- | ------ |
|  SOLID principles | 
| Single responsibility principle |  You should structure your code so that each class has a single responsibility. Controllers should also be as lightweight as possible. For example. mapping from an entity to a view model should also be delegated to a separate mapping class. |
| Open-closed principle |  If you add any inheritance with base/derived classes (such as services or repositories), ensure that the inheritance it is architected so that new behaviour can be accommodated without needing to change the code of the base classes, will be flexible if the requirements change, and that the inheritance is not better architectured using abstraction or composition instead. |
|  Liskov substitution principle |   If you add any inheritance with base/derived classes, ensure that derived classes you add (such as services, repositories, mappers or validators) are correctly substitutable for their base classes, will be flexible if the requirements change, and that the inheritance is not better architectured using abstraction or composition instead. |
|  Interface segregation principle |  Classes in your code should only implement interfaces with methods that they actually use. For example, your To-do List services will return and save data. Interfaces used in your code should reflect this. |
| Dependency inversion principle |  You should abstract any dependencies in your back-end code into interfaces, inject them using dependency injection, and mock them where required in unit tests. For example, the services should have an abstraction of the data access code injected rather than a concrete implementation. |
|  Back-end |   
|  Architecture | You should expand upon the N-tier skeleton structure setup in the test template. Data access should use the repository pattern, which injects your database context and interacts with it. The services then use the repository to read/save data. Api Controllers then consume these services. Services and controllers should not use the the database context directly. |
|  Unit tests | Each class you add with public methods should have at least one unit test added to demonstrate how you would unit test that component. Aim to create tests for the relevant service classses.  |
| RESTful conventions |  You should follow RESTful conventions for any endpoints you add into your application in terms of route URLs and HTTP verbs. And also return correct HTTP status codes for responses (for example, 404 when a to-do item isn't found). |
| Validation |   Validation should be added to check values provided for all fields are valid. This includes mandatory data fields. |
|  Database & model | Entities and models should use appropriate types for the data they are storing. For example, a DateTime or DateOnly should be used for a due date, not a string. |

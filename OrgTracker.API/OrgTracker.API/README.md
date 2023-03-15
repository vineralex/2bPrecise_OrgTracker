# OrgTracker
OrgTracker is a C# .NET Core 6 API server side application that allows users to track their organizational structure and data.

## Getting Started
* Clone this repository to your local machine.
* Open the solution file OrgTracker.sln in Visual Studio or your preferred IDE.
* Build the solution to restore NuGet packages and dependencies.
* Run the application using dotnet run command in the terminal or use the Visual Studio's run button.

## API Documentation

### Employee
* GET `/Employee`
Retrieves all employees as a collection of EmployeeDto objects.

* GET `/Employee/{id}`
Retrieves an individual employee by his ID.

* GET `/Employee/GetSubordinaries/{id}`
Retrieves all subordinates of a specified manager as a collection of EmployeeDto objects.

### Report
* GET `/Report/GetReportsFromSubordinaries/{managerId}`
Retrieves all reports submitted by subordinates of a specific manager.

* POST `/Report/{employeeId}/{managerId}`
Creates a new report and assigns it to an employee.

### Task
* GET `/Task/GetTasksAssignedToEmployee/{employeeId}`
Retrieves all tasks assigned to a specific employee.

* POST `/Task/{managerId}/{assignToId}`
Creates a new task assigned to a specific employee and` supervised by a specific manager.

## Technologies Used
* C# .NET Core 6
* Entity Framework Core
* Swagger/OpenAPI
* LocalDb
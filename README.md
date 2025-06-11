#Chair Management System — Team Zeta

Welcome to our project repository! This web application, titled **Chair**, was developed as part of our ASP.NET Core MVC course, under the guidance of our professor. The aim of the project was to understand and apply the concepts of MVC architecture, routing, model binding, views, controllers, Entity Framework Core, and SQL Server integration through a real-world CRUD-based system.

---

#About the Project

Our team, **Zeta**, was assigned the topic “Chair” — and we took that literally! The idea was to create a fully functional system where we could **Create**, **Read**, **Update**, and **Delete** records about chairs. Think of it as a basic inventory system — you can add new chairs, view all chairs in the list, edit their details, and delete them when they’re no longer needed.

In addition to that, we added:
- A **search bar** to find chairs by name.
- A **rating system** (with proper decimal support).
- Proper **data validation** to make sure no invalid data can be submitted.
- A **logo** related to chairs on the main page.
- A **responsive layout** using Razor views and Bootstrap.

We worked through the full development cycle — from creating the MVC project in Visual Studio, to writing code for controllers, models, and views, to configuring routing, performing migrations, seeding initial data, testing with parameters, and finally deploying it locally.

---

##Project Objectives

- Understand the MVC pattern using ASP.NET Core
- Learn to scaffold controllers and views
- Create a functional CRUD application
- Integrate SQL Server using Entity Framework Core
- Implement routing, parameter handling, and query strings
- Seed a database with initial data
- Apply validation rules with data annotations
- Add custom UI features (like search, logo, etc.)
- Learn Git and GitHub for version control and collaboration

---

How to Run the Project

Prerequisites
- Visual Studio 2022 or later
- .NET 7 SDK
- SQL Server (any edition)
- Git

1. Clone the reposenary
   ```bash
   git clone https://github.com/your-username/chair-management-system.git
   cd chair-management-system
Open in Visual Studio
Double-click the .sln file to open the solution.

Run Migrations
Open the Package Manager Console in Visual Studio:

bash
Copy
Edit
Update-Database
This will create the required database and seed it with initial chair data.

Run the Application
Press F5 or use:

bash
Copy
Edit
dotnet run
Open in Browser
Go to https://localhost:7092/Chairs to access the main page.

Features Implemented
CRUD Operations
You can add new chairs, view them in a list, edit existing ones, and delete any entry.

Search Functionality
We added a filter in the Index view that lets you search for chairs by their name using query strings.

Rating Support
Each chair has a rating (0.0 to 5.0), added later via migration. This helps us demonstrate how to evolve the database schema.

Validation
We added data annotations like [Required], [StringLength], and [Range] to ensure proper user input.

Data Seeding
Using a SeedData.cs class, we added initial records to populate the database with a few chairs for demo purposes.

Error Handling
While testing, we ran into a few issues — notably a 500 internal server error — but we learned from it and rebuilt parts of the project. We included logs and debugging steps in our process.

Razor Views & Dynamic Parameters
The views are Razor-based and support dynamic parameters. For example, /HelloWorld/Chair?name=Rick&numtimes=4 was used to display custom messages.

UI Improvements
We customized the layout, added a logo image of a chair, and made the UI more intuitive and clean.

Project Structure
pgsql
Copy
Edit
├── Controllers
│   ├── ChairsController.cs
│   └── HelloWorldController.cs
├── Models
│   ├── Chair.cs
│   └── SeedData.cs
├── Views
│   ├── Chairs
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Details.cshtml
│   │   └── Delete.cshtml
│   └── HelloWorld
│       ├── Index.cshtml
│       └── Chairs.cshtml
├── Program.cs
├── appsettings.json
└── ChairManagementSystem.csproj
Testing
Manual Testing:
Every feature was tested locally multiple times:

Controller actions

View rendering

Query string parameters

Validation errors

CRUD functionality

SQL data consistency

Error Recovery:
On June 10, we faced a major crash (Error 500) due to a configuration issue. After trying several fixes, we decided to rebuild the project from scratch, re-adding all models, views, controllers, and migrations — this gave us a clean slate and resolved the issue.

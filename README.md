# ShipIt Inventory Management

## Setup Instructions
Open the project in VSCode.
VSCode should automatically set up and install everything you'll need apart from the database connection!
Ensure the .NET version in appsettings.json is compatible with your current .NET version installed.

Install Entity Framework Core by running:
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

Update Npgsql and Npgsql.EntityFrameworkCore.PostgreSQL to 6.0.0

### Setting up the Database.

Create 2 new postgres databases - one for the main program and one for our test database.
Ask a team member for a dump of the production databases to create and populate your tables.
Run: /Library/PostgreSQL/15/bin/psql -U postgres -d postgresql://localhost:5432/shipittest -f ./ShipIt-database-dump.sql (on MAC)

Then for each of the projects, add a `.env` file at the root of the project.
That file should contain a property named `POSTGRES_CONNECTION_STRING`.
It should look something like this:
```
POSTGRES_CONNECTION_STRING=Server=127.0.0.1;Port=5432;Database=your_database_name;User Id=your_database_user; Password=your_database_password;
```

## Running The API
Once set up, simply run dotnet run in the ShipIt directory.

## Running The Tests
To run the tests you should be able to run dotnet test in the ShipItTests directory.

## Deploying to Production
Improved inbound order speed - created indices for gcp_cd in gcp (see 24-08-2023-AddIndices.sql).
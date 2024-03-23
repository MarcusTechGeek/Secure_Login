# SECURELOGIN
This is a Secure Login Application built with Blazor Server and .NET Core. It provides user authentication and password reset functionality using ElasticMail for email sending.

Prerequisites
Before running the application, ensure that you have the following installed on your machine:

.NET Core SDK (version 6.0 or later)
Visual Studio Code (or any other code editor of your choice)
Getting Started

1)Clone the repository or download the source code.

2)Open the project folder in Visual Studio Code.

3)Open a new terminal window in Visual Studio Code (Terminal > New Terminal).

4)In the terminal, navigate to the project directory:
cd /path/to/your/project

5)Restore the NuGet packages by running the following command:
dotnet restore
This will restore the following packages required by the application:
BCrypt.Net-Next
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.Sqlite
Microsoft.EntityFrameworkCore.SqlServer
Newtonsoft.Json
ElasticMail

6)Once the package restoration is complete, you need to configure the ElasticMail API key and sender email address in the appsettings.json file. Replace the placeholders with your actual ElasticMail API key and sender email address:
"ElasticMailApiKey": "YOUR_ELASTICMAIL_API_KEY",
"ElasticMailFromEmail": "your_email@example.com"

7)After configuring the ElasticMail settings, you can run the application with the following command:
dotnet run
This will start the application and make it accessible at https://localhost:5001 (or a different port if the default port is already in use).

8)Open a web browser and navigate to https://localhost:5001 to access the Secure Login Application.

Configuration
The application uses an SQLite database file (securelogin.db) by default. If you want to use a different database provider or connection string, update the ConnectionStrings section in the appsettings.json file.

You can also configure the JWT settings, such as the secret key, issuer, and audience, in the JwtSettings section of the appsettings.json file.

Additional Resources
Blazor Documentation
.NET Core Documentation
Entity Framework Core Documentation
JWT Authentication in ASP.NET Core
ElasticMail Documentation


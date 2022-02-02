# hahn-Application-CargorequestManager
A Cargo request management system developed using Angular Framework with material design,.NET Core(5.0), EntityFrameworkCore.SqlServer, Bootstrap.
This is a smiple application that enable user to manage the cargo request from request to assignment. 

# Architecture

This app is developed following the SOLID & Clean Architecture,Mediator Pattern and CQRS Pattern

below are details of the architectures,tools and implementations used in building the application:

 1. Clean or Onion Architecture
 2. Command Query Responsibility Segregation (CQRS) and UnitOfWork
 3. Mediatr Pattern
 4. Email Service using SendGrid
 5. Efficient Exception Handling and Routing
 6. Global Error Handling with Custom Middleware and Exceptions
 7. Validation Using Fluent Validation
 8. Automapper to mapping the DTOs with database models
 9. .NET Core API and Angular UI Application
 10. Docker for the application deployment
 11. Swagger for API documentation
 12. Sql Server for Persistence

Explaining Project Structure:

a. Hann.Application.CargoManager.Domain
   This a standard(5.0) .net classlibary project inside a Core Folder that contains all the domain objects or entity classes that get translated into our database tables. It has    a common folder that    has BaseDomainEntity.cs that contains all the common properties that is required in all the domain objects.
   
b. Hann.Application.CargoManager.Application
   This a standard(5.0) .net classlibary project inside a Core Folder. The purpose of this layer is to sit in between our application, application being whatever 
   would be wanting to access the database and the database. So in this project, I define all of those access parameters to mediate between the calling application 
   and the database itself.
   
c. Hann.Application.CargoManager.Persistence
   This a standard(5.0) .net classlibary project inside a Infrastructure Folder. In the layer we implemented our  generic repository,UnitOfWork for data consistence 
   ,other specific repository and the CargoRequestDbContextSeed.cs for running the migration on application start up.
   
d. Hann.Application.CargoManager.Infrastructure
   This a standard(5.0) .net classlibary project inside a Infrastructure Folder. This infrastructure project is pretty much where the implementations for all the third 
   party services will sits. I currently have only the implementation of an email service with SendGrid sitting in the project.
   
e. Hann.Application.CargoManager.Api
   This a Asp.net core .net 5.0 API project inside a API Folder. The Api project is incharge of inforation exchnage between the project and the client. the infrastructure, 
   the persistance projects, domain and application projects are the base stone on which  the API project depends on to serve the client request. The client application is 
   build into the wwwwrote folder in the API project so both the API and Angular client can be access with the same url. The wwwroot also contains the src folder that has
   the angular source code.
   
f. docker-compose 
   This contains the docker-compose.yml and the docker-compose.override.yml. It contains the details setup for the application and the sqlserver to run from our container.
   
Follow the steps below to run the application from source code:

In order to use this application from the source code, you will need Angular CLI, .NET 5 and NodeJs (14 or above) and any text editor IDE.

To install Angular CLI : run "sudo npm install -g @angular/cli" on terminal for MacOS or run "npm install -g @angular/cli" on Command prompt for windows.

# TO START API AND CLIENT APP:

 Navigate to the Sollution folder that contain projects and the docker-compose.yml
 then run 'docker-compose build' to build it
 then run 'docker-compose up' to start it


# APPLICATION GUIDE:
To begin using the application, Here are a few steps:

* The API with swagger documentation is avaliable on
  http://localhost:8080/swagger/index.html

* The client application is avaliable on. We need to setup the terminal before making a request. 
  http://localhost:8080/


  
Developer : Onwudiwe Cyprain Okeke


# E-Commerce search using Atlas search

## Description of the Project:
This Project is a POC on how Atlas search can be used for ecommerce product search.

Below 2 Scenarios are covered in this POC.
1) Free text search on range of fields. This includes autocomplete also.
2) Search on specific product category and attributes like size for shoe, ram for mobiles etc.

For both the use cases, atlease search index were created with proper type in Mongodb.

Code quality is ensured by referring microsoft recommended coding ruleset throughout the project. This ensures no code is pushed by mistake even with some space issues.

## Application structure:
### - Azure HTTP trigger function
   - We have 2 functions covering the 2 scenarios above. 
   - Swagger definitions are created for the Azure functions.
   - Only necessary services for the function are pushed through dependency injection and avoided unnecessary loading of packages.
   - Settings are currently managed in localsettings.json which can be retrived from Azure keyvalues once deployed in Azure cloud with 0 code change.
   - Error message and code reponse model is created for generic error handling in API response.
   - ILogger is used for logging which implicitly uses application insights when deplyed in Azure.
 
### - Core services
  - It has 2 major services one for MongoDB logic and another for product service logic
  - Automapper is used for dynamic mapping between MongoDB models to DTO models.
  - Newtonsoft is used for proper DTO naming conventions and serialization.
  - MongoDB variables like collection name, keyword name etc are all defined seperately as constanc variables ane used throughout the code whereever needed.
  - Aggregation pipelines are created in a loosely coupled way which makes it easy to understand the logic and maintainability.
  - Singleton MongoDB is created and connections are effectively managed.
  - Dependency injection are defined as micro functions so that they can be consumed by services which need them instead of injectign everything.

### - Model
  - This project has all DTO, DB Models, constants and formatters used throughout the project.

### - Unit testing:
  - Unit testing is written for all the functions in Core and in API. 
  - Mocking of MongoDB is done which can be referred for any future use in C#.
  - Mocking is done in all layers to cover all functional scenarions. 
  - XUnit is ued for Unit testing.

### - CI/CD:
  - Code is checked-in to GIT hub.
  - Created Actions to trigger build everything there is a checkin and pull request.
    - This action executes all unit test cases to make sure no failures
    - It is integrated with Sonarcube cloud to  measure code quality and code coverage.
    - Build is validated against all platforms like MAC/linux/windows.

### - Sonarqube integration:
  - Sonarqube is integrated with GITHUB on every commit and pull request. 
  - Code coverage is around 82 percent. startup and swageer are not covered in unit test which contributes the rest 18 percent.
  - Minor warnign in sonar cube and no medium or high severities reported by sonarcube.

Sonar Qube link: https://sonarcloud.io/summary/overall?id=pihackathon_e-commerce
<img width="1047" alt="Screenshot 2022-02-03 at 11 28 37 PM" src="https://user-images.githubusercontent.com/82909783/152401288-0ced01c0-171d-419a-8324-7c146890204c.png">


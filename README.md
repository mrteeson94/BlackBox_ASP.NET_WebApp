# BlackBox (ASP.NET MVC)
Introducing an exciting and game-changing movie rental web application, built with the cutting-edge ASP.NET MVC framework. Prepare for a "blockbuster" experience like never before!

# Preview (still under development)
![Alt Text](https://github.com/mrteeson94/Blackbox/blob/main/blackbox.gif)

## Table Content
* [Application Summary](#Application-Summary)

* [Technology & Language Used](#Technology-&-Language-Used)

* [Functionality](#Functionality)

## Application Summary
Blackbox is a cutting-edge ASP.NET web application endeavor aimed at offering a comprehensive platform for users (including staff, administrators, and guests) to securely log in, seamlessly access customer and movie information, and effortlessly generate rental orders.

Plans for the project:
* Incorporates a relational database using Entity Framework for seamless data management.
* Develops intuitive forms to capture and store new customer and movie details, while ensuring user restrictions and granting administrative access.
* Implements robust authentication and authorization mechanisms through the Identity framework to ensure secure user interactions.
* Constructs RESTful API web services for efficient communication and data exchange.
* Leverages the power of jQuery, Bootstrap, and bootbox.js to create a user-friendly webpage with a modern touch. The webpage offers a wide range of convenient features, including pagination, sorting, and search filters for tables featured in customer and movie webpages.
* Integrates social media login-authentication options for added convenience and user accessibility.
  
## LATEST TODO LIST 25/06/23:
* Deploy on Azure web app
* Create a CI/CD pipeline for the ASP.NET app
* Utilize Docker for packaging the app environment

## Technology & Language Used
* Framework: ASP.NET Web Application MVC 
* Languages: C#, Jquery, Razor (cshtml), CSS (bootstrap)
* IDE: Visual Studio 2022 (Community version)
* Components (via Nuget Packages): AutoMapper, bootbox, bootstrap, Entity framework (EF6), Datatables(Jquery) 

## Functionality
* Users are able to create rental orders for customers, where movie inventory is automatically updated.
* Authorisation of admins are able to perform all CRUD operations on the webpages (customer and movie) via REST API.
* Implemented pagination, sorting and search filter options are available for users when viewing tables of movies or customers. 
* Social media logins are available for lazy users.

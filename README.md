# Website for Minecraft Server

# Table of contents


- [Requirements](#requirements)
- [Project description](#project-description)
- [future improvements](#future-improvements)
- [Screenshots](#screenshots)
- [License](#license)


## Requirements

[(Back to top)](#table-of-contents)

Project requires ASP NET MVC to build. For building database use Entity Framework.

Database is required in project to build and run.


How to build database:

Disclaimer: databases where project was test: SQL Server or Azure SQL Edge

- provide connection string in appsettings.Development.json or create similar json in secrets.json
- in package manager console type: *update-database* or in project directory type: *dotnet ef database update*
- if everything is configured properly the web application will be hosted and you can create first account
- as for today, the only way to change role for user is to edit user role id in database.


How to send announcement to discord via hook:
- generate discord hook
- provide it in "HookIdAndToken" in appsettings.Development.json or create similar json in secrets.json
- when creating announcement use checkbox to send the announcement to discord

How to enable email confirmation:

- email confirmation functionality was tested using outlook email provider
- provide email sender by editing "Email" and "Password" inside "EmailProvider" which is located in appsettings.Development.json or create similar json in secrets.json
- build and run program in release mode


## Project description

[(Back to top)](#table-of-contents)


The entire project was created by [Krystian Grela](https://github.com/GreysonKrystian/). Initial purpose of project was to create webpage for existing 
minecraft server. Since the project of server was abandoned the main purpose of project is training and expanding knowledge in MVC. The project
contains web application made in ASP.NET MVC framework and database made with DBFirst method in Entity Framework (tested with SQL Server and Azure Sql Edge).
The MVC project is likely to be treated as a beta, because there are plans to rewrite the project using Angular with .NET API (for training purposes).

#### Attention: not every functionality of program was tested and website is not ready to release. Moreover photo upload functionality works only on                                    windows.

Main funtionalities of project: 

- Identity - project uses ASP.NET identity to authorize users and manage access using roles.
- Admin Panel - management of users including checking their profiles and temportary or permanent blocking. 
- Announcements - admins and owners can add announcements for users of webpage, the announcements can then be send to  
- Comments - users can comment announcements or delete them.
- Editing profile - user can edit his profile and upload profile picture
        
## future improvements
  
[(Back to top)](#table-of-contents)

- create forum and finish other minor functionalities such as
- rewrite project in Angular - the main purpose of this is to split the server side and client site, moreover is a great training and opportunity to learn 
angular framework
- test web application with automated tests
- change frontend to English - initial plan was to make whole application in polish language, because the minecraft server was focused on polish players, but since the project of server was suspended, the main aim is to create universal application.
## Screenshots

TODO

[(Back to top)](#table-of-contents)


## License

[(Back to top)](#table-of-contents)


The MIT License (MIT) 2022 - [Krystian Grela](https://github.com/GreysonKrystian/). Please have a look at the [LICENSE.md](LICENSE.md) for more details.




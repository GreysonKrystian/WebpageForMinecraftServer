![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white)
![HTML](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
# Website for Minecraft Server

# Table of contents


- [Requirements](#requirements)
- [Project description](#project-description)
- [future improvements](#future-improvements)
- [Screenshots](#screenshots)
- [License](#license)


## Requirements

[(Back to top)](#table-of-contents)

The project requires ASP NET MVC to be build. Entity Framework is used to create database.
A database is required for the project to build and run.


How to build a database:

#### Databases where project was tested: SQL Server or Azure SQL Edge.

- include connection string in appsettings.Development.json or create similar json in secrets.json
- in package manager console type: *update-database* or in project directory type: *dotnet ef database update*
- if everything is configured properly, the web application will be hosted and you can create first account
- as for today, the only way to change user's role is to edit the user role id in the database.


How to send an announcement to Discord via hook:
- generate discord hook
- provide it in "HookIdAndToken" in appsettings.Development.json or create similar json in secrets.json
- when creating an announcement use the checkbox to send the announcement to Discord.

How to enable email confirmation:
An Outlook email provider was used to test the email confirmation functionality.

- provide email sender by editing "Email" and "Password" inside "EmailProvider", which is located in appsettings.Development.json or create similar json in secrets.json
- build and run program in release mode


## Project description

[(Back to top)](#table-of-contents)


The entire project was created by [Krystian Grela](https://github.com/GreysonKrystian/). The initial purpose of the project was to create webpage for an existing 
minecraft server. Since the project of server was abandoned the primary goal of the project is training and expanding knowledge in MVC. The project
contains a web application made in the ASP.NET MVC framework and database made with the DBFirst method in Entity Framework (tested with SQL Server and Azure Sql Edge).
The MVC project is likely to be treated as a beta, because there are plans to rewrite the project using Angular with .NET API (for training purposes).

#### Attention: not every functionality of program was tested, and the website is not ready to release. Furthermore, the photo upload functionality works only on windows.

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
- change frontend to English - initial plan was to make whole application in Polish language, because the minecraft server was focused on Polish players, but since the project of server was suspended, the main aim is to create a universal application.
## Screenshots
### click on image to zoom in
<strong>MAIN PAGE</strong>:
<br>
<p align="center" width="100%">
<img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/main_page_1.png" width=1500 height= auto>
 <br>
 <br>
 <img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/main_page_2.png" width=1500 height= auto>
<br>
<br>
<img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/main_page_3.png" width=1500 height= auto>
</p>
<br>

<strong>ANNOUNCEMENTS</strong>:
<br>
<p align="center" width="100%">
<img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/announcement_1.png" width=1500 height= auto>
 <br>
 <br>
 </p>
 
<strong>PROFILE</strong>:
<br>
<p align="center" width="100%">
<img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/profile_1.png" width=1500 height= auto>
 <br>
 <br>
 </p>
 
 <strong>ADMIN PANEL</strong>:
<br>
<p align="center" width="100%">
<img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/admin_panel_1.png" width=1500 height= auto>
 <br>
 <br>
 <img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/admin_panel_2.png" width=1500 height= auto>
<br>
<br>
<img alt="Screenshot from main page" src="https://raw.github.com/GreysonKrystian/WebpageForMinecraftServer/master/Screenshots/admin_panel_1.png" width=1500 height= auto>
</p>
<br>

[(Back to top)](#table-of-contents)


## License

[(Back to top)](#table-of-contents)


The MIT License (MIT) 2022 - [Krystian Grela](https://github.com/GreysonKrystian/). Please have a look at the [LICENSE.md](LICENSE.txt) for more details.




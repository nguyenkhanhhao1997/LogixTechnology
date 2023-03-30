## Update Database

### Change connectionstrings

Go to file `~\StudentManagement\StudentManagement\appsettings.json` and change the connectionstrings

### run dotnet-ef

Open Developer Powershell in VS
cd to `StudentManagement` project
run `dotnet-ef database update` to create database

## Run project

### BE

Go to file `~\StudentManagement\StudentManagement\Startup.cs` and change the CORS to your FE link
Run the StudentManagement project

### FE

Go to file `~\StudentManagement\client-app\src\api\apiService.js` and change `API_URL` to your BE link
In the `client-app` open command
run `npm install` to install all packages
run `npm start` to run FE site
List students: `~/home`
Add list students: `~/add-list-student`

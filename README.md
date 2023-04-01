## Create database

Go to file `~\LogixTechnology-BE\LogixTechnology\appsettings.json` and change the connectionstrings

Open Package Manager Console
Set default project is `LogixTechnology.Data`
run `update-database` to create database

## Run project

### BE

Go to file `~\LogixTechnology-BE\LogixTechnology\appsettings.json` and change the `ApiCorsPolicy` to your FE link
Run the project

### FE

Go to file `~\StudentManagement\client-app\src\api\apiService.js` and change `API_URL` to your BE link
In the `client-app` open command
run `npm install` to install all packages
run `npm start` to run FE site
List students: `~/home`
Add list students: `~/add-list-student`

# GitLogAnalysis
Projeto de TCC que analisa dados do GitLog

#Requirements to Run the project (Backend and Frontend)
 - Install .NET Core 3.1 SDK
 - Install Angular CLI version 8.3.20
 - Install MySQL 8.0.25 (Complete installation, with .NET Connector)
 - Install Microsoft Visual Studio Code
 - Install Microsoft Visual Studio 2019 (optional)
 
 
# GitLogAnalysis Client

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 8.3.20.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

# GitLogAnalysis API
This project was generated with [.NET Core 3.1 SDK].

## Create Schema with Entity Framework Core
Install EF Core tools as a global tool running this command. 
```bash
dotnet tool install --global dotnet-ef
```

Access `GitLogAnalisys.Infra` folder and run this dotnet-ef commands:
```bash
dotnet ef database update
```

## Run API
Access `GitLogAnalisys.API/` folder and run this dotnet-ef commands:
```bash
dotnet run
```
Navigate to `http://localhost:5000/`. The app will open the Swagger Page with all Endpoints.

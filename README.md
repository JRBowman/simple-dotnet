# Simple .Net

## Prerequisites
1.  Docker

## Build and Run

### Windows
1.  Run script in powershell
```
start-process run.bat
```
2.  Open [http://localhost:5000](http://localhost:5000)
3.  When done, `ctrl-c` and `y` to terminate `cmd` shell
4.  Stop and remove container from powershell
```
docker stop simple-dotnet
```

### Linux
1.  Run `run.sh`
2.  Open [http://localhost:5000](http://localhost:5000)
3.  Stop and remove container by running the following in another terminal
```
docker stop simple-dotnet
```

## Project Setup
You should never have to do this, but these are the instructions I ran.

1.  Create project
```
dotnet new webapp -auth Windows -o simple-dotnet
```

2.  Setup repo
```
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```

3.  Add dep
```
dotnet add package Microsoft.AspNetCore.Authentication.Negotiate
```

4.  Generate Certs
```
dotnet dev-certs https --clean
dotnet dev-certs https --trust -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p SECRETPASSWORD
```
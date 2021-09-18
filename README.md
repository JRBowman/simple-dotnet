# Simple .Net

## Prerequisites
1.  Docker
2.  Visual Studio Build Tools 2019 (You will need the `dotnet` command)

## Build and Run

### Windows
1.  Run script in powershell
```
start-process run.bat
```
2.  Open [http://localhost:5000](http://localhost:5000)
3.  When done, `ctrl-c` and `Y` to terminate `cmd` shell
4.  Stop and remove container from powershell
```
docker stop simple-dotnet
```

### Linux
1.  Run `run.sh`
2.  Open [http://localhost:5000](http://localhost:5000)
3.  `ctrl-c` to stop
4.  Stop and remove container from powershell
```
docker stop simple-dotnet
```
docker run --rm --name simple-dotnet-builder -v "${PWD}:/app" -it mcr.microsoft.com/dotnet/sdk:5.0 /app/build.sh
docker build -t simple-dotnet .
REM docker run --rm --name simple-dotnet -p "5000:5000" -p "5001:5001" -e ASPNETCORE_HTTPS_PORT=5001 simple-dotnet
docker run --rm --name simple-dotnet -p 5000:5000 -p 5001:5001 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=5001 -e ASPNETCORE_Kestrel__Certificates__Default__Password="SECRETPASSWORD" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v %USERPROFILE%\.aspnet\https:/https/ simple-dotnet
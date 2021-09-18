docker run --rm --name simple-dotnet-builder -v "${PWD}:/app" -it mcr.microsoft.com/dotnet/sdk:5.0 /app/build.sh
docker build -t simple-dotnet .

docker stop simple-dotnet
docker run --rm --name simple-dotnet -p "5000:5000" simple-dotnet
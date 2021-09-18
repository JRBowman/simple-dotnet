FROM mcr.microsoft.com/dotnet/aspnet:5.0

RUN mkdir /app
WORKDIR /app

COPY ./bin/Release/net5.0/* /app

# USER nobody
CMD dotnet simple.dll
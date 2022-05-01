# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY dockerSample_WebApi/*.csproj ./dockerSample_WebApi/
COPY dockerSample_Service/*.csproj ./dockerSample_Service/
RUN dotnet restore

# copy everything else and build app
COPY dockerSample_WebApi/. ./dockerSample_WebApi/
COPY dockerSample_Service/. ./dockerSample_Service/

WORKDIR /source/dockerSample_WebApi
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "dockerSample_WebApi.dll"]
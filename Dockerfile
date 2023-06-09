FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
Workdir /app

Copy ./NLayer.Core/*.csproj ./NLayer.Core/
Copy ./NLayerRepository/*.csproj ./NLayerRepository/
Copy ./NLayerService/*.csproj ./NLayerService/
Copy ./NLayerWeb/*.csproj ./NLayerWeb/
Copy *.sln .
Run dotnet restore
Copy . .
Run dotnet publish ./NLayerWeb/*.csproj -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 
Workdir /app
Copy --from=build /publish .
Env ASPNETCORE_URLS="http://*:5000"
ENTRYPOINT ["dotnet","NLayerWeb.dll"]
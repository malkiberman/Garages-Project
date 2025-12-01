FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Garages.API/Garages.API.csproj", "Garages.API/"]
COPY ["Garages.Data/Garages.Data.csproj", "Garages.Data/"]
COPY ["Garages.Repositories/Garages.Repositories.csproj", "Garages.Repositories/"]

RUN dotnet restore "Garages.API/Garages.API.csproj"

COPY . .

WORKDIR "/src/Garages.API"
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .
EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080

ENTRYPOINT ["dotnet", "Garages.API.dll"]

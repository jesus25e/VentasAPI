FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["Inventory.API/Inventory.API.csproj", "Inventory.API/"]
COPY ["Inventory.Application/Inventory.Application.csproj", "Inventory.Application/"]
COPY ["Inventory.Domain/Inventory.Domain.csproj", "Inventory.Domain/"]
COPY ["Inventory.Infrastructure/Inventory.Infrastructure.csproj", "Inventory.Infrastructure/"]
COPY ["Inventory.Shared/Inventory.Shared.csproj", "Inventory.Shared/"]

RUN dotnet restore "Inventory.API/Inventory.API.csproj"

COPY . .

WORKDIR "/src/Inventory.API"

RUN dotnet publish "Inventory.API.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "Inventory.API.dll"]
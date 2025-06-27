FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000
EXPOSE 50051

ENTRYPOINT ["dotnet", "health-check.dll"]

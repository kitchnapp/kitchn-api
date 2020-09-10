FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

COPY src/ ./
RUN dotnet restore *.sln

WORKDIR /app/Kitchn.API.GraphQL
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/Kitchn.API.GraphQL/out ./
ENTRYPOINT ["dotnet", "Kitchn.API.GraphQL.dll"]

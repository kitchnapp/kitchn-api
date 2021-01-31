#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Kitchn.API.GraphQL/Kitchn.API.GraphQL.csproj", "Kitchn.API.GraphQL/"]
COPY ["Kitchn.API.Data/Kitchn.API.Data.csproj", "Kitchn.API.Data/"]
RUN dotnet restore "Kitchn.API.GraphQL/Kitchn.API.GraphQL.csproj"
COPY . .
WORKDIR "/src/Kitchn.API.GraphQL"
RUN dotnet build "Kitchn.API.GraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kitchn.API.GraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kitchn.API.GraphQL.dll"]
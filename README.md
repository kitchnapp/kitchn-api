# Kitchn

Kitchn is a easy-to-use home food management system. Created for the users.

It aims to be easy to setup, configurable and reliable.

## Docker Setup

With Docker Compose:

```bash
docker-compose build
docker-compose up
```

Without Docker Compose:

```bash
docker build . -t kitchn:test
docker run -it --rm \
  -e ConnectionStrings__KitchnDb=Host=<HOST>;Database=<DB>;Username=<USER>;Password=<PASS> \
  -p 80:80 \
  kitchn:test
```

## Create a Migration

You will need to install the EF dotnet command utilities globally using the following:

```bash
dotnet tool install -g dotnet-ef
```

Change the connection string in `KitchnDbContextFactory.cs` to the comparison database
  and run the following:

```bash
dotnet ef migrations add --project src/Kitchn.Data <Name>
```

## GraphQL API

The URLs which are availabe are:

- GraphQL Query Endpoint: `/graphql`
- GraphQL Playground: `/ui/playground`
- GraphQL Voyager: `/ui/playground`
- GraphQL Altair: `/ui/altair`

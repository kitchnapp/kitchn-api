# Kitchn

Kitchn is a easy-to-use home food management system. Created for the users.

It aims to be easy to setup, configurable and reliable.

## Docker Setup

With Docker Compose:

```bash
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

Change the connection string in `KitchnDbContextFactory.cs` to the comparison database.

```bash
dotnet ef migrations add --project src/Kitchn.Data <Name>
```

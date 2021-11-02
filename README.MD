# Commander API

A rest api built in .Net Core framework 5.0+

## Installation

### - Setup database

Create docker volume:
```bash
docker volume create commander-sql-server
```
Create docker sql-server container:
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=mySuperStrongPassword123" \
   -p 1433:1433 --name commander-sql-server -h sql-server -v sql-server \
   -d mcr.microsoft.com/mssql/server:2019-latest
```
### - Setup .Net
To install dependencies run:

```bash
dotnet restore
```

If you don't have entity framework installed locally you can install Entity Framework with the next command:

```bash
dotnet tool install --global dotnet-ef
```

If you cannot run ```dotnet ef``` command got to this [site](https://stackoverflow.com/questions/62181743/dotnet-ef-does-not-exist-windows-10-wsl-ubuntu) to fix it.

Run database migration if there is not a Migrations folder or u need to update your database schema:
```bash
dotnet ef migrations add <Migration name>
```

Update database:
```bash
dotnet ef database update
```

## Usage

To build your .Net api run:
```bash
dotnet build
```

To execute your .Net api run:
```bash
dotnet run
```

and you can make requests to the endpoint:
```bash
https://localhost:5001/<resource-name>
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
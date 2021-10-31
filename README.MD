# Commander API

A rest api built in .Net Core framework 5.0+

## Installation

To install dependencies run:

```bash
dotnet restore
```

## Usage

```bash
# create docker volume
docker volume create commander-sql-server

# create docker sql-server container
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=mySuperStrongPassword123" \
   -p 1433:1433 --name commander-sql-server -h sql-server -v sql-server \
   -d mcr.microsoft.com/mssql/server:2019-latest

# install entityFramework
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 1.1.0-msbuild3-fina
dotnet tool install --global dotnet-ef

# execute migration
dotnet ef migrations add AddCommandToDB

# update database
dotnet ef database update

# build api
dotnet build

# run api
dotnet run

#test
localhost:5001/api/commands/
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
# FormulaOne
En este proyecto se encuentra desarrollado con .NET 7

## Requisitos
* Visual Studio con Framework .Net 7 instalado.
* Base de datos.
* Installar Entity Framework Cli.
```bash
dotnet tool install --global dotnet-ef
```
### Recomendacion
Usar Docker para usar la una base de datos SQL Server.

* Installar imagen
```bash
sudo docker pull mcr.microsoft.com/mssql/server:2022-latest
```

* Generar instancia de container
```bash
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=*******" -p 1433:1433 --name SqlServerDocker --hostname localhost -d mcr.microsoft.com/mssql/server:2022-latest
```
  
## Pasos a seguir
* Modificar el conexion string del archivo "appsettings.json" en el proyecto FormulaOne.Api
```bash
"ConnectionStrings": {
  "FormulaOneDBConnection": "server=localhost; database=FormulaOne; User Id=sa; Password=**********; trustServerCertificate=true;"
}
```
* Ejecutar el bat "InitDataBase.bat" que se encuentra root. Este bat impacta la migracion de la base de datos.
* Correr la aplicacion (http://localhost:5014/swagger/index.html).

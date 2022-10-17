# LabNet2022

## Lab de .NET Framework y Angular 

### TP8

¿Qué encontrás en este proyecto?

- Un proyecto WebAPI con acciones CRUD que trabajan sobre la entidad [**Shippers**](https://github.com/Marcelo1197/LabNet2022/blob/tp8/Crud.NorthW.App/Crud.NorthW.App.Entities/Shippers.cs) Esta WebAPI es consumida por la app shippers-crud de Angular.

### Ejecutar y Configurar WebAPI
- Configurar el [connectionString](https://github.com/Marcelo1197/LabNet2022/blob/c1469a0739af9e50d16d690897c87472157246bd/api-shippers/Crud.NorthW.App/Crud.NorthW.App.Data/App.config#L17) en el archivo de configuracion de la capa de datos. Se debe asignar a `data source=`el nombre de su conexión de SQL Server.
- Click derecho sobre el proyecto **Crud.NorthW.App.WebAPI** y elegir **Set as Startup Project**
- Correr el proyecto con F5 o clickeando el botón **IIS Express** en la Toolbar

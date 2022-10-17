# LabNet2022

## Lab de .NET Framework y Angular 

### TP9 - App CRUD de Angular consumiendo API Local de .NET

¿Qué encontrás en este proyecto?

- Una app tipo CRUD desarrollada en Angular que consume la api de Shippers desarrollada anteriormente en el TP9
- La API Shippers lista para correr y ser utilizada por la app de Angular

### Ejecutar API Shippers
- Configurar el [connectionString](https://github.com/Marcelo1197/LabNet2022/blob/c1469a0739af9e50d16d690897c87472157246bd/api-shippers/Crud.NorthW.App/Crud.NorthW.App.Data/App.config#L17) en el archivo de configuracion de la capa de datos. Se debe asignar a `data source=`el nombre de su conexión de SQL Server.
- Click derecho sobre el proyecto **Crud.NorthW.App.WebAPI** y elegir **Set as Startup Project**
- Correr el proyecto con F5 o clickeando el botón **IIS Express** en la Toolbar

### Ejecutar APP Crud Angular
- Posicionarse en la raíz del proyecto /shippers-crud
- Ejecutar `npm i`
- Ejecutar `npm serve` 

### Recursos utilizados en la App de Angular
- [Angular Material](https://material.angular.io/guide/getting-started)
- [Bootstrap](https://getbootstrap.com/)
- [Ngx Awesome Popup](https://costlydeveloper.github.io/ngx-awesome-popup/#/)

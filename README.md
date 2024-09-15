# Prueba Técnica Desarrollador SQL, .net, Angular 18 y D3


1. En la carpeta "Documentación" se agregó el diagrama de arquitectura de la solución con el cual se realizó la aplicación: este diagrama se hizo cumpliendo los principios SOLID y KISS con el patrón de diseño para el Back de n-capas, siendo en este caso de 3 capas (API, Business, DataAccess).
2. Todo está hecho con programación orientada a objetos.
3. El backend en su capa "DataAccess" consume/accede la base de datos en SQL server, de igual forma, el Front consume al back como una REST API atraves de sus diferentes servicios.
4. Se realizo control de versión con GitHub--> este repositorio.
5. Para los estilos se usó SCSS con angular material en el frontend (se puede apreciar en la configuración y en los archivos (.scss).
6. El Backend se desarrolló en .Net con Entity Framework y .Net framework.
6.1. El backend cuenta con:
* EntityFramework
* DataAnnotation
* Automapper
* .Net Framework
* ASP NET
7. El frontend se desarrolló  con Angular 18.
7.1. El frontend cuenta con:
* Archivo de config.
* Injections Tokens.
* Interceptors.
* Spinner de carga.
* Enrutamiento con lazy loading.
* Estilos personalizados con SCSS.
* Uso de Angular material.
* Footer y Header.
* Uso de modales y controladores de estado.


## Prerequisito para la ejecución:


1. Tener node v18.19.0.
2. Tener angular cli 18.2.4.
3. Tener en SQL Server la base de datos de la prueba.}

## Instrucciones para la ejecución:


1. Abrir la carpeta de la API REST (Web-API) en visual estudio.
2. Instalar dependencias faltantes (en caso de faltar).
3. Ejecutar proyecto.
4. Abrir un terminal en la carpeta Front(Sales-Date-Prediction-app).(cd Front desde la consola).
5. Ejecutar npm i en la consola.
5. 1. En caso de error ejecutar: npm i --force 
6. Ejecutar ng g -o
7. Se abrira el navegador con la URL http://localhost:4200/ 

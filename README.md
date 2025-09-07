# TestDoubleV_BackEnd
BackEnd de prueba técnica para le entidad Double V Partner.  

##Precondiciones:  
    - Instalar (Si no lo tiene) el paquete de NET 9 (SDK, RunTime y Hosting Bundle: https://dotnet.microsoft.com/es-es/download/dotnet/9.0).  
	- Instalar un editor de código si se desea trabajar con CLI y dotnet o Visual Studio si desea un entorno que facilite las cosas, inclusive puede instalar desde este último el paquete de NET 9.  
	- Instalar Git si se desea realizar commits.  

##Clonar el proyecto a un directorio local (Si se está viendo este archivo desde el repositorio remoto en la web).  
(1) git clone https://github.com/luiseduardovillarreal/TestDoubleV_BackEnd.git  
(2) git checkout main / moverte en el VS a la rama main  

##Configurar parametros como la base de datos, IP de quien puede realizar peticiones, etc. para los dos micro servicios recién clonados..  
(1) En la raíz del proyecto ve al archivo appsettings.json, este archivo contiene todo lo parametrizable del API (Conexión a BD, IPs, etc.).  

##Consideración y datos relevantes  
(1) No necesita Script SQL para base de datos, puede correr las APIs que la API Movement tiene configurada el lanzamiento de la migración, creando en base de datos: menús, submenús, roles, perfiles, un usuario administrador y la debida relación entre todos, sólo es correrlas, correr el Front e iniciar sesión.  
(2) Correo usuario administrador: super.admin@superadmin.com.co  
(3) Password usuario administrador: U53r5up3r4dm1n157r4d0r.2025*  

##Tenemos el BackEnd arriba.
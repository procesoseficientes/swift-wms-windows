# WMS Swift Windows
Este repositorio tiene las versiones de Swift 3PL para Windows CE, Backoffice de Escritorio y Web.

El repositorio tiene tanto el código como los binarios del software.

## Estructura general de los archivos
* `WmsOnePlan` tiene el Backoffice
  * `WMSOnePlan_Client` es el cliente Win32
  * `WMSOnePlan_WebForm` es el cliente Web ASP.net
* `ConfiguracionBotonesYModeloDispositivo` es una aplicación para Windows CE para ver y confirugrar los botones de Handhelds
* `Swift3PLMobile` es la versión de Windows CE de la aplicación
  * En este repo la versión móvil está desactualizada
* Todos los demas directorios son liberarias compartidas por todos los programas

## Cliente Win32
### Dependencias
- DevExpress 19.2
- Visual Studio 2017+
- IIS
- .Net Extensibility 3.5 y 4.5+
- ASP.NET 3.5 y 4.5+

Este repoo inicia en el último commit del branch `G-Force@Paris`
### Instalación
#### Instalación de IIS y ASP.NET
1. Navegar a:
`Control Panel` -> `Programs and Features` -> `Turn Windows features on or off`
2. Chequear `Internet Information Services`
3. Expandir `Internet Information Services`-> `World Wide Web Services` -> `Application Development Features`
4. Chequear ISAPI, ASP.NET 3.5 y 4.6 y .Net Extensibility 3.5 y 4.6
5. Correr el siguiente comando:
```bash
%windir%\Microsoft.NET\Framework64\v4.0.30319\aspnet_regiis.exe -ir
```

#### Configurar Web Service
![Captura de pasos](WebServiceSteps.jpg)
1. Dentro del IIS Manager, en las acciones del sitio por defecto (Default Web Site) cliquear en `“Bindings”`
2. Agregar el puerto 8088
3. Clic derecho en `Default Web Site` -> `Add Application`
4. Ingresar la siguiente información
  - Alias: `WMSOnePlan_BussinessServices`
  - Path: `<repo>/WmsOnePlan/WmsOnePlan/WMSOnePlan_BussinessServices`
  - Connect As: `Ingresar credenciales de usuario`
5. Agregar aplicación
6. Probar que el servicio funcione navegando a [http://localhost:8088/WMSOnePlan_BusinessServices/Catalogues/WMS_Security.asmx](http://localhost:8088/WMSOnePlan_BusinessServices/Catalogues/WMS_Security.asmx)

#### Visual Studio
1. Abrir Visual Studio como administrador
2. Abrir la solución en `/WmsOnePlan/WmsOnePlan/WmsOnePlan.sln`
3. Dentro del proyecto `WmsOnePlan_Client`  agregar las referencias a los dll en el directorio `/WmsOnePlan/WmsOnePlan/DLLs`
4. Probar correr programa con F5

### Configución con DB
Los datos para configurar la DB en el backend está en `WMSOnePlan_BussinessServices/Web.config` en la llave `DESARROLLO`.

`<add key="DESARROLLO" value="Server=`**`<ip del servidor deprueba>`**`,1433;Database=`**`<nombre de la DB deprueba>`**`;User=`**`<usuario>`**`;Pwd=`**`<SQ1MSCM!9>`**`"/>`

Los datos para configurar la DB en el frontend está en `WMSOnePlan_Client/App.config` en las llaves `ConnectionString` y `SERVER_IP`.


Los datos dentro del servidor de prueba son:
- Database: `OP_WMS_ALSERSA`
- User: `sa`
- Pwd: `SQ1MSCM!9`

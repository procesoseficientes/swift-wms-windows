1. Cambiar la configuración de la solución a `Release`
2. Cambiar la versión de Assembly en `WmsOnePlan/WMSOnePlan_Client/My_Proyect/AssemblyInfo.vb`
  - Este es el patrón para las versiones, "`año`.`mes`.`día`.`versión de ese día`"
3. Compilar solución
4. Comprometer y empujar los cambios con una descripción clara de los cambios que tiene ese release
5. Comprimir los archivos en el directorio `WmsOnePlan\WMSOnePlan_Client\bin\Release`
6. Preferiblemente crear un Pull Request de la rama donde se hicieron los cambios a la principal
7. Crear el release en [Github](https://github.com/procesoseficientes/swift-wms-windows/releases)
8. Subir el archivo comprimido de Release en la sección de `Binario` en Github
9. Públicar el Release

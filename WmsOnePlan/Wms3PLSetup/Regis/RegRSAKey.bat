set @pathAplicacion=%~dp0
@SET @pathFramework=
@for /F "tokens=1,2*" %%i in ('reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v "InstallPath"') DO (
    if "%%i"=="InstallPath" (
        SET "@pathFramework=%%k"
    )
)


set @keyFile=ConfigWmsD.xml
set @keyFullPath=%@pathAplicacion%%@keyFile%
set @userName="%USERNAME%"
set @domainControl="%USERDOMAIN%"
set @fullname="%USERDOMAIN%\%USERNAME%"

cd /d "%@pathFramework%"

if exist "%@keyFullPath%" (
    rem file exists
	aspnet_regiis -pz "ConfigWmsD"    	
	aspnet_regiis -pi "ConfigWmsD"  "%@keyFullPath%"
	aspnet_regiis -pa ConfigWmsD %@fullname%
	del "%@keyFullPath%"	
) 
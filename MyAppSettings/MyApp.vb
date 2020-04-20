Public Module MyApp
    Dim path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
    Dim filename = "AppSettings.xml"

    Public AppSettings As MyAppSettings = New MyAppSettings(path, filename)

End Module


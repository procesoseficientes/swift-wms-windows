Imports System.Configuration
Imports System.Data.SqlClient
Imports DevExpress.LookAndFeel.Design
Imports MobilityScm.Utilerias

Public Class ConfiguracionDeConexion
    Implements IConfiguracionDeConexion

    Public ReadOnly Property StringConnection As String Implements IConfiguracionDeConexion.StringConnection


    Public Sub New()
        
        StringConnection = My.Settings.ConnectionString
    End Sub

    Public ReadOnly  Property Esquema() As String Implements IConfiguracionDeConexion.Esquema
        get
            Return My.Settings.Schema 
        End Get
    end property 

End Class
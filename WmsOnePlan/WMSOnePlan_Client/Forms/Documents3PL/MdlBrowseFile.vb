Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Diagnostics.Eventing.Reader
Imports Microsoft.VisualBasic

Module MdlBrowseFile
    Sub importarExcel(ByVal tabla As DataGridView, ByVal LblRowsLoad As Label)
        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString

            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            xSheet = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            conn = New OleDbConnection( _
                              "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                              "data source=" & ExcelFile & "; " & _
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            Try
                da = New OleDbDataAdapter("SELECT * FROM  [" & xSheet & "$]", conn)

                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                tabla.DataSource = ds
                tabla.DataMember = "MyData"
            Catch ex As Exception
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            Finally
                conn.Close()
            End Try
        End If
        LblRowsLoad.Text = "Se han cargado exitosamente " + tabla.Rows.Count.ToString() + " registros"
        'MsgBox("Numero de registros cargados correctamente: " + Limit.ToString(), MsgBoxStyle.Information, "Importado con exito")
    End Sub


    Public Function ImportExcellToDataGridView(ByVal tabla As DataGridView, ByVal LblRowsLoad As Label)
        Try
            Dim myFileDialog As New OpenFileDialog()

            With myFileDialog
                .Filter = "Excel Files |*.xlsx"
                .Title = "Open File"
                .ShowDialog()
            End With
            If myFileDialog.FileName.ToString <> "" Then

            End If
            Dim ExcelFile As String = myFileDialog.FileName.ToString
            Dim stConexion As String = ( _
                              "Provider=Microsoft.ACE.OLEDB.12.0;" & _
                              "data source=" & ExcelFile & "; " & _
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [" + FrmInventoryAdd.Gtipo + "S$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter
            Dim Dt As New DataTable

            FrmInventoryAdd.GlobalUrlFileExt= ExcelFile
            FrmInventoryAdd.GlobalNameFileExt="Select * From [" + FrmInventoryAdd.Gtipo + "S$]"

            
            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0)

            'If DataSet.Tables(0).Rows(0).Item("FieldName") Is DBNull.Value Then
            Dim j As Integer
            Dim k As Integer
            For Each dataRow As DataRow In Dt.Rows
                j = j + 1
                If dataRow.Item("CODIGO") Is DBNull.Value Then ' If IsDBNull(Dt.Rows(j)) Then
                    Dt.Rows(j).Delete()
                    k = k + 1

                    ' MsgBox("Informacion: Se encontraron " + k + " filas vacias", MsgBoxStyle.Information, "Error en  archivo")
                End If

            Next
            'MessageBox.Show("Se han eliminado: " + k.ToString() + " filas vacias")


            If (Dt.Columns.Count = 6) Then
               ' tabla.Columns.Clear()
               ' tabla.DataSource = Dt
                
                Dim filas As Integer = tabla.Rows.Count
                LblRowsLoad.Text = "Se han cargado exitosamente " + filas.ToString() + " registros"
            Else
                MessageBox.Show("Numero de columnas Incorrecto, verificar archivo")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            ' MsgBox("Informacion: El nombre de la hoja no corresponde a <Ingresos>" + ex.Message, MsgBoxStyle.Information, "Error en carga de archivo")
        End Try
        Return True
    End Function

    Private Function stConexion() As String
        Throw New NotImplementedException
    End Function
End Module

'DataSet.Clear()             ' Elimina la información antigua.
'dataAdapter.Fill(DataSet)   ' Recarga la nueva información.
'DataGrid1.ResetBindings()   ' Vuelve a mostrar los datos.
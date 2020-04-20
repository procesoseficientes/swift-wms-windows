Imports System.IO
Imports System.Data
Imports System.Web.UI.WebControls.Expressions
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.Charts.Native
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Imports System.Data.SqlClient

Public Class FrmInventoryFile
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim pResult As String
    Private Sub BtnUpload_Click(sender As Object, e As EventArgs)
        'importarExcel(DgvLoadInventory, LblRows)
        ImportExcellToDataGridView(DgvLoadInventory, LblRows)
    End Sub
    Private Sub FrmInventoryFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fn_llena_combos()
    End Sub
   

    Private Sub DgvLoadInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        'Dim registro As String = Convert.ToString(DgvLoadInventory.CurrentRow.Index())
        'Dim indice As Integer = Convert.ToInt16(registro)
        'TxtDgvSKU.Text = (DgvLoadInventory.Item(0, indice).Value)
        'TxtDgvDescripcion.Text = (DgvLoadInventory.Item(1, indice).Value)
        'TxtDgvUMedida.Text = (DgvLoadInventory.Item(2, indice).Value)
        'TxtDgvCantidad.Text = (DgvLoadInventory.Item(3, indice).Value)'TxtDgvPrecio.Text = (DgvLoadInventory.Item(4, indice).Value)
        'TxtDgvTotal.Text = (DgvLoadInventory.Item(5, indice).Value)
    End Sub
    Private Sub fn_llena_combos()
        Try

        Catch ex As Exception

        End Try
        Dim i As Integer
        'llenamos el combo de los clientes
        Dim dsClientes As New DataSet
        dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)


        If pResult = "OK" Then
            If Not IsNothing(dsClientes) Then
                CmbClientes.Properties.DataSource = dsClientes.Tables(0)
                cmbClientes.Properties.PopulateViewColumns()
                cmbClientes.Properties.ValueMember = "CLIENT_CODE"
                CmbClientes.Properties.DisplayMember = "CLIENT_NAME"

                For i = 0 To CmbClientes.Properties.View.Columns.Count - 1
                    CmbClientes.Properties.View.Columns(i).Visible = False
                Next

                CmbClientes.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                CmbClientes.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                CmbClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
                CmbClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
                CmbClientes.Properties.View.BestFitColumns()

            End If
        End If
    End Sub

 
    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles BtnSend.Click

    End Sub
End Class

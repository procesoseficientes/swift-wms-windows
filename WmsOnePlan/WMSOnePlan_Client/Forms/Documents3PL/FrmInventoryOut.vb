Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization
Imports DevExpress.XtraGrid.Helpers
Imports DevExpress.XtraReports.Design
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports System.Diagnostics.Eventing.Reader
Imports Microsoft.VisualBasic

Public Class FrmInventoryOut

    Public gCustomerCode As String
    Public gCustomerName As String
    Public gencabezado As String
    Public gresultado As String
    Public glicense As String
    Public gPoliza As String
    Public gAcuerdo As String
    Public gfecha As String
    Public Rpoliza As String
    Public gINSURANCE As String
    Public GRegistos As String
    Public Gfilas As Integer
    Public Dt As New DataTable
    Dim Cn As New SqlConnection("")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xWarehouseServ As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx") 'As New OnePlanServices_Locations.WMS_LocationsSoap("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_")
    Dim xTransServ As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim pResult As String


    Private Sub GLUClientes_EditValueChanged(sender As Object, e As EventArgs)
        gCustomerCode = GLUClientes.EditValue
        gCustomerName = GLUClientes.Properties.GetDisplayTextByKeyValue(GLUClientes.EditValue)
        DtaDate.Enabled = True
    End Sub


    Private Sub FillCombo(ByVal consulta As String, ByVal display As String, ByVal value As String, ByVal cmb As ComboBox)
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = consulta
            .Connection = Cn
        End With
        Da.SelectCommand = Cmd
        Dt = New DataTable
        Da.Fill(Dt)
        With cmb
            .DataSource = Dt
            .DisplayMember = display
            .ValueMember = value
        End With
    End Sub
    Private Sub FrmInventoryOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SaveToolStripButton1.Enabled = False
        SaveToolStripButton.Enabled = False
        System.Threading.Thread.CurrentThread.CurrentCulture =
          New System.Globalization.CultureInfo("es-GT")
        System.Threading.Thread.CurrentThread.CurrentUICulture =
        New System.Globalization.CultureInfo("es")
        DtaDate.Properties.Mask.Culture = New CultureInfo("es-GT")
        DtaDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        GLUClientes.Focus()
        DtaDate.Enabled = False
        BtnUpload.Enabled = False
        FillComboClientes()
    End Sub
    Private Sub FillComboClientes()
        gCustomerCode = Nothing
        gCustomerName = Nothing
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dsClientes As New DataSet
        dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            If Not IsNothing(dsClientes) Then
                GLUClientes.Properties.DataSource = dsClientes.Tables(0)
                GLUClientes.Properties.PopulateViewColumns()
                GLUClientes.Properties.ValueMember = "CLIENT_CODE"
                GLUClientes.Properties.DisplayMember = "CLIENT_NAME"
                For i = 0 To GLUClientes.Properties.View.Columns.Count - 1
                    GLUClientes.Properties.View.Columns(i).Visible = False
                Next
                GLUClientes.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                GLUClientes.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                GLUClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
                GLUClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
                GLUClientes.Properties.View.BestFitColumns()
            End If
        End If
    End Sub


    Private Sub DtaDate_EditValueChanged(sender As Object, e As EventArgs)
        gfecha = DtaDate.EditValue
        BtnUpload.Enabled = True
        BtnUpload.Visible = True
    End Sub

    Public Function ImportExcellToDataGridView()
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
            Dim stConexion As String = (
                              "Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "data source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")
            Dim cnConex As New OleDbConnection(stConexion)
            Dim Cmd As New OleDbCommand("Select * From [" + FrmInventoryAdd.Gtipo + "S$]")
            Dim Ds As New DataSet
            Dim Da As New OleDbDataAdapter

            'ImportExcellToDataGridViewExtracted()

            FrmInventoryAdd.GlobalUrlFileExt = ExcelFile
            FrmInventoryAdd.GlobalNameFileExt = "Select * From [" + FrmInventoryAdd.Gtipo + "S$]"



            cnConex.Open()
            Cmd.Connection = cnConex
            Da.SelectCommand = Cmd
            Da.Fill(Ds)
            Dt = Ds.Tables(0).Select("CODIGO IS NOT NULL").CopyToDataTable()
            Dt.TableName = "ExcelSource"


            If (Dt.Columns.Count = 6) Then
                ' tabla.Columns.Clear()
                ' tabla.DataSource = Dt
                GCEgreso.DataSource = Nothing
                GCEgreso.DataSource = Dt

                '
                Gfilas = Dt.Rows.Count

                '
                GridView1.ViewCaption = "Se han cargado exitosamente " + Gfilas.ToString() + " registros"
                TabPane1.SelectedPage = TabNavigationPage1
                NotifyStatus(GridView1.ViewCaption, False, False)
                SaveToolStripButton1.Enabled = True

            Else
                MessageBox.Show("Numero de columnas Incorrecto, verificar archivo")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
        Return True
    End Function



    Private Sub DtaDate_EditValueChanged_1(sender As Object, e As EventArgs) Handles DtaDate.EditValueChanged
        BtnUpload.Visible = True
        BtnUpload.Enabled = True
    End Sub

    Private Sub BtnUpload_Click_1(sender As Object, e As EventArgs) Handles BtnUpload.Click
        ImportExcellToDataGridView()
        SaveToolStripButton.Enabled = True
    End Sub


    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        ImportExcellToDataGridView()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click


        Dim xdataset As New DataSet
        Dim xdatatable As New List(Of DataTable)
        xdatatable.Add(Dt)

        xTransServ.ReceiveInventoryFromFileExcel(Dt, PublicLoginInfo.LoginID, gCustomerCode, PublicLoginInfo.Environment)

        TabPane1.SelectedPage = TabNavigationPage3
        NotifyStatus(GridView3.ViewCaption, False, False)

        ReviewProcessExternalDispatch()
        SaveToolStripButton1.Enabled = True
    End Sub



    Private Sub ReviewProcessExternalDispatchUpdate()
        GridControl1.DataSource = xTransServ.GetReviewDispatchForExternalUpdate(PublicLoginInfo.Environment)
    End Sub
    Private Sub ReviewProcessExternalDispatch()
        dim dt = xTransServ.GetReviewDispatchForExternal(PublicLoginInfo.Environment)
        GridControl1.DataSource = dt
        Dim expression As String
        expression = "PROCESS_RESULT <> 'OK'"
        Dim foundRows() As DataRow
        foundRows = dt.Select(expression)
        SaveToolStripButton1.Visible = Not (foundRows.Length > 0)
    End Sub


    Private Sub ProcessExternalDispatch()
        Dim ProcessResult As String
         ProcessResult = xTransServ.ResultProcessDispatchExternal(PublicLoginInfo.Environment, DtaDate.DateTime.Date)
        ReviewProcessExternalDispatchUpdate()
        Try

            If (ProcessResult.ToString = "EXITO") Then
                GridView3.ViewCaption = "Se han procesado Correctamente Los Registros"
                Dim result As Integer = MessageBox.Show("Archivo procesado, ¿Desea Procesar un Nuevo Archivo?", "WMS OnePlan, Inventario Externo", MessageBoxButtons.YesNo)
                If result = DialogResult.Cancel Then
                ElseIf result = DialogResult.No Then
                ElseIf result = DialogResult.Yes Then
                    TabPane1.SelectedPage = TabNavigationPage1
                    NotifyStatus(GridView1.ViewCaption, False, False)
                    GCEgreso.DataSource = Nothing
                    SaveToolStripButton1.Enabled = False
                End If
            Else
                NotifyStatus(ProcessResult.ToString, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub


    Private Sub GLUClientes_EditValueChanged_1(sender As Object, e As EventArgs) Handles GLUClientes.EditValueChanged
        gCustomerCode = GLUClientes.EditValue
        gCustomerName = GLUClientes.Properties.GetDisplayTextByKeyValue(GLUClientes.EditValue)
        DtaDate.Enabled = True
    End Sub

    Private Sub SaveToolStripButton1_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton1.Click
        ProcessExternalDispatch()
        SaveToolStripButton1.Enabled = False
    End Sub
End Class






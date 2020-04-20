Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data.OleDb
Imports System.Data
Imports System.Threading.Thread
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraEditors.Calendar

Imports System.Linq


Public Class FrmInventoryExtAdd
    Public Shared GlobalUrlFileExt As String
    Public Shared GlobalNameFileExt As String
    Public gCustomerCode As String
    Public gCustomerName As String
    Public gWarehouse As String
    Public glocation As String
    Public glicense As String
    Public gEncabezado As String
    Public gPoliza As String
    Public gAcuerdo As String
    Public gfecha As Date 'String
    Public Rpoliza As String
    Public GResultado As String
    Public GRegistos As String
    Dim arrCadena As Array()
    Public Shared Gtipo As String = ""
    Public Shared Gsigno As String = ""
    Dim cn As New SqlConnection("")
    Public Gfilas As Integer
    Public Dt As New DataTable
    Dim Regristro As Integer = 0




    'WS Cliente
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xWarehouseServ As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx") 'As New OnePlanServices_Locations.WMS_LocationsSoap("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_")
    Dim xTransServ As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim xct As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim pResult As String


    Private Sub FrmInventoryAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture =
          New System.Globalization.CultureInfo("es-GT")
        System.Threading.Thread.CurrentThread.CurrentUICulture =
        New System.Globalization.CultureInfo("es")
        DtaDate.Properties.Mask.Culture = New CultureInfo("es-GT")
        DtaDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        ' DtaDate.Properties.Mask.UseMaskAsDisplayFormat = True

        FillComboClientes()
        GLUBODEGA.Enabled = False
        GLUUBICACIONES.Enabled = False
        GLUPoliza.Enabled = False
        GLCAcuerdo.Enabled = False
        DtaDate.Enabled = False
        BtnUpload.Enabled = False
        TabNavigationPage3.Visible = False
    End Sub


    Private Sub GLUClientes_EditValueChanged(sender As Object, e As EventArgs) Handles GLUClientes.EditValueChanged
        gCustomerCode = GLUClientes.EditValue
        gCustomerName = GLUClientes.Properties.GetDisplayTextByKeyValue(GLUClientes.EditValue)
        FillComboBodegasdos()

    End Sub


    Private Sub GLUUBICACIONES_EditValueChanged(sender As Object, e As EventArgs) Handles GLUUBICACIONES.EditValueChanged
        glocation = GLUUBICACIONES.EditValue
        FillComboPoliza()
    End Sub

    Private Sub GLUPoliza_EditValueChanged(sender As Object, e As EventArgs) Handles GLUPoliza.EditValueChanged
        gPoliza = GLUPoliza.EditValue
        FillComboAcuerdo()
    End Sub

    Private Sub GLCAcuerdo_EditValueChanged(sender As Object, e As EventArgs) Handles GLCAcuerdo.EditValueChanged
        gAcuerdo = GLCAcuerdo.EditValue
        DtaDate.Enabled = True
    End Sub

    Private Sub DtaDate_EditValueChanged(sender As Object, e As EventArgs) Handles DtaDate.EditValueChanged
        gfecha = DtaDate.EditValue
        BtnUpload.Enabled = True
        BtnUpload.Visible = True
    End Sub


    Private Sub FillComboClientes()
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dsClientes As New DataSet
        dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
        GLUClientes.Properties.DataSource = dsClientes.Tables(0)
        'If pResult = "OK" Then
        '    If Not IsNothing(dsClientes) Then
        '        GLUClientes.Properties.DataSource = dsClientes.Tables(0)
        '        GLUClientes.Properties.PopulateViewColumns()
        '        GLUClientes.Properties.ValueMember = "CLIENT_CODE"
        '        GLUClientes.Properties.DisplayMember = "CLIENT_NAME"
        '        For i = 0 To GLUClientes.Properties.View.Columns.Count - 1
        '            GLUClientes.Properties.View.Columns(i).Visible = False
        '        Next
        '        GLUClientes.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
        '        GLUClientes.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
        '        GLUClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
        '        GLUClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
        '        GLUClientes.Properties.View.BestFitColumns()
        '    End If
        'End If
    End Sub
    Private Sub FillComboBodegasdos()
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dsBodegas As New DataSet
        dsBodegas = xWarehouseServ.GetWareHouseEnabled(pResult, PublicLoginInfo.Environment)
        GLUBODEGA.Properties.DataSource = dsBodegas.Tables(0)
        GLUBODEGA.Enabled = True
        'If pResult = "OK" Then
        '    If Not IsNothing(dsBodegas) Then
        '        GLUBODEGA.Properties.DataSource = dsBodegas.Tables(0)
        '        GLUBODEGA.Properties.PopulateViewColumns()
        '        GLUBODEGA.Properties.ValueMember = "WAREHOUSE_ID"
        '        GLUBODEGA.Properties.DisplayMember = "NAME"
        '        For i = 0 To GLUBODEGA.Properties.View.Columns.Count - 1
        '            GLUBODEGA.Properties.View.Columns(i).Visible = False
        '        Next
        '        GLUBODEGA.Properties.View.Columns("WAREHOUSE_ID").Caption = "CODIGO"
        '        GLUBODEGA.Properties.View.Columns("NAME").Caption = "NOMBRE"
        '        GLUBODEGA.Properties.View.Columns("WAREHOUSE_ID").Visible = True
        '        GLUBODEGA.Properties.View.Columns("NAME").Visible = True
        '        GLUBODEGA.Properties.View.BestFitColumns()
        '    End If
        'End If
    End Sub

    Private Sub FillComboUbicaciones()
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dsUbicaciones As New DataSet

        dsUbicaciones = xWarehouseServ.GetLocationsByWH(gWarehouse, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            If Not IsNothing(dsUbicaciones) Then
                GLUUBICACIONES.Properties.DataSource = dsUbicaciones.Tables(0)
                GLUUBICACIONES.Properties.PopulateViewColumns()
                GLUUBICACIONES.Properties.ValueMember = "LOCATION_SPOT"
                GLUUBICACIONES.Properties.DisplayMember = "LOCATION_SPOT"
                For i = 0 To GLUUBICACIONES.Properties.View.Columns.Count - 1
                    GLUUBICACIONES.Properties.View.Columns(i).Visible = False
                Next
                GLUUBICACIONES.Properties.View.Columns("WAREHOUSE_PARENT").Caption = "BODEGA"
                GLUUBICACIONES.Properties.View.Columns("LOCATION_SPOT").Caption = "UBICACIONES"
                GLUUBICACIONES.Properties.View.Columns("WAREHOUSE_PARENT").Visible = True
                GLUUBICACIONES.Properties.View.Columns("LOCATION_SPOT").Visible = True
                GLUUBICACIONES.Properties.View.BestFitColumns()
            End If
        End If
        GLUUBICACIONES.Enabled = True
    End Sub
    Private Sub FillComboPoliza()
        GLUPoliza.Enabled = True
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dspSeguro As New DataSet

        dspSeguro = xWarehouseServ.GetPolizaInsurance(pResult, PublicLoginInfo.Environment)

        If pResult = "OK" Then
            If Not IsNothing(dspSeguro) Then
                GLUPoliza.Properties.DataSource = dspSeguro.Tables(0)
                GLUPoliza.Properties.PopulateViewColumns()
                GLUPoliza.Properties.ValueMember = "POLIZA_INSURANCE"
                GLUPoliza.Properties.DisplayMember = "CLIENT_NAME"
                For i = 0 To GLUPoliza.Properties.View.Columns.Count - 1
                    GLUPoliza.Properties.View.Columns(i).Visible = False
                Next
                GLUPoliza.Properties.View.Columns("POLIZA_INSURANCE").Caption = "CODIGO"
                GLUPoliza.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                GLUPoliza.Properties.View.Columns("POLIZA_INSURANCE").Visible = True
                GLUPoliza.Properties.View.Columns("CLIENT_NAME").Visible = True
                GLUPoliza.Properties.View.BestFitColumns()
            End If
        End If

    End Sub
    Private Sub FillComboAcuerdo()
        GLCAcuerdo.Enabled = True
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dspAcuerdo As New DataSet

        'dspAcuerdo = xWarehouseServ.GetTermsOfTrade(pResult, PublicLoginInfo.Environment)
        dspAcuerdo = xct.GetClient_CommercialAggrements(GLUClientes.EditValue.ToString, pResult, PublicLoginInfo.Environment) 'xWarehouseServ.GetTermsOfTrade(pResult, PublicLoginInfo.Environment)

        If pResult = "OK" Then
            If Not IsNothing(dspAcuerdo) Then
                GLCAcuerdo.Properties.DataSource = dspAcuerdo.Tables(0)
                GLCAcuerdo.Properties.PopulateViewColumns()
                GLCAcuerdo.Properties.ValueMember = "ACUERDO_COMERCIAL"
                GLCAcuerdo.Properties.DisplayMember = "DESCRIPCION"
                For i = 0 To GLCAcuerdo.Properties.View.Columns.Count - 1
                    GLCAcuerdo.Properties.View.Columns(i).Visible = False
                Next
                GLCAcuerdo.Properties.View.Columns("ACUERDO_COMERCIAL").Caption = "ACUERO_COMERCIAL"
                GLCAcuerdo.Properties.View.Columns("DESCRIPCION").Caption = "DESCRIPCION"
                GLCAcuerdo.Properties.View.Columns("ACUERDO_COMERCIAL").Visible = True
                GLCAcuerdo.Properties.View.Columns("DESCRIPCION").Visible = True
                GLCAcuerdo.Properties.View.BestFitColumns()
            End If
        End If
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

            'Dt = 


            Dim j As Integer
            Dim k As Integer
            'For Each dataRow As DataRow In Dt.Rows
            '    j = j + 1
            '    If dataRow.Item("CODIGO") Is DBNull.Value Then
            '        Dt.Rows(j).Delete()
            '        k = k + 1

            '    End If

            'Next

            Dt = Ds.Tables(0).Select("CODIGO IS NOT NULL").CopyToDataTable()


            Dim dtest As New DataTable

            dtest.Columns.Add("CODIGO")

            dtest.Columns.Add("Count")

            Dim query = (From dr In (From d In Dt.AsEnumerable Select New With {.CODIGO = d("CODIGO")}) Select dr.CODIGO Distinct)

            For Each colName As String In query
                Dim cName = colName
                Dim cCount = (From row In Dt.Rows Select row Where row("CODIGO").ToString = cName).Count
                dtest.Rows.Add(colName, cCount)
            Next

            Dim dtrow = dtest.Select("Count > 1")

            if Dtrow.Any() Then
                NotifyStatus("Hay sku repetidos, validar.", True, true)
                Exit Function
            End If

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
                If Gfilas > 0 Then
                    SaveToolStripButton.Enabled = True
                End If
                TabPane1.SelectedPage = TabNavigationPage1
                NotifyStatus(GridView1.ViewCaption, False, False)


            Else
                MessageBox.Show("Numero de columnas Incorrecto, verificar archivo")
            End If


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
        Return True
    End Function

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        ImportExcellToDataGridView()
        SaveToolStripButton.Enabled = True
    End Sub

    Private Sub GLUBODEGA_EditValueChanged(sender As Object, e As EventArgs) Handles GLUBODEGA.EditValueChanged
        gWarehouse = GLUBODEGA.EditValue
        FillComboUbicaciones()
    End Sub

    Private Sub OpenToolStripButton_Click(sender As Object, e As EventArgs) Handles OpenToolStripButton.Click
        ImportExcellToDataGridView()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        Try



            Dim xdataset As New DataSet
            Dim xdatatable As New List(Of DataTable)
            xdatatable.Add(Dt)

            xTransServ.AddDataToReviewAddExternal(Dt, PublicLoginInfo.LoginID, gCustomerCode, PublicLoginInfo.Environment)

            'TabPane1.SelectedPage=TabNavigationPage3
            'NotifyStatus(GridView3.ViewCaption,False,False)

            sProcess()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

    End Sub

    Private Sub sProcess()
        Dim aProcess As String = ""
        aProcess = xTransServ.AddGeneralData(gCustomerCode, gCustomerName, PublicLoginInfo.LoginID, gWarehouse, glocation, gPoliza, gAcuerdo, gfecha, pResult, PublicLoginInfo.Environment)

        'If(aProcess.Contains("EXITO").ToString()) Then




        '    GridView1.ViewCaption = "Se han cargado exitosamente " + Gfilas.ToString() + " registros"
        'End If

        ' MessageBox.Show(aProcess)

        If (aProcess.Contains("EXITO").ToString()) Then
            Dim CadenaRES As String = aProcess
            Dim ArrCadena As String() = CadenaRES.Split("|")
            Dim RESPUESTACOMPLETA As String = ""
            RESPUESTACOMPLETA = RESPUESTACOMPLETA + "No. Licencia: " + ArrCadena(2).ToString()
            RESPUESTACOMPLETA = RESPUESTACOMPLETA + ", No. Poliza: " + ArrCadena(1).ToString()
            GridView1.ViewCaption = RESPUESTACOMPLETA.ToString()


            Dim result As Integer = MessageBox.Show("Proceso Exitoso, ¿Desea procesar otro Archivo?", "WMS OnePlan, Inventario Externo", MessageBoxButtons.YesNo)
            If result = DialogResult.Cancel Then
            ElseIf result = DialogResult.No Then
                SaveToolStripButton.Enabled = False
            ElseIf result = DialogResult.Yes Then
                GCEgreso.DataSource = Nothing
                SaveToolStripButton.Enabled = False
            End If

        Else
            NotifyStatus(aProcess, True, True)
        End If



    End Sub

End Class

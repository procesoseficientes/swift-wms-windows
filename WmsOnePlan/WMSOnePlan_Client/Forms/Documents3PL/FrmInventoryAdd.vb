Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading.Thread
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraEditors.Calendar

Public Class FrmInventoryAdd
    Public Shared GlobalUrlFileExt As String
    Public shared GlobalNameFileExt As String
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
    Dim Regristro As Integer = 0
    Dim cn As New SqlConnection("")

    'WS Cliente
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xWarehouseServ As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx") 'As New OnePlanServices_Locations.WMS_LocationsSoap("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_")
    Dim xTransServ As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim xct As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim pResult As String

    Private Sub FillComboAcuerdo()
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dspAcuerdo As New DataSet

        'dspAcuerdo = xWarehouseServ.GetTermsOfTrade(pResult, PublicLoginInfo.Environment)
        dspAcuerdo = xct.GetClient_CommercialAggrements(GLUClientes.EditValue.ToString, pResult, PublicLoginInfo.Environment)'xWarehouseServ.GetTermsOfTrade(pResult, PublicLoginInfo.Environment)

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
    Private Sub GLCAcuerdo_EditValueChanged(sender As Object, e As EventArgs) Handles GLCAcuerdo.EditValueChanged
        gAcuerdo = GLCAcuerdo.EditValue
        '  MessageBox.Show("Acuerdo: " + gAcuerdo)
        DtaDate.Enabled = True
    End Sub
    Private Sub FillComboPoliza()
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
    Private Sub GLUPoliza_EditValueChanged(sender As Object, e As EventArgs) Handles GLUPoliza.EditValueChanged
        gPoliza = GLUPoliza.EditValue
        'MessageBox.Show("Poliza: " + gPoliza)
        FillComboAcuerdo()
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
                GLUUBICACIONES.Properties.DisplayMember = "WAREHOUSE_PARENT"
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
    End Sub
    Private Sub GLUUBICACIONES_EditValueChanged(sender As Object, e As EventArgs) Handles GLUUBICACIONES.EditValueChanged
        glocation = GLUUBICACIONES.EditValue
        FillComboPoliza()
    End Sub
    Private Sub FillComboBodegas()
        Try
        Catch ex As Exception
        End Try
        Dim i As Integer
        Dim dsBodegas As New DataSet
        dsBodegas = xWarehouseServ.GetWareHouseEnabled(pResult, PublicLoginInfo.Environment)   ' xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            If Not IsNothing(dsBodegas) Then
                GLUBodegas.Properties.DataSource = dsBodegas.Tables(0)
                GLUBodegas.Properties.PopulateViewColumns()
                GLUBodegas.Properties.ValueMember = "WAREHOUSE_ID"
                GLUBodegas.Properties.DisplayMember = "NAME"
                For i = 0 To GLUBodegas.Properties.View.Columns.Count - 1
                    GLUBodegas.Properties.View.Columns(i).Visible = False
                Next
                GLUBodegas.Properties.View.Columns("WAREHOUSE_ID").Caption = "CODIGO"
                GLUBodegas.Properties.View.Columns("NAME").Caption = "NOMBRE"
                GLUBodegas.Properties.View.Columns("WAREHOUSE_ID").Visible = True
                GLUBodegas.Properties.View.Columns("NAME").Visible = True
                GLUBodegas.Properties.View.BestFitColumns()
            End If
        End If
    End Sub
    Private Sub GLUBodegas_EditValueChanged(sender As Object, e As EventArgs) Handles GLUBodegas.EditValueChanged
        gWarehouse = GLUBodegas.EditValue
        FillComboUbicaciones()
    End Sub
    Private Sub FillComboClientes()
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
    Private Sub GLUClientes_EditValueChanged(sender As Object, e As EventArgs) Handles GLUClientes.EditValueChanged
        gCustomerCode = GLUClientes.EditValue
        gCustomerName = GLUClientes.Properties.GetDisplayTextByKeyValue(GLUClientes.EditValue)
        FillComboBodegas()
    End Sub
    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        ImportExcellToDataGridView(DgvLoadInventory, LblRows)
        If (DgvLoadInventory.Rows.Count > 0) Then
            BtnSend.Enabled = True
            BtnUpload.Enabled = False
        End If
    End Sub

    Private Sub FillCombo(ByVal consulta As String, ByVal display As String, ByVal value As String, ByVal cmb As ComboBox)
        Dim Dt As DataTable
        Dim Da As New SqlDataAdapter
        Dim Cmd As New SqlCommand
        With Cmd
            .CommandType = CommandType.Text
            .CommandText = consulta
            .Connection = cn
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
    Private Sub FrmInventoryAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture =
          New System.Globalization.CultureInfo("es-GT")
        System.Threading.Thread.CurrentThread.CurrentUICulture =
        New System.Globalization.CultureInfo("es")
        DtaDate.Properties.Mask.Culture = New CultureInfo("es-GT")
        DtaDate.Properties.Mask.EditMask = "dd/MM/yyyy"
        ' DtaDate.Properties.Mask.UseMaskAsDisplayFormat = True
        PbrStatus.Maximum = 6
        PbrStatus.Minimum = 0
        FillComboClientes()
        BtnData.Visible=False
    End Sub


    Private Sub DgvLoadInventory_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvLoadInventory.CellContentClick
        Dim registro As String = Convert.ToString(DgvLoadInventory.CurrentRow.Index())
        Dim indice As Integer = Convert.ToInt16(registro)
    End Sub

    Private Sub SendData()
        Dim i As Integer = -1
        Try
            For Each row As DataGridViewRow In DgvLoadInventory.Rows
                i = i + 1
                Dim cmd As New SqlCommand("[ALSERSA].[OP_WMS_SP_UPDATE_OR_INSERT_OP_WMS_INV_X_LICENSE]", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@CODE_SKU", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(0, i).Value)
                cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(1, i).Value)
                cmd.Parameters.Add("@UNIT_MEASURE", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(2, i).Value)
                cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = Convert.ToInt32(DgvLoadInventory.Item(3, i).Value)
                cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = Convert.ToDecimal(DgvLoadInventory.Item(4, i).Value)
                cmd.Parameters.Add("@UNIT_PRICE", SqlDbType.Float).Value = Convert.ToDecimal(DgvLoadInventory.Item(5, i).Value)
                cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = gCustomerCode
                cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = gCustomerName
                cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = PublicLoginInfo.LoginID 'Convert.ToDateTime(fila.Item(2).ToString())
                cmd.Parameters.Add("@WAREHOUSE", SqlDbType.VarChar).Value = gWarehouse
                cmd.Parameters.Add("@SIGNO", SqlDbType.VarChar).Value = Gsigno
                cmd.Parameters.Add("@LOCATION", SqlDbType.VarChar).Value = glocation
                cmd.Parameters.Add("@HEADER", SqlDbType.Int).Value = gEncabezado
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = gfecha
                cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.VarChar).Value = gAcuerdo
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()


            Next 'MessageBox.Show("Datos Ingresados Correctamente", "Envio de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Regristro = Regristro + 1
            PbrStatus.Value = PbrStatus.Value + 1
        Catch ex As Exception
            '  MessageBox.Show("Error en inventario")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SendDetalle()
        Dim i As Integer = -1
        Try
            For Each row As DataGridViewRow In DgvLoadInventory.Rows
                i = i + 1
                Dim cmd As New SqlCommand("[ALSERSA].[OP_WMS_SP_INSERT_OP_WMS_POLIZA_DETAIL]", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@HEADER", SqlDbType.Int).Value = gEncabezado
                cmd.Parameters.Add("@LINE", SqlDbType.Int).Value = i + 1
                cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = gCustomerCode
                cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = gCustomerName
                cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = PublicLoginInfo.LoginID
                cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(1, i).Value)
                cmd.Parameters.Add("@UNIT_MEASURE", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(2, i).Value)
                cmd.Parameters.Add("@QTY", SqlDbType.Int).Value = Convert.ToInt32(DgvLoadInventory.Item(3, i).Value)
                cmd.Parameters.Add("@TOTAL", SqlDbType.Float).Value = Convert.ToDecimal(DgvLoadInventory.Item(4, i).Value)
                cmd.Parameters.Add("@UNIT_PRICE", SqlDbType.Float).Value = Convert.ToDecimal(DgvLoadInventory.Item(5, i).Value)
                cmd.Parameters.Add("@FECHA", SqlDbType.DateTime2).Value = gfecha
                cn.Open()
                cmd.ExecuteNonQuery()
                cn.Close()
            Next
            'MessageBox.Show("Datos Ingresados Correctamente", "Envio de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Regristro = Regristro + 1
            PbrStatus.Value = PbrStatus.Value + 1
        Catch ex As Exception
            '  MessageBox.Show("Error en Detalle")
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CrearEncabezado()
        Try
            ' Enviamos datos de licencia
            Dim cmd As New SqlCommand("[alsersa].[OP_WMS_SP_INSERT_OP_WMS_POLIZA_HEADER]", cn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@NumeroPoliza", SqlDbType.Int).Value = glicense
            cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = gCustomerCode
            cmd.Parameters.Add("@CUSTOMER_NAME", SqlDbType.VarChar).Value = gCustomerName
            cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = PublicLoginInfo.LoginID
            cmd.Parameters.Add("@TIPO", SqlDbType.VarChar).Value = Gtipo
            cmd.Parameters.Add("@POLASEGURADORA", SqlDbType.VarChar).Value = gPoliza
            cmd.Parameters.Add("@ACUERDO_COMERCIAL", SqlDbType.VarChar).Value = gAcuerdo
            cmd.Parameters.Add("@IDENTITY", SqlDbType.Int).Value = ParameterDirection.Output
            cn.Open()
            gEncabezado = cmd.ExecuteScalar()
            cn.Close()
        Catch ex As Exception
        End Try


    End Sub

    Private Sub CrearMaterial()
        Dim i As Integer = -1
        Try
            For Each row As DataGridViewRow In DgvLoadInventory.Rows

                i = i + 1
                Dim cmd As New SqlCommand("[alsersa].[OP_WMS_SP_ADD_MATERIAL]", cn)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@CODE_SKU", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(0, i).Value)
                cmd.Parameters.Add("@SKU_DESCRIPTION", SqlDbType.VarChar).Value = (DgvLoadInventory.Item(1, i).Value)
                cmd.Parameters.Add("@CUSTOMER", SqlDbType.VarChar).Value = gCustomerCode
                cmd.Parameters.Add("@USER", SqlDbType.VarChar).Value = PublicLoginInfo.LoginID
                cn.Open()
                glicense = cmd.ExecuteNonQuery()
                cn.Close()
            Next
            'MessageBox.Show("Materiales Ingresados Correctamente", "Envio de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Regristro = Regristro + 1
            PbrStatus.Value = PbrStatus.Value + 1
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ' MessageBox.Show("Error en Material")
        End Try
    End Sub
    Private Sub ActualizarPolizaSeguro()
        Dim i As Integer = -1
        Dim insurance As String
        Dim tresult As String
        Try
            Rpoliza = xTransServ.GetInsuranceAvilable(gPoliza, PublicLoginInfo.LoginID, tresult, pResult, PublicLoginInfo.Environment)
            'MessageBox.Show(Rpoliza)
            MostrarPoliza()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            'MessageBox.Show("Error en Seguro")
        End Try
    End Sub
    Private Sub MostrarPoliza()
        Dim Lineas() As String
        Dim i As Integer
        LstR.ClearSelected()
        Lineas = Split(Rpoliza, "#")
        For i = LBound(Lineas) To UBound(Lineas)
            LstR.Items.Add(Lineas(i))
        Next

        Dim Usado As Double = Convert.ToDecimal(LstR.Items(0))
        Dim Total As Double = Convert.ToDecimal(LstR.Items(1))
        LblCobertura.Text = "Q." + Total.ToString()
        LblUtilizado.Text = "Q." + Usado.ToString()
        Dim saldo As Double = Total - Usado
        LblSaldo.Text = "Q." + saldo.ToString()
    End Sub



    Private Sub BtnSend_Click_1(sender As Object, e As EventArgs) Handles BtnSend.Click
        sMaterial()
        AgregarLicencia()
        sHeader()
        sDetalle()
        sInventario()

        If PbrStatus.Value = 5 Then
            PbrStatus.Value = PbrStatus.Value + 1
            GrpResp.Visible = True

            GrpLog.Visible = True
            ActualizarPolizaSeguro()
            LblLicense.Text = "No. Ingreso: " + glicense
        Else
            MessageBox.Show("Error en transaccion  ", "Envio de Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
        BtnSend.Enabled = False
    End Sub
    Private Sub sDetalle()
        Dim sDetalle As String
        Dim i As Integer = -1
        Try
            For Each row As DataGridViewRow In DgvLoadInventory.Rows
                i = i + 1
                Dim TempCodigo As String = DgvLoadInventory.Item(0, i).Value
                Dim TempDesc As String = DgvLoadInventory.Item(1, i).Value
                Dim TempUMeasure As String = DgvLoadInventory.Item(2, i).Value
                Dim TempQty As Integer = DgvLoadInventory.Item(3, i).Value
                Dim Temptotal As Decimal = DgvLoadInventory.Item(4, i).Value
                Dim TempUPrice As Decimal = DgvLoadInventory.Item(5, i).Value
                sDetalle = xTransServ.AddPolizaDetail(gEncabezado, i, gCustomerCode, gCustomerName, PublicLoginInfo.LoginID, TempDesc, TempUMeasure, TempQty, Temptotal, TempUPrice, gfecha, pResult, PublicLoginInfo.Environment)
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub sMaterial()
        Dim smat As New DataSet
        Dim i As Integer = -1
        Try
            For Each row As DataGridViewRow In DgvLoadInventory.Rows
                i = i + 1
                Dim pCODE_SKU As String = DgvLoadInventory.Item(0, i).Value
                Dim pSKU_DESCRIPTION As String = DgvLoadInventory.Item(1, i).Value
                'Se agregan campos para enviar toda la grid como tabla temporal
                Dim pUMedida As String=DgvLoadInventory.Item(2,i).Value
                 Dim pqty As String=DgvLoadInventory.Item(3,i).Value
                 Dim pPUnitario As String=DgvLoadInventory.Item(4,i).Value
                 Dim pCTotal As String=DgvLoadInventory.Item(5,i).Value


                smat = xTransServ.AddMaterial(pCODE_SKU, pSKU_DESCRIPTION, gCustomerCode, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            Next
        Catch ex As Exception

        End Try
        ' smat = xserv.AddMaterial()
    End Sub
    Private Sub AgregarLicencia()
        Dim pResult As String = ""
        Dim pIdentity As String = ""
        Dim licencia As String = ""
        licencia = xTransServ.AddLicense(gCustomerName, gWarehouse, glocation, PublicLoginInfo.LoginID, gfecha, pIdentity, pResult, PublicLoginInfo.Environment)
        glicense = licencia
        If (licencia > 0) Then
            PbrStatus.Value = PbrStatus.Value + 2
        End If
    End Sub
    Private Sub sHeader()
        Dim pResult As String = ""
        Dim pIdentity As String = ""
        Dim Header As String = ""
        Header = xTransServ.AddPolizaHeader(glicense, gCustomerCode, gCustomerName, PublicLoginInfo.LoginID, Gtipo, gPoliza, gAcuerdo, pIdentity, pResult, PublicLoginInfo.Environment)
        gEncabezado = Header
        If (Header > 0) Then
            PbrStatus.Value = PbrStatus.Value + 2
        End If
    End Sub

    Private Sub sInventario()

        Dim sinventory As String = ""
        Dim pRESULTADO As String = ""
        Dim i As Integer = -1
        'Try
        For Each row As DataGridViewRow In DgvLoadInventory.Rows
            i = i + 1
            Dim TempCodigo As String = DgvLoadInventory.Item(0, i).Value
            Dim TempDesc As String = DgvLoadInventory.Item(1, i).Value
            Dim TempUMeasure As String = DgvLoadInventory.Item(2, i).Value
            Dim TempQty As Integer = DgvLoadInventory.Item(3, i).Value
            Dim Temptotal As Decimal = DgvLoadInventory.Item(4, i).Value
            Dim TempUPrice As Decimal = DgvLoadInventory.Item(5, i).Value
            sinventory = xTransServ.AddInventory(TempCodigo, TempDesc, TempUMeasure, TempQty, Temptotal, TempUPrice, gCustomerCode, gCustomerName, PublicLoginInfo.LoginID, gWarehouse, Gsigno, glocation, gPoliza, gfecha, gAcuerdo, PRESULTADO, pResult, PublicLoginInfo.Environment)
            LstLog.Items.Add("Linea: " + (i + 1).ToString() + " : " + sinventory.ToString())
        Next
        GResultado = sinventory

        If (sinventory.Contains("EXITO")) Then
            PbrStatus.Value = PbrStatus.Value + 1
        End If
    End Sub


    Private Sub DtaDate_EditValueChanged(sender As Object, e As EventArgs) Handles DtaDate.EditValueChanged
        gfecha = DtaDate.EditValue
        BtnData.Enabled = True
        BtnData.Visible = True
    End Sub

'      Private Sub sFILE_X_SERVER()
'        Dim pResult As String = ""
'        Dim pIdentity As String = ""
'        GRegistos = xTransServ.AddAllDataToServer(PublicLoginInfo.Environment)
'      '  MessageBox.Show(Header)
'        If (GRegistos>0) Then
'            Dim result As Integer = MessageBox.Show("Se han cargado "+GRegistos+" registros, ¿Desea Procesarlos?", "WMS OnePlan, Inventario Externo", MessageBoxButtons.YesNo)
'If result = DialogResult.Cancel Then
'ElseIf result = DialogResult.No Then
'ElseIf result = DialogResult.Yes Then
'                 sProcess()
'End If
'        End If 
'End Sub

       Private Sub sProcess()
        Dim aProcess As String = ""
        aProcess = xTransServ.AddGeneralData(gCustomerCode,gCustomerName,PublicLoginInfo.LoginID, gWarehouse,glocation,gPoliza,gAcuerdo,gfecha,pResult,PublicLoginInfo.Environment)
       ' MessageBox.Show(aProcess)
   
        If (aProcess.Contains("EXITO").ToString()) Then
        dim CadenaRES as String = aProcess
        dim ArrCadena AS string() = CadenaRES.Split("_")
        LblLicencia.Text="No. Licencia: "+ArrCadena(1).ToString()
        LblPoliza.Text="No. Poliza: "+ArrCadena(2).ToString()
        LblRegistros.Text="No. Registros: "+GRegistos.ToString()
            GPResumen.Visible=True
            Else
                LblErrorTrans.Visible=True
        End If


    End Sub

     
    Private Sub BtnData_Click_Click(sender As Object, e As EventArgs) Handles BtnData.Click
        'sFILE_X_SERVER()
        BtnData.Enabled=False
    End Sub

    Private Sub BtnDo_Click(sender As Object, e As EventArgs) Handles BtnDo.Click
        sProcess()
    End Sub
End Class





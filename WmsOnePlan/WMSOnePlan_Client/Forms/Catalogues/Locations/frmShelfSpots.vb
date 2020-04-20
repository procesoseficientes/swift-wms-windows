Imports System.IO
Imports System.Data
Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class frmShelfSpots

    Private Sub frmShelfSpots_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmShelfSpots_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmShelfSpots_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmShelfSpots_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmShelfSpots_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmShelfSpots_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ShowWarehouseAndZones()
    End Sub
    Sub ShowWarehouseAndZones()
        TreeView1.Nodes(0).Nodes.Clear()
        GetWarehouses()
        GetZones()
    End Sub


    Public Sub GetZones()
        Dim xdata As New DataSet
        Dim pResult As String = ""
        Dim xNode As TreeNode
        Dim pWName As String = ""


        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")

        For Each xNode In TreeView1.Nodes("Node0").Nodes
            pWName = xNode.Name
            Try
                xdata = xserv.SelectZonesGroup(pWName, pResult, PublicLoginInfo.Environment)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Return
            End Try

            If pResult = "OK" Then
                For Each xrow_subdata In xdata.Tables(0).Rows

                    xNode = New TreeNode
                    xNode.Text = xrow_subdata("DESCRIPTION").ToString
                    xNode.Name = xrow_subdata("ZONE").ToString
                    xNode.ImageIndex = 1
                    xNode.SelectedImageIndex = 1

                    Try
                        TreeView1.Nodes("Node0").Nodes(pWName).Nodes.Add(xNode)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try

                Next
            End If
        Next

    End Sub
    Public Sub GetWarehouses()
        Dim xdata As New DataSet
        Dim xrow As DataRow
        Dim pResult As String = ""
        Dim xNode As TreeNode

        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim pWName As String = ""
        Try
            xdata = xserv.GetAssociatedWarehouseWithUser(PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return
        End Try
        If pResult = "OK" Then
            For Each xrow In xdata.Tables(0).Rows
                xNode = New TreeNode
                pWName = ""
                xNode.Text = xrow("name").ToString
                xNode.Name = xrow("warehouse_id").ToString
                xNode.ImageIndex = 0
                TreeView1.Nodes("Node0").Nodes.Add(xNode)
                pWName = xNode.Name
            Next
            TreeView1.Nodes("Node0").ExpandAll()
        End If
    End Sub
    Private Sub TreeView1_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
        ShowLocations(e.Node)
    End Sub
    Private Sub TreeView1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.GotFocus
        'ShowLocations(TreeView1.Nodes(0))
    End Sub

    Sub ShowLocations(ByVal e As TreeNode)
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xdata As New DataSet
        Dim pResult As String = ""

        Me.GridControl1.DataSource = Nothing
        Try
            Select Case e.Level
                Case 0  'all records
                    xdata = xserv.SearchByHierarchyShelfSpots("", "", "", pResult, PublicLoginInfo.Environment)
                Case 1  'all records based on a warehouse
                    xdata = xserv.SearchByHierarchyShelfSpots(e.Name, "", "", pResult, PublicLoginInfo.Environment)
                    ShowWareHouseProps(e.Name.ToString)
                Case 2  'all records based on a specific warehouse and zone
                    xdata = xserv.SearchByHierarchyShelfSpots(e.Parent.Name, e.Name, "", pResult, PublicLoginInfo.Environment)
                    ShowWareHouseProps(e.Parent.Name.ToString)
            End Select
        Catch ex As Exception

        End Try
        Try
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xdata.Tables(0)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub ShowWareHouseProps(ByVal pWhCode As String)
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xdata1 As DataSet
        Dim pLocalResult As String = ""
        xdata1 = xserv.SearchByKeyWarehouse(pWhCode, pLocalResult, PublicLoginInfo.Environment)
        If pLocalResult = "OK" Then 'Update the record
            With Bag_Warehouse_Class
                .CodigoBodega = pWhCode
                .NombreBodega = xdata1.Tables(0).Rows(0)("name").ToString
                .Comentarios = IIf(IsDBNull(xdata1.Tables(0).Rows(0)("comments").ToString), "", xdata1.Tables(0).Rows(0)("comments").ToString)
                .CodigoBodegaSAP = IIf(IsDBNull(xdata1.Tables(0).Rows(0)("erp_warehouse").ToString), "", xdata1.Tables(0).Rows(0)("erp_warehouse").ToString)
                .DescripcionCorta = xdata1.Tables(0).Rows(0)("SHUNT_NAME").ToString
                .Clima = xdata1.Tables(0).Rows(0)("WAREHOUSE_WEATHER").ToString
                .Estatus = xdata1.Tables(0).Rows(0)("WAREHOUSE_STATUS").ToString
                .EsBodegaHabilitada = xdata1.Tables(0).Rows(0)("IS_3PL_WAREHUESE").ToString
                .DireccionFisicaDeBodega = xdata1.Tables(0).Rows(0)("WAHREHOUSE_ADDRESS").ToString
                .PuntoGps = xdata1.Tables(0).Rows(0)("GPS_URL").ToString
                .CentroDeDistribucion = xdata1.Tables(0).Rows(0)("DISTRIBUTION_CENTER_ID").ToString
                .TipoDePicking = xdata1.Tables(0).Rows(0)("PICKING_TYPE").ToString
            End With
            PropertyGrid2.SelectedObject = Bag_Warehouse_Class
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ClearBagWarehouse()
        PropertyGrid2.Focus()
    End Sub

    Private Sub PropertyGrid2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyGrid2.Click

    End Sub

    Private Sub PropertyGrid2_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid2.PropertyValueChanged

        Select Case e.ChangedItem.Label
            Case "CodigoBodega"
                Bag_Warehouse_Class.CodigoBodega = e.ChangedItem.Value
            Case "NombreBodega"
                Bag_Warehouse_Class.NombreBodega = e.ChangedItem.Value
            Case "CodigoBodegaSAP"
                Bag_Warehouse_Class.CodigoBodegaSAP = e.ChangedItem.Value
            Case "Comentarios"
                Bag_Warehouse_Class.Comentarios = e.ChangedItem.Value
        End Select

    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If Bag_Warehouse_Class.Grabar(pResult) Then
            ShowWarehouseAndZones()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        SaveAndRefresh()
    End Sub
    Private Sub ClearBagWarehouse()
        With Bag_Warehouse_Class
            .CodigoBodega = ""
            .NombreBodega = ""
            .Comentarios = ""
            .CodigoBodegaSAP = ""
            .DescripcionCorta = ""
            .Clima = ""
            .Estatus = ""
            .EsBodegaHabilitada = ""
            .DireccionFisicaDeBodega = ""
            .PuntoGps = ""
        End With
        PropertyGrid2.SelectedObject = Bag_Warehouse_Class
        Me.PropertyGrid2.Refresh()

    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Dim pResult As String = ""
        If Bag_Warehouse_Class.Delete(pResult) Then
            ShowWarehouseAndZones()
            ClearBagWarehouse()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        Try
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pWarehouse As String = xdatarow("WAREHOUSE_PARENT").ToString
            Dim pLocation As String = xdatarow("LOCATION_SPOT").ToString

            ShowLocation(pWarehouse, pLocation)

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub
    Sub ShowLocation(ByVal pWarehouse As String, ByVal pLocation As String)
        ClearBagLocation()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xdata As DataSet = xserv.SearchByKeyShelfSpots(pWarehouse, pLocation, pResult, PublicLoginInfo.Environment)

        If xdata.Tables(0).Rows(0)("SPOT_TYPE").ToString = "RACK" Then
            Bag_ShelfSpots_Class.SetBrowsableProperty("PesoMaximo", True)
            Bag_ShelfSpots_Class.SetBrowsableProperty("Volumen", True)
        Else
            Bag_ShelfSpots_Class.SetBrowsableProperty("PesoMaximo", False)
            Bag_ShelfSpots_Class.SetBrowsableProperty("Volumen", False)
        End If

        If pResult = "OK" Then
            With Bag_ShelfSpots_Class
                .Bodega = xdata.Tables(0).Rows(0)("WAREHOUSE_PARENT").ToString
                .Codigo = xdata.Tables(0).Rows(0)("LOCATION_SPOT").ToString
                .Columna = xdata.Tables(0).Rows(0)("SPOT_COLUMN").ToString
                .Nivel = xdata.Tables(0).Rows(0)("SPOT_LEVEL").ToString
                .Rack = xdata.Tables(0).Rows(0)("SPOT_AISLE").ToString
                .PermiteAlmacenaje = xdata.Tables(0).Rows(0)("ALLOW_STORAGE").ToString
                .PermitePicking = xdata.Tables(0).Rows(0)("ALLOW_PICKING").ToString
                .PermiteReubicar = xdata.Tables(0).Rows(0)("ALLOW_REALLOC").ToString
                .SecuenciaDeOrden = xdata.Tables(0).Rows(0)("SPOT_ORDERBY").ToString
                .Tipo = xdata.Tables(0).Rows(0)("SPOT_TYPE").ToString
                .Disponible = xdata.Tables(0).Rows(0)("AVAILABLE").ToString
                .Particion = xdata.Tables(0).Rows(0)("SPOT_PARTITION").ToString
                .Zona = xdata.Tables(0).Rows(0)("ZONE").ToString
                .Etiqueta = xdata.Tables(0).Rows(0)("SPOT_LABEL").ToString
                .Linea = xdata.Tables(0).Rows(0)("SPOT_LINE").ToString
                .Metros2 = IIf(IsDBNull(xdata.Tables(0).Rows(0)("MAX_MT2_OCCUPANCY")), 0, xdata.Tables(0).Rows(0)("MAX_MT2_OCCUPANCY"))
                .PesoMaximo = IIf(IsDBNull(xdata.Tables(0).Rows(0)("MAX_WEIGHT")), 0, xdata.Tables(0).Rows(0)("MAX_WEIGHT"))
                .Seccion = xdata.Tables(0).Rows(0)("SECTION").ToString
                .Volumen = xdata.Tables(0).Rows(0)("VOLUME").ToString
                .PermitePickingRapido = xdata.Tables(0).Rows(0)("ALLOW_FAST_PICKING").ToString
                .EsDesperdicio = xdata.Tables(0).Rows(0)("IS_WASTE").ToString
            End With
            PropertyGrid1.SelectedObject = Bag_ShelfSpots_Class
            PropertyGrid1.Refresh()
        Else
            MessageBox.Show(pResult)
        End If
    End Sub
    Private Sub ClearBagLocation()
        With Bag_ShelfSpots_Class
            .Bodega = ""
            .Codigo = ""
            .Etiqueta = ""
            .Zona = ""
            .Linea = ""
            .Columna = ""
            .Nivel = ""
            .Rack = ""
            .PermiteAlmacenaje = "NO"
            .PermitePicking = "NO"
            .PermiteReubicar = "NO"
            .Disponible = "NO"
            .SecuenciaDeOrden = 0
            .Tipo = "RACK"
            .Seccion = ""
            .PesoMaximo = 0
            .Volumen = 0
            .Metros2 = 0
            .PermitePickingRapido = "NO"
            .EsDesperdicio = "NO"

            If .Tipo = "RACK" Then
                Bag_ShelfSpots_Class.SetBrowsableProperty("PesoMaximo", True)
                Bag_ShelfSpots_Class.SetBrowsableProperty("Volumen", True)
            Else
                Bag_ShelfSpots_Class.SetBrowsableProperty("PesoMaximo", False)
                Bag_ShelfSpots_Class.SetBrowsableProperty("Volumen", False)
            End If
        End With
        PropertyGrid1.SelectedObject = Bag_ShelfSpots_Class
        Me.PropertyGrid1.Refresh()

    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        ClearBagLocation()
        PropertyGrid1.Focus()
    End Sub

    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click
        Dim pResult As String = ""
        Dim pResponse As DialogResult = DialogResult.No
        If Not IsNothing(Bag_ShelfSpots_Class.Bodega) AndAlso Not IsNothing(Bag_ShelfSpots_Class.Codigo) Then
            pResponse = MessageBox.Show("Confirma eliminacion?", "Confirme accion", MessageBoxButtons.YesNo)
            If pResponse = DialogResult.Yes Then
                If Bag_ShelfSpots_Class.Delete(pResult) Then
                    ShowLocations(TreeView1.Nodes(0).Nodes(Bag_ShelfSpots_Class.Bodega.ToString))
                    ClearBagLocation()
                Else
                    MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If

    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefreshLocation()
    End Sub
    Sub SaveAndRefreshLocation()
        Dim pResult As String = ""
        Try
            Cursor = Cursors.WaitCursor
            If Not IsNothing(Bag_ShelfSpots_Class.Bodega) AndAlso Not IsNothing(Bag_ShelfSpots_Class.Codigo) Then
                If Bag_ShelfSpots_Class.Grabar(pResult) Then
                    ShowLocations(TreeView1.Nodes(0).Nodes(Bag_ShelfSpots_Class.Bodega.ToString))
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If

            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default

            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GridControl1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridControl1.MouseClick
        Try
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            If IsNothing(xdatarow) Then
                Return
            End If

            Dim pWarehouse As String = xdatarow("WAREHOUSE_PARENT").ToString
            Dim pLocation As String = xdatarow("LOCATION_SPOT").ToString


            ShowLocation(pWarehouse, pLocation)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PropertyGrid1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PropertyGrid1.KeyUp
        If e.KeyCode = Keys.F5 Then
            SaveAndRefreshLocation()
        End If
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        Try
            If e.ChangedItem.Label = "Codigo" Then
                Bag_ShelfSpots_Class.Rack = IIf(InStr(e.ChangedItem.Value, "R") = 0, "0", Mid(e.ChangedItem.Value, InStr(e.ChangedItem.Value, "R") + 1, 2).ToString)

                Bag_ShelfSpots_Class.Columna = IIf(InStr(e.ChangedItem.Value, "C") = 0, "0", Mid(e.ChangedItem.Value, InStr(e.ChangedItem.Value, "C") + 1, 2).ToString)
                Bag_ShelfSpots_Class.Nivel = IIf(InStr(e.ChangedItem.Value, "N") = 0, "0", Mid(e.ChangedItem.Value, InStr(e.ChangedItem.Value, "N") + 1, 2).ToString)
                Bag_ShelfSpots_Class.Particion = IIf(InStr(e.ChangedItem.Value, "P") = 0, "0", Mid(e.ChangedItem.Value, InStr(e.ChangedItem.Value, "P") + 1, 2).ToString)
                Bag_ShelfSpots_Class.Etiqueta = e.ChangedItem.Value

                PropertyGrid1.SelectedObject = Bag_ShelfSpots_Class

            End If

            If e.ChangedItem.Label = "Tipo" Then
                If Bag_ShelfSpots_Class.Tipo = "RACK" Then
                    Bag_ShelfSpots_Class.SetBrowsableProperty("PesoMaximo", True)
                    Bag_ShelfSpots_Class.SetBrowsableProperty("Volumen", True)
                Else
                    Bag_ShelfSpots_Class.SetBrowsableProperty("PesoMaximo", False)
                    Bag_ShelfSpots_Class.SetBrowsableProperty("Volumen", False)
                End If
                PropertyGrid1.Refresh()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem_CopyPartition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem_CopyPartition.Click
        Dim xfrm As New frmCopyLocations
        Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim pWarehouse As String = xdatarow(0).ToString
        Dim pLocation As String = xdatarow(2).ToString

        xfrm.LabelControl2.Text = pLocation
        xfrm.LabelControl2.Tag = pWarehouse

        xfrm.ShowDialog()

    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub PrintToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripButton.Click
        PrintSingleLabel()
    End Sub
    Sub PrintSingleLabel()
        Dim pStr As String = ""
        Dim pd As New PrintDialog()

        pd.PrinterSettings = New PrinterSettings()
        If (pd.ShowDialog() = DialogResult.OK) Then
            Dim xrow As DataRow

            For i = 0 To GridView1.RowCount - 1
                If GridView1.IsRowSelected(i) Then
                    xrow = GridView1.GetDataRow(i)

                    ObtenerFormatoDeImprecion("2X2", pStr, xrow("LOCATION_SPOT"), xrow("LOCATION_SPOT"))

                    'HeadPartOne("2X2", xrow("LOCATION_SPOT"), pStr)
                    'HeadPartTwo("2X2", xrow("LOCATION_SPOT"), pStr)

                    For j = 1 To pd.PrinterSettings.Copies
                        RawPrinterHelper2.SendStringToPrinter(pd.PrinterSettings.PrinterName, pStr)
                    Next
                End If
            Next
        End If

    End Sub

    Public Function GetBarcodeFormat(ByVal pSize As String)
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "TIPO_ETIQUETAS", pSize, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Return "^FO150,250^BCN,200,Y,N,N^FN4^FS" 'xds.Tables(0).Rows(0)("SPARE1")
            Else
                Return "^FO01,140^BY3^B3N,N,200,N,N^FN4^FS"
            End If

        Catch ex As Exception
            Return "Money Twins"
        End Try
    End Function

    Sub HeadPartOne(ByVal pSize As String, ByVal pGroup As String, ByRef pStr As String)
        Select Case pSize
            Case "2X2"
                pStr = "^XA"
                pStr = pStr + " ^DFR:SAMPLE.GRF"
                pStr = pStr + " ^FS"

                pStr = pStr + " ^LH10,05^LL5000^MD30^PF1" '2 inches
                'pStr = pStr + " ^FO01,20^ADN,36,20^FD" + pGroup + "^FS"

                pStr = pStr + " ^CF0,0^FO150,17^FB250,4,,^FN2^FS(TITULO)"
                pStr = pStr + GetBarcodeFormat("2X2")
                pStr = pStr + " ^FO270,350^ADN,18,10^FN5^FS (company)"

                'pStr = "^XA"
                'pStr = pStr + " ^DFR:SAMPLE.GRF"
                'pStr = pStr + " ^FS"

                'pStr = pStr + " ^LH20,10^LL1000" '2 inches
                ''pStr = pStr + " ^FO01,20^ADN,36,20^FD" + pGroup + "^FS"

                'pStr = pStr + " ^FO270,100^ADN,40,24^FN2^FS(TITULO)"
                'pStr = pStr + GetBarcodeFormat("2X2")
                'pStr = pStr + " ^FO270,350^ADN,18,10^FN5^FS (company)"


        End Select
    End Sub

    Sub ObtenerFormatoDeImprecion(ByVal pSize As String, ByRef pStr As String, ByVal pName As String, ByVal pCode As String)
        'Cambio parametros de impresion
        Dim pLine1 As String = "", pLine2 As String = "", pLine3 As String = ""

        pStr = "^XA"
        pStr = pStr + " ^DFR:SAMPLE.GRF"
        pStr = pStr + " ^FS"

        Call GetPrintLines(pSize, pLine1, pLine2, pLine3)

        pStr = pStr + pLine1
        pStr = pStr + pLine2
        pStr = pStr + pLine3

        pStr = pStr + " ^XZ"
        pStr = pStr + " ^XA"
        pStr = pStr + " ^XFR:SAMPLE.GRF"
        pStr = pStr + " ^FN2^FD" + pName + "^FS"
        pStr = pStr + " ^FN4^FD" + pCode + "^FS"
        pStr = pStr + " ^XZ"
    End Sub

    Public Function GetPrintLines(ByVal pSize As String, ByRef pLine1 As String, ByRef pLine2 As String, ByRef pLine3 As String)
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "TIPO_ETIQUETAS", pSize, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                pLine1 = xds.Tables(0).Rows(0)("TEXT_VALUE")
                pLine2 = xds.Tables(0).Rows(0)("SPARE1")
                pLine3 = xds.Tables(0).Rows(0)("SPARE2")
            Else
                pLine1 = "^LH40,2^LL250"
                pLine2 = "^F10,10^ADN,2,03^FN2^FS(Producto#)"
                pLine3 = "^F10,50^BY2^B2N,N,30,N,N^FN4^FS(barcode)"
            End If
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function

    Sub HeadPartTwo(ByVal pSize As String, ByVal pBinID As String, ByRef pStr As String)
        Select Case pSize
            Case "2X2"
                pStr = pStr + " ^XZ"
                pStr = pStr + " ^XA"
                pStr = pStr + " ^XFR:SAMPLE.GRF"
                pStr = pStr + " ^FN2^FD" + pBinID + "^FS" 'TITULO
                pStr = pStr + " ^FN4^FD" + pBinID + "^FS" '-CODIGO DE BARRAS
                'pStr = pStr + " ^FN5^FDCOSMETICA GLOBAL^FS"
                'pStr = pStr + " ^FN1^FD" + Bag_Bin_Class.TituloEtiqueta + "^FS"
                pStr = pStr + " ^XZ"

        End Select

    End Sub


    Private Sub PropertyGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyGrid1.Click

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)
        Dim xfrm As New frmCopyLocations
        Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
        Dim pWarehouse As String = xdatarow(0).ToString
        Dim pLocation As String = xdatarow(2).ToString

        xfrm.LabelControl2.Text = pLocation
        xfrm.LabelControl2.Tag = pWarehouse

        xfrm.ShowDialog()
    End Sub
End Class
Public Class RawPrinterHelper2
    ' Structure and API declarions:
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Structure DOCINFOW
        <MarshalAs(UnmanagedType.LPWStr)> Public pDocName As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pOutputFile As String
        <MarshalAs(UnmanagedType.LPWStr)> Public pDataType As String
    End Structure

    <DllImport("winspool.Drv", EntryPoint:="OpenPrinterW",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function OpenPrinter(ByVal src As String, ByRef hPrinter As IntPtr, ByVal pd As Long) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="ClosePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function ClosePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartDocPrinterW",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartDocPrinter(ByVal hPrinter As IntPtr, ByVal level As Int32, ByRef pDI As DOCINFOW) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndDocPrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndDocPrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="StartPagePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function StartPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="EndPagePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function EndPagePrinter(ByVal hPrinter As IntPtr) As Boolean
    End Function
    <DllImport("winspool.Drv", EntryPoint:="WritePrinter",
       SetLastError:=True, CharSet:=CharSet.Unicode,
       ExactSpelling:=True, CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function WritePrinter(ByVal hPrinter As IntPtr, ByVal pBytes As IntPtr, ByVal dwCount As Int32, ByRef dwWritten As Int32) As Boolean
    End Function

    ' SendBytesToPrinter()
    ' When the function is given a printer name and an unmanaged array of  
    ' bytes, the function sends those bytes to the print queue.
    ' Returns True on success or False on failure.
    Public Shared Function SendBytesToPrinter(ByVal szPrinterName As String, ByVal pBytes As IntPtr, ByVal dwCount As Int32) As Boolean
        Dim hPrinter As IntPtr      ' The printer handle.
        Dim dwError As Int32        ' Last error - in case there was trouble.
        Dim di As DOCINFOW          ' Describes your document (name, port, data type).
        Dim dwWritten As Int32      ' The number of bytes written by WritePrinter().
        Dim bSuccess As Boolean     ' Your success code.

        ' Set up the DOCINFO structure.
        di = Nothing
        With di
            .pDocName = "My Visual Basic .NET RAW Document"
            .pDataType = "RAW"
        End With
        ' Assume failure unless you specifically succeed.
        bSuccess = False
        If OpenPrinter(szPrinterName, hPrinter, 0) Then
            If StartDocPrinter(hPrinter, 1, di) Then
                If StartPagePrinter(hPrinter) Then
                    ' Write your printer-specific bytes to the printer.
                    bSuccess = WritePrinter(hPrinter, pBytes, dwCount, dwWritten)
                    EndPagePrinter(hPrinter)
                End If
                EndDocPrinter(hPrinter)
            End If
            ClosePrinter(hPrinter)
        End If
        ' If you did not succeed, GetLastError may give more information
        ' about why not.
        If bSuccess = False Then
            dwError = Marshal.GetLastWin32Error()
        End If
        Return bSuccess
    End Function ' SendBytesToPrinter()

    ' SendFileToPrinter()
    ' When the function is given a file name and a printer name, 
    ' the function reads the contents of the file and sends the
    ' contents to the printer.
    ' Presumes that the file contains printer-ready data.
    ' Shows how to use the SendBytesToPrinter function.
    ' Returns True on success or False on failure.
    Public Shared Function SendFileToPrinter(ByVal szPrinterName As String, ByVal szFileName As String) As Boolean
        ' Open the file.
        Dim fs As New FileStream(szFileName, FileMode.Open)
        ' Create a BinaryReader on the file.
        Dim br As New BinaryReader(fs)
        ' Dim an array of bytes large enough to hold the file's contents.
        Dim bytes(fs.Length) As Byte
        Dim bSuccess As Boolean
        ' Your unmanaged pointer.
        Dim pUnmanagedBytes As IntPtr

        ' Read the contents of the file into the array.
        bytes = br.ReadBytes(fs.Length)
        ' Allocate some unmanaged memory for those bytes.
        pUnmanagedBytes = Marshal.AllocCoTaskMem(fs.Length)
        ' Copy the managed byte array into the unmanaged array.
        Marshal.Copy(bytes, 0, pUnmanagedBytes, fs.Length)
        ' Send the unmanaged bytes to the printer.
        bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, fs.Length)
        ' Free the unmanaged memory that you allocated earlier.
        Marshal.FreeCoTaskMem(pUnmanagedBytes)
        Return bSuccess
    End Function ' SendFileToPrinter()

    ' When the function is given a string and a printer name,
    ' the function sends the string to the printer as raw bytes.
    Public Shared Function SendStringToPrinter(ByVal szPrinterName As String, ByVal szString As String)
        Dim pBytes As IntPtr
        Dim dwCount As Int32
        ' How many characters are in the string?
        dwCount = szString.Length()
        ' Assume that the printer is expecting ANSI text, and then convert
        ' the string to ANSI text.
        pBytes = Marshal.StringToCoTaskMemAnsi(szString)
        ' Send the converted ANSI string to the printer.
        SendBytesToPrinter(szPrinterName, pBytes, dwCount)
        Marshal.FreeCoTaskMem(pBytes)
        Return ""
    End Function
End Class

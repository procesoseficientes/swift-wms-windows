Imports System.IO
Imports System.Data
Imports System.Globalization

Public Class frmAprobacionRecepcion
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim pResult, _codigo_poliza As String
    Dim _recepcion As Integer
    Dim dsTransMatch As New DataSet
    Dim xDetTrans As New DataSet
    Dim dsPolDet As New DataSet

    Private Sub frmAprobacionRecepcion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
        SaveGridLayout("frmAprobacionRecepcion", PublicLoginInfo.LoginID, GridViewRECEPCIONES)

    End Sub

    Private Sub frmAprobacionRecepcion_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
        SaveGridLayout("frmAprobacionRecepcion", PublicLoginInfo.LoginID, GridViewRECEPCIONES)

    End Sub
    Private Sub frmAprobacionRecepcion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showi()
    End Sub

    Private Sub GridViewRECEPCIONES_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewRECEPCIONES.FocusedRowChanged
        Try
            If GridViewRECEPCIONES.SelectedRowsCount = 1 Then
                If GridViewRECEPCIONES.IsDataRow(e.FocusedRowHandle) Then
                    'If GridViewRECEPCIONES.GetFocusedRowCellValue("CODIGO_POLIZA").ToString.Length > 0 Then
                    _codigo_poliza = GridViewRECEPCIONES.GetFocusedRowCellValue("CODIGO_POLIZA").ToString
                    Integer.TryParse(GridViewRECEPCIONES.GetFocusedRowCellValue("SERIAL_NUMBER").ToString, _recepcion)
                    XtraTabPage2.Text = IIf(GridViewRECEPCIONES.GetFocusedRowCellValue("NUMERO_ORDEN").ToString.Length > 0, GridViewRECEPCIONES.GetFocusedRowCellValue("NUMERO_ORDEN").ToString, GridViewRECEPCIONES.GetFocusedRowCellValue("CODIGO_POLIZA").ToString)
                Else
                    _codigo_poliza = String.Empty
                    _recepcion = 0
                    'End If
                End If

                '  If _codigo_poliza.Length > 0 Then

                dsPolDet.Clear()
                pResult = String.Empty
                dsPolDet = xserv.get_Poliza_Detail("", _codigo_poliza, PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    GridPOLIZADET.DataSource = dsPolDet.Tables("OP_WMS_POLIZA_DETAIL")
                Else
                    MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                End If
                GridPOLIZADET.Refresh()

                xDetTrans.Clear()
                pResult = String.Empty
                xDetTrans = xserv.get_tran_byID(Val(GridViewRECEPCIONES.GetFocusedRowCellValue("SERIAL_NUMBER")), PublicLoginInfo.Environment, pResult)
                'Dim colEs As DataColumn
                'colEs = New DataColumn
                'With colEs
                '    .ColumnName = "ESTADO"
                '    .DataType = Type.GetType("System.String")
                '    .DefaultValue = "P"
                'End With
                'xDetTrans.Tables("OP_WMS_TRANS").Columns.Add(colEs)

                If pResult = "OK" Then
                    GridRECDET.DataSource = xDetTrans.Tables("OP_WMS_TRANS")
                Else
                    MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                End If

                dsTransMatch.Clear()
                pResult = String.Empty
                dsTransMatch = xserv.get_trans_match(" where codigo_poliza = '" & _codigo_poliza & "'", PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    GridMATCH.DataSource = dsTransMatch.Tables("OP_WMS3PL_POLIZA_TRANS_MATCH")
                    GridViewMATCH.BestFitColumns()
                Else
                    MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                End If
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar el detalle : " + ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            pResult = String.Empty
        End Try

    End Sub

    Private Sub btnAsociar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAsociar.ItemClick
        Try
            If GridViewPOLIZADET.SelectedRowsCount > 0 And GridViewRECDET.SelectedRowsCount > 0 Then
                Dim _sku_description, _material_code, _material_desc As String
                Dim _lineno_poliza, _doc_id, _bultos As Integer
                Dim _quantity_units, _qty As Double

                If GridViewPOLIZADET.GetFocusedRowCellValue("SKU_DESCRIPTION").ToString.Length > 0 Then
                    _sku_description = GridViewPOLIZADET.GetFocusedRowCellValue("SKU_DESCRIPTION").ToString
                Else
                    _sku_description = String.Empty
                End If
                If GridViewRECDET.GetFocusedRowCellValue("MATERIAL_CODE").ToString.Length > 0 Then
                    _material_code = GridViewRECDET.GetFocusedRowCellValue("MATERIAL_CODE").ToString
                Else
                    _material_code = String.Empty
                End If
                If GridViewRECDET.GetFocusedRowCellValue("MATERIAL_DESCRIPTION").ToString.Length > 0 Then
                    _material_desc = GridViewRECDET.GetFocusedRowCellValue("MATERIAL_DESCRIPTION").ToString
                Else
                    _material_desc = String.Empty
                End If

                Integer.TryParse(GridViewPOLIZADET.GetFocusedRowCellValue("LINE_NUMBER").ToString, _lineno_poliza)
                Integer.TryParse(GridViewPOLIZADET.GetFocusedRowCellValue("DOC_ID").ToString, _doc_id)
                Double.TryParse(GridViewRECDET.GetFocusedRowCellValue("QUANTITY_UNITS").ToString, _quantity_units)
                Double.TryParse(GridViewPOLIZADET.GetFocusedRowCellValue("QTY").ToString, _qty)
                Integer.TryParse(GridViewPOLIZADET.GetFocusedRowCellValue("BULTOS").ToString, _bultos)

                If xserv.set_POLIZA_TRANS_MATCH(_codigo_poliza, _recepcion, _lineno_poliza, _doc_id, _sku_description, _material_code, _
                                               _material_desc, _quantity_units, _qty, _bultos, PublicLoginInfo.LoginName, Double.Parse("0"), "",
                                                PublicLoginInfo.Environment, pResult) Then
                    GridViewRECDET.SetFocusedRowCellValue("STATUS", "MATCH")
                    GridViewRECDET.UpdateColumnsCustomization()
                    MsgBox("PRODUCTO ASOCIADO", MsgBoxStyle.Information, "Aviso")
                    dsTransMatch.Clear()
                    dsTransMatch = xserv.get_trans_match(" where CODIGO_POLIZA = '" & _codigo_poliza & "'", PublicLoginInfo.Environment, pResult)
                    If pResult = "OK" Then
                        GridMATCH.DataSource = dsTransMatch.Tables("OP_WMS3PL_POLIZA_TRANS_MATCH")
                        GridViewMATCH.BestFitColumns()
                    End If
                Else
                    MsgBox("Error al asociar: " & pResult, MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Debe seleccionar una linea de la poliza y una linea de la recepcion", MsgBoxStyle.Information, "Aviso")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            PrintableComponentLink1.ShowPreview()

        Catch ex As Exception
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub BarLargeButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarLargeButtonItem1.ItemClick
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                If GridViewMATCH.IsFocusedView Then
                    GridViewMATCH.ExportToXlsx(SaveFileDialog1.FileName)
                End If
                If GridViewRECEPCIONES.IsFocusedView Then
                    GridViewRECEPCIONES.ExportToXlsx(SaveFileDialog1.FileName)
                End If
            End If

        Catch ex As Exception
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnDel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDel.ItemClick
        Try
            If XtraTabControl1.SelectedTabPage.Name = "XtraTabPage2" Then
                If GridViewMATCH.SelectedRowsCount > 0 Then
                    Dim _linea, _trans As Integer
                    Dim _poliza, _sku As String
                    Integer.TryParse(GridViewMATCH.GetFocusedRowCellValue("LINENO_POLIZA"), _linea)
                    Integer.TryParse(GridViewMATCH.GetFocusedRowCellValue("TRANS_ID"), _trans)

                    If GridViewMATCH.GetFocusedRowCellValue("CODIGO_POLIZA").ToString.Length > 0 Then
                        _poliza = GridViewMATCH.GetFocusedRowCellValue("CODIGO_POLIZA").ToString
                    Else
                        _poliza = String.Empty
                    End If

                    If GridViewMATCH.GetFocusedRowCellValue("MATERIAL_CODE").ToString.Length > 0 Then
                        _sku = GridViewMATCH.GetFocusedRowCellValue("MATERIAL_CODE").ToString
                    Else
                        _sku = String.Empty
                    End If

                    pResult = String.Empty

                    If xserv.del_POLIZA_TRANS_MATCH(_poliza, _sku, _linea, _trans, PublicLoginInfo.Environment, pResult) Then
                        GridMATCH.DataSource = Nothing
                        dsTransMatch.Clear()

                        dsTransMatch = xserv.get_trans_match(" where codigo_poliza = '" & _codigo_poliza & "'", PublicLoginInfo.Environment, pResult)
                        GridMATCH.DataSource = dsTransMatch.Tables("OP_WMS3PL_POLIZA_TRANS_MATCH")
                        GridViewMATCH.BestFitColumns()
                    Else
                        MsgBox("Error al borrar : " & pResult, MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    MsgBox("Debe seleccionar una linea a borrar del grid inferior", MsgBoxStyle.Information, "Aviso")
                End If
            End If

        Catch ex As Exception
            MsgBox("Error al borrar : " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            pResult = String.Empty
        End Try
    End Sub

    Private Sub btnSKU_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSKU.ItemClick
        Try
            Dim _SKU As String
            _SKU = String.Empty
            If GridViewRECEPCIONES.IsFocusedView Then
                _SKU = GridViewRECEPCIONES.GetFocusedRowCellValue("MATERIAL_CODE").ToString
            End If
            If GridViewRECDET.IsFocusedView Then
                _SKU = GridViewRECDET.GetFocusedRowCellValue("MATERIAL_CODE").ToString
            End If
            If GridViewMATCH.IsFocusedView Then
                _SKU = GridViewMATCH.GetFocusedRowCellValue("MATERIAL_CODE").ToString
            End If
            If _SKU.Length > 0 Then
                Dim fmat As New frmMaterials
                fmat.MdiParent = Me.MdiParent
                'fmat.GridView1.Columns("MATERIAL_CODE")
                fmat.GridView1.ActiveFilterString = "[MATERIAL_ID] = '" & _SKU & "'"
                fmat.Show()
            Else
                MsgBox("Debe seleccionar un grid que tenga codigo del articulo", MsgBoxStyle.Information, "Aviso")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRazonamiento_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRazonamiento.ItemClick

        Dim xfr As New frmRazonamiento
        xfr.serialNumber = _recepcion
        xfr.ShowDialog()

    End Sub
    Private Sub btnActualizacion_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnActualizacion.ItemClick
        If XtraTabControl1.SelectedTabPage.Name = "XtraTabPage1" Then
            Me.Timer1.Enabled = IIf(Me.Timer1.Enabled, False, True)
            e.Item.Caption = IIf(Me.Timer1.Enabled, "Actualzacion automatica", "Actualizacion manual")
            showi()
        Else
            MsgBox("Para cambiar este valor debe seleccionar el tab de recepciones")
        End If
    End Sub
    Private Sub showi()
        Try
            Dim xDataSet As New DataSet
            pResult = String.Empty
            xDataSet = xserv.get_recepcions_pending_auto(PublicLoginInfo.Environment, pResult)

            If pResult = "OK" Then
                LoadGridLayout("frmAprobacionRecepcion", PublicLoginInfo.LoginID, GridViewRECEPCIONES)

                GridRECEPCIONES.DataSource = xDataSet.Tables("OP_WMS_TRANS")
                GridRECEPCIONES.Refresh()
            Else
                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            pResult = String.Empty
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If XtraTabControl1.SelectedTabPage.Name = "XtraTabPage1" Then
            showi()
        End If
    End Sub

End Class
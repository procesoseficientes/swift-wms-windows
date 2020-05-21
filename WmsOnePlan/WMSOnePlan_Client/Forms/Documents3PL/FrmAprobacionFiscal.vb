
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraReports.UI
Imports MobilityScm.Modelo.Configuracion
Imports MobilityScm.Modelo.Tipos
Imports Enums = MobilityScm.Modelo.Tipos.Enums

Public Class FrmAprobacionFiscal
    ReadOnly _xserv3PlPolizas As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    ReadOnly _xInfoTrans As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")

    Private _codigoPoliza As String = ""
    Private _comments As String = String.Empty

#Region "Encabezaod"

    Private Sub FrmAprobacionFiscal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFechaInicio.EditValue = Date.Today.AddDays(-7)
        dtFechaFinal.EditValue = Date.Today

        Dim showQtyAso = _xInfoTrans.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.ValidateQuantity), Enums.GetStringValue(IdParametro.TaxApprovalAmount))

        If showQtyAso IsNot Nothing And showQtyAso.Equals("0") Then
            colQtyAso.Visible = False
        End If

    End Sub

    Private Sub LlenarGridPolizas()
        Try
            If dtFechaInicio.EditValue Is Nothing Or dtFechaFinal.EditValue Is Nothing Then
                Return
            End If
            Dim result As String = ""
            gridPolizas.DataSource = _xserv3PlPolizas.GetPolizasIngresoFiscal("INGRESO", "FISCAL", True, Date.Parse(dtFechaInicio.EditValue), Date.Parse(dtFechaFinal.EditValue), PublicLoginInfo.Environment, result)
            If Not result.Equals("OK") Then
                NotifyStatus(result, False, True)
            End If
            ValidarPrint()
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub dtFechaInicio_EditValueChanged(sender As Object, e As EventArgs) Handles dtFechaInicio.EditValueChanged, dtFechaFinal.EditValueChanged
        LlenarGridPolizas()
    End Sub

    Private Sub barBtnRefreshHeader_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles barBtnRefreshHeader.ItemClick
        LlenarGridPolizas()
    End Sub

    Private Sub gridPolizas_DoubleClick(sender As Object, e As EventArgs) Handles gridPolizas.DoubleClick
        SelectPoliza()
    End Sub

    Private Sub SelectPoliza()
        Try
            If gridViewPolizas.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = gridViewPolizas.GetDataRow(gridViewPolizas.FocusedRowHandle)
                Dim docId As String = Integer.Parse(xdatarow("DOC_ID").ToString)
                If Not docId = 0 Then
                    _comments = String.Empty
                    _comments = xdatarow("COMMENTS").ToString
                    _codigoPoliza = xdatarow("CODIGO_POLIZA").ToString
                    tabDet.Text = _codigoPoliza
                    tabDet.Show()
                    LlenarGridEnlazados()
                    LlenarGridLineas()
                    LlenarGridLicence()
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub
#End Region

#Region "Detalle"

    Private Sub FrmAprobacionFiscal_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'SplitContainerControl1.SplitterPosition = Me.Width / 2
    End Sub

    Private Sub LlenarGridLicence()
        Try
            Dim result As String = ""
            Dim dt As DataTable = _xserv3PlPolizas.GetRecepcionPendingAuto(_codigoPoliza, PublicLoginInfo.Environment, result)
            If Not result.Equals("OK") Then
                NotifyStatus(result, False, True)
                Return
            End If
            dt.Columns.Add("LINEAS_ASOCIADOS")


            For Each rowTrans As DataRow In dt.Rows
                Dim enlazados As String = ""
                For Each rowEnlazados As DataRow In CType(gridEnlazados.DataSource, DataTable).Rows
                    If rowTrans("SERIAL_NUMBER").ToString().Equals(rowEnlazados("TRANS_ID").ToString()) Then
                        If Not String.IsNullOrEmpty(enlazados) Then
                            enlazados += ", "
                        End If
                        enlazados += rowEnlazados("LINENO_POLIZA").ToString()
                    End If
                Next
                rowTrans("LINEAS_ASOCIADOS") = enlazados
            Next

            gridLicencias.DataSource = dt

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private _nombrarDatamenber = False

    Private Sub LlenarGridLineas()
        Try
            Dim result As String = ""

            Dim dtS As DataSet = _xserv3PlPolizas.get_Poliza_Detail("", _codigoPoliza, PublicLoginInfo.Environment, result)
            If Not result.Equals("OK") Then
                NotifyStatus(result, False, True)
            End If
            Dim dt As DataTable = dtS.Tables(0)
            dt.Columns.Add("TRANS_ASOCIADOS")

            For Each rowLineas As DataRow In dt.Rows
                Dim enlazados As String = ""
                For Each rowEnlazados As DataRow In CType(gridEnlazados.DataSource, DataTable).Rows
                    If rowLineas("LINE_NUMBER").ToString().Equals(rowEnlazados("LINENO_POLIZA").ToString()) Then
                        If Not String.IsNullOrEmpty(enlazados) Then
                            enlazados += ", "
                        End If
                        enlazados += rowEnlazados("TRANS_ID").ToString()
                    End If
                Next
                rowLineas("TRANS_ASOCIADOS") = enlazados
            Next

            If Not _nombrarDatamenber Then
                gridLienas.DataMember = "OP_WMS_POLIZA_DETAIL"
                _nombrarDatamenber = True
            End If

            gridLienas.DataSource = dt
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Dim _nombrarDatamenberAsociados As Boolean = False
    Private Sub LlenarGridEnlazados()
        Try
            Dim result As String = ""
            If Not _nombrarDatamenberAsociados Then
                gridEnlazados.DataMember = "OP_WMS3PL_POLIZA_TRANS_MATCH"
                _nombrarDatamenberAsociados = True
            End If

            Dim dt As DataSet = _xserv3PlPolizas.get_trans_match(" where TM.codigo_poliza = '" & _codigoPoliza & "'", PublicLoginInfo.Environment, result)
            If Not result.Equals("OK") Then
                NotifyStatus(result, False, True)
            Else
                If dt.Tables(0).Rows.Count >= 1 Then
                    Bar1.Visible = True
                    SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel2
                    btnBorrorAso.Visibility = BarItemVisibility.Never
                    btnEnlazar.Visibility = BarItemVisibility.Never
                    barConfirAsociacion.Visibility = BarItemVisibility.Never
                    btnCancelarAso.Visibility = BarItemVisibility.Never
                    txtComentario3.Visibility = BarItemVisibility.Always

                    txtComentario3.EditValue = _comments
                    txtComentario3.Enabled = False
                    colQtyAso.OptionsColumn.AllowEdit = False
                    colQtyAso.OptionsColumn.AllowFocus = False
                Else
                    Bar1.Visible = True
                    SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
                    btnBorrorAso.Visibility = BarItemVisibility.Always
                    btnEnlazar.Visibility = BarItemVisibility.Always
                    txtComentario3.Visibility = BarItemVisibility.Always
                    txtComentario3.EditValue = String.Empty
                    txtComentario3.Enabled = True
                    barConfirAsociacion.Visibility = BarItemVisibility.Never
                    btnCancelarAso.Visibility = BarItemVisibility.Never
                    colQtyAso.OptionsColumn.AllowEdit = True
                    colQtyAso.OptionsColumn.AllowFocus = True
                End If
            End If
            gridEnlazados.DataSource = dt.Tables(0)

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Public DowTrans As GridHitInfo

    Private Sub gridViewLicencias_MouseDown(sender As Object, e As MouseEventArgs) Handles gridViewLicencias.MouseDown
        Dim view As GridView
        view = CType(sender, GridView)
        DowTrans = Nothing
        Dim hitInfo As GridHitInfo
        hitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not Control.ModifierKeys = Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            DowTrans = hitInfo
        End If
    End Sub

    Private Sub gridViewLicencias_MouseMove(sender As Object, e As MouseEventArgs) Handles gridViewLicencias.MouseMove
        Dim view As GridView
        view = CType(sender, GridView)
        If DowTrans Is Nothing Then
            Return
        End If
        If e.Button = MouseButtons.Left And DowTrans.RowHandle >= 0 Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(DowTrans.HitPoint.X - dragSize.Width / 2, DowTrans.HitPoint.Y - dragSize.Height / 2), dragSize)
            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim row As DataRow = gridViewLicencias.GetDataRow(DowTrans.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                DowTrans = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub gridLicencias_DragOver(sender As Object, e As DragEventArgs) Handles gridLicencias.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub gridLicencias_DragDrop(sender As Object, e As DragEventArgs) Handles gridLicencias.DragDrop
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Asociar()
        End If
    End Sub

    Public DowLineasPoliza As GridHitInfo
    Private Sub gridViewLineas_MouseDown(sender As Object, e As MouseEventArgs) Handles gridViewLineas.MouseDown
        Dim view As GridView
        view = CType(sender, GridView)
        DowLineasPoliza = Nothing
        Dim hitInfo As GridHitInfo
        hitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not Control.ModifierKeys = Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left And hitInfo.RowHandle >= 0 Then
            DowLineasPoliza = hitInfo
        End If
    End Sub

    Private Sub gridViewLineas_MouseMove(sender As Object, e As MouseEventArgs) Handles gridViewLineas.MouseMove
        Dim view As GridView
        view = CType(sender, GridView)
        If DowLineasPoliza Is Nothing Then
            Return
        End If
        If e.Button = MouseButtons.Left And DowLineasPoliza.RowHandle >= 0 Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(DowLineasPoliza.HitPoint.X - dragSize.Width / 2, DowLineasPoliza.HitPoint.Y - dragSize.Height / 2), dragSize)
            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim row As DataRow = gridViewLineas.GetDataRow(DowLineasPoliza.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                DowLineasPoliza = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub

    Private Sub gridLienas_DragOver(sender As Object, e As DragEventArgs) Handles gridLienas.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub gridLienas_DragDrop(sender As Object, e As DragEventArgs) Handles gridLienas.DragDrop
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            Asociar()
        End If
    End Sub

    Private Sub Asociar()
        Try
            If gridViewLicencias.SelectedRowsCount >= 1 Then
                For i = 0 To gridViewLicencias.RowCount - 1
                    If gridViewLicencias.IsRowSelected(i) Then
                        Dim rowTrans As DataRow = gridViewLicencias.GetDataRow(i)

                        For j = 0 To gridViewLineas.RowCount - 1
                            If gridViewLineas.IsRowSelected(j) Then
                                Dim rowLinea As DataRow = gridViewLineas.GetDataRow(j)
                                If Not BuscarAsociacion(rowTrans("SERIAL_NUMBER").ToString(), rowLinea("LINE_NUMBER").ToString()) Then
                                    Dim newRowAso As DataRow = CType(gridViewEnlazados.DataSource, DataView).Table.NewRow()
                                    newRowAso("TRANS_ID") = rowTrans("SERIAL_NUMBER")
                                    newRowAso("LICENSE_ID") = rowTrans("LICENSE_ID")
                                    newRowAso("MATERIAL_CODE") = rowTrans("MATERIAL_CODE")
                                    newRowAso("MATERIAL_DESCRIPTION") = rowTrans("MATERIAL_DESCRIPTION")
                                    newRowAso("QTY_TRANS") = rowTrans("QUANTITY_UNITS")
                                    newRowAso("LINENO_POLIZA") = rowLinea("LINE_NUMBER")
                                    newRowAso("SKU_DESCRIPTION") = rowLinea("SKU_DESCRIPTION")
                                    newRowAso("QTY_POLIZA") = rowLinea("QTY")
                                    newRowAso("BULTOS_POLIZA") = rowLinea("BULTOS")
                                    newRowAso("QTY") = 0
                                    newRowAso("DOC_ID") = rowLinea("DOC_ID")
                                    CType(gridViewEnlazados.DataSource, DataView).Table.Rows.Add(newRowAso)
                                End If
                            End If
                        Next

                    End If
                Next
                LlenarGridLicence()
                LlenarGridLineas()
                gridViewEnlazados.ExpandAllGroups()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Function BuscarAsociacion(ByVal pTransId As String, ByVal pLineaPoliza As String) As Boolean
        Try
            Return CType(gridViewEnlazados.DataSource, DataView).Table.Rows.Cast(Of DataRow)().Any(Function(row) row("TRANS_ID").ToString().Equals(pTransId) And row("LINENO_POLIZA").ToString().Equals(pLineaPoliza))
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
            Return False
        End Try
    End Function

#End Region

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim frm As New FrmTest
        frm.ShowDialog()
    End Sub

    Private Sub btnExpandirAsociados_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExpandirAsociados.ItemClick
        gridViewEnlazados.ExpandAllGroups()
    End Sub

    Private Sub btnContraerAsociados_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnContraerAsociados.ItemClick
        gridViewEnlazados.CollapseAllGroups()
    End Sub

    Private Sub btnBorrorAso_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnBorrorAso.ItemClick
        BorrarAsociacion()
    End Sub

    Private Sub BorrarAsociacion()
        Try
            If gridViewEnlazados.SelectedRowsCount >= 1 Then
                For i = 0 To gridViewEnlazados.RowCount - 1
                    If gridViewEnlazados.IsRowSelected(i) Then
                        Dim rowTrans As DataRow = gridViewEnlazados.GetDataRow(i)
                        CType(gridViewEnlazados.DataSource, DataView).Table.Rows.Remove(rowTrans)
                    End If
                Next
                LlenarGridLicence()
                LlenarGridLineas()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub GrabarAsociadion()
        Try
            Dim validateQTY = _xInfoTrans.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.ValidateQuantity), Enums.GetStringValue(IdParametro.TaxApprovalAmount))

            For Each rowAsociado As DataRow In CType(gridViewEnlazados.DataSource, DataView).Table.Rows
                Dim pResult As String = ""
                Dim comments As String = ""
                If Not txtComentario3.EditValue = Nothing Then
                    comments = txtComentario3.EditValue.ToString()
                End If
                'Dim comments As String = IIf(txtComentario3.EditValue = Nothing, "", txtComentario3.EditValue.ToString())
                If Not _xserv3PlPolizas.set_POLIZA_TRANS_MATCH(_codigoPoliza, Integer.Parse(rowAsociado("TRANS_ID").ToString()),
                                                                   Integer.Parse(rowAsociado("LINENO_POLIZA").ToString()),
                                                                   Integer.Parse(rowAsociado("DOC_ID").ToString()),
                                                                   rowAsociado("SKU_DESCRIPTION").ToString(), rowAsociado("MATERIAL_CODE").ToString(),
                                                                   rowAsociado("MATERIAL_DESCRIPTION").ToString(), Double.Parse(rowAsociado("QTY_TRANS").ToString()),
                                                                   Double.Parse(rowAsociado("QTY_POLIZA").ToString()), Double.Parse(rowAsociado("BULTOS_POLIZA").ToString()),
                                                                   PublicLoginInfo.LoginName, IIf(validateQTY IsNot Nothing And validateQTY.Equals("0"), Double.Parse(rowAsociado("QTY_TRANS").ToString()), Double.Parse(rowAsociado("QTY")).ToString()), comments,
                                                                    PublicLoginInfo.Environment, pResult) Then

                    NotifyStatus(pResult, True, True)
                    Exit For
                End If
            Next
            barConfirAsociacion.Visibility = BarItemVisibility.Never
            btnCancelarAso.Visibility = BarItemVisibility.Never
            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
            btnBorrorAso.Visibility = BarItemVisibility.Always
            btnEnlazar.Visibility = BarItemVisibility.Always
            tabHeader.Show()
            gridLienas.DataSource = Nothing
            gridLicencias.DataSource = Nothing
            gridEnlazados.DataSource = Nothing
            tabDet.Text = "Cuadre"
            LlenarGridPolizas()
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub btnEnlazar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEnlazar.ItemClick
        If gridViewEnlazados.RowCount = 0 Then
            Return
        End If
        gridLicencias.Focus()
        If Validar() Then
            SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Panel2
            btnBorrorAso.Visibility = BarItemVisibility.Never
            btnEnlazar.Visibility = BarItemVisibility.Never
            barConfirAsociacion.Visibility = BarItemVisibility.Always
            btnCancelarAso.Visibility = BarItemVisibility.Always
            gridViewEnlazados.ExpandAllGroups()
            colQtyAso.OptionsColumn.AllowEdit = False
            colQtyAso.OptionsColumn.AllowFocus = False
        End If
    End Sub

    Private Sub barConfirAsociacion_ItemClick(sender As Object, e As ItemClickEventArgs) Handles barConfirAsociacion.ItemClick
        GrabarAsociadion()
    End Sub

    Private Sub btnCancelarAso_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnCancelarAso.ItemClick
        SplitContainerControl2.PanelVisibility = SplitPanelVisibility.Both
        btnBorrorAso.Visibility = BarItemVisibility.Always
        btnEnlazar.Visibility = BarItemVisibility.Always
        barConfirAsociacion.Visibility = BarItemVisibility.Never
        btnCancelarAso.Visibility = BarItemVisibility.Never
        colQtyAso.OptionsColumn.AllowEdit = True
        colQtyAso.OptionsColumn.AllowFocus = True

    End Sub

    Function Validar() As Boolean
        Try
            Dim validateQTY = _xInfoTrans.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.ValidateQuantity), Enums.GetStringValue(IdParametro.TaxApprovalAmount))

            If CType(gridViewLicencias.DataSource, DataView).Table.Rows.Cast(Of DataRow)().Any(Function(dataRow) dataRow("LINEAS_ASOCIADOS") Is Nothing Or String.IsNullOrEmpty(dataRow("LINEAS_ASOCIADOS").ToString())) Then
                MessageBox.Show("Faltan transacciones por asociar", "Error Transacciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If CType(gridViewLineas.DataSource, DataView).Table.Rows.Cast(Of DataRow)().Any(Function(dataRow) dataRow("TRANS_ASOCIADOS") Is Nothing Or String.IsNullOrEmpty(dataRow("TRANS_ASOCIADOS").ToString())) Then
                MessageBox.Show("Faltan lineas por asociar", "Error Lineas", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            If validateQTY IsNot Nothing And validateQTY.Equals("1") And CType(gridViewEnlazados.DataSource, DataView).Table.Rows.Cast(Of DataRow)().Any(Function(dataRow) dataRow("QTY") Is Nothing Or Double.Parse(dataRow("QTY").ToString()) <= 0) Then
                MessageBox.Show("Las cantidades tienen que ser mayor a 0", "Error Asociados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If

            For Each dataRow As DataRow In CType(gridViewLineas.DataSource, DataView).Table.Rows
                Dim qty As Double = 0
                For Each dataRowDet As DataRow In CType(gridViewEnlazados.DataSource, DataView).Table.Rows
                    If dataRow("LINE_NUMBER").ToString().Equals(dataRowDet("LINENO_POLIZA").ToString()) Then
                        qty += IIf(validateQTY IsNot Nothing And validateQTY.Equals("1"), Double.Parse(dataRowDet("QTY").ToString()), Double.Parse(dataRowDet("QTY_TRANS").ToString()))
                    End If
                Next

                If qty <> Double.Parse(dataRow("BULTOS")) Then

                    MessageBox.Show("Las cantidades no coiciden con la linea " & dataRow("LINE_NUMBER").ToString() & " de la poliza", "Error Asociados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'Return False
                    If MessageBox.Show("Desea guardar con diferencias?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        If txtComentario3.EditValue.ToString() = "" Then
                            MessageBox.Show("Ingrese el comentario.", "Error Asociados", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Bar1.ItemLinks(1).Focus()
                            Return False
                        End If 'Dim xstr As String
                        'xstr = InputBox("Comentario sobre las diferencias", "Ingrese un comentario", "")
                        'If xstr <> "" Then
                        'End If
                    Else
                        Return False
                    End If
                End If
            Next

            Return True
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
            Return False
        End Try
        Return True
    End Function


    Private Sub btnExpandirHeader_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnExpandirHeader.ItemClick
        gridViewPolizas.ExpandAllGroups()
    End Sub

    Private Sub barContraerHeader_ItemClick(sender As Object, e As ItemClickEventArgs) Handles barContraerHeader.ItemClick
        gridViewPolizas.CollapseAllGroups()
    End Sub

    Private Sub btnPrintHeader_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnPrintHeader.ItemClick
        Print()
    End Sub

    Private Sub Print()
        Try
            If gridViewPolizas.RowCount > 0 Then
                If gridViewPolizas.SelectedRowsCount = 1 Then
                    Dim xdatarow As DataRow = gridViewPolizas.GetDataRow(gridViewPolizas.FocusedRowHandle)

                    Dim result As String = ""
                    Dim dt As DataSet = _xserv3PlPolizas.get_trans_match(" where TM.codigo_poliza = '" & xdatarow("CODIGO_POLIZA").ToString() & "'", PublicLoginInfo.Environment, result)
                    If result.Equals("OK") Then
                        Dim rptApFiscal As New rptAprobacionFiscal
                        rptApFiscal.DataMember = "OP_WMS3PL_POLIZA_TRANS_MATCH"
                        rptApFiscal.DataSource = dt
                        rptApFiscal.RequestParameters = False
                        rptApFiscal.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                        rptApFiscal.Parameters("prmCodigoPoliza").Value = xdatarow("CODIGO_POLIZA").ToString()
                        rptApFiscal.Parameters("prmNumOrden").Value = xdatarow("NUMERO_ORDEN").ToString()
                        rptApFiscal.Parameters("prmCodigoCliente").Value = xdatarow("CLIENT_CODE").ToString()
                        rptApFiscal.Parameters("prmNombreCliente").Value = xdatarow("CardName").ToString()
                        rptApFiscal.Parameters("prmUsers").Value = PublicLoginInfo.LoginName
                        rptApFiscal.ShowPreview()
                    Else
                        NotifyStatus(result, False, True)
                    End If
                End If
            End If


        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub ValidarPrint()
        Try
            If gridViewPolizas.FocusedRowHandle >= 0 Then
                Dim xdatarow As DataRow = gridViewPolizas.GetDataRow(gridViewPolizas.FocusedRowHandle)
                If xdatarow("STATUS").ToString.Equals("ASOCIADO") Then
                    btnPrintHeader.Visibility = BarItemVisibility.Always
                Else
                    btnPrintHeader.Visibility = BarItemVisibility.Never
                End If
                Exit Sub
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
        btnPrintHeader.Visibility = BarItemVisibility.Never
    End Sub

    Private Sub gridViewPolizas_FocusedRowChanged(sender As Object, e As Views.Base.FocusedRowChangedEventArgs) Handles gridViewPolizas.FocusedRowChanged
        ValidarPrint()
    End Sub

    Private Sub gridPolizas_Click(sender As System.Object, e As System.EventArgs) Handles gridPolizas.Click

    End Sub

    Private Sub UiBotonRectificar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonRectificar.ItemClick
        If gridViewPolizas.SelectedRowsCount = 1 Then
            Dim xdatarow As DataRow = gridViewPolizas.GetDataRow(gridViewPolizas.FocusedRowHandle)
            Dim docId As String = Integer.Parse(xdatarow("DOC_ID").ToString)
            Dim codigoPoliza As String = xdatarow("CODIGO_POLIZA").ToString
            Dim numeroPoliza As String = xdatarow("NUMERO_ORDEN").ToString

            Dim pendienteRectificacion As String = IIf(IsDBNull(xdatarow("PENDIENTE_RECTIFICACION")), "0", xdatarow("PENDIENTE_RECTIFICACION"))
            Dim comentario As String = IIf(IsDBNull(xdatarow("COMENTARIO_RECTIFICADO")), "", xdatarow("COMENTARIO_RECTIFICADO"))
            Dim clase As String = IIf(IsDBNull(xdatarow("CLASE_POLIZA_RECTIFICACION")), "", xdatarow("CLASE_POLIZA_RECTIFICACION"))
            'Dim codigoPolizaRectificacion As String = xdatarow("CODIGO_POLIZA_RECTIFICACION").ToString

            Dim frmRectificarPoliza As New FrmRectificarPoliza(pendienteRectificacion, docId, codigoPoliza, numeroPoliza, comentario, clase)
            frmRectificarPoliza.ShowDialog()
            If frmRectificarPoliza._pendienteDeRectificacion = 1 Then
                LlenarGridPolizas()
                MessageBox.Show("Proceso exitoso.", "Pendiente de Rectificar", MessageBoxButtons.OK)
            End If
        End If
    End Sub
End Class
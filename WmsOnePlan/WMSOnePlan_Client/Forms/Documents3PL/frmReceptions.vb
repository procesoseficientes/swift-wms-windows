Imports System.IO
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraLayout
Imports DevExpress.XtraPrinting
Public Class frmReceptions
    Dim pResult As String
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim btnReadClickedAtLeastOneTime = False

    Private Sub frmReceptions_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            fn_llena_combos()

        Catch ex As Exception
            MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmReceptions_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'limpiamos los datasets
        Try

            xserv = Nothing
            xClientsServ = Nothing
            xSettingServ = Nothing

            pResult = Nothing
        Catch ex As Exception
            MsgBox("Error al Limpiar" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmReceptions_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmReceptionsLayout" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutControl1.SaveLayoutToXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmReceptionsGridPolizas" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewPolizas.SaveLayoutToXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmReceptionsGridTrans" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewTrans.SaveLayoutToXml(strPath)
                strPath = String.Empty
            End If
        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmReceptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String
        Try
            LayoutControl1.SetDefaultLayout()

            gLastScreenShowed = Me.Name

            Me.Cursor = Cursors.Default

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmReceptionsLayout" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutControl1.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmReceptionsGridPolizas" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewPolizas.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If
            'grabamos el layout del grid
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmReceptionsGridTrans" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewTrans.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If
        Catch ex As Exception
            MsgBox("Error al abrir la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub fn_llena_combos()
        Try
            Dim i As Integer
            'llenamos el combo de los regimenes de almacen
            Dim dsRegimenAlmacen As New DataSet
            dsRegimenAlmacen = xSettingServ.GetParam_ByParamKey("WMS3PL", "WAREHOUSE_REGIMEN", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                cmbRegimen.Properties.DataSource = dsRegimenAlmacen.Tables(0)
                cmbRegimen.Properties.PopulateViewColumns()
                cmbRegimen.Properties.ValueMember = "PARAM_NAME"
                cmbRegimen.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To cmbRegimen.Properties.View.Columns.Count - 1
                    cmbRegimen.Properties.View.Columns(i).Visible = False
                Next
                cmbRegimen.Properties.View.Columns("PARAM_NAME").Caption = "REGIMEN ALMACEN"
                cmbRegimen.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION REGIMEN ALMACEN"
                cmbRegimen.Properties.View.Columns("PARAM_NAME").Visible = True
                cmbRegimen.Properties.View.Columns("PARAM_CAPTION").Visible = True
                cmbRegimen.Properties.View.BestFitColumns()
            Else
                MsgBox(pResult)
            End If
            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsClientes) Then
                    cmbClientes.Properties.DataSource = dsClientes.Tables(0)
                    cmbClientes.Properties.PopulateViewColumns()
                    cmbClientes.Properties.ValueMember = "CLIENT_CODE"
                    cmbClientes.Properties.DisplayMember = "CLIENT_NAME"

                    For i = 0 To cmbClientes.Properties.View.Columns.Count - 1
                        cmbClientes.Properties.View.Columns(i).Visible = False
                    Next

                    cmbClientes.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                    cmbClientes.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                    cmbClientes.Properties.View.Columns("CLIENT_CODE").Visible = True
                    cmbClientes.Properties.View.Columns("CLIENT_NAME").Visible = True
                    cmbClientes.Properties.View.BestFitColumns()

                End If
            Else
                MsgBox(pResult)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnRead_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles btnRead.ItemClick
        Try
            Dim dsPol As DataSet
            If IsNothing(cmbRegimen.EditValue) Then
                MsgBox("Debe seleccionar un regimen")
                cmbRegimen.Focus()
                Exit Sub
            End If
            If IsNothing(cmbClientes.EditValue) Then
                MsgBox("Debe seleccionar un cliente")
                cmbClientes.Focus()
                Exit Sub
            End If

            dsPol = xserv.GetPolizaByClientAndWarehouseRegimen(PublicLoginInfo.LoginID, cmbRegimen.EditValue, cmbClientes.EditValue, PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If Not IsNothing(dsPol) Then
                    If dsPol.Tables.Count > 0 Then
                        GridPolizas.DataSource = dsPol.Tables(0)
                        GridViewPolizas.BestFitColumns()
                        If GridViewPolizas.RowCount < 1 Then
                            ClearControlsWhenReadingPolicy(GridTrans, GridImagen)
                        Else
                            If btnReadClickedAtLeastOneTime Then
                                ShowTransactionsAndImages()
                            Else
                                btnReadClickedAtLeastOneTime = True
                            End If
                        End If
                    End If
                End If
            Else
                MsgBox(pResult)
            End If
            dsPol = Nothing
            pResult = String.Empty
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GridViewPolizas_FocusedRowChanged(ByVal sender As Object, ByVal e As Views.Base.FocusedRowChangedEventArgs) Handles GridViewPolizas.FocusedRowChanged
        Try
            btnReadClickedAtLeastOneTime = False
            ShowTransactionsAndImages()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            Dim i As Int16
            CompositeLink1.Links.Clear()

            For i = 0 To 2
                Dim link As New PrintableComponentLink
                If i = 0 Then
                    link.Component = GridPolizas
                ElseIf i = 1 Then
                    link.Component = GridTrans
                Else
                    link.Component = GridImagen
                End If

                CompositeLink1.Links.Add(link)
            Next

            CompositeLink1.CreateDocument()
            CompositeLink1.ShowPreview()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ShowTransactionsAndImages()
        Try
            Dim dsTrans As DataSet
            Dim dsIMAGE As DataSet
            If GridViewPolizas.SelectedRowsCount > 0 Then
                If GridViewPolizas.FocusedRowHandle >= 0 Then ' then DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                    If GridViewPolizas.GetFocusedRowCellValue("CODIGO_POLIZA").ToString().Length > 0 Then
                        dsTrans = xserv.get_tran_byPoliza(GridViewPolizas.GetFocusedRowCellValue("CODIGO_POLIZA").ToString(), PublicLoginInfo.Environment, pResult)
                        If pResult = "OK" Then
                            If Not IsNothing(dsTrans) Then
                                If dsTrans.Tables(0).Rows.Count > 0 Then
                                    GridTrans.DataSource = dsTrans.Tables(0)
                                    GridViewTrans.BestFitColumns()
                                Else
                                    ClearControlsWhenReadingPolicy(GridTrans, GridImagen, dsTrans)
                                End If
                            End If
                        Else
                            MsgBox(pResult)
                        End If

                        dsIMAGE = xserv.get_all_Poliza_Images(" Where CODIGO_POLIZA = '" & GridViewPolizas.GetFocusedRowCellValue("CODIGO_POLIZA").ToString() & "'", PublicLoginInfo.Environment, pResult)
                        If pResult = "OK" Then
                            If Not IsNothing(dsIMAGE) Then
                                If dsIMAGE.Tables(0).Rows.Count > 0 Then

                                    layoutViewField_colIMAGEN.Width = LayoutView1.CalcColumnBestWidth(colIMAGEN)
                                    LayoutView1 = New Views.Layout.LayoutView(GridImagen)
                                    LayoutView1.OptionsBehavior.AutoPopulateColumns = False
                                    GridImagen.DataSource = dsIMAGE.Tables(0)

                                    Dim imagesXPolicy = dsIMAGE.Tables(0).Rows
                                    If imagesXPolicy.Count > 0 Then
                                        For Each image As DataRow In imagesXPolicy
                                            If Not IsDBNull(image.Item("IMAGE_64")) Then
                                                Dim base64Image As String = image.Item("IMAGE_64")
                                                Dim bytesArray() As Byte

                                                bytesArray = Convert.FromBase64String(base64Image)
                                                image.Item("IMAGEN") = bytesArray
                                            End If
                                        Next
                                    End If
                                    'GridImagen.Dock = DockStyle.Fill
                                    RepositoryItemPictureEdit1.SizeMode = PictureSizeMode.Stretch
                                    colIMAGEN.ColumnEdit = RepositoryItemPictureEdit1
                                    LayoutView1.CardMinSize = New Size(850, 300)
                                    layoutViewField_colIMAGEN.TextVisible = False
                                    layoutViewField_colIMAGEN.SizeConstraintsType = SizeConstraintsType.Custom
                                    layoutViewField_colIMAGEN.Size = New Size(200, 200)
                                    layoutViewField_colIMAGEN.MaxSize = New Size(200, 200)
                                    layoutViewField_colIMAGEN.MinSize = layoutViewField_colIMAGEN.MaxSize
                                Else
                                    ClearControlsWhenReadingPolicy(GridTrans, GridImagen, dsIMAGE)
                                End If
                            End If
                        Else
                            MsgBox(pResult)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearControlsWhenReadingPolicy(gridControl As GridControl, Optional gridControl2 As GridControl = Nothing, Optional dataSet As DataSet = Nothing)
        If dataSet IsNot Nothing Then
            dataSet.Tables(0).Clear()
        End If
        If gridControl2 IsNot Nothing Then
            gridControl2.DataSource = Nothing
            gridControl2.Refresh()
        End If
        gridControl.DataSource = Nothing
        gridControl.Refresh()
    End Sub
End Class
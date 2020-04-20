Public Class frmNewAudit 
    Dim pResult As String = String.Empty
    Dim cTipo As String = String.Empty
    Dim cFiltro As String = String.Empty
    Dim cOpcion As String = String.Empty
    Dim dtOpciones As DataTable
    Dim listOp As DataTable

    Private Sub WizardControl1_NextClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControl1.NextClick
        Try
            If e.Page.Name = WizardPage1.Name Then
                If IsNothing(rgTipoConteo.EditValue) Then
                    MsgBox("Debe seleccionar un conteo")
                    rgTipoConteo.Focus()
                Else
                    Select Case rgTipoConteo.EditValue
                        Case "MATERIAL_ID"
                            cargaProductos("Tipo")
                        Case "CLIENT_CODE"
                            cargaClientes("Tipo")
                        Case "CODIGO_POLIZA"
                            cargaPolizas()
                        Case "REGIMEN"
                            cargaRegimen("Tipo")
                        Case "WAREHOUSE_ID"
                            cargaBodegas("Tipo")
                        Case "COMPLETO"
                            Dim response As MsgBoxResult
                            response = MsgBox("Se creara un conteo con todas las ubicaciones de todas las bodegas ¿desea continuar?", MsgBoxStyle.YesNo, "Confirmacion")
                            If response = MsgBoxResult.Yes Then
                                MsgBox("entro")
                            End If
                        Case Else
                            MsgBox("Debe seleccionar un conteo")
                    End Select
                    creaTablaOpciones()
                End If
            ElseIf e.Page.Name = WizardPage2.Name Then
                If GridView1.SelectedRowsCount > 0 Then
                    listOp = New DataTable
                    Dim dc As New DataColumn
                    Dim dc1 As New DataColumn
                    Dim dr As DataRow
                    Dim i As Integer

                    listOp.TableName = "OPCIONES"
                    dc.ColumnName = "OPCION"
                    dc.DataType = System.Type.GetType("System.String")
                    dc.MaxLength = 50
                    listOp.Columns.Add(dc)

                    dc1.ColumnName = "VALOR"
                    dc1.DataType = System.Type.GetType("System.String")
                    dc1.MaxLength = 300
                    listOp.Columns.Add(dc1)
                    dc = Nothing
                    dc1 = Nothing

                    For i = 0 To GridView1.SelectedRowsCount - 1
                        dr = listOp.NewRow

                        Select Case rgTipoConteo.EditValue
                            Case "MATERIAL_ID"
                                dr("OPCION") = "MATERIAL_ID"
                                dr("VALOR") = GridView1.GetRowCellValue(i, "MATERIAL_ID").ToString

                            Case "CLIENT_CODE"
                                dr("OPCION") = "CLIENT_CODE"
                                dr("VALOR") = GridView1.GetRowCellValue(i, "CLIENT_CODE").ToString

                            Case "CODIGO_POLIZA"
                                dr("OPCION") = "CODIGO_POLIZA"
                                dr("VALOR") = GridView1.GetRowCellValue(i, "CODIGO_POLIZA").ToString

                            Case "REGIMEN"
                                dr("OPCION") = "REGIMEN"
                                dr("VALOR") = GridView1.GetRowCellValue(i, "PARAM_NAME").ToString

                            Case "WAREHOUSE_ID"
                                dr("OPCION") = "WAREHOUSE_ID"
                                dr("VALOR") = GridView1.GetRowCellValue(i, "WAREHOUSE_ID").ToString

                            Case "COMPLETO"
                                dr("OPCION") = "COMPLETO"
                                dr("VALOR") = "COMPLETO"

                            Case Else
                                MsgBox("Debe seleccionar un conteo")
                        End Select
                        listOp.Rows.Add(dr)
                        dr = Nothing
                    Next
                    obtieneUbicaciones(listOp)
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub rgTipoConteo_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rgTipoConteo.EditValueChanged
        If Not IsNothing(rgTipoConteo.EditValue) Then
            WizardPage1.AllowNext = True

        End If
    End Sub
    Private Sub cargaProductos(ByVal pPaso As String)
        Dim xSkus As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
        Dim dsSKUS As New DataSet
        Try
            Cursor = Cursors.WaitCursor
            dsSKUS = xSkus.SearchPartialMaterials("", "", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If pPaso = "Filtro" Then
                    cmbOpcion.Properties.View.Columns.Clear()
                    cmbOpcion.Properties.DataSource = dsSKUS.Tables(0)
                    cmbOpcion.Properties.PopulateViewColumns()
                    cmbOpcion.Properties.ValueMember = "MATERIAL_ID"
                    cmbOpcion.Properties.DisplayMember = "MATERIAL_NAME"

                    For i = 0 To cmbOpcion.Properties.View.Columns.Count - 1
                        cmbOpcion.Properties.View.Columns(i).Visible = False
                    Next
                    cmbOpcion.Properties.View.Columns("MATERIAL_ID").Caption = "CODIGO"
                    cmbOpcion.Properties.View.Columns("MATERIAL_NAME").Caption = "DESCRIPCION"
                    cmbOpcion.Properties.View.Columns("ALTERNATE_BARCODE").Caption = "CODIGO ALTERNO"
                    cmbOpcion.Properties.View.Columns("MATERIAL_ID").Visible = True
                    cmbOpcion.Properties.View.Columns("MATERIAL_NAME").Visible = True
                    cmbOpcion.Properties.View.Columns("ALTERNATE_BARCODE").Visible = True
                    cmbOpcion.Properties.View.BestFitColumns()
                ElseIf pPaso = "Tipo" Then
                    GridView1.Columns.Clear()
                    GridControl1.DataSource = dsSKUS.Tables(0)
                    GridControl1.RefreshDataSource()
                    For i = 0 To GridView1.Columns.Count - 1
                        GridView1.Columns(i).Visible = False
                    Next
                    GridView1.Columns("MATERIAL_ID").Caption = "CODIGO"
                    GridView1.Columns("MATERIAL_NAME").Caption = "DESCRIPCION"
                    GridView1.Columns("ALTERNATE_BARCODE").Caption = "CODIGO ALTERNO"
                    GridView1.Columns("BARCODE_ID").Caption = "CODIGO BARRAS"
                    GridView1.Columns("MATERIAL_ID").Visible = True
                    GridView1.Columns("MATERIAL_NAME").Visible = True
                    GridView1.Columns("ALTERNATE_BARCODE").Visible = True
                    GridView1.Columns("BARCODE_ID").Visible = True
                    GridView1.BestFitColumns()
                End If
            Else
                MessageBox.Show("Error en el servicio : " + pResult, "Error")
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub cmbFiltro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFiltro.SelectedIndexChanged
        Try
            If Not IsNothing(cmbFiltro.EditValue) Then
                Select Case cmbFiltro.EditValue
                    Case "Regimen"
                        cargaRegimen("Filtro")
                    Case "Cliente"
                        cargaClientes("Filtro")
                    Case "Bodega"
                        cargaBodegas("Filtro")
                End Select
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        End Try
    End Sub
    Private Sub cargaRegimen(ByVal pPaso As String)
        Try
            Cursor = Cursors.WaitCursor
            Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            Dim dsRegimenAlmacen As New DataSet
            dsRegimenAlmacen = xSettingServ.GetParam_ByParamKey("WMS3PL", "WAREHOUSE_REGIMEN", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If pPaso = "Filtro" Then
                    cmbOpcion.Properties.View.Columns.Clear()
                    cmbOpcion.Properties.DataSource = dsRegimenAlmacen.Tables(0)
                    cmbOpcion.Properties.PopulateViewColumns()
                    cmbOpcion.Properties.ValueMember = "PARAM_NAME"
                    cmbOpcion.Properties.DisplayMember = "PARAM_CAPTION"

                    For i = 0 To cmbOpcion.Properties.View.Columns.Count - 1
                        cmbOpcion.Properties.View.Columns(i).Visible = False
                    Next
                    cmbOpcion.Properties.View.Columns("PARAM_NAME").Caption = "REGIMEN ALMACEN"
                    cmbOpcion.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION REGIMEN ALMACEN"
                    cmbOpcion.Properties.View.Columns("PARAM_NAME").Visible = True
                    cmbOpcion.Properties.View.Columns("PARAM_CAPTION").Visible = True
                    cmbOpcion.Properties.View.BestFitColumns()
                ElseIf pPaso = "Tipo" Then
                    GridView1.Columns.Clear()
                    GridControl1.DataSource = dsRegimenAlmacen.Tables(0)
                    GridControl1.RefreshDataSource()
                    For i = 0 To GridView1.Columns.Count - 1
                        GridView1.Columns(i).Visible = False
                    Next
                    GridView1.Columns("PARAM_NAME").Caption = "REGIMEN ALMACEN"
                    GridView1.Columns("PARAM_CAPTION").Caption = "DESCRIPCION REGIMEN ALMACEN"
                    GridView1.Columns("PARAM_NAME").Visible = True
                    GridView1.Columns("PARAM_CAPTION").Visible = True
                    GridView1.BestFitColumns()
                End If
            Else
                MessageBox.Show("Error en el servicio : " + pResult, "Error")
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cargaClientes(ByVal pPaso As String)

        Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
        Try
            Cursor = Cursors.WaitCursor
            Dim dsClientes As New DataSet
            pResult = String.Empty
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If pPaso = "Filtro" Then
                    cmbOpcion.Properties.View.Columns.Clear()
                    cmbOpcion.Properties.DataSource = dsClientes.Tables(0)
                    cmbOpcion.Properties.PopulateViewColumns()
                    cmbOpcion.Properties.ValueMember = "CLIENT_CODE"
                    cmbOpcion.Properties.DisplayMember = "CLIENT_NAME"

                    For i = 0 To cmbOpcion.Properties.View.Columns.Count - 1
                        cmbOpcion.Properties.View.Columns(i).Visible = False
                    Next
                    cmbOpcion.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                    cmbOpcion.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                    cmbOpcion.Properties.View.Columns("CLIENT_CODE").Visible = True
                    cmbOpcion.Properties.View.Columns("CLIENT_NAME").Visible = True
                    cmbOpcion.Properties.View.BestFitColumns()
                ElseIf pPaso = "Tipo" Then
                    GridView1.Columns.Clear()
                    GridControl1.DataSource = dsClientes.Tables(0)
                    GridControl1.RefreshDataSource()
                    For i = 0 To GridView1.Columns.Count - 1
                        GridView1.Columns(i).Visible = False
                    Next
                    GridView1.Columns("CLIENT_CODE").Caption = "CODIGO"
                    GridView1.Columns("CLIENT_NAME").Caption = "NOMBRE"
                    GridView1.Columns("CLIENT_CODE").Visible = True
                    GridView1.Columns("CLIENT_NAME").Visible = True
                    GridView1.BestFitColumns()
                End If
            Else
                MessageBox.Show("Error en el servicio : " + pResult, "Error")
            End If


        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub cargaPolizas()
        Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
        Dim dsPolizas As New DataSet
        Try
            Cursor = Cursors.WaitCursor
            pResult = String.Empty
            dsPolizas = xserv.get_all_Poliza_Headers(" Where TIPO = 'INGRESO' ", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                GridView1.Columns.Clear()
                GridControl1.DataSource = dsPolizas.Tables(0)
                GridControl1.RefreshDataSource()
                For i = 0 To GridView1.Columns.Count - 1
                    GridView1.Columns(i).Visible = False
                Next
                GridView1.Columns("CODIGO_POLIZA").Caption = "POLIZA"
                GridView1.Columns("NUMERO_ORDEN").Caption = "NUMERO DE ORDEN"
                GridView1.Columns("NUMERO_DUA").Caption = "DUA"
                GridView1.Columns("CODIGO_POLIZA").Visible = True
                GridView1.Columns("NUMERO_ORDEN").Visible = True
                GridView1.Columns("NUMERO_DUA").Visible = True
                GridView1.Columns("REGIMEN").Visible = True
                GridView1.BestFitColumns()

            Else
                MessageBox.Show("Error en el servicio : " + pResult, "Error")
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub cargaBodegas(ByVal pPaso As String)
        Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
        Dim dsPolizas As New DataSet
        Try
            Cursor = Cursors.WaitCursor
            pResult = String.Empty
            dsPolizas = xserv.get_all_warehouses(PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If pPaso = "Filtro" Then
                    cmbOpcion.Properties.View.Columns.Clear()
                    cmbOpcion.Properties.DataSource = dsPolizas.Tables(0)
                    cmbOpcion.Properties.PopulateViewColumns()
                    cmbOpcion.Properties.ValueMember = "WAREHOUSE_ID"
                    cmbOpcion.Properties.DisplayMember = "WAREHOUSE_ID"

                    'For i = 0 To cmbOpcion.Properties.View.Columns.Count - 1
                    '    cmbOpcion.Properties.View.Columns(i).Visible = False
                    'Next
                    cmbOpcion.Properties.View.Columns("WAREHOUSE_ID").Caption = "CODIGO"
                    'cmbOpcion.Properties.View.Columns("NAME").Caption = "NOMBRE"
                    'cmbOpcion.Properties.View.Columns("WAREHOUSE_ID").Visible = True
                    'cmbOpcion.Properties.View.Columns("NAME").Visible = True
                    cmbOpcion.Properties.View.BestFitColumns()
                ElseIf pPaso = "Tipo" Then
                    GridView1.Columns.Clear()
                    GridControl1.DataSource = dsPolizas.Tables(0)
                    GridControl1.RefreshDataSource()
                    'For i = 0 To GridView1.Columns.Count - 1
                    ' GridView1.Columns(i).Visible = False
                    ' Next
                    GridView1.Columns("WAREHOUSE_ID").Caption = "CODIGO"
                    'GridView1.Columns("NAME").Caption = "NOMBRE"
                    'GridView1.Columns("WAREHOUSE_ID").Visible = True
                    'GridView1.Columns("NAME").Visible = True
                    GridView1.BestFitColumns()
                End If

            Else
                MessageBox.Show("Error en el servicio : " + pResult, "Error")
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnAgregarFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarFiltro.Click
        Try
            If Not IsNothing(cmbOpcion.EditValue) Then
                Dim dr As DataRow
                dr = dtOpciones.NewRow
                dr("FILTRO") = cmbFiltro.EditValue.ToString.ToUpper
                dr("VALOR") = cmbOpcion.EditValue.ToString

                dtOpciones.Rows.Add(dr)
            Else
                MsgBox("Debe seleccionar una opcion")
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        End Try
    End Sub
    Private Sub creaTablaOpciones()
        Try
            dtOpciones = New DataTable
            dtOpciones.TableName = "FILTROS"
            Dim dc As New DataColumn
            Dim dc1 As New DataColumn
            dc.ColumnName = "FILTRO"
            dc.Caption = "Filtro"
            dc.DataType = System.Type.GetType("System.String")
            dtOpciones.Columns.Add(dc)

            dc1.ColumnName = "VALOR"
            dc1.Caption = "Valor"
            dc1.DataType = System.Type.GetType("System.String")
            dtOpciones.Columns.Add(dc1)

            dc = Nothing
            dc1 = Nothing

            GridViewFiltros.Columns.Clear()
            GridFiltros.DataSource = dtOpciones
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub GridFiltros_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridFiltros.KeyUp
        Try
            If e.KeyCode = 46 Then ' delete
                If MessageBox.Show("¿ Confirma la eliminacion de " & GridViewFiltros.GetFocusedRowCellValue("FILTRO").ToString & " ?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                    GridViewFiltros.DeleteSelectedRows()

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al borrar linea " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub obtieneUbicaciones(ByVal pOp As DataTable)
        Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
        Dim dsUbicaciones As New DataSet
        Dim dsPARAMS As New DataSet
        Try
            Cursor = Cursors.WaitCursor
            pResult = String.Empty

            dsPARAMS.Tables.Add(dtOpciones)
            dsPARAMS.Tables.Add(pOp)
            dsUbicaciones = xserv.get_locations_count(dsPARAMS, PublicLoginInfo.Environment, pResult)
            dsPARAMS.Tables.Clear()
            If pResult = "OK" Then
                GridUbicaciones.DataSource = dsUbicaciones.Tables(0)
                GridViewUbicaciones.BestFitColumns()
            Else
                MessageBox.Show("Error en el servicio : " + pResult, "Error")
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub WizardControl1_FinishClick(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControl1.FinishClick
        Try
            Cursor = Cursors.WaitCursor
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
            pResult = String.Empty
            Dim pCOUNTID As Integer = 0
            Dim dsPARAMS As New DataSet

            dsPARAMS.Tables.Add(dtOpciones)
            dsPARAMS.Tables.Add(listOp)
            xserv.set_counting(pCOUNTID, PublicLoginInfo.LoginID, rgTipoConteo.EditValue.ToString, 0, dsPARAMS, PublicLoginInfo.Environment, pResult)
            dsPARAMS.Tables.Clear()
            If pResult = "OK" Then
                MsgBox("Se creó el conteo # " + pCOUNTID.ToString)
            Else
                MsgBox("Error en el servicio: " + pResult)
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub rgTipoConteo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rgTipoConteo.SelectedIndexChanged

    End Sub

    Private Sub frmNewAudit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
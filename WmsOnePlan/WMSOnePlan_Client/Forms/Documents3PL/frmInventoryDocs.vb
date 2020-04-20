Imports System.Data
Imports System.IO
Imports DevExpress.XtraReports.UI

Public Class frmInventoryDocs
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim pResult As String = String.Empty
    Dim dsInv As New DataSet
    Private Sub btnExcel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExcel.ItemClick
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Documentos de Excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                GridView1.ExportToXlsx(SaveFileDialog1.FileName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try

            PrintableComponentLink1.ShowPreview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub fn_llena_combos()


        Try

            'llenamos las unidades de volumen
            Dim dsVolumen As New DataSet
            dsVolumen = xSettingServ.GetParam_ByParamKey("SISTEMA", "UNIDAD_VOLUMEN", "", pResult, PublicLoginInfo.Environment)
            cmbUnidadVolumen.DataSource = dsVolumen.Tables(0)
            cmbUnidadVolumen.PopulateViewColumns()
            cmbUnidadVolumen.ValueMember = "PARAM_NAME"
            cmbUnidadVolumen.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbUnidadVolumen.View.Columns.Count - 1
                cmbUnidadVolumen.View.Columns(i).Visible = False
            Next
            cmbUnidadVolumen.View.Columns("PARAM_NAME").Caption = "CODIGO"
            cmbUnidadVolumen.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbUnidadVolumen.View.Columns("PARAM_NAME").Visible = True
            cmbUnidadVolumen.View.Columns("PARAM_CAPTION").Visible = True
            cmbUnidadVolumen.View.BestFitColumns()

            'llenamos las unidades de peso
            Dim dsPeso As New DataSet
            dsPeso = xSettingServ.GetParam_ByParamKey("SISTEMA", "UNIDAD_PESO", "", pResult, PublicLoginInfo.Environment)
            cmbUNIDAD_PESO.DataSource = dsPeso.Tables(0)
            cmbUNIDAD_PESO.PopulateViewColumns()
            cmbUNIDAD_PESO.ValueMember = "PARAM_NAME"
            cmbUNIDAD_PESO.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbUNIDAD_PESO.View.Columns.Count - 1
                cmbUNIDAD_PESO.View.Columns(i).Visible = False
            Next
            cmbUNIDAD_PESO.View.Columns("PARAM_NAME").Caption = "CODIGO"
            cmbUNIDAD_PESO.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbUNIDAD_PESO.View.Columns("PARAM_NAME").Visible = True
            cmbUNIDAD_PESO.View.Columns("PARAM_CAPTION").Visible = True
            cmbUNIDAD_PESO.View.BestFitColumns()

            'llenamos las unidades de cantidad
            Dim dsQTY As New DataSet
            dsQTY = xSettingServ.GetParam_ByParamKey("SISTEMA", "UNIDAD_CANTIDAD", "", pResult, PublicLoginInfo.Environment)
            CMBUNIDADCANTIDAD.DataSource = dsQTY.Tables(0)
            CMBUNIDADCANTIDAD.PopulateViewColumns()
            CMBUNIDADCANTIDAD.ValueMember = "PARAM_NAME"
            CMBUNIDADCANTIDAD.DisplayMember = "PARAM_CAPTION"

            For i = 0 To CMBUNIDADCANTIDAD.View.Columns.Count - 1
                CMBUNIDADCANTIDAD.View.Columns(i).Visible = False
            Next
            CMBUNIDADCANTIDAD.View.Columns("PARAM_NAME").Caption = "CODIGO"
            CMBUNIDADCANTIDAD.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            CMBUNIDADCANTIDAD.View.Columns("PARAM_NAME").Visible = True
            CMBUNIDADCANTIDAD.View.Columns("PARAM_CAPTION").Visible = True
            CMBUNIDADCANTIDAD.View.BestFitColumns()

            'llenamos el combo de los acuerdos comerciales
            'Dim dsSAC As New DataSet
            'dsSAC = xSettingServ.GetParam_ByParamKey("WMS3PL", "CODIGO_SAC", "", pResult, PublicLoginInfo.Environment)
            'cmbSacCode.Properties.DataSource = dsSAC.Tables(0)
            'cmbSacCode.Properties.PopulateViewColumns()
            'cmbSacCode.Properties.ValueMember = "PARAM_NAME"
            'cmbSacCode.Properties.DisplayMember = "PARAM_CAPTION"

            'For i = 0 To cmbSacCode.Properties.View.Columns.Count - 1
            '    cmbSacCode.Properties.View.Columns(i).Visible = False
            'Next
            'cmbSacCode.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            'cmbSacCode.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            'cmbSacCode.Properties.View.Columns("PARAM_NAME").Visible = True
            'cmbSacCode.Properties.View.Columns("PARAM_CAPTION").Visible = True
            'cmbSacCode.Properties.View.BestFitColumns()

            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            cmbCLIENTE.DataSource = dsClientes.Tables(0)
            cmbCLIENTE.PopulateViewColumns()
            cmbCLIENTE.ValueMember = "CLIENT_CODE"
            cmbCLIENTE.DisplayMember = "CLIENT_NAME"

            For i = 0 To cmbCLIENTE.View.Columns.Count - 1

                cmbCLIENTE.View.Columns(i).Visible = False
            Next

            cmbCLIENTE.View.Columns("CLIENT_CODE").Caption = "CODIGO"
            cmbCLIENTE.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
            cmbCLIENTE.View.Columns("CLIENT_CODE").Visible = True
            cmbCLIENTE.View.Columns("CLIENT_NAME").Visible = True
            cmbCLIENTE.View.BestFitColumns()

        Catch ex As Exception
            MsgBox("Error al llenar combos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub frmInventoryDocs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadGridLayout("frmAInventoryDocs", PublicLoginInfo.LoginID, GridView1)

            showI()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub btnUpdate_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUpdate.ItemClick
        Me.Timer1.Enabled = IIf(Me.Timer1.Enabled, False, True)
        lblUpdate.Caption = IIf(Me.Timer1.Enabled, "Actualzacion automatica", "Actualizacion manual")
        showI()
    End Sub
    Private Sub showI()
        Try
            dsInv = xserv.get_inventory_bydocs(" WHERE VID.QTY > 0 AND VID.BULTOS > 0 ", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then

                GridControl1.DataSource = dsInv.Tables("INVENTORY_X_DOCS")
                fn_llena_combos()
                GridView1.BestFitColumns()
            Else
                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        showI()
    End Sub

    Private Sub btnPrintPolizaLabel_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrintPolizaLabel.ItemClick
        Dim Xrpt As New XtraReport_PolizaHeaderDetail
        Try
            Dim xrow As DataRow

            If GridView1.SelectedRowsCount >= 1 Then
                Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO 
                'Xrpt.DataSource = Nothing
                Xrpt.DataSource = GridControl1.DataSource
                Xrpt.DataMember = "INVENTORY_X_DOCS"
                Xrpt.FillDataSource()

                xrow = GridView1.GetFocusedDataRow
                Xrpt.FilterString = "NUMERO_ORDEN = '" + xrow("NUMERO_ORDEN") + "'"
                Xrpt.FillDataSource()

                Xrpt.ShowPreview()

            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try


    End Sub

    Private Sub GridControl1_Click(sender As System.Object, e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub btnSaveLayout_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveLayout.ItemClick
        SaveGridLayout("frmAInventoryDocs", PublicLoginInfo.LoginID, GridView1)

    End Sub
End Class
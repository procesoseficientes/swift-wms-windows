Imports System.IO
Imports System.Data
Imports System.Globalization
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports MobilityScm.Modelo.Estados
Imports DevExpress.XtraEditors.Controls

Public Class frmDocumentoEgresoFiscal
    'Declaramos la variable del servicio que esta vinculado a este form
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Public dblDoc_id As Double = 0
    Dim xdataset As New DataSet
    Dim xDataSetHead As New DataSet
    Dim xdataDocsRef As New DataSet
    Dim dsTiposDocRef As New DataSet
    Dim pResult As String = ""

    Private Impuesto As Decimal = 1

    Private Sub btnRestore_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRestore.ItemClick
        Dim strPath As String
        Try

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutEncabezado" & PublicLoginInfo.LoginID & ".xml"

            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If
            LayoutEncabezado.RestoreDefaultLayout()

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutDetalle" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If

            LayoutDetalle.RestoreDefaultLayout()

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutServicios" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If
            LayoutServicios.RestoreDefaultLayout()

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalGridDetalle" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalGridDocReferencia" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmDocumentoEgresoFiscal_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            fn_llena_combos()
        Catch ex As Exception
            MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmDocumentoEgresoFiscal_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'limpiamos los datasets
        Try
            If Not IsNothing(xdataset) Then
                xdataset.Dispose()
            End If
            If Not IsNothing(xDataSetHead) Then
                xDataSetHead.Dispose()
            End If
            If Not IsNothing(dsTiposDocRef) Then
                dsTiposDocRef.Dispose()
            End If
            If Not IsNothing(xdataDocsRef) Then
                xdataDocsRef.Dispose()
            End If

            pResult = String.Empty
        Catch ex As Exception
            MsgBox("Error al Limpiar" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmDocumentoEgresoFiscal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name
            If xdataset.HasChanges Or xDataSetHead.HasChanges Then
                If MsgBox("¿Desea Grabar los datos que ha cambiando antes de salir?", MsgBoxStyle.YesNoCancel, "Datos") = MsgBoxResult.Yes Then
                    Return
                End If
            End If
            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutEncabezado" & PublicLoginInfo.LoginID & ".xml"
            LayoutEncabezado.SaveLayoutToXml(strPath)

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutDetalle" & PublicLoginInfo.LoginID & ".xml"
            LayoutDetalle.SaveLayoutToXml(strPath)

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutServicios" & PublicLoginInfo.LoginID & ".xml"
            LayoutServicios.SaveLayoutToXml(strPath)

            'grabamos el layout del grid del detalle
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalGridDetalle" & PublicLoginInfo.LoginID & ".xml"
            GridViewDetalle.SaveLayoutToXml(strPath)


            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Private Sub frmDocumentoEgresoFiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String
        Try
            LayoutEncabezado.SetDefaultLayout()
            LayoutDetalle.SetDefaultLayout()
            LayoutServicios.SetDefaultLayout()

            'verificamos el layout de la forma
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutEncabezado" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutEncabezado.RestoreLayoutFromXml(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutDetalle" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutDetalle.RestoreLayoutFromXml(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalLayoutServicios" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutServicios.RestoreLayoutFromXml(strPath)
            End If

            'verificamos el layout de los grids
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoEgresoFiscalGridDetalle" & PublicLoginInfo.LoginID & ".xml"

            If File.Exists(strPath) Then
                GridViewDetalle.RestoreLayoutFromXml(strPath)
            End If


            strPath = String.Empty

            txtDocId.Text = dblDoc_id

            'llenamos los datos de la forma
            If dblDoc_id > 0 Then
                fn_llena_Head()

            End If

            fn_llena_detalle()

            dtFechaDocumento.EditValue = FormatDateTime(Now, DateFormat.GeneralDate)

            'Bar2.ItemLinks(0).Focus()
            'BarManager1.MainMenu.ItemLinks(1).
            LlenarListaImpuesto()
        Catch ex As Exception
            MsgBox("Error al Cargar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Private Sub fn_llena_Head()
        Try
            If Not IsNothing(xDataSetHead) Then
                If xDataSetHead.Tables.Count > 0 Then
                    If Not xDataSetHead.Tables(0).Rows.Count > 0 Then
                        xDataSetHead = xserv.get_Poliza_Header(" Where WAREHOUSE_REGIMEN = 'FISCAL'  AND TIPO = 'EGRESO' AND (DOC_ID = " & dblDoc_id.ToString() & " or NUMERO_ORDEN = '" & dblDoc_id.ToString & "')", PublicLoginInfo.Environment, pResult)
                        If pResult <> "OK" Then
                            MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                            Return
                        End If
                    End If
                Else
                    xDataSetHead = xserv.get_Poliza_Header(" Where WAREHOUSE_REGIMEN = 'FISCAL'  AND TIPO = 'EGRESO' AND (DOC_ID = " & dblDoc_id.ToString() & " or NUMERO_ORDEN = '" & dblDoc_id.ToString & "')", PublicLoginInfo.Environment, pResult)

                    If pResult <> "OK" Then
                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                        Return
                    End If
                End If
            Else
                xDataSetHead = xserv.get_Poliza_Header(" Where DOC_ID = " & dblDoc_id.ToString(), PublicLoginInfo.Environment, pResult)

                If pResult <> "OK" Then
                    MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                    Return
                End If
            End If

            If xDataSetHead.Tables(0).Rows.Count > 0 Then
                txtDocId.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOC_ID").ToString
                'FRM  24 de Nov 2012
                '-Cuando una poliza ya existe tambien debe darle valor al docid para continuar grabando items.
                dblDoc_id = CDbl(txtDocId.Text)

                txtNumeroOrden.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_ORDEN").ToString
                txtAduanaEntradaSalida.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ADUANA_ENTRADA_SALIDA").ToString
                txtNumeroDua.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_DUA").ToString
                Try
                    dtFechaAceptacion.Text = Date.ParseExact(xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_ACEPTACION_DMY").ToString, "ddMMyyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
                Catch ex As Exception
                    dtFechaAceptacion.Text = Format(Now.Date, "ddMMyyyy")
                End Try
                ' dtFechaAceptacion.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_ACEPTACION_DMY").ToString
                txtAduanaDespachoDestino.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ADUANA_DESPACHO_DESTINO").ToString
                cmbRegimenPoliza.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("REGIMEN").ToString

                txtClase.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLASE").ToString
                txtPaisProcedencia.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PAIS_PROCEDENCIA").ToString
                txtNaturalezaTrans.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NATURALEZA_TRANS").ToString
                txtDepositoFiscalZf.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DEPOSITO_FISCAL_ZF").ToString
                txtModo.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("MODO").ToString
                dtFechaDocumento.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_DOCUMENTO").ToString
                dtFechaLlegada.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_LLEGADA").ToString
                txtTipoCambio.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_CAMBIO").ToString
                txtTotalValorAduana.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_VALOR_ADUANA").ToString
                txtTotalLineas.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_NUMERO_LINEAS").ToString
                txtTotalBultos.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_BULTOS").ToString
                txtTotalPesoBrutoKg.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_PESO_BRUTO_KG").ToString
                txtTotalFobUsd.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_FOB_USD").ToString()
                txtTotalFleteUsd.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_FLETE_USD").ToString
                txtTotalSeguroUsd.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_SEGURO_USD").ToString
                txtTotalOtrosUsd.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_OTROS_USD").ToString
                txtNumeroSat.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_SAT").ToString
                txtTipoImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_IMPORTADOR").ToString
                txtIdTributariaImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ID_TRIB_IMPORTADOR").ToString
                txtPaisImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PAIS_IMPORTADOR").ToString
                txtRazonSocialImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("RAZON_SOCIAL_IMPORTADOR").ToString
                txtDomicilioImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOMICILIO_IMPORTADOR").ToString
                txtTipoRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_REPRESENTANTE").ToString
                txtIdTributariaRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ID_TRIB_REPRESENTANTE").ToString
                txtPaisRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PAIS_REPRESENTANTE").ToString
                txtTipoDeclaranteRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_DECLARANTE_REPRESENTANTE").ToString
                txtRazonSocialRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("RAZON_SOCIAL_REPRESENTANTE").ToString
                txtDomicilioRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOMICILIO_REPRESENTANTE").ToString
                txtTipoContenedor.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_CONTENEDOR").ToString
                txtNumeroContenedor.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_CONTENEDOR").ToString
                txtEntidadContenedor.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ENTIDAD_CONTENEDOR").ToString
                txtMarchamo.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_MARCHAMO_CONTENEDOR").ToString
                txtTotalLiquidar.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_LIQUIDAR").ToString
                txtTotalOtros.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_OTROS").ToString
                cmbRegimen.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("WAREHOUSE_REGIMEN").ToString

                cmbCliente.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLIENT_CODE").ToString
                cmbCliente.Properties.ValueMember = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLIENT_CODE").ToString
                txtCodigoPoliza.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CODIGO_POLIZA").ToString
                txtStatus.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("STATUS").ToString
                If xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLIENT_CODE").ToString.Length > 0 Then
                    cmbAcuerdoHead.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ACUERDO_COMERCIAL").ToString
                End If
                'cmbBodegueros.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("POLIZA_ASSIGNEDTO").ToString
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub fn_llena_detalle()
        Try

            'traemos por default del webservice los detalles de la poliza que estan asociados al documento abierto
            If Not IsNothing(xdataset) Then
                xdataset.Clear()
            End If
            If txtDocId.Text.Length > 0 Then
                xdataset = xserv.get_Poliza_Detail(" Where DOC_ID = " & txtDocId.Text, "", PublicLoginInfo.Environment, pResult)
            Else
                xdataset = xserv.get_Poliza_Detail(" Where 1 = 2 ", "", PublicLoginInfo.Environment, pResult)
            End If

            If pResult = "OK" Then
                GridDetalle.DataSource = xdataset.Tables(0)
            Else
                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
            End If

            'seteamos los elementos visuales del grid

            GridViewDetalle.BestFitColumns()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""

        End Try
    End Sub



    Private Sub fn_llena_combos()


        Try


            'llenamos el combo de los regimenes de almacen
            Dim dsRegimenAlmacen As New DataSet
            dsRegimenAlmacen = xSettingServ.GetParam_ByParamKey("WMS3PL", "WAREHOUSE_REGIMEN", "", pResult, PublicLoginInfo.Environment)
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
            'llenamos el combo de los regimenes de aduana
            Dim dsRegimen As New DataSet
            dsRegimen = xSettingServ.GetParam_ByParamKey("WMS3PL", "REGIMEN", "", pResult, PublicLoginInfo.Environment)
            cmbRegimenPoliza.Properties.DataSource = dsRegimen.Tables(0)
            cmbRegimenPoliza.Properties.PopulateViewColumns()
            cmbRegimenPoliza.Properties.ValueMember = "PARAM_NAME"
            cmbRegimenPoliza.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbRegimenPoliza.Properties.View.Columns.Count - 1
                cmbRegimenPoliza.Properties.View.Columns(i).Visible = False
            Next
            cmbRegimenPoliza.Properties.View.Columns("PARAM_NAME").Caption = "REGIMEN"
            cmbRegimenPoliza.Properties.View.Columns("PARAM_CAPTION").Caption = "REGIMEN ADUANERO"
            cmbRegimenPoliza.Properties.View.Columns("PARAM_NAME").Visible = True
            cmbRegimenPoliza.Properties.View.Columns("PARAM_CAPTION").Visible = True
            cmbRegimenPoliza.Properties.View.BestFitColumns()

            'llenamos las unidades de volumen
            Dim dsVolumen As New DataSet
            dsVolumen = xSettingServ.GetParam_ByParamKey("SISTEMA", "UNIDAD_VOLUMEN", "", pResult, PublicLoginInfo.Environment)
            cmbUnidadVolumen.Properties.DataSource = dsVolumen.Tables(0)
            cmbUnidadVolumen.Properties.PopulateViewColumns()
            cmbUnidadVolumen.Properties.ValueMember = "PARAM_NAME"
            cmbUnidadVolumen.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbUnidadVolumen.Properties.View.Columns.Count - 1
                cmbUnidadVolumen.Properties.View.Columns(i).Visible = False
            Next
            cmbUnidadVolumen.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            cmbUnidadVolumen.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbUnidadVolumen.Properties.View.Columns("PARAM_NAME").Visible = True
            cmbUnidadVolumen.Properties.View.Columns("PARAM_CAPTION").Visible = True
            cmbUnidadVolumen.Properties.View.BestFitColumns()

            'llenamos las unidades de peso
            Dim dsPeso As New DataSet
            dsPeso = xSettingServ.GetParam_ByParamKey("SISTEMA", "UNIDAD_PESO", "", pResult, PublicLoginInfo.Environment)
            cmbUnidadPeso.Properties.DataSource = dsPeso.Tables(0)
            cmbUnidadPeso.Properties.PopulateViewColumns()
            cmbUnidadPeso.Properties.ValueMember = "PARAM_NAME"
            cmbUnidadPeso.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbUnidadPeso.Properties.View.Columns.Count - 1
                cmbUnidadPeso.Properties.View.Columns(i).Visible = False
            Next
            cmbUnidadPeso.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            cmbUnidadPeso.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbUnidadPeso.Properties.View.Columns("PARAM_NAME").Visible = True
            cmbUnidadPeso.Properties.View.Columns("PARAM_CAPTION").Visible = True
            cmbUnidadPeso.Properties.View.BestFitColumns()

            'llenamos las unidades de cantidad
            Dim dsQTY As New DataSet
            dsQTY = xSettingServ.GetParam_ByParamKey("SISTEMA", "UNIDAD_CANTIDAD", "", pResult, PublicLoginInfo.Environment)
            cmbUnidadCantidad.Properties.DataSource = dsQTY.Tables(0)
            cmbUnidadCantidad.Properties.PopulateViewColumns()
            cmbUnidadCantidad.Properties.ValueMember = "PARAM_NAME"
            cmbUnidadCantidad.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbUnidadCantidad.Properties.View.Columns.Count - 1
                cmbUnidadCantidad.Properties.View.Columns(i).Visible = False
            Next
            cmbUnidadCantidad.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            cmbUnidadCantidad.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbUnidadCantidad.Properties.View.Columns("PARAM_NAME").Visible = True
            cmbUnidadCantidad.Properties.View.Columns("PARAM_CAPTION").Visible = True
            cmbUnidadCantidad.Properties.View.BestFitColumns()

            'llenamos el combo de los acuerdos comerciales
            Dim dsSAC As New DataSet
            dsSAC = xSettingServ.GetParam_ByParamKey("WMS3PL", "CODIGO_SAC", "", pResult, PublicLoginInfo.Environment)
            cmbSacCode.Properties.DataSource = dsSAC.Tables(0)
            cmbSacCode.Properties.PopulateViewColumns()
            cmbSacCode.Properties.ValueMember = "PARAM_NAME"
            cmbSacCode.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To cmbSacCode.Properties.View.Columns.Count - 1
                cmbSacCode.Properties.View.Columns(i).Visible = False
            Next
            cmbSacCode.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            cmbSacCode.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbSacCode.Properties.View.Columns("PARAM_NAME").Visible = True
            cmbSacCode.Properties.View.Columns("PARAM_CAPTION").Visible = True
            cmbSacCode.Properties.View.BestFitColumns()

            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If Not IsNothing(dsClientes) Then
                cmbCliente.Properties.DataSource = dsClientes.Tables(0)
                cmbCliente.Properties.PopulateViewColumns()
                cmbCliente.Properties.ValueMember = "CLIENT_CODE"
                cmbCliente.Properties.DisplayMember = "CLIENT_NAME"
                'llenamos el mismo combo del detalle
                cmbConsignatario.Properties.DataSource = dsClientes.Tables(0)
                cmbConsignatario.Properties.PopulateViewColumns()
                cmbConsignatario.Properties.ValueMember = "CLIENT_CODE"
                cmbConsignatario.Properties.DisplayMember = "CLIENT_NAME"

                For i = 0 To cmbCliente.Properties.View.Columns.Count - 1
                    cmbConsignatario.Properties.View.Columns(i).Visible = False
                    cmbCliente.Properties.View.Columns(i).Visible = False
                Next

                cmbCliente.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                cmbCliente.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                cmbCliente.Properties.View.Columns("CLIENT_CODE").Visible = True
                cmbCliente.Properties.View.Columns("CLIENT_NAME").Visible = True
                cmbCliente.Properties.View.BestFitColumns()
                ''seteamos lo mismo en el detalle
                cmbConsignatario.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                cmbConsignatario.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                cmbConsignatario.Properties.View.Columns("CLIENT_CODE").Visible = True
                cmbConsignatario.Properties.View.Columns("CLIENT_NAME").Visible = True
                cmbConsignatario.Properties.View.BestFitColumns()
                'LlenarComboOperador()
            End If

        Catch ex As Exception
            MsgBox("Error al llenar combos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub




    Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Try
            fn_graba_head()

            'fn_graba_Detalle()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub fn_graba_head()
        Try

            'If txtCodigoPoliza.Text.Length <= 0 Then
            '    MsgBox("Debe ingresar el codigo de poliza", MsgBoxStyle.Critical, "Error")
            '    Exit Sub
            'End If

            'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
            Dim _fechaAceptacion_dmy, _status, _codigoPoliza, _acuerdoComercial, _regimenPoliza, _regimenAlmacen As String
            Dim _fechaLlegada, _fechaDocumento As Date
            Dim _totalValorAduana, _tipoCambio, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd As Double
            Dim _totalSeguroUsd, _totalOtrosUsd, _totalLiquidar, _totalOtros, _totalGeneral As Double
            Dim _lastUpdated As Date
            Dim _docId, _numero_lineas, _modo, _totalBultos, _tipoContenedor As Integer

            'asignacion de las variables
            If cmbRegimen.EditValue = Nothing Then
                NotifyStatus("Seleccione un regimen", True, True)
                cmbRegimen.Focus()
                Return
            End If
            If dtFechaAceptacion.Text.Length > 0 Then
                _fechaAceptacion_dmy = dtFechaAceptacion.Text  'CStr(Format(dtFechaAceptacion.Text, "dd") & "/" & Format(dtFechaAceptacion.Text, "MM") & "/" & Format(dtFechaAceptacion.Text, "yyyy"))
            Else
                _fechaAceptacion_dmy = String.Empty
            End If
            If Not IsNothing(cmbAcuerdoHead.EditValue) Then
                _acuerdoComercial = cmbAcuerdoHead.EditValue

            Else
                MsgBox("Debe ingresar un acuerdo comercial", MsgBoxStyle.Information, "Error")
                cmbAcuerdoHead.Focus()
                Return
            End If
            _regimenAlmacen = cmbRegimen.EditValue.ToString
            If _regimenAlmacen = "[Seleccione Regimen...]" Or _regimenAlmacen = "" Then
                MsgBox("Debe ingresar un regimen", MsgBoxStyle.Information, "Error")
                cmbRegimen.Focus()
                Return
            End If
            _regimenPoliza = cmbRegimenPoliza.EditValue.ToString

            If _regimenPoliza = "[Seleccione Regimen...]" Or _regimenPoliza = "" Then
                MsgBox("Debe ingresar un regimen", MsgBoxStyle.Information, "Error")
                cmbRegimenPoliza.Focus()
                Return
            End If
            If dtFechaLlegada.Text.Length > 0 Then
                _fechaLlegada = dtFechaLlegada.EditValue
            Else
                MsgBox("Debe ingresar una fecha de llegada", MsgBoxStyle.Information, "Error")
                dtFechaLlegada.Focus()
                Return
            End If

            If txtStatus.Text.Length <= 0 Then
                _status = "Created"
            Else
                _status = txtStatus.Text
            End If
            If txtCodigoPoliza.Text.Length > 0 Then
                _codigoPoliza = txtCodigoPoliza.Text
            Else
                _codigoPoliza = String.Empty
            End If

            _fechaDocumento = dtFechaDocumento.EditValue

            'seteamos todos los valores numericos
            Double.TryParse(txtDocId.Text, _docId)
            Double.TryParse(txtTotalValorAduana.Text, _totalValorAduana)
            Integer.TryParse(txtTotalLineas.Text, _numero_lineas)
            Double.TryParse(txtTipoCambio.Text, _tipoCambio)
            Integer.TryParse(txtModo.Text, _modo)
            Integer.TryParse(txtTotalBultos.Text, _totalBultos)
            Double.TryParse(txtTotalPesoBrutoKg.Text, _totalPesoBrutokg)
            Double.TryParse(txtTotalFobUsd.Text, _totalFobUsd)
            Double.TryParse(txtTotalFleteUsd.Text, _totalFleteUsd)
            Double.TryParse(txtTotalSeguroUsd.Text, _totalSeguroUsd)
            Double.TryParse(txtTotalOtrosUsd.Text, _totalOtrosUsd)
            Integer.TryParse(txtTipoContenedor.Text, _tipoContenedor)
            Double.TryParse(txtTotalLiquidar.Text, _totalLiquidar)
            Double.TryParse(txtTotalOtros.Text, _totalOtros)
            Double.TryParse(txtTotalGeneral.Text, _totalGeneral)
            _lastUpdated = Date.Now()

            If cmbCliente.Text.Length <= 0 Then
                MsgBox("Error: Debe asignar un cliente al documento", MsgBoxStyle.Critical, "Error")
                Return
            End If

            If _totalBultos > 0 Then _totalBultos = -_totalBultos
            If _totalFleteUsd > 0 Then _totalFleteUsd = -_totalFleteUsd
            If _totalFobUsd > 0 Then _totalFobUsd = -_totalFobUsd
            If _totalGeneral > 0 Then _totalGeneral = -_totalGeneral
            If _totalLiquidar > 0 Then _totalLiquidar = -_totalLiquidar
            If _totalOtros > 0 Then _totalOtros = -_totalOtros
            If _totalOtrosUsd > 0 Then _totalOtrosUsd = -_totalOtrosUsd
            If _totalPesoBrutokg > 0 Then _totalPesoBrutokg = -_totalPesoBrutokg
            If _totalSeguroUsd > 0 Then _totalSeguroUsd = -_totalSeguroUsd
            If _totalValorAduana > 0 Then _totalValorAduana = -_totalValorAduana

            'grabamos el encabezado
            _docId = Val(txtDocId.Text)

            If xserv.set_Poliza_Header(txtNumeroOrden.Text, txtAduanaEntradaSalida.Text, txtNumeroDua.Text, _fechaAceptacion_dmy,
                                    txtAduanaDespachoDestino.Text, _regimenPoliza, txtClase.Text, txtPaisProcedencia.Text,
                                    txtNaturalezaTrans.Text, txtDepositoFiscalZf.Text, _modo, _fechaLlegada, _tipoCambio,
                                    _totalValorAduana, _numero_lineas, _totalBultos, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd,
                                    _totalSeguroUsd, _totalOtrosUsd, txtNumeroSat.Text, txtTipoImportador.Text, txtIdTributariaImportador.Text,
                                    txtPaisImportador.Text, txtRazonSocialImportador.Text, txtDomicilioImportador.Text, txtTipoRepresentante.Text,
                                    txtIdTributariaRepresentante.Text, txtPaisRepresentante.Text, txtTipoDeclaranteRepresentante.Text,
                                    txtRazonSocialRepresentante.Text, txtDomicilioRepresentante.Text, _tipoContenedor, txtNumeroContenedor.Text,
                                    txtEntidadContenedor.Text, txtMarchamo.Text, _totalLiquidar, _totalOtros, _totalGeneral, _codigoPoliza, PublicLoginInfo.LoginID, _lastUpdated,
                                    _status, cmbCliente.EditValue, _regimenAlmacen, _fechaDocumento, _acuerdoComercial, "EGRESO", PublicLoginInfo.Environment, pResult, _docId, "", "", IIf(switchTraslado2.EditValue, "SI", "NO"), Nothing) Then

                txtDocId.Text = _docId
                dblDoc_id = _docId

                If switchTraslado2.EditValue Then
                    'si el regimen esta en los parametros general se ingreso a almacen general

                    Dim regimen As DataSet
                    Dim result As String = String.Empty
                    regimen = xSettingServ.GetParam_ByParamKey("ALMACENAMIENTO", "TIPOS_ALMACENAJE", _regimenPoliza, result, PublicLoginInfo.Environment)

                    If Not regimen Is Nothing Then
                        If result = "OK" Then
                            If pResult = "inserted" Then
                                _docId = 0
                            Else
                                Dim dsDoc As New DataSet
                                dsDoc = xserv.get_Poliza_Header(" where CODIGO_POLIZA = '" + _codigoPoliza.ToUpper + "' AND WAREHOUSE_REGIMEN = 'GENERAL' ", PublicLoginInfo.Environment, pResult)
                                If pResult = "OK" Then
                                    If dsDoc.Tables(0).Rows.Count = 1 Then
                                        _docId = Val(dsDoc.Tables(0).Rows(0)("DOC_ID").ToString)
                                    End If
                                Else
                                    MsgBox(pResult, MsgBoxStyle.Critical, "Error")
                                End If
                            End If
                            pResult = String.Empty
                            If xserv.set_Poliza_Header(txtNumeroOrden.Text, txtAduanaEntradaSalida.Text, txtNumeroDua.Text, _fechaAceptacion_dmy,
                                           txtAduanaDespachoDestino.Text, _regimenPoliza, txtClase.Text, txtPaisProcedencia.Text,
                                           txtNaturalezaTrans.Text, txtDepositoFiscalZf.Text, _modo, _fechaLlegada, _tipoCambio,
                                           _totalValorAduana, _numero_lineas, (_totalBultos * -1), (_totalPesoBrutokg * -1), (_totalFobUsd * -1), (_totalFleteUsd * -1),
                                           _totalSeguroUsd, _totalOtrosUsd, txtNumeroSat.Text, txtTipoImportador.Text, txtIdTributariaImportador.Text,
                                           txtPaisImportador.Text, txtRazonSocialImportador.Text, txtDomicilioImportador.Text, txtTipoRepresentante.Text,
                                           txtIdTributariaRepresentante.Text, txtPaisRepresentante.Text, txtTipoDeclaranteRepresentante.Text,
                                           txtRazonSocialRepresentante.Text, txtDomicilioRepresentante.Text, _tipoContenedor, txtNumeroContenedor.Text,
                                           txtEntidadContenedor.Text, txtMarchamo.Text, (_totalLiquidar * -1), (_totalOtros * -1), (_totalGeneral * -1), _codigoPoliza, PublicLoginInfo.LoginID, _lastUpdated,
                                           _status, cmbCliente.EditValue, "GENERAL", _fechaDocumento, _acuerdoComercial, "INGRESO", PublicLoginInfo.Environment, pResult, _docId, "", "", "NO", Nothing) Then

                                gLastGeneratedDOC_ID = _docId
                                gRegimenSource = _regimenPoliza.ToUpper

                                NotifyStatus("Se ha grabado en general el ingreso " + gRegimenSource + " # " + _docId.ToString, True, False)
                            Else
                                gLastGeneratedDOC_ID = 0
                                MsgBox("error al grabar el ingreso a general " + pResult, MsgBoxStyle.Critical, "Error")
                            End If
                            _docId = dblDoc_id
                        End If
                    End If
                End If
                'If _regimenPoliza.ToUpper = "23DI" Then

                'End If
            Else
                MsgBox(pResult, MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception

            Throw New ApplicationException(ex.Message)

            ' ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub fn_graba_Detalle()
        Try
            'Validamos que hayan ingresado datos obligatorios
            If txtDescripcionSku.Text.Length <= 0 Then
                MsgBox("Debe ingresar una descripcion de articulo", MsgBoxStyle.Critical, "Error")
                txtDescripcionSku.Focus()
                Exit Sub
            End If

            'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
            Dim _numeroLinea, _documentoOrigen, _docid, _origin_line_number As Integer
            Dim _bultos, _Cantidad, _valorAduana, _valorDai, _valorIva, _pesoNeto, _volumen, _impuestosVarios, _gastosVarios, _fobUsd As Double
            Dim _fleteUsd, _seguroUsd, _pctdai As Double
            Dim _codigoSAC, _unidadCantidad, _unidadPeso, _unidadVolumen As String

            Integer.TryParse(txtNumeroLinea.Text, _numeroLinea)
            Double.TryParse(txtBultos.Text, _bultos)
            Integer.TryParse(txtDocumentoOrigen.Text, _documentoOrigen)
            Double.TryParse(txtCantidad.Text, _Cantidad)
            Double.TryParse(txtValorAduana.Text, _valorAduana)
            Double.TryParse(txtDai.Text, _valorDai)
            Double.TryParse(txtValorIva.Text, _valorIva)
            Double.TryParse(txtPesoNeto.Text, _pesoNeto)
            Double.TryParse(txtVolumen.Text, _volumen)
            Double.TryParse(txtImpuestosVarios.Text, _impuestosVarios)
            Double.TryParse(txtGastosVarios.Text, _gastosVarios)
            Double.TryParse(txtFobUsd.Text, _fobUsd)
            Double.TryParse(txtFleteUsd.Text, _fleteUsd)
            Double.TryParse(txtSeguroUsd.Text, _seguroUsd)
            Double.TryParse(pctDAI.Text, _pctdai)
            Integer.TryParse(txtDocId.Text, _docid)
            Integer.TryParse(cmbLineas.Text, _origin_line_number)


            If cmbConsignatario.EditValue = Nothing Then
                cmbConsignatario.EditValue = cmbCliente.EditValue
            End If

            If dblDoc_id > 0 And _docid = 0 Then
                _docid = dblDoc_id
            End If
            If IsNothing(cmbSacCode.EditValue) Then
                _codigoSAC = String.Empty
            Else
                _codigoSAC = cmbSacCode.EditValue
            End If
            If IsNothing(cmbUnidadCantidad.EditValue) Then
                _unidadCantidad = String.Empty
            Else
                _unidadCantidad = cmbUnidadCantidad.EditValue
            End If
            If IsNothing(cmbUnidadPeso.EditValue) Then
                _unidadPeso = String.Empty
            Else
                _unidadPeso = cmbUnidadPeso.EditValue
            End If
            If IsNothing(cmbUnidadVolumen.EditValue) Then
                _unidadVolumen = String.Empty
            Else
                _unidadVolumen = cmbUnidadVolumen.EditValue
            End If
            If IsNothing(_numeroLinea) Then
                _numeroLinea = 0
            End If
            If _bultos = 0 And _Cantidad = 0 Then
                MsgBox("debe asignar una cantidad")
                Exit Sub
            End If
            If _bultos > 0 Then _bultos = -_bultos
            If _Cantidad > 0 Then _Cantidad = -_Cantidad
            If _fleteUsd > 0 Then _fleteUsd = -_fleteUsd
            If _fobUsd > 0 Then _fobUsd = -_fobUsd
            If _gastosVarios > 0 Then _gastosVarios = -_gastosVarios
            If _impuestosVarios > 0 Then _impuestosVarios = -_impuestosVarios
            If _pesoNeto > 0 Then _pesoNeto = -_pesoNeto
            If _seguroUsd > 0 Then _seguroUsd = -_seguroUsd
            If _valorAduana > 0 Then _valorAduana = -_valorAduana
            If _valorDai > 0 Then _valorDai = -_valorDai
            If _valorIva > 0 Then _valorIva = -_valorIva
            If _volumen > 0 Then _volumen = -_volumen

            If _Cantidad = 0 Then _Cantidad = _bultos
            If _origin_line_number = 0 Then
                MsgBox("Debe especificar el numero de linea origen del ingreso a despachar")
                cmbLineas.Focus()
                Exit Sub
            End If
            If _documentoOrigen = 0 Then
                MsgBox("Debe especificar el numero de documento origen del ingreso a despachar")
                txtDocumentoOrigen.Focus()
                Exit Sub
            End If

            If xserv.set_Poliza_Detail(_docid, txtDescripcionSku.Text, _codigoSAC, _bultos, txtClaseLinea.Text, _pesoNeto, _unidadPeso, _Cantidad, _valorAduana, _unidadCantidad,
                                    _volumen, _unidadVolumen, _valorDai, _valorIva, _impuestosVarios, _fobUsd, _fleteUsd, _seguroUsd, _gastosVarios, txtPaisOrigen.Text, txtRegionCp.Text, txtAcuerdo1.Text,
                                    txtAcuerdo2.Text, txtPolizaRelacionada.Text, PublicLoginInfo.LoginID, Date.Now(), _documentoOrigen, txtPolizaOrigen.Text, cmbConsignatario.EditValue, _pctdai,
                                    _origin_line_number, PublicLoginInfo.Environment, pResult, _numeroLinea, UiListaImpuesto.EditValue, "") Then
                fn_llena_detalle()
                fn_limpia_detalle()
            Else

                Throw New ApplicationException(pResult)

            End If

        Catch ex As Exception

            Throw New ApplicationException(ex.Message)

        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If e.Page.Name = "XtraTabDetail" Then
            txtNumeroLinea.Focus()
        End If
    End Sub

    Private Sub btnAddLine_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAddLine.ItemClick
        Dim xfr As New frmEgresoFiscalAddLine
        xfr.doc_id = dblDoc_id
        xfr.ShowDialog()
        fn_limpia_detalle()
        fn_llena_detalle()

    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            If Not txtScanPoliza.EditValue Is Nothing Then
                If Not String.IsNullOrEmpty(txtScanPoliza.EditValue) Then
                    Print(txtScanPoliza.EditValue.ToString())
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Print(ByVal pCodigoPoliza As String)
        Try
            Dim rptPolEgreso As New rptEgresoFiscal
            'Dim frS As New xrptSalida
            Dim dt As DataSet
            Dim result As String = String.Empty
            Dim serverInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            dt = serverInfoTrans.GetRepPolizaFiscal(pCodigoPoliza, "FISCAL", "EGRESO", result, PublicLoginInfo.Environment)


            If result = "OK" Then
                'dt.Tables(0).TableName= "repPolEgresoFiscal"
                rptPolEgreso.DataSource = dt.Tables(0)
                rptPolEgreso.DataMember = dt.Tables(0).TableName
                rptPolEgreso.RequestParameters = False
                rptPolEgreso.Parameters("imgLogo").Value = PublicLoginInfo.LOGO
                rptPolEgreso.Parameters("prmUsuario").Value = PublicLoginInfo.LoginName
                rptPolEgreso.ShowPreview()
            Else
                MsgBox(result)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub fn_limpia_detalle()
        Try
            txtNumeroLinea.Text = 0
            txtDescripcionSku.Text = String.Empty
            txtBultos.Text = String.Empty
            txtCantidad.Text = String.Empty
            cmbUnidadCantidad.EditValue = Nothing
            txtValorAduana.Text = String.Empty
            txtDai.Text = String.Empty
            txtValorIva.Text = String.Empty
            txtClaseLinea.Text = String.Empty
            txtPesoNeto.Text = String.Empty
            cmbUnidadPeso.EditValue = Nothing
            txtVolumen.Text = String.Empty
            cmbUnidadVolumen.EditValue = Nothing
            cmbSacCode.EditValue = Nothing
            txtImpuestosVarios.Text = String.Empty
            txtGastosVarios.Text = String.Empty
            txtPaisOrigen.Text = String.Empty
            txtFobUsd.Text = String.Empty
            txtFleteUsd.Text = String.Empty
            txtSeguroUsd.Text = String.Empty
            txtRegionCp.Text = String.Empty
            txtAcuerdo1.Text = String.Empty
            txtAcuerdo2.Text = String.Empty
            txtDocumentoOrigen.Text = String.Empty
            txtActualizadaPor.Text = String.Empty
            txtActualizadaEl.Text = String.Empty
            pctDAI.Text = String.Empty
            'cmbAcuerdoComercial.EditValue = Nothing
            cmbConsignatario.EditValue = Nothing
            cmbLineas.Text = ""
            cmbLineas.Properties.Items.Clear()
            txtPolizaOrigen.Text = String.Empty


        Catch ex As Exception
            MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub fn_limpia_head()
        Try
            txtNumeroOrden.Text = String.Empty
            txtAduanaEntradaSalida.Text = String.Empty
            txtNumeroDua.Text = String.Empty
            dtFechaAceptacion.EditValue = Nothing
            txtAduanaDespachoDestino.Text = String.Empty
            cmbRegimen.EditValue = Nothing
            txtClase.Text = String.Empty
            txtPaisProcedencia.Text = String.Empty
            txtNaturalezaTrans.Text = String.Empty
            txtDepositoFiscalZf.Text = String.Empty
            txtModo.Text = String.Empty
            dtFechaLlegada.EditValue = Nothing
            txtTipoCambio.Text = String.Empty
            txtTotalValorAduana.Text = String.Empty
            txtTotalLineas.Text = String.Empty
            txtTotalBultos.Text = String.Empty
            txtTotalPesoBrutoKg.Text = String.Empty
            txtTotalFobUsd.Text = String.Empty
            txtTotalFleteUsd.Text = String.Empty
            txtTotalSeguroUsd.Text = String.Empty
            txtTotalOtrosUsd.Text = String.Empty
            txtNumeroSat.Text = String.Empty
            txtTipoImportador.Text = String.Empty
            txtIdTributariaImportador.Text = String.Empty
            txtPaisImportador.Text = String.Empty
            txtRazonSocialImportador.Text = String.Empty
            txtDomicilioImportador.Text = String.Empty
            txtTipoRepresentante.Text = String.Empty
            txtIdTributariaRepresentante.Text = String.Empty
            txtPaisRepresentante.Text = String.Empty
            txtTipoDeclaranteRepresentante.Text = String.Empty
            txtRazonSocialRepresentante.Text = String.Empty
            txtDomicilioRepresentante.Text = String.Empty
            txtTipoContenedor.Text = String.Empty
            txtNumeroContenedor.Text = String.Empty
            txtEntidadContenedor.Text = String.Empty
            txtMarchamo.Text = String.Empty
            txtTotalLiquidar.Text = String.Empty
            txtTotalOtros.Text = String.Empty
            txtTotalGeneral.Text = String.Empty
            txtCodigoPoliza.Text = String.Empty
            txtStatus.Text = String.Empty
            cmbCliente.EditValue = Nothing
            cmbRegimen.EditValue = Nothing
            cmbAcuerdoHead.EditValue = Nothing
            cmbRegimenPoliza.EditValue = Nothing
            dtFechaDocumento.EditValue = Nothing
            txtDocId.Text = String.Empty

        Catch ex As Exception
            MsgBox("Error:" & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnScan_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnScan.ItemClick
        Dim xServPol As New WMS_Polizas.WMS_PolizasSoapClient("WMS_PolizasSoap", PublicLoginInfo.WSHost + "/trans/WMS_Polizas.asmx")
        Dim dtParsePoliza As New DataSet()

        'FRM - SEP-27-2012 / COLOCAR TRY
        Try
            If Not txtScanPoliza.EditValue Is Nothing Then
                If Not String.IsNullOrEmpty(txtScanPoliza.EditValue) Then
                    If txtScanPoliza.EditValue.ToString().Length > 0 Then

                        fn_limpia_head()
                        fn_limpia_detalle()
                        xDataSetHead.Clear()
                        xdataset.Clear()
                        xdataDocsRef.Clear()

                        If Double.TryParse(txtScanPoliza.EditValue, dblDoc_id) Then
                            fn_llena_Head()
                            fn_llena_detalle()

                        Else
                            dtParsePoliza = xServPol.ParsePoliza(txtScanPoliza.EditValue, pResult)
                            If pResult = "OK" Then
                                If dtParsePoliza.Tables(0).Rows.Count > 0 Then

                                    If dtParsePoliza.Tables(0).Rows(0)("FIELD_29").ToString().Length > 0 Then
                                        xDataSetHead = xserv.get_Poliza_Header(" Where CODIGO_POLIZA = '" & dtParsePoliza.Tables(0).Rows(0)("FIELD_29").ToString() & "'", PublicLoginInfo.Environment, pResult)
                                        If pResult = "OK" Then
                                            If Not IsNothing(xDataSetHead) Then
                                                If xDataSetHead.Tables(0).Rows.Count > 0 Then
                                                    If xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CODIGO_POLIZA").ToString().Length > 0 Then
                                                        fn_llena_Head()
                                                        fn_llena_detalle()

                                                    End If

                                                Else
                                                    txtNumeroOrden.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_1")
                                                    txtNumeroDua.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_3")
                                                    'FRM - SEP-27-2012 / TRY DE FECHA
                                                    Try
                                                        dtFechaAceptacion.Text = Date.ParseExact(dtParsePoliza.Tables(0).Rows(0)("FIELD_4"), "ddMMyyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
                                                    Catch ex As Exception
                                                        dtFechaAceptacion.Text = Format(Now.Date, "ddMMyyyy")
                                                    End Try

                                                    txtAduanaEntradaSalida.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_5")
                                                    txtIdTributariaImportador.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_6")
                                                    'MsgBox(Trim(dtParsePoliza.Tables(0).Rows(0)("FIELD_8_1").ToString()), MsgBoxStyle.Information, "Advertencia")
                                                    cmbRegimenPoliza.EditValue = Trim(dtParsePoliza.Tables(0).Rows(0)("FIELD_8_1").ToString())

                                                    'FRM - OCT-05-2012 / CLIENTE DEFAULT "1"
                                                    'cmbCliente.EditValue = "1"
                                                    txtClase.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_8_2")
                                                    txtPaisProcedencia.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_9")
                                                    txtModo.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_12")
                                                    txtTipoCambio.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_15")
                                                    txtTotalValorAduana.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_16")
                                                    txtTotalPesoBrutoKg.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_20")
                                                    txtTotalFobUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_21")
                                                    txtTotalFleteUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_22")
                                                    txtTotalSeguroUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_23")
                                                    txtTotalOtrosUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_24")
                                                    txtTotalLiquidar.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_25_4")
                                                    txtTotalOtros.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_25_5")
                                                    txtCodigoPoliza.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_29")
                                                End If

                                            Else
                                                txtNumeroOrden.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_1")
                                                txtNumeroDua.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_3")
                                                'FRM - SEP-27-2012 / TRY DE FECHA
                                                Try
                                                    dtFechaAceptacion.Text = Date.ParseExact(dtParsePoliza.Tables(0).Rows(0)("FIELD_4"), "ddMMyyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
                                                Catch ex As Exception
                                                    dtFechaAceptacion.Text = Format(Now.Date, "ddMMyyyy")
                                                End Try
                                                'dtFechaAceptacion.Text = Date.ParseExact(dtParsePoliza.Tables(0).Rows(0)("FIELD_4"), "ddMMyyyy", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat)
                                                'FRM - OCT-05-2012 / CLIENTE DEFAULT "1"
                                                cmbCliente.EditValue = "1"
                                                txtAduanaEntradaSalida.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_5")
                                                txtIdTributariaImportador.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_6")
                                                cmbRegimenPoliza.EditValue = Trim(dtParsePoliza.Tables(0).Rows(0)("FIELD_8_1").ToString())
                                                txtClase.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_8_2")
                                                txtPaisProcedencia.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_9")
                                                txtModo.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_12")
                                                txtTipoCambio.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_15")
                                                txtTotalValorAduana.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_16")
                                                txtTotalPesoBrutoKg.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_20")
                                                txtTotalFobUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_21")
                                                txtTotalFleteUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_22")
                                                txtTotalSeguroUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_23")
                                                txtTotalOtrosUsd.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_24")
                                                txtTotalLiquidar.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_25_4")
                                                txtTotalOtros.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_25_5")
                                                txtCodigoPoliza.Text = dtParsePoliza.Tables(0).Rows(0)("FIELD_29")
                                            End If
                                        End If

                                        txtScanPoliza.EditValue = String.Empty
                                        If IsNothing(dtFechaLlegada.EditValue) Then
                                            dtFechaLlegada.EditValue = Date.Now
                                        End If
                                    Else

                                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                                    End If
                                End If
                            Else

                                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "WMS OnePlan", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub GridViewDetalle_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridViewDetalle.FocusedRowChanged
        Try
            If Not e.FocusedRowHandle = DevExpress.XtraGrid.GridControl.AutoFilterRowHandle Then
                If Not IsNothing(xdataset) Then
                    If xdataset.Tables.Count > 0 Then
                        If xdataset.Tables(0).Rows.Count > 0 Then
                            If GridViewDetalle.SelectedRowsCount > 0 Then
                                txtNumeroLinea.Text = GridViewDetalle.GetFocusedRowCellValue("LINE_NUMBER").ToString
                                txtDescripcionSku.Text = GridViewDetalle.GetFocusedRowCellValue("SKU_DESCRIPTION").ToString
                                txtBultos.Text = GridViewDetalle.GetFocusedRowCellValue("BULTOS").ToString
                                txtValorAduana.Text = GridViewDetalle.GetFocusedRowCellValue("CUSTOMS_AMOUNT").ToString
                                txtDai.Text = GridViewDetalle.GetFocusedRowCellValue("DAI").ToString
                                txtValorIva.Text = GridViewDetalle.GetFocusedRowCellValue("IVA").ToString
                                txtCantidad.Text = GridViewDetalle.GetFocusedRowCellValue("QTY").ToString
                                If GridViewDetalle.GetFocusedRowCellValue("QTY_UNIT").ToString.Length > 0 Then
                                    cmbUnidadCantidad.EditValue = GridViewDetalle.GetFocusedRowCellValue("QTY_UNIT").ToString
                                End If
                                txtClaseLinea.Text = GridViewDetalle.GetFocusedRowCellValue("CLASE").ToString
                                txtPesoNeto.Text = GridViewDetalle.GetFocusedRowCellValue("NET_WEIGTH").ToString
                                If GridViewDetalle.GetFocusedRowCellValue("WEIGTH_UNIT").ToString.Length > 0 Then
                                    cmbUnidadPeso.EditValue = GridViewDetalle.GetFocusedRowCellValue("WEIGTH_UNIT").ToString
                                End If
                                txtVolumen.Text = GridViewDetalle.GetFocusedRowCellValue("VOLUME").ToString
                                If GridViewDetalle.GetFocusedRowCellValue("VOLUME_UNIT").ToString.Length > 0 Then
                                    cmbUnidadVolumen.EditValue = GridViewDetalle.GetFocusedRowCellValue("VOLUME_UNIT").ToString
                                End If
                                If GridViewDetalle.GetFocusedRowCellValue("SAC_CODE").ToString.Length > 0 Then
                                    cmbSacCode.EditValue = GridViewDetalle.GetFocusedRowCellValue("SAC_CODE").ToString
                                End If
                                txtImpuestosVarios.Text = GridViewDetalle.GetFocusedRowCellValue("MISC_TAXES").ToString
                                txtGastosVarios.Text = GridViewDetalle.GetFocusedRowCellValue("MISC_EXPENSES").ToString
                                txtPaisOrigen.Text = GridViewDetalle.GetFocusedRowCellValue("ORIGIN_COUNTRY").ToString
                                txtFobUsd.Text = GridViewDetalle.GetFocusedRowCellValue("FOB_USD").ToString
                                txtFleteUsd.Text = GridViewDetalle.GetFocusedRowCellValue("FREIGTH_USD").ToString
                                txtSeguroUsd.Text = GridViewDetalle.GetFocusedRowCellValue("INSURANCE_USD").ToString
                                txtRegionCp.Text = GridViewDetalle.GetFocusedRowCellValue("REGION_CP").ToString
                                txtAcuerdo1.Text = GridViewDetalle.GetFocusedRowCellValue("AGREEMENT_1").ToString
                                txtAcuerdo2.Text = GridViewDetalle.GetFocusedRowCellValue("AGREEMENT_2").ToString
                                txtPolizaRelacionada.Text = GridViewDetalle.GetFocusedRowCellValue("RELATED_POLIZA").ToString
                                txtActualizadaEl.Text = GridViewDetalle.GetFocusedRowCellValue("LAST_UPDATED").ToString
                                txtActualizadaPor.Text = GridViewDetalle.GetFocusedRowCellValue("LAST_UPDATED_BY").ToString
                                txtDocumentoOrigen.Text = GridViewDetalle.GetFocusedRowCellValue("ORIGIN_DOC_ID").ToString
                                txtPolizaOrigen.Text = GridViewDetalle.GetFocusedRowCellValue("CODIGO_POLIZA_ORIGEN").ToString
                                pctDAI.Text = Val(GridViewDetalle.GetFocusedRowCellValue("PCTDAI").ToString)
                                'cambio
                                cmbLineas.Text = GridViewDetalle.GetFocusedRowCellValue("ORIGIN_LINE_NUMBER").ToString
                                If GridViewDetalle.GetFocusedRowCellValue("CLIENT_CODE").ToString.Length > 0 Then
                                    cmbConsignatario.EditValue = GridViewDetalle.GetFocusedRowCellValue("CLIENT_CODE").ToString
                                End If
                                txtOrigenNumOrden.Text = Val(GridViewDetalle.GetFocusedRowCellValue("NUMEROODERORIGEN").ToString)
                                If IsDBNull(GridViewDetalle.GetFocusedRowCellValue("TAX")) Then
                                    UiListaImpuesto.EditValue = CType(UiListaImpuesto.Properties.DataSource, DataTable).Rows(0)("MONEY_VALUE")
                                Else
                                    UiListaImpuesto.EditValue = GridViewDetalle.GetFocusedRowCellValue("TAX")
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error en doble click de grid " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub btnClean_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClean.ItemClick
        Try
            If XtraTabControl1.SelectedTabPage.Name = "XtraTabDetail" Then
                fn_limpia_detalle()
                Me.txtDescripcionSku.Focus()
            End If
            If XtraTabControl1.SelectedTabPage.Name = "XtraTabHead" Then
                fn_limpia_head()
                fn_limpia_detalle()

                fn_llena_detalle()

            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub cmbCliente_EditValueChanged(ByVal sender As System.Object, ByVal e As ChangingEventArgs) Handles cmbCliente.EditValueChanged

        Try
            Dim rowCliente As DataRowView
            If e.NewValue.GetType().Name = "DataRowView" Then
                rowCliente = e.NewValue
                cmbCliente.EditValue = rowCliente.Item(0)
            End If

            If cmbCliente.EditValue = "" Then
                Return
            End If

            Dim dsTerms As New DataSet
            Dim dsCT As New DataSet
            Dim xct As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            If Not IsNothing(cmbCliente.EditValue) Then
                If cmbCliente.EditValue.ToString.Length > 0 Then
                    pResult = String.Empty
                    dsCT = xct.GetClient_CommercialAggrements(cmbCliente.EditValue.ToString, pResult, PublicLoginInfo.Environment)
                    If pResult = "OK" Then
                        If dsCT.Tables(0).Rows.Count > 0 Then
                            'llenamos el combo de los acuerdos comerciales
                            cmbAcuerdoHead.Properties.DataSource = dsCT.Tables(0)
                            cmbAcuerdoHead.Properties.PopulateViewColumns()
                            cmbAcuerdoHead.Properties.ValueMember = "ACUERDO_COMERCIAL"
                            cmbAcuerdoHead.Properties.DisplayMember = "DESCRIPCION"

                            cmbAcuerdoHead.Properties.View.Columns("CLIENT_CODE").Visible = False
                            cmbAcuerdoHead.Properties.View.BestFitColumns()

                            'cmbAcuerdoComercial.Properties.DataSource = dsCT.Tables(0)
                            'cmbAcuerdoComercial.Properties.PopulateViewColumns()
                            'cmbAcuerdoComercial.Properties.ValueMember = "ACUERDO_COMERCIAL"
                            'cmbAcuerdoComercial.Properties.DisplayMember = "DESCRIPCION"

                            'cmbAcuerdoComercial.Properties.View.Columns("CLIENT_CODE").Visible = False
                            'cmbAcuerdoComercial.Properties.View.BestFitColumns()

                            'seteamos el acuerdo por default
                            dsTerms = xserv.get_cust_term_of_trade(cmbCliente.EditValue, PublicLoginInfo.Environment, pResult)
                            If pResult = "OK" Then
                                If dsTerms.Tables(0).Rows.Count > 0 Then
                                    If dsTerms.Tables(0).Rows(0)("CLIENT_CA").ToString.Length > 0 Then
                                        'cmbAcuerdoComercial.EditValue = dsTerms.Tables(0).Rows(0)("CLIENT_CA").ToString
                                        cmbAcuerdoHead.EditValue = dsTerms.Tables(0).Rows(0)("CLIENT_CA").ToString

                                    End If
                                End If
                                pResult = String.Empty
                            Else

                                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                                pResult = String.Empty
                            End If

                            If Not IsNothing(cmbCliente.EditValue) Then
                                If cmbCliente.EditValue.ToString.Length > 0 Then

                                    'llenamos el combo de los productos por cliente
                                    Dim dsMAT As New DataSet
                                    dsMAT = xserv.get_cust_skus(cmbCliente.EditValue, PublicLoginInfo.Environment, pResult)
                                    If pResult = "OK" Then
                                        For i = 0 To dsMAT.Tables(0).Rows.Count - 1
                                            txtDescripcionSku.Properties.Items.Add(dsMAT.Tables("OP_WMS_MATERIALS").Rows(i)("BARCODE_ID").ToString & " - " & dsMAT.Tables("OP_WMS_MATERIALS").Rows(i)("MATERIAL_NAME").ToString)
                                        Next
                                        pResult = String.Empty
                                    Else

                                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                                        pResult = String.Empty
                                    End If
                                End If
                            End If

                        Else
                            MsgBox("El cliente no posee acuerdos comerciales")
                            cmbCliente.EditValue = Nothing
                        End If
                    Else
                        MsgBox(pResult)
                        cmbCliente.EditValue = Nothing
                    End If
                End If
            End If



        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub txtValorAduana_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValorAduana.GotFocus
        txtValorAduana.SelectionStart = 0
        txtValorAduana.SelectionLength = Len(txtValorAduana.Text)

    End Sub

    Private Sub txtDescripcionSku_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcionSku.KeyPress
        If e.KeyChar = ChrW(13) Then
            Me.txtValorAduana.Text = "0.00"
            Me.txtValorAduana.SelectAll()
            Me.txtValorAduana.Focus()
        End If
    End Sub
    Private Sub GridDetalle_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridDetalle.KeyUp
        Try
            If e.KeyCode = 46 Then ' delete
                If MessageBox.Show("¿ Confirma la eliminacion de " & GridViewDetalle.GetFocusedRowCellValue("SKU_DESCRIPTION").ToString & " ?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                    xserv.del_POLIZA_LINE(Val(GridViewDetalle.GetFocusedRowCellValue("DOC_ID")), Val(GridViewDetalle.GetFocusedRowCellValue("LINE_NUMBER")), PublicLoginInfo.Environment, pResult)
                    If pResult = "OK" Then
                        fn_limpia_detalle()
                        fn_llena_detalle()

                    Else
                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al borrar linea " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub GridViewDetalle_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridViewDetalle.GotFocus
        Try

            If Not IsNothing(xdataset) Then
                If xdataset.Tables.Count > 0 Then
                    If xdataset.Tables(0).Rows.Count > 0 Then
                        If GridViewDetalle.SelectedRowsCount > 0 Then
                            txtNumeroLinea.Text = GridViewDetalle.GetFocusedRowCellValue("LINE_NUMBER").ToString
                            txtDescripcionSku.Text = GridViewDetalle.GetFocusedRowCellValue("SKU_DESCRIPTION").ToString
                            txtBultos.Text = GridViewDetalle.GetFocusedRowCellValue("BULTOS").ToString
                            txtValorAduana.Text = GridViewDetalle.GetFocusedRowCellValue("CUSTOMS_AMOUNT").ToString
                            txtDai.Text = GridViewDetalle.GetFocusedRowCellValue("DAI").ToString
                            txtValorIva.Text = GridViewDetalle.GetFocusedRowCellValue("IVA").ToString
                            txtCantidad.Text = GridViewDetalle.GetFocusedRowCellValue("QTY").ToString
                            If GridViewDetalle.GetFocusedRowCellValue("QTY_UNIT").ToString.Length > 0 Then
                                cmbUnidadCantidad.EditValue = GridViewDetalle.GetFocusedRowCellValue("QTY_UNIT").ToString
                            End If
                            txtClaseLinea.Text = GridViewDetalle.GetFocusedRowCellValue("CLASE").ToString
                            txtPesoNeto.Text = GridViewDetalle.GetFocusedRowCellValue("NET_WEIGTH").ToString
                            If GridViewDetalle.GetFocusedRowCellValue("WEIGTH_UNIT").ToString.Length > 0 Then
                                cmbUnidadPeso.EditValue = GridViewDetalle.GetFocusedRowCellValue("WEIGTH_UNIT").ToString
                            End If
                            txtVolumen.Text = GridViewDetalle.GetFocusedRowCellValue("VOLUME").ToString
                            If GridViewDetalle.GetFocusedRowCellValue("VOLUME_UNIT").ToString.Length > 0 Then
                                cmbUnidadVolumen.EditValue = GridViewDetalle.GetFocusedRowCellValue("VOLUME_UNIT").ToString
                            End If
                            If GridViewDetalle.GetFocusedRowCellValue("SAC_CODE").ToString.Length > 0 Then
                                cmbSacCode.EditValue = GridViewDetalle.GetFocusedRowCellValue("SAC_CODE").ToString
                            End If
                            'CODIGO_POLIZA_ORIGEN
                            txtImpuestosVarios.Text = GridViewDetalle.GetFocusedRowCellValue("MISC_TAXES").ToString
                            txtGastosVarios.Text = GridViewDetalle.GetFocusedRowCellValue("MISC_EXPENSES").ToString
                            txtPaisOrigen.Text = GridViewDetalle.GetFocusedRowCellValue("ORIGIN_COUNTRY").ToString
                            txtFobUsd.Text = GridViewDetalle.GetFocusedRowCellValue("FOB_USD").ToString
                            txtFleteUsd.Text = GridViewDetalle.GetFocusedRowCellValue("FREIGTH_USD").ToString
                            txtSeguroUsd.Text = GridViewDetalle.GetFocusedRowCellValue("INSURANCE_USD").ToString
                            txtRegionCp.Text = GridViewDetalle.GetFocusedRowCellValue("REGION_CP").ToString
                            txtAcuerdo1.Text = GridViewDetalle.GetFocusedRowCellValue("AGREEMENT_1").ToString
                            txtAcuerdo2.Text = GridViewDetalle.GetFocusedRowCellValue("AGREEMENT_2").ToString
                            txtPolizaRelacionada.Text = GridViewDetalle.GetFocusedRowCellValue("RELATED_POLIZA").ToString
                            txtActualizadaEl.Text = GridViewDetalle.GetFocusedRowCellValue("LAST_UPDATED").ToString
                            txtActualizadaPor.Text = GridViewDetalle.GetFocusedRowCellValue("LAST_UPDATED_BY").ToString
                            txtDocumentoOrigen.Text = GridViewDetalle.GetFocusedRowCellValue("ORIGIN_DOC_ID").ToString
                            txtPolizaOrigen.Text = GridViewDetalle.GetFocusedRowCellValue("CODIGO_POLIZA_ORIGEN").ToString
                            pctDAI.Text = Val(GridViewDetalle.GetFocusedRowCellValue("PCTDAI").ToString)
                            If GridViewDetalle.GetFocusedRowCellValue("CLIENT_CODE").ToString.Length > 0 Then
                                cmbConsignatario.EditValue = GridViewDetalle.GetFocusedRowCellValue("CLIENT_CODE").ToString
                            End If
                            If IsDBNull(GridViewDetalle.GetFocusedRowCellValue("TAX")) Then
                                UiListaImpuesto.EditValue = CType(UiListaImpuesto.Properties.DataSource, DataTable).Rows(0)("MONEY_VALUE")
                            Else
                                UiListaImpuesto.EditValue = GridViewDetalle.GetFocusedRowCellValue("TAX")
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox("Error en doble click de grid " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbRegimenPoliza_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegimenPoliza.EditValueChanged
        Try
            If Not IsNothing(cmbRegimenPoliza.EditValue) Then
                'If cmbRegimenPoliza.Properties.View.RowCount > 0 Then

                If cmbRegimenPoliza.EditValue.ToString.Length > 0 Then
                    Dim dsREGIME As DataSet

                    dsREGIME = xSettingServ.GetParam_ByParamKey("WMS3PL", "REGIMEN", cmbRegimenPoliza.EditValue.ToString, pResult, PublicLoginInfo.Environment)

                    If pResult = "OK" Then
                        If Not IsNothing(dsREGIME) Then
                            If dsREGIME.Tables(0).Rows.Count = 1 Then
                                cmbRegimen.EditValue = dsREGIME.Tables(0).Rows(0)("TEXT_VALUE").ToString
                            End If
                        End If
                    Else
                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                    End If
                End If
                'End If
            End If
        Catch ex As Exception
            MsgBox("Error al borrar linea " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub cmbAcuerdoHead_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAcuerdoHead.EditValueChanged
        'Try
        '    If cmbAcuerdoHead.Properties.View.RowCount > 0 Then
        '        If cmbAcuerdoHead.EditValue.ToString.Length > 0 Then
        '            cmbAcuerdoComercial.EditValue = cmbAcuerdoHead.EditValue
        '        End If
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub pctDAI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctDAI.Validated

    End Sub

    Private Sub pctDAI_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctDAI.EditValueChanged
        Try
            If Val(txtValorAduana.Text) > 0 Then
                If Val(pctDAI.Text) > 0 Then
                    txtDai.Text = txtValorAduana.Text * (pctDAI.Text / 100)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtDai_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDai.EditValueChanged
        Try
            If Val(txtValorAduana.Text) > 0 Then
                If Val(txtDai.Text) > 0 Then
                    txtValorIva.Text = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12
                Else
                    txtValorIva.Text = CDbl(txtValorAduana.Text) * Impuesto '0.12
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtValorAduana_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorAduana.EditValueChanged
        Try
            If Val(txtValorAduana.Text) > 0 Then
                If Val(txtDai.Text) > 0 Then
                    txtValorIva.Text = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12
                Else
                    txtValorIva.Text = CDbl(txtValorAduana.Text) * Impuesto '0.12
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dtFechaLlegada_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtFechaLlegada.EditValueChanged
        Try
            If Not IsNothing(dtFechaLlegada.EditValue) Then
                If dtFechaLlegada.EditValue.ToString.Length > 0 Then
                    If IsNothing(dtFechaDocumento.EditValue) Then
                        dtFechaDocumento.EditValue = dtFechaLlegada.EditValue
                    Else
                        If dtFechaDocumento.EditValue.ToString.Length = 0 Then
                            dtFechaDocumento.EditValue = dtFechaLlegada.EditValue
                        End If
                    End If

                    If IsNothing(dtFechaAceptacion.EditValue) Then
                        dtFechaAceptacion.EditValue = dtFechaLlegada.EditValue
                    Else
                        If dtFechaAceptacion.EditValue.ToString.Length = 0 Then
                            dtFechaAceptacion.EditValue = dtFechaLlegada.EditValue
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSaveChanges_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSaveChanges.ItemClick
        Try

            fn_graba_Detalle()

            'FRM - SEP-27-2012 / FOCUS
            txtDescripcionSku.Focus()
            txtDescripcionSku.SelectionStart = 0
            txtDescripcionSku.SelectionLength = Len(txtDescripcionSku.Text)

            txtValorAduana.SelectionStart = 0
            txtValorAduana.SelectionLength = Len(txtValorAduana.Text)


        Catch ex As Exception
            MsgBox("Error : " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Private Sub LlenarComboOperador()
    '    Try
    '        Dim xSecurity As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_Security.asmx")
    '        Dim dsUsuarios As New DataSet
    '        dsUsuarios = xSecurity.SearchOperators(pResult, PublicLoginInfo.Environment)
    '        If pResult = "OK" Then
    '            If Not IsNothing(dsUsuarios) Then
    '                cmbBodegueros.Properties.DataSource = dsUsuarios.Tables(0)
    '                cmbBodegueros.Properties.PopulateViewColumns()
    '                cmbBodegueros.Properties.ValueMember = "LOGIN_ID"
    '                cmbBodegueros.Properties.DisplayMember = "LOGIN_NAME"

    '                For i = 0 To cmbBodegueros.Properties.View.Columns.Count - 1
    '                    cmbBodegueros.Properties.View.Columns(i).Visible = False
    '                Next
    '                cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Caption = "NOMBRE"
    '                cmbBodegueros.Properties.View.Columns("LOGIN_ID").Caption = "USUARIO"
    '                cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Visible = True
    '                cmbBodegueros.Properties.View.Columns("LOGIN_ID").Visible = True
    '            End If
    '        Else
    '            MsgBox(pResult)
    '        End If

    '        cmbBodegueros.EditValue = "1"
    '    Catch ex As Exception
    '        NotifyStatus(ex.Message, True, True)
    '    End Try
    'End Sub

    Private Sub txtDocumentoOrigen_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPolizaOrigen.KeyUp, txtOrigenNumOrden.KeyUp, txtDocumentoOrigen.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Not String.IsNullOrEmpty(CType(sender, ButtonEdit).Text) Then
                If CType(sender, ButtonEdit).Name.Equals("txtDocumentoOrigen") Then
                    If IsNumeric(txtDocumentoOrigen.Text) Then
                        GetDocOrigen(txtDocumentoOrigen.Text, "", "")
                    End If
                ElseIf CType(sender, ButtonEdit).Name.Equals("txtPolizaOrigen") Then
                    GetDocOrigen(0, txtPolizaOrigen.Text, "")
                ElseIf CType(sender, ButtonEdit).Name.Equals("txtOrigenNumOrden") Then
                    GetDocOrigen(0, "", txtOrigenNumOrden.Text)
                End If
            End If
        Else
            cmbLineas.Text = ""
            cmbLineas.Properties.Items.Clear()
        End If
    End Sub

    Private Sub GetDocOrigen(ByVal pDocId As Integer, ByVal pCodigoPoliza As String, ByVal pNumeroOrden As String)
        Try
            Dim result As String = ""
            Dim servInfTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim dt As DataSet
            dt = servInfTrans.GetDocPolizaEnc(pDocId, pCodigoPoliza, pNumeroOrden, result, PublicLoginInfo.Environment)
            If result = "OK" Then
                If dt.Tables(0).Rows(0)("IS_BLOCKED") = SiNo.Si Then
                    txtDocumentoOrigen.Text = ""
                    txtPolizaOrigen.Text = ""
                    txtOrigenNumOrden.Text = ""
                    NotifyStatus("ERROR: La póliza se encuentra bloqueada.", False, True)
                    Return
                End If
                txtDocumentoOrigen.Text = dt.Tables(0).Rows(0)("DOC_ID")
                txtPolizaOrigen.Text = dt.Tables(0).Rows(0)("CODIGO_POLIZA")
                txtOrigenNumOrden.Text = dt.Tables(0).Rows(0)("NUMERO_ORDEN")
                result = ""
                dt = servInfTrans.GetLineasAvailable(Integer.Parse(dt.Tables(0).Rows(0)("DOC_ID").ToString()), result, PublicLoginInfo.Environment)
                cmbLineas.Text = ""
                cmbLineas.Properties.Items.Clear()
                If result = "OK" Then
                    For Each row As DataRow In dt.Tables(0).Rows
                        cmbLineas.Properties.Items.Add(row(0).ToString())

                    Next
                    cmbLineas.SelectedIndex = 0
                Else
                    NotifyStatus(result, False, True)
                End If
            Else
                txtDocumentoOrigen.Text = ""
                txtPolizaOrigen.Text = ""
                txtOrigenNumOrden.Text = ""
                NotifyStatus(result, False, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub txtDocumentoOrigen_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtDocumentoOrigen.ButtonClick, txtPolizaOrigen.ButtonClick, txtOrigenNumOrden.ButtonClick
        If Not String.IsNullOrEmpty(CType(sender, ButtonEdit).Text) Then
            If CType(sender, ButtonEdit).Name.Equals("txtDocumentoOrigen") Then
                If IsNumeric(txtDocumentoOrigen.Text) Then
                    GetDocOrigen(txtDocumentoOrigen.Text, "", "")
                End If
            ElseIf CType(sender, ButtonEdit).Name.Equals("txtPolizaOrigen") Then
                GetDocOrigen(0, txtPolizaOrigen.Text, "")
            ElseIf CType(sender, ButtonEdit).Name.Equals("txtOrigenNumOrden") Then
                GetDocOrigen(0, "", txtOrigenNumOrden.Text)
            End If
        End If
    End Sub

    Private Sub LlenarListaImpuesto()
        Try
            Dim ds As New DataSet
            ds = xSettingServ.GetParam_ByParamKey("INGRESOS", "IMPUESTO_FISCAL", "", pResult, PublicLoginInfo.Environment)

            If ds.Tables(0).Rows.Count = 0 Then
                Dim filaNueva As DataRow
                filaNueva = ds.Tables(0).NewRow()
                filaNueva("PARAM_CAPTION") = "Impuesto 0.12%"
                filaNueva("MONEY_VALUE") = 0.12
                ds.Tables(0).Rows.Add(filaNueva)
            End If
            UiListaImpuesto.Properties.DataSource = ds.Tables(0)
            UiListaImpuesto.EditValue = ds.Tables(0).Rows(0)("MONEY_VALUE")

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiListaImpuesto_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaImpuesto.EditValueChanged
        Impuesto = IIf(UiListaImpuesto.EditValue Is Nothing, 1, UiListaImpuesto.EditValue)

        If String.IsNullOrEmpty(txtValorAduana.Text) Then
            Return
        End If

        If Val(txtValorAduana.Text) > 0 Then
            If Val(txtDai.Text) > 0 Then
                txtValorIva.Text = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12
            Else
                txtValorIva.Text = CDbl(txtValorAduana.Text) * Impuesto '0.12
            End If
        End If

        If Val(txtValorAduana.Text) > 0 Then
            If Val(txtDai.Text) > 0 Then
                txtValorIva.Text = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12
            Else
                txtValorIva.Text = CDbl(txtValorAduana.Text) * Impuesto '0.12
            End If
        End If
    End Sub
End Class
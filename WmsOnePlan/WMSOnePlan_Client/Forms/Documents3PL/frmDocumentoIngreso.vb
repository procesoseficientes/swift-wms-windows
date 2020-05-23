Imports System.IO
Imports System.Data
Imports System.Globalization
Imports DevExpress.XtraBars
Imports DevExpress.XtraGrid.Views.Base
Imports WMSOnePlan_Client.OnePlanServices_Clients
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports WMSOnePlan_Client.OnePlanServices_Security
Imports MobilityScm.Modelo.Tipos

Public Class frmDocumentoIngreso
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

    Dim pendienteRectificacion As Integer = 0
    Dim codigoPolizaRectificacion As String = ""
    Dim comentarioRectificado As String = ""
    Dim clasePolizaRectificacion As String = ""
    Dim docIdRectificacion As Integer = 0
    Dim comentarioRectificacion As String = ""

    Private Impuesto As Decimal = 1

    Private Sub btnRestore_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRestore.ItemClick
        Dim strPath As String
        Try

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutEncabezado" & PublicLoginInfo.LoginID & ".xml"

            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If
            LayoutEncabezado.RestoreDefaultLayout()

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutDetalle" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If

            LayoutDetalle.RestoreDefaultLayout()

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutServicios" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If
            LayoutServicios.RestoreDefaultLayout()

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGridDetalle" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGridDocReferencia" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmDocumentoIngreso_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Try
            fn_llena_combos()

        Catch ex As Exception
            MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub frmDocumentoIngreso_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
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

    Private Sub frmDocumentoIngreso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutEncabezado" & PublicLoginInfo.LoginID & ".xml"
            LayoutEncabezado.SaveLayoutToXml(strPath)

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutDetalle" & PublicLoginInfo.LoginID & ".xml"
            LayoutDetalle.SaveLayoutToXml(strPath)

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutServicios" & PublicLoginInfo.LoginID & ".xml"
            LayoutServicios.SaveLayoutToXml(strPath)

            'grabamos el layout del grid del detalle
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGridDetalle" & PublicLoginInfo.LoginID & ".xml"
            GridViewDetalle.SaveLayoutToXml(strPath)

            'grabamos el layout del grid del detalle
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGridDocReferencia" & PublicLoginInfo.LoginID & ".xml"
            GridViewDocReferencia.SaveLayoutToXml(strPath)

            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmDocumentoIngreso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strPath As String
        Try
            LayoutEncabezado.SetDefaultLayout()
            LayoutDetalle.SetDefaultLayout()
            LayoutServicios.SetDefaultLayout()

            'verificamos el layout de la forma
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutEncabezado" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutEncabezado.RestoreLayoutFromXml(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutDetalle" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutDetalle.RestoreLayoutFromXml(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoLayoutServicios" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                LayoutServicios.RestoreLayoutFromXml(strPath)
            End If

            'verificamos el layout de los grids
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGridDetalle" & PublicLoginInfo.LoginID & ".xml"

            If File.Exists(strPath) Then
                GridViewDetalle.RestoreLayoutFromXml(strPath)
            End If

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmDocumentoIngresoGridDocReferencia" & PublicLoginInfo.LoginID & ".xml"

            If File.Exists(strPath) Then
                GridViewDocReferencia.RestoreLayoutFromXml(strPath)
            End If

            'Verificamos si se muestra el campo de ticket
            If ValidateEnterTicket() Then
                Me.layoutTicketFiscal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                Me.layoutTicketFiscal.ContentVisible = True
            Else
                Me.layoutTicketFiscal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                Me.layoutTicketFiscal.ContentVisible = False
            End If

            strPath = String.Empty

            txtDocId.Text = dblDoc_id

            'llenamos los datos de la forma
            If dblDoc_id > 0 Then
                fn_llena_Head()
            End If

            fn_llena_detalle()

            fn_llena_docs_ref()

            dtFechaDocumento.EditValue = FormatDateTime(Now, DateFormat.GeneralDate)
            Dim xitem As DevExpress.XtraBars.BarEditItemLink
            xitem = Bar2.ItemLinks(0)

            UIBotonRectificar.Visibility = BarItemVisibility.Never
            UIBotonRectificacion.Visibility = BarItemVisibility.Never
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
                        xDataSetHead = xserv.get_Poliza_Header(" Where WAREHOUSE_REGIMEN = 'FISCAL'  AND TIPO = 'INGRESO' AND (DOC_ID = " & dblDoc_id.ToString() & " or NUMERO_ORDEN = '" & dblDoc_id.ToString & "')", PublicLoginInfo.Environment, pResult)
                        If pResult <> "OK" Then
                            MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                            Return
                        End If
                    End If
                Else
                    xDataSetHead = xserv.get_Poliza_Header(" Where WAREHOUSE_REGIMEN = 'FISCAL'  AND TIPO = 'INGRESO' AND (DOC_ID = " & dblDoc_id.ToString() & " or NUMERO_ORDEN = '" & dblDoc_id.ToString & "')", PublicLoginInfo.Environment, pResult)

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
                cmbPolizaAsegurada.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("POLIZA_ASEGURADA").ToString
                cmbBodegueros.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("POLIZA_ASSIGNEDTO").ToString

                pendienteRectificacion = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PENDIENTE_RECTIFICACION").ToString
                codigoPolizaRectificacion = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CODIGO_POLIZA_RECTIFICACION").ToString
                comentarioRectificado = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("COMENTARIO_RECTIFICADO").ToString
                clasePolizaRectificacion = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLASE_POLIZA_RECTIFICACION").ToString
                docIdRectificacion = IIf(DBNull.Value.Equals(xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOC_ID_RECTIFICACION")), 0, xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOC_ID_RECTIFICACION"))
                comentarioRectificacion = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("COMENTARIO_RECTIFICADO").ToString

                txtTicketNumber.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TICKET_NUMBER").ToString


                txtTicketNumber.Enabled = False
                lookUpPrioridad.Enabled = False

                'UIBotonRectificar.Visibility = BarItemVisibility.Always
                If pendienteRectificacion <> 1 Then
                    UIBotonRectificacion.Visibility = BarItemVisibility.Always
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
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
            'cmbConsignatario
            GridViewDetalle.BestFitColumns()

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)

        Finally
            pResult = ""

        End Try
    End Sub

    Private Sub fn_llena_docs_ref()
        Try

            'traemos por default del webservice los detalles de la poliza que estan asociados al documento abierto
            If txtDocId.Text.Length > 0 Then
                xdataDocsRef = xserv.get_Docs_Ref_Poliza(" Where DOC_ID = " & txtDocId.Text, PublicLoginInfo.Environment, pResult)
            Else
                xdataDocsRef = xserv.get_Docs_Ref_Poliza(" Where 1 = 2", PublicLoginInfo.Environment, pResult)
            End If
            If pResult = "OK" Then
                GridDocRefencia.DataSource = xdataDocsRef.Tables(0)
            Else
                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
            End If

            'seteamos los elementos visuales del grid

            GridViewDocReferencia.BestFitColumns()

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""

        End Try
    End Sub

    Private Sub fn_llena_combos()


        Try
            'llenamos el combo de los tipos de documento
            dsTiposDocRef = xSettingServ.GetParam_ByParamKey("WMS3PL", "DOCUMENTOS", "", pResult, PublicLoginInfo.Environment)
            cmbTipoDocRef.DataSource = dsTiposDocRef.Tables(0)
            cmbTipoDocRef.PopulateViewColumns()
            cmbTipoDocRef.ValueMember = "PARAM_NAME"
            cmbTipoDocRef.DisplayMember = "PARAM_CAPTION"

            Dim i As Int16

            For i = 0 To cmbTipoDocRef.View.Columns.Count - 1
                cmbTipoDocRef.View.Columns(i).Visible = False
            Next
            cmbTipoDocRef.View.Columns("PARAM_NAME").Caption = "TIPO"
            cmbTipoDocRef.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            cmbTipoDocRef.View.Columns("PARAM_NAME").Visible = True
            cmbTipoDocRef.View.Columns("PARAM_CAPTION").Visible = True
            cmbTipoDocRef.View.BestFitColumns()

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

            ''llenamos el combo de los acuerdos comerciales
            'Dim dsCA As New DataSet
            'dsCA = xSettingServ.GetParam_ByParamKey("CLIENTES", "ACUERDO COMERCIAL", "", pResult, PublicLoginInfo.Environment)
            'cmbAcuerdoComercial.Properties.DataSource = dsCA.Tables(0)
            'cmbAcuerdoComercial.Properties.PopulateViewColumns()
            'cmbAcuerdoComercial.Properties.ValueMember = "PARAM_NAME"
            'cmbAcuerdoComercial.Properties.DisplayMember = "PARAM_CAPTION"

            'For i = 0 To cmbAcuerdoComercial.Properties.View.Columns.Count - 1
            '    cmbAcuerdoComercial.Properties.View.Columns(i).Visible = False
            'Next
            'cmbAcuerdoComercial.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            'cmbAcuerdoComercial.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            'cmbAcuerdoComercial.Properties.View.Columns("PARAM_NAME").Visible = True
            'cmbAcuerdoComercial.Properties.View.Columns("PARAM_CAPTION").Visible = True
            'cmbAcuerdoComercial.Properties.View.BestFitColumns()
            ''llenamos el combo del encabezado
            'cmbAcuerdoHead.Properties.DataSource = dsCA.Tables(0)
            'cmbAcuerdoHead.Properties.PopulateViewColumns()
            'cmbAcuerdoHead.Properties.ValueMember = "PARAM_NAME"
            'cmbAcuerdoHead.Properties.DisplayMember = "PARAM_CAPTION"

            'For i = 0 To cmbAcuerdoHead.Properties.View.Columns.Count - 1
            '    cmbAcuerdoHead.Properties.View.Columns(i).Visible = False
            'Next
            'cmbAcuerdoHead.Properties.View.Columns("PARAM_NAME").Caption = "CODIGO"
            'cmbAcuerdoHead.Properties.View.Columns("PARAM_CAPTION").Caption = "DESCRIPCION"
            'cmbAcuerdoHead.Properties.View.Columns("PARAM_NAME").Visible = True
            'cmbAcuerdoHead.Properties.View.Columns("PARAM_CAPTION").Visible = True
            'cmbAcuerdoHead.Properties.View.BestFitColumns()

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
            End If

            'llenamos el combo de prioridad
            Dim dsPrioridad As New DataSet
            dsPrioridad = xSettingServ.GetParam_ByParamKey("SISTEMA", "PRIORITY", "", pResult, PublicLoginInfo.Environment)
            lookUpPrioridad.Properties.DataSource = dsPrioridad.Tables(0)
            lookUpPrioridad.Properties.PopulateViewColumns()
            lookUpPrioridad.Properties.ValueMember = "NUMERIC_VALUE"
            lookUpPrioridad.Properties.DisplayMember = "PARAM_CAPTION"

            For i = 0 To lookUpPrioridad.Properties.View.Columns.Count - 1
                lookUpPrioridad.Properties.View.Columns(i).Visible = False
            Next

            lookUpPrioridad.Properties.View.Columns("NUMERIC_VALUE").Caption = $"Prioridad"
            lookUpPrioridad.Properties.View.Columns("PARAM_CAPTION").Caption = $"Descripción Prioridad"
            lookUpPrioridad.Properties.View.Columns("NUMERIC_VALUE").Visible = True
            lookUpPrioridad.Properties.View.Columns("PARAM_CAPTION").Visible = True
            lookUpPrioridad.Properties.View.BestFitColumns()
            lookUpPrioridad.EditValue = 1

            'FRM - ESTO ES SOLO MIENTRAS SE DETERMINA UN VALOR DEFAULT POR USUARIO
            'cmbConsignatario.EditValue = "1"
            cmbUnidadCantidad.EditValue = "UN"
            LlenarComboOperador()
        Catch ex As Exception
            MsgBox("Error al llenar combos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try


    End Sub

    Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Try
            fn_graba_head()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub


    Private Sub fn_graba_head()
        Try

            'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
            Dim _fechaAceptacion_dmy, _status, _codigoPoliza, _acuerdoComercial, _regimenPoliza, _regimenAlmacen, docIdExiste As String
            Dim _fechaLlegada, _fechaDocumento As Date
            Dim _totalValorAduana, _tipoCambio, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd As Double
            Dim _totalSeguroUsd, _totalOtrosUsd, _totalLiquidar, _totalOtros, _totalGeneral As Double
            Dim _lastUpdated As Date
            Dim _docId, _numero_lineas, _modo, _totalBultos, _tipoContenedor As Integer

            'asignacion de las variables
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

            If cmbRegimen.EditValue = Nothing Then
                NotifyStatus("Seleccione un regimen", True, False)
                cmbRegimen.Focus()
                Return
            End If

            _regimenAlmacen = cmbRegimen.EditValue.ToString
            If _regimenAlmacen = "[Seleccione Regimen...]" Or _regimenAlmacen = "" Then
                MsgBox("Debe ingresar un Regimen Almacen", MsgBoxStyle.Information, "Error")
                cmbRegimen.Focus()
                Return
            End If

            _regimenPoliza = IIf(IsNothing(cmbRegimenPoliza.EditValue), "", cmbRegimenPoliza.EditValue.ToString)

            If cmbRegimenPoliza.EditValue = Nothing Or _regimenPoliza = "[Seleccione Regimen...]" Or _regimenPoliza = "" Then
                MsgBox("Debe ingresar un Regimen de poliza", MsgBoxStyle.Information, "Error")
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

            If txtCodigoPoliza.Text = "" Then
                NotifyStatus("Debe ingresar el codigo de poliza", True, False)
                txtCodigoPoliza.Focus()
                Return
            End If

            If txtNumeroOrden.Text = "" Then
                NotifyStatus("Debe ingresar el número  de orden", True, False)
                txtNumeroOrden.Focus()
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

            If String.IsNullOrEmpty(txtTicketNumber.Text) And ValidateEnterTicket() Then
                MsgBox("Debe ingresar el No. ticket", MsgBoxStyle.Information, "Error")
                Return
            End If

            If lookUpPrioridad.EditValue = Nothing Then
                MsgBox("Debe seleccionar prioridad", MsgBoxStyle.Information, "Error")
                lookUpPrioridad.Focus()
                Return
            End If

            If (ValidateEnterTicket()) Then
                If (Not GetTicketById()) Then Return
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

            If cmbBodegueros.Text.Length <= 0 Then
                MsgBox("Error: Debe asignar un operador al documento", MsgBoxStyle.Critical, "Error")
                Return
            End If


            If cmbPolizaAsegurada.EditValue = Nothing Then
                MsgBox("Error: Debe asignar una poliza de seguro al documento", MsgBoxStyle.Critical, "Error")
                Return
            End If

            'grabamos el encabezado




            pResult = String.Empty
            If xserv.set_Poliza_Header(txtNumeroOrden.Text, txtAduanaEntradaSalida.Text, txtNumeroDua.Text, _fechaAceptacion_dmy,
                                    txtAduanaDespachoDestino.Text, _regimenPoliza, txtClase.Text, txtPaisProcedencia.Text,
                                    txtNaturalezaTrans.Text, txtDepositoFiscalZf.Text, _modo, _fechaLlegada, _tipoCambio,
                                    _totalValorAduana, _numero_lineas, _totalBultos, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd,
                                    _totalSeguroUsd, _totalOtrosUsd, txtNumeroSat.Text, txtTipoImportador.Text, txtIdTributariaImportador.Text,
                                    txtPaisImportador.Text, txtRazonSocialImportador.Text, txtDomicilioImportador.Text, txtTipoRepresentante.Text,
                                    txtIdTributariaRepresentante.Text, txtPaisRepresentante.Text, txtTipoDeclaranteRepresentante.Text,
                                    txtRazonSocialRepresentante.Text, txtDomicilioRepresentante.Text, _tipoContenedor, txtNumeroContenedor.Text,
                                    txtEntidadContenedor.Text, txtMarchamo.Text, _totalLiquidar, _totalOtros, _totalGeneral, _codigoPoliza, PublicLoginInfo.LoginID, _lastUpdated,
                                    _status, cmbCliente.EditValue, _regimenAlmacen, _fechaDocumento, _acuerdoComercial, "INGRESO", PublicLoginInfo.Environment, pResult, _docId, cmbPolizaAsegurada.EditValue, IIf(cmbBodegueros.EditValue = Nothing, "", cmbBodegueros.EditValue.ToString), "NO", IIf(String.IsNullOrEmpty(txtTicketNumber.Text), Nothing, txtTicketNumber.Text)) Then

                Dim dt As DataTable

                If pResult = "inserted" Then
                    If txtCodigoPoliza.Text.Length <= 0 Then
                        _codigoPoliza = _docId
                    End If

                    dt = xserv.InsertarTareaDeRecepcion("INGRESO_FISCAL", PublicLoginInfo.LoginID, cmbBodegueros.EditValue.ToString(), "Tarea de Recepcion Fiscal", _regimenAlmacen, cmbCliente.EditValue, cmbCliente.Text, _docId, PublicLoginInfo.Environment, pResult, _codigoPoliza, 0, lookUpPrioridad.EditValue, "")

                    If dt Is Nothing Then
                        MsgBox(pResult, MsgBoxStyle.Critical, "Error")
                    End If
                Else
                    If MessageBox.Show("Usted esta creando una nueva tarea de ingreso a un documento ya existente. ¿Desea continuar con esta acción?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then

                        dt = xserv.InsertarTareaDeRecepcion("INGRESO_FISCAL", PublicLoginInfo.LoginID, cmbBodegueros.EditValue.ToString(), "Tarea de Recepcion Fiscal", _regimenAlmacen, cmbCliente.EditValue, cmbCliente.Text, _docId, PublicLoginInfo.Environment, pResult, _codigoPoliza, 0, lookUpPrioridad.EditValue, "")
                        If dt Is Nothing Then
                            MsgBox(pResult, MsgBoxStyle.Critical, "Error")
                        End If
                    End If
                End If

                UIBotonRectificacion.Visibility = BarItemVisibility.Always
                txtDocId.Text = _docId
                dblDoc_id = _docId
                fn_graba_docs_ref()


            Else
                MsgBox(pResult, MsgBoxStyle.Critical, "Error")
            End If


        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
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
            Dim _numeroLinea, _documentoOrigen, _docid As Integer
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

            If cmbConsignatario.EditValue = Nothing Or cmbConsignatario.EditValue = "" Then
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
                MsgBox("Debe ingresar cantidades y bultos")
                Exit Sub
            End If

            If _Cantidad = 0 Then
                _Cantidad = _bultos
            End If

            If xserv.set_Poliza_Detail(_docid, txtDescripcionSku.Text.ToString(), _codigoSAC, _bultos, txtClaseLinea.Text, _pesoNeto, _unidadPeso, _Cantidad, _valorAduana, _unidadCantidad,
                                    _volumen, _unidadVolumen, _valorDai, _valorIva, _impuestosVarios, _fobUsd, _fleteUsd, _seguroUsd, _gastosVarios, txtPaisOrigen.Text, txtRegionCp.Text, txtAcuerdo1.Text,
                                    txtAcuerdo2.Text, txtPolizaRelacionada.Text, PublicLoginInfo.LoginID, Date.Now(), _documentoOrigen, txtPolizaOrigen.Text, cmbConsignatario.EditValue, _pctdai, 0, PublicLoginInfo.Environment, pResult, _numeroLinea, UiListaImpuesto.EditValue, txtDescripcionSku.EditValue.ToString()) Then
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
        Try
            fn_graba_Detalle()
            'FRM - SEP-27-2012 / FOCUS
            txtDescripcionSku.Focus()
            txtDescripcionSku.SelectionStart = 0
            txtDescripcionSku.SelectionLength = Len(txtDescripcionSku.Text.ToString())

            txtValorAduana.SelectionStart = 0
            txtValorAduana.SelectionLength = Len(txtValorAduana.Text)


        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            Try
                If Not txtScanPoliza.EditValue Is Nothing Then
                    If Not String.IsNullOrEmpty(txtScanPoliza.EditValue) Then
                        Print(txtScanPoliza.EditValue.ToString())
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Print(ByVal pCodigoPoliza As String)
        Try
            Dim rptPolEgreso As New rptDocumentoIngresoFiscal

            Dim dt As DataSet
            Dim result As String = String.Empty
            Dim serverInfoTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            dt = serverInfoTrans.GetRepPolizaFiscal(pCodigoPoliza, "FISCAL", "INGRESO", result, PublicLoginInfo.Environment)

            If result = "OK" Then
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
            cmbConsignatario.EditValue = Nothing

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
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
            cmbBodegueros.EditValue = Nothing

            pendienteRectificacion = 0
            codigoPolizaRectificacion = ""
            comentarioRectificado = ""
            clasePolizaRectificacion = ""
            docIdRectificacion = 0
            comentarioRectificacion = ""

            txtTicketNumber.Text = String.Empty
            lookUpPrioridad.EditValue = 1

            txtTicketNumber.Enabled = True
            lookUpPrioridad.Enabled = True

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub btnScan_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnScan.ItemClick
        Dim xServPol As New WMS_Polizas.WMS_PolizasSoapClient("WMS_PolizasSoap", PublicLoginInfo.WSHost + "/trans/WMS_Polizas.asmx")
        Dim dtParsePoliza As New DataSet()

        'FRM - SEP-27-2012 / COLOCAR TRY
        Try
            If txtScanPoliza.EditValue.ToString().Length > 0 Then
                fn_limpia_head()
                fn_limpia_detalle()
                xDataSetHead.Clear()
                xdataset.Clear()
                xdataDocsRef.Clear()
                dtFechaLlegada.EditValue = Date.Today

                If Double.TryParse(txtScanPoliza.EditValue.ToString.ToUpper, dblDoc_id) Then
                    fn_llena_Head()
                    fn_llena_detalle()
                    fn_llena_docs_ref()

                Else

                    dtParsePoliza = xServPol.ParsePoliza(txtScanPoliza.EditValue.ToString.ToUpper, pResult)
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
                                                fn_llena_docs_ref()
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
                                            cmbRegimenPoliza.EditValue = Trim(dtParsePoliza.Tables(0).Rows(0)("FIELD_8_1").ToString())

                                            'FRM - OCT-05-2012 / CLIENTE DEFAULT "1"
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
                                Else
                                    NotifyStatus(pResult, False, True)

                                End If

                                txtScanPoliza.EditValue = String.Empty
                            Else

                                NotifyStatus(pResult, False, True)
                            End If
                        End If
                    Else
                        MessageBox.Show("1 else:" + pResult)
                    End If
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try

    End Sub

    Private Sub fn_graba_docs_ref()
        Dim i As Int16
        Dim _numDoc As String
        Dim _tipoDoc As String
        Dim _fechaDoc As Date
        Dim _obs As String
        Try
            If GridViewDocReferencia.RowCount > 0 Then
                For i = 0 To GridViewDocReferencia.RowCount - 1
                    If GridViewDocReferencia.GetRowCellValue(i, "NUMERO_DOCUMENTO").ToString.Length > 0 Then
                        _numDoc = GridViewDocReferencia.GetRowCellValue(i, "NUMERO_DOCUMENTO").ToString
                    Else
                        _numDoc = String.Empty
                    End If
                    If GridViewDocReferencia.GetRowCellValue(i, "TIPO_DOCUMENTO").ToString.Length > 0 Then
                        _tipoDoc = GridViewDocReferencia.GetRowCellValue(i, "TIPO_DOCUMENTO").ToString
                    Else
                        _tipoDoc = String.Empty
                    End If
                    If GridViewDocReferencia.GetRowCellValue(i, "OBSERVACIONES").ToString.Length > 0 Then
                        _obs = GridViewDocReferencia.GetRowCellValue(i, "OBSERVACIONES").ToString
                    Else
                        _obs = String.Empty
                    End If
                    Date.TryParse(GridViewDocReferencia.GetRowCellValue(i, "FECHA_DOCUMENTO").ToString, _fechaDoc)

                    If xserv.set_Docs_Ref_Poliza(dblDoc_id, txtNumeroDua.Text, _numDoc, _tipoDoc, _fechaDoc, _obs, PublicLoginInfo.LoginID, Date.Now(), PublicLoginInfo.Environment, pResult) = False Then
                        Throw New ApplicationException(pResult)
                    End If
                Next
            End If

        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
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
                                txtDescripcionSku.Text = GridViewDetalle.GetFocusedRowCellValue("MATERIAL_ID").ToString
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
            End If

        Catch ex As Exception
            MsgBox("Error en doble click de grid " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    'Private Sub txtScanEdit_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanEdit.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        btnScan.PerformClick()
    '    End If
    'End Sub

    'Boton Enviar a Sat
    Private Sub btnEnviar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEnviar.ItemClick
        Dim _Document As Int32
        Dim _cliente, _clientName, _satResult As String
        Dim _sent, _receive As Date
        Dim provider As CultureInfo = CultureInfo.InvariantCulture

        If Int32.TryParse(txtDocId.Text, _Document) Then

            If Not IsNothing(cmbCliente.EditValue) Then
                _cliente = cmbCliente.EditValue
                _clientName = cmbCliente.Text
            Else
                _cliente = String.Empty
                _clientName = String.Empty
            End If

            _satResult = String.Empty
            _sent = Date.ParseExact("01/01/1900", "d", provider)
            _receive = Date.ParseExact("01/01/1900", "d", provider)
            Try
                If xserv.set_Sync_Poliza(txtCodigoPoliza.Text, _Document, _cliente, _clientName, 1, _sent, _receive, _satResult, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pResult) Then
                    If pResult = "inserted" Or pResult = "updated" Then
                        MsgBox("la poliza ha sido enviada ", MsgBoxStyle.Information, "Aviso")
                        txtStatus.Text = "Enviada SAT"
                        fn_graba_head()

                    Else
                        MsgBox("error: " & pResult, MsgBoxStyle.Critical, "Error")

                    End If
                End If
            Catch ex As Exception
                MsgBox("error: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        End If
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
                fn_llena_docs_ref()
                fn_llena_detalle()

            End If
            UIBotonRectificar.Visibility = BarItemVisibility.Never
            UIBotonRectificacion.Visibility = BarItemVisibility.Never
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub cmbCliente_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.EditValueChanged
        cmbConsignatario.EditValue = cmbCliente.EditValue
        Try
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
                        Else
                            MsgBox("El cliente no posee acuerdos comerciales")
                        End If
                    Else
                        MsgBox(pResult)
                    End If
                Else
                    'cmbAcuerdoComercial.Properties.DataSource = Nothing
                    cmbAcuerdoHead.Properties.DataSource = Nothing
                End If
            Else
                'cmbAcuerdoComercial.Properties.DataSource = Nothing
                cmbAcuerdoHead.Properties.DataSource = Nothing
            End If

            'Dim dsTerms As New DataSet
            If Not IsNothing(cmbCliente.EditValue) Then
                If cmbCliente.EditValue.ToString.Length > 0 Then

                    'llenamos el combo de los productos por cliente
                    Dim dsMAT As New DataSet
                    dsMAT = xserv.get_cust_skus(cmbCliente.EditValue, PublicLoginInfo.Environment, pResult)
                    If pResult = "OK" Then
                        txtDescripcionSku.Properties.DataSource = dsMAT.Tables("OP_WMS_MATERIALS")
                        txtDescripcionSku.Properties.PopulateColumns()
                        txtDescripcionSku.Properties.ValueMember = "MATERIAL_ID"
                        txtDescripcionSku.Properties.DisplayMember = "MATERIAL_NAME"


                        'For i = 0 To dsMAT.Tables(0).Rows.Count - 1
                        '    ''txtDescripcionSku.Properties.Items.Add(dsMAT.Tables("OP_WMS_MATERIALS").Rows(i)("BARCODE_ID").ToString & " - " & dsMAT.Tables("OP_WMS_MATERIALS").Rows(i)("MATERIAL_NAME").ToString)
                        '    txtDescripcionSku.Properties.Columns.Add(dsMAT.Tables("OP_WMS_MATERIALS").Rows(i)("BARCODE_ID"))
                        '    txtDescripcionSku.Properties.Columns.Add(dsMAT.Tables("OP_WMS_MATERIALS").Rows(i)("MATERIAL_NAME"))
                        '    txtDescripcionSku.Properties.DataSource = dsMAT.Tables("OP_WMS_MATERIALS")
                        'Next
                        pResult = String.Empty
                    Else

                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                        pResult = String.Empty
                    End If
                    LlenarCmbPolizasSeguro()
                End If
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub LlenarCmbPolizasSeguro()
        Try
            Dim xdataset As New DataSet
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetInsuranceDocsCliente(cmbCliente.EditValue.ToString, pResult, PublicLoginInfo.Environment)

            cmbPolizaAsegurada.Properties.View.Columns.Clear()

            If pResult = "OK" Then

                cmbPolizaAsegurada.Properties.DataSource = xdataset.Tables(0)
                cmbPolizaAsegurada.Properties.PopulateViewColumns()
                cmbPolizaAsegurada.Properties.ValueMember = "DOC_ID"
                cmbPolizaAsegurada.Properties.DisplayMember = "POLIZA_INSURANCE"

                For i = 0 To cmbPolizaAsegurada.Properties.View.Columns.Count - 1
                    cmbPolizaAsegurada.Properties.View.Columns(i).Visible = False
                Next

                cmbPolizaAsegurada.Properties.View.Columns("POLIZA_INSURANCE").Caption = "POLIZA"
                cmbPolizaAsegurada.Properties.View.Columns("DOC_ID").Caption = "CODIGO"
                cmbPolizaAsegurada.Properties.View.Columns("POLIZA_INSURANCE").Visible = True
                cmbPolizaAsegurada.Properties.View.Columns("DOC_ID").Visible = True
                cmbPolizaAsegurada.Properties.View.BestFitColumns()

            Else

                NotifyStatus(pResult, False, True)

                Dim dsPolizas As DataSet
                dsPolizas = xSettingServ.GetParam_ByParamKey("POLIZAS", "POLIZAS_SEGUROS", "", pResult, PublicLoginInfo.Environment)
                cmbPolizaAsegurada.Properties.DataSource = dsPolizas.Tables(0)
                cmbPolizaAsegurada.Properties.PopulateViewColumns()
                cmbPolizaAsegurada.Properties.ValueMember = "TEXT_VALUE"
                cmbPolizaAsegurada.Properties.DisplayMember = "PARAM_CAPTION"

                For i = 0 To cmbPolizaAsegurada.Properties.View.Columns.Count - 1
                    cmbPolizaAsegurada.Properties.View.Columns(i).Visible = False
                Next
                cmbPolizaAsegurada.Properties.View.Columns("PARAM_NAME").Caption = "POLIZA"
                cmbPolizaAsegurada.Properties.View.Columns("TEXT_VALUE").Caption = "CODIGO"
                cmbPolizaAsegurada.Properties.View.Columns("PARAM_NAME").Visible = True
                cmbPolizaAsegurada.Properties.View.Columns("TEXT_VALUE").Visible = True
                cmbPolizaAsegurada.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub txtValorAduana_GotFocus(sender As Object, e As System.EventArgs) Handles txtValorAduana.GotFocus
        txtValorAduana.SelectionStart = 0
        txtValorAduana.SelectionLength = Len(txtValorAduana.Text)

    End Sub

    Private Sub txtDescripcionSku_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcionSku.KeyPress
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
                            txtDescripcionSku.EditValue = GridViewDetalle.GetFocusedRowCellValue("MATERIAL_ID").ToString
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

    Private Sub txtDescripcionSku_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub GridDocRefencia_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridDocRefencia.KeyUp
        Try
            If e.KeyCode = 46 Then ' delete
                If MessageBox.Show("¿ Confirma la eliminacion de " & GridViewDocReferencia.GetFocusedRowCellValue("NUMERO_DOCUMENTO").ToString & " ?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                    xserv.del_Docs_Ref_Poliza(dblDoc_id, GridViewDocReferencia.GetFocusedRowCellValue("NUMERO_DOCUMENTO"), GridViewDocReferencia.GetFocusedRowCellValue("TIPO_DOCUMENTO"), PublicLoginInfo.Environment, pResult)
                    If pResult = "OK" Then
                        fn_llena_docs_ref()

                    Else
                        NotifyStatus(pResult, False, True)
                    End If

                End If
            End If
        Catch ex As Exception
            NotifyStatus(pResult, False, True)
        End Try
    End Sub

    Private Sub cmbRegimenPoliza_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRegimenPoliza.EditValueChanged
        Try
            If Not IsNothing(cmbRegimenPoliza.EditValue) Then
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
                        NotifyStatus(pResult, False, True)
                    End If
                End If
            End If
        Catch ex As Exception
            NotifyStatus(pResult, False, True)
        End Try

    End Sub


    Private Sub pctDAI_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctDAI.Validated

    End Sub

    Private Sub pctDAI_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctDAI.EditValueChanged
        Try
            Dim pDAI As Double = 0

            pDAI = CDbl(txtValorAduana.Text) * (CDbl(pctDAI.Text) / 100)
            txtDai.Text = pDAI.ToString("###,##0.00")

            Dim pIVA As Double = 0
            pIVA = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12

            txtValorIva.Text = pIVA.ToString("###,##0.00")
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
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
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub txtValorAduana_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValorAduana.EditValueChanged
        Try
            If Not txtValorAduana.Text = "" Then
                Dim pDAI As Double = 0

                pDAI = CDbl(txtValorAduana.Text) * (CDbl(pctDAI.Text) / 100)
                txtDai.Text = pDAI.ToString("###,##0.00")
                Dim pIVA As Double = 0
                pIVA = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12

                txtValorIva.Text = pIVA.ToString("###,##0.00")
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
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
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    'Boton Rectificacion
    Private Sub btnRectify_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRectify.ItemClick
        Try
            If Val(txtDocId.EditValue) > 0 Then
                If Not IsNothing(cmbCliente.EditValue) Then
                    If cmbCliente.EditValue.ToString.Length > 0 Then
                        Dim fim As New frmRectificacion
                        fim.stCUST = cmbCliente.EditValue.ToString()
                        fim.stRELPOL = txtCodigoPoliza.Text
                        fim.inDOCID = Val(txtDocId.Text)
                        fim.ShowDialog()
                        fn_limpia_detalle()
                        fn_llena_detalle()

                    Else
                        MsgBox("Debe seleccionar el cliente antes de recitificar la poliza", MsgBoxStyle.Information, "Advertencia")
                    End If
                Else
                    MsgBox("Debe seleccionar el cliente antes de recitificar la poliza", MsgBoxStyle.Information, "Advertencia")
                End If
            Else
                MsgBox("Debe grabar el encabezado antes de recitificar la poliza", MsgBoxStyle.Information, "Advertencia")
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub LlenarComboOperador()
        Try
            Dim xSecurity As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_Security.asmx")
            Dim dsUsuarios As New DataSet
            dsUsuarios = xSecurity.SearchOperators(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    cmbBodegueros.Properties.DataSource = dsUsuarios.Tables(0)
                    cmbBodegueros.Properties.PopulateViewColumns()
                    cmbBodegueros.Properties.ValueMember = "LOGIN_ID"
                    cmbBodegueros.Properties.DisplayMember = "LOGIN_NAME"

                    For i = 0 To cmbBodegueros.Properties.View.Columns.Count - 1
                        cmbBodegueros.Properties.View.Columns(i).Visible = False
                    Next
                    cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Caption = "NOMBRE"
                    cmbBodegueros.Properties.View.Columns("LOGIN_ID").Caption = "USUARIO"
                    cmbBodegueros.Properties.View.Columns("LOGIN_NAME").Visible = True
                    cmbBodegueros.Properties.View.Columns("LOGIN_ID").Visible = True
                    cmbBodegueros.Properties.View.BestFitColumns()
                End If
            Else
                MsgBox(pResult)
            End If

            ''cmbBodegueros.EditValue = "1"
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub UIBotonRectificar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UIBotonRectificar.ItemClick
        If Not txtDocId.Text.Equals("0") Then
            Dim frmRectificarPoliza As New FrmRectificarPoliza(pendienteRectificacion, Integer.Parse(txtDocId.Text), txtCodigoPoliza.Text, txtNumeroOrden.Text, comentarioRectificado, clasePolizaRectificacion)
            frmRectificarPoliza.ShowDialog()

            If frmRectificarPoliza._pendienteDeRectificacion = 1 Then
                pendienteRectificacion = frmRectificarPoliza._pendienteDeRectificacion
                codigoPolizaRectificacion = frmRectificarPoliza.UiEtiqeutaPoliza.Text
                comentarioRectificado = frmRectificarPoliza.UiMemoComentario.Text
                clasePolizaRectificacion = frmRectificarPoliza.UiEtiqeutaPoliza.Text
                'UIBotonRectificar.Visibility = BarItemVisibility.Never
                MessageBox.Show("Proceso exitoso.", "Pendiente de Rectificar", MessageBoxButtons.OK)
            End If
        End If
    End Sub

    Private Sub UIBotonRectificacion_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UIBotonRectificacion.ItemClick
        Try
            If Not txtDocId.Text.Equals("0") Then
                Dim frmRectificarPoliza As New FrmRectificacionPoliza(docIdRectificacion, Integer.Parse(txtDocId.Text), txtCodigoPoliza.Text, txtNumeroOrden.Text, docIdRectificacion, comentarioRectificacion)
                frmRectificarPoliza.ShowDialog()

                If frmRectificarPoliza._pendienteDeRectificacion <> 0 Then
                    pendienteRectificacion = frmRectificarPoliza._pendienteDeRectificacion
                    codigoPolizaRectificacion = frmRectificarPoliza.UiEtiqeutaPoliza.Text
                    comentarioRectificacion = frmRectificarPoliza.UiMemoComentario.Text
                    clasePolizaRectificacion = frmRectificarPoliza.UiEtiqeutaPoliza.Text
                    docIdRectificacion = frmRectificarPoliza._pendienteDeRectificacion
                    MessageBox.Show("Proceso exitoso.", "Rectificación", MessageBoxButtons.OK)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try

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
        If String.IsNullOrEmpty(txtValorAduana.Text) Then
            Return
        End If

        Impuesto = IIf(UiListaImpuesto.EditValue Is Nothing, 1, UiListaImpuesto.EditValue)

        Dim pDAI As Double = 0

        pDAI = CDbl(txtValorAduana.Text) * (CDbl(pctDAI.Text) / 100)
        txtDai.Text = pDAI.ToString("###,##0.00")

        Dim pIVA As Double = 0
        pIVA = (CDbl(txtValorAduana.Text) + CDbl(txtDai.Text)) * Impuesto '0.12

        txtValorIva.Text = pIVA.ToString("###,##0.00")

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

    Private Shared Function ValidateEnterTicket() As Boolean
        Dim securityService = New WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Security.asmx")
        Dim ingresaTicket = securityService.GetParameterValue("", PublicLoginInfo.Environment, Enums.GetStringValue(GrupoParametro.ValidarIngresoTicket), Enums.GetStringValue(IdParametro.DebeIngresarTicket))
        If String.IsNullOrEmpty(ingresaTicket) Then
            Return False
        Else
            Return (Convert.ToInt16(ingresaTicket)) = 1
        End If
    End Function

    Public Function GetTicketById() As Boolean
        Try
            Dim dtTicket = xserv.GetTicketById(Convert.ToInt64(txtTicketNumber.Text), pResult, PublicLoginInfo.Environment)
            Dim idPolice As Decimal
            Dim dateTicket As DateTime
            Dim statusTicket As String

            If (dtTicket.Rows.Count <= 0) Then
                NotifyStatus("No se encontró el ticket.", True, True)
                txtTicketNumber.Text = String.Empty
                Return False
            End If


            For Each dtRow As DataRow In dtTicket.Rows

                idPolice = Convert.ToInt64(dtRow("POLIZA_DOC_ID"))
                dateTicket = Convert.ToDateTime(dtRow("CREATED_DATE"))
                statusTicket = dtRow("STATUS").ToString()

            Next

            If idPolice > 0 OrElse statusTicket <> "PRINTED" Then
                NotifyStatus("No se puede asignar el ticket porque se encuentra asignado.", True, True)
                txtTicketNumber.Text = String.Empty
                Return False
            End If

            dtFechaLlegada.EditValue = dateTicket.ToString
            NotifyStatus("Fecha de llegada: " + dateTicket.ToString(), False, False)
            Return True

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try


    End Function

    Private Sub txtTicketNumber_Leave(sender As Object, e As EventArgs) Handles txtTicketNumber.Leave
        Try

            If Not String.IsNullOrEmpty(txtTicketNumber.Text) Then
                GetTicketById()
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
End Class
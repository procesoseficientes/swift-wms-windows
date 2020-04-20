Imports System.IO
Imports System.Data
Public Class frmInDocument
    'Declaramos la variable del servicio que esta vinculado a este form
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Public dblDoc_id As Double = 0
    Dim xdataset As New DataSet
    Dim xDataSetHead As New DataSet
    Dim pResult As String = ""
    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            LayoutControl1.Print()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub frmInDocument_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            If xdataset.HasChanges Or xDataSetHead.HasChanges Then
                If MsgBox("¿Desea Grabar los datos que ha cambiando antes de salir?", MsgBoxStyle.YesNoCancel, "Datos") = MsgBoxResult.Yes Then
                    Return
                End If
            End If
            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInDocument.xml"
            LayoutControl1.SaveLayoutToXml(strPath)

            'grabamos el layout del grid del detalle
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInDocumentDetailGrid.xml"
            GridViewDetalle.SaveLayoutToXml(strPath)

            strPath = String.Empty


        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Private Sub frmInDocument_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'MsgBox(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString())
        Dim strPath As String
        Try
            'verificamos el layout de la forma
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInDocument.xml"
            If File.Exists(strPath) Then
                LayoutControl1.RestoreLayoutFromXml(strPath)
            End If

            'verificamos el layout del grid del detalle
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInDocumentDetailGrid.xml"
            If File.Exists(strPath) Then
                GridViewDetalle.SaveLayoutToXml(strPath)
            End If
            strPath = String.Empty

            'llenamos los datos de la forma
            If dblDoc_id > 0 Then
                fn_llena_Head()
            End If
            If txtDocId.Text.Length > 0 Then
                fn_llena_detalle()
            Else
                fn_llena_detalle_vacio()
            End If
        Catch ex As Exception
            MsgBox("Error al Cargar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub

    Private Sub frmInDocument_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'limpiamos los datasets
        xdataset.Dispose()
        xDataSetHead.Dispose()
        pResult = String.Empty
    End Sub

    Private Sub btnRestore_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRestore.ItemClick
        Dim strPath As String
        Try
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInDocument.xml"
            If File.Exists(strPath) Then
                File.Delete(strPath)
            End If
        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Private Sub fn_llena_Head()
        Try
            If xDataSetHead.Tables(0).Columns.Count > 0 Then
                xDataSetHead.Clear()
            End If
            xDataSetHead = xserv.get_Poliza_Header(" Where DOC_ID = " & dblDoc_id.ToString(), PublicLoginInfo.Environment, pResult)
            Dim HeadDV As DataView = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").DefaultView
            If pResult = "OK" Then
                txtDocId.Text = dblDoc_id.ToString()
                txtNumeroOrden.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_ORDEN").ToString
                cmbAduanaEntradaSalida.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ADUANA_ENTRADA_SALIDA").ToString
                txtNumeroDUA.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_DUA").ToString
                txtFechaAceptacion.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_ACEPTACION").ToString
                cmbAduanaDespachoDestino.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ADUANA_DESPACHO_DESTINO").ToString
                cmbType.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("REGIMEN").ToString
                txtClase.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("CLASE").ToString
                txtPaisProcedencia.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PAIS_PROCEDENCIA").ToString
                txtNaturalezaTran.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NATURALEZA_TRANS").ToString
                txtDepositoFiscal_ZF.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DEPOSITO_FISCAL_ZF").ToString
                txtModo.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("MODO").ToString
                dtFechaDocumento.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_DOCUMENTO").ToString
                dtFechaLLegada.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_LLEGADA").ToString
                txtTipoCambio.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_CAMBIO").ToString
                txtTotal.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_VALOR_ADUANA").ToString
                txtNumeroLineas.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_NUMERO_LINEAS").ToString
                txtBultos.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_BULTOS").ToString
                txtPesoBrutoKG.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_PESO_BRUTO_KG").ToString
                txtTotalFOB.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_FOB_USD").ToString()
                txtFleteUSD.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_FLETE_USD").ToString
                txtSeguroUSD.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_SEGURO_USD").ToString
                txtOtrosUSD.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_OTROS_USD").ToString
                txtNumeroSAT.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_SAT").ToString
                txtTipoImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_IMPORTADOR").ToString
                txtIdTribImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ID_TRIB_IMPORTADOR").ToString
                txtPaisImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PAIS_IMPORTADOR").ToString
                txtRazonSocialImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("RAZON_SOCIAL_IMPORTADOR").ToString
                txtDomicilioImportador.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOMICILIO_IMPORTADOR").ToString
                txtTipoRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_REPRESENTANTE").ToString
                txtTributariaRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ID_TRIB_REPRESENTANTE").ToString
                txtPaisRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("PAIS_REPRESENTANTE").ToString
                txtTipoDeclaranteRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_DECLARANTE_REPRESENTANTE").ToString
                txtRazonRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("RAZON_SOCIAL_REPRESENTANTE").ToString
                txtDomicilioRepresentante.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("DOMICILIO_REPRESENTANTE").ToString
                txtTipoContenedor.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TIPO_CONTENEDOR").ToString
                txtNumeroContenedor.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_CONTENEDOR").ToString
                txtEntidadContenedor.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("ENTIDAD_CONTENEDOR").ToString
                txtMarchamo.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("NUMERO_MARCHAMO_CONTENEDOR").ToString
                txtTotalLiquidar.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_LIQUIDAR").ToString
                txtTotalOtros.Text = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("TOTAL_OTROS").ToString
                cmbRegimen.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("WAREHOUSE_REGIMEN").ToString
                dtFechaDocumento.EditValue = xDataSetHead.Tables("OP_WMS_POLIZA_HEAD").Rows(0)("FECHA_DOCUMENTO").ToString

            Else
                MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub fn_llena_detalle()
        Try

            'limpiamos los datos para llenarlos con registros desde la base de datos
            If xdataset.Tables(0).Columns.Count > 0 Then
                xdataset.Clear()
            End If
            If GridViewDetalle.Columns.Count > 0 Then
                GridViewDetalle.Columns.Clear()
            End If
            'traemos por default del webservice los detalles de la poliza que estan asociados al documento abierto
            xdataset = xserv.get_Poliza_Detail(" Where DOC_ID = " & txtDocId.Text, "", PublicLoginInfo.Environment, pResult)
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

    Private Sub fn_llena_detalle_vacio()
        Try

            'limpiamos los datos para llenarlos con registros desde la base de datos
            If xdataset.Tables.Count > 0 Then
                If xdataset.Tables(0).Columns.Count > 0 Then
                    xdataset.Clear()
                End If
            End If

            If GridViewDetalle.Columns.Count > 0 Then
                GridViewDetalle.Columns.Clear()
            End If
            'traemos por default del webservice los detalles de la poliza que estan asociados al documento abierto
            xdataset = xserv.get_Poliza_Detail(" Where 1 = 2", "", PublicLoginInfo.Environment, pResult)
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

    Private Sub btnSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Try
            'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
            Dim _fechaAceptacion_dmy As String
            Dim _fechaLlegada As DateTime
            Dim _totalValorAduana = Nothing, _numero_lineas = Nothing, _tipoCambio = Nothing, _modo = Nothing, _totalBultos = Nothing, _totalPesoBrutokg = Nothing, _totalFobUsd = Nothing, _totalFleteUsd As Double = 0
            Dim _totalSeguroUsd = Nothing, _totalOtrosUsd = Nothing, _tipoContenedor = Nothing, _totalLiquidar = Nothing, _totalOtros = Nothing, _totalGeneral As Double = 0
            Dim _lastUpdated As Date = Now, _docParent As Double = 0
            Dim _docId As Integer = 0

            'asignacion de las variables
            _fechaAceptacion_dmy = txtFechaAceptacion.Text
            _fechaLlegada = Format(dtFechaLLegada.Text, DateFormat.GeneralDate)


            'grabamos el encabezado
            'xserv.set_Poliza_Header(txtNumeroOrden.Text, cmbAduanaEntradaSalida.EditValue, txtNumeroDUA.Text, _fechaAceptacion_dmy, _
            '                        cmbAduanaDespachoDestino.EditValue, cmbRegimen.EditValue, txtClase.Text, txtPaisProcedencia.Text, _
            '                        txtNaturalezaTran.Text, txtDepositoFiscal_ZF.Text, _modo, _fechaLlegada, _tipoCambio, _
            '                        _totalValorAduana, _numero_lineas, _totalBultos, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd, _
            '                        _totalSeguroUsd, _totalOtrosUsd, txtNumeroSAT.Text, txtTipoImportador.Text, txtIdTribImportador.Text, _
            '                        txtPaisImportador.Text, txtRazonSocialImportador.Text, txtDomicilioImportador.Text, txtTipoRepresentante.Text, _
            '                        txtTributariaRepresentante.Text, txtPaisRepresentante.Text, txtTipoDeclaranteRepresentante.Text, _
            '                        txtRazonRepresentante.Text, txtDomicilioRepresentante.Text, _tipoContenedor, txtNumeroContenedor.Text, _
            '                        txtEntidadContenedor.Text, txtMarchamo.Text, _totalLiquidar, _totalOtros, _totalGeneral, txtNumeroDUA.Text, PublicLoginInfo.LoginID, _lastUpdated, _
            '                        txtStatus.Text, btnClientCode.EditValue, _docParent, cmbRegimen.EditValue, PublicLoginInfo.Environment, pResult, _docId)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")

        Finally
            pResult = ""
        End Try
    End Sub
End Class
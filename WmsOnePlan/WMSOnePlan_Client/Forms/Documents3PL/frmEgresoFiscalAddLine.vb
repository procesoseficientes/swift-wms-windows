Public Class frmEgresoFiscalAddLine
    'Declaramos la variable del servicio que esta vinculado a este form
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xSettingServ As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")

    Dim xdataset As New DataSet
    Dim xDSPOL As New DataTable

    Dim pResult As String = ""
    Public doc_id As Double

    Private Sub frmEgresoFiscalAddLine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            xDSPOL = xserv.GetInventoryByDosc(PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                GridPolizas.DataSource = xDSPOL
                GridViewPolizas.BestFitColumns()
                'GridPolizas
            End If
            pResult = String.Empty

            xdataset = xserv.get_Poliza_Detail(" where doc_id = " & doc_id.ToString, "", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                GridEnvio.DataSource = xdataset.Tables(0)

            End If
            pResult = String.Empty
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BarLargeButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarLargeButtonItem1.ItemClick
        Try
            If GridViewEnvio.RowCount > 0 Then
                Dim I As Int16

                'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
                Dim _numeroLinea, _documentoOrigen, _docid, _origin_line_number As Integer
                Dim _bultos, _Cantidad, _valorAduana, _valorDai, _valorIva, _pesoNeto, _volumen, _impuestosVarios, _gastosVarios, _fobUsd As Double
                Dim _fleteUsd, _seguroUsd, _pctdai As Double
                Dim _codigoSAC, _unidadCantidad, _unidadPeso, _unidadVolumen, _sku_description, _clase, _region_cp, _material_id As String
                Dim _agreement1, _agreement2, _origin_poliza, _origin_country, _related_poliza, _consignatario As String
                dim impuesto as Decimal
                For I = 0 To GridViewEnvio.RowCount - 1

                    Integer.TryParse(GridViewEnvio.GetRowCellValue(I, "LINE_NUMBER"), _numeroLinea)
                    Integer.TryParse(GridViewEnvio.GetRowCellValue(I, "ORIGIN_LINE_NUMBER"), _origin_line_number)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "BULTOS"), _bultos)
                    Integer.TryParse(GridViewEnvio.GetRowCellValue(I, "ORIGIN_DOC_ID"), _documentoOrigen)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "QTY"), _Cantidad)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "CUSTOMS_AMOUNT"), _valorAduana)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "DAI"), _valorDai)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "IVA"), _valorIva)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "NET_WEIGTH"), _pesoNeto)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "VOLUME"), _volumen)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "MISC_TAXES"), _impuestosVarios)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "MISC_EXPENSES"), _gastosVarios)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "FOB_USD"), _fobUsd)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "FREIGTH_USD"), _fleteUsd)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "INSURANCE_USD"), _seguroUsd)
                    Double.TryParse(GridViewEnvio.GetRowCellValue(I, "PCT_DAI"), _pctdai)
                    Integer.TryParse(GridViewEnvio.GetRowCellValue(I, "DOC_ID"), _docid)
                    'Integer.TryParse(, _consignatario)
                    _consignatario = GridViewEnvio.GetRowCellValue(I, "CLIENT_CODE")
                    Integer.TryParse(GridViewEnvio.GetRowCellValue(I, "DOC_ID"), _docid)
                    _codigoSAC = GridViewEnvio.GetRowCellValue(I, "SAC_CODE")
                    _unidadCantidad = GridViewEnvio.GetRowCellValue(I, "QTY_UNIT")
                    _unidadPeso = GridViewEnvio.GetRowCellValue(I, "WEIGTH_UNIT")
                    _unidadVolumen = GridViewEnvio.GetRowCellValue(I, "VOLUME_UNIT")
                    _sku_description = GridViewEnvio.GetRowCellValue(I, "SKU_DESCRIPTION").ToString
                    _clase = GridViewEnvio.GetRowCellValue(I, "CLASE").ToString
                    _region_cp = GridViewEnvio.GetRowCellValue(I, "REGION_CP").ToString
                    _material_id = GridViewEnvio.GetRowCellValue(I, "MATERIAL_ID").ToString
                    _agreement1 = GridViewEnvio.GetRowCellValue(I, "AGREEMENT_1").ToString
                    _agreement2 = GridViewEnvio.GetRowCellValue(I, "AGREEMENT_2").ToString
                    _origin_country = GridViewEnvio.GetRowCellValue(I, "ORIGIN_COUNTRY").ToString
                    _related_poliza = GridViewEnvio.GetRowCellValue(I, "RELATED_POLIZA").ToString
                    _origin_poliza = GridViewEnvio.GetRowCellValue(I, "CODIGO_POLIZA_ORIGEN").ToString
                    Decimal.TryParse(IIf(GridViewEnvio.GetRowCellValue(I, "TAX").Equals(DBNull.Value), 0, GridViewEnvio.GetRowCellValue(I, "TAX")), impuesto)

                    If _bultos > 0 Then _bultos = -_bultos
                    If _Cantidad > 0 Then _Cantidad = -_Cantidad
                    If _valorAduana > 0 Then _valorAduana = -_valorAduana
                    If _volumen > 0 Then _volumen = -_volumen
                    If _valorDai > 0 Then _valorDai = -_valorDai
                    If _valorIva > 0 Then _valorIva = -_valorIva
                    If _impuestosVarios > 0 Then _impuestosVarios = -_impuestosVarios
                    If _fobUsd > 0 Then _fobUsd = -_fobUsd
                    If _fleteUsd > 0 Then _fleteUsd = -_fleteUsd
                    If _seguroUsd > 0 Then _seguroUsd = -_seguroUsd
                    If _gastosVarios > 0 Then _gastosVarios = -_gastosVarios

                    fn_graba_Detalle(_docid, _sku_description, _codigoSAC, _bultos, _clase, _pesoNeto, _unidadPeso, _Cantidad, _valorAduana, _unidadCantidad, _volumen, _unidadVolumen,
                                         _valorDai, _valorIva, _impuestosVarios, _fobUsd, _fleteUsd, _seguroUsd, _gastosVarios, _origin_country, _region_cp, _agreement1, _agreement2,
                                         _related_poliza, _documentoOrigen, _origin_poliza, _consignatario, _pctdai, _origin_line_number, _numeroLinea, impuesto, _material_id)

                Next

                _numeroLinea = Nothing
                _bultos = Nothing
                _documentoOrigen = Nothing
                _docid = Nothing
                _Cantidad = Nothing
                _valorAduana = Nothing
                _valorDai = Nothing
                _valorIva = Nothing
                _pesoNeto = Nothing
                _volumen = Nothing
                _impuestosVarios = Nothing
                _gastosVarios = Nothing
                _fobUsd = Nothing
                _fleteUsd = Nothing
                _seguroUsd = Nothing
                _pctdai = Nothing
                _codigoSAC = Nothing
                _unidadCantidad = Nothing
                _unidadPeso = Nothing
                _unidadVolumen = Nothing
            End If

            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnAdd_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Try
            If MessageBox.Show("Confirma el Egreso de la Cantidad y Bultos", "Confirmacion", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                Dim dsLine As DataSet
                Dim drLine As DataRow
                Dim dblVALOR As Double
                Dim dblDUMMYC As Integer
                Dim dblIVA As Double
                Dim dblDAI As Double

                dsLine = xserv.get_Poliza_Detail(" WHERE DOC_ID = " & GridViewPolizas.GetFocusedRowCellValue("DOC_ID") & " AND LINE_NUMBER = " & GridViewPolizas.GetFocusedRowCellValue("LINE_NUMBER") & " ", "", PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then
                    If Not IsNothing(dsLine) Then
                        If dsLine.Tables.Count > 0 Then
                            drLine = dsLine.Tables(0).Rows(0)
                            dblVALOR = Val(drLine.Item("CUSTOMS_AMOUNT"))
                            dblDUMMYC = Val(drLine.Item("QTY"))
                            dblDAI = Val(drLine.Item("DAI"))
                            dblIVA = Val(drLine.Item("IVA"))

                            drLine.Item("LINE_NUMBER") = 0
                            drLine.Item("DOC_ID") = doc_id
                            drLine.Item("QTY") = Val(GridViewPolizas.GetFocusedRowCellValue("QTY").ToString)
                            drLine.Item("BULTOS") = Val(GridViewPolizas.GetFocusedRowCellValue("BULTOS").ToString)
                            drLine.Item("ORIGIN_DOC_ID") = Val(GridViewPolizas.GetFocusedRowCellValue("DOC_ID").ToString)
                            drLine.Item("ORIGIN_LINE_NUMBER") = Val(GridViewPolizas.GetFocusedRowCellValue("LINE_NUMBER").ToString)
                            drLine.Item("CODIGO_POLIZA_ORIGEN") = GridViewPolizas.GetFocusedRowCellValue("CODIGO_POLIZA")
                            drLine.Item("CLIENT_CODE") = GridViewPolizas.GetFocusedRowCellValue("CLIENT_CODE")
                            drLine.Item("CONSIGNATARIO_NAME") = GridViewPolizas.GetFocusedRowCellValue("CONSIGNATARIO_NAME")

                            If dblVALOR > 0 Then
                                If dblDUMMYC > 0 Then
                                    drLine.Item("CUSTOMS_AMOUNT") = Math.Round((dblVALOR / dblDUMMYC) * Val(drLine.Item("QTY")), 2)
                                Else
                                    drLine.Item("CUSTOMS_AMOUNT") = Math.Round(dblVALOR, 2)
                                End If
                            Else
                                drLine.Item("CUSTOMS_AMOUNT") = 0
                            End If

                            If dblDAI > 0 Then
                                If dblDUMMYC > 0 Then
                                    drLine.Item("DAI") = Math.Round((dblDAI / dblDUMMYC) * Val(drLine.Item("QTY")), 2)
                                Else
                                    drLine.Item("DAI") = Math.Round(dblDAI, 2)
                                End If
                            Else
                                drLine.Item("DAI") = 0
                            End If

                            If dblIVA > 0 Then
                                If dblDUMMYC > 0 Then
                                    drLine.Item("IVA") = Math.Round((dblIVA / dblDUMMYC) * Val(drLine.Item("QTY")), 2)
                                Else
                                    drLine.Item("IVA") = Math.Round(dblIVA, 2)
                                End If
                            Else
                                drLine.Item("IVA") = 0
                            End If
                            xdataset.Tables(0).ImportRow(drLine)

                            GridEnvio.Refresh()
                        End If
                    End If
                Else
                    MsgBox(pResult)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function fn_graba_Detalle(ByVal pDOC_ID As Integer, ByVal pSKU_DESCRIPTION As String, ByVal pSAC_CODE As String, ByVal pBULTOS As Double, ByVal pCLASE As String _
    , ByVal pNET_WEIGTH As Double, ByVal pWEIGTH_UNIT As String, ByVal pQTY As Double, ByVal pCUSTOMS_AMOUNT As Double, ByVal pQTY_UNIT As String, ByVal pVOLUME As Double _
    , ByVal pVOLUME_UNIT As String, ByVal pDAI As Double, ByVal pIVA As Double, ByVal pMISC_TAXES As Double, ByVal pFOB_USD As Double, ByVal pFREIGTH_USD As Double _
    , ByVal pINSURANCE_USD As Double, ByVal pMISC_EXPENSES As Double, ByVal pORIGIN_COUNTRY As String, ByVal pREGION_CP As String, ByVal pAGREEMENT_1 As String _
    , ByVal pAGREEMENT_2 As String, ByVal pRELATED_POLIZA As String, ByVal pORIGIN_DOC_ID As Integer _
    , ByVal pCODIGO_POLIZA_ORIGEN As String, ByVal pCLIENT_CODE As String, ByVal pPCTDAI As Double, ByVal pORIGIN_LINE_NUMBER As Double, ByRef pLINE_NUMBER As Integer, impuesto As Decimal, ByVal pMATERIAL_ID As String) As Boolean
        Try

            If xserv.set_Poliza_Detail(pDOC_ID, pSKU_DESCRIPTION, pSAC_CODE, pBULTOS, pCLASE, pNET_WEIGTH, pWEIGTH_UNIT, pQTY, pCUSTOMS_AMOUNT, pQTY_UNIT,
                                    pVOLUME, pVOLUME_UNIT, pDAI, pIVA, pMISC_TAXES, pFOB_USD, pFREIGTH_USD, pINSURANCE_USD, pMISC_EXPENSES, pORIGIN_COUNTRY,
                                    pREGION_CP, pAGREEMENT_1, pAGREEMENT_2, pRELATED_POLIZA, PublicLoginInfo.LoginID, Date.Now(), pORIGIN_DOC_ID, pCODIGO_POLIZA_ORIGEN,
                                    pCLIENT_CODE, pPCTDAI, pORIGIN_LINE_NUMBER, PublicLoginInfo.Environment, pResult, pLINE_NUMBER, impuesto, pMATERIAL_ID) Then

                'NotifyStatus("gRegimenSource:" + gRegimenSource, False, False)

                If InStr(gRegimenSource, "23DI0") Then

                    If xserv.set_Poliza_Detail(gLastGeneratedDOC_ID, pSKU_DESCRIPTION, pSAC_CODE, (pBULTOS * -1), pCLASE,
                                               pNET_WEIGTH, pWEIGTH_UNIT, (pQTY * -1), (pCUSTOMS_AMOUNT * -1), pQTY_UNIT,
                        pVOLUME, pVOLUME_UNIT, (pDAI * -1), (pIVA * -1), pMISC_TAXES, (pFOB_USD * -1), (pFREIGTH_USD * -1), (pINSURANCE_USD * -1), pMISC_EXPENSES, pORIGIN_COUNTRY,
                        pREGION_CP, pAGREEMENT_1, pAGREEMENT_2, pRELATED_POLIZA, PublicLoginInfo.LoginID, Date.Now(), pORIGIN_DOC_ID, pCODIGO_POLIZA_ORIGEN,
                        pCLIENT_CODE, pPCTDAI, pORIGIN_LINE_NUMBER, PublicLoginInfo.Environment, pResult, pLINE_NUMBER, impuesto, pMATERIAL_ID) Then
                        'NotifyStatus("gRegimenSource:" + gRegimenSource, False, False)

                        Return True

                    Else
                        Return False
                        Throw New ApplicationException(pResult)
                    End If

                End If

            Else
                Return False
                Throw New ApplicationException(pResult)

            End If

        Catch ex As Exception
            Return False

            Throw New ApplicationException(ex.Message)

        Finally
            pResult = ""
        End Try
    End Function

    Private Sub GridEnvio_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridEnvio.KeyUp
        Try
            If e.KeyCode = 46 Then ' delete
                If MessageBox.Show("¿ Confirma la eliminacion de " & GridViewEnvio.GetFocusedRowCellValue("SKU_DESCRIPTION").ToString & " ?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                    xserv.del_POLIZA_LINE(Val(GridViewEnvio.GetFocusedRowCellValue("DOC_ID")), Val(GridViewEnvio.GetFocusedRowCellValue("LINE_NUMBER")), PublicLoginInfo.Environment, pResult)
                    If pResult = "OK" Then
                        GridViewEnvio.DeleteSelectedRows()

                    Else
                        MsgBox("Error: " & pResult, MsgBoxStyle.Critical, "Error")
                    End If

                End If
            End If
        Catch ex As Exception
            MsgBox("Error al borrar linea " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
Imports System.IO
Imports System.Data
Public Class frmCostearGeneral
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim xct As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
    Dim pResult As String = String.Empty
    Dim pCurrentDoc As String = ""
    Private Sub frmCostearGeneral_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dim strPath As String
            gLastScreenShowed = Me.Name

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmCostearGeneralGridIngresos" & PublicLoginInfo.LoginID & ".xml"
            GridViewIngresos.SaveLayoutToXml(strPath)

            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmCostearGeneralGridCostos" & PublicLoginInfo.LoginID & ".xml"
            GridViewCostos.SaveLayoutToXml(strPath)
        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub frmCostearGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String
        Try
            'verificamos el layout de la forma
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmCostearGeneralGridIngresos" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewIngresos.SaveLayoutToXml(strPath)
            End If
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmCostearGeneralGridCostos" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                GridViewCostos.SaveLayoutToXml(strPath)
            End If
            fn_llena_combos()
            fn_Llena_head()
        Catch ex As Exception
            MsgBox("Error al Cargar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub fn_llena_combos()

        Try
            'llenamos el combo de los clientes
            Dim dsClientes As New DataSet
            dsClientes = xClientsServ.SearchPartialClients("", "", pResult, PublicLoginInfo.Environment)
            If Not IsNothing(dsClientes) Then
                cmbClientes.DataSource = dsClientes.Tables(0)
                cmbClientes.PopulateViewColumns()
                cmbClientes.ValueMember = "CLIENT_CODE"
                cmbClientes.DisplayMember = "CLIENT_NAME"

                For i = 0 To cmbClientes.View.Columns.Count - 1
                    cmbClientes.View.Columns(i).Visible = False
                Next

                cmbClientes.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                cmbClientes.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                cmbClientes.View.Columns("CLIENT_CODE").Visible = True
                cmbClientes.View.Columns("CLIENT_NAME").Visible = True
                cmbClientes.View.BestFitColumns()

            End If

        Catch ex As Exception
            MsgBox("Error al llenar combos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub fn_Llena_head()
        Try
            Dim dsHead As New DataSet
            pResult = String.empty
            dsHead = xserv.get_all_Poliza_Headers(" Where warehouse_regimen = 'GENERAL' and status IN ('Created', 'COMPLETED', 'ON_PROCESS') AND TIPO = 'INGRESO' ", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                GridIngresos.DataSource = dsHead.Tables(0)
                GridViewIngresos.BestFitColumns()

            Else
                MsgBox(" Error al llenar el encabezado: " & pResult, MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GridIngresos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridIngresos.Click
       
            Try
            Dim dsDet
            If GridViewIngresos.SelectedRowsCount > 0 Then
                Dim xdatarow As DataRow = GridViewIngresos.GetDataRow(GridViewIngresos.FocusedRowHandle)

                If pCurrentDoc <> xdatarow("CODIGO_POLIZA").ToString() Then
                    If pCurrentDoc <> "" Then
                        If MessageBox.Show("Desea pasar a otra poliza, sin grabar la anterior (" + xdatarow("CODIGO_POLIZA").ToString() + ")", "WMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Exit Sub
                        End If
                    End If
                End If

                pCurrentDoc = xdatarow("CODIGO_POLIZA").ToString()
                dsDet = xserv.get_skus_tran_byPoliza(xdatarow("CODIGO_POLIZA").ToString(), PublicLoginInfo.Environment, pResult)

                If pResult = "OK" Then
                    If Not IsNothing(dsDet) Then
                        If dsDet.Tables(0).Rows.Count > 0 Then
                            GridCostos.DataSource = dsDet.Tables(0)
                            GridCostos.Refresh()
                            GridViewCostos.BestFitColumns()
                        Else
                            GridCostos.DataSource = Nothing
                            GridCostos.Refresh()
                        End If
                    Else
                        NotifyStatus(pResult, False, True)
                    End If
                Else
                    NotifyStatus(pResult, False, True)
                End If
            End If



        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)

        End Try
    End Sub

    Private Function fn_graba_Detalle(ByVal pDOC_ID As Integer, ByVal pSKU_DESCRIPTION As String, ByVal pSAC_CODE As String, ByVal pBULTOS As Integer, ByVal pCLASE As String _
    , ByVal pNET_WEIGTH As Double, ByVal pWEIGTH_UNIT As String, ByVal pQTY As Double, ByVal pCUSTOMS_AMOUNT As Double, ByVal pQTY_UNIT As String, ByVal pVOLUME As Double _
    , ByVal pVOLUME_UNIT As String, ByVal pDAI As Double, ByVal pIVA As Double, ByVal pMISC_TAXES As Double, ByVal pFOB_USD As Double, ByVal pFREIGTH_USD As Double _
    , ByVal pINSURANCE_USD As Double, ByVal pMISC_EXPENSES As Double, ByVal pORIGIN_COUNTRY As String, ByVal pREGION_CP As String, ByVal pAGREEMENT_1 As String _
    , ByVal pAGREEMENT_2 As String, ByVal pRELATED_POLIZA As String, ByVal pORIGIN_DOC_ID As Integer _
    , ByVal pCODIGO_POLIZA_ORIGEN As String, ByVal pCLIENT_CODE As String, ByVal pPCTDAI As Double, ByVal pORIGIN_LINE_NUMBER As Double, ByRef pLINE_NUMBER As Integer, ByVal pMATERIAL_ID As String) As Boolean
        Try
            If xserv.set_Poliza_Detail(pDOC_ID, pSKU_DESCRIPTION, pSAC_CODE, pBULTOS, pCLASE, pNET_WEIGTH, pWEIGTH_UNIT, pQTY, pCUSTOMS_AMOUNT, pQTY_UNIT,
                                    pVOLUME, pVOLUME_UNIT, pDAI, pIVA, pMISC_TAXES, pFOB_USD, pFREIGTH_USD, pINSURANCE_USD, pMISC_EXPENSES, pORIGIN_COUNTRY,
                                    pREGION_CP, pAGREEMENT_1, pAGREEMENT_2, pRELATED_POLIZA, PublicLoginInfo.LoginID, Date.Now(), pORIGIN_DOC_ID, pCODIGO_POLIZA_ORIGEN,
                                    pCLIENT_CODE, pPCTDAI, pORIGIN_LINE_NUMBER, PublicLoginInfo.Environment, pResult, pLINE_NUMBER, 0, pMATERIAL_ID) Then
                Return True
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

    Private Sub btnGrabar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGrabar.ItemClick
        Try

            Dim drHead As DataRow
            Dim drDet As DataRow
            Dim iR As Int16
            drHead = GridViewIngresos.GetFocusedDataRow
            xserv.del_ALL_POLIZA_LINES(Val(drHead("DOC_ID")), PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                For iR = 0 To GridViewCostos.RowCount - 1
                    drDet = GridViewCostos.GetDataRow(iR)
                    If fn_graba_Detalle(drHead("DOC_ID"), drDet("MATERIAL_CODE").ToString + "-" + drDet("MATERIAL_DESCRIPTION").ToString, "", Val(drDet("QUANTITY_UNITS")),
                                     "", 0, "", Val(drDet("QUANTITY_UNITS")), Val(drDet("MATERIAL_COST")), "UN", 0, "", 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", 0, "", drHead("CLIENT_CODE"), 0, 0, 0, drDet("MATERIAL_CODE").ToString) = False Then

                        Exit For
                    End If
                    NotifyStatus(" Grabado con Exito " + drDet("MATERIAL_CODE").ToString, False, False)
                Next
            Else
                NotifyStatus(pResult, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub fn_graba_head()
        Try
            'creamos variables para todos los campos que se deben validar o convertir de alguna manera.
            Dim _status, _acuerdoComercial, _regimenAlmacen, _codigPoliza, _IdPolizaAsegurada, _IdOperador As String
            Dim _fechaLlegada, _fechaDocumento As Date
            Dim _totalValorAduana, _tipoCambio, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd As Double
            Dim _totalSeguroUsd, _totalOtrosUsd, _totalLiquidar, _totalOtros, _totalGeneral As Double
            Dim _lastUpdated As Date
            Dim _docId, _numero_lineas, _modo, _totalBultos, _tipoContenedor As Integer

            If Not IsNothing(GridViewIngresos.GetFocusedRowCellValue("ACUERDO_COMERCIAL")) Then
                _acuerdoComercial = GridViewIngresos.GetFocusedRowCellValue("ACUERDO_COMERCIAL")
            Else
                _acuerdoComercial = ""
            End If

            If Not IsNothing(GridViewIngresos.GetFocusedRowCellValue("POLIZA_ASEGURADA")) Then
                _IdPolizaAsegurada = GridViewIngresos.GetFocusedRowCellValue("POLIZA_ASEGURADA")
            Else
                _IdPolizaAsegurada = ""
            End If

            If Not IsNothing(GridViewIngresos.GetFocusedRowCellValue("POLIZA_ASSIGNEDTO")) Then
                _IdOperador = GridViewIngresos.GetFocusedRowCellValue("POLIZA_ASSIGNEDTO")
            Else
                _IdOperador = ""
            End If



            _regimenAlmacen = "GENERAL"
            _status = "COSTED"


            Dim fechaformato As String
            Dim fecha As String
            fecha = GridViewIngresos.GetFocusedRowCellValue("FECHA_DOCUMENTO")
            fechaformato = Format(CDate(fecha), "dd/MM/yyyy")
            'MessageBox.Show("Formato: " + fechaformato)
            
            Date.TryParse(GridViewIngresos.GetFocusedRowCellValue("FECHA_DOCUMENTO"), _fechaDocumento)
            _fechaLlegada = _fechaDocumento
            Double.TryParse(GridViewIngresos.GetFocusedRowCellValue("DOC_ID"), _docId)
            _lastUpdated = Date.Now()
            If GridViewIngresos.GetFocusedRowCellValue("CODIGO_POLIZA").ToString.Length > 0 Then
                _codigPoliza = GridViewIngresos.GetFocusedRowCellValue("CODIGO_POLIZA").ToString
            Else
                _codigPoliza = "0"
            End If
            'grabamos el encabezado
            pResult = String.Empty
            If xserv.set_Poliza_Header(_codigPoliza, "", "", "", "", "", "", "",
                                    "", "", _modo, _fechaLlegada, _tipoCambio,
                                    _totalValorAduana, _numero_lineas, _totalBultos, _totalPesoBrutokg, _totalFobUsd, _totalFleteUsd,
                                    _totalSeguroUsd, _totalOtrosUsd, "", "", "", "", "", "", "", "", "", "", "", "", _tipoContenedor, "",
                                    "", "", _totalLiquidar, _totalOtros, _totalGeneral, _codigPoliza, PublicLoginInfo.LoginID, _lastUpdated,
                                    _status, GridViewIngresos.GetFocusedRowCellValue("CLIENT_CODE"), _regimenAlmacen, _fechaDocumento, _acuerdoComercial, "INGRESO", PublicLoginInfo.Environment, pResult, _docId, _IdPolizaAsegurada, _IdOperador, "NO", Nothing) Then

            Else
                MsgBox(pResult, MsgBoxStyle.Critical, "Error")
            End If

        Catch ex As Exception

            Throw New ApplicationException(ex.Message)

        Finally
            pResult = ""
        End Try
    End Sub

    Private Sub btnCosteo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCosteo.ItemClick
        Try
            If MessageBox.Show("!!! Esta accion es irreversible por favor revise que coloco el costo a todas las lineas ¡¡¡", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = MsgBoxResult.Yes Then
                fn_graba_head()

                fn_Llena_head()
                GridCostos.DataSource = Nothing
                GridCostos.Refresh()
            End If

        Catch ex As Exception
            NotifyStatus(" Error al grabar el encabezado", True, True)
        End Try
    End Sub

    Private Sub GridCostos_Click(sender As System.Object, e As System.EventArgs) Handles GridCostos.Click

    End Sub

    Private Sub GridCostos_Leave(sender As Object, e As System.EventArgs) Handles GridCostos.Leave

    End Sub

    Private Sub GridCostos_LostFocus(sender As Object, e As System.EventArgs) Handles GridCostos.LostFocus

    End Sub

    Private Sub GridViewCostos_LostFocus(sender As Object, e As System.EventArgs) Handles GridViewCostos.LostFocus

    End Sub
End Class
Imports System.Threading
Imports System.IO
Imports System.Data
Imports System.Text

Module ZebraPrinterModule
    Public Class ZebraPrinter

        Public Sub TestPrinter()

            Try
                Dim xstrmsg As [String] = "! 0 50 50 635 1 " & vbCr & vbLf
                xstrmsg += "! U1 LMARGIN 10" & vbCr & vbLf & "! U1 PAGE-WIDTH 1400" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 6 3 10 " & AppSettings.LICENSE_OWNER & vbCr & vbLf

                xstrmsg += "LINE 0 60 570 60 2" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 5 0 70 FISCAL" & vbCr & vbLf
                xstrmsg += "BARCODE 39 1 1 150 20 140 B11-R01-C01-NB" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 6 0 310 B11-R01-C01-NB" & vbCr & vbLf
                xstrmsg += "LINE 0 500 570 500 2" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 2 0 510 NOMBRE DEL USUARIO / FECHA Y HORA" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" & vbCr & vbLf

                xstrmsg += "L 5 T 0 2 0 130 " & vbCr & vbLf & "PRINT" & vbCr & vbLf

                bluetooth.Print(xstrmsg)

            Catch ex As Exception
                Notify(ex.Message, True)
            End Try

        End Sub
        Public Sub PrintLicense(ByVal pIsReprinted As Boolean, ByVal pLicenceID As Integer, ByVal pUseGlobalLicense As Boolean)

            Try
                If gDeviceAddress = "" Then
                    Notify("Debe seleccionar la impresora movil", True)
                    ShowPanel(panelSetupPrinter)
                    Exit Sub
                End If
                Dim servicio As New WMS_InfoTrans.WMS_InfoTrans

                Dim printRegimen As String = "" ' IIf((gCurrentTransactionType = gTRANS_TYPE.INICIALIZACION_GENERAL) Or (gCurrentTransactionType = gTRANS_TYPE.RECEPCION_ALMGEN), "GENERAL", "FISCAL")
                Dim pResult As String = ""

                Select Case gCurrentTransactionType
                    Case gTRANS_TYPE.REUBICACION_POR_REABASTECIMIENTO
                        Dim tabla As DataTable
                        tabla = servicio.ObtenerInformacionPickingNoInmediato(gWavePickingId, GlobalEnviroment, pResult)
                        If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                            printRegimen = If(tabla.Rows(0)("PROJECT").ToString.Length > 0, tabla.Rows(0)("PROJECT").ToString, tabla.Rows(0)("CLIENT_CODE").ToString)
                        Else
                            printRegimen = "GENERAL"
                        End If
                    Case Else
                        printRegimen = GetRegimenLincese(pLicenceID)
                End Select


                Dim xstrmsg As [String] = "! 0 50 50 635 1 " & vbCr & vbLf
                xstrmsg += "! U1 LMARGIN 10" & vbCr & vbLf & "! U1 PAGE-WIDTH 1400" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 6 3 10 " & AppSettings.LICENSE_OWNER & vbCr & vbLf
                '
                xstrmsg += "LINE 0 60 570 60 2" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 5 0 70 " & printRegimen & vbCr & vbLf

                If pUseGlobalLicense Then
                    xstrmsg += "BARCODE 39 1 1 150 20 140 " & gLicenseID & "-" & vbCr & vbLf
                    xstrmsg += "CENTER 570 T 0 6 0 310 " & gLicenseID & vbCr & vbLf
                Else
                    xstrmsg += "BARCODE 39 1 1 150 20 140 " & pLicenceID & "-" & vbCr & vbLf
                    xstrmsg += "CENTER 570 T 0 6 0 310 " & pLicenceID & vbCr & vbLf
                End If

                If pIsReprinted Then
                    xstrmsg += "CENTER 570 T 0 4 0 360 *REIMPRESION*" & vbCr & vbLf
                End If

                xstrmsg += "LINE 0 500 570 500 2" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 2 0 510 " & GlobalUserID & " " & servicio.GetServerDateTime() & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" & vbCr & vbLf

                xstrmsg += "L 5 T 0 2 0 130 " & vbCr & vbLf & "PRINT" & vbCr & vbLf

                bluetooth.Print(xstrmsg)

            Catch ex As Exception
                Notify(ex.Message, True)
            End Try

        End Sub

        Public Sub PrinterSku(ByVal pSKU As String, ByVal pSKUName As String, ByVal veces As Int32)
            Try
                Dim xserv As New WMS_InfoTrans.WMS_InfoTrans

                Dim xstrmsg As [String] = "! 0 50 50 635 " & veces & " " & vbCr & vbLf
                xstrmsg += "! U1 LMARGIN 10" & vbCr & vbLf & "! U1 PAGE-WIDTH 1400" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 6 3 10 " & AppSettings.LICENSE_OWNER & vbCr & vbLf
                '
                xstrmsg += "LINE 0 60 570 60 2" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 5 0 70 " & pSKUName & vbCr & vbLf
                xstrmsg += "BARCODE 128 1 1 150 20 140 " & pSKU & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 6 0 310 " & pSKU & vbCr & vbLf
                xstrmsg += "LINE 0 500 570 500 2" & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 2 0 510 " & GlobalUserID & " " & xserv.GetServerDateTime() & vbCr & vbLf
                xstrmsg += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" & vbCr & vbLf

                xstrmsg += "L 5 T 0 2 0 130 " & vbCr & vbLf & "PRINT" & vbCr & vbLf
                bluetooth.Print(xstrmsg)

            Catch ex As Exception
                Notify(ex.Message, True)
            End Try

        End Sub


        Public Sub ImprimirEtiquetaOperacion(ByVal subTipo As String, ByVal bodegaReferencia As String, _
                                           ByVal nombreUsuario As String, ByVal fechaImpresion As DateTime, _
                                           ByVal nombreCliente As String, ByVal codigoCliente As String, ByVal numeroTarea As String, _
                                           ByVal codigoPoliza As String, ByVal licenciaActual As String)

            Try
                Dim impresion As [String] = "! 0 50 50 635 1 " & vbCr & vbLf
                impresion += "! U1 LMARGIN 10" & vbCr & vbLf & "! U1 PAGE-WIDTH 1400" & vbCr & vbLf
                impresion += "CENTER 570 T 0 5 3 10 " & subTipo & vbCr & vbLf
                impresion += "LINE 0 60 570 60 2" & vbCr & vbLf
                impresion += "CENTER 570 T 0 5 0 80 " & "" & If(licenciaActual = String.Empty, String.Empty, "" & licenciaActual) & " " & If(numeroTarea = String.Empty, String.Empty, "" & numeroTarea) & " " & vbCr & vbLf
                impresion += "BARCODE 39 1 1 150 20 140 " & codigoPoliza & vbCr & vbLf
                impresion += "CENTER 570 T 0 2 0 300 " & codigoPoliza & vbCr & vbLf
                If bodegaReferencia <> String.Empty Then
                    impresion += "CENTER 570 T 0 5 0 335 " & bodegaReferencia & vbCr & vbLf
                End If
                impresion += "CENTER 570 T 0 5 0 400 " & codigoCliente & " " & vbCr & vbLf
                impresion += "CENTER 570 T 0 3 0 470 " & nombreCliente & " " & vbCr & vbLf
                impresion += "LINE 0 500 570 500 2" & vbCr & vbLf
                impresion += "CENTER 570 T 0 2 0 510 " & GlobalUserID & " " & fechaImpresion & vbCr & vbLf
                impresion += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" & vbCr & vbLf
                impresion += "L 5 T 0 2 0 130 " & vbCr & vbLf & "PRINT" & vbCr & vbLf
                bluetooth.Print(impresion)

            Catch ex As Exception
                Notify(ex.Message, True)
            Finally

            End Try


        End Sub
        Public Sub ImprimirEtiquetaDeListo(ByVal tipoDeDocumento As String, ByVal motivoDeTransaccion As String, ByVal fechaDeTransaccion As String, ByVal operador As String, ByVal codigoDeCliente As String, ByVal nombreDeCliente As String)

            Try
                Dim zpl As String = ""
                zpl += "! 0 50 50 630 1 " & vbCr & vbLf
                zpl += "CENTER 550 T 1 2 0 10 " + tipoDeDocumento & " " & vbCr & vbLf
                zpl += "a " & vbCr & vbLf
                zpl += "LEFT 5 " & vbCr & vbLf
                zpl += "T 7 0 5 85 " & motivoDeTransaccion & " " & vbCr & vbLf
                zpl += "LEFT 5 " & vbCr & vbLf
                zpl += "T 7 0 5 170 " & fechaDeTransaccion & " " & vbCr & vbLf
                zpl += "LEFT 5 " & vbCr & vbLf
                zpl += "T 7 0 5 255 " & operador & " " & vbCr & vbLf
                zpl += "LEFT 5 " & vbCr & vbLf
                zpl += "T 7 0 5 340 " & codigoDeCliente & " " & vbCr & vbLf
                zpl += "LEFT 5 " & vbCr & vbLf
                zpl += "T 7 0 5 425 " & nombreDeCliente & " " & vbCr & vbLf
                zpl += "PRINT " & vbCr & vbLf

                bluetooth.Print(zpl)

            Catch ex As Exception
                Notify(ex.Message, True)
            End Try
        End Sub

        Public Sub PrintStatusByMaterial(ByVal codeStatus As String, ByVal login As String, ByVal taskId As Integer, ByVal codeClient As String)


            Try
                Dim xClientsServ As New WMS_Clients.WMS_Clients
                Dim serverInfoTrans As New WMS_InfoTrans.WMS_InfoTrans
                Dim serverSetting As New WMS_Settings.WMS_Settings
                Dim dsSetting As DataSet
                Dim pResult As String = ""
                Dim supplier As String = ""
                Dim labelSupplier As String = " Proveedor: "
                Dim countLineSupplier As Integer = 25
                Dim nameStatus As String = String.Empty
                Dim description As String = ""
                Dim printDate As Date = Now
                Dim result As String = String.Empty
                Dim dt As DataTable
                Dim statusLock As String = String.Empty

                dsSetting = serverSetting.GetParam_ByParamKey("ESTADO", "ESTADOS", codeStatus, pResult, GlobalEnviroment)

                If pResult.ToUpper.Equals("OK") Then
                    nameStatus = dsSetting.Tables(0).Rows(0)("PARAM_CAPTION")
                    description = dsSetting.Tables(0).Rows(0)("TEXT_VALUE")
                    statusLock = dsSetting.Tables(0).Rows(0)("SPARE1")
                Else
                    Exit Sub
                End If

                dt = serverInfoTrans.GetSupplierByDocument(taskId, GlobalEnviroment, result)

                If result.ToUpper.Equals("OK") Then

                    If ValidatedSupplier(dt) Then
                        supplier = dt.Rows(0)("NAME_SUPPLIER")
                    Else
                        Dim dsClient As New DataSet
                        result = String.Empty
                        dsClient = xClientsServ.SearchPartialClients(codeClient, "", result, GlobalEnviroment)
                        supplier = dsClient.Tables(0).Rows(0)("CLIENT_NAME")
                        labelSupplier = " Cliente: "
                        countLineSupplier = 28
                    End If


                    Dim print As [String] = "! 0 50 50 635 1 " & vbCr & vbLf
                    print += "! U1 LMARGIN 10" & vbCr & vbLf & "! U1 PAGE-WIDTH 1400" & vbCr & vbLf
                    print += "LEFT 570 T 0 3 3 20 Estado: " + nameStatus & vbCr & vbLf
                    print += "LEFT 570 T 0 3 0 70 Fecha y Hora: " & printDate.ToString("dd/MM/yyyy hh:mm tt") & " " & vbCr & vbLf
                    print += "LEFT 570 T 0 3 0 120 Operador: " & GlobalUserID & vbCr & vbLf

                    Dim lineNumber As Integer = 170
                    If NumberOfCharactersIsEqualToOrLess(supplier.Count, 25) Then
                        print += "LEFT 570 T 0 3 0 " + lineNumber.ToString + labelSupplier & supplier & vbCr & vbLf
                        lineNumber += 50
                    Else

                        Dim count As Integer = Math.Ceiling(supplier.Count / countLineSupplier)
                        Dim initialIndex As Integer = countLineSupplier
                        For i As Integer = 0 To count - 1
                            print += "LEFT 570 T 0 3 0 " + lineNumber.ToString + IIf(i = 0, labelSupplier, " ") & Mid(supplier, initialIndex - (countLineSupplier - 1), IIf((i + 1 = count), supplier.Count, initialIndex)) & vbCr & vbLf
                            lineNumber += 50
                            initialIndex += countLineSupplier
                        Next
                    End If

                    If NumberOfCharactersIsEqualToOrLess(description.Count, 22) Then
                        print += "LEFT 570 T 0 3 0 " + lineNumber.ToString + " Descripción: " & description & vbCr & vbLf
                        lineNumber += 50
                    Else
                        Dim count As Integer = Math.Ceiling(description.Count / 22)
                        Dim initialIndex As Integer = 22
                        For i As Integer = 0 To count - 1
                            print += "LEFT 570 T 0 3 0 " + lineNumber.ToString + IIf(i = 0, " Descripción: ", " ") & Mid(description, initialIndex - 21, IIf((i + 1 = count), description.Count, initialIndex)) & vbCr & vbLf
                            lineNumber += 50
                            initialIndex += 22
                        Next
                    End If

                    If ValidatedInventoryLock(statusLock) Then
                        print += "CENTER 570 T 0 5 0 " + lineNumber.ToString + " Inventario Bloqueado " & vbCr & vbLf
                        lineNumber += 50
                    End If

                    print += "CENTER 570 T 0 2 0 520 www.mobilityscm.com" & vbCr & vbLf
                    print += "L 5 T 0 2 0 130 " & vbCr & vbLf & "PRINT" & vbCr & vbLf

                    bluetooth.Print(print)
                Else
                    Notify(result, True)
                End If
            Catch ex As Exception
                Notify(ex.Message, True)
            End Try
        End Sub

        Public Sub PrintLabel(ByVal clientCode As String, ByVal clientName As String, ByVal regimen As String, ByVal label_id As Integer, ByVal state_code As String, ByVal wavePickingId As String)

            Try
                Dim printDate As Date = Now
                Dim print As [String] = "! 0 50 50 635 1 " & vbCr & vbLf
                print += "! U1 LMARGIN 10" & vbCr & vbLf & "! U1 PAGE-WIDTH 1400" & vbCr & vbLf
                print += "CENTER 570 T 0 5 3 10 " & clientName & vbCr & vbLf
                print += "CENTER 570 T 0 5 3 60 " & clientCode & vbCr & vbLf
                print += "LINE 0 100 570 100 2" & vbCr & vbLf
                print += "CENTER 570 T 0 5 0 115 " & "" & regimen & " " & vbCr & vbLf
                print += "BARCODE 39 1 1 160 20 160 " & label_id & vbCr & vbLf
                print += "CENTER 570 T 0 3 0 340 Codigo Etiqueta: " & label_id & vbCr & vbLf
                If Not String.IsNullOrEmpty(wavePickingId) Then
                    print += "CENTER 570 T 0 5 0 370 T: " & wavePickingId & " " & vbCr & vbLf
                End If
                If Not String.IsNullOrEmpty(state_code) Then
                    print += "CENTER 570 T 0 5 0 410 Departamento: " & state_code & " " & vbCr & vbLf
                End If
                print += "LINE 0 500 570 500 2" & vbCr & vbLf
                print += "CENTER 570 T 0 2 0 510 " & GlobalUserID & " " & printDate.ToString("dd/MM/yyyy hh:mm tt") & vbCr & vbLf
                print += "CENTER 570 T 0 1 0 550 www.mobilityscm.com" & vbCr & vbLf
                print += "L 5 T 0 2 0 130 " & vbCr & vbLf & "PRINT" & vbCr & vbLf
                bluetooth.Print(print)
            Catch ex As Exception
                Notify(ex.Message, True)
            End Try
        End Sub



        Private Function ValidatedSupplier(ByVal dt As DataTable) As Boolean
            Return (dt.Rows.Count > 0 AndAlso dt.Rows(0)("NAME_SUPPLIER") IsNot Nothing AndAlso Not (IsDBNull(dt.Rows(0)("NAME_SUPPLIER"))))
        End Function

        Private Function ValidatedInventoryLock(ByVal status As String) As Boolean
            Return (status.ToUpper.Equals("SI") Or status.Equals("1"))
        End Function

        Private Function NumberOfCharactersIsEqualToOrLess(ByVal numberOfCharacters As Integer, ByVal maximumNumberOfCharacters As Integer) As Boolean
            Return numberOfCharacters <= maximumNumberOfCharacters
        End Function

        Private Function GetRegimenLincese(ByVal license As Integer)
            Try
                Dim servicio As New WMS_InfoTrans.WMS_InfoTrans
                Return servicio.ObtenerValorProyectoEnBaseALicencia(license, GlobalEnviroment)
            Catch ex As Exception
                Notify(ex.Message, True)
                Return "GENERAL"
            End Try
        End Function

    End Class
End Module

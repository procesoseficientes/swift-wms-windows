Imports MobilityScm.Keyboard
Imports System.Data

Public Class MaterialXSerialNumbers

    Public numeroDeSeriesIngresadas As Integer = 0
    Dim numeroLote As String = String.Empty
    Dim fechaDeLote As Date = Date.Now

    Public Sub CargarInformacion(ByVal codigoMaterial As String, ByVal descripcionMaterial As String, ByVal manejaLote As Boolean)
        Try
            LimpiarControles()
            UiTextoIngresoSerieMaterial.Tag = codigoMaterial
            UiTextoIngresoSerieMaterial.Text = descripcionMaterial
            UiTextoIngresoSerieLote.Visible = manejaLote
            UiFechaIngresoSerieFechaLote.Visible = manejaLote
            CargarSiLicenciaDeProducto()
            If UiTextoIngresoSerieLote.Visible Then
                UiTextoIngresoSerieLote.SetFocus()
                CargarInformacionDeLote()
            Else
                UiTextoIngresoSerieNumeroSerie.SetFocus()
            End If
        Catch ex As Exception
            Notify("Error al cargar la pantalla: " + ex.Message, True)
        End Try
    End Sub

    Private Sub CargarInformacionDeLote()
        Try
            Dim servicioWebPolizas As New WMS_Polizas.WMS_Polizas
            Dim tabla As Data.DataTable
            Dim resultado As String = ""

            tabla = servicioWebPolizas.ObtienerInformacionPorMaterialSerie(UiTextoIngresoSerieMaterial.Tag, "", gLicenseID, resultado, GlobalEnviroment)

            If MostrarErrorDeWebService(resultado) Then
                Return
            End If

            If tabla.Rows.Count > 0 Then
                UiTextoIngresoSerieLote.Text = tabla.Rows(0)("BATCH")
                UiFechaIngresoSerieFechaLote.Value = tabla.Rows(0)("DATE_EXPIRATION")
                numeroLote = UiTextoIngresoSerieLote.Text
                fechaDeLote = Convert.ToDateTime(UiFechaIngresoSerieFechaLote.Value).Date
            End If

        Catch ex As Exception
            Notify("Error al cargar lote: " + ex.Message, True)
        End Try
    End Sub

    Private Sub LimpiarControles()
        Try
            UiTextoIngresoSerieMaterial.Tag = ""
            UiTextoIngresoSerieMaterial.Text = "..."
            UiTextoIngresoSerieLote.Text = ""
            UiFechaIngresoSerieFechaLote.Value = Date.Today
            UiTextoIngresoSerieNumeroSerie.Text = ""
            UiTextoIngresoSerieSerieAnterior.Label = "Cant. 0/Serie Anterior"
            UiTextoIngresoSerieSerieAnterior.Text = ""
            numeroDeSeriesIngresadas = 0
            numeroLote = String.Empty
            fechaDeLote = Date.Now
        Catch ex As Exception
            Notify("Error al limpiar la pantalla: " + ex.Message, True)
        End Try
    End Sub

    Private Sub MaterialXSerialNumbers_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub UiVistaDetalleIngresoSeries_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UiVistaDetalleIngresoSeries.KeyUp
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    If validarIngreso() Then
                        ValidarNumeroDeSerie()
                    End If
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    UsuarioDeseaSalirDePantalla()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub UsuarioEscaneoNumeroDeSerie(ByVal codigoMaterial As String)
        Try
            UiTextoIngresoSerieNumeroSerie.Text = codigoMaterial
            If validarIngreso() Then
                ValidarNumeroDeSerie()
            End If
        Catch ex As Exception
            Notify("Error al escanear el número de serie: " + ex.Message, True)
        End Try
    End Sub

    Private Function validarIngreso() As Boolean
        Try
            Dim resultado As Boolean = True
            If UiTextoIngresoSerieLote.Visible Then
                If String.IsNullOrEmpty(UiTextoIngresoSerieLote.Text) Then
                    Notify("Ingrese el número de lote.", True)
                    UiTextoIngresoSerieLote.SetFocus()
                    resultado = False
                End If
            End If
            If String.IsNullOrEmpty(UiTextoIngresoSerieNumeroSerie.Text) Then
                Notify("Ingrese el número de serie", True)
                UiTextoIngresoSerieNumeroSerie.SetFocus()
                resultado = False
            End If

            If UiTextoIngresoSerieLote.Visible And Not String.IsNullOrEmpty(numeroLote) Then
                If Not numeroLote.ToUpper.Equals(UiTextoIngresoSerieLote.Text.ToUpper) Or Not Convert.ToDateTime(UiFechaIngresoSerieFechaLote.Value).Date = fechaDeLote.Date Then
                    Return MensajeDeConfirmacion(String.Format("Cambio el lote o fecha expiración, esto actualizara todas las series ingresadas. Desea continuar?"))
                End If
            End If

            Return resultado
        Catch ex As Exception
            Notify("Error al validar el ingreso: " + ex.Message, True)
            Return False
        End Try
    End Function

    Private Sub ValidarNumeroDeSerie()
        Try
            Dim servicioWebPolizas As New WMS_Polizas.WMS_Polizas
            Dim tabla As Data.DataTable
            Dim resultado As String = ""

            If UiTextoIngresoSerieNumeroSerie.Text.Trim() = String.Empty Then
                Return
            End If

            tabla = servicioWebPolizas.ObtienerInformacionPorMaterialSerie(UiTextoIngresoSerieMaterial.Tag, UiTextoIngresoSerieNumeroSerie.Text, gLicenseID, resultado, GlobalEnviroment)
            If MostrarErrorDeWebService(resultado) Then
                Return
            End If

            If tabla.Rows.Count > 0 Then
                If MensajeDeConfirmacion(String.Format("El número de serie ya fue escaneado, Desea borrarlo?{0}", tabla.Rows(0)("SERIAL"))) Then
                    resultado = ""
                    If servicioWebPolizas.EliminarSerie(tabla.Rows(0)("CORRELATIVE"), resultado, GlobalEnviroment) Then
                        UiTextoIngresoSerieNumeroSerie.Text = ""
                        numeroDeSeriesIngresadas -= 1
                        UiTextoIngresoSerieSerieAnterior.Label = "Cant. " + numeroDeSeriesIngresadas.ToString + "/Serie Anterior"
                    Else
                        If MostrarErrorDeWebService(resultado) Then
                            Return
                        End If
                    End If
                End If
            Else
                If servicioWebPolizas.AgregarSeriePorMaterial(gLicenseID, UiTextoIngresoSerieMaterial.Tag, UiTextoIngresoSerieNumeroSerie.Text, IIf(UiTextoIngresoSerieLote.Visible, UiTextoIngresoSerieLote.Text, Nothing), IIf(UiTextoIngresoSerieLote.Visible, UiFechaIngresoSerieFechaLote.Value, Nothing), resultado, GlobalEnviroment) Then
                    UiTextoIngresoSerieSerieAnterior.Text = UiTextoIngresoSerieNumeroSerie.Text
                    UiTextoIngresoSerieNumeroSerie.Text = ""
                    numeroDeSeriesIngresadas += 1
                    UiTextoIngresoSerieSerieAnterior.Label = "Cant. " + numeroDeSeriesIngresadas.ToString + "/Serie Anterior"
                Else
                    If MostrarErrorDeWebService(resultado) Then
                        Return
                    End If
                End If
            End If

            numeroLote = UiTextoIngresoSerieLote.Text
            fechaDeLote = Convert.ToDateTime(UiFechaIngresoSerieFechaLote.Value).Date

        Catch ex As Exception
            Notify("Error al validar el número de serie: " + ex.Message, True)
        End Try
    End Sub

    Sub UsuarioPresionoTecla(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Sub UsuarioDeseaSalirDePantalla()
        Try
            gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
            With panelTransHandler.DetailView1
                .Items("txtCantidad").Text = numeroDeSeriesIngresadas
            End With
            If numeroDeSeriesIngresadas > 0 Then
                SaveSKULicense()
            End If
            ShowPanel(panelTransHandler)
            LimpiarControles()

        Catch ex As Exception
            Notify("Error al salir de pantalla: " + ex.Message, True)
        End Try
    End Sub

    Private Function MostrarErrorDeWebService(ByVal resultado As String) As Boolean
        If Not String.IsNullOrEmpty(resultado) Then
            Notify("Error al validar el número de serie: " + resultado, True)
            Return True
        End If
        Return False
    End Function

    Private Sub CargarSiLicenciaDeProducto()
        Try
            Dim resultado As String = ""
            Dim servicioWebInformacionInventario As New WMS_InfoInventory.WMS_InfoInventory
            Dim ds As DataSet
            ds = servicioWebInformacionInventario.GET_INV_X_LIC(gLicenseID, GlobalUserID, "*", resultado, GlobalEnviroment)

            If ds Is Nothing Then
                Return
            End If

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If ds.Tables(0).Rows(i)("MATERIAL_ID").ToString.Equals(UiTextoIngresoSerieMaterial.Tag.ToString) Then
                    UiTextoIngresoSerieSerieAnterior.Label = "Cant. " + ds.Tables(0).Rows(i)("QTY").ToString + "/Serie Anterior"
                    numeroDeSeriesIngresadas = ds.Tables(0).Rows(i)("QTY")
                    Exit For
                End If
            Next
        Catch ex As Exception
            Notify("Error al obtener la información de la licencia: " + ex.Message, True)
        End Try
    End Sub
End Class

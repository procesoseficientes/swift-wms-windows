Imports MobilityScm.Keyboard

Public Class SerialNumberProcess
    Private dtSeries As New Data.DataTable("SERIES")
    Public materialId = String.Empty
    Private esDiscrecional = False
    Private cantidadDeSeriesEscaneadas = 0
    Private cantidadDeSeriesAEscanear = 0
    Public tipoTarea = String.Empty


#Region "Eventos de Controles"

    Private Sub UiBotonConsultarSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UiBotonConsultarSeries.Click
        UiListaSeriesDiscrecional.Visible = Not UiListaSeriesDiscrecional.Visible
    End Sub

    Private Sub SerialNumberProcess_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp, UiVistaDetalleIngresoSeries.KeyUp, UiListaSeriesDiscrecional.KeyUp, UiBotonConsultarSeries.KeyUp
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    IngresoManualDeSerie()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    RegresarAPantalla()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

#End Region

#Region "Metodos"

    Private Sub IngresoManualDeSerie()
        Try
            If Not String.IsNullOrEmpty(UiTextoSerie.Text) Then
                IngresarDeSerie(UiTextoSerie.Text.ToUpper)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub MostrarBotonConsultaDeSeries(ByVal mostrar As Boolean, ByVal cantidadDeSeries As Integer, ByVal material As String)
        UiListaSeriesDiscrecional.Visible = False
        UiBotonConsultarSeries.Visible = mostrar
        esDiscrecional = mostrar
        cantidadDeSeriesAEscanear = cantidadDeSeries
        materialId = material
        UiTextoMaterial.Text = materialId
        If mostrar Then
            LlenarListadoSeries()
        Else
            dtSeries.Rows.Clear()
        End If
    End Sub

    Private Function ValidarSiExisteLaSerieParaDiscrecional(ByVal numeroSerie As String) As Boolean
        For Each row As Data.DataRow In dtSeries.Rows
            If row("SERIAL") = numeroSerie Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub LlenarListadoSeries()
        Try
            Dim resultado = String.Empty
            Dim servicioTrans = New WMS_Trans.WMS_Trans
            dtSeries = servicioTrans.GetRequestedSerialNumberDiscretionalPickingByLicense(gCurrentWavePicking, gCurrentLicenseID, materialId, GlobalEnviroment, resultado)
            If String.IsNullOrEmpty(resultado) Then
                UiListaSeriesDiscrecional.DataSource = dtSeries
            Else
                Notify(resultado, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub IngresarDeSerie(ByVal numeroSerie As String)
        Try
            If esDiscrecional Then
                If Not ValidarSiExisteLaSerieParaDiscrecional(numeroSerie) Then
                    Notify("La serie escaneada no es valida.", True)
                    Exit Sub
                End If
            End If
            Dim resultado = String.Empty
            Dim servicioTrans = New WMS_Trans.WMS_Trans
            Dim dt = servicioTrans.UpdateScannedSerialNumberToProcess(numeroSerie, gCurrentLicenseID, gCurrentWavePicking, materialId, GlobalUserID, tipoTarea, GlobalEnviroment, resultado)
            If String.IsNullOrEmpty(resultado) Then
                Select Case dt.Rows(0)("Resultado")
                    Case ResultadoOperacionTipo.Fallo
                        Notify(dt.Rows(0)("Mensaje"), True)
                    Case ResultadoOperacionTipo.Duplicado
                        EliminarSerie(numeroSerie)
                    Case ResultadoOperacionTipo.Exito
                        UiTextoSerie.Text = ""
                        cantidadDeSeriesEscaneadas = Integer.Parse(dt.Rows(0)("DbData").ToString)
                        UiTextoUltimaSerie.Label = String.Format("Cant. {0}/Serie Anterior", dt.Rows(0)("DbData"))
                        UiTextoUltimaSerie.Text = numeroSerie
                End Select
            Else
                Notify(resultado, True)
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub EliminarSerie(ByVal numeroSerie As String)
        Try
            If MensajeDeConfirmacion("La serie ingresada ya fue ingresada. Desea eliminarla?") Then
                Dim resultado = String.Empty
                Dim servicioTrans = New WMS_Trans.WMS_Trans
                Dim dt = servicioTrans.UpdateSetActiveSerialNumber(numeroSerie, gCurrentLicenseID, materialId, gCurrentWavePicking, GlobalUserID, tipoTarea, GlobalEnviroment, resultado)

                If String.IsNullOrEmpty(resultado) Then
                    Select Case dt.Rows(0)("Resultado")
                        Case ResultadoOperacionTipo.Fallo
                            Notify(dt.Rows(0)("Mensaje"), True)
                        Case ResultadoOperacionTipo.Exito
                            UiTextoSerie.Text = ""
                            cantidadDeSeriesEscaneadas = Integer.Parse(dt.Rows(0)("DbData").ToString)
                            UiTextoUltimaSerie.Label = String.Format("Cant. {0}/Serie Anterior", dt.Rows(0)("DbData"))
                            UiTextoUltimaSerie.Text = numeroSerie
                    End Select
                Else
                    Notify(resultado, True)
                End If
            End If
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub RegresarAPantalla()
        Try
            Select Case tipoTarea
                Case "DESPACHO_GENERAL"
                    RegresarAPantallaDePickingDesdeSerie(cantidadDeSeriesEscaneadas)
                Case "REUBICACION_PARCIAL"
                    RegresarAPantallaDeUbicacionDesdeSerie(cantidadDeSeriesEscaneadas)
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub LimpiarVariables()
        Try
            cantidadDeSeriesEscaneadas = 0
            UiTextoUltimaSerie.Label = "Cant. 0/Serie Anterior"
            UiTextoSerie.Text = ""
            UiTextoUltimaSerie.Text = ""
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

#End Region
End Class

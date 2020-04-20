Imports Resco.Controls.MessageBox
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard


Public Class ctrl_acuse_recibo

    Private Sub btnPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPhoto.Click
        ShowPanel(panelTomarFoto)
        panelTomarFoto.Handheld = gHandheld
        RemoveHandler panelTomarFoto.Controls(0).KeyUp, AddressOf TomarFoto_KeyUp
        RemoveHandler panelTomarFoto.Controls(1).KeyUp, AddressOf TomarFoto_KeyUp
        AddHandler panelTomarFoto.Controls(0).KeyUp, AddressOf TomarFoto_KeyUp
        AddHandler panelTomarFoto.Controls(1).KeyUp, AddressOf TomarFoto_KeyUp
    End Sub

    Private Sub TomarFoto_KeyUp(ByVal sender As System.Object, ByVal e As Windows.Forms.KeyEventArgs)
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                ShowPanel(panelAcuseRecibo)
        End Select
        
    End Sub

    Sub btn_Satis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Satis.Click
        If Validar() Then
            Grabar("SATISFACTORIO")
        End If

    End Sub

    Private Sub btnDis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDis.Click
        If Validar() Then
            Grabar("DISCREPANCIA")
        End If
    End Sub

    Private Sub Grabar(ByVal pStatus As String)
        Resco.Controls.MessageBox.MessageBoxEx.Settings.AutoDefaultResult = False
        Resco.Controls.MessageBox.MessageBoxEx.Settings.Background = Color.Green
        Dim pText() As String = {"SI", "NO"}
        If MessageBoxEx.ShowYesCancel("Confirma finalizar?", True, pText) Then
            Try
                Dim result As String = ""
                Dim servTrans As New WMS_Trans.WMS_Trans
                If servTrans.CreateAcuseRecibo(txtScanPoliza.Text, txtFob.Text, DateTime.Today.AddMinutes(-30), txtCodigoTransporte.Text, txtPlacaTransporte.Text, txtNoContenedor.Text, txtNoMarchamo.Text, GlobalUserID, panelTomarFoto.FotoNumeroUno, panelTomarFoto.FotoNumeroDos, panelTomarFoto.FotoNumeroTres, pStatus, result, GlobalEnviroment) Then
                    If result = "OK" Then
                        ShowPanel(panelMenu)
                    Else
                        Notify(result, True)
                    End If
                Else
                    Notify(result, True)
                End If
            Catch ex As Exception
                Notify(ex.Message, True)
            End Try
        End If
    End Sub

    Private Sub DetailView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DetailView1.KeyUp
        ProcessLastKey(e)
    End Sub

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    panelTomarFoto.LimpiarImgVista()
                    panelTomarFoto.NumeroDeFotos = 0
                    panelTomarFoto.Fotos(0) = Nothing
                    panelTomarFoto.Fotos(1) = Nothing
                    panelTomarFoto.Fotos(2) = Nothing
                    ShowPanel(panelMenu)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub TextosFoscuas(ByVal pNameButon As String)
        Select Case pNameButon

            Case "txtScanPoliza"
                txtFob.SetFocus()
            Case "txtFob"
                txtFob.SetFocus()
            Case "txtCodigoTransporte"
                txtPlacaTransporte.SetFocus()
            Case "txtPlacaTransporte"
                txtNoContenedor.SetFocus()
            Case "txtNoContenedor"
                txtNoMarchamo.SetFocus()
            Case "txtNoMarchamo"
                txtScanPoliza.SetFocus()

        End Select
    End Sub

    Private Sub ctrl_acuse_recibo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Function Validar() As Boolean

        Dim paso As Boolean = True
        txtPlacaTransporte.TextBackColor = Color.Transparent
        txtNoContenedor.TextBackColor = Color.Transparent
        txtNoMarchamo.TextBackColor = Color.Transparent
        txtFob.TextBackColor = Color.Transparent
        txtScanPoliza.TextBackColor = Color.Transparent
        txtCodigoTransporte.TextBackColor = Color.Transparent

        If txtScanPoliza.Text = "" Then
            txtScanPoliza.TextBackColor = Color.Red
            txtScanPoliza.SetFocus()
            paso = False
        End If

        If txtFob.Text = "" Then
            txtFob.TextBackColor = Color.Red
            txtFob.SetFocus()
            paso = False
        Else
            Dim declaracionesPol As String() = txtScanPoliza.Text.Split(",")
            Dim declaracionesFob As String() = txtFob.Text.Split(",")

            Dim valDec As Boolean = declaracionesFob.All(Function(item) IsNumeric(item))

            If Not valDec Then
                Notify("Fob Dolares es campo numerico.", True)
                txtFob.TextBackColor = Color.Red
                paso = False
            End If

            If Not declaracionesPol.Count() = declaracionesFob.Count() Then
                Notify("Las polizas y fob dolares, no tiene la misma cantidad de datos", True)
                txtScanPoliza.TextBackColor = Color.Red
                txtFob.TextBackColor = Color.Red
                paso = False
            End If
        End If


        If txtCodigoTransporte.Text = "" Then
            txtCodigoTransporte.TextBackColor = Color.Red
            txtCodigoTransporte.SetFocus()
            paso = False
        End If

        If txtPlacaTransporte.Text = "" Then
            txtPlacaTransporte.TextBackColor = Color.Red
            txtPlacaTransporte.SetFocus()
            paso = False
        End If

        If txtNoContenedor.Text = "" Then
            txtNoContenedor.TextBackColor = Color.Red
            txtNoContenedor.SetFocus()
            paso = False
        End If

        If txtNoMarchamo.Text = "" Then
            txtNoMarchamo.TextBackColor = Color.Red
            txtNoMarchamo.SetFocus()
            paso = False
        Else
            Dim transportistaPlaca As String() = txtPlacaTransporte.Text.Split(",")
            Dim transportistaContenedor As String() = txtNoContenedor.Text.Split(",")
            Dim transportistaMarc As String() = txtNoMarchamo.Text.Split(",")

            If Not transportistaPlaca.Count() = transportistaContenedor.Count() Or Not transportistaPlaca.Count() = transportistaMarc.Count() Or Not transportistaContenedor.Count() = transportistaMarc.Count() Then
                Notify("Las placas de transport, números de contenedor y número de marchamo, no tiene la misma cantidad de datos", True)
                txtPlacaTransporte.TextBackColor = Color.Red
                txtNoContenedor.TextBackColor = Color.Red
                txtNoMarchamo.TextBackColor = Color.Red
                paso = False
            End If
        End If

        Return paso
    End Function
End Class


Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Public Class ctrl_RECFIS_LogisInfo

    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                    Cursor.Current = Cursors.Default
                    panelRecFiscalStep1.txtQTY.Focus()
                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                    ShowPanel(panelRecFiscalStep1)
                    gHasLogisticInfo = False
                    Me.txtVolumen.Text = ""
                    Me.txtSerie.Text = ""
                    Me.txtPeso.Text = ""
                    Me.txtComments.Text = ""
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                    gHasLogisticInfo = True
                    SaveSKULicense()
                    Cursor.Current = Cursors.Default
                    panelRecFiscalStep1.txtQTY.Focus()
                    ShowPanel(panelRecFiscalStep1)
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Private Sub txtComments_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtComments.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub ctrl_RECFIS_LogisInfo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        ProcessLastKey(e)
    End Sub

    Private Sub txtVolumen_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVolumen.KeyUp
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                txtPeso.SelectAll()
                txtPeso.Focus()
            Case Else
                ProcessLastKey(e)
        End Select
    End Sub
    Private Sub txtSerie_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerie.KeyUp
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                txtComments.SelectAll()
                txtComments.Focus()
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                ProcessLastKey(e)
        End Select
    End Sub

    Private Sub txtPeso_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPeso.KeyUp
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                txtSerie.SelectAll()
                txtSerie.Focus()
            Case Else
                ProcessLastKey(e)
        End Select

    End Sub


    Private Sub txtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerie.TextChanged

    End Sub

    Private Sub txtComments_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtComments.TextChanged

    End Sub
End Class

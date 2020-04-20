Public Class frmIngresoAutorizationSyncSat

    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim pResult As String = String.Empty

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Grabar()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub LimpiarControles()
        txtNumCliente.Text = ""
        txtNombreCliente.Text = ""
    End Sub

    Private Sub Grabar()
        Try
            If String.IsNullOrEmpty(txtNumCliente.Text) Then
                NotifyStatus("Busque la poliza antes de grabar.", True, True)
                txtPoliza.Focus()
            Else
                Dim grabo As Boolean
                grabo = xserv.Create_Autorization_Sat(txtPoliza.Text, Integer.Parse(txtNumCliente.Text), PublicLoginInfo.Environment, pResult)
                If grabo Then
                    If pResult = "OK" Then
                        NotifyStatus("Se grabo existosamente", True, False)
                        Me.DialogResult = DialogResult.OK
                        Close()
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Function ValidarPoliza() As Boolean
        Try

            Dim dsData As New DataSet
            dsData = xserv.Exist_Autorization_Sat(txtPoliza.Text, PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsData.Tables(0).Rows.Count = 0 Then
                    btnAceptar.Focus()
                    Return True
                Else
                    btnBuscar.Focus()
                    Select Case Integer.Parse(dsData.Tables(0).Rows(0)(0).ToString)
                        Case 1
                            NotifyStatus("Poliza ya fue grabada.", True, True)
                        Case 2
                            NotifyStatus("Poliza fue validada por la SAT.", True, True)
                        Case 3
                            NotifyStatus("Poliza ya fue enviada.", True, True)
                    End Select
                    Return False
                End If
            Else
                NotifyStatus(pResult, True, True)
                Return False
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
            Return False
        End Try
    End Function

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If String.IsNullOrEmpty(txtPoliza.Text) Then
            btnBuscar.Focus()
            NotifyStatus("Ingrese la poliza.", True, True)
        Else
            BuscarPoliza()
        End If
    End Sub

    Private Sub BuscarPoliza()
        Try
            LimpiarControles()
            pResult = String.Empty
            Dim dsData As New DataSet
            dsData = xserv.Verify_Poliza(txtPoliza.Text, PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                If dsData.Tables(0).Rows.Count = 0 Then
                    btnBuscar.Focus()
                    NotifyStatus("La poliza ingresada no existe", True, True)
                Else
                    If ValidarPoliza() Then
                        txtNumCliente.Text = dsData.Tables(0).Rows(0)(0).ToString
                        txtNombreCliente.Text = dsData.Tables(0).Rows(0)(1).ToString
                    End If
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub txtPoliza_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPoliza.KeyUp
        If e.KeyData = Keys.Enter Then
            If String.IsNullOrEmpty(txtPoliza.Text) Then
                btnBuscar.Focus()
                NotifyStatus("Ingrese la poliza.", True, True)
            Else
                BuscarPoliza()
            End If
        End If
    End Sub
End Class
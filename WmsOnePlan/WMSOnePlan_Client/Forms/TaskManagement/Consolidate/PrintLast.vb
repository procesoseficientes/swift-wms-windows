Imports System.Windows.Forms

Public Class PrintLast

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If grpFactura.Visible Then
            frmMainConsolidate.PrintDocuments(Me.TextBox1.Text)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            If Me.txtCajas.Text.Trim = "" Then
                Me.txtCajas.Focus()
                Exit Sub
            End If
            frmMainConsolidate.PrintLabels(Me.txtPedido.Text + "|" + Me.txtCajas.Text)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
        'If RB_Label.Checked And TextBox1.Text.Trim <> "" Then
        'ElseIf RB_Invoice.Checked And TextBox1.Text.Trim <> "" Then
        'End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RB_Label_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Label.CheckedChanged
        If RB_Label.Checked Then
            Me.lblInputTitle.Text = "Numero de Etiqueta:"
        End If
    End Sub

    Private Sub RB_Invoice_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_Invoice.CheckedChanged
        If RB_Invoice.Checked Then
            Me.lblInputTitle.Text = "Numero de Factura:"
        End If
    End Sub

    Private Sub btnVerInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerInfo.Click

        Dim pResult As String = ""

        Try
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")
            Dim xdata As DataSet = xserv.GetDocumentInfo(Me.txtPedido.Text, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.lblCliente.Text = "" & xdata.Tables(0).Rows(0)("CLIENT_NAME")
                Me.lblSector.Text = "" & xdata.Tables(0).Rows(0)("SECTOR")
                Me.lblRuta.Text = "" & xdata.Tables(0).Rows(0)("RUTA")
                Me.lblTotalCajas.Text = IIf(IsDBNull(xdata.Tables(0).Rows(0)("QTY_BOXES")), "", xdata.Tables(0).Rows(0)("QTY_BOXES"))
            Else
                MessageBox.Show(pResult)
                Me.lblCliente.Text = ""
                Me.lblSector.Text = ""
                Me.lblRuta.Text = ""
                Me.lblTotalCajas.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub txtPedido_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPedido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnVerInfo_Click(sender, e)
        End If
    End Sub

    Private Sub txtPedido_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPedido.KeyUp
        'If e.KeyCode = Keys.Enter Then
        '    MessageBox.Show("SS")

        '    btnVerInfo_Click(sender, e)
        'End If

    End Sub

    Private Sub txtPedido_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedido.Leave
        btnVerInfo_Click(sender, e)
    End Sub

    Private Sub txtPedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedido.TextChanged

    End Sub

    Private Sub txtCajas_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCajas.KeyUp

        If e.KeyCode = Keys.Enter Then
            OK_Button_Click(sender, e)
        End If

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub btnCambiarCajas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCambiarCajas.Click
        frmChangeTotalBoxes.lblPedidoNumero.Text = Me.txtPedido.Text
        frmChangeTotalBoxes.lblTotalCajasActual.Text = Me.lblTotalCajas.Text
        frmChangeTotalBoxes.txtTotalCajasNuevo.Text = ""
        frmChangeTotalBoxes.ShowDialog()
        If frmChangeTotalBoxes.DialogResult = Windows.Forms.DialogResult.OK Then
            btnVerInfo_Click(sender, e)
        End If
    End Sub

    Private Sub PrintLast_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.grpPedido.Visible Then
            btnVerInfo_Click(sender, e)
        End If
    End Sub
End Class

Imports System.Windows.Forms

Public Class frmAssignBin

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        Try

            If Me.txtPedido.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un numero de Pedido para reasignar")
            ElseIf Me.txtBin.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar un numero de BIN para reasignar")
            Else
                If MessageBox.Show("Seguro que quiere asignar este pedido a un nuevo Bin?", "Reasignar Bin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then

                    Dim pResult As String = ""
                    Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/wms_tasksadmin.asmx")
                    If Not xserv.UpdateTaskStatusByBin(txtPedido.Text, CInt(Me.txtBin.Text), pResult, PublicLoginInfo.Environment) Then
                        MessageBox.Show("No se pudo reasignar el pedido." + vbNewLine + pResult)
                    Else
                        If Me.cboColumna.Text <> "" Or Me.cboColumna.Text <> "Ninguna" Then
                            If Not xserv.AddReassignedBINtoControlTableCall(txtPedido.Text, CInt(Me.txtBin.Text), Me.cboColumna.Text, pResult, PublicLoginInfo.Environment) Then
                                MessageBox.Show("No se pudo reasignar el pedido. Intente con otro BIN" + vbNewLine + pResult)
                            Else
                                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                                Me.Close()
                            End If
                        Else
                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()
                        End If
                    End If


                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmAssignBin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cboColumna.SelectedIndex = 0
        Me.lblLinea.Text = ""
        LlenarColumnas()
    End Sub

    Private Sub txtPedido_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPedido.Leave

        LlenarColumnas()

    End Sub

    Private Sub txtPedido_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPedido.TextChanged

    End Sub

    Private Sub LlenarColumnas()
        Try

            Dim pResult As String = ""
            Dim rsData As DataSet = New DataSet
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/info/wms_infotrans.asmx")
            rsData = xserv.GetLocationsByDocument(Me.txtPedido.Text.Trim, pResult, PublicLoginInfo.Environment)

            Me.cboColumna.Items.Clear()
            Me.cboColumna.Items.Add("Ninguna")
            If pResult = "OK" Then
                For Each xrow In rsData.Tables(0).Rows
                    Me.cboColumna.Items.Add(xrow("LOCATION_SPOT").ToString)
                    Me.lblLinea.Text = xrow("LINE_ID").ToString
                Next
                Me.lblLinea.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class

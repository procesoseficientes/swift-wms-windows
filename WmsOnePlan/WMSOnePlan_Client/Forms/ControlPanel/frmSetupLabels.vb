Imports DevExpress.UserSkins

Public Class frmSetupLabels
    Dim pLabelType As String = ""
    Private Sub frmSetupLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        ClearFields()


    End Sub
    Sub ClearFields()
        txtZPLCommands.Text = ""

        chkListLineas.Items(0).CheckState = CheckState.Unchecked 'linea 1
        chkListLineas.Items(1).CheckState = CheckState.Unchecked 'linea 2
        chkListLineas.Items(2).CheckState = CheckState.Unchecked 'linea 3

        lblLastUpdated.Text = "..."
        lblLastUser.Text = "..."
    End Sub
    Private Sub btnUnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnLock.Click
        Me.txtZPLCommands.Properties.ReadOnly = False
        Me.txtZPLCommands.Focus()

    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        SaveRecord()
    End Sub
    Sub SaveRecord()
        Try
            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            Dim pResult As String = ""

            If xserv.RelateLabel_Line(pLabelType, "", True, pResult, PublicLoginInfo.Environment) Then
                For i = 0 To chkListLineas.Items.Count - 1
                    If Me.chkListLineas.Items(i).CheckState = CheckState.Checked Then
                        If Not xserv.RelateLabel_Line(pLabelType, Me.chkListLineas.Items(i).Value, False, pResult, PublicLoginInfo.Environment) Then
                            MessageBox.Show(pResult)
                            Exit Sub
                        End If
                    End If
                Next
                If Not xserv.UpdateLabelSetup(pLabelType, Me.txtZPLCommands.Text, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                    MessageBox.Show(pResult)
                End If
            Else
                MessageBox.Show(pResult)
                Exit Sub
            End If
            ShowRecord()
            Me.txtZPLCommands.Properties.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ShowRecord()
        Try
            Dim xdata As DataSet

            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            Dim pResult As String = ""
            Me.grp_info.Text = "Información General: ETIQUETA " + pLabelType
            xdata = xserv.GetLabelsSetup(pLabelType, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                Me.txtZPLCommands.Text = xdata.Tables(0).Rows(0)("ZPL_Commands")
                Me.lblLastUpdated.Text = IIf(IsDBNull(xdata.Tables(0).Rows(0)("LAST_UPDATED")), "...", xdata.Tables(0).Rows(0)("LAST_UPDATED"))
                Me.lblLastUser.Text = IIf(IsDBNull(xdata.Tables(0).Rows(0)("LAST_LOGIN")), "...", xdata.Tables(0).Rows(0)("LAST_LOGIN"))

                For i = 0 To chkListLineas.Items.Count - 1
                    If xserv.IsLabelID_In_Line(pLabelType, Me.chkListLineas.Items(i).Value, pResult, PublicLoginInfo.Environment) Then
                        Me.chkListLineas.Items(i).CheckState = CheckState.Checked
                    Else
                        Me.chkListLineas.Items(i).CheckState = CheckState.Unchecked
                    End If
                Next
            Else
                ClearFields()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub NavBarControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NavBarControl1.Click

    End Sub

    Private Sub btnShow_4by4_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles btnShow_4by4.LinkClicked
        pLabelType = "4X4"
        ShowRecord()
    End Sub

    Private Sub btnShow_4by6_LinkClicked(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles btnShow_4by6.LinkClicked
        pLabelType = "4X6"
        ShowRecord()
    End Sub

    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton2.Click
        RetriveLastRecord()
    End Sub
    Sub RetriveLastRecord()
        Try
            Dim xdata As DataSet

            Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

            Dim pResult As String = ""


            If MessageBox.Show("Seguro de retornar los ultimos comandos ZPL grabados?", "WMS OnePlan", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                xdata = xserv.GetLabelsSetup(pLabelType, pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    Me.txtZPLCommands.Text = xdata.Tables(0).Rows(0)("LAST_ZPL_COMMANDS")
                    MessageBox.Show("Ultimos comandos ZPL grabados han sido retornados", "WMS OnePlan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(pResult)
                End If

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
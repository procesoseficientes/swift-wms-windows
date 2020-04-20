Imports System.Data
Imports System.Configuration.ConfigurationManager
Imports System.ComponentModel
Imports System.ServiceModel
Imports DevExpress.UserSkins
Imports DevExpress.Skins
Imports DevExpress.Skins.Info
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Threading
Imports DevExpress.XtraEditors
Imports MobilityScm.Modelo.Vistas

Public Class frmLogin

    Private Sub CheckButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButton2.CheckedChanged
        Try
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
    Sub MyUnhandledExceptionHandler()

    End Sub
    Private Sub CheckButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        LogUser()
    End Sub
    Sub LogUser()
        Dim pResult As String = ""
        Dim pUri As String = ""
        Try
            pUri = AppSettings("WSHOST").ToString + "/Catalogues/WMS_Security.asmx"
        Catch ex As Exception
            lblStatus.Text = pUri + "|" + ex.Message
            lblStatus.Refresh()
        End Try

        lblStatus.Text = "Ws=" + pUri
        lblStatus.Refresh()

        Try
            Cursor = Cursors.WaitCursor

            Dim pDfltEnv As String = AppSettings("DEFAULT_ENVIRONMENT").ToString

            If pDfltEnv = "" Then
                pDfltEnv = "DESARROLLO"
            End If

            Me.lblStatus.Text = "Ambiente:" + pDfltEnv
            Me.lblStatus.Refresh()
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", pUri)
            
            Dim xdata As DataSet
            Dim xdata1 As DataSet
            Dim expirationDate As DateTime
            Dim showMessage As Boolean
            Dim missingDays As Integer

            If IsUserIdValid(txtUserID.Text) Then
                xdata = xserv.VerifyUserPass(Me.txtUserID.Text.ToUpper.Trim, Me.txtPwd.Text.ToString.ToUpper.Trim, pResult, pDfltEnv, expirationDate, showMessage, missingDays)
            Else 
                lblStatus.Text = $"El usuario {txtUserID.Text} es incorrecto, por favor, verifique y vuelva a intentar"
                lblStatus.Refresh()
                Cursor = Cursors.Default   
                Exit Sub
            End If
            
            lblStatus.Text = "Result=" + pResult
            lblStatus.Refresh()

            If pResult = "OK" Then

                If xdata.Tables(0).Rows(0)("LOGIN_TYPE").ToString <> "PC" And xdata.Tables(0).Rows(0)("LOGIN_TYPE").ToString <> "PC_Y_MOVIL" Then
                    Cursor = Cursors.Default
                    lblStatus.Text = $"Usuario no tiene acceso a la aplicación cliente de Swift 3PL"
                    Exit Sub
                End If

                If xdata.Tables(0).Rows(0)("IS_LOGGED").ToString = "1" Then
                    Cursor = Cursors.Default
                    lblStatus.Text = pDfltEnv
                    lblStatus.Refresh()

                    Dim args As New XtraMessageBoxArgs()
                    args.AutoCloseOptions.Delay = 3000
                    args.Caption = "Swift 3PL"
                    args.Text = "Este usuario ya tiene una sesión abierta. ¿Desea cerrar la sesión anterior y continuar?"
                    args.Buttons = {DialogResult.Yes, DialogResult.No}
                    args.Icon = SystemIcons.Question
                    args.DefaultButtonIndex = 0
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = True

                    If (XtraMessageBox.Show(args) = DialogResult.Yes) Then
                        If Not xserv.RegisterLogIn(Me.txtUserID.Text.ToUpper.Split("@")(0), "CHECK_OUT", pResult, pDfltEnv) Then
                            lblStatus.Text = pResult
                            lblStatus.Refresh()
                        End If
                    Else
                        Exit Sub
                    End If

                End If

                Try
                    xdata1 = xserv.GetEnvironmentByKey("OP_WMS", xdata.Tables(0).Rows(0)("ENVIRONMENT").ToString, pResult, xdata.Tables(0).Rows(0)("ENVIRONMENT").ToString)
                    If pResult = "OK" Then
                        If xdata1.Tables(0).Rows(0)("STATUS") <> "ACTIVO" Then
                            Cursor = Cursors.Default
                            lblStatus.Text = "El Ambiente de trabajo [" + xdata.Tables(0).Rows(0)("ENVIRONMENT") + "] esta INACTIVO"
                            lblStatus.Refresh()


                            Exit Sub
                        End If
                    Else
                        Cursor = Cursors.Default
                        lblStatus.Text = pResult
                        lblStatus.Refresh()

                        Exit Sub
                    End If

                Catch ex As Exception
                    lblStatus.Text = "ERROR: " + xdata.Tables(0).Rows(0)("ENVIRONMENT").ToString
                    lblStatus.Refresh()

                    End
                End Try

                SaveSetting("OnePlan", "WMS", "LASTUSER", txtUserID.Text.ToUpper)
                SaveSetting("OnePlan", "WMS", "LASTUSER_LOGON", Now.ToString)
                SaveSetting("OnePlan", "WMS", "ENVIRONMENT", xdata.Tables(0).Rows(0)("ENVIRONMENT"))
                SaveSetting("OnePlan", "WMS", "VERSION", $"{CStr(My.Application.Info.Version.Major)}.{CStr(My.Application.Info.Version.Minor)}")

                PublicLoginInfo.LoginID = txtUserID.Text.ToUpper.Trim.Split("@")(0)
                PublicLoginInfo.Domain = txtUserID.Text.ToUpper.Trim.Split("@")(1)
                PublicLoginInfo.Password = txtPwd.Text.ToString.ToUpper.Trim
                PublicLoginInfo.LoginName = xdata.Tables(0).Rows(0)("LOGIN_NAME")
                PublicLoginInfo.Environment = xdata.Tables(0).Rows(0)("ENVIRONMENT")
                PublicLoginInfo.GUI = xdata.Tables(0).Rows(0)("GUI_LAYOUT")
                PublicLoginInfo.DistributionCenter = xdata.Tables(0).Rows(0)("DISTRIBUTION_CENTER_ID")
                PublicLoginInfo.ImgLogoDefault =  AppSettings("IMG_LOGO_DEFAULT").ToString
                PublicLoginInfo.ServerAddress(pResult)
                PublicLoginInfo.Api3PlAddress = AppSettings("API_3PL_ADDRESS").ToString
                PublicLoginInfo.DbUser = xdata.Tables(0).Rows(0)("USER")
                PublicLoginInfo.DbPassword = xdata.Tables(0).Rows(0)("PASSWORD")
                PublicLoginInfo.ServerIp = AppSettings("SERVER_IP").ToString
                PublicLoginInfo.AccessLevel = xdata.Tables(0).Rows(0)("ROLE_ID")
                PublicLoginInfo.DialogoDeCargaAbierto = False
                xserv.RegisterLogIn(PublicLoginInfo.LoginID, "CHECK_IN", pResult, PublicLoginInfo.Environment)

                xfrmRibbon.Static_Version.Caption = $"Versión: {My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}"
                xfrmRibbon.Text = RibbonForm1.Text + $"/{CStr(My.Application.Info.Version.Major)}.{CStr(My.Application.Info.Version.Minor)}.{(My.Application.Info.Version.Build)}({PublicLoginInfo.LoginID})"

                xfrmRibbon.Static_UserID.Caption = "Usuario:" + PublicLoginInfo.LoginID

                If Not IsDBNull(xdata.Tables(0).Rows(0)("LAST_LOGGED")) Then
                    xfrmRibbon.Static_UserID.Tag = "Ultimo ingreso fue el: " + FormatDateTime(xdata.Tables(0).Rows(0)("LAST_LOGGED"), DateFormat.LongDate)
                End If

                xfrmRibbon.Static_Environment.Caption = $"Ambiente: {xdata.Tables(0).Rows(0)("ENVIRONMENT")}"
                xfrmRibbon.Static_Environment.Tag = xdata.Tables(0).Rows(0)("ENVIRONMENT")

                xdata = xserv.GetCompanyName(pResult, PublicLoginInfo.Environment)

                If pResult = "OK" Then
                    PublicLoginInfo.CompanyName = xdata.Tables(0).Rows(0)("COMPANY_NAME")
                    xfrmRibbon.Static_CustomerName.Caption = xdata.Tables(0).Rows(0)("COMPANY_NAME")
                    If String.IsNullOrEmpty(xdata.Tables(0).Rows(0)("LOGO").ToString()) Then
                        PublicLoginInfo.LOGO = ""
                    Else
                        PublicLoginInfo.LOGO = xdata.Tables(0).Rows(0)("LOGO")
                    End If
                Else
                    lblStatus.Text = pResult
                    lblStatus.Refresh()
                    Exit Sub
                End If

                If showMessage Then

                    If missingDays = 0 Then
                        NotifyStatus($"La licencia expira hoy [{expirationDate.ToString()}]", True, True)
                    ElseIf missingDays = 1 Then
                        NotifyStatus($"La licencia expira mañana [{expirationDate.ToString()}]", True, True)
                    Else
                        NotifyStatus($"La licencia expira en {missingDays.ToString()} días, [{expirationDate.ToString()}]", True, True)
                    End If

                End If

                xfrmRibbon.Visible = True
                Cursor = Cursors.Default
                xfrmRibbon.Show()
                xfrmRibbon.Refresh()
            Else
                Cursor = Cursors.Default
                lblStatus.Text = pResult
                Me.txtPwd.Text = ""
                lblStatus.ForeColor = Color.Red
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            lblStatus.Text = ex.Message
            lblStatus.Refresh()
        End Try

    End Sub

    Private Shared Function IsUserIdValid(userId As string) As Boolean
        Dim pattern As String
        pattern = "^[_a-zA-Z0-9-]+(.[_a-zA-Z0-9-]+)*@[a-zA-Z0-9-]+(.[a-zA-Z0-9-]+)*(.[a-zA-Z])$"
        Return (Regex.Matches(userId, pattern)).Count > 0
    End Function

    Private Sub txtUserID_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtUserID.ButtonClick
        GetLastUser()
    End Sub

    Sub GetLastUser()
        Dim pLastUser = GetSetting("OnePlan", "WMS", "LASTUSER", "")
        If pLastUser <> "" Then
            txtUserID.Text = pLastUser
            Me.lblLastUSER.Text = pLastUser
            txtPwd.Focus()
        Else
            txtUserID.Visible = True
            txtUserID.Focus()
        End If

    End Sub

    Private Sub txtUserID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtPwd.Focus()
        End If
        If e.KeyCode = Keys.Down Then
            GetLastUser()
        End If
    End Sub

    Private Sub txtPwd_CausesValidationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPwd.CausesValidationChanged

    End Sub

    Private Sub txtPwd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPwd.KeyUp
        If e.KeyCode = Keys.Enter Then
            LogUser()
        End If
    End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            DevExpress.UserSkins.BonusSkins.Register()
            DevExpress.UserSkins.OfficeSkins.Register()

        Catch ex As Exception
            MessageBox.Show("Registrando skins de devexpress: " + ex.Message)

        End Try       
        GetLastUser()
        GroupControl1.Focus()
        GroupControl1.Text = "Bienvenido: Swift 3PL " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build
        txtPwd.Focus()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.lblLastUSER.Visible = Not Me.lblLastUSER.Visible
        Me.txtUserID.Visible = Not Me.txtUserID.Visible
        If Me.txtUserID.Visible Then
            Me.txtUserID.Focus()
        Else
            Me.txtPwd.Focus()
        End If
    End Sub

    Private Sub txtPwd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPwd.TextChanged

    End Sub

    Private Sub GroupControl1_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub txtUserID_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles txtUserID.EditValueChanged

    End Sub

    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        Try
            Cursor = Cursors.WaitCursor
            LogUser()
            Cursor = Cursors.Default

        Catch ex As Exception
            Cursor = Cursors.WaitCursor

            Me.lblStatus.Text = "Login.Catch:" + ex.Message
            Me.lblStatus.Refresh()

        End Try
    End Sub

    Private Sub lblStatus_Click(sender As System.Object, e As System.EventArgs) Handles lblStatus.Click
        Try
            Clipboard.SetText(lblStatus.Text)
            MessageBox.Show("Copied!")
            lblStatus.Text = ""

        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Data
Imports System.IO
Imports System.Text
Imports Resco.Controls.MessageBox
Imports MobilityScm.Keyboard.ButtonConfiguration
Imports System.Runtime.CompilerServices
Imports MobilityScm.Modelo.Vistas
Imports Symbol.WPAN.Bluetooth

Public Class ctrl_Login


    Public Sub LogInUser()

        Dim pResult As String = ""
        Dim xDS As New DataSet
        'handlekeyboard(gKEYBOARDACTION.HIDDE)

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim xservSecurity As New WMS_Security.WMS_Security
            Dim xservSettings As New WMS_Settings.WMS_Settings
            Dim pResultConfiguration As String = "OK"
            Dim pValorConfiguration As Int16 = 0
            Dim dsConfiguration As New DataSet
            Dim expirationDate As DateTime
            Dim showMessage As Boolean
            Dim missingDays As Integer

            Try
                GlobalEnviroment = AppSettings.Environment
                xDS = xservSecurity.VerifyUserPass(panelLogin.txtUserID.Text.ToUpper, panelLogin.txtPass.Text, pResult, GlobalEnviroment, expirationDate, showMessage, missingDays)

            Catch ex As Exception
                Cursor.Current = Cursors.Default
                Notify("LogInUser: " + ex.Message + vbNewLine + xservSecurity.Url.ToString, True)
                Exit Sub
            End Try


            If pResult = "OK" Then
                GlobalEnviroment = AppSettings.Environment

                Dim pLoginType As String = xDS.Tables(0).Rows(0)("LOGIN_TYPE").ToString.ToUpper

                If pLoginType = "MOVIL" Or pLoginType = "PC_Y_MOVIL" Then
                    CloseScanner()
                    GlobalUserID = xDS.Tables(0).Rows(0)("LOGIN_ID").ToString.ToUpper
                    GlobalEnviroment = xDS.Tables(0).Rows(0)("ENVIRONMENT").ToString

                    panelLogin.txtPass.Text = ""
                    GlobalWarehouse = xDS.Tables(0).Rows(0)("DEFAULT_WAREHOUSE_ID").ToString
                    xservSecurity.RegisterLogIn(GlobalUserID, "CHECK_IN", pResult, GlobalEnviroment)

                    StoreLastLogin()
                    gRol = xDS.Tables(0).Rows(0)("ROLE_ID").ToString
                    Global_WS_HOST = xDS.Tables(0).Rows(0)("WS_HOST")

                    BringMenu()
                    Cursor.Current = Cursors.Default

                    VariablesDeAmbiente.UserId = GlobalUserID
                    VariablesDeAmbiente.Enviroment = GlobalEnviroment
                    VariablesDeAmbiente.WsHost = Global_WS_HOST
                    VariablesDeAmbiente.BarcodeScanner = xScanner

                    VariablesDeAmbienteOperaciones.Usuario = GlobalUserID
                    VariablesDeAmbienteOperaciones.Ambiente = GlobalEnviroment
                    VariablesDeAmbienteOperaciones.DireccionDeServicio = Global_WS_HOST
                    VariablesDeAmbienteOperaciones.EscanerDeCodigoDeBarras = xScanner
                    VariablesDeAmbienteOperaciones.DireccionDeImpresora = gDeviceAddress
                    VariablesDeAmbienteOperaciones.Empresa = AppSettings.LICENSE_OWNER

                    VariablesDeAmbienteParaConsulta.UserId = GlobalUserID
                    VariablesDeAmbienteParaConsulta.Enviroment = GlobalEnviroment
                    VariablesDeAmbienteParaConsulta.WsHost = Global_WS_HOST
                    VariablesDeAmbienteParaConsulta.BarcodeScanner = xScanner
                    VariablesDeAmbienteParaConsulta.Printer = gDeviceAddress

                    VariablesDeAmbienteCertificacion.Usuario = GlobalUserID
                    VariablesDeAmbienteCertificacion.Ambiente = GlobalEnviroment
                    VariablesDeAmbienteCertificacion.DireccionDeServicio = Global_WS_HOST
                    VariablesDeAmbienteCertificacion.EscanerDeCodigoDeBarras = xScanner
                    VariablesDeAmbienteCertificacion.DireccionDeImpresora = gDeviceAddress
                    VariablesDeAmbienteCertificacion.Empresa = AppSettings.LICENSE_OWNER

                    VariablesDeAmbienteEntregaDeDespacho.Usuario = GlobalUserID
                    VariablesDeAmbienteEntregaDeDespacho.Ambiente = GlobalEnviroment
                    VariablesDeAmbienteEntregaDeDespacho.DireccionDeServicio = Global_WS_HOST
                    VariablesDeAmbienteEntregaDeDespacho.EscanerDeCodigoDeBarras = xScanner
                    VariablesDeAmbienteEntregaDeDespacho.DireccionDeImpresora = gDeviceAddress
                    VariablesDeAmbienteEntregaDeDespacho.Empresa = AppSettings.LICENSE_OWNER

                    dsConfiguration = xservSettings.GetParam_ByParamKey("SISTEMA", "RECEPCION", "DEBE_MOSTRAR_BOTON_SUGERENCIA_UBICACIONES", pResultConfiguration, GlobalEnviroment)
                    If pResultConfiguration = "OK" Then
                        pValorConfiguration = dsConfiguration.Tables(0).Rows(0)("NUMERIC_VALUE")
                        If pValorConfiguration = 0 Then
                            gMuestraBotonSugerenciaReubicacion = False
                        Else
                            gMuestraBotonSugerenciaReubicacion = True
                        End If
                    End If


                    If showMessage Then
                        If missingDays = 0 Then
                            Notify("La licencia expira hoy [" & expirationDate.ToString() & "]", False)
                        ElseIf missingDays = 1 Then
                            Notify("La licencia expira mañana [" & expirationDate.ToString() & "]", False)
                        Else
                            Notify("La licencia expira en " & missingDays.ToString() & " días [" & expirationDate.ToString() & "]", False)
                        End If
                    End If

                Else
                    Cursor.Current = Cursors.Default
                    Notify("Usuario sin autorización para utilizar WMS Mobile", True)
                    'MessageBoxEx.Show("Usuario sin autorización para utilizar WMS Mobile", AppDomain.CurrentDomain.FriendlyName)
                End If
            Else
                Cursor.Current = Cursors.Default
                Notify(pResult, True)
            End If

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default

            Notify("LogInUser: " + ex.Message + " " + Global_WS_HOST, True)

            While Not ex.InnerException Is Nothing
                MessageBoxEx.Show(ex.InnerException.Message)
                ex = ex.InnerException
            End While
        End Try
    End Sub

    Sub StoreLastLogin()
        Dim pPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString + "\lstUser.txt"
        Dim pTmpLine As String = ""

        Try
            Dim streamW As StreamWriter
            Dim fS As FileStream
            If File.Exists(pPath) = False Then
                streamW = File.CreateText(pPath)

                streamW.WriteLine(panelLogin.txtUserID.Text + "                ")
                streamW.Close()

            Else
                fS = File.OpenWrite(pPath)
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(panelLogin.txtUserID.Text + "                ")
                fS.Write(info, 0, info.Length)
                fS.Close()
            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub toolbar_footer_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolbar_footer.Click
        If toolbar_footer.SelectedIndex = 2 Then
            'ReturnTaskbar()
            'Application.Exit()
            'CloseScanner()
            'CloseWLAN()
            frmBase.ShowWindowsMenu(True)
            Application.Exit()
            'frmBase.Close()
        Else

            panelSetupPrinter.lbl_DefaultPrinter.Text = "Connected to: " + gDeviceAddress
            ShowPanel(panelSetupPrinter)
        End If
    End Sub

    Private Sub btnMyTasks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LogInUser()


    End Sub


    Private Sub txtUserID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserID.GotFocus
        Me.txtUserID.SelectAll()


    End Sub

    Private Sub txtUserID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserID.KeyUp

        Select Case e.ObtenerActionDeBoton(AppSettings.Environment, AppSettings.ServerUrl)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                Me.txtPass.Focus()
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                frmBase.ShowWindowsMenu(True)
                Application.Exit()
            Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
                Me.txtPass.Focus()
        End Select


    End Sub

    Private Sub txtPass_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPass.GotFocus
        'handlekeyboard(gKEYBOARDACTION.SHOW)
    End Sub

    Private Sub txtPass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPass.KeyUp

        Try
            Select Case e.ObtenerActionDeBoton(AppSettings.Environment, AppSettings.ServerUrl)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.ACEPTAR
                    LogInUser()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    CloseScanner()
                    'CloseWLAN()
                    frmBase.ShowWindowsMenu(True)
                    Application.Exit()
                Case MobilityScm.Modelo.Tipos.FuncionBoton.CANCELAR
                Case MobilityScm.Modelo.Tipos.FuncionBoton.GUARDAR
            End Select

        Catch ex As Exception
            Notify("Ocurrió un error al conectar: " + ex.Message, True)
        End Try

    End Sub

    Private Sub txtPass_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPass.LostFocus
        'handlekeyboard(gKEYBOARDACTION.HIDDE)
    End Sub

    Private Sub txtPass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub ctrl_Login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Click

    End Sub

    Private Sub ctrl_Login_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        Try
            lblLicenseTo.Text = "Licencia:" + AppSettings.LICENSE_OWNER.ToString
            lblServer.Text = AppSettings.ServerUrl
            tblHeader.Items(0).Text = "Swift 3PL® V" + My.Resources.APP_VERSION '+ "@" + My.Resources.DEF_ENVIRONMENT
        Catch ex As Exception

        End Try
    End Sub


    Private Sub ctrl_Login_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'ShowFullScreen()
        With frmBase
            .Height = Screen.PrimaryScreen.Bounds.Height
            .Width = Screen.PrimaryScreen.Bounds.Width

            panelLogin.Size = .ClientSize
        End With
    End Sub

    Private Sub txtUserID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserID.LostFocus
        handlekeyboard(gKEYBOARDACTION.HIDDE)
    End Sub

    Private Sub txtUserID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUserID.TextChanged

    End Sub

    Private Sub lblServer_ParentChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblServer.ParentChanged

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Notify(AppSettings.Environment, False)
    End Sub
End Class

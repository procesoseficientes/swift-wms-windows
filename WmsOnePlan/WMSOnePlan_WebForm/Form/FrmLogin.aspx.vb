
Public Class FrmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtUser.Focus()
        End If
    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ValidatedCredential()
    End Sub

    Private Sub ValidatedCredential()
        Try
            Dim pResult As String = ""
            Dim pTrace As String = "Begin"
            Dim pUri As String = ""
            Try
                pTrace = " Before URI " + Now.ToString
                pUri = ConfigurationManager.AppSettings("WSHOST").ToString + "/Catalogues/WMS_Security.asmx"
                pTrace = " After URI " + Now.ToString

            Catch ex As Exception
                lblerror.Text = "ValidatedCredential, Ha ocurrido el siguiente error: " + ex.Message
            End Try

            Dim pDfltEnv As String = ConfigurationManager.AppSettings("DEFAULT_ENVIRONMENT").ToString()

            If pDfltEnv = "" Then
                pDfltEnv = "DESARROLLO"
            End If
            pResult = ""
            Dim svSegurity As New OnePlanServices_Security.WMS_SecuritySoapClient
            Dim dsValidated As DataSet
            dsValidated = svSegurity.VerifyUserPass(Me.txtUser.Text.ToUpper.Trim, Me.txtPassword.Text.ToString.ToUpper.Trim, pResult, pDfltEnv)

            If pResult.Equals("OK") Then
                If dsValidated.Tables(0).Rows(0)("LOGIN_TYPE").ToString <> "PC" And dsValidated.Tables(0).Rows(0)("LOGIN_TYPE").ToString <> "PC_Y_MOVIL" Then
                    lblerror.Text = "Usuario no tiene acceso a la Web cliente del OnePlan WMS"
                    Exit Sub
                End If

                If dsValidated.Tables(0).Rows(0)("3PL_WAREHOUSE") Is Nothing Or String.IsNullOrEmpty(dsValidated.Tables(0).Rows(0)("3PL_WAREHOUSE").ToString()) Then
                    lblerror.Text = "El usuario no tiene una bodega habilitadad "
                    Exit Sub
                End If
                Session("users") = txtUser.Text
                Session("role") = dsValidated.Tables(0).Rows(0)("ROLE_ID")
                Session("3PL_WAREHOUSE") = dsValidated.Tables(0).Rows(0)("3PL_WAREHOUSE")
                Session("environmentName") = pDfltEnv
                Response.Redirect("FrmKardex.aspx")
            Else
                lblerror.Text = pResult
            End If
        Catch ex As Exception
            lblerror.Text = "ValidatedCredential, Ha ocurrido el siguiente error: " + ex.Message
        End Try
    End Sub

End Class
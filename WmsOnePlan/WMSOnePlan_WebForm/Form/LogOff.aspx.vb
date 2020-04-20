Public Class LogOff
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("users") Is Nothing Then
            Session("users") = Nothing
            Session("role") = Nothing
            Session("3PL_WAREHOUSE") = Nothing
            Session("environmentName") = Nothing
            Response.Redirect("FrmLogin.aspx")
        Else
            Response.Redirect("FrmLogin.aspx")
        End If
            
    End Sub

End Class
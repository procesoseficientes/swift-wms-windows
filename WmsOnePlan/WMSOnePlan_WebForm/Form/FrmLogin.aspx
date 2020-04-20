<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmLogin.aspx.vb" Inherits="WMSOnePlan_WebForm.FrmLogin" %>

<%@ Register assembly="DevExpress.Web.v19.2, Version=19.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="CSS/Main.css" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 261px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <input type="text"/>
        <div id="divLogin">
            <dx:ASPxRoundPanel ID="panelLogin" runat="server" Width="450px"
                HeaderText="" View="GroupBox" Height="200px">
                <PanelCollection>
                    <dx:PanelContent ID="PanelContent1" runat="server" SupportsDisabledAttribute="True">
                        <br/>
                        <br/>
                        
                        
                        <table align="center" width="100%">
                            <tr>
                                <td rowspan="5"><br/>
                                    <br/>
                                    <a href="#">
                                        <img alt="" width="140px" src="CSS/IMG/Alsersa_Logotipo_parte_2.png" style="border-style: none; border-width: 0px; height: 125px;">
                                    </a>
                                    &nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td>
                                    <br/>
                                    <br/>
                                    <br/>
                                    <br/>
                                    Usuario:
                                </td>
                                <td>
                                    <br/>
                                    <br/>
                                    <br/>
                                    <br/>
                                    <dx:ASPxTextBox ID="txtUser" runat="server" Width="200px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Password:
                                </td>
                                <td colspan="2">
                                    <dx:ASPxTextBox ID="txtPassword" runat="server" Width="200px" Password="True">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right">
                                    <br/>
                                    <dx:ASPxButton ID="btnLogin" runat="server"
                                        OnClick="btnLogin_Click" BackColor="Transparent" Height="20px" Width="85px">
                                        <BackgroundImage ImageUrl="~/Form/CSS/IMG/Frodo_botton-1.png" Repeat="NoRepeat" />
                                        <Border BorderColor="Transparent" />
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1" >&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style1" >&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="lblerror" runat="server" ForeColor="Red"
                                        EnableViewState="False">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                        </table>
                    </dx:PanelContent>
                </PanelCollection>
                <BackgroundImage HorizontalPosition="center" ImageUrl="~/Form/CSS/IMG/Login_Alsersa_segundo.png" Repeat="NoRepeat" />
                <Border BorderColor="Transparent" />
            </dx:ASPxRoundPanel>
        </div>

    </form>
</body>
</html>

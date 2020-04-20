Public Class FrmAssicuateUserClient

    Private Property LoginId() As String
    Private Property ClienteCode() As String
    Public Sub New(ByVal pLoginId As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LlenarCmbGriClient()
        LoginId = pLoginId
        LlenarControles()
    End Sub

    Private Sub LlenarCmbGriClient()

        Dim xdataset As DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

            xdataset = xserv.GetClientSap(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                xdataset.Rows.Add("0", "N/A")
                cmbCliente.Properties.DataSource = xdataset
                cmbCliente.Properties.PopulateViewColumns()
                cmbCliente.Properties.ValueMember = "CLIENT_CODE"
                cmbCliente.Properties.DisplayMember = "CLIENT_NAME"

                For i = 0 To cmbCliente.Properties.View.Columns.Count - 1
                    cmbCliente.Properties.View.Columns(i).Visible = False
                Next

                cmbCliente.Properties.View.Columns("CLIENT_NAME").Caption = "NOMBRE"
                cmbCliente.Properties.View.Columns("CLIENT_CODE").Caption = "CODIGO"
                cmbCliente.Properties.View.Columns("CLIENT_NAME").Visible = True
                cmbCliente.Properties.View.Columns("CLIENT_CODE").Visible = True
                cmbCliente.Properties.View.Columns("CLIENT_NAME").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                cmbCliente.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LlenarControles()
        Dim result As String = ""
        Try
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            Dim dt As New DataTable
            dt = xserv.GetClientUser(LoginId, result, PublicLoginInfo.Environment)
            If result = "OK" Then
                Dim row As DataRow = dt.Rows(0)
                lblUsuario.Text = row("LOGIN_NAME").ToString()
                lblClienteAcutal.Text = row("CLIENT_NAME").ToString()
                cmbCliente.EditValue = row("CLIENT_CODE").ToString()
                ClienteCode = row("CLIENT_CODE").ToString()
                If String.IsNullOrEmpty(row("CLIENT_CODE").ToString()) Then
                    cmbCliente.EditValue = 0
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub Grabar()
        If Not ClienteCode.Equals(cmbCliente.EditValue) Then
            Dim result As String = ""
            Try
                Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
                If xserv.UpdateUserCliente(LoginId, IIf(cmbCliente.EditValue.Equals("0"), "", cmbCliente.EditValue), IIf(cmbCliente.EditValue.Equals("0"), 0, 1), result, PublicLoginInfo.Environment) Then
                    If result = "OK" Then
                        NotifyStatus("Se grabo exitosamente.", True, False)
                        Close()
                    Else
                        NotifyStatus(result, True, True)
                    End If
                Else
                    NotifyStatus(result, True, True)
                End If
            Catch ex As Exception
                NotifyStatus(ex.Message, True, True)
            End Try
        Else
            Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Grabar()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class
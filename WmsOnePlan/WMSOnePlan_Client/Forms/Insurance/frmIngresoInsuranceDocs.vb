Imports DevExpress.XtraEditors.DXErrorProvider

Public Class frmIngresoInsuranceDocs
    Private Property DocId As Integer = 0
    Private Property Monto As Decimal = 0
    Private Property Cobertura As String = String.Empty

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal pDoc_Id As Int32)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        DocId = pDoc_Id
        LlenarControles()
    End Sub

    Private Sub LlenarControles()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")

        Dim xdata As DataSet = xserv.FillInsuranceDocs(DocId, pResult, PublicLoginInfo.Environment)

        If pResult = "OK" Then
            cmbCompania.EditValue = xdata.Tables(0).Rows(0)("COMPANY_ID").ToString
            cmbCliente.EditValue = xdata.Tables(0).Rows(0)("CLIENT_CODE").ToString
            txtPoliza.Text = xdata.Tables(0).Rows(0)("POLIZA_INSURANCE").ToString
            dtFechaInicio.EditValue = Date.Parse(xdata.Tables(0).Rows(0)("VALIN_FROM").ToString)
            dtFechaFinal.EditValue = Date.Parse(xdata.Tables(0).Rows(0)("VALIN_TO").ToString)
            ceMonto.EditValue = xdata.Tables(0).Rows(0)("AMOUNT").ToString
            memCobertura.Text = xdata.Tables(0).Rows(0)("COVERAGE").ToString
            cmbTipoSeguro.EditValue = xdata.Tables(0).Rows(0)("INSURANCE_OWHEN").ToString

            cmbCompania.Enabled = False
            cmbCompania.BackColor = Color.LightYellow
            cmbCliente.Enabled = False
            cmbCliente.BackColor = Color.LightYellow
            txtPoliza.Enabled = False
            txtPoliza.BackColor = Color.LightYellow
            dtFechaInicio.Enabled = False
            dtFechaInicio.BackColor = Color.LightYellow
            dtFechaFinal.Enabled = False
            dtFechaFinal.BackColor = Color.LightYellow

            cmbTipoSeguro.Enabled = False
            cmbTipoSeguro.BackColor = Color.LightYellow

            Monto = Decimal.Parse(ceMonto.EditValue)
            Cobertura = memCobertura.Text
        Else
            MessageBox.Show(pResult)
        End If
    End Sub

    Private Sub LlenarCmbGriClient()
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetViewClients(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbCliente.Properties.DataSource = xdataset.Tables(0)
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
                cmbCliente.Properties.View.BestFitColumns()

            End If
        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub LlenarCmbGridCompania()
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Companies.WMS_Insurance_CompaniesSoapClient("WMS_Insurance_CompaniesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Companies.asmx")
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.GetInsuranceCompany(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

                cmbCompania.Properties.DataSource = xdataset.Tables(0)
                cmbCompania.Properties.PopulateViewColumns()
                cmbCompania.Properties.ValueMember = "COMPANY_ID"
                cmbCompania.Properties.DisplayMember = "COMPANY_NAME"

                For i = 0 To cmbCompania.Properties.View.Columns.Count - 1
                    cmbCompania.Properties.View.Columns(i).Visible = False
                Next


                cmbCompania.Properties.View.Columns("COMPANY_NAME").Caption = "NOMBRE"
                cmbCompania.Properties.View.Columns("COMPANY_ID").Caption = "CODIGO"
                cmbCompania.Properties.View.Columns("COMPANY_NAME").Visible = True
                cmbCompania.Properties.View.Columns("COMPANY_ID").Visible = True
                cmbCompania.Properties.View.BestFitColumns()

            End If

        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub CrearDoc()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")

            Dim grabo As New Boolean
            grabo = xserv.CreateInsuranceDocs(cmbCompania.EditValue.ToString, cmbCliente.EditValue.ToString, txtPoliza.Text,
                                              Date.Parse(dtFechaInicio.EditValue.ToString), Date.Parse(dtFechaFinal.EditValue.ToString),
                                              Decimal.Parse(ceMonto.EditValue), memCobertura.Text,
                                              PublicLoginInfo.LoginID, "ENDOSADO",
                                              pResult, PublicLoginInfo.Environment)
            If grabo Then
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

    Private Sub UpdateDoc()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")

            Dim grabo As New Boolean
            grabo = xserv.UpdateInsuranceDocs(DocId, Decimal.Parse(ceMonto.EditValue), memCobertura.Text, PublicLoginInfo.LoginID,
                                              pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
                    If pResult = "OK" Then
                        CreateLog()
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

    Private Sub CreateLog()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Log.WMS_Insurance_LogSoapClient("WMS_Insurance_LogSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Log.asmx")

            Dim grabo As New Boolean
            grabo = xserv.CreateInsuranceLog(DocId, PublicLoginInfo.LoginID, Monto, Cobertura, Decimal.Parse(ceMonto.EditValue), memCobertura.Text, pResult, PublicLoginInfo.Environment)
            If grabo Then
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

    Private Function ValidarFormulario() As Boolean
        dxError.SetError(cmbCompania, "", ErrorType.None)
        dxError.SetError(cmbCliente, "", ErrorType.None)
        dxError.SetError(txtPoliza, "", ErrorType.None)
        dxError.SetError(dtFechaInicio, "", ErrorType.None)
        dxError.SetError(dtFechaFinal, "", ErrorType.None)
        dxError.SetError(ceMonto, "", ErrorType.None)
        dxError.SetError(memCobertura, "", ErrorType.None)

        Try
            Dim paso As Boolean = True
            If cmbCompania.EditValue Is Nothing Then
                dxError.SetError(cmbCompania, "Seleccione una compania")
                paso = False
            End If

            If cmbCliente.EditValue Is Nothing Then
                dxError.SetError(cmbCliente, "Seleccione un cliente")
                paso = False
            End If

            If String.IsNullOrEmpty(txtPoliza.Text) Then
                dxError.SetError(txtPoliza, "Ingrese la poliza")
                paso = False
            End If

            If dtFechaInicio.EditValue Is Nothing Then
                dxError.SetError(dtFechaInicio, "Ingrese la fecha de inicio")
                paso = False
            Else
                If dtFechaFinal.EditValue Is Nothing Then
                    dxError.SetError(dtFechaFinal, "Ingrese la fecha de final")
                    paso = False
                Else
                    If Date.Parse(dtFechaInicio.EditValue).Date > Date.Parse(dtFechaFinal.EditValue).Date Then
                        dxError.SetError(dtFechaInicio, "La fecha de inicio es mayor a la fecha final")
                        paso = False
                    End If
                End If
            End If

            If ceMonto.EditValue Is Nothing Then
                dxError.SetError(ceMonto, "Ingrese el monto")
                paso = False
            Else
                If Decimal.Parse(ceMonto.EditValue) <= 0 Then
                    dxError.SetError(ceMonto, "EL monto tiene que ser mayor a 0")
                    paso = False
                End If
            End If

            If String.IsNullOrEmpty(memCobertura.Text) Then
                dxError.SetError(memCobertura, "Ingrese la cobertura")
                paso = False
            End If

            Return paso
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
            Return False
        End Try
    End Function

    Private Sub frmIngresoInsuranceDocs_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LlenarCmbGriClient()
        LlenarCmbGridCompania()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidarFormulario() Then
            If DocId = 0 Then
                CrearDoc()
            Else
                UpdateDoc()
            End If

        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub cmbCompania_Leave(sender As Object, e As EventArgs) Handles cmbCompania.Leave, txtPoliza.Leave, memCobertura.Leave, dtFechaInicio.Leave, dtFechaFinal.Leave, cmbCliente.Leave, ceMonto.Leave
        dxError.SetError(sender, "", ErrorType.None)
    End Sub
  
End Class
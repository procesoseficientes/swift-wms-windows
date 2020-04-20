Imports DevExpress.XtraEditors.DXErrorProvider

Public Class FrmInsuranceDocsRenew
    Private _insuranceId As Integer

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub New(ByVal pDocId As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _insuranceId = pDocId
        LlenarGrid()
    End Sub

    Private Function Validar() As Boolean
        dxError.SetError(dtFechaInicio, "", ErrorType.None)
        dxError.SetError(dtFechaFinal, "", ErrorType.None)
        dxError.SetError(txtAutoriazado, "", ErrorType.None)
        dxError.SetError(menComentario, "", ErrorType.None)

        Dim paso As Boolean = True
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
                    dtFechaInicio.Focus()
                    paso = False
                End If
            End If
        End If
       
        If String.IsNullOrEmpty(txtAutoriazado.Text) Then
            dxError.SetError(txtAutoriazado, "Ingrese el nombre del autorizado")
            paso = False
        End If
        If String.IsNullOrEmpty(menComentario.Text) Then
            dxError.SetError(menComentario, "Ingrese el motivo")
            paso = False
        End If

        Return paso
    End Function
    
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Validar() Then
            Grabar()
        End If
    End Sub

    Private Sub Grabar()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            If xserv.CreateInsuranceDocsLog(_insuranceId, PublicLoginInfo.LoginID, dtFechaInicio.EditValue, dtFechaFinal.EditValue, menComentario.Text, txtAutoriazado.Text, pResult, PublicLoginInfo.Environment) Then
                If pResult = "OK" Then
                    NotifyStatus("Se actualizo exitosamente", False, False)
                    DialogResult = DialogResult.OK
                    Close()
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus("Ha ocurrido el siguiente error: " + ex.Message, True, True)
        End Try
    End Sub

    Private Sub dtFechaInicio_Leave(sender As Object, e As EventArgs) Handles txtAutoriazado.Leave, menComentario.Leave, dtFechaInicio.Leave, dtFechaFinal.Leave
        dxError.SetError(sender, "", ErrorType.None)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
    
    Private Sub LlenarGrid()

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Insurance_Docs.WMS_Insurance_DocsSoapClient("WMS_Insurance_DocsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Insurance_Docs.asmx")
            xdataset = xserv.GetInsuranceDocsLog(_insuranceId, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridHistorial.DataSource = xdataset.Tables(0)
            Else
                NotifyStatus(pResult, False, True)
            End If

            GridView4.BestFitColumns()
            GridView4.ExpandAllGroups()
        Catch ex As Exception
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
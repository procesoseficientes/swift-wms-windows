Public Class FrmAcuerdoXCliente

    Private Sub LlenarCmbGriClient()

        Dim xdataset As DataTable
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

            xdataset = xserv.GetClientSap(pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then

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

    Private Sub LlenarListas()
        Dim xdatatable As DataTable
        Dim pResult As String = ""
        Try

            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            xdatatable = xserv.GetAssignedAcuerdo(cmbCliente.EditValue, "GetAssignedAcuerdo", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                lstAcuerdoAsignado.DataSource = xdatatable
            Else
                NotifyStatus(pResult, True, True)
                Return
            End If
            pResult = ""
            xdatatable = xserv.GetAviaableAcuerdo(cmbCliente.EditValue, "GetAviaableAcuerdo", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                lstAcuerdoDisponible.DataSource = xdatatable
            Else
                NotifyStatus(pResult, True, True)
                Return
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub FrmAcuerdoXCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarCmbGriClient()
    End Sub

    Private Sub cmbCliente_EditValueChanged(sender As Object, e As EventArgs) Handles cmbCliente.EditValueChanged
        LlenarListas()
    End Sub

    Private Sub AsignaAcuerdo()
        Dim pResult As String = ""
        Try
            Dim validar As Boolean = True
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            For i = 0 To lstAcuerdoDisponible.SelectedItems.Count - 1
                pResult = ""
                If xserv.CreateAcuerdoXCliente(lstAcuerdoDisponible.SelectedItems.Item(i)("ACUERDO_COMERCIAL_ID"), cmbCliente.EditValue, pResult, PublicLoginInfo.Environment) Then
                    If Not pResult = "Ok" Then
                        NotifyStatus(pResult, True, True)
                        validar = False
                        Exit For
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Next
            If validar Then
                LlenarListas()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub AsignaTodoAcuerdo()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            If Not lstAcuerdoDisponible.ItemCount = 0 Then
                If xserv.CreateAllAcuerdoXCliente(cmbCliente.EditValue, pResult, PublicLoginInfo.Environment) Then
                    If pResult = "Ok" Then
                        LlenarListas()
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
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        AsignaAcuerdo()
    End Sub

    Private Sub btnAgregarTodo_Click(sender As Object, e As EventArgs) Handles btnAgregarTodo.Click
        AsignaTodoAcuerdo()
    End Sub

    Private Sub QuitaAcuerdo()
        Dim pResult As String = ""
        Try
            Dim validar As Boolean = True
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")
            For i = 0 To lstAcuerdoAsignado.SelectedItems.Count - 1
                pResult = ""
                If xserv.DeleteAcuerdoXCliente(lstAcuerdoAsignado.SelectedItems.Item(i)("ACUERDO_COMERCIAL_ID"), cmbCliente.EditValue, pResult, PublicLoginInfo.Environment) Then
                    If Not pResult = "Ok" Then
                        NotifyStatus(pResult, True, True)
                        validar = False
                        Exit For
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Next
            If validar Then
                LlenarListas()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub QuitaTodoAcuerdo()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Tariff.WMS_TariffSoapClient("WMS_TariffSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Tariff.asmx")

            If Not lstAcuerdoAsignado.ItemCount = 0 Then
                If xserv.DeleteAllAcuerdoXCliente(cmbCliente.EditValue, pResult, PublicLoginInfo.Environment) Then
                    If pResult = "Ok" Then
                        LlenarListas()
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

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        QuitaAcuerdo()
    End Sub

    Private Sub btnQuitarTodo_Click(sender As Object, e As EventArgs) Handles btnQuitarTodo.Click
        QuitaTodoAcuerdo()
    End Sub
End Class
Public Class frmRelateOperatorModule

    Private Sub frmRelateOperatorModule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub
    Sub RefreshData()
        RefreshAvailableOperators()
        RefreshAvailableLocations()
    End Sub
    Sub RefreshAvailableOperators()
        Dim pResult As String = ""
        Dim xdata As New DataSet

        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")

        Try
            Me.cmbOperador.Properties.NullText = "SELECCIONE OPERADOR"

            xdata = xserv.GetAvailable_Operators(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.cmbOperador.Properties.DataSource = xdata.Tables(0)
                Me.cmbOperador.Properties.ValueMember = "LOGIN_ID"
                Me.cmbOperador.Properties.DisplayMember = "LOGIN_NAME"

                btnAceptar.Enabled = True
            Else
                Me.cmbOperador.Properties.DataSource = Nothing
                btnAceptar.Enabled = False
                MessageBox.Show(pResult)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub RefreshAvailableLocations()
        Dim pResult As String = ""
        Dim xdata As New DataSet

        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")

        Try
            Me.cmbLocation.Properties.NullText = "SELECCIONE UBICACION"

            xdata = xserv.GetAvailable_Locations(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.cmbLocation.Properties.DataSource = xdata.Tables(0)
                Me.cmbLocation.Properties.ValueMember = "LOCATION_SPOT"
                Me.cmbLocation.Properties.DisplayMember = "LOCATION_SPOT"

                btnAceptar.Enabled = True
            Else
                Me.cmbLocation.Properties.DataSource = Nothing
                btnAceptar.Enabled = False
                MessageBox.Show(pResult)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim pResult As String = ""
        Dim xdata As New DataSet
        Dim xrow As DataRowView

        Dim pOperator As String = ""
        Dim pOperatorName As String = ""
        Dim pLocation As String = ""
        Dim pLineID As String = ""

        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")

        Try
            xrow = cmbOperador.GetSelectedDataRow()
            pOperator = xrow("LOGIN_ID")
            pOperatorName = xrow("LOGIN_NAME")

            xrow = cmbLocation.GetSelectedDataRow()
            pLocation = xrow("LOCATION_SPOT")
            pLineID = xrow("LINE_ID")

            If xserv.CreateLoginXLoc(pOperator, pOperatorName, "PICKING", pLineID, pLocation, "PICKING", pResult, PublicLoginInfo.Environment) Then
                RefreshData()
            Else
                If xserv.UpdateLoginXLoc(pOperator, "", pOperatorName, "PICKING", pLineID, pLocation, "PICKING", pResult, PublicLoginInfo.Environment) Then
                    RefreshData()
                Else
                    MessageBox.Show(pResult)
                    RefreshData()
                End If
            End If

        Catch ex As Exception
            RefreshData()
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
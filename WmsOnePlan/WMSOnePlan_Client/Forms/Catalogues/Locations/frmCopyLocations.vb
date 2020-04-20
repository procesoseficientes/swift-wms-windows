Public Class frmCopyLocations

    Private Sub btnCopyPartition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyPartition.Click
        Dim i As Integer = 1
        Dim pNewPartion As String
        Dim pCountSuccess As Integer = 0, pCountError = 0
        Dim pNewLocation As String = ""
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
        Dim xData As DataSet = xserv.SearchByKeyShelfSpots(Me.LabelControl2.Tag, Me.LabelControl2.Text, pResult, PublicLoginInfo.Environment)
        Dim xDR As DataRow

        If pResult = "OK" Then
            xDR = xData.Tables(0).Rows(0)
            For i = 1 To CInt(Me.SpinEdit1.Text)
                pNewPartion = CStr(xDR("SPOT_PARTITION"))
                pNewLocation = CStr(CInt(pNewPartion) + i)
                If Len(pNewLocation) = 1 Then
                    pNewLocation = "0" + pNewLocation
                End If
                pNewPartion = pNewLocation
                pNewLocation = Mid(xDR("LOCATION_SPOT"), 1, InStr(xDR("LOCATION_SPOT"), "P")) & pNewLocation

                If xserv.CreateShelfSpots(xDR("WAREHOUSE_PARENT"), pNewLocation, xDR("SPOT_TYPE").ToString, xDR("SPOT_ORDERBY"), xDR("SPOT_AISLE"), xDR("SPOT_COLUMN"), xDR("SPOT_LEVEL"), xDR("ALLOW_PICKING"), xDR("ALLOW_STORAGE"), xDR("ALLOW_REALLOC"), xDR("AVAILABLE"), xDR("ZONE"), pNewPartion, "P" + pNewPartion, xDR("LINE_ID"), xDR("MAX_MT2_OCCUPANCY"), xDR("MAX_WEIGHT"), pResult, PublicLoginInfo.Environment, "", xDR("VOLUME"), xDR("ALLOW_FAST_PICKING"), xDR("IS_WASTE")) Then
                    pCountSuccess = pCountSuccess + 1
                Else
                    pCountError = pCountError + 1
                End If
                ProgressBarControl1.EditValue = ((i * 100) / CInt(Me.SpinEdit1.Text))
                ProgressBarControl1.Refresh()
            Next
        End If
        MessageBox.Show("Proceso Completado . Errores: " & CStr(pCountError))
        Close()
    End Sub

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Close()
    End Sub
End Class
Public Class frmServicesComments

    Private Sub LabelControl2_Click(sender As System.Object, e As System.EventArgs) Handles LabelControl2.Click

    End Sub

    Private Sub btnSaveComments_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveComments.Click
        SaveCommentsAndReferences()
    End Sub
    Public Sub ShowRelated(pClientCode As Integer)
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")

        Dim xfrm As New frmRelateServices
        xfrm = xfrmLoaded

        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup
        Dim xcol(1) As DataColumn
        Try
            xfrm.GridControlRelatedServices.DataSource = Nothing
            xfrm.GridControlRelatedServices.Refresh()
            xfrm.GridViewServices.ViewCaption = "Servicios Disponibles para " + xfrm.gClientName

            xfrm.gRelatedDSet = xserv.GetAllServicesRelatedTo(pClientCode, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                xfrm.GridControlRelatedServices.DataSource = xfrm.gRelatedDSet.Tables(0)
            Else
                Me.Cursor = Cursors.Default
                NotifyStatus(pResult, False, True)
            End If

        Catch ex As Exception
            xfrm.gRelatedDSet = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xfrm.gRelatedDSet = Nothing
        xserv = Nothing


    End Sub
    Sub SaveCommentsAndReferences()
        Try
            Dim i As Integer = 0
            Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")

            Dim xdataset As New DataSet
            Dim pResult As String = ""
            Dim xgrp As New ListViewGroup
            Me.Cursor = Cursors.WaitCursor
            Try
                If xserv.UpdateServiceComments(txtComments.Tag, Me.lblService.Tag, Me.txtComments.Text.ToUpper.Replace("'", ""), Me.txtReferences.Text.ToUpper.Replace("'", ""), PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                    If pResult = "OK" Then
                        ShowRelated(Me.txtComments.Tag)
                        Me.Close()

                    Else
                        NotifyStatus(pResult, False, True)
                        Me.Cursor = Cursors.Default
                        'MessageBox.Show(pResult, False, True)
                    End If
                Else
                    Me.Cursor = Cursors.Default
                    NotifyStatus(pResult, False, True)
                End If

            Catch ex As Exception
                xdataset = Nothing
                xserv = Nothing
                Me.Cursor = Cursors.Default
                MessageBox.Show(ex.Message)
            End Try
            Me.Cursor = Cursors.Default
            xdataset = Nothing
            xserv = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmServicesComments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
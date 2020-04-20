Public Class frmRelateServices
    Public gRelatedDSet As New DataSet
    Public gClientName As String = ""
    Public gServiceID As String = ""
    Public gERP_Code As String = ""
    Public gServiceDesc As String = ""
    Public gServiceComments As String = ""
    Public gComments As String = ""
    Public gRefs As String = ""

    Private Sub frmRelateServices_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmRelateServices_Deactivate(sender As Object, e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmRelateServices_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmRelateServices_Enter(sender As Object, e As System.EventArgs) Handles Me.Enter

    End Sub

    Private Sub frmRelateServices_GotFocus(sender As Object, e As System.EventArgs) Handles Me.GotFocus

    End Sub

    Private Sub frmRelateServices_HandleCreated(sender As Object, e As System.EventArgs) Handles Me.HandleCreated

    End Sub

    Private Sub frmRelateServices_Leave(sender As Object, e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
    End Sub
    Private Sub frmRelateServices_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SearchByPartial()
        gLastScreenShowed = Me.Name
    End Sub
    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup
        Me.Cursor = Cursors.WaitCursor
        Try
            xdataset = xserv.GetAllClientsWithServices(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControlClientes.DataSource = xdataset.Tables(0)
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
        Return True
    End Function

    Private Sub GridControlClientes_Click(sender As System.Object, e As System.EventArgs) Handles GridControlClientes.Click
        Try
            Dim xdatarow As DataRow = GridViewClientes.GetDataRow(GridViewClientes.FocusedRowHandle)
            Dim pClientCode As String = xdatarow("CLIENT_ERP_CODE").ToString
            gClientName = xdatarow(1).ToString
            gERP_Code = pClientCode

            ShowNotRelated(pClientCode)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub ShowNotRelated(pClientCode As Integer)
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup
        Dim xcol(1) As DataColumn
        Me.Tag = pClientCode
        Me.Cursor = Cursors.WaitCursor
        Try
            GridControlServices.DataSource = Nothing
            GridControlServices.Refresh()
            GridViewRelatedServices.ViewCaption = "Servicios Agregados a " + gClientName
            xdataset = xserv.GetAllServicesNotRelated(pClientCode, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridControlServices.DataSource = xdataset.Tables(0)

            Else
                Me.Cursor = Cursors.Default
                NotifyStatus(pResult, False, True)
            End If
            ShowRelated(pClientCode)
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing
            Me.Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Me.Cursor = Cursors.Default

    End Sub
    Public Sub ShowRelated(pClientCode As Integer)
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")


        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup
        Dim xcol(1) As DataColumn
        Try
            GridControlRelatedServices.DataSource = Nothing
            GridControlRelatedServices.Refresh()
            GridViewServices.ViewCaption = "Servicios Disponibles para " + gClientName

            gRelatedDSet = xserv.GetAllServicesRelatedTo(pClientCode, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                GridControlRelatedServices.DataSource = gRelatedDSet.Tables(0)
            Else
                Me.Cursor = Cursors.Default
                NotifyStatus(pResult, False, True)
            End If

        Catch ex As Exception
            gRelatedDSet = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        gRelatedDSet = Nothing
        xserv = Nothing


    End Sub
    Sub RelateServices(pServiceID As String)
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")
            xserv.RelateServiceTo(Me.Tag, pServiceID, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult <> "OK" Then
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub ToolStripButton7_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton7.Click
        Dim i As Integer = 0
        Dim xrows() As Integer
        xrows = GridViewServices.GetSelectedRows
        Dim xrow As DataRow

        Try
            For i = 0 To (xrows.Length - 1)
                xrow = GridViewServices.GetDataRow(xrows(i))
                RelateServices(xrow("SERVICE_ID"))
            Next
            SearchByPartial()
            ShowNotRelated(Me.Tag)

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub ToolStripButton3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton3.Click
        SearchByPartial()
    End Sub

    Private Sub ToolStripButton14_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton14.Click
        Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")
        Dim pResult As String = ""
        Dim xDRow As DataRow
        Dim xrows As Integer = Me.GridViewRelatedServices.DataRowCount
        Try
            Me.Cursor = Cursors.WaitCursor
            For i = 0 To (xrows - 1)
                xDRow = GridViewRelatedServices.GetDataRow(i)
                If Not xserv.UpdateService(Me.Tag, xDRow("SERVICE_ID"), PublicLoginInfo.LoginID, xDRow("QTY"), pResult, PublicLoginInfo.Environment) Then
                    NotifyStatus(pResult, True, True)
                    Exit For
                End If
            Next
            SearchByPartial()
            ShowNotRelated(Me.Tag)
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try

    End Sub

    Private Sub frmRelateServices_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub ToolStripButton11_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton11.Click
        Dim i As Integer = 0
        Dim xrows() As Integer
        xrows = GridViewRelatedServices.GetSelectedRows

        Dim xrow As DataRow
        Try
            If MessageBox.Show("Confirma la eliminacion de " & xrows.Length & " servicio(s)?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                For i = 0 To (xrows.Length - 1)
                    xrow = GridViewRelatedServices.GetDataRow(xrows(i))
                    UnRelateServices(xrow("SERVICE_ID"))
                Next
                SearchByPartial()
                ShowNotRelated(Me.Tag)

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub
    Sub UnRelateServices(pServiceSequence As Integer)
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_ServicesToBill.WMS_ServicesToBillSoapClient("WMS_ServicesToBillSoap", PublicLoginInfo.WSHost + "/trans/wms_servicestobill.asmx")
            xserv.UnRelateServiceTo(Me.Tag, pServiceSequence, PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult <> "OK" Then
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub GridControlServices_Click(sender As System.Object, e As System.EventArgs) Handles GridControlServices.Click

    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Dim pFileName As String = ""

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                pFileName = SaveFileDialog1.FileName
                Me.GridViewClientes.ExportToXls(pFileName)

            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click
        Try
            Dim pFileName As String = ""

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                pFileName = SaveFileDialog1.FileName
                Me.GridViewServices.ExportToXls(pFileName)

            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub ToolStripButton9_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton9.Click
        Try
            Dim pFileName As String = ""

            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                pFileName = SaveFileDialog1.FileName
                Me.GridViewRelatedServices.ExportToXls(pFileName)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub GridControlRelatedServices_Click(sender As System.Object, e As System.EventArgs) Handles GridControlRelatedServices.Click

    End Sub

    Private Sub GridViewRelatedServices_DoubleClick(sender As Object, e As System.EventArgs) Handles GridViewRelatedServices.DoubleClick
        Dim xfrm As New frmServicesComments
        xfrm.lblService.Text = gServiceDesc
        xfrm.lblService.Tag = gServiceID
        xfrm.txtComments.Tag = gERP_Code
        xfrm.txtComments.Text = gComments
        xfrm.txtReferences.Text = gRefs
        xfrm.ShowDialog()

    End Sub

    Private Sub GridViewRelatedServices_FocusedRowLoaded(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowEventArgs) Handles GridViewRelatedServices.FocusedRowLoaded
        
    End Sub

    Private Sub GridControlRelatedServices_DoubleClick(sender As Object, e As System.EventArgs) Handles GridControlRelatedServices.DoubleClick

    End Sub

    Private Sub GridViewRelatedServices_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridViewRelatedServices.RowClick
        Try
            Dim xRow As DataRow
            Dim xdesc As String = ""
            xRow = GridViewRelatedServices.GetDataRow(e.RowHandle)

            gServiceID = xRow("SERVICE_ID")
            gServiceDesc = xRow("SERVICE_DESCRIPTION")
            gComments = xRow("COMMENTS").ToString
            gRefs = xRow("REF_DOCS").ToString

        Catch ex As Exception

            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub GridViewRelatedServices_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridViewRelatedServices.SelectionChanged

    End Sub

    Private Sub frmRelateServices_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub
End Class
Imports System.Configuration.ConfigurationManager

Public Class frmOperatorXModules

    Private Sub frmOperatorXModules_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
        RefreshView()
    End Sub

    Private Sub frmOperatorXModules_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmOperatorXModules_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmOperatorXModules_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmOperatorXModules_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmOperatorXModules_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'RefreshView()
        gLastScreenShowed = Me.Name
    End Sub
    Sub RefreshView()
        Dim xdata As New DataSet
        Dim pResult As String = ""


        Try
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")
            xdata = xserv.GetModules_X_Operator(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                DGC_OperatorsXModule.DataSource = xdata.Tables(0)
            Else
                DGC_OperatorsXModule.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gLastScreenShowed = Me.Name
        Me.Close()
    End Sub


    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Dim xfrm As New frmRelateOperatorModule
        xfrm.ShowDialog()
    End Sub

    Private Sub btnRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        RefreshView()
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SelectAllNodes()
    End Sub
    Sub SelectAllNodes()
        GridView_ModulosYaAsignados.SelectAll()
    End Sub
    Sub DeleteSelectedNodes()
        Try
            Dim pResponse As DialogResult = DialogResult.No
            Dim xrow As DataRow
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_locations.asmx")

            pResponse = MessageBox.Show("Confirma eliminacion de " & GridView_ModulosYaAsignados.SelectedRowsCount & " Registro(s) ?", "Confirme accion", MessageBoxButtons.YesNo)
            If pResponse = DialogResult.Yes Then
                If GridView_ModulosYaAsignados.SelectedRowsCount >= 1 Then
                    For i = 0 To GridView_ModulosYaAsignados.RowCount - 1
                        If GridView_ModulosYaAsignados.IsRowSelected(i) Then
                            xrow = GridView_ModulosYaAsignados.GetDataRow(i)
                            If Not xserv.DeleteLoginXLoc(xrow("LOGIN_ID").ToString, "PICKING", xrow("LINE_ID").ToString, xrow("LOCATION_SPOT").ToString, "PICKING", pResult, PublicLoginInfo.Environment) Then
                                pResponse = MessageBox.Show(pResult + " Desea continuar?", "Confirme accion", MessageBoxButtons.YesNo)
                                If pResponse = DialogResult.No Then
                                    Exit Sub
                                End If
                            Else
                                'RefreshView()
                            End If
                        End If
                    Next
                End If
                RefreshView()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        DeleteSelectedNodes()
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick

        Dim pFileName As String = ""

        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            pFileName = SaveFileDialog1.FileName
            GridView_ModulosYaAsignados.ExportToXls(pFileName)
        End If


    End Sub
End Class
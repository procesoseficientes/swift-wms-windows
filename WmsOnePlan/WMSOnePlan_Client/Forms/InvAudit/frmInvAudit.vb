Imports System.IO
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraReports.UI

Public Class frmInvAudit

    Private Sub btnNuevo_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNuevo.ItemClick
        Dim fs As New frmNewAudit

        fs.ShowDialog()
        cargaConteos()
    End Sub

    Private Sub frmInvAudit_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmInvAudit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strPath As String
            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInvAudit" & PublicLoginInfo.LoginID & ".xml"
            If File.Exists(strPath) Then
                AdvBandedGridView1.RestoreLayoutFromXml(strPath)
                strPath = String.Empty
            End If

            cargaConteos()
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        End Try

    End Sub
    Public Sub cargaConteos()
        Try
            Dim pResult As String = String.Empty
            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
            Dim xSecurity As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_Security.asmx")
            Dim dsConteos As New DataSet
            dsConteos = xserv.get_all_counts(PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                GridControl1.DataSource = dsConteos.Tables(0)
                GridView1.BestFitColumns()
            Else
                MessageBox.Show("Error en servicio: " + pResult, "Error")
            End If

            Dim dsUsuarios As New DataSet
            dsUsuarios = xSecurity.SearchOperators(pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                If Not IsNothing(dsUsuarios) Then
                    RepositoryItemGridLookUpEdit1.DataSource = dsUsuarios.Tables(0)
                    RepositoryItemGridLookUpEdit1.PopulateViewColumns()
                    RepositoryItemGridLookUpEdit1.ValueMember = "LOGIN_ID"
                    RepositoryItemGridLookUpEdit1.DisplayMember = "LOGIN_NAME"

                    For i = 0 To RepositoryItemGridLookUpEdit1.View.Columns.Count - 1
                        RepositoryItemGridLookUpEdit1.View.Columns(i).Visible = False
                    Next
                    RepositoryItemGridLookUpEdit1.View.Columns("LOGIN_ID").Caption = "USUARIO"
                    RepositoryItemGridLookUpEdit1.View.Columns("LOGIN_NAME").Caption = "NOMBRE"
                    RepositoryItemGridLookUpEdit1.View.Columns("LOGIN_ID").Visible = True
                    RepositoryItemGridLookUpEdit1.View.Columns("LOGIN_NAME").Visible = True
                End If
            Else
                MsgBox(pResult)
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnExcel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExcel.ItemClick
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Documentos de Excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                If XtraTabControl1.SelectedTabPage.Name = XtraTabPage1.Name Then
                    GridView1.ExportToXlsx(SaveFileDialog1.FileName)
                Else
                    AdvBandedGridView1.ExportToXlsx(SaveFileDialog1.FileName)
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try
            If XtraTabControl1.SelectedTabPage.Name = XtraTabPage1.Name Then
                PrintableComponentLink1.ShowPreview()
            Else
                PrintableComponentLink2.ShowPreview()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnAssign_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAssign.ItemClick
        Try
            If Not IsNothing(cmbAsignar.EditValue) Then
                Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
                Dim dsAsignar As New DataSet
                Dim dtAsignar As New DataTable
                Dim dc1 As New DataColumn
                Dim dc2 As New DataColumn
                Dim dc3 As New DataColumn
                Dim dc4 As New DataColumn
                Dim pRESULT As String = String.Empty

                dsAsignar.Tables.Clear()
                dsAsignar.Tables.Add(dtAsignar)

                dc1.ColumnName = "COUNT_ID"
                dc1.DataType = System.Type.GetType("System.Int16")
                dtAsignar.Columns.Add(dc1)
                dc1 = Nothing

                dc2.ColumnName = "SERIAL_NUMBER"
                dc2.DataType = System.Type.GetType("System.Int16")
                dtAsignar.Columns.Add(dc2)

                dc3.ColumnName = "ASIGNAR_A"
                dc3.DataType = System.Type.GetType("System.String")
                dtAsignar.Columns.Add(dc3)

                dc4.ColumnName = "ASIGNADO_POR"
                dc4.DataType = System.Type.GetType("System.String")
                dtAsignar.Columns.Add(dc4)

                dc1 = Nothing
                dc2 = Nothing
                dc3 = Nothing
                dc4 = Nothing

                Dim dr As DataRow
                Dim Rows As New ArrayList()
                Dim i As Int16
                If AdvBandedGridView1.SelectedRowsCount > 0 Then
                    For i = 0 To AdvBandedGridView1.SelectedRowsCount - 1
                        If (AdvBandedGridView1.GetSelectedRows()(i) >= 0) Then
                            Rows.Add(AdvBandedGridView1.GetDataRow(AdvBandedGridView1.GetSelectedRows()(i)))
                        End If
                    Next

                    AdvBandedGridView1.BeginUpdate()
                    For i = 0 To Rows.Count - 1
                        Dim Row As DataRow = CType(Rows(i), DataRow)
                        If String.IsNullOrEmpty(Row("COUNTED_DATE").ToString) And String.IsNullOrEmpty(Row("COMPLETED_DATE").ToString) And String.IsNullOrEmpty(Row("CANCELED_DATE").ToString) Then
                            Row("ASSIGNED_TO") = cmbAsignar.EditValue.ToString
                            Row("ASSIGNED_DATE") = DateTime.Now

                            dr = dtAsignar.NewRow
                            dr("COUNT_ID") = Row("COUNT_ID")
                            dr("SERIAL_NUMBER") = Row("SERIAL_NUMBER")
                            dr("ASIGNAR_A") = cmbAsignar.EditValue.ToString
                            dr("ASIGNADO_POR") = PublicLoginInfo.LoginID

                            dtAsignar.Rows.Add(dr)
                            dr = Nothing
                        End If
                    Next
                    If dsAsignar.Tables(0).Rows.Count > 0 Then
                        xserv.assing_counting_task(dsAsignar, PublicLoginInfo.Environment, pRESULT)
                        If Not pRESULT = "OK" Then
                            MsgBox(" Error en el servicio: " & pRESULT)
                        End If
                    Else
                        MessageBox.Show("No hay filas actualizables", "Advertencia")
                    End If
                    AdvBandedGridView1.EndUpdate()
                Else
                    MsgBox("Debe seleccionar las filas a asignar")
                End If
            Else
                MsgBox("Debe seleccionar un bodeguero")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub leeDetalle()
        Dim pResult As String = String.Empty
        Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
        Dim dsTareas As New DataSet
        dsTareas = xserv.get_all_count_tasks(Val(GridView1.GetFocusedRowCellValue("COUNT_ID")), PublicLoginInfo.Environment, pResult)
        If pResult = "OK" Then
            GridControl2.DataSource = dsTareas.Tables(0)
            AdvBandedGridView1.BestFitColumns()
        Else
            MessageBox.Show("Error en servicio: " + pResult, "Error")
        End If
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Try
            If XtraTabControl1.SelectedTabPage.Name = XtraTabPage2.Name Then
                leeDetalle()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub frmInvAudit_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dim strPath As String
            gLastScreenShowed = Me.Name

            'grabamos el layout de la forma 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmInvAudit" & PublicLoginInfo.LoginID & ".xml"

            AdvBandedGridView1.SaveLayoutToXml(strPath)
            strPath = String.Empty
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
       
    End Sub

    Private Sub btnDiff_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDiff.ItemClick
        Try
            If GridView1.SelectedRowsCount > 0 Then
                Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
                Dim dsConteos As New DataSet
                Dim pRESULT As String = String.Empty
                dsConteos = xserv.get_count_dif(Val(GridView1.GetFocusedRowCellValue("COUNT_ID")), PublicLoginInfo.Environment, pRESULT)
                If pRESULT = "OK" Then
                    Dim rpt As New rptDif
                    rpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                    rpt.DataSource = dsConteos
                    rpt.ShowPreview()
                Else
                    MessageBox.Show("Error en el servicio: " + pRESULT, "Error")
                End If
            Else
                MessageBox.Show("Debe seleccionar al menos una fila", "Error")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub GridView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.DoubleClick
        Try
            Dim view As GridView = CType(sender, GridView)
            Dim pt As Point = view.GridControl.PointToClient(Control.MousePosition)

            Dim info As GridHitInfo = view.CalcHitInfo(pt)

            If info.InRow OrElse info.InRowCell Then

                GridView1.SelectRow(info.RowHandle)

                XtraTabControl1.SelectedTabPage = XtraTabPage2
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick

    End Sub

    Private Sub GridControl1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GridControl1.MouseDoubleClick
        
    End Sub

    Private Sub btnCancelar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCancelar.ItemClick
        Try

            Dim xserv As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/Trans/WMS_TasksAdmin.asmx")
            Dim dsAsignar As New DataSet
            Dim dtAsignar As New DataTable
            Dim dc1 As New DataColumn
            Dim dc2 As New DataColumn
            Dim pRESULT As String = String.Empty

            dsAsignar.Tables.Clear()
            dsAsignar.Tables.Add(dtAsignar)

            dc1.ColumnName = "COUNT_ID"
            dc1.DataType = System.Type.GetType("System.Int16")
            dtAsignar.Columns.Add(dc1)
            dc1 = Nothing

            dc2.ColumnName = "SERIAL_NUMBER"
            dc2.DataType = System.Type.GetType("System.Int16")
            dtAsignar.Columns.Add(dc2)

            dc1 = Nothing
            dc2 = Nothing

            Dim dr As DataRow
            Dim Rows As New ArrayList()
            Dim i As Int16
            If AdvBandedGridView1.SelectedRowsCount > 0 Then
                For i = 0 To AdvBandedGridView1.SelectedRowsCount - 1
                    If (AdvBandedGridView1.GetSelectedRows()(i) >= 0) Then
                        Rows.Add(AdvBandedGridView1.GetDataRow(AdvBandedGridView1.GetSelectedRows()(i)))
                    End If
                Next

                AdvBandedGridView1.BeginUpdate()
                For i = 0 To Rows.Count - 1
                    Dim Row As DataRow = CType(Rows(i), DataRow)
                    If String.IsNullOrEmpty(Row("COUNTED_DATE").ToString) And String.IsNullOrEmpty(Row("COMPLETED_DATE").ToString) And String.IsNullOrEmpty(Row("CANCELED_DATE").ToString) Then
                        Row("CANCELED_DATE") = DateTime.Now

                        dr = dtAsignar.NewRow
                        dr("COUNT_ID") = Row("COUNT_ID")
                        dr("SERIAL_NUMBER") = Row("SERIAL_NUMBER")

                        dtAsignar.Rows.Add(dr)
                        dr = Nothing
                    End If
                Next
                If dsAsignar.Tables(0).Rows.Count > 0 Then
                    xserv.cancel_counting_task(dsAsignar, PublicLoginInfo.Environment, pRESULT)
                    If Not pRESULT = "OK" Then
                        MsgBox(" Error en el servicio: " & pRESULT)
                    End If
                Else
                    MessageBox.Show("No hay filas actualizables", "Advertencia")
                End If
                AdvBandedGridView1.EndUpdate()
            Else
                MsgBox("Debe seleccionar las filas a cancelar")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
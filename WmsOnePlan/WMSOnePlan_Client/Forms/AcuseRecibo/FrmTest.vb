
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmTest

    Private Sub LlenarGrid()
        Dim dt As New DataTable("DatosTes")
        dt.Columns.Add("Col1")


        For i As Integer = 0 To 5
            dt.Rows.Add(i.ToString())
        Next
        GridControl1.DataSource = dt

        Dim dt1 As New DataTable("DatosTes")
        dt1.Columns.Add("Col1")


        For i As Integer = 6 To 10
            dt1.Rows.Add(i.ToString())
        Next
        GridControl2.DataSource = dt1

    End Sub


    Public dowTest As GridHitInfo
    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        Dim view As GridView
        view = CType(sender, GridView)
        dowTest = Nothing
        Dim hitInfo As GridHitInfo
        hitInfo = view.CalcHitInfo(New Point(e.X, e.Y))
        If Not Control.ModifierKeys = Keys.None Then
            Return
        End If
        If e.Button = MouseButtons.Left And hitInfo.RowHandle >= 0 Then

            dowTest = hitInfo
        End If
    End Sub

    Private Sub GridView1_MouseMove(sender As Object, e As MouseEventArgs) Handles GridView1.MouseMove
        Dim view As GridView
        view = CType(sender, GridView)
        If dowTest Is Nothing Then
            Return
        End If
        If e.Button = MouseButtons.Left And dowTest.RowHandle >= 0 Then
            Dim dragSize As Size = SystemInformation.DragSize
            Dim dragRect As Rectangle = New Rectangle(New Point(dowTest.HitPoint.X - dragSize.Width / 2, dowTest.HitPoint.Y - dragSize.Height / 2), dragSize)
            If Not dragRect.Contains(New Point(e.X, e.Y)) Then
                Dim row As DataRow = GridView1.GetDataRow(dowTest.RowHandle)
                view.GridControl.DoDragDrop(row, DragDropEffects.Move)
                dowTest = Nothing
                DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True
            End If
        End If
    End Sub
    Private Sub FrmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenarGrid()
    End Sub

    Private Sub GridControl1_DragOver(sender As Object, e As DragEventArgs) Handles GridControl2.DragOver
        If e.Data.GetDataPresent(GetType(DataRow)) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub GridControl1_DragDrop(sender As Object, e As DragEventArgs) Handles GridControl2.DragDrop
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim table As DataTable = TryCast(grid.DataSource, DataTable)
        Dim row As DataRow = TryCast(e.Data.GetData(GetType(DataRow)), DataRow)
        If Not row Is Nothing And Not table Is Nothing And Not row.Table Is table Then
            table.ImportRow(row)
            row.Delete()
        End If

        'If row IsNot Nothing AndAlso table IsNot Nothing AndAlso row.Table <> table Then
        'End If
    End Sub

End Class
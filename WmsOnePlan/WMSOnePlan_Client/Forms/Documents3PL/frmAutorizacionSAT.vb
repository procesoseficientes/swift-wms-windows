Public Class frmAutorizacionSAT 

    'Declaramos la variable del servicio que esta vinculado a este form
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")

    Private Sub frmAutorizacionSAT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmAutorizacionSAT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarGrid(" where STATUS in ( 1, 2) ")
    End Sub

    Private Sub LlenarGrid(ByVal pCondicion As String)

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            'traemos por default del webservice las polizas que su estado es 1 o dos o sea que no han sido procesadas por la sat o que no ha sido impreso el acuse
            xdataset = xserv.get_Sync_Poliza(pCondicion, PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                GridAutorizaciones.DataSource = xdataset.Tables(0)
            End If

            'seteamos los elementos visuales del grid

            GridViewAutorizaciones.BestFitColumns()

            xdataset = xserv.Get_Num_Status(PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                VGridStats.DataSource = xdataset.Tables(0)
            End If

        Catch ex As Exception
            xdataset = Nothing
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        xdataset = Nothing
        pResult = Nothing
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim xdataset As New DataSet
        Dim pResult As String = ""

        Try
            SendPolizas()

            'validamos que la poliza exista
            'If Trim(txtPoliza.Text).Length > 0 Then
            '    xdataset = xserv.get_Poliza(txtPoliza.Text, PublicLoginInfo.Environment, pResult)
            'End If
            'le mandamos al webservice para que haga el insert o update de las polizas que cambiaron en el datagrid.
            If xdataset.Tables(0).Rows.Count > 0 Then
                xdataset.Tables(0).Columns("POLIZA").ToString()
            Else
                MsgBox("La poliza ingresada no existe", MsgBoxStyle.Information, "Advertencia")
            End If
        Catch ex As Exception
            MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub SendPolizas()
        Try
            Dim pResult As String = ""
            Dim poliza = String.Empty
            Dim docId As Integer = 0
            Dim listaIndicesGrid As New List(Of Integer)
            listaIndicesGrid = GridViewAutorizaciones.GetSelectedRows.ToList
            Dim dateSend As DateTime
            Dim dateReceived As DateTime

            For i As Integer = 0 To listaIndicesGrid.Count - 1

                dateSend = DateTime.Now

                poliza = GridViewAutorizaciones.GetRowCellValue(listaIndicesGrid(i), GridViewAutorizaciones.Columns("POLIZA")).ToString()
                docId = Integer.Parse(GridViewAutorizaciones.GetRowCellValue(listaIndicesGrid(i), GridViewAutorizaciones.Columns("DOC_ID")).ToString())

                'sat

                dateReceived = DateTime.Now
                Dim actualizao As Boolean
                actualizao = xserv.Update_Autorization_Sat(docId, "pSendResult", dateSend, dateReceived, PublicLoginInfo.Environment, pResult)
            Next
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        GridViewAutorizaciones.SelectAll()
    End Sub

    Private Sub btnUnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnSelect.Click
        Dim i As Integer
        If GridViewAutorizaciones.SelectedRowsCount > 0 Then
            For i = 0 To GridViewAutorizaciones.SelectedRowsCount - 1
                GridViewAutorizaciones.UnselectRow(i)
            Next
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Dim frm As New frmIngresoAutorizationSyncSat
        frm.ShowDialog()
        If frm.DialogResult = DialogResult.OK Then
            LlenarGrid(" where STATUS in ( 1, 2) ")
        End If
    End Sub

    Private Sub btnStby_Click(sender As Object, e As EventArgs) Handles btnStby.Click
        LlenarGrid(" where STATUS = 1")
    End Sub

    Private Sub btnReyected_Click(sender As Object, e As EventArgs) Handles btnReyected.Click
        LlenarGrid(" where STATUS = 2")
    End Sub

    Private Sub btnAproved_Click(sender As Object, e As EventArgs) Handles btnAproved.Click
        LlenarGrid(" where STATUS = 3")
    End Sub
End Class
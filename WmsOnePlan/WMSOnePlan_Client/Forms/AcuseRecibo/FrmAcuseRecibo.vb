Imports System.IO
Imports DevExpress.PivotGrid.OLAP.AdoWrappers
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Extensions

Public Class FrmAcuseRecibo

    Private _lstFotos As New List(Of Bitmap)
    Private _indeceFoto1 As Integer = 0
    Private _cantidadFotos As Integer = 0

    Private Sub LlenarGrid()
        If Not dtFechaInicio.EditValue = Nothing And Not dtFechaFinal.EditValue = Nothing Then
            Dim xserv As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim xdataset As New DataSet
            Dim pResult As String = ""
            Try
                xdataset = xserv.GetAcuseRecibo(Date.Parse(dtFechaInicio.EditValue), Date.Parse(dtFechaFinal.EditValue), pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    Me.GridControl1.DataSource = xdataset.Tables(0)
                    Me.GridView1.ExpandAllGroups()
                Else
                    NotifyStatus(pResult, False, True)
                    Me.GridControl1.DataSource = Nothing
                End If
            Catch ex As Exception
                NotifyStatus(ex.Message, True, True)
            End Try
        End If
    End Sub

    Private Sub dtFechaInicio_EditValueChanged(sender As Object, e As EventArgs) Handles dtFechaInicio.EditValueChanged, dtFechaFinal.EditValueChanged
        LlenarGrid()
    End Sub

    Private Sub btnFiltar_Click(sender As Object, e As EventArgs) Handles btnFiltar.Click
        LlenarGrid()
    End Sub

    Private Sub FrmAcuseRecibo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFechaInicio.EditValue = DateTime.Today
        dtFechaFinal.EditValue = DateTime.Today
    End Sub
    Private Sub pnlGrup_Leave(sender As Object, e As EventArgs) Handles pnlFotografias.Leave
        pnlFotografias.Visible = False
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        pnlFotografias.Visible = False
        If TransitionManager1.IsTransition Then
            TransitionManager1.EndTransition()
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try

            If GridView1.SelectedRowsCount = 1 Then
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)

                If CType(xdatarow("FOTO_1"), Byte()).Length > 0 Then
                    pctFoto1.Image = Nothing
                    pctFoto2.Image = Nothing
                    pctFoto3.Image = Nothing
                    pctFoto4.Image = Nothing
                    pnlFotografias.Location = New Point(Me.Width / 3.5, Me.Height / 6.5)
                    pctFoto1.Image = New Bitmap(New MemoryStream(CType(xdatarow("FOTO_1"), Byte())))
                    'lstFotos = New List(Of Bitmap)
                    '_lstFotos.Add(New Bitmap(New MemoryStream(CType(xdatarow("FOTO_1"), Byte()))))

                    If CType(xdatarow("FOTO_2"), Byte()).Length > 0 Then
                        '   _lstFotos.Add(New Bitmap(New MemoryStream(CType(xdatarow("FOTO_2"), Byte()))))
                        pctFoto2.Image = New Bitmap(New MemoryStream(CType(xdatarow("FOTO_2"), Byte())))
                    End If
                    If CType(xdatarow("FOTO_3"), Byte()).Length > 0 Then
                        '  _lstFotos.Add(New Bitmap(New MemoryStream(CType(xdatarow("FOTO_3"), Byte()))))
                        pctFoto3.Image = New Bitmap(New MemoryStream(CType(xdatarow("FOTO_3"), Byte())))
                    End If

                    '_cantidadFotos = _lstFotos.Count
                    '    '_indeceFoto1 = 1
                    '    If _cantidadFotos = 3 Then
                    '        pctFoto1.Image = _lstFotos(0)
                    '        pctFoto2.Image = _lstFotos(1)
                    '        pctFoto3.Image = _lstFotos(2)
                    '    ElseIf _cantidadFotos = 2 Then
                    '        pctFoto1.Image = _lstFotos(0)
                    '        pctFoto2.Image = _lstFotos(1)
                    '    Else
                    '        _indeceFoto1 = 2
                    '        pctFoto2.Image = _lstFotos(0)
                    '    End If
                    pnlFotografias.Visible = True
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs)
        MovSigImg()
    End Sub

    Private Sub MovSigImg()
        pctFoto1.Image = Nothing
        pctFoto2.Image = Nothing
        pctFoto3.Image = Nothing
        Select Case _indeceFoto1
            Case 1
                _indeceFoto1 = 2
                If _cantidadFotos = 3 Then
                    pctFoto2.Image = _lstFotos(0)
                    pctFoto3.Image = _lstFotos(1)
                    pctFoto1.Image = _lstFotos(2)
                    _indeceFoto1 = 2
                ElseIf _cantidadFotos = 2 Then
                    pctFoto2.Image = _lstFotos(0)
                    pctFoto1.Image = _lstFotos(1)

                End If
            Case 2
                If _cantidadFotos = 3 Then
                    pctFoto3.Image = _lstFotos(0)
                    pctFoto1.Image = _lstFotos(1)
                    pctFoto2.Image = _lstFotos(2)
                    _indeceFoto1 = 3
                ElseIf _cantidadFotos = 2 Then
                    pctFoto1.Image = _lstFotos(0)
                    pctFoto2.Image = _lstFotos(1)
                    _indeceFoto1 = 1
                Else
                    pctFoto2.Image = _lstFotos(0)
                End If
            Case 3
                pctFoto1.Image = _lstFotos(0)
                pctFoto2.Image = _lstFotos(1)
                pctFoto3.Image = _lstFotos(2)
                _indeceFoto1 = 1
        End Select
    End Sub

    Private Sub MovAtImg()
        pctFoto1.Image = Nothing
        pctFoto2.Image = Nothing
        pctFoto3.Image = Nothing
        Select Case _indeceFoto1
            Case 1
                If _cantidadFotos = 3 Then
                    pctFoto3.Image = _lstFotos(0)
                    pctFoto1.Image = _lstFotos(1)
                    pctFoto2.Image = _lstFotos(2)
                    _indeceFoto1 = 3
                ElseIf _cantidadFotos = 2 Then
                    pctFoto2.Image = _lstFotos(0)
                    pctFoto1.Image = _lstFotos(1)
                    _indeceFoto1 = 2
                End If
            Case 2
                If _cantidadFotos = 3 Then
                    pctFoto1.Image = _lstFotos(0)
                    pctFoto2.Image = _lstFotos(1)
                    pctFoto3.Image = _lstFotos(2)
                    _indeceFoto1 = 1
                ElseIf _cantidadFotos = 2 Then
                    pctFoto1.Image = _lstFotos(0)
                    pctFoto2.Image = _lstFotos(1)
                    _indeceFoto1 = 1
                Else
                    pctFoto2.Image = _lstFotos(0)
                End If
            Case 3
                pctFoto2.Image = _lstFotos(0)
                pctFoto3.Image = _lstFotos(1)
                pctFoto1.Image = _lstFotos(2)
                _indeceFoto1 = 1
        End Select
    End Sub

    Private Sub btnAtras_Click(sender As Object, e As EventArgs)
        MovAtImg()
    End Sub

    Private Sub pctFoto2_Click(sender As Object, e As EventArgs) Handles pctFoto2.Click, pctFoto3.Click, pctFoto1.Click
        If TransitionManager1.IsTransition Then
            TransitionManager1.EndTransition()
        End If
        TransitionManager1.StartTransition(pctFoto4)
        Try
            pctFoto4.Image = CType(sender, PictureEdit).Image
        Catch ex As Exception
            TransitionManager1.EndTransition()
        End Try

    End Sub
    Private Sub EnviarSat()
        Try
            If GridView1.SelectedRowsCount >= 1 Then
                Dim paso As Boolean = False
                For i = 0 To GridView1.RowCount - 1
                    If GridView1.IsRowSelected(i) Then
                        Dim xdatarow As DataRow = GridView1.GetDataRow(i)
                        If xdatarow("EstatusSat").ToString().Equals("PENDIENTE") Or xdatarow("EstatusSat").ToString().Equals("") Then

                            Dim arFob(xdatarow("FOB").ToString().Split(",").Length - 1) As Double
                            For j As Integer = 0 To arFob.Length - 1
                                arFob(j) = Double.Parse(xdatarow("FOB").ToString().Split(",")(j))
                            Next
                            Dim serv As New OnePlanServices_XmlGenerator.XmlGeneratorWSSoapClient
                            serv.CrearAcuseXml(xdatarow("CODIGO_POLIZA").ToString().Split(","), arFob, Date.Today, xdatarow("CODIGO_TRANSPORTISTA").ToString(), xdatarow("PLACA_TRANSPORTE").ToString().Split(","), xdatarow("NUMERO_CONTENEDOR").ToString().Split(","), xdatarow("NUMERO_MARCHAMO").ToString().Split(","), xdatarow("DOC_ID").ToString())
                            paso = True
                        End If
                    End If
                Next
                If paso Then
                    LlenarGrid()
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        EnviarSat()
    End Sub

    Private Sub CancelarEnvio()
        Try
            If GridView1.SelectedRowsCount >= 1 Then
                Dim paso As Boolean = False
                For i = 0 To GridView1.RowCount - 1
                    If GridView1.IsRowSelected(i) Then
                        Dim xdatarow As DataRow = GridView1.GetDataRow(i)
                        If xdatarow("EstatusSat").ToString().Equals("PENDIENTE") Then
                            Dim pResult = ""
                            Dim xservTrans As New OnePlanServices_Trans.WMS_TransSoapClient("WMS_TransSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Trans.asmx")
                            xservTrans.UpdateStatusSapService(xdatarow("DOC_ID").ToString(), "CANCELADO", pResult, PublicLoginInfo.Environment)
                            paso = True
                        End If
                    End If
                Next
                If paso Then
                    LlenarGrid()
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        CancelarEnvio()
    End Sub
End Class
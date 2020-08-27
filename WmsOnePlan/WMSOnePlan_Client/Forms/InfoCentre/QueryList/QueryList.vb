Imports System.IO
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class QueryList
    Private Sub QueryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fecha As Date = DateTime.Today

        UiContenedorFechaInicio.EditValue = fecha.AddMonths(-1)
        UiContenedorFechaFinal.EditValue = fecha
        cargarListaQuery()
    End Sub


    Private Sub cargarListaQuery()
        Try
            Dim dataTable As DataTable
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            dataTable = servicio.ObtenerListadoConsultasDinamicas(PublicLoginInfo.LoginID, PublicLoginInfo.Environment)
            ListaConsultas.DataSource = dataTable
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub botonRefrescar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles botonRefrescar.ItemClick
        RefrescarVista()

    End Sub

    Private Sub RefrescarVista()
        Try

            If UiContenedorFechaInicio.EditValue > UiContenedorFechaFinal.EditValue Then
                NotifyStatus("La fecha inicial tiene que ser mayor a la fecha final.", True, True)
                Return
            End If

            Dim idConsulta As Integer = 0
            If UiComboConsultas.EditValue = Nothing OrElse Not Integer.TryParse(UiComboConsultas.EditValue.ToString(), idConsulta) Then
                Return
            End If

            Dim dataTable As DataTable
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            dataTable = servicio.ObtenerConsultaSeleccionada(idConsulta, String.Empty, PublicLoginInfo.LoginID, PublicLoginInfo.Environment, UiContenedorFechaInicio.EditValue, UiContenedorFechaFinal.EditValue)
            Consulta.Columns.Clear()
            GridConsultas.DataSource = Nothing
            GridConsultas.DataSource = dataTable
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub botonExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles botonExcel.ItemClick
        UiDialogoParaGuardar.DefaultExt = "xlsx"
        UiDialogoParaGuardar.Filter = "Archivos de excel (*.xlsx)|*.xlsx"
        UiDialogoParaGuardar.FilterIndex = 2
        UiDialogoParaGuardar.RestoreDirectory = True
        UiDialogoParaGuardar.Title = "Guardar consulta"
        If (UiDialogoParaGuardar.ShowDialog() = DialogResult.OK) Then
            GridConsultas.ExportToXlsx(UiDialogoParaGuardar.FileName)
        End If
    End Sub

    Private Sub CambiarLayoutDeVista()
        Try
            Dim idConsulta As Integer = 0
            If UiComboConsultas.EditValue = Nothing OrElse Not Integer.TryParse(UiComboConsultas.EditValue.ToString(), idConsulta) Then
                Return
            End If
            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim dt As DataTable = servicio.ObtenerLayoutDeLaVistaDeQueryList(idConsulta, PublicLoginInfo.LoginID, PublicLoginInfo.Environment)
            If dt.Rows.Count > 0 Then
                Dim pLayoutString As String = dt.Rows(0)("LAYOUT_XML")

                If pLayoutString Is Nothing OrElse pLayoutString.Length = 0 Then Exit Sub

                Dim stream As New IO.MemoryStream()
                Dim sWriter As New IO.StreamWriter(stream)
                sWriter.AutoFlush = True

                Dim tmpPos As Integer = InStr(pLayoutString, "ActiveFilterString") + 20
                Dim tmpData As String = ""

                tmpData = Mid(pLayoutString, tmpPos + 1, Len(pLayoutString))
                tmpData = Replace(tmpData, """", "'")

                pLayoutString = Mid(pLayoutString, 1, tmpPos) + tmpData

                sWriter.Write(pLayoutString)
                stream.Position = 0
                Consulta.RestoreLayoutFromStream(stream)
            End If
        Catch ex As Exception
            NotifyStatus("Error al cargar la vista: " + ex.Message, True, True)
        End Try
    End Sub

    Private Sub UiBotonGrabarLayout_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonGrabarLayout.ItemClick
        GrabarLayout()
    End Sub

    Private Sub GrabarLayout()
        Try
            Dim idConsulta As Integer = 0
            If UiComboConsultas.EditValue = Nothing OrElse Not Integer.TryParse(UiComboConsultas.EditValue.ToString(), idConsulta) Then
                Return
            End If

            If GridConsultas.DataSource Is Nothing Then
                Return
            End If

            Dim servicio As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/WMS_InfoTrans.asmx")
            Dim pStream As New MemoryStream
            Dim pLayoutString As String = ""
            Consulta.SaveLayoutToStream(pStream)
            pStream.Position = 0
            pLayoutString = ConvertStreamToString(pStream)
            pLayoutString = Replace(pLayoutString, "'", """")
            servicio.GuardarElLayoutDeLaVistaDeQueryList(idConsulta, PublicLoginInfo.LoginID, pLayoutString, PublicLoginInfo.Environment)

        Catch ex As Exception
            NotifyStatus("Error al cargar la vista: " + ex.Message, True, True)
        End Try
    End Sub

    Private Sub QueryList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        GrabarLayout()
    End Sub

    Private Sub UiBotonExpandir_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonExpandir.ItemClick
        Consulta.ExpandAllGroups()
    End Sub

    Private Sub UiBotonContraer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonContraer.ItemClick
        Consulta.CollapseAllGroups()
    End Sub

    Private Sub UiComboConsultas_EditValueChanged(sender As Object, e As EventArgs) Handles UiComboConsultas.EditValueChanged
        RefrescarVista()
        CambiarLayoutDeVista()
    End Sub
End Class
Public Class frmControlPanel

    Private Sub frmControlPanel_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmControlPanel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmControlPanel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmControlPanel_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmControlPanel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmControlPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gLastScreenShowed = Me.Name
        FilListView()
        FillPropGrid()
    End Sub
    Public Function FillPropGrid()
        Me.PropertyGrid1.SelectedObject = New CtrlPanel_Class
        Return True
    End Function

    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        Me.Cursor = Cursors.Default
        Return True
    End Function
    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup


        Try
            xdataset = xserv.GetParam_PartialSearch("", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Me.GridControl1.DataSource = xdataset.Tables(0)
                Me.GridView1.ExpandAllGroups()

            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Return True
    End Function

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged

        Select Case e.ChangedItem.Label
            Case "Grupo"
                Bag_CtrlPanel_Class.Grupo = e.ChangedItem.Value
            Case "Tipo"
                Bag_CtrlPanel_Class.Tipo = e.ChangedItem.Value
            Case "TituloDelGrupo"
                Bag_CtrlPanel_Class.TituloDelGrupo = e.ChangedItem.Value
            Case "NombreDelParametro"
                Bag_CtrlPanel_Class.NombreDelParametro = e.ChangedItem.Value
            Case "TituloDelParametro"
                Bag_CtrlPanel_Class.TituloDelParametro = e.ChangedItem.Value
            Case "ValorNumerico"
                Bag_CtrlPanel_Class.ValorNumerico = e.ChangedItem.Value
            Case "ValorMonetario"
                Bag_CtrlPanel_Class.ValorMonetario = e.ChangedItem.Value
            Case "ValorTexto"
                Bag_CtrlPanel_Class.ValorTexto = e.ChangedItem.Value
            Case "ValorFecha"
                Bag_CtrlPanel_Class.ValorFecha = e.ChangedItem.Value
            Case "NumeroInicial"
                Bag_CtrlPanel_Class.NumeroInicial = e.ChangedItem.Value
            Case "NumeroFinal"
                Bag_CtrlPanel_Class.NumeroFinal = e.ChangedItem.Value
            Case "FechaInicial"
                Bag_CtrlPanel_Class.FechaInicial = e.ChangedItem.Value
            Case "FechaFinal"
                Bag_CtrlPanel_Class.FechaFinal = e.ChangedItem.Value
            Case "ValorExtra_1"
                Bag_CtrlPanel_Class.ValorExtra_1 = e.ChangedItem.Value
            Case "ValorExtra_2"
                Bag_CtrlPanel_Class.ValorExtra_2 = e.ChangedItem.Value
            Case "ValorExtra_3"
                Bag_CtrlPanel_Class.ValorExtra_3 = e.ChangedItem.Value
            Case "ValorExtra_4"
                Bag_CtrlPanel_Class.ValorExtra_4 = e.ChangedItem.Value
            Case "ValorExtra_5"
                Bag_CtrlPanel_Class.ValorExtra_5 = e.ChangedItem.Value
            Case "Color"
                Bag_CtrlPanel_Class.Color = e.ChangedItem.Value

        End Select

    End Sub
    Public Sub SaveAndRefresh()
        Dim pResult As String = ""
        If Bag_CtrlPanel_Class.Grabar(pResult) Then
            FilListView()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub


    Private Sub ClearBagCtlPanel()
        With Bag_CtrlPanel_Class
            .FechaFinal = Nothing
            .FechaInicial = Nothing
            .NombreDelParametro = ""
            .Grupo = ""
            .Tipo = ""
            .TituloDelGrupo = ""
            .TituloDelParametro = ""
            .ValorExtra_1 = ""
            .ValorExtra_2 = ""
            .ValorExtra_3 = ""
            .ValorExtra_4 = ""
            .ValorExtra_5 = ""
            .ValorFecha = Nothing
            .ValorMonetario = 0
            .ValorNumerico = 0
            .ValorTexto = ""
            .NumeroFinal = 0
            .NumeroInicial = 0
            .ValorDecimal = 0.00
            .Color = Color.Transparent

            Me.PropertyGrid1.SelectedObject = Bag_CtrlPanel_Class
            Me.PropertyGrid1.Refresh()

        End With

    End Sub
    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click

        Dim pResult As String = ""
        If Bag_CtrlPanel_Class.Delete(pResult) Then
            FilListView()
            ClearBagCtlPanel()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub PropertyGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyGrid1.Click

    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        ClearBagCtlPanel()
        PropertyGrid1.SelectedObject = Bag_CtrlPanel_Class
        PropertyGrid1.Focus()

    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Try
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pParam As String = xdatarow("PARAM_NAME").ToString
            ShowParam(pParam)

        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ShowParam(ByVal pParam As String)

        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")

        Dim xdatarow As DataRow
        Dim xdataset As New DataSet
        Dim pResult As String = ""

        With Bag_CtrlPanel_Class
            Try
                xdataset = xserv.GetParam_ByParamID(pParam, pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    For Each xdatarow In xdataset.Tables(0).Rows

                        .Tipo = IIf(IsDBNull(xdatarow("PARAM_TYPE")), "", xdatarow("PARAM_TYPE"))
                        .Grupo = IIf(IsDBNull(xdatarow("PARAM_GROUP")), "", xdatarow("PARAM_GROUP"))
                        .TituloDelGrupo = IIf(IsDBNull(xdatarow("PARAM_GROUP_CAPTION")), "", xdatarow("PARAM_GROUP_CAPTION"))

                        .NombreDelParametro = IIf(IsDBNull(xdatarow("PARAM_NAME")), "", xdatarow("PARAM_NAME"))
                        .TituloDelParametro = IIf(IsDBNull(xdatarow("PARAM_CAPTION")), "", xdatarow("PARAM_CAPTION"))

                        .ValorTexto = IIf(IsDBNull(xdatarow("TEXT_VALUE")), "", xdatarow("TEXT_VALUE"))
                        .ValorNumerico = IIf(IsDBNull(xdatarow("NUMERIC_VALUE")), 0, xdatarow("NUMERIC_VALUE"))
                        .ValorMonetario = IIf(IsDBNull(xdatarow("MONEY_VALUE")), 0, xdatarow("MONEY_VALUE"))
                        .ValorFecha = IIf(IsDBNull(xdatarow("DATE_VALUE")), Nothing, xdatarow("DATE_VALUE"))
                        .ValorDecimal = IIf(IsDBNull(xdatarow("DECIMAL_VALUE")), 0, xdatarow("DECIMAL_VALUE"))

                        .FechaInicial = IIf(IsDBNull(xdatarow("RANGE_DATE_START")), Nothing, xdatarow("RANGE_DATE_START"))
                        .FechaFinal = IIf(IsDBNull(xdatarow("RANGE_DATE_END")), Nothing, xdatarow("RANGE_DATE_END"))

                        .NumeroInicial = IIf(IsDBNull(xdatarow("RANGE_NUM_START")), 0, xdatarow("RANGE_NUM_START"))
                        .NumeroFinal = IIf(IsDBNull(xdatarow("RANGE_NUM_END")), 0, xdatarow("RANGE_NUM_END"))

                        .ValorExtra_1 = IIf(IsDBNull(xdatarow("SPARE1")), "", xdatarow("SPARE1"))
                        .ValorExtra_2 = IIf(IsDBNull(xdatarow("SPARE2")), "", xdatarow("SPARE2"))
                        .ValorExtra_3 = IIf(IsDBNull(xdatarow("SPARE3")), "", xdatarow("SPARE3"))
                        .ValorExtra_4 = IIf(IsDBNull(xdatarow("SPARE4")), "", xdatarow("SPARE4"))
                        .ValorExtra_5 = IIf(IsDBNull(xdatarow("SPARE5")), "", xdatarow("SPARE5"))

                        If ElColorEsNullOEstaVacio(xdatarow("COLOR")) Then
                            .Color = Color.Transparent
                        Else
                            .Color = Color.FromArgb(xdatarow("COLOR"))
                        End If

                    Next xdatarow
                End If
            Catch ex As Exception
                xdataset = Nothing
                xserv = Nothing

                MessageBox.Show(ex.Message)
            End Try
            xdataset = Nothing
            xserv = Nothing
        End With

        Me.PropertyGrid1.SelectedObject = Bag_CtrlPanel_Class
        Me.PropertyGrid1.Refresh()


    End Sub

    Private Function ElColorEsNullOEstaVacio(color As Object) As Boolean
        Return IsDBNull(color) OrElse color.ToString = ""
    End Function

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            Try
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pParam As String = xdatarow("PARAM_NAME").ToString
                ShowParam(pParam)

            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class

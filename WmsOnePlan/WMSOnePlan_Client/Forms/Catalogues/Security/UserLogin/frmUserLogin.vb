
Imports System.ComponentModel
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class frmUserLogin

    Private Property ClientCode() As String = ""
    Private Property ClientName() As String = ""

    Private Sub ClearBag_UserLogin()
        With Bag_Userlogin_Class
            .CodigoUsuario = ""
            .NivelAcceso = ""
            .NombreUsuario = ""
            .TipoUsuario = ""
            .Estatus = "ACTIVO"
            .Password = ""
            .SerieDeLicencia = ""
            .InterfaseGrafica = ""
            .AmbienteTrabajo = ""
            .TerminalConsolidacion = 0  '06Sep10 J.R. agregar terminal consolidacion
            .GeneraTareas = 0  '07Oct10 J.R. usuario genera tareas picking si o no
            .Linea = ""
            .BodegasHabilitadas = ""
            .EMAIL = ""
            .Autorizador = "0"
            .NotificarCartaCupo = "0"
            .TareasReubicacion = "0"
            .Terminal = ""
            .PosicionEnLaLinea = ""
            .Columna = ""
            .Dominio = clsUserLogin._DEFAULT_DOMAIN
            Me.PropertyGridControl1.SelectedObject = Bag_Userlogin_Class
            Me.PropertyGridControl1.Refresh()
        End With
    End Sub



    Public Sub SaveAndRefresh()
        Dim pResult As String = ""

        If Bag_Userlogin_Class.Grabar(pResult) Then
            FilListView()
            UiTabCentroDistribucion.PageVisible = True
            LimpiarControles()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        SearchByPartial()
        Me.Cursor = Cursors.Default
        Return True
    End Function
    Public Function SearchByPartial()
        Dim i As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Dim xgrp As New ListViewGroup

        'create default groups

        Try
            xdataset = xserv.SearchPartialUserLogin("", "", "", "", pResult, PublicLoginInfo.Environment)
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


    Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click

        Dim pResult As String = ""
        If Bag_Userlogin_Class.Delete(pResult) Then
            FilListView()
            ClearBag_UserLogin()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub

    Private Sub frmUserLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmUserLogin_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmUserLogin_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmUserLogin_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmUserLogin_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        gLastScreenShowed = Me.Name
    End Sub

    Private Sub frmUserLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        gLastScreenShowed = Me.Name
        SearchByPartial()
        UiTabCentroDistribucion.PageVisible = False
        LlenarListaCentroDsitribucion()
        ClearBag_UserLogin()
    End Sub

    Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click
        ClearBag_UserLogin()
        PropertyGridControl1.SelectedObject = Bag_Userlogin_Class
        Me.PropertyGridControl1.Focus()
    End Sub

    Private Sub lstview_searchresults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SearchByPartial()
    End Sub

    Private Sub lstview_searchresults_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs)

    End Sub



    Private Sub lstview_searchresults_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        Try
            Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            Dim pUserID As String = xdatarow("LOGIN_ID").ToString
            ShowUser(pUserID)
            'LlenarListaDeBodegasAsociadas()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ShowUser(ByVal pUserID As String)
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xdatarow As DataRow
        Dim xdataset As New DataSet
        Dim pResult As String = ""
        Try
            ClearBag_UserLogin()
            With Bag_Userlogin_Class
                Try
                    xdataset = xserv.SearchByKeyUserLogin(pUserID, pResult, PublicLoginInfo.Environment)
                    If pResult = "OK" Then
                        xdatarow = xdataset.Tables(0).Rows(0)

                        .Estatus = IIf(IsDBNull(xdatarow("LOGIN_STATUS")), "", xdatarow("LOGIN_STATUS"))
                        .Password = IIf(IsDBNull(xdatarow("LOGIN_PWD")), "", xdatarow("LOGIN_PWD"))
                        .SerieDeLicencia = IIf(IsDBNull(xdatarow("LICENSE_SERIAL")), "", xdatarow("LICENSE_SERIAL"))
                        .AmbienteTrabajo = IIf(IsDBNull(xdatarow("ENVIRONMENT")), "TEST", xdatarow("ENVIRONMENT"))
                        .InterfaseGrafica = IIf(IsDBNull(xdatarow("GUI_LAYOUT")), "DEFAULT", xdatarow("GUI_LAYOUT"))
                        .NivelAcceso = IIf(IsDBNull(xdatarow("ROLE_ID")), "DEFAULT", xdatarow("ROLE_ID"))
                        .TipoUsuario = IIf(IsDBNull(xdatarow("LOGIN_TYPE")), "DEFAULT", xdatarow("LOGIN_TYPE"))
                        .CodigoUsuario = pUserID
                        .NombreUsuario = IIf(IsDBNull(xdatarow("LOGIN_NAME")), "DEFAULT", xdatarow("LOGIN_NAME"))
                        .TerminalConsolidacion = IIf(IsDBNull(xdatarow("CONSOLIDATION_TERMINAL")), 0, xdatarow("CONSOLIDATION_TERMINAL"))
                        .GeneraTareas = IIf(IsDBNull(xdatarow("GENERATE_TASKS")), 0, xdatarow("GENERATE_TASKS"))
                        .Linea = IIf(IsDBNull(xdatarow("LINE_ID")), "", xdatarow("LINE_ID"))
                        .BodegasHabilitadas = IIf(IsDBNull(xdatarow("3PL_WAREHOUSE")), "", xdatarow("3PL_WAREHOUSE"))
                        .EMAIL = IIf(IsDBNull(xdatarow("EMAIL")), "", xdatarow("EMAIL"))
                        .Autorizador = IIf(IsDBNull(xdatarow("AUTHORIZER")), "0", xdatarow("AUTHORIZER"))
                        .NotificarCartaCupo = IIf(IsDBNull(xdatarow("NOTIFY_LETTER_QUOTA")), "0", xdatarow("NOTIFY_LETTER_QUOTA"))
                        .TareasReubicacion = IIf(IsDBNull(xdatarow("CAN_RELOCATE")), "0", xdatarow("CAN_RELOCATE"))
                        .PosicionEnLaLinea = IIf(IsDBNull(xdatarow("LINE_POSITION")), "0", xdatarow("LINE_POSITION"))
                        .Columna = IIf(IsDBNull(xdatarow("SPOT_COLUMN")), "0", xdatarow("SPOT_COLUMN"))
                        .Terminal = IIf(IsDBNull(xdatarow("TERMINAL_IP")), "0", xdatarow("TERMINAL_IP"))
                        .Dominio = IIf(IsDBNull(xdatarow("DOMAIN_DESCRIPTION")), "", xdatarow("DOMAIN_DESCRIPTION"))
                        UiListaCentroDistribucion.EditValue = IIf(IsDBNull(xdatarow("DISTRIBUTION_CENTER_ID")), "", xdatarow("DISTRIBUTION_CENTER_ID"))
                        UiTabCentroDistribucion.PageVisible = True
                        LlenarVistaBodegasAsociadas()
                    End If
                Catch ex As Exception
                    xdataset = Nothing
                    xserv = Nothing

                    MessageBox.Show(ex.Message)
                End Try
                xdataset = Nothing
                xserv = Nothing
            End With

            Me.PropertyGridControl1.SelectedObject = Bag_Userlogin_Class
            Me.PropertyGridControl1.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridControl1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridControl1.KeyUp
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            Try
                Dim xdatarow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
                Dim pUserID As String = xdatarow("LOGIN_ID").ToString
                ShowUser(pUserID)
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub



    Private Sub btnKillBroadcast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKillBroadcast.Click
        Dim pResult As String = ""
        Try

            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")

            If MessageBox.Show("Esta seguro de cerrar todas las sesiones de trabajo?", "Swift 3PL", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                If xserv.KillBroadcast(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment) Then
                    SearchByPartial()
                    'MessageBox.Show("Las sesiones han sido cerradas correctamente", "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show(pResult)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnAsociarCliente_Click(sender As Object, e As EventArgs) Handles btnAsociarCliente.Click
        Dim frm As New FrmAssicuateUserClient(Bag_Userlogin_Class.CodigoUsuario)
        Cursor = Cursors.WaitCursor
        frm.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiListaCentroDistribucion_EditValueChanged(sender As Object, e As EventArgs) Handles UiListaCentroDistribucion.EditValueChanged
        LlenarListaDeBodegasDisponibles()
    End Sub

    Private Sub LlenarListaCentroDsitribucion()
        Try
            Dim resultado As String
            Dim serviceLocation As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
            Dim ds As DataSet = serviceLocation.GetDistributionCenters(PublicLoginInfo.Environment, resultado)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, False, True)
            Else
                UiListaCentroDistribucion.Properties.DataSource = ds.Tables(0)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub LlenarListaDeBodegasDisponibles()
        Try
            If UiListaCentroDistribucion.EditValue Is Nothing Or String.IsNullOrEmpty(UiListaCentroDistribucion.EditValue) Then
                Return
            End If
            Dim resultado As String
            Dim serviceLocation As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
            Dim ds As DataSet = serviceLocation.GetWarehouseByDistributionCenter(Bag_Userlogin_Class.CodigoUsuario, UiListaCentroDistribucion.EditValue, PublicLoginInfo.Environment, resultado)
            If Not String.IsNullOrEmpty(resultado) Then
                NotifyStatus(resultado, False, True)
            Else
                UiListaBodegasDisponibles.Properties.DataSource = ds.Tables(0)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub LlenarVistaBodegasAsociadas()
        Try
            Dim resultado As String
            Dim serviceLocation As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
            Dim ds As DataSet = serviceLocation.GetAssociatedWarehouseWithUser(Bag_Userlogin_Class.CodigoUsuario, PublicLoginInfo.Environment, resultado)
            If Not resultado.ToUpper.Equals("OK") Then
                NotifyStatus(resultado, False, True)
                UiContenedorDeVistasBodegaAsociada.DataSource = Nothing
            Else
                UiContenedorDeVistasBodegaAsociada.DataSource = ds.Tables(0)
                If ds.Tables(0).Rows.Count > 0 Then
                    UiListaCentroDistribucion.ReadOnly = True
                Else
                    UiListaCentroDistribucion.ReadOnly = False
                End If

            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub UiBotonEliminarBodega_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiBotonEliminarBodega.ButtonClick
        EliminarBodegaAsociada()
    End Sub

    Dim usuarioSeleccionoListaBodegasDisponiblesCompleta As Boolean = False
    Private Sub UiListavistaBodegasDisponibles_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles UiListavistaBodegasDisponibles.SelectionChanged
        If e.ControllerRow >= 0 Then
            Dim fila As DataRow
            fila = UiListavistaBodegasDisponibles.GetDataRow(e.ControllerRow)
            fila("IS_SELECT") = (e.Action = CollectionChangeAction.Add)
        Else
            If usuarioSeleccionoListaBodegasDisponiblesCompleta Then
                For i = 0 To UiListavistaBodegasDisponibles.RowCount - 1
                    Dim fila As DataRow
                    fila = UiListavistaBodegasDisponibles.GetDataRow(i)
                    If Not fila Is Nothing Then
                        fila("IS_SELECT") = (Not UiListavistaBodegasDisponibles.SelectedRowsCount = 0)
                    End If
                Next
                usuarioSeleccionoListaBodegasDisponiblesCompleta = False
            End If
        End If

        Dim edit = TryCast(ActiveControl, DevExpress.XtraEditors.SearchLookUpEdit)
        If Not edit Is Nothing Then
            edit.Text = ObtenerTextoAMostrarListaComponentes()
        End If
    End Sub

    Private Sub UiListaBodegasDisponibles_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles UiListaBodegasDisponibles.CustomDisplayText
        e.DisplayText = ObtenerTextoAMostrarListaComponentes()
    End Sub

    Private Sub UiListavistaBodegasDisponibles_MouseUp(sender As Object, e As MouseEventArgs) Handles UiListavistaBodegasDisponibles.MouseUp
        Dim view As GridView = TryCast(sender, GridView)
        If view Is Nothing Then
            Return
        End If
        Dim hi As GridHitInfo = view.CalcHitInfo(New System.Drawing.Point(e.X, e.Y))
        If (hi.HitTest = GridHitTest.Column OrElse hi.HitTest = GridHitTest.GroupPanelColumn) AndAlso hi.Column.Name.Equals("DX$CheckboxSelectorColumn") Then
            usuarioSeleccionoListaBodegasDisponiblesCompleta = True
        End If
    End Sub

    Private Sub UiListavistaBodegasDisponibles_BeforeLeaveRow(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles UiListavistaBodegasDisponibles.BeforeLeaveRow
        For i = 0 To UiListavistaBodegasDisponibles.RowCount - 1
            Dim fila As DataRow
            fila = UiListavistaBodegasDisponibles.GetDataRow(i)
            If Not fila Is Nothing Then
                If fila("IS_SELECT") = 1 Then
                    UiListavistaBodegasDisponibles.SelectRow(i)
                End If
            End If
        Next
    End Sub

    Private Function ObtenerTextoAMostrarListaComponentes() As String
        Dim cadena As New StringBuilder
        cadena.Append("")
        If Not UiListaBodegasDisponibles.Properties.DataSource Is Nothing Then

            For i = 0 To UiListavistaBodegasDisponibles.RowCount - 1
                Dim fila As DataRow
                fila = UiListavistaBodegasDisponibles.GetDataRow(i)
                If Not fila Is Nothing Then
                    If fila("IS_SELECT") = 1 Then
                        If cadena.Length > 0 Then
                            cadena.Append(",")
                        End If
                        cadena.Append(fila("WAREHOUSE_ID") + "|" + fila("NAME"))
                    End If
                End If
            Next
        End If
        Return cadena.ToString()
    End Function

    Private Sub AgregarBodegas()
        Try

            Dim resultado As String = ""
            Dim serviceLocation As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
            If Not UiListaCentroDistribucion.ReadOnly Then
                If serviceLocation.AssociateDistributionCenterWithUser(Bag_Userlogin_Class.CodigoUsuario, UiListaCentroDistribucion.EditValue, PublicLoginInfo.Environment, resultado) Then
                    If Not resultado.Equals("OK") Then
                        NotifyStatus(resultado, True, True)
                        Return
                    End If
                Else
                    NotifyStatus(resultado, True, True)
                    Return
                End If
            End If

            Dim dt As DataTable
            dt = TryCast(UiListaBodegasDisponibles.Properties.DataSource, DataTable)
            If (From fila As DataRow In dt.Rows Where Not fila Is Nothing Where fila("IS_SELECT") = 1 Where serviceLocation.AssociateWarehouseOfUser(Bag_Userlogin_Class.CodigoUsuario, fila("WAREHOUSE_ID"), PublicLoginInfo.Environment, resultado)).Any(Function(fila) Not resultado.Equals("OK")) Then
                NotifyStatus(resultado, True, True)
                Return
            End If
            LlenarListaDeBodegasDisponibles()
            LlenarVistaBodegasAsociadas()

        Catch ex As Exception
            NotifyStatus(ex.Message, False, True)
        End Try
    End Sub

    Private Sub UiBotonAgregarBodegas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonAgregarBodegas.ItemClick
        AgregarBodegas()
    End Sub

    Private Sub UiListaCentroDistribucion_Properties_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles UiListaCentroDistribucion.ButtonClick, UiListaBodegasDisponibles.ButtonClick
        Select Case e.Button.Tag
            Case "UiBotonRefrescarCentrosDistribucion"
                LlenarListaCentroDsitribucion()
                Exit Select
            Case "UiBotonRefrescarBodegasDisponibles"
                LlenarListaDeBodegasDisponibles()
                Exit Select
        End Select
    End Sub

    Private Sub EliminarBodegaAsociada()
        Try
            If (UiVistaBodegasAsociadas.FocusedRowHandle >= 0) Then
                Dim resultado As String = ""
                Dim serviceLocation As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")
                Dim fila As DataRow
                fila = UiVistaBodegasAsociadas.GetDataRow(UiVistaBodegasAsociadas.FocusedRowHandle)

                If serviceLocation.DisassociateWarehouseOfUser(fila("WAREHOUSE_BY_USER_ID"), PublicLoginInfo.Environment, resultado) Then
                    If Not resultado.Equals("OK") Then
                        NotifyStatus(resultado, True, True)
                    Else
                        LlenarListaDeBodegasDisponibles()
                        LlenarVistaBodegasAsociadas()
                    End If
                Else
                    NotifyStatus(resultado, True, True)
                End If

            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub LimpiarControles()
        UiListaCentroDistribucion.EditValue = Nothing
        UiListaBodegasDisponibles.Properties.DataSource = Nothing
        UiContenedorDeVistasBodegaAsociada.DataSource = Nothing
    End Sub

    Private Sub PropertyGridControl1_CellValueChanging(sender As Object, e As DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs) Handles PropertyGridControl1.CellValueChanging
        If e.Row.Name = "rowPassword" Then
            Bag_Userlogin_Class.Password = e.Value
        End If
        If e.Row.Name = "rowEMAIL" Then
            Bag_Userlogin_Class.EMAIL = e.Value
        End If
        If e.Row.Name = "rowGeneraTareas" Then
            Bag_Userlogin_Class.GeneraTareas = e.Value
        End If
        If e.Row.Name = "rowNombreUsuario" Then
            Bag_Userlogin_Class.NombreUsuario = e.Value
        End If
        If e.Row.Name = "rowTerminalConsolidacion" Then
            Bag_Userlogin_Class.TerminalConsolidacion = e.Value
        End If
    End Sub
End Class
Imports System.Configuration.ConfigurationManager
Imports System.Reflection
Imports DevExpress.DataProcessing
Imports DevExpress.Skins
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraEditors
Imports DevExpress.XtraSplashScreen
Imports DocumentFormat.OpenXml.Bibliography
Imports MobilityScm.Modelo.Configuracion
Imports MobilityScm.Modelo.Vistas
Imports MobilityScm.Utilerias
Imports MobilityScm.Vertical.Servicios


Public Class RibbonForm1
    Implements IInteraccionConUsuarioServicio


#Region "Interaccion con usuario"
    Public Sub MensajeExito(mensaje As String) Implements IInteraccionConUsuarioServicio.MensajeExito
        NotifyStatus(mensaje, True, False)
    End Sub

    Public Sub MensajeExito(mensaje As String, mostrarAlerta As Boolean) Implements IInteraccionConUsuarioServicio.MensajeExito
        NotifyStatus(mensaje, mostrarAlerta, False)
    End Sub

    Public Sub Confirmar(mensaje As String, accionAceptar As Action, titulo As String, botonAceptar As String, botonCancelar As String) Implements IInteraccionConUsuarioServicio.Confirmar
        If MessageBox.Show(Me, mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            accionAceptar()
        End If
    End Sub

    Public Sub Confirmar(mensaje As String, respuesta As Action(Of Boolean), titulo As String, botonAceptar As String, botonCancelar As String) Implements IInteraccionConUsuarioServicio.Confirmar
        If XtraMessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            respuesta(True)
        Else
            respuesta(False)
        End If
    End Sub

    Public Sub Confirmar(mensaje As String, respuesta As Action(Of Boolean)) Implements IInteraccionConUsuarioServicio.Confirmar
        Confirmar(mensaje, respuesta, "Mobility SCM", "Yes", "No")
    End Sub

    Public Sub Alerta(mensaje As String, accionFinalizar As Action, titulo As String) Implements IInteraccionConUsuarioServicio.Alerta
        If MessageBox.Show(Me, mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            accionFinalizar()
        End If
    End Sub

    Public Sub Mensaje(mensaje As String, accionFinalizar As Action, titulo As String) Implements IInteraccionConUsuarioServicio.Mensaje
        If MessageBox.Show(Me, mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            accionFinalizar()
        End If
    End Sub

    Public Sub CerrarActividadActual() Implements IInteraccionConUsuarioServicio.CerrarActividadActual

    End Sub

    Public Sub AgregarActividadActual() Implements IInteraccionConUsuarioServicio.AgregarActividadActual

    End Sub

    Public Sub CerrarDosActividadesPrevias() Implements IInteraccionConUsuarioServicio.CerrarDosActividadesPrevias

    End Sub

    Public Sub Alerta(mensaje As String) Implements IInteraccionConUsuarioServicio.Alerta
        NotifyStatus(mensaje, False, True)
    End Sub

    Public Sub Confirmar(mensaje As String, accionAceptar As Action) Implements IInteraccionConUsuarioServicio.Confirmar
        Confirmar(mensaje, accionAceptar, "Mobility SCM", "OK", "Cancel")
    End Sub

    Public Sub Alerta(mensaje As String, accionFinalizar As Action) Implements IInteraccionConUsuarioServicio.Alerta
        Alerta(mensaje, accionFinalizar, "Mobility SCM")
    End Sub

    Public Sub Mensaje(mensaje As String) Implements IInteraccionConUsuarioServicio.Mensaje
        CerrarDialogoDeCargando()
        NotifyStatus(mensaje, False, True)
    End Sub

    Public Function ObtenerUsuario() As String Implements IInteraccionConUsuarioServicio.ObtenerUsuario
        Return PublicLoginInfo.LoginID
    End Function
    Public Function ObtenerNombreUsuario() As String Implements IInteraccionConUsuarioServicio.ObtenerNombreUsuario
        Return PublicLoginInfo.LoginName
    End Function

    Public Function ObtenerCentroDistribucion() As String Implements IInteraccionConUsuarioServicio.ObtenerCentroDistribucion
        Return PublicLoginInfo.DistributionCenter
    End Function

    Public Function ObtenerLogo() As String Implements IInteraccionConUsuarioServicio.ObtenerLogo
        Return PublicLoginInfo.LOGO
    End Function
    Public Sub MensajeErrorDialogo(mensaje As String) Implements IInteraccionConUsuarioServicio.MensajeErrorDialogo
        CerrarDialogoDeCargando()
        NotifyStatus(mensaje, True, True)
    End Sub

    Public Function ObtenerNombreEmpresa() As String Implements IInteraccionConUsuarioServicio.ObtenerNombreEmpresa
        Return PublicLoginInfo.CompanyName
    End Function

    Public Function ObtenerLogoDeImagenPredeterminada() As String Implements IInteraccionConUsuarioServicio.ObtenerLogoDeImagenPredeterminada
        Return PublicLoginInfo.ImgLogoDefault
    End Function
    Public Function ObtenerApi() As String Implements IInteraccionConUsuarioServicio.ObtenerDireccionBaseDeApi
        Return PublicLoginInfo.Api3PlAddress
    End Function
    Public Function ObtenerDominio() As String Implements IInteraccionConUsuarioServicio.ObtenerDominioDeUsuario
        Return PublicLoginInfo.Domain
    End Function
    Public Function ObtenerClaveDeUsuario() As String Implements IInteraccionConUsuarioServicio.ObtenerClaveDeUsuario
        Return PublicLoginInfo.Password
    End Function

    Public Function ObtenerUsuarioYDominio() As String Implements IInteraccionConUsuarioServicio.ObtenerUsuarioYDominio
        Return $"{ObtenerUsuario()}@{ObtenerDominio()}"
    End Function

    Public Function ObtenerUsuarioDeBaseDeDatos() As String Implements IInteraccionConUsuarioServicio.ObtenerUsuarioDeBaseDeDatos
        Return PublicLoginInfo.DbUser
    End Function

    Public Function ObtenerContraseniaDeBaseDeDatos() As String Implements IInteraccionConUsuarioServicio.ObtenerContraseniaDeBaseDeDatos
        Return PublicLoginInfo.DbPassword
    End Function

    Public Function ObtenerServerIp() As String Implements IInteraccionConUsuarioServicio.ObtenerServerIp
        Return PublicLoginInfo.ServerIp
    End Function

    Public Sub MostrarDialogoDeCargando() Implements IInteraccionConUsuarioServicio.MostrarDialogoDeCargando
        MostrarDialogoDeCargandoVb()
    End Sub

    Public Sub CerrarDialogoDeCargando() Implements IInteraccionConUsuarioServicio.CerrarDialogoDeCargando
        CerrarDialogoDeCargandoVb()
    End Sub

    Public Sub MensajeListaDeErrorDialogo(listaErrores As List(Of String)) Implements IInteraccionConUsuarioServicio.MensajeListaDeErrorDialogo
        'XtraDialog.Show(New ListaDeErroresControl(listaErrores), "Lista de Errores", MessageBoxButtons.OK)
        Dim form As XtraDialogForm = New XtraDialogForm()
        Dim dialogArg As XtraDialogArgs = New XtraDialogArgs()
        dialogArg.Caption = "Lista de Errores"
        dialogArg.Owner = Me
        dialogArg.Content = New ListaDeErroresControl(listaErrores)
        dialogArg.Buttons = New DialogResult() {DialogResult.OK}
        form.Width = 750
        form.ShowMessageBoxDialog(dialogArg)

    End Sub

    Public Class ListaDeErroresControl
        Inherits XtraUserControl

        Public Sub New(ByVal listaErrores As List(Of String))
            Dim list = New ListBoxControl()
            list.Dock = DockStyle.Fill

            For Each [error] In listaErrores
                list.Items.Add([error])
            Next

            Me.Controls.Add(list)
            Me.Height = 250

            Me.Dock = DockStyle.Top
        End Sub
    End Class


#End Region


    Private Sub PanelCtrl_BarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles PanelCtrl_BarButtonItem.ItemClick
        Dim xCtrlPanel_form As New frmControlPanel
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem25_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles uiCerrarSesion.ItemClick
        LogOut()
        'System.Environment.Exit(-1)
        'Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, True)
        'Application.Exit()
        Me.Dispose()



        '  LogOut()
        'System.Environment.Exit(-1)

        'Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, True)
        'Application.Exit()

        End
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Dim xCtrlPanel_form As New frmUserLogin
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim xCtrlPanel_form As New frmCheckPoint
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Dim xCtrlPanel_form As New frmAccessLevel
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub BarButtonLocations_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonLocations.ItemClick
        Dim xCtrlPanel_form As New frmShelfSpots
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Sub SetLayout(ByVal pGUI As String)
        Dim pResult As String = ""
        pResult = SaveUserGui(pGUI)
        If pResult = "OK" Then
            Me.DefaultLookAndFeel1.LookAndFeel.SkinName = pGUI
        Else
            MessageBox.Show(pResult)
        End If

    End Sub
    Public Function SaveUserGui(ByVal pGuiValue As String) As String
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            If xserv.UpdateUserGUI(PublicLoginInfo.LoginID, pGuiValue, pResult, PublicLoginInfo.Environment) Then
                PublicLoginInfo.GUI = pGuiValue
                Return "OK"
            Else
                Return pResult
            End If
        Catch ex As Exception
            Return pResult
        End Try

    End Function
    Private Sub RibbonForm1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        LogOut()
        System.Environment.Exit(-1)

        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, True)
        Application.Exit()
        End
    End Sub

    Public Function GetUserLayout()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.SearchByKeyUserLogin(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Return xds.Tables(0).Rows(0)("GUI_LAYOUT")
            Else
                Return "DevExpress Style"
            End If
        Catch ex As Exception
            Return "DevExpress Style"
        End Try
    End Function
    Private Sub RibbonForm1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        LogOut()
        Me.Dispose()

        'Environment.Exit(-1)
        'Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException, True)
        'Application.Exit()
        End
    End Sub
    Sub FillLookAndFeelMenu(ByVal pSetting As String)
        'Dim xbaritem As DevExpress.XtraBars.BarItem = Nothing
        Dim xbaritem As DevExpress.XtraBars.BarButtonItem
        'BarEditItem_GUI.Links.Clear()

        For i = 0 To SkinManager.Default.Skins.Count - 1
            If Not SkinManager.Default.Skins(i).SkinName.ContainsAny({"2016", "2019", "DevExpress"}) Then
                Continue For
            End If
            xbaritem = New DevExpress.XtraBars.BarButtonItem
            xbaritem.Caption = SkinManager.Default.Skins(i).SkinName
            xbaritem.Name = "skinItem_" + SkinManager.Default.Skins(i).SkinName
            AddHandler xbaritem.ItemClick, AddressOf xbaritem_click
            BarEditItem_GUI.AddItem(xbaritem)
        Next
    End Sub

    Sub xbaritem_click(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim myButton As DevExpress.XtraBars.BarButtonItem = CType(e.Item, DevExpress.XtraBars.BarButtonItem)
        BarEditItem_GUI.Caption = myButton.Caption
        Me.DefaultLookAndFeel1.LookAndFeel.SetSkinStyle(myButton.Caption)
        SetLayout(myButton.Caption)
    End Sub

    Public Sub MyUnhandledExceptionHandler()

    End Sub

    Private Sub RibbonForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DevExpress.UserSkins.BonusSkins.Register()
        DevExpress.UserSkins.OfficeSkins.Register()

        Me.DefaultLookAndFeel1.LookAndFeel.SetSkinStyle(PublicLoginInfo.GUI)

        MostrarDialogoDeCargando()

        'Dim pSetting = GetUserLayout()
        gLastScreenShowed = GetLastScreen()
        gLastTabShowed = GetLastTabPage()
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf MyUnhandledExceptionHandler

        'FillLookAndFeelMenu(PublicLoginInfo.GUI)

        BarEditItem_GUI.Caption = PublicLoginInfo.GUI


        Try
            Application.OpenForms("frmLogin").Close()

            'ApplyAccessLevel()
            GeneratedMenu()

            If (gLastTabShowed <> "") Then
                RibbonControl.SelectedPage = RibbonControl.Pages(gLastTabShowed)
            End If

            If gLastScreenShowed <> "" And gLastScreenShowed <> Me.Name Then
                OpenLastForm(gLastScreenShowed)
            End If

        Catch ex As Exception
            CerrarDialogoDeCargando()
            Cursor = Cursors.Default
            MessageBox.Show(ex.Message)
        End Try
        CerrarDialogoDeCargando()
    End Sub

    Public Function LoadGUIs()
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim xdr As DataRow
        Dim pResult As String = ""
        Dim xTmp As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "GUI_LAYOUT", "", pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                For Each xdr In xds.Tables(0).Rows
                    xTmp = xdr("PARAM_NAME").ToString
                    'BarEditItem_GUI.
                Next
            End If
        Catch ex As Exception
            XStr(0) = "NONE"
        End Try
        Return XStr

    End Function

    Sub ApplyAccessLevel()
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/catalogues/wms_security.asmx")

        Try
            Dim permisos = xserv.ObtenerPermisosPorUsuario(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)

            RibbonPage_CONFIG.Visible = True
            For Each row As DataRow In permisos.Rows
                Dim permiso = row.Item("CHECK_ID")
                Select Case permiso.ToString()
#Region "Pestañas"
                    Case Swift3PlPestania.NEXT.ToString()
                        RibbonPage1.Visible = True
                    Case Swift3PlPestania.WMSALMACENADORA.ToString()
                        RibbonPage_ALMACENAJE.Visible = True
                    Case Swift3PlPestania.WMSBACKOFFICE.ToString()
                        RibbonPage_BACKOFFICE.Visible = True
#End Region
#Region "Pestaña WMS"
                    Case Swift3PlOpcionesWms.ADMIN_TAREAS.ToString()
                        BarButtonItem15.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.ADMINISTRADOR_DE_LINEA_DE_PICKING.ToString()
                        UiBotonAdminitradorDeLineaDePicking.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGOS.ToString()
                        RibbonPageGroup_CATALOGOS.Visible = True
                    Case Swift3PlOpcionesWms.CATALOGO_ASEGURADOAS.ToString()
                        btnInsuranceCompany.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGO_BIN.ToString()
                        BarButtonItem31.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGO_CLIENTES.ToString()
                        BarButtonItem29.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGO_CONSULTA_COSTEO.ToString()
                        UiBotonConsultaCosteos.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGO_PRODUCTOS.ToString()
                        BarButtonItem30.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGO_UBICACIONES.ToString()
                        BarButtonLocations.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CATALOGO_ZONAS.ToString()
                        UiBarButtonZonas.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CERTIFICADO.ToString()
                        btnCertificadoDeposito.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CERTIFICATE_GROUP.ToString()
                        grpCertificadosBonos.Visible = True
                    Case Swift3PlOpcionesWms.CLASES.ToString()
                        UiBotonCatalogoClases.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CONSOLIDAR_PICKING.ToString()

                    Case Swift3PlOpcionesWms.CONSULTA_VEN_POLIZAS.ToString()
                        btnVencimientoPolizas.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.CREAR_CONTEO.ToString()

                    Case Swift3PlOpcionesWms.CREAR_OLA_PICKING.ToString()

                    Case Swift3PlOpcionesWms.CREAR_PICKING_D.ToString()

                    Case Swift3PlOpcionesWms.CREAR_TAREA_REAB.ToString()

                    Case Swift3PlOpcionesWms.CREAR_TAREA_REUB.ToString()

                    Case Swift3PlOpcionesWms.CREAR_TAREA_VARIA.ToString()

                    Case Swift3PlOpcionesWms.INFO_INV_CONSOL.ToString()
                        BarButtonItem35.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_INV_ONLINE.ToString()
                        BarButtonItem14.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_TRANS_ONLINE.ToString()
                        BarButtonItem37.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_WMS_BALC_OF_PAY.ToString()
                        UiBotonBalanceDeSaldosFiscal.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_WMS_MASTER_PACK.ToString()
                        UiBotonMasterPack.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_WMS_NIVEL_OCUPACION.ToString()
                        btnOccupancy.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_WMS_VIEW_INV.ToString()
                        BarButtonItem_InvViews.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_WMS_VR_SAP.ToString()
                        BarButtonItem36.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INSPECCIONES.ToString()
                        btnSupervisions.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INV_GROUP.ToString()
                        grpInventarios.Visible = True
                    Case Swift3PlOpcionesWms.PEDIDOS_SIN_ASIGNAR.ToString()

                    Case Swift3PlOpcionesWms.POLIZAS_SEGURO.ToString()
                        btnInsuranceDocs.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.REPORTE_CERTIFICADO_BONO.ToString()
                        btnRepCertificadoBono.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.REPORTE_SEGURO.ToString()
                        btnRepPolizaSeguros.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.TASK_GROUP.ToString()

                    Case Swift3PlOpcionesWms.TASK_PICKING.ToString()
                        RibbonPageGroup_TASKS.Visible = True
                    Case Swift3PlOpcionesWms.CONSULTA_INVENTARIO_DIARIO.ToString()
                        UiBarButtonConsultaInventarioDiario.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.REPORTE_PICKING.ToString()
                        UiBotonReportePicking.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_INV_INACTIVO.ToString()
                        UiBontonInvnetarioInactivo.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.INFO_INDICES_BODEGA.ToString()
                        UiBotonIndicesDeBodega.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesWms.SUGERIDO_COMPRA.ToString()
                        UiBotonSugeridoCompra.Visibility = BarItemVisibility.Always
#End Region
#Region "Pestaña Almacenadora"
                    Case Swift3PlOpcionesAlmacenadora.AUDITORIAS.ToString()
                        btnConsultaAuditsRec.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.SERV_ADIC.ToString()
                        btnServiciosAsociados.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.CONSULTA_BACKORDERS.ToString()
                        UiBotonConsultaBackOrder.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.INV_DOC.ToString()
                        btnInventarioDocumentos.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.MOV_FISCAL.ToString()
                        btnKardexFiscal.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.POLIZAS_EXPIRADAS.ToString()
                        btnVencimientoDePolizas.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.TRAS_DOC.ToString()
                        btnReceptions.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.ASIGNACION_CONTEO_FISICO.ToString()
                        UiBotonAsignacionConteoFisico.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.CONSULTA_CONTEO_FISICO.ToString()
                        UiBotonConsultaConteoFisico.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.EGRESO_GENERAL.ToString()
                        btnEgresoGeneral.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.EGRESO_POLIZA.ToString()
                        btnPolizaEgreso.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.ORDEN_PREPARADO.ToString()
                        btnGenerateWave.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.PASE_SALIDA.ToString()
                        btnPase.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.REPORTE_EGRESO.ToString()
                        UiBotonReporteIngresoF.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.ACUSE_RECIBO.ToString()
                        btnAcuseRecibo.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.APROBACION_FISCAL.ToString()
                        btnAprobacion.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.AUTORIZACION_CUPO.ToString()
                        btnAutoQuotaLetter.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.AUTORIZACION_SAT.ToString()
                        btnAutoSat.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.COSTEAR_GENERAL.ToString()
                        btnCostearGeneral.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.GARITA.ToString()
                        btnGarita.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.INGRESO_FISCAL.ToString()
                        btnReciboDoc.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.INGRESO_GENERAL.ToString()
                        btnIngresoGeneral.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.REPORTE_INGRESO_FISCAL.ToString()
                        UiBotonReporteEgreso.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.CONSULTA_SOLICITUD_DE_TRASLADO.ToString()
                        UiBarButtonConsultaSolicitudDeTraslado.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.SOLICITUD_DE_TRASLADO.ToString()
                        UiBotonSolicitudDeTraslado.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.ACUERDO_COMERCIAL.ToString()
                        btnAcuerdoComercial.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.CONS_ACUERDO_CLIENTE.ToString()
                        btnAcuerdoCliente.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.INV_POR_ACUERDO_COMERCIAL.ToString()

                    Case Swift3PlOpcionesAlmacenadora.TARIFARIO.ToString()
                        UiBotonServiciosPorCobrar.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.TIPO_COBRO.ToString()
                        btnTypeChange.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_AUDITORIAS.ToString()
                        RibbonPageGroupAudit.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_BACKORDERS.ToString()
                        RibbonPage_BackOrder.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_CONSULTA_DOC.ToString()
                        RibbonPageGroup_inventario.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_CONTEO_FISICO.ToString()
                        RibbonPage_Conteos.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_DESPACHO.ToString()
                        RibbonPageGroup_Despacho.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_RECEPCION.ToString()
                        RibbonPageGroup_Recepcion.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_SOLICITUD_TRASLADO.ToString()
                        RibbonPage_SolicitudTraslado.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_TARIFARIO.ToString()
                        RibbonPage_Tarifario.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.INGRESO_ERP.ToString()
                        UiBotonIngresoERP.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.CERTIFICADO_DEPOSITO.ToString()
                        UiBotonCertificadoDeposito.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.INGRESO_EXTERNO.ToString()
                        BtnIngresoExterno.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.PASE_DE_SALIDA.ToString()
                        UiBotonPaseSalidaCertificado.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.EGRESO_EXTERNO.ToString()
                        BarBntOutInventory.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.RECTIFICACIONES.ToString()
                        UiBotonRectificaciones.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_BLOQUEO_INVENTARIO.ToString()
                        RibbonPage_BloqueoInventario.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.BLOQUEO_DE_INVENTARIO.ToString()
                        UiBotonBloqueoDeInventario.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.REPORTE_DEVOLUCIONES.ToString()
                        UiBarButtonReporteDevoluciones.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesAlmacenadora.GRUPO_INVENTARIO_COMPROMETIDO.ToString()
                        RibbonPage_InventarioComprometido.Visible = True
                    Case Swift3PlOpcionesAlmacenadora.INVENTARIO_COMPROMETIDO.ToString()
                        UiBotonInventarioComprometido.Visibility = BarItemVisibility.Always

#End Region
#Region "Pestaña NEXT"
                    Case Swift3PlOpcionesNext.DEMANDA_DESPACHO.ToString()
                        UiBotonDemandaDespacho.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.DESPACHO.ToString()

                    Case Swift3PlOpcionesNext.ENTREGA.ToString()

                    Case Swift3PlOpcionesNext.MANIFIESTO_DE_CARGA.ToString()
                        UiBotonManifiestoDeCarga.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.GRUPO_MOVIMIENTOS.ToString()
                        RibbonPageGroup3.Visible = True
                    Case Swift3PlOpcionesNext.TRAZABILIDAD_DEMANDA.ToString()
                        UiButtonTrazabilidadDeDemanda.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.TRANSPORTE.ToString()
                        UiGrupoPaginaNextTransporte.Visible = True
                    Case Swift3PlOpcionesNext.CATALOGO_EMPRESAS_DE_TRANSPORTE.ToString()
                        UiBotonCatalogoEmpresasDeTransporte.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.CATALOGO_PILOTOS.ToString()
                        UiBotonCatalogoDePiloto.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.CATALOGO_VEHICULOS.ToString()
                        UiBotonCatalogoVehiculo.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.CONSULTA_DE_MANIFIESTO.ToString()
                        UiBotonConsultaDeManifiesto.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.COSULTAS_Y_TRANSACCIONES.ToString()
                        UiGrupoPaginaNextConsultasYTransacciones.Visible = True
                    Case Swift3PlOpcionesNext.PEDIDOS_POR_VENDEDOR.ToString()
                        UiBotonPedidosPorRuta.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.CONSULTA_LINEA_DE_PICKING.ToString()
                        UiBotonConsultaDeLineaDePicking.Visibility = BarItemVisibility.Always
                    Case Swift3PlOpcionesNext.CONSULTA_CUMPLIMIENTO_ENTREGA.ToString()
                        UiBotonConsultaCumplimientoEntrega.Visibility = BarItemVisibility.Always
#End Region
#Region "Pestaña Configuracion"
                    Case Swift3plOpcionesConfiguracion.CATALOGO_USUARIOS.ToString()
                        BarButtonItem4.Visibility = BarItemVisibility.Always
                    Case Swift3plOpcionesConfiguracion.CONFIG_GROUP.ToString()
                        RibbonPageGroup_CONFIG.Visible = True
                    Case Swift3plOpcionesConfiguracion.INTERFASE_GRAFICA.ToString()
                        BarEditItem_GUI.Visibility = BarItemVisibility.Always
                    Case Swift3plOpcionesConfiguracion.NIVEL_ACCESO.ToString()
                        BarButtonItem5.Visibility = BarItemVisibility.Always
                    Case Swift3plOpcionesConfiguracion.PARAMS.ToString()
                        PanelCtrl_BarButtonItem.Visibility = BarItemVisibility.Always
                    Case Swift3plOpcionesConfiguracion.SEGURIDAD_GROUP.ToString()
                        RibbonPageGroup_SEGURIDAD.Visible = True
                    Case Swift3plOpcionesConfiguracion.USUARIOS.ToString()
                        BarButtonItem4.Visibility = BarItemVisibility.Always
#End Region
                End Select
            Next row


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BarButtonItem30_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        AbrirFormulario(Of frmMaterials)()
    End Sub

    Private Sub BarButtonItem33_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim xCtrlPanel_form As New frmOperatorXModules
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarButtonItem29_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        Dim xCtrlPanel_form As New frmClients
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem17_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarStaticItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles Static_CustomerName.ItemClick

    End Sub

    Private Sub BarButtonItem14_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        Dim xfrm As New frmInfo_Inventory
        Me.Cursor = Cursors.WaitCursor
        With xfrm
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem35_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick
        Dim xfrm As New frmInfo_InvConsolidate
        Me.Cursor = Cursors.WaitCursor
        With xfrm
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BarButtonItem37_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem37.ItemClick
        Dim xfrm As New frmInfoTransOnLine
        Me.Cursor = Cursors.WaitCursor
        With xfrm
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAparienciaCoffee_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAparienciaCoffee.ItemClick
        SetLayout("Coffee")
    End Sub

    Private Sub BarButtonItem6_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim xfrm As New frmChangePassword
        xfrm.ShowDialog()
    End Sub

    Private Sub BarButtonItem16_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim xfrm As New frmCreatePickingD
        xfrm.ShowDialog()
    End Sub

    Private Sub Static_UserID_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles Static_UserID.ItemClick
        MessageBox.Show(Static_UserID.Tag, "3PL ", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub BarButtonItemReceive_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCrearTareaCargaRuta.ItemClick
        'Dim xfrm As New frmReceiveFinishGood
        'Me.Cursor = Cursors.WaitCursor
        'With xfrm
        '.MdiParent = Me
        '.Show()'End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem15_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        AbrirFormulario(Of AdministradorDeTareasVista)()
    End Sub

    Private Sub NewPickingWave_BarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim xfrm As New frmCreateWavePicking
        Me.Cursor = Cursors.WaitCursor
        With xfrm
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Protected Overrides Sub Finalize()
        'LogOut()
        'End
        'MyBase.Finalize()
    End Sub
    Sub LogOut()
        Dim pResult As String = ""
        Try
            Me.Timer1.Stop()
            Me.Timer1.Dispose()
            Dim pUri As String = AppSettings("WSHOST").ToString + "/Catalogues/WMS_Security.asmx"
            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", pUri)
            xserv.RegisterLogIn(PublicLoginInfo.LoginID, "CHECK_OUT", pResult, PublicLoginInfo.Environment)

            Try

                SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_TAB", gLastTabShowed)
                '           "ONE_PLAN", "USER_CONFIG", "LAST_TAB"
            Catch ex As Exception

            End Try

            SaveSetting("ONE_PLAN", "USER_CONFIG", "LAST_SCREEN", gLastScreenShowed)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Function GetLastScreen() As String
        Dim pResult As String = ""
        Try
            Return GetSetting("ONE_PLAN", "USER_CONFIG", "LAST_SCREEN", "")
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
    Public Function GetLastTabPage() As String
        Dim pResult As String = ""
        Try
            Return GetSetting("ONE_PLAN", "USER_CONFIG", "LAST_TAB", "")
        Catch ex As Exception
            Return ""
        End Try
        Return ""
    End Function
    Private Sub CheckPicking_BarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        'Dim xfrm As New frmMainConsolidate
        'xfrm.bForzarSalir = False
        'xfrm.Show()
    End Sub

    Private Sub BarButtonItemLineBalancing_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)

        '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
        Dim xCtrlPanel_form As New frmLineBalancing
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Static_Version_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles Static_Version.ItemClick

    End Sub

    Private Sub BarButtonItem36_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem36.ItemClick

    End Sub

    Private Sub btnReleaseBin_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If MessageBox.Show("Esta seguro que desea LIBERAR un Bin?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) = DialogResult.Yes Then

            'frmReleaseBin.ShowDialog()

        End If
    End Sub

    Private Sub btnUpLoad_InitFile_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUpLoad_InitFile.ItemClick
        Dim xfrm As New frmUpLoadInitFile
        xfrm.MdiParent = Me
        xfrm.Show()
    End Sub

    Private Sub BarButtonItem17_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        SetLayout("Office 2010 Black")
    End Sub

    Private Sub BarButtonItem18_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick

    End Sub

    Private Sub btnSetupLabels_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSetupLabels.ItemClick
        'Configurar Etiqueta
        Dim xCtrlPanel_form As New frmSetupLabels
        Me.Cursor = Cursors.WaitCursor
        With xCtrlPanel_form
            .MdiParent = Me
            .Show()
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbSkinItems_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSkinItems.EditValueChanged
        'DefaultLookAndFeel1.LookAndFeel.SetSkinStyle()

    End Sub

    Private Sub cmbSkinItems_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSkinItems.SelectedIndexChanged
        'DefaultLookAndFeel1.LookAndFeel.SetSkinStyle()

    End Sub

    Private Sub BarButtonItem23_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick

    End Sub



    Sub GetLoginStatus()
        Dim pResult As String = ""
        Dim xdata As DataSet
        Try

            Dim xserv As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/Catalogues/wms_security.asmx")
            xdata = xserv.SearchByKeyUserLogin(PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                If xdata.Tables(0).Rows(0)("IS_LOGGED") = "0" Then
                    Application.Exit()
                End If
            Else
                MessageBox.Show(pResult)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnReciboDoc_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReciboDoc.ItemClick
        Dim xRece As New frmDocumentoIngreso
        Me.Cursor = Cursors.WaitCursor
        xRece.MdiParent = Me
        xRece.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAutoSat_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAutoSat.ItemClick
        Dim xAuSa As New frmAutorizacionSAT
        Me.Cursor = Cursors.WaitCursor
        xAuSa.MdiParent = Me
        xAuSa.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnGarita_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGarita.ItemClick
        Dim xgar As New frmGarita
        Me.Cursor = Cursors.WaitCursor
        xgar.MdiParent = Me
        xgar.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAprobacion_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAprobacion.ItemClick
        'Dim XAPR As New frmAprobacionRecepcion
        Dim XAPR As New FrmAprobacionFiscal
        Me.Cursor = Cursors.WaitCursor
        XAPR.MdiParent = Me
        XAPR.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnInventarioDocumentos_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInventarioDocumentos.ItemClick
        Dim xinvd As New frmInventoryDocs
        Me.Cursor = Cursors.WaitCursor
        xinvd.MdiParent = Me
        xinvd.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnPolizaEgreso_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPolizaEgreso.ItemClick
        Dim xDEF As New frmDocumentoEgresoFiscal
        Me.Cursor = Cursors.WaitCursor
        xDEF.MdiParent = Me
        xDEF.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Static_Message_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Static_Message.ItemClick
        NotifyStatus("...", False, False)
    End Sub

    Private Sub btnGenerateWave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnGenerateWave.ItemClick
        Dim xwp As New frmGeneraOla
        Me.Cursor = Cursors.WaitCursor
        xwp.MdiParent = Me
        xwp.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnReceptions_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReceptions.ItemClick
        Dim rec As New frmReceptions
        rec.Cursor = Cursors.WaitCursor
        rec.MdiParent = Me
        rec.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnConsultaAuditsRec_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConsultaAuditsRec.ItemClick
        Dim xwp As New frmAuditRec
        Me.Cursor = Cursors.WaitCursor
        xwp.MdiParent = Me
        xwp.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnPase_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPase.ItemClick
        Dim frm As New PaseDeSalidaVista
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Static_Environment_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Static_Environment.ItemClick

    End Sub

    Private Sub btnIngresoGeneral_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnIngresoGeneral.ItemClick
        Dim fdg As New frmDocumentoIngresoGeneral
        Me.Cursor = Cursors.WaitCursor
        fdg.MdiParent = Me
        fdg.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAuditDispatch_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim xwp As New frmAuditDisp
        Me.Cursor = Cursors.WaitCursor
        xwp.MdiParent = Me
        xwp.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnEgresoGeneral_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEgresoGeneral.ItemClick
        Dim feg As New frmEgresoGeneral
        Me.Cursor = Cursors.WaitCursor
        feg.MdiParent = Me
        feg.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnKardexFiscal_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnKardexFiscal.ItemClick
        Dim fk As New frmKardexFiscal
        Me.Cursor = Cursors.WaitCursor
        fk.MdiParent = Me
        fk.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCostearGeneral_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCostearGeneral.ItemClick
        Dim frm As New CosteoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem_InvViews_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem_InvViews.ItemClick
        Dim fc As New frmInvViews
        Me.Cursor = Cursors.WaitCursor
        fc.MdiParent = Me
        fc.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnConteos_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConteos.ItemClick
        Dim fc As New frmInvAudit
        Me.Cursor = Cursors.WaitCursor
        fc.MdiParent = Me
        fc.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnServiciosAsociados_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnServiciosAsociados.ItemClick
        Dim fc As New frmRelateServices
        Me.Cursor = Cursors.WaitCursor
        fc.MdiParent = Me
        fc.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnOccupancy_ItemClick(sender As System.Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOccupancy.ItemClick
        Dim fc As New EstadoDeUbicacionesVista
        Me.Cursor = Cursors.WaitCursor
        fc.MdiParent = Me
        fc.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RibbonControl_Click(sender As System.Object, e As System.EventArgs) Handles RibbonControl.Click



    End Sub

    Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As System.EventArgs) Handles RibbonControl.SelectedPageChanged

    End Sub

    Private Sub RibbonControl_SelectedPageChanging(sender As Object, e As DevExpress.XtraBars.Ribbon.RibbonPageChangingEventArgs) Handles RibbonControl.SelectedPageChanging


    End Sub

    Private Sub RibbonControl_TabIndexChanged(sender As Object, e As System.EventArgs) Handles RibbonControl.TabIndexChanged

    End Sub

    Private Sub btnIngresoActurizacionSat_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnIngresoActurizacionSat.ItemClick
        Dim frm As New frmIngresoAutorizationSyncSat
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnInsuranceCompany_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInsuranceCompany.ItemClick
        Dim frm As New frmInsuranceCompanies
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnInsuranceDocs_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInsuranceDocs.ItemClick
        Dim frm As New frmInsuranceDocs
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCertificadoDeposito_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCertificadoDeposito.ItemClick


        Dim frm As New frmCertificado
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnSupervisions_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSupervisions.ItemClick
        Dim frm As New frmSupervisions
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GenerateRepCertificateBond()
        Try
            Dim xdataset As New DataSet
            Dim pResult As String = ""
            Try
                Dim xserv As New OnePlanServices_Certificates.WMS_CertificatesSoapClient("WMS_CertificatesSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Certificates.asmx")
                xdataset = xserv.GetRepCertificateBond("repCertificadoBono", pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    Dim Xrpt As New repCerticateBond
                    Xrpt.Parameters("logoImg").Value = PublicLoginInfo.LOGO
                    Xrpt.DataSource = Nothing
                    Xrpt.DataSource = xdataset.Tables(0)
                    Xrpt.DataMember = "repCertificadoBono"
                    Xrpt.FillDataSource()
                    Xrpt.ShowPreview()
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Catch ex As Exception
                xdataset = Nothing
                MsgBox(pResult & ": " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
            xdataset = Nothing
            pResult = Nothing
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnRepCertificadoBono_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRepCertificadoBono.ItemClick
        GenerateRepCertificateBond()
    End Sub

    Private Sub btnRepPolizaSeguros_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRepPolizaSeguros.ItemClick
        Dim frm As New frmRepPolizasSeguro
        Me.Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnTypeChange_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTypeChange.ItemClick
        Dim frm As New FrmTypeChange
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAcuerdoComercial_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAcuerdoComercial.ItemClick
        Dim frm As New FrmAcuerdoComercial
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAcuerdoCliente_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAcuerdoCliente.ItemClick
        Dim frm As New FrmConsultAcuerdoCliente
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAutoQuotaLetter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAutoQuotaLetter.ItemClick
        Dim frm As New FrmAuthorizationLatterQuota
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnAcuseRecibo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAcuseRecibo.ItemClick
        Dim frm As New FrmAcuseRecibo
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnVencimientoPolizas_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnVencimientoPolizas.ItemClick
        Dim frm As New FrmVencimientoPolizas
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonCertificadoDeposito_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonCertificadoDeposito.ItemClick
        Dim frm As New FrmCertificateDeposit
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonPaseSalidaCertificado_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UiBotonPaseSalidaCertificado.ItemClick
        Dim frm As New frmPaseSalidaCertificado
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonRectificaciones_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonRectificaciones.ItemClick
        Dim frm As New FrmRectifications
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnIngresoExterno_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnIngresoExterno.ItemClick
        Dim frmInvFl As New FrmInventoryExtAdd 'FrmInventoryFile
        Cursor = Cursors.WaitCursor
        frmInvFl.MdiParent = Me
        frmInvFl.Show()
        Cursor = Cursors.Default
        FrmInventoryAdd.Gtipo = "INGRESO"
        FrmInventoryAdd.Gsigno = "+"
    End Sub

    Private Sub BarBntOutInventory_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarBntOutInventory.ItemClick
        Dim frmInvFl As New FrmInventoryOut 'FrmInventoryFile
        Cursor = Cursors.WaitCursor
        frmInvFl.MdiParent = Me
        frmInvFl.Show()
        Cursor = Cursors.Default
        FrmInventoryAdd.Gtipo = "EGRESO"
        FrmInventoryAdd.Gsigno = "-"
    End Sub

    ''' <summary>
    ''' Usuario desea abrir consulta de egreso
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub UiBotonReporteEgreso_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonReporteEgreso.ItemClick
        Dim frm As New FrmConsultaDeEgreso
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem44_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonReporteIngresoF.ItemClick
        Dim frm As New frmConsultaDeIngresoFiscal
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonDemandaDespacho_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonDemandaDespacho.ItemClick
        AbrirFormulario(Of DemandaDeDespachoVista)()
    End Sub

    Private Sub UiBotonServiciosPorCobrar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonServiciosPorCobrar.ItemClick
        Dim frm As New ServiciosPorCobrarVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim coneccion As ConfiguracionDeConexion = New ConfiguracionDeConexion
        Mvx.Ioc.RegisterSingleton(Of IConfiguracionDeConexion, ConfiguracionDeConexion)(coneccion)
        Mvx.Ioc.RegisterSingleton(Of IInteraccionConUsuarioServicio, RibbonForm1)(Me)
        Mvx.Ioc.RegisterSingleton(Of IBaseDeDatosServicio, BaseDeDatosServicio)(New BaseDeDatosServicio(coneccion))
    End Sub

    Private Sub UiBtnInventarioPorAcuerdoComercial_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBtnInventarioPorAcuerdoComercial.ItemClick
        Dim frm As New AcuerdoComercialVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonIngresoERP_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonIngresoERP.ItemClick
        AbrirFormulario(Of RecepcionErpVista)()
    End Sub

    Private Sub UiBotonMasterPack_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonMasterPack.ItemClick
        Dim frm As New InventarioMasterPackVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonManifiestoDeCarga_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonManifiestoDeCarga.ItemClick
        AbrirFormulario(Of ManifiestoCargaVista)()
    End Sub

    Private Sub UiBotonConsultaBackOrder_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaBackOrder.ItemClick
        Dim frm As New OrdenesDeVentaPendientesVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonAsignacionConteoFisico_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonAsignacionConteoFisico.ItemClick
        Dim frm As New AsignacionConteoFisico
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonConsultaConteoFisico_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaConteoFisico.ItemClick
        Dim frm As New ConsultaConteoFisico
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBarButtonZonas_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBarButtonZonas.ItemClick
        Dim frm As New CatalogoZonaVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonBalanceDeSaldosFiscal_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonBalanceDeSaldosFiscal.ItemClick
        Dim frm As New BalanceDeSaldosFiscalVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub
    Private Sub UiBotonConsultaCosteos_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaCosteos.ItemClick
        Dim frm As New ConsultaCosteoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub btnVencimientoDePolizas_ItemClick(sender As Object, e As ItemClickEventArgs) Handles btnVencimientoDePolizas.ItemClick
        Dim frm As New VencimientoDePolizasVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonSolicitudDeTraslado_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonSolicitudDeTraslado.ItemClick
        AbrirFormulario(Of SolicitudDeTrasladoVista)()
    End Sub

    Private Sub UiBarButtonConsultaSolicitudDeTraslado_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBarButtonConsultaSolicitudDeTraslado.ItemClick
        Dim frm As New ReporteDeSolicitudDeTrasladoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub


    Private Sub BarButtonItem33_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles UiBotonCatalogoClases.ItemClick
        Dim frm As New ClaseVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonBloqueoDeInventario_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonBloqueoDeInventario.ItemClick
        Dim frm As New BloqueoDeInventarioVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Function ValidarSiEstaAbiertoElFormulario(nombre As String) As Form
        Dim formularios As FormCollection = Application.OpenForms

        For Each formulario As Form In formularios
            If formulario.Name = nombre Then
                Return formulario
            End If
        Next

        Return Nothing
    End Function

    Private Sub AbrirFormulario(Of T As Form)(Optional ByVal nombreDelFormulario As String = Nothing, Optional ByVal parametrosDeFormulario As Object() = Nothing)
        Cursor = Cursors.WaitCursor
        Try
            Dim tipoDeFormulario As Type = GetType(T)
            If nombreDelFormulario Is Nothing Then
                nombreDelFormulario = tipoDeFormulario.Name
            End If

            Dim formulario As Form = ValidarSiEstaAbiertoElFormulario(nombreDelFormulario)
            If IsNothing(formulario) Then
                Dim formularioNuevo As T = Activator.CreateInstance(tipoDeFormulario, parametrosDeFormulario)
                formularioNuevo.MdiParent = Me
                formularioNuevo.Show()
            Else
                formulario.MdiParent = Me
                formulario.Activate()
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub UiButtonTrazabilidadDeDemanda_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiButtonTrazabilidadDeDemanda.ItemClick
        Dim frm As New TrazabilidadDeDemandaVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonConsultaDeLineaDePicking_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaDeLineaDePicking.ItemClick
        Dim frm As New ConsultaDeLineaDePickingVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonCatalogoEmpresasDeTransporte_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonCatalogoEmpresasDeTransporte.ItemClick
        Dim frm As New EmpresaDeTransporteVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonCatalogoDePiloto_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonCatalogoDePiloto.ItemClick
        Dim frm As New PilotoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonCatalogoVehiculo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonCatalogoVehiculo.ItemClick
        Dim frm As New VehiculoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonConsultaDeManifiesto_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaDeManifiesto.ItemClick
        AbrirFormulario(Of ConsultaDeManifiestoVista)()
    End Sub

    Private Sub UiTimerVerifyLicense_Tick(sender As Object, e As EventArgs) Handles UiTimerVerifyLicense.Tick

    End Sub

    Private Sub UiBarButtonConsultaInventarioDiario_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBarButtonConsultaInventarioDiario.ItemClick
        Dim frm As New ConsultaDeInventarioDiarioVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonPedidosPorRuta_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonPedidosPorRuta.ItemClick
        Dim frm As New ConsultaPedidosPorVendedorVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonConsultaPaseDeSalida_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaPaseDeSalida.ItemClick
        Dim frm As New ConsultaDePaseDeSalidaVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem33_ItemClick_2(sender As Object, e As ItemClickEventArgs) Handles UiBotonConsultaCumplimientoEntrega.ItemClick
        Dim frm As New CumplimientoDeEntregaVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonAdminitradorDeLineaDePicking_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonAdminitradorDeLineaDePicking.ItemClick
        AbrirFormulario(Of AdministradorDeLineaDePickingVista)()
    End Sub

    Private Sub UiBarButtonReporteDevoluciones_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBarButtonReporteDevoluciones.ItemClick
        Dim frm As New ReporteRecepcionPorDevolucionVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonInventarioComprometido_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonInventarioComprometido.ItemClick
        Dim frm As New InventarioComprometido
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub botonConsultasPersonalizadas_ItemClick(sender As Object, e As ItemClickEventArgs) Handles botonConsultasPersonalizadas.ItemClick
        Dim frm As New QueryList
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonReportePicking_Click(sender As Object, e As ItemClickEventArgs) Handles UiBotonReportePicking.ItemClick
        Dim frm As New ReportePickingVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBontonInvnetarioInactivo_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBontonInvnetarioInactivo.ItemClick
        Dim frm As New InventarioInactivoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonIndicesDeBodega_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonIndicesDeBodega.ItemClick
        Dim frm As New IndicesDeBodegaVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub UiBotonZonaPosicionamiento_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonZonaPosicionamiento.ItemClick
        Dim frm As New ZonaDePosicionamientoVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default

    End Sub

    Private Sub UiBotonSugeridoCompra_ItemClick(sender As Object, e As ItemClickEventArgs) Handles UiBotonSugeridoCompra.ItemClick
        Dim frm As New SugeridoCompraVista
        Cursor = Cursors.WaitCursor
        frm.MdiParent = Me
        frm.Show()
        Cursor = Cursors.Default
    End Sub

    Public Function GetCheckPoint() As Checkpoint
        Dim resultListCheckPoint = New Checkpoint
        Try

            Dim securityWs As New OnePlanServices_Security.WMS_SecuritySoapClient("WMS_SecuritySoap", PublicLoginInfo.WSHost + "/catalogues/wms_security.asmx")
            Dim resultError As String = ""
            Dim dt As DataTable
            dt = securityWs.GetCheckpointsByLogin(PublicLoginInfo.LoginID, "PC", PublicLoginInfo.Environment, resultError)
            If String.IsNullOrEmpty(resultError) Then
                If dt.Rows.Count > 0 Then
                    Dim expression As String
                    expression = "CATEGORY = 'ROOT'"
                    Dim dr = dt.Select(expression)
                    Dim cp As New Checkpoint()
                    If (dr.Length > 0) Then
                        cp.CheckId = dr(0)("CHECK_ID")
                        cp.Category = dr(0)("CATEGORY")
                        cp.Description = dr(0)("DESCRIPTION")
                        cp.Parent = IIf(IsDBNull(dr(0)("PARENT")), Nothing, dr(0)("PARENT"))
                        cp.Access = dr(0)("ACCESS")
                        cp.Mpc1 = IIf(IsDBNull(dr(0)("MPC_1")), 0, dr(0)("MPC_1"))
                        cp.Mpc2 = IIf(IsDBNull(dr(0)("MPC_2")), 0, dr(0)("MPC_2"))
                        cp.Mpc3 = IIf(IsDBNull(dr(0)("MPC_3")), 0, dr(0)("MPC_3"))
                        cp.Mpc4 = IIf(IsDBNull(dr(0)("MPC_4")), 0, dr(0)("MPC_4"))
                        cp.Mpc5 = IIf(IsDBNull(dr(0)("MPC_5")), 0, dr(0)("MPC_5"))
                        cp.TargetLocation = IIf(IsDBNull(dr(0)("TARGET_LOCATION")), Nothing, dr(0)("TARGET_LOCATION"))
                        cp.Order = IIf(IsDBNull(dr(0)("ORDER")), 0, dr(0)("ORDER"))

                        cp.Checkpoints = New List(Of Checkpoint)
                        cp = GetAccessCheckPoint(cp, dt)
                        resultListCheckPoint = cp
                    Else
                        Throw New Exception("No se encontro el nivel raiz(root), para formar el menu.")
                    End If
                Else
                    Throw New Exception("No tiene configurado niveles de acceso.")
                End If
            Else
                Throw New Exception(resultError)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return resultListCheckPoint
    End Function

    Private Function GetAccessCheckPoint(cp As Checkpoint, dt As DataTable) As Checkpoint
        Dim expression As String
        expression = "[PARENT] = '" + cp.CheckId + "'"
        Dim dr = dt.Select(expression, "[ORDER] ASC")
        For Each dataRow As DataRow In dr
            Dim checkpoint = New Checkpoint()
            checkpoint.CheckId = dataRow("CHECK_ID")
            checkpoint.Category = dataRow("CATEGORY")
            checkpoint.Description = dataRow("DESCRIPTION")
            checkpoint.Parent = IIf(IsDBNull(dataRow("PARENT")), Nothing, dataRow("PARENT"))
            checkpoint.Access = dataRow("ACCESS")
            checkpoint.Mpc1 = IIf(IsDBNull(dataRow("MPC_1")), 0, dataRow("MPC_1"))
            checkpoint.Mpc2 = IIf(IsDBNull(dataRow("MPC_2")), 0, dataRow("MPC_2"))
            checkpoint.Mpc3 = IIf(IsDBNull(dataRow("MPC_3")), "", dataRow("MPC_3"))
            checkpoint.Mpc4 = IIf(IsDBNull(dataRow("MPC_4")), 0, dataRow("MPC_4"))
            checkpoint.Mpc5 = IIf(IsDBNull(dataRow("MPC_5")), "", dataRow("MPC_5"))
            checkpoint.TargetLocation = IIf(IsDBNull(dataRow("TARGET_LOCATION")), Nothing, dataRow("TARGET_LOCATION"))
            checkpoint.Order = IIf(IsDBNull(dataRow("ORDER")), 0, dataRow("ORDER"))
            checkpoint.PathImage = IIf(IsDBNull(dataRow("PATH_IMAGE")), "", dataRow("PATH_IMAGE"))
            Dim parentCh As New Checkpoint
            With parentCh
                .CheckId = cp.CheckId
                .Category = cp.Category
            End With
            checkpoint.ParentObject = parentCh
            checkpoint.Checkpoints = New List(Of Checkpoint)

            checkpoint = GetAccessCheckPoint(checkpoint, dt)
            cp.Checkpoints.Add(checkpoint)
        Next
        Return cp
    End Function

    Private Sub GeneratedMenu()
        Try
            RibbonControl.Items.Clear()

            Dim image As Image
            image = Image.FromFile(Application.StartupPath + "\Resources\DevExpress\Images\Appearance\ColorMixer_32x32.png")
            BarEditItem_GUI.ImageOptions.Image = image
            BarEditItem_GUI.ImageOptions.LargeImage = image

            RibbonControl.Items.Add(Static_Version)
            RibbonControl.Items.Add(Static_Environment)
            RibbonControl.Items.Add(Static_Message)
            RibbonControl.Items.Add(BarEditItem_GUI)

            RibbonStatusBar.ItemLinks.Add(Static_Version)
            RibbonStatusBar.ItemLinks.Add(Static_Environment)
            RibbonStatusBar.ItemLinks.Add(BarEditItem_GUI)
            RibbonStatusBar.ItemLinks.Add(Static_Message)

            RibbonControl.PageCategories.Clear()
            RibbonControl.Pages.Clear()
            RibbonControl.QuickToolbarItemLinks.Clear()
            RibbonControl.PageHeaderItemLinks.Clear()

            RibbonControl.PageHeaderItemLinks.Add(BarEditItem_GUI)
            RibbonControl.QuickToolbarItemLinks.Add(BarEditItem_GUI)
            ApplicationMenu1.ItemLinks.Add(BarEditItem_GUI)

            CreatedControllerForMenu(GetCheckPoint())
            FillLookAndFeelMenu(PublicLoginInfo.GUI)
            AddItemsStyleToRibbon()
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub CreatedControllerForMenu(checkpoint As Checkpoint)
        Try
            For Each cp As Checkpoint In checkpoint.Checkpoints
                Try
                    Select Case cp.Category
                        Case Swift3plCategory.PAGE.ToString()
                            Dim page = New RibbonPage()
                            page.Name = cp.CheckId
                            page.Text = cp.Description
                            If Not String.IsNullOrEmpty(cp.PathImage) Then
                                Dim image As Image
                                image = Image.FromFile(Application.StartupPath + cp.PathImage)
                                page.ImageOptions.Image = image
                            End If
                            RibbonControl.Pages.Add(page)
                        Case Swift3plCategory.GROUP.ToString()
                            Dim pageGroup = New RibbonPageGroup()
                            pageGroup.Name = cp.CheckId
                            pageGroup.Text = cp.Description
                            If Not String.IsNullOrEmpty(cp.PathImage) Then
                                Dim image As Image
                                image = Image.FromFile(Application.StartupPath + cp.PathImage)
                                pageGroup.ImageOptions.Image = image
                            End If
                            For Each page As RibbonPage In RibbonControl.Pages
                                If page.Name.Equals(cp.ParentObject.CheckId) Then
                                    page.Groups.Add(pageGroup)
                                    Exit For
                                End If
                            Next
                        Case Swift3plCategory.OPTION.ToString()
                            Dim button = New BarButtonItem()
                            button.Name = cp.CheckId
                            button.Caption = cp.Description
                            button.Tag = cp
                            Dim style = 0
                            If Not String.IsNullOrEmpty(cp.Mpc3) Then
                                style = Integer.Parse(cp.Mpc3)
                            End If
                            button.RibbonStyle = GetRibbonStyleByButton(style)

                            If Not String.IsNullOrEmpty(cp.PathImage) Then
                                Dim image As Image
                                image = Image.FromFile(Application.StartupPath + cp.PathImage)
                                button.ImageOptions.Image = image
                                button.ImageOptions.LargeImage = image
                            End If
                            RibbonControl.Items.Add(button)

                            For Each page As RibbonPage In RibbonControl.Pages
                                For Each group As RibbonPageGroup In page.Groups
                                    If group.Name.Equals(cp.ParentObject.CheckId) Then
                                        group.ItemLinks.Add(button)
                                    End If
                                Next
                            Next

                            If cp.Mpc1 = 1 Then
                                RibbonControl.PageHeaderItemLinks.Add(button)
                            End If
                            If cp.Mpc2 = 1 Then
                                RibbonControl.QuickToolbarItemLinks.Add(button)
                            End If
                            If cp.Mpc4 = 1 Then
                                ApplicationMenu1.ItemLinks.Add(button)
                            End If

                            AddHandler button.ItemClick, AddressOf ProcessOperation

                    End Select
                    CreatedControllerForMenu(cp)
                Catch ex As Exception
                    NotifyStatus(ex.Message, False, True)
                End Try
            Next
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub ProcessOperation(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        MostrarDialogoDeCargando()
        Try
            '\Dim button = DirectCast(sender, BarButtonItem)
            If e.Item.Tag Is Nothing Then
                CerrarDialogoDeCargando()
                Return
            End If
            Dim optionButton As Checkpoint = DirectCast(e.Item.Tag, Checkpoint)

            If optionButton.TargetLocation.Equals("LogOut") Then
                LogOut()
                Dispose()
                CerrarDialogoDeCargando()
                Return
            End If
            If optionButton.TargetLocation.Equals("RefreshMenu") Then
                GeneratedMenu()
                CerrarDialogoDeCargando()
                Return
            End If

            Dim openMultipleForm = True
            openMultipleForm = Not String.IsNullOrEmpty(optionButton.Mpc5) AndAlso (Integer.Parse(optionButton.Mpc5) = 1)

            Dim objectForm = [Assembly].GetEntryAssembly.CreateInstance([Assembly].GetEntryAssembly.GetName.Name & "." & optionButton.TargetLocation)
            If Not objectForm Is Nothing Then
                Dim resultForm = DirectCast(objectForm, Form)
                OpenForm(resultForm, openMultipleForm)
                CerrarDialogoDeCargando()
                Return
            End If
            objectForm = Nothing
            Dim projectM As Assembly = Assembly.Load("MobilityScm.Modelo.Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            If projectM IsNot Nothing Then
                For Each dt As Object In projectM.DefinedTypes
                    If (dt.Name() = optionButton.TargetLocation) Then
                        objectForm = dt
                        Exit For
                    End If
                Next
            End If
            If Not objectForm Is Nothing Then
                Dim resultForm = Nothing
                Dim frm = Activator.CreateInstance(objectForm, False)
                If TypeOf frm Is XtraForm Then
                    resultForm = DirectCast(frm, XtraForm)
                Else
                    resultForm = DirectCast(frm, Form)
                End If
                OpenForm(resultForm, openMultipleForm)
                CerrarDialogoDeCargando()
                Return
            End If
        Catch ex As Exception
            CerrarDialogoDeCargando()
            NotifyStatus(ex.Message, True, True)
        End Try
        CerrarDialogoDeCargando()
    End Sub

    Private Sub OpenForm(formPr As Form, validatedOpen As Boolean)
        Cursor = Cursors.WaitCursor
        Try
            If validatedOpen Then
                Dim formOp As Form = ValidarSiEstaAbiertoElFormulario(formPr.Name)
                If IsNothing(formOp) Then
                    formPr.MdiParent = Me
                    formPr.Show()
                    gLastScreenShowed = formPr.Name
                Else
                    formOp.MdiParent = Me
                    formOp.Activate()
                    gLastScreenShowed = formOp.Name
                End If
            Else
                formPr.MdiParent = Me
                formPr.Show()
                gLastScreenShowed = formPr.Name
            End If
            gLastTabShowed = RibbonControl.SelectedPage.Text
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GetRibbonStyleByButton(optionStyle As Integer) As RibbonItemStyles
        Select Case optionStyle
            Case Swift3plRibbonItemStyle.Default
                Return RibbonItemStyles.Default
            Case Swift3plRibbonItemStyle.All
                Return RibbonItemStyles.All
            Case Swift3plRibbonItemStyle.Large
                Return RibbonItemStyles.Large
            Case Swift3plRibbonItemStyle.SmallWithText
                Return RibbonItemStyles.SmallWithText
            Case Swift3plRibbonItemStyle.SmallWithoutText
                Return RibbonItemStyles.SmallWithoutText
        End Select
        Return RibbonItemStyles.Default
    End Function

    Private Sub OpenLastForm(nameForm As String)
        Try
            Dim objectForm = [Assembly].GetEntryAssembly.CreateInstance([Assembly].GetEntryAssembly.GetName.Name & "." & nameForm)
            If Not objectForm Is Nothing Then
                Dim resultForm = DirectCast(objectForm, Form)
                OpenForm(resultForm, False)
                Return
            End If
            objectForm = Nothing
            Dim projectM As Assembly = Assembly.Load("MobilityScm.Modelo.Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")
            If projectM IsNot Nothing Then
                For Each dt As Object In projectM.DefinedTypes
                    If (dt.Name() = nameForm) Then
                        objectForm = dt
                        Exit For
                    End If
                Next
            End If
            If Not objectForm Is Nothing Then
                Dim resultForm = Nothing
                Dim frm = Activator.CreateInstance(objectForm, False)
                If TypeOf frm Is XtraForm Then
                    resultForm = DirectCast(frm, XtraForm)
                Else
                    resultForm = DirectCast(frm, Form)
                End If
                OpenForm(resultForm, False)
                Return
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub AddItemsStyleToRibbon()
        Try
            Dim existsPage = False
            For Each page As RibbonPage In RibbonControl.Pages
                If page.Name.Equals("CONFIGURATION") Then
                    Dim existsGroup = False
                    For Each group As RibbonPageGroup In page.Groups
                        If group.Name.Equals("STYLE") Then
                            group.ItemLinks.Add(BarEditItem_GUI)
                            existsGroup = True
                            Exit For
                        End If
                    Next
                    If Not existsGroup Then
                        Dim pageGroup = New RibbonPageGroup()
                        pageGroup.Name = "STYLE"
                        pageGroup.Text = "Estilo"
                        pageGroup.ItemLinks.Add(BarEditItem_GUI)
                        page.Groups.Add(pageGroup)
                    End If
                    existsPage = True
                    Exit For
                End If
            Next
            If Not existsPage Then
                Dim page = New RibbonPage()
                page.Name = "CONFIGURATION"
                page.Text = "Configuración"

                Dim pageGroup = New RibbonPageGroup()
                pageGroup.Name = "STYLE"
                pageGroup.Text = "Estilo"
                pageGroup.ItemLinks.Add(BarEditItem_GUI)
                page.Groups.Add(pageGroup)

                RibbonControl.Pages.Add(page)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub MostrarDialogoDeCargandoVb()
        If Not PublicLoginInfo.DialogoDeCargaAbierto Then
            PublicLoginInfo.DialogoDeCargaAbierto = True
           ' UISplashScreenManager.ShowWaitForm()
        End If
    End Sub

    Public Sub CerrarDialogoDeCargandoVb()
        If PublicLoginInfo.DialogoDeCargaAbierto Then
            PublicLoginInfo.DialogoDeCargaAbierto = False
            'UISplashScreenManager.CloseWaitForm()
        End If
    End Sub
End Class

Public Class ObjectFinder
    Public Shared Function CreateObjectInstance(ByVal objectName As String) As Object
        ' Creates and returns an instance of any object in the assembly by its type name.
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                'Appends the root namespace if not specified.
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj

    End Function

    Public Shared Function CreateForm(ByVal formName As String) As Form
        ' Return the instance of the form by specifying its name.
        Return DirectCast(CreateObjectInstance(formName), Form)
    End Function
End Class


Public Class Checkpoint
    Public Property CheckId As String
    Public Property Category As String
    Public Property Description As String
    Public Property Parent As String
    Public Property Access As String
    Public Property Mpc1 As Decimal
    Public Property Mpc2 As Decimal
    Public Property Mpc3 As String
    Public Property Mpc4 As Decimal
    Public Property Mpc5 As String
    Public Property TargetLocation As String
    Public Property Order As Integer
    Public Property PathImage As String
    Public Property ParentObject As Checkpoint
    Public Property Checkpoints As List(Of Checkpoint)
End Class

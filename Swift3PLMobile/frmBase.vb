Imports System.Data
Imports System.IO
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports MobilityScm.Views.TomarFoto
Imports MobilityScm.Views
Imports Resco
Imports Resco.Controls
Imports MobilityScm.Vertical.Servicios
Imports MobilityScm.Louncher


Public Class frmBase

    Private Const SRCCOPY As Integer = &HCC0020
    Private Const CORE_DLL As String = "coredll.dll"
    Private Shared _taskBar As IntPtr
    Private Shared _sipButton As IntPtr
    Private Shared _deviceId As String, _deviceIp As String
    Private Shared _lastUpdateCheck As DateTime, _startTime As DateTime

    Public Enum WindowPosition
        SWP_HIDEWINDOW = &H80
        SWP_SHOWWINDOW = &H40
    End Enum

    <DllImport(CORE_DLL)> _
    Public Shared Function BitBlt(ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, _
    ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As UInteger) As Integer
    End Function

    <DllImport(CORE_DLL)> _
    Public Shared Function CeRunAppAtEvent(ByVal appName As String, ByVal [Event] As Integer) As Boolean
    End Function

    <DllImport(CORE_DLL, EntryPoint:="FindWindowW", SetLastError:=True)> _
    Public Shared Function FindWindowCE(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    <DllImport(CORE_DLL)> _
    Private Shared Function GetDC(ByVal hwnd As IntPtr) As IntPtr
    End Function

    <DllImport(CORE_DLL)> _
    Public Shared Function MessageBeep(ByVal uType As Integer) As Boolean
    End Function

    <DllImport(CORE_DLL, SetLastError:=True)> _
    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, _
     ByVal uFlags As UInteger) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Private Sub frmBase_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus

    End Sub

    Private Sub frmBase_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.HandleDestroyed
        'ReturnTaskbar()
        'Application.Exit()
    End Sub
    Private Sub frmBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        MyBase.OnResize(e)
        panelLogin.Size = Me.ClientSize
    End Sub



    Public Sub New()
        Try

            handheld = UtileriasServicio.UsuarioDeseaObtenerInformacionModelo

            panelLogin = New ctrl_Login() With {.Visible = False}
            panelMenu = New ctrl_Menu() With {.Visible = False}
            panelTakePicture = New ctrl_Picture() With {.Visible = False}

            panelMyPickingMC92 = New myPickingMC92() With {.Visible = False}
            panelMyPicking = New myPicking() With {.Visible = False}

            panelMyReception = New MyReception() With {.Visible = False}
            panelSetupPrinter = New ctrl_setup_printer() With {.Visible = False}
            panelRecepFiscal = New ctrl_RecepFiscal() With {.Visible = False}
            panelBrowsePics = New ctrl_browse() With {.Visible = False}
            panelRecFiscalLogisInfo = New ctrl_RECFIS_LogisInfo() With {.Visible = False}
            panelRecFiscalStep2 = New ctrl_RECFIS_Step2() With {.Visible = False}
            panelTransHandler = New ctrl_trans_handler() With {.Visible = False}
            panelInfoHandler = New ctrl_info_handler() With {.Visible = False}
            panelInfoHandlerTree = New ctrl_info_handler_tree() With {.Visible = False}
            panelTypeChange = New ctrl_type_charge() With {.Visible = False}
            panelAcuseRecibo = New ctrl_acuse_recibo() With {.Visible = False}
            panelTomarFoto = New TomarFoto() With {.Visible = False}
            panelMaterialXSerialNumbers = New MaterialXSerialNumbers() With {.Visible = False}
            panelExplodeMasterPack = New ExplodeMasterPack() With {.Visible = False}
            panelExplodeMasterPackDetail = New ExplodeMasterPackDetail() With {.Visible = False}
            panelSerialNumberProcess = New SerialNumberProcess() With {.Visible = False}
            panelScanDocument = New ctrl_ScanDocument() With {.Visible = False}
            panelDetalleDevoluciones = New DetalleDevoluciones() With {.Visible = False}
            panelUbicacionesSugeridas = New UbicacionesSugeridas() With {.Visible = False}
            InitializeComponent()

            Me.SuspendLayout()
            Me.Controls.Add(panelLogin)
            Me.Controls.Add(panelMenu)
            Me.Controls.Add(panelTakePicture)
            Me.Controls.Add(panelMyPicking)
            Me.Controls.Add(panelMyPickingMC92)
            Me.Controls.Add(panelMyReception)
            Me.Controls.Add(panelSetupPrinter)
            Me.Controls.Add(panelRecepFiscal)
            Me.Controls.Add(panelBrowsePics)
            Me.Controls.Add(panelRecFiscalLogisInfo)
            Me.Controls.Add(panelRecFiscalStep2)

            Me.Controls.Add(panelTransHandler)
            Me.Controls.Add(panelInfoHandler)
            Me.Controls.Add(panelInfoHandlerTree)
            Me.Controls.Add(panelTypeChange)
            Me.Controls.Add(panelAcuseRecibo)
            Me.Controls.Add(panelTomarFoto)
            Me.Controls.Add(panelMaterialXSerialNumbers)
            Me.Controls.Add(panelExplodeMasterPack)
            Me.Controls.Add(panelExplodeMasterPackDetail)
            Me.Controls.Add(panelSerialNumberProcess)
            Me.Controls.Add(panelScanDocument)
            Me.Controls.Add(panelDetalleDevoluciones)
            Me.Controls.Add(panelUbicacionesSugeridas)
            panelLogin.txtUserID.Text = ReadLastUser()
            gDeviceAddress = ReadLastPrinter()
            panelLogin.LblLastPrinter.Text = gDeviceAddress
            gCurrentScannerService = gSCANNER_SERVICES.LEER_USER_PWD

            SetupScanner(Me)


            If (handheld = "PA692" Or handheld = "PA400") Then
                ResizeFactorX = 1
                ResizeFactorY = 1
            ElseIf (handheld = "MC67" Or handheld = "MC65" Or handheld = "MC92N0") Then
                ResizeFactorX = 640 / 800
                ResizeFactorY = 1
            ElseIf (handheld.ToUpper() = "MOTOROLA WINCE") Then
                ResizeFactorX = 1.327
                ResizeFactorY = 0.8
            ElseIf (handheld = "ES400") Then
                ResizeFactorX = 0.8
                ResizeFactorY = 1
            ElseIf (handheld = "7545") Then
                ResizeFactorX = 0.8
                ResizeFactorY = 1
            Else
                ResizeFactorX = 1
                ResizeFactorY = 1
            End If

            ResizePanel(panelLogin, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelTakePicture, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelMyPickingMC92, ResizeFactorX, ResizeFactorY)
            ResizeAdvanceTree(panelMyPickingMC92.AdvancedTree1, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelInfoHandlerTree, ResizeFactorX, ResizeFactorY)
            ResizeAdvanceTree(panelInfoHandlerTree.AdvancedTree_Default, ResizeFactorX, ResizeFactorY)
            ResizeAdvanceTree(panelDetalleDevoluciones.AdvancedTree1, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelBrowsePics, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelInfoHandler, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelTransHandler, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelRecFiscalStep2, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelMenu, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelMyReception, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelSetupPrinter, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelExplodeMasterPack, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelExplodeMasterPackDetail, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelAcuseRecibo, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelTomarFoto, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelSerialNumberProcess, ResizeFactorX, ResizeFactorY)
            ResizeDetailView(panelAcuseRecibo.DetailView1, ResizeFactorX, ResizeFactorY)
            ResizeAdvanceList(panelMenu.AdvancedList1, ResizeFactorX, ResizeFactorY)

            ResizeAdvanceList(panelMyReception.UiListaTareas, ResizeFactorX, ResizeFactorY)
            ResizeAdvanceList(panelExplodeMasterPackDetail.UiListaDetalleComponente, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelScanDocument, ResizeFactorX, ResizeFactorY)
            ResizeUiPanel(panelScanDocument.UiElementPanelControl1, ResizeFactorX, ResizeFactorY)
            ResizePanel(panelUbicacionesSugeridas, ResizeFactorX, ResizeFactorY)

            ShowPanel(panelLogin)

            Louncher.FormularioPrincipal = Me
            Louncher.factorX = ResizeFactorX
            Louncher.factorY = ResizeFactorY

            If panelLogin.txtUserID.Text <> "" Then
                panelLogin.txtPass.Focus()
            Else
                panelLogin.txtUserID.Focus()
            End If

            ShowWindowsMenu(False)

            MobilityScm.Keyboard.ButtonConfiguration.ObtenerActionDeBoton(New Windows.Forms.KeyEventArgs(Keys.Enter), AppSettings.Environment, AppSettings.ServerUrl)
            Me.ResumeLayout()

            bluetooth.DeviceName = gDeviceName
            bluetooth.DeviceAddress = gDeviceAddress
            Try
                bluetooth.SetupBluetooth()
            Catch ex As Exception
                Notify(ex.Message, True)
            End Try

            MobilityScm.Print.Zebra.PrintModule.bluetooth = bluetooth

        Catch ex As Exception
            Notify(ex.Message, True)

        End Try
    End Sub

    Public Sub ResizePanel(ByVal panel As Control, ByVal factorX As Double, ByVal factorY As Double)
        panel.Height = panel.Height * factorY
        panel.Top = panel.Location.Y * factorY
        panel.Width = panel.Width * factorX
        Try
            ' panel.Font = New Font(panel.Name, panel.Font.Size * factor, panel.Font.Style)
        Catch
        End Try

        For index As Integer = 0 To panel.Controls.Count - 1
            ResizePanel(panel.Controls(index), factorX, factorY)
        Next
    End Sub

    Public Sub ResizeDetailView(ByVal view As Resco.Controls.DetailView.DetailView, ByVal factorX As Double, ByVal factorY As Double)
        view.Height = view.Height * factorY
        view.Width = view.Width * factorX
        For index As Integer = 0 To view.Items.Count - 1

            view.Items(index).Height = view.Items(index).Height * factorY

            Try
                view.Items(index).TextFont = New Font(view.Items(index).TextFont.Name, view.Items(index).TextFont.Size * factorX, view.Items(index).TextFont.Style)
            Catch ex As Exception

            End Try
        Next
    End Sub
    Public Sub ResizeUiPanel(ByVal panel As Resco.UIElements.Controls.UIElementPanelControl, ByVal factorX As Double, ByVal factorY As Double)
        For index As Integer = 0 To panel.Children.Count - 1
            Try
                Dim child As UIElements.UIControl = panel.Children(index)
                child.Width = child.Width * factorX
                child.Location = New System.Drawing.Point(child.Location.X * factorX, child.Location.Y * factorY)
                Try
                    '  child.Font = New System.Drawing.Font(child.Font.Name, child.Font.Size * factor, child.Font.Style)
                Catch
                End Try
            Catch
            End Try

        Next
    End Sub

    Public Sub ResizeUiPanel(ByVal panel As Resco.UIElements.UIPanel, ByVal factorX As Double, ByVal factorY As Double)
        Try
            panel.Height = panel.Height * factorY
            panel.Width = panel.Width * factorX
            For index As Integer = 0 To panel.Children.Count - 1
                Try
                    Dim child As UIElements.UIControl = panel.Children(index)
                    child.Width = child.Width * factorX
                    child.Location = New System.Drawing.Point(child.Location.X * factorX, child.Location.Y * factorY)
                Catch
                End Try

            Next
        Catch
        End Try
    End Sub

    Public Sub ResizeAdvanceList(ByVal lista As AdvancedList.AdvancedList, ByVal factorX As Double, ByVal factorY As Double)
        For index As Integer = 0 To lista.Templates.Count - 1
            For jndex As Integer = 0 To lista.Templates(index).CellTemplates.Count - 1
                Try
                    Dim tc As AdvancedList.TextCell = lista.Templates(index).CellTemplates(jndex)

                    '  tc.TextFont = New System.Drawing.Font(tc.TextFont.Name, tc.TextFont.Size * factor, tc.TextFont.Style)
                Catch
                End Try
            Next
        Next
    End Sub

    Public Sub ResizeAdvanceTree(ByVal tree As Resco.Controls.AdvancedTree.AdvancedTree, ByVal factorX As Double, ByVal factorY As Double)

     

        For index As Integer = 0 To tree.Templates.Count - 1
            For jndex As Integer = 0 To tree.Templates(index).CellTemplates.Count - 1
                Try
                    If TypeOf tree.Templates(index).CellTemplates(jndex) Is Resco.Controls.AdvancedTree.TextCell Then
                        Dim tc As Resco.Controls.AdvancedTree.TextCell = tree.Templates(index).CellTemplates(jndex)
                        tc.Size = New System.Drawing.Size(tc.Size.Width * factorX, tc.Size.Height * factorY)
                        tc.Location = New System.Drawing.Point(tc.Location.X * factorX, tc.Location.Y * factorY)
                        '  tc.TextFont = New System.Drawing.Font(tc.TextFont.Name, (tc.TextFont.Size) * factor, tc.TextFont.Style)
                    ElseIf TypeOf tree.Templates(index).CellTemplates(jndex) Is Resco.Controls.AdvancedTree.ButtonCell Then
                        Dim tc As Resco.Controls.AdvancedTree.ButtonCell = tree.Templates(index).CellTemplates(jndex)
                        tc.Size = New System.Drawing.Size(tc.Size.Width * factorX, tc.Size.Height * factorY)
                        tc.Location = New System.Drawing.Point(tc.Location.X * factorX, tc.Location.Y * factorY)
                    End If
                Catch
                End Try
            Next
        Next
    End Sub

    'Public Sub ResizeDetailView(ByVal detailView As Resco.Controls.DetailView.DetailView, ByVal factor As Double)
    '    detailView.Size = New System.Drawing.Size(detailView.Size.Width, detailView.Size.Height * factor)
    '    detailView.Location = New System.Drawing.Point(detailView.Location.X, detailView.Location.Y * factor)
    'End Sub

    Public Function ReadLastUser() As String
        Try
            Dim pPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString + "\lstuser.txt"
            Dim pTmpLine As String = ""

            Dim oRead As StreamReader = File.OpenText(pPath)

            Do While oRead.Peek() >= 0
                pTmpLine = oRead.ReadLine().ToUpper
            Loop
            oRead.Close()
            Return pTmpLine.Trim

        Catch ex As Exception
        End Try
        Return ""
    End Function

    Public Function ReadLastPrinter() As String
        Try
            Dim pPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString + "\lstPrinter.txt"
            Dim pTmpLine As String = ""

            Dim oRead As StreamReader = File.OpenText(pPath)

            Do While oRead.Peek() >= 0
                pTmpLine = oRead.ReadLine().ToUpper
            Loop
            oRead.Close()
            Return pTmpLine.Trim

        Catch ex As Exception
        End Try
        Return ""
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Shared Sub ShowWindowsMenu(ByVal enable As Boolean)
        Try
            If enable Then
                If _taskBar <> IntPtr.Zero Then
                    ' display the start bar
                    SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 480, 36, _
                     CInt(WindowPosition.SWP_SHOWWINDOW))
                End If
            Else
                _taskBar = FindWindowCE("HHTaskBar", Nothing)
                ' Find the handle to the Start Bar
                If _taskBar <> IntPtr.Zero Then
                    ' If the handle is found then hide the start bar
                    ' Hide the start bar
                    SetWindowPos(_taskBar, IntPtr.Zero, 0, 0, 0, 0, _
                     CInt(WindowPosition.SWP_HIDEWINDOW))
                End If
            End If
        Catch err As Exception
            'ErrorWrapper(If(enable, "Show Start", "Hide Start"), err)
        End Try
        Try
            If enable Then
                If _sipButton <> IntPtr.Zero Then
                    ' If the handle is found then hide the start bar
                    ' display the start bar
                    SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 480, 36, _
                     CInt(WindowPosition.SWP_SHOWWINDOW))
                End If
            Else
                _sipButton = FindWindowCE("MS_SIPBUTTON", "MS_SIPBUTTON")
                If _sipButton <> IntPtr.Zero Then
                    ' If the handle is found then hide the start bar
                    ' Hide the start bar
                    SetWindowPos(_sipButton, IntPtr.Zero, 0, 0, 0, 0, _
                     CInt(WindowPosition.SWP_HIDEWINDOW))
                End If
            End If
        Catch err As Exception
            'ErrorWrapper(If(enable, "Show SIP", "Hide SIP"), err)
        End Try
    End Sub

End Class
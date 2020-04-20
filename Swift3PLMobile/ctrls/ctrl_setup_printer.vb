Imports System.IO
Imports System.Text
Imports MobilityScm.Keyboard

Public Class ctrl_setup_printer

    Private Sub btnLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        BTExplorer()
    End Sub

    Sub BTExplorer()

        Try
            Try
                Dim listDevices As String() = bluetooth.ExploreDevices()
                DiscoveredDevices.DataRows.Clear()
                For Each device In listDevices
                    If device.Split("|")(1) = gDeviceAddress Then
                        Me.lbl_DefaultPrinter.Text = device
                    End If
                    Dim strNames(0) As String
                    strNames(0) = "DEVICE_NAME"

                    Dim xmapping As New Resco.Controls.AdvancedList.Mapping(strNames)


                    Dim xrow As Resco.Controls.AdvancedList.Row = Nothing
                    xrow = New Resco.Controls.AdvancedList.Row(1, 2, xmapping)
                    xrow("DEVICE_NAME") = device
                    DiscoveredDevices.DataRows.Add(xrow)
                Next
                Cursor.Current = Cursors.Default
            Catch ex As Exception
                Cursor.Current = Cursors.Default
                Notify("BTExplorer: " + ex.Message, True)
            End Try

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            Notify("BTExplorer: " + ex.Message, True)
        End Try

    End Sub

    Private Sub toolbar_footer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolbar_footer.Click
        Select Case toolbar_footer.SelectedIndex
            Case 0
                BTExplorer()
            Case 1
                Select Case gLastPanelName
                    Case If(Not panelTransHandler Is Nothing, panelTransHandler.Name, "")
                        ShowPanel(panelTransHandler)
                    Case If(Not panelLogin Is Nothing, panelLogin.Name, "")
                        ShowPanel(panelLogin)
                    Case If(Not panelInfo_InvXLic Is Nothing, panelInfo_InvXLic.Name, "")
                        ShowPanel(panelInfo_InvXLic)
                    Case If(Not panelInfoHandler Is Nothing, panelInfoHandler.Name, "")
                        ShowPanel(panelInfoHandler)
                    Case Else
                        ShowPanel(panelLogin)
                End Select

        End Select

    End Sub

    Sub PairBT(ByVal pListIndex As Integer)
        Try
            Dim i As Integer = 0

            'bt_dev.RemoteDevices(0).Pair()
            'bt_dev.RemoteDevices(0).OpenPort()
            'bt_dev.RemoteDevices(0).ClosePort()

        Catch ex As Exception
            Notify("PairBT: " + ex.Message, True)
        End Try

    End Sub

    Sub SendToPrintTest()
        Try
            Dim xprinter As New ZebraPrinter
            xprinter.TestPrinter()

        Catch ex As Exception
            Notify("SendToPrintTest: " + ex.Message, True)
        End Try
    End Sub

    Public Function ToByteArray(ByVal str As String) As Byte()
        Dim encoding As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()
        Return encoding.GetBytes(str)
    End Function

    Private Sub DiscoveredDevices_RowSelect(ByVal sender As Object, ByVal e As Resco.Controls.AdvancedList.RowEventArgs) Handles DiscoveredDevices.RowSelect
        Try
            Dim pValue As String = e.DataRow.StringData(0)
            gDeviceAddress = Mid(pValue, InStr(pValue, "|", CompareMethod.Text) + 1, Len(pValue))
            gDeviceName = Mid(pValue, 1, InStr(pValue, "|", CompareMethod.Text) - 1)
            bluetooth.DeviceName = gDeviceName
            bluetooth.DeviceAddress = gDeviceAddress
            bluetooth.SetupBluetooth()
            MobilityScm.Print.Zebra.PrintModule.bluetooth = bluetooth

        Catch ex As Exception
            Notify("RowSelect: " + ex.Message, True)
        End Try

    End Sub

    Private Sub btnPrintTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintTest.Click
        SendToPrintTest()
    End Sub
    Sub MakeThisDefault()
        Dim pPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).ToString + "\lstPrinter.txt"
        Dim pTmpLine As String = ""

        Try
            Dim streamW As StreamWriter
            Dim fS As FileStream
            If File.Exists(pPath) = False Then
                streamW = File.CreateText(pPath)
                streamW.WriteLine(gDeviceAddress + "                ")
                streamW.Close()
            Else
                fS = File.OpenWrite(pPath)
                Dim info As Byte() = New UTF8Encoding(True).GetBytes(gDeviceAddress + "                ")
                fS.Write(info, 0, info.Length)
                fS.Close()
            End If
            Me.lbl_DefaultPrinter.Text = "Connected to: " + gDeviceAddress
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnMakeDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMakeDefault.Click
        MakeThisDefault()
    End Sub

    Private Sub btnTestThis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestThis.Click
        SendToPrintTest()
    End Sub

    Private Sub DiscoveredDevices_CellClick(ByVal sender As System.Object, ByVal e As Resco.Controls.AdvancedList.CellEventArgs) Handles DiscoveredDevices.CellClick

    End Sub

    Private Sub ctrl_setup_printer_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        UsuarioPresionoBoton(e)

    End Sub
    Private Sub UsuarioPresionoBoton(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
            Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                Select Case gLastPanelName
                    Case If(Not panelTransHandler Is Nothing, panelTransHandler.Name, "")
                        ShowPanel(panelTransHandler)
                    Case If(Not panelLogin Is Nothing, panelLogin.Name, "")
                        ShowPanel(panelLogin)
                    Case If(Not panelInfo_InvXLic Is Nothing, panelInfo_InvXLic.Name, "")
                        ShowPanel(panelInfo_InvXLic)
                    Case If(Not panelInfoHandler Is Nothing, panelInfoHandler.Name, "")
                        ShowPanel(panelInfoHandler)
                    Case Else
                        ShowPanel(panelLogin)
                End Select
        End Select

    End Sub
    Private Sub DiscoveredDevices_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DiscoveredDevices.KeyUp
        UsuarioPresionoBoton(e)
    End Sub

    Private Sub toolbar_footer_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles toolbar_footer.KeyUp
        UsuarioPresionoBoton(e)
    End Sub
End Class


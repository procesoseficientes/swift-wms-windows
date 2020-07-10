Imports System.Configuration
Imports System.IO
Imports System.Reflection
Imports System.ServiceProcess
Imports System.Threading
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip
Imports Microsoft.Win32
Imports MobilityScm.Modelo.Tipos
Imports MobilityScm.Vertical.Entidades
Imports NamedPipeWrapper
Imports WMSOnePlan_Client.OnePlanServices_InfoTrans
Imports WMSOnePlan_Client.OnePlanServices_Security

Module WMS_GlobalModule
    Public detailView As GridView
    Public gLastScreenShowed As String
    Public gLastTabShowed As String
    Public gLabelSize As String = "2X2"
    Public PublicDataSet_RegisteredUsers As DataSet
    Public xfrmRibbon As New RibbonForm1

    Public gIsIntermediate As Boolean = False

    Public ColType As DataColumn
    Public ColText As DataColumn
    Public ColDetail As DataColumn
    Public ColDateTime As DataColumn

    '22-Jun-11 J.R.
    Public ColPedido As DataColumn
    Public ColCliente As DataColumn

    Public MessagesTable As New DataTable
    Public MessagesDataSet As New DataSet

    Public Structure CurrentLogin
        Public LoginID As String
        Public LoginName As String
        Public LoginDateTime As DateTime
        Public LoginType As String
        Public Environment As String
        Public SondaEnvironment As String
        Public GUI As String
        Public Linea As String
        Public LOGO As String
        Public DistributionCenter As String
        public CompanyName as string
        Public ImgLogoDefault as String
        Public Api3PlAddress as String
        Public Domain As String
        Public Password As String
        Public DbUser As String
        Public DbPassword As String
        Public ServerIp As String
        Public DialogoDeCargaAbierto As Boolean 

        Public Function ServerAddress(ByRef pResult As String) As String

            Try
                Dim pUri As String = ConfigurationManager.AppSettings("WSHOST").ToString +
                                     "/Catalogues/WMS_Security.asmx"
                Dim xserv As New WMS_SecuritySoapClient("WMS_SecuritySoap", pUri)

                Dim xdata As DataSet = xserv.GetEnvironmentByKey("OP_WMS", Environment, pResult,
                                                                 PublicLoginInfo.Environment)
                If pResult = "OK" Then
#If DEBUG Then
                    'local
                    WSHost = "http://localhost:8088/WMSOnePlan_BusinessServices"
                    'Cealsa
                    'WSHost = "http://192.168.0.5:9999"
                    'Ferco
                    'WSHost = "http://10.240.29.104:8090"
                    'Arium
                    'WSHost = "http://172.16.20.11:8088"

#End If
#If Not DEBUG Then
                    WSHost = xdata.Tables(0).Rows(0)("WS_HOST").ToString
#End If
                Else
                    WSHost = ""
                    Return pResult
                End If

            Catch ex As Exception
                WSHost = ""
                pResult = ex.Message
                Return "ERROR"
            End Try

            Return ""
        End Function

        Public Function GetSondaWSHOST(ByRef pResult As String) As String

            Try
                Dim pUri As String = ConfigurationManager.AppSettings("WSHOST").ToString +
                                     "/Catalogues/WMS_Security.asmx"
                Dim xserv As New WMS_SecuritySoapClient("WMS_SecuritySoap", pUri)

                Dim xdata As DataSet = xserv.GetEnvironmentByKey("SONDA_SERVER", Environment, pResult,
                                                                 PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    SONDA_WSHost = xdata.Tables(0).Rows(0)("WS_HOST").ToString
                    Return xdata.Tables(0).Rows(0)("WS_HOST").ToString
                Else
                    SONDA_WSHost = ""
                    Return pResult
                End If

            Catch ex As Exception
                SONDA_WSHost = ""
                pResult = ex.Message
                Return "ERROR"
            End Try

            Return ""
        End Function

        Public WSHost As String
        Public SONDA_WSHost As String
        Public AccessLevel As String
        
    End Structure

    Public PublicLoginInfo As CurrentLogin
    Public Bag_CtrlPanel_Class As New CtrlPanel_Class
    Public Bag_Userlogin_Class As New clsUserLogin
    Public Bag_CheckPoint_Class As New clsCheckPoint
    Public Bag_AccessLevel_Class As New clsAccessLevel
    Public Bag_Warehouse_Class As New clsWarehouse
    Public Bag_ShelfSpots_Class As New clsShelfSpots

    Public Bag_Materials_Class As New clsMaterials

    Public Bag_Insurance_Companies As New clsInsuranceCompanies
    Public Bag_Supervisions_Detail As New clsSupervisionsDetail
    'Public Bag_LoginXLoc_Class As New clsLoginXLoc
    Public Bag_Clients_Class As New clsClients
    Public LineBalancing_Class As New clsLineBalancing  '21-Feb-11 J.R. cambios para balanceo de pedidos por linea
    Public Bag_InfoBin_Class As New clsInfoBin  '03-Mar-11 J.R. para agregar consultas de info por BIN y Documento
    Public Bag_InfoDoc_Class As New clsInfoDoc  '03-Mar-11 J.R. para agregar consultas de info por BIN y Documento


    Public Structure Basic_TrasView
        Public lstUsers As String
        Public lstTransTypes As String
        Public objDataGrid As GridControl
        Public pSinceDate As Date
        Public pToDate As Date

        Public Function RefreshGrid(ByRef pResult As String) As String
            Try
                Dim _
                    xserv As _
                        New WMS_InfoTransSoapClient("WMS_InfoTransSoap",
                                                    PublicLoginInfo.WSHost +
                                                    "/Info/wms_InfoTrans.asmx")

                Dim xdata As DataSet = xserv.GetTransBasicView(PublicLoginInfo.LoginID, lstUsers, lstTransTypes,
                                                               pSinceDate, pToDate, pResult, PublicLoginInfo.Environment)
                If pResult = "OK" Then
                    objDataGrid.DataSource = xdata.Tables(0)
                    objDataGrid.Refresh()
                Else
                    MessageBox.Show(pResult, "OnePlan(r) WMS", MessageBoxButtons.OK, MessageBoxIcon.Error,
                                    MessageBoxDefaultButton.Button1)
                    objDataGrid.DataSource = Nothing
                End If
                xserv = Nothing
            Catch ex As Exception
                pResult = ex.Message
                Return "ERROR"
            End Try

            Return ""
        End Function
    End Structure

    Public Structure Basic_TaskView
        Public lstUsers As String
        Public lstTasksTypes As String
        Public objDataGrid As GridControl
        Public pSinceDate As Date
        Public pToDate As Date
        Public pDates As String
        Public pDateFilterType As String
        Public pDemandView As String
        Public pServiceType As String

        Public Function RefreshGrid(ByRef pResult As String) As String
            Try
                Dim _
                    xserv As _
                        New WMS_InfoTransSoapClient("WMS_InfoTransSoap",
                                                    PublicLoginInfo.WSHost +
                                                    "/Info/wms_InfoTrans.asmx")
                Dim xdata As DataSet = Nothing

                Dim pDatesStr = ""
                Select Case pServiceType
                    Case "VIEW_TASK"
                        If pDateFilterType = "BY_CALENDAR" Then
                            xdata = xserv.GetTasksBasicView_Calendar(lstUsers, lstTasksTypes, pDates, pResult,
                                                                     PublicLoginInfo.Environment)
                        Else
                            xdata = xserv.GetTasksBasicView(lstUsers, lstTasksTypes, pSinceDate, pToDate,
                                                            PublicLoginInfo.LoginID, pResult,
                                                            PublicLoginInfo.Environment)
                        End If
                    Case "VIEW_DEMAND"
                        If pDateFilterType = "BY_CALENDAR" Then
                            If pDemandView = "PENDING" Then
                                '29Jun10 J.R. no funcionaba este filtro
                                'xdata = xserv.GetDemandBasicView_Calendar(lstUsers, lstTasksTypes, pDates, pResult, PublicLoginInfo.Environment)
                                xdata = xserv.GetDemandBasicView(lstUsers, lstTasksTypes, pDateFilterType, pSinceDate,
                                                                 pToDate, pDates, pResult, PublicLoginInfo.Environment)

                            ElseIf pDemandView = "VOIDED" Then
                                '24-Feb-11 J.R. para anular pedidos (asignados y por asignar)
                                xdata = xserv.GetDemandVoidedView(pSinceDate, pToDate, pDateFilterType, pDates, pResult,
                                                                  PublicLoginInfo.Environment)

                            Else
                                '29Jun10 J.R. no funcionaba este filtro
                                'xdata = xserv.GetDemandAssignedView_Calendar(pDates, pResult, PublicLoginInfo.Environment)
                                xdata = xserv.GetDemandAssignedView(pSinceDate, pToDate, pDateFilterType, pDates,
                                                                    pResult, PublicLoginInfo.Environment)
                            End If
                        Else
                            If pDemandView = "PENDING" Then
                                xdata = xserv.GetDemandBasicView(lstUsers, lstTasksTypes, pDateFilterType, pSinceDate,
                                                                 pToDate, pDates, pResult, PublicLoginInfo.Environment)
                                If pResult <> "OK" Then
                                    'MessageBox.Show("No hay informacion para el Rango seleccionado " & pResult)
                                    MessageBox.Show("No hay informacion para el Rango seleccionado ", "Swift 3PL",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    'MessageBox.Show(xdata.Tables(0).Rows.Count)
                                End If
                            ElseIf pDemandView = "VOIDED" Then
                                '24-Feb-11 J.R. para anular pedidos (asignados y por asignar)
                                xdata = xserv.GetDemandVoidedView(pSinceDate, pToDate, pDateFilterType, pDates, pResult,
                                                                  PublicLoginInfo.Environment)
                            Else
                                xdata = xserv.GetDemandAssignedView(pSinceDate, pToDate, pDateFilterType, pDates,
                                                                    pResult, PublicLoginInfo.Environment)
                            End If
                        End If

                        '07-Jul-10 J.R. mostrar productos llegando al limite para iniciar replenishment
                    Case "VIEW_REPLENISHMENT"

                        xdata = xserv.GetReplenishmentProdsBasicView(pResult, PublicLoginInfo.Environment)

                        '11-Mar-11 J.R. Reporte de pedidos recibidos vs consolidados
                    Case "VIEW_DOCSREPORT"

                        xdata = xserv.GetDocsReportBasicView(pSinceDate, pToDate, pDateFilterType, pDates, pResult,
                                                             PublicLoginInfo.Environment)

                        '25-Abr-11 J.R. mostrar pedidos pendientes de picking
                    Case "VIEW_PENDINGPICKING"

                        If pDemandView = "PENDPICK" Then
                            '25-Abr-11 J.R. mostrar pedidos pendientes de picking
                            xdata = xserv.GetDemandPendingPickingView(pSinceDate, pToDate, pDateFilterType, pDates,
                                                                      pResult, PublicLoginInfo.Environment)
                        End If

                End Select

                If pResult = "OK" Then
                    objDataGrid.DataSource = xdata.Tables(0)
                    objDataGrid.ForceInitialize()
                    If pServiceType = "VIEW_DEMAND" Then
                        'Dim xcondition As New DevExpress.XtraEditors.StyleFormatConditionBase
                        'xcondition.Value1 = 0
                        'xcondition.Condition = FormatConditionEnum.LessOrEqual
                        'xcondition.Appearance.BackColor = Color.Red
                        'objDataGrid.Views(1).FormatConditions.Add(xcondition)

                    End If
                Else
                    MessageBox.Show("no hay info: " + pResult)
                    objDataGrid.DataSource = Nothing
                End If


                xserv = Nothing
            Catch ex As Exception
                pResult = ex.Message
                Return "ERROR"
            End Try

            Return ""
        End Function
    End Structure

    Sub LoadGridLayout(pGridViewName As String, pUserID As String, ByRef pGridView As GridView)
        Try 'save the layout

            Dim strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString() & "\" &
                          pGridViewName & "_" & pUserID & ".xml"

            If File.Exists(strPath) Then
                pGridView.RestoreLayoutFromXml(strPath)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub NotifyStatus(pMessage As String, ShowInMessageBox As Boolean, isError As Boolean)
        Try
            xfrmRibbon.Static_Message.Caption = pMessage
            If isError Then
                xfrmRibbon.Static_Message.Appearance.BackColor = Color.Red
                xfrmRibbon.Static_Message.Appearance.ForeColor = Color.Black

                Beep()
            Else
                xfrmRibbon.Static_Message.Appearance.BackColor = Color.Transparent
                xfrmRibbon.Static_Message.Appearance.ForeColor = Color.Black
            End If
            If ShowInMessageBox Then

                Dim args As XtraMessageBoxArgs = New XtraMessageBoxArgs()
                args.Caption = "Swift3PL"
                args.Text = pMessage
                args.Buttons = {DialogResult.OK}
                args.Icon =  IIf(isError, System.Drawing.SystemIcons.Error, System.Drawing.SystemIcons.Information)
                args.AutoCloseOptions.ShowTimerOnDefaultButton = True
                args.DefaultButtonIndex = 0
                XtraMessageBox.Show(args)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub SaveGridLayout(pGridViewName As String, pUserID As String, ByRef GridView1 As GridView)
        Try 'save the layout

            Dim strPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString() & "\" &
                          pGridViewName & "_" & pUserID & ".xml"
            GridView1.SaveLayoutToXml(strPath)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub SetLayoutData(Data As String, ByRef gridView1 As GridView)
        If Data Is Nothing OrElse Data.Length = 0 Then Exit Sub

        Dim s As New MemoryStream()
        Dim w As New StreamWriter(s)
        w.AutoFlush = True

        Dim tmpPos As Integer = InStr(Data, "ActiveFilterString") + 20
        Dim tmpData = ""

        tmpData = Mid(Data, tmpPos + 1, Len(Data))
        tmpData = Replace(tmpData, """", "'")

        Data = Mid(Data, 1, tmpPos) + tmpData

        w.Write(Data)
        s.Position = 0
        Try
            gridView1.RestoreLayoutFromStream(s)
        Catch ex As Exception
            Throw New Exception("Wrong data format", ex)
        End Try
    End Sub

    Public Function ConvertStreamToString(pStream As Stream) As String
        Dim xreader As New StreamReader(pStream)
        Return xreader.ReadToEnd
    End Function

    Public Function ConverStringToStream(pString As String, ByRef memoryStream As MemoryStream) As Boolean
        Try
            Dim streamWriter As New StreamWriter(memoryStream)
            streamWriter.Write(pString)
            memoryStream.Position = 0
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function GetTableOfSelectedRows(view As GridView) As DataTable
        Dim resultTable As New DataTable
        If TypeOf view.DataSource Is DataView Then
            Dim sourceTable As DataTable = CType(view.DataSource, DataView).Table
            resultTable = sourceTable.Clone()
            Dim rowHandle As Integer
            For Each rowHandle In view.GetSelectedRows()
                Dim row As DataRow = view.GetDataRow(rowHandle)
                resultTable.Rows.Add(row.ItemArray)
            Next rowHandle
            resultTable.AcceptChanges()
        End If
        Return resultTable
    End Function

    Public Sub LogToFile(strmsg)
        Try
            Dim FILE_NAME As String = ConfigurationManager.AppSettings("LOG_FILE").ToString

            If File.Exists(FILE_NAME) Then

                Dim objWriter As New StreamWriter(FILE_NAME)

                objWriter.WriteLine(strmsg)
                objWriter.Flush()

                objWriter.Close()

            Else

                MessageBox.Show(FILE_NAME + " Does Not Exist")

            End If
        Catch ex As Exception
            MessageBox.Show("LOG.CATCH." + ex.Message)
        End Try
    End Sub

    Public Function AsignarTareasPendientesATodosLosOperadores() As Operacion
        Dim op As New Operacion
        Try
            Dim _
                servicio As _
                    New WMS_InfoTransSoapClient("WMS_InfoTransSoap",
                                                PublicLoginInfo.WSHost +
                                                "/Info/wms_InfoTrans.asmx")
            Dim pResult = ""
            Dim data = servicio.DistribuirTareasATodosLosOperadores(PublicLoginInfo.LoginID, PublicLoginInfo.Environment)

            With op
                .Mensaje = data.Rows(0).Item("Mensaje")
                .Codigo = data.Rows(0).Item("Codigo")
                .Resultado = data.Rows(0).Item("Resultado")
            End With
        Catch ex As Exception
            With op
                .Mensaje = ex.Message
                .Codigo = - 1
                .Resultado = ResultadoOperacionTipo.Error
            End With
        End Try
        Return op
    End Function

    Public Function AsignarTareasPendientesATodosLosOperadoresSinTareas() As Operacion
        Dim op As New Operacion
        Try
            Dim _
                servicio As _
                    New WMS_InfoTransSoapClient("WMS_InfoTransSoap",
                                                PublicLoginInfo.WSHost +
                                                "/Info/wms_InfoTrans.asmx")
            Dim pResult = ""
            Dim data = servicio.DistribuirTareasATodosLosOperadoresSinTareas(PublicLoginInfo.LoginID, pResult,
                                                                             PublicLoginInfo.Environment)

            With op
                .Mensaje = data.Rows(0).Item("Mensaje")
                .Codigo = data.Rows(0).Item("Codigo")
                .Resultado = data.Rows(0).Item("Resultado")
            End With
        Catch ex As Exception
            With op
                .Mensaje = ex.Message
                .Codigo = - 1
                .Resultado = ResultadoOperacionTipo.Error
            End With
        End Try
        Return op
    End Function


    Private _client As NamedPipeClient(Of String)

    Public Function ExistsUpdateEngineService(serviceName As String) As Boolean
        Dim services As ServiceController() = ServiceController.GetServices()
        Dim service = services.FirstOrDefault(Function(s) s.ServiceName = serviceName)
        Return service IsNot Nothing
    End Function

    Private Function GetApplicationBinPath() As String
        Return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
    End Function

    Private Function GetApplicationPath() As String
        Return Assembly.GetExecutingAssembly().Location
    End Function

    Private Function GetRootPath() As String
        Return Directory.GetParent(GetApplicationBinPath()).FullName
    End Function

    Private Function GetUpdateEngineBinPath() As String
        Return Path.Combine(GetRootPath(), "UpdateEngine")
    End Function

    private Function GetManagerBinPath() As String
        Return Path.Combine(GetUpdateEngineBinPath(), "Manager")
    End Function

    Private Function GetUpdatesPath() As String
        Return Path.Combine(GetRootPath(), "Update")
    End Function

    Private Sub ExtractUpdateEngineService(path As String)
        ExtractZipFile(New MemoryStream(My.Resources.mobility_scm_update_engine),
                       String.Empty, path)
    End Sub

    Private Sub InstallUpdateEngineService(serviceName As String, serviceExecutableName As String,
                                           serviceBinPath As String, updateServer As String,
                                           updatePath As String,
                                           serviceInterval As Integer, notificationInterval As Integer,
                                           phaseInterval As Integer)
        Dim updateEngineServicePath As String = Path.Combine(serviceBinPath, serviceExecutableName)

        Dim processStartInfo As New ProcessStartInfo
        processStartInfo.CreateNoWindow = True
        processStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        processStartInfo.FileName = "sc.exe"
        processStartInfo.WorkingDirectory = serviceBinPath
        processStartInfo.Arguments =
            String.Format(
                "create {6} binpath=""\""{0}\"" \""{1}\"" \""{2}\"" \""{3}\"" \""{4}\"" \""{5}\"" \""{7}\"""" start=auto",
                updateEngineServicePath, GetApplicationPath(), updateServer, updatePath, serviceInterval,
                notificationInterval, serviceName, phaseInterval)
        Debug.WriteLine("{0} {1}", processStartInfo.FileName, processStartInfo.Arguments)

        Dim process As New Process()
        process.StartInfo = processStartInfo

        process.Start()
        process.WaitForExit()
    End Sub

    Private Function VerifyUpdateEngineInstallation(updateServer As String, serviceInterval As Integer,
                                                    notificationInterval As Integer, phaseInterval As Integer) _
        As Operacion
        Dim operacion As New Operacion
        Try
            Const serviceName = "MobilityScm.UpdateEngine"
            Const serviceExecutableName = "MobilityScm.UpdateEngine.Service.exe"
            Const managerName = "MobilityScm.UpdateEngine.Manager"
            Const managerExecutableName = "MobilityScm.UpdateEngine.Manager.exe"

            If Not ExistsUpdateEngineService(serviceName) Then
                Dim updateEngineBinPath = GetUpdateEngineBinPath()

                ExtractUpdateEngineService(updateEngineBinPath)

                InstallUpdateEngineService(serviceName, serviceExecutableName, updateEngineBinPath, updateServer,
                                           GetUpdatesPath(),
                                           serviceInterval,
                                           notificationInterval, phaseInterval)
            End If

            Dim managerBinPath as string = GetManagerBinPath()
            SetStartup(managerName, managerBinPath)
            ReLaunch(managerExecutableName, managerBinPath)

            VerifyUpdateEngineStatus(serviceName)
            With operacion
                .Mensaje = "Instalación de servicio de actualizaciones exitoso"
                .Codigo = 0
                .Resultado = ResultadoOperacionTipo.Exito
            End With

        Catch ex As Exception
            With operacion
                .Mensaje = ex.Message
                .Codigo = - 1
                .Resultado = ResultadoOperacionTipo.Error
                .Dato = ex
            End With
        End Try
        Return operacion
    End Function

    Private Sub VerifyUpdateEngineStatus(serviceName As String)
        Using serviceController As New ServiceController(serviceName)
            If serviceController.Status <> ServiceControllerStatus.Running Then
                serviceController.Start()
            End If
        End Using
    End Sub

    Public Sub ExtractZipFile(archiveFilenameIn As String, password As String, outFolder As String)
        Dim fs As FileStream = File.OpenRead(archiveFilenameIn)
        ExtractZipFile(fs, password, outFolder)
    End Sub

    Public Sub ExtractZipFile(inputStream As Stream, password As String, outFolder As String)
        Dim zf As ZipFile = Nothing
        Try
            zf = New ZipFile(inputStream)
            If Not [String].IsNullOrEmpty(password) Then ' AES encrypted entries are handled automatically
                zf.Password = password
            End If

            If (Directory.Exists(outFolder)) Then
                Directory.Delete(outFolder, True)
            End If

            Directory.CreateDirectory(outFolder)

            For Each zipEntry As ZipEntry In zf
                If Not zipEntry.IsFile Then ' Ignore directories
                    Continue For
                End If
                Dim entryFileName As [String] = zipEntry.Name
                ' to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                ' Optionally match entrynames against a selection list here to skip as desired.
                ' The unpacked length is available in the zipEntry.Size property.

                Dim buffer = New Byte(4095) {}  ' 4K is optimum
                Dim zipStream As Stream = zf.GetInputStream(zipEntry)

                ' Manipulate the output filename here as desired.
                Dim fullZipToPath As [String] = Path.Combine(outFolder, entryFileName)
                Dim directoryName As String = Path.GetDirectoryName(fullZipToPath)
                If directoryName.Length > 0 Then
                    Directory.CreateDirectory(directoryName)
                End If

                ' Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                ' of the file, but does not waste memory.
                ' The "Using" will close the stream even if an exception occurs.
                Using streamWriter As FileStream = File.Create(fullZipToPath)
                    StreamUtils.Copy(zipStream, streamWriter, buffer)
                End Using
            Next
        Finally
            If zf IsNot Nothing Then
                zf.IsStreamOwner = True     ' Makes close also shut the underlying stream
                ' Ensure we release resources
                zf.Close()
            End If
        End Try
    End Sub

    Public Sub ConfigureUpdateEngineClient()
        _client = New NamedPipeClient(Of String)("MobilityScm.UpdateEngine")
        _client.Start()
    End Sub

    Public Sub ListenUpdateEngineClient()
        AddHandler _client.ServerMessage, AddressOf UpdateRequired
    End Sub

    Private Sub UpdateRequired(connection As NamedPipeConnection(Of String, String), message As String)
        If XtraMessageBox.Show("La aplicación necesita cerrarse para ser actualizada. ¿Reiniciar ahora?", "Info",
                               MessageBoxButtons.OKCancel) = DialogResult.OK Then
            connection.PushMessage("Yes")
            Thread.Sleep(My.Settings.PhaseInterval/2)
            connection.Close()
            Process.GetCurrentProcess().Kill()
        End If
    End Sub

    Private Sub SetStartup(appName As string, path as String)
        Dim rk As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

        If rk.GetValue(appName) Is nothing
            rk.SetValue(appName, System.IO.Path.Combine(path, appName))
        End If
    End Sub

    Private Sub ReLaunch(executableName As String, executableBinPath As String)
        Dim process As New Process()
        With process.StartInfo
            .WindowStyle = ProcessWindowStyle.Normal
            .FileName = executableName
            .WorkingDirectory = executableBinPath
        end with

        process.Start()
    End Sub
End Module

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventoryAdd
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventoryAdd))
        Me.GrpDetail = New System.Windows.Forms.GroupBox()
        Me.PbrStatus = New System.Windows.Forms.ProgressBar()
        Me.BtnSend = New System.Windows.Forms.Button()
        Me.LblRows = New System.Windows.Forms.Label()
        Me.DgvLoadInventory = New System.Windows.Forms.DataGridView()
        Me.GrpLog = New System.Windows.Forms.GroupBox()
        Me.LstLog = New System.Windows.Forms.ListBox()
        Me.GLCAcuerdo = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLUPoliza = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLUClientes = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GrpHeader = New System.Windows.Forms.GroupBox()
        Me.LblErrorTrans = New System.Windows.Forms.Label()
        Me.BtnDo = New System.Windows.Forms.Button()
        Me.BtnData = New System.Windows.Forms.Button()
        Me.DtaDate = New DevExpress.XtraEditors.DateEdit()
        Me.GLUUBICACIONES = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GLUBodegas = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GrpResp = New System.Windows.Forms.GroupBox()
        Me.LblSaldo = New System.Windows.Forms.Label()
        Me.LblUtilizado = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblCobertura = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PbxResult = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblCliente = New System.Windows.Forms.Label()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.LstR = New System.Windows.Forms.ListBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblLicense = New System.Windows.Forms.Label()
        Me.GPResumen = New System.Windows.Forms.GroupBox()
        Me.LblResumen = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblRegistros = New System.Windows.Forms.Label()
        Me.LblPoliza = New System.Windows.Forms.Label()
        Me.LblLicencia = New System.Windows.Forms.Label()
        Me.GrpDetail.SuspendLayout
        CType(Me.DgvLoadInventory,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GrpLog.SuspendLayout
        CType(Me.GLCAcuerdo.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView5,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GLUPoliza.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GLUClientes.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GrpHeader.SuspendLayout
        CType(Me.DtaDate.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.DtaDate.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GLUUBICACIONES.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GLUBodegas.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GrpResp.SuspendLayout
        CType(Me.PbxResult,System.ComponentModel.ISupportInitialize).BeginInit
        Me.GPResumen.SuspendLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'GrpDetail
        '
        Me.GrpDetail.Controls.Add(Me.PbrStatus)
        Me.GrpDetail.Controls.Add(Me.BtnSend)
        Me.GrpDetail.Controls.Add(Me.LblRows)
        Me.GrpDetail.Controls.Add(Me.DgvLoadInventory)
        Me.GrpDetail.Location = New System.Drawing.Point(719, 207)
        Me.GrpDetail.Name = "GrpDetail"
        Me.GrpDetail.Size = New System.Drawing.Size(32, 41)
        Me.GrpDetail.TabIndex = 3
        Me.GrpDetail.TabStop = false
        Me.GrpDetail.Text = "Detalle"
        Me.GrpDetail.Visible = false
        '
        'PbrStatus
        '
        Me.PbrStatus.Location = New System.Drawing.Point(245, 304)
        Me.PbrStatus.Name = "PbrStatus"
        Me.PbrStatus.Size = New System.Drawing.Size(300, 30)
        Me.PbrStatus.TabIndex = 21
        '
        'BtnSend
        '
        Me.BtnSend.Enabled = false
        Me.BtnSend.Location = New System.Drawing.Point(564, 304)
        Me.BtnSend.Name = "BtnSend"
        Me.BtnSend.Size = New System.Drawing.Size(90, 30)
        Me.BtnSend.TabIndex = 20
        Me.BtnSend.Text = "Enviar"
        Me.BtnSend.UseVisualStyleBackColor = true
        '
        'LblRows
        '
        Me.LblRows.AutoSize = true
        Me.LblRows.Location = New System.Drawing.Point(6, 313)
        Me.LblRows.Name = "LblRows"
        Me.LblRows.Size = New System.Drawing.Size(16, 13)
        Me.LblRows.TabIndex = 1
        Me.LblRows.Text = "..."
        '
        'DgvLoadInventory
        '
        Me.DgvLoadInventory.AllowUserToAddRows = false
        Me.DgvLoadInventory.AllowUserToDeleteRows = false
        Me.DgvLoadInventory.AllowUserToResizeColumns = false
        Me.DgvLoadInventory.AllowUserToResizeRows = false
        Me.DgvLoadInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvLoadInventory.Location = New System.Drawing.Point(18, 19)
        Me.DgvLoadInventory.Name = "DgvLoadInventory"
        Me.DgvLoadInventory.ReadOnly = true
        Me.DgvLoadInventory.Size = New System.Drawing.Size(660, 250)
        Me.DgvLoadInventory.TabIndex = 0
        '
        'GrpLog
        '
        Me.GrpLog.Controls.Add(Me.LstLog)
        Me.GrpLog.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.GrpLog.Location = New System.Drawing.Point(719, 166)
        Me.GrpLog.Name = "GrpLog"
        Me.GrpLog.Size = New System.Drawing.Size(53, 35)
        Me.GrpLog.TabIndex = 24
        Me.GrpLog.TabStop = false
        Me.GrpLog.Text = "Resumen"
        Me.GrpLog.Visible = false
        '
        'LstLog
        '
        Me.LstLog.FormattingEnabled = true
        Me.LstLog.Location = New System.Drawing.Point(25, 28)
        Me.LstLog.Name = "LstLog"
        Me.LstLog.Size = New System.Drawing.Size(660, 238)
        Me.LstLog.TabIndex = 6
        Me.LstLog.Visible = false
        '
        'GLCAcuerdo
        '
        Me.GLCAcuerdo.Location = New System.Drawing.Point(78, 135)
        Me.GLCAcuerdo.Name = "GLCAcuerdo"
        Me.GLCAcuerdo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GLCAcuerdo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GLCAcuerdo.Properties.NullText = ""
        Me.GLCAcuerdo.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.GLCAcuerdo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.GLCAcuerdo.Properties.View = Me.GridView5
        Me.GLCAcuerdo.Size = New System.Drawing.Size(270, 20)
        Me.GLCAcuerdo.TabIndex = 25
        '
        'GridView5
        '
        Me.GridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView5.OptionsView.ShowAutoFilterRow = true
        Me.GridView5.OptionsView.ShowGroupPanel = false
        '
        'GLUPoliza
        '
        Me.GLUPoliza.Location = New System.Drawing.Point(78, 103)
        Me.GLUPoliza.Name = "GLUPoliza"
        Me.GLUPoliza.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GLUPoliza.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GLUPoliza.Properties.NullText = ""
        Me.GLUPoliza.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.GLUPoliza.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.GLUPoliza.Properties.View = Me.GridView4
        Me.GLUPoliza.Size = New System.Drawing.Size(270, 20)
        Me.GLUPoliza.TabIndex = 25
        '
        'GridView4
        '
        Me.GridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView4.OptionsView.ShowAutoFilterRow = true
        Me.GridView4.OptionsView.ShowGroupPanel = false
        '
        'GLUClientes
        '
        Me.GLUClientes.Location = New System.Drawing.Point(78, 18)
        Me.GLUClientes.Name = "GLUClientes"
        Me.GLUClientes.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GLUClientes.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GLUClientes.Properties.NullText = ""
        Me.GLUClientes.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.GLUClientes.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.GLUClientes.Properties.View = Me.GridView2
        Me.GLUClientes.Size = New System.Drawing.Size(270, 20)
        Me.GLUClientes.TabIndex = 22
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView2.OptionsView.ShowAutoFilterRow = true
        Me.GridView2.OptionsView.ShowGroupPanel = false
        '
        'GrpHeader
        '
        Me.GrpHeader.Controls.Add(Me.LblErrorTrans)
        Me.GrpHeader.Controls.Add(Me.BtnDo)
        Me.GrpHeader.Controls.Add(Me.BtnData)
        Me.GrpHeader.Controls.Add(Me.DtaDate)
        Me.GrpHeader.Controls.Add(Me.GLCAcuerdo)
        Me.GrpHeader.Controls.Add(Me.GLUUBICACIONES)
        Me.GrpHeader.Controls.Add(Me.GLUPoliza)
        Me.GrpHeader.Controls.Add(Me.GLUBodegas)
        Me.GrpHeader.Controls.Add(Me.GLUClientes)
        Me.GrpHeader.Controls.Add(Me.Label4)
        Me.GrpHeader.Controls.Add(Me.Label2)
        Me.GrpHeader.Controls.Add(Me.Label1)
        Me.GrpHeader.Controls.Add(Me.GrpResp)
        Me.GrpHeader.Controls.Add(Me.Label10)
        Me.GrpHeader.Controls.Add(Me.Label9)
        Me.GrpHeader.Controls.Add(Me.LblCliente)
        Me.GrpHeader.Controls.Add(Me.BtnUpload)
        Me.GrpHeader.Location = New System.Drawing.Point(7, 32)
        Me.GrpHeader.Name = "GrpHeader"
        Me.GrpHeader.Size = New System.Drawing.Size(515, 228)
        Me.GrpHeader.TabIndex = 2
        Me.GrpHeader.TabStop = false
        Me.GrpHeader.Text = "Datos Generales"
        '
        'LblErrorTrans
        '
        Me.LblErrorTrans.AutoSize = true
        Me.LblErrorTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblErrorTrans.Location = New System.Drawing.Point(168, 196)
        Me.LblErrorTrans.Name = "LblErrorTrans"
        Me.LblErrorTrans.Size = New System.Drawing.Size(152, 20)
        Me.LblErrorTrans.TabIndex = 39
        Me.LblErrorTrans.Text = "Error en transaccion"
        Me.LblErrorTrans.Visible = false
        '
        'BtnDo
        '
        Me.BtnDo.Enabled = false
        Me.BtnDo.Location = New System.Drawing.Point(354, 110)
        Me.BtnDo.Name = "BtnDo"
        Me.BtnDo.Size = New System.Drawing.Size(60, 25)
        Me.BtnDo.TabIndex = 27
        Me.BtnDo.Text = "Procesar"
        Me.BtnDo.UseVisualStyleBackColor = true
        Me.BtnDo.Visible = false
        '
        'BtnData
        '
        Me.BtnData.Enabled = false
        Me.BtnData.Location = New System.Drawing.Point(361, 156)
        Me.BtnData.Name = "BtnData"
        Me.BtnData.Size = New System.Drawing.Size(60, 25)
        Me.BtnData.TabIndex = 26
        Me.BtnData.Text = "Cargar"
        Me.BtnData.UseVisualStyleBackColor = true
        Me.BtnData.Visible = false
        '
        'DtaDate
        '
        Me.DtaDate.EditValue = Nothing
        Me.DtaDate.Location = New System.Drawing.Point(78, 159)
        Me.DtaDate.Name = "DtaDate"
        Me.DtaDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtaDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DtaDate.Properties.Mask.EditMask = "g"
        Me.DtaDate.Size = New System.Drawing.Size(270, 20)
        Me.DtaDate.TabIndex = 22
        '
        'GLUUBICACIONES
        '
        Me.GLUUBICACIONES.Location = New System.Drawing.Point(78, 77)
        Me.GLUUBICACIONES.Name = "GLUUBICACIONES"
        Me.GLUUBICACIONES.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GLUUBICACIONES.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GLUUBICACIONES.Properties.NullText = ""
        Me.GLUUBICACIONES.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.GLUUBICACIONES.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.GLUUBICACIONES.Properties.View = Me.GridView3
        Me.GLUUBICACIONES.Size = New System.Drawing.Size(270, 20)
        Me.GLUUBICACIONES.TabIndex = 24
        '
        'GridView3
        '
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView3.OptionsView.ShowAutoFilterRow = true
        Me.GridView3.OptionsView.ShowGroupPanel = false
        '
        'GLUBodegas
        '
        Me.GLUBodegas.Location = New System.Drawing.Point(78, 44)
        Me.GLUBodegas.Name = "GLUBodegas"
        Me.GLUBodegas.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.GLUBodegas.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.GLUBodegas.Properties.NullText = ""
        Me.GLUBodegas.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.GLUBodegas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.GLUBodegas.Properties.View = Me.GridView1
        Me.GLUBodegas.Size = New System.Drawing.Size(270, 20)
        Me.GLUBodegas.TabIndex = 23
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowGroupPanel = false
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Location = New System.Drawing.Point(15, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(15, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Acuerdo"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(15, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Poliza:"
        '
        'GrpResp
        '
        Me.GrpResp.Controls.Add(Me.LblSaldo)
        Me.GrpResp.Controls.Add(Me.LblUtilizado)
        Me.GrpResp.Controls.Add(Me.Label3)
        Me.GrpResp.Controls.Add(Me.LblCobertura)
        Me.GrpResp.Controls.Add(Me.Label7)
        Me.GrpResp.Controls.Add(Me.Label6)
        Me.GrpResp.Controls.Add(Me.Label5)
        Me.GrpResp.Controls.Add(Me.Label11)
        Me.GrpResp.Controls.Add(Me.PbxResult)
        Me.GrpResp.Location = New System.Drawing.Point(467, 19)
        Me.GrpResp.Name = "GrpResp"
        Me.GrpResp.Size = New System.Drawing.Size(187, 146)
        Me.GrpResp.TabIndex = 9
        Me.GrpResp.TabStop = false
        Me.GrpResp.Visible = false
        '
        'LblSaldo
        '
        Me.LblSaldo.AutoSize = true
        Me.LblSaldo.Location = New System.Drawing.Point(144, 82)
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Size = New System.Drawing.Size(34, 13)
        Me.LblSaldo.TabIndex = 20
        Me.LblSaldo.Text = "00.00"
        Me.LblSaldo.Visible = false
        '
        'LblUtilizado
        '
        Me.LblUtilizado.AutoSize = true
        Me.LblUtilizado.Location = New System.Drawing.Point(144, 63)
        Me.LblUtilizado.Name = "LblUtilizado"
        Me.LblUtilizado.Size = New System.Drawing.Size(34, 13)
        Me.LblUtilizado.TabIndex = 19
        Me.LblUtilizado.Text = "00.00"
        Me.LblUtilizado.Visible = false
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Location = New System.Drawing.Point(68, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Cobertura de Poliza"
        Me.Label3.Visible = false
        '
        'LblCobertura
        '
        Me.LblCobertura.AutoSize = true
        Me.LblCobertura.Location = New System.Drawing.Point(144, 50)
        Me.LblCobertura.Name = "LblCobertura"
        Me.LblCobertura.Size = New System.Drawing.Size(34, 13)
        Me.LblCobertura.TabIndex = 18
        Me.LblCobertura.Text = "00.00"
        Me.LblCobertura.Visible = false
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Location = New System.Drawing.Point(66, 82)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Saldo Actual:"
        Me.Label7.Visible = false
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Location = New System.Drawing.Point(66, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Utilizado:"
        Me.Label6.Visible = false
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Location = New System.Drawing.Point(66, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Corbertura:"
        Me.Label5.Visible = false
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Location = New System.Drawing.Point(85, 103)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 13)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Carga Completa"
        '
        'PbxResult
        '
        Me.PbxResult.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.PbxResult.BackgroundImage = Global.WMSOnePlan_Client.My.Resources.Resources.check
        Me.PbxResult.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PbxResult.InitialImage = CType(resources.GetObject("PbxResult.InitialImage"),System.Drawing.Image)
        Me.PbxResult.Location = New System.Drawing.Point(98, 40)
        Me.PbxResult.Name = "PbxResult"
        Me.PbxResult.Size = New System.Drawing.Size(174, 127)
        Me.PbxResult.TabIndex = 13
        Me.PbxResult.TabStop = false
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Location = New System.Drawing.Point(15, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Ubicacion:"
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Location = New System.Drawing.Point(15, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Bodega:"
        '
        'LblCliente
        '
        Me.LblCliente.AutoSize = true
        Me.LblCliente.Location = New System.Drawing.Point(15, 25)
        Me.LblCliente.Name = "LblCliente"
        Me.LblCliente.Size = New System.Drawing.Size(42, 13)
        Me.LblCliente.TabIndex = 3
        Me.LblCliente.Text = "Cliente:"
        '
        'BtnUpload
        '
        Me.BtnUpload.Enabled = false
        Me.BtnUpload.Location = New System.Drawing.Point(361, 156)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(60, 25)
        Me.BtnUpload.TabIndex = 0
        Me.BtnUpload.Text = "Archivo..."
        Me.BtnUpload.UseVisualStyleBackColor = true
        Me.BtnUpload.Visible = false
        '
        'LstR
        '
        Me.LstR.FormattingEnabled = true
        Me.LstR.Location = New System.Drawing.Point(740, 520)
        Me.LstR.Name = "LstR"
        Me.LstR.Size = New System.Drawing.Size(32, 17)
        Me.LstR.TabIndex = 5
        Me.LstR.Visible = false
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(257, 24)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "Ingreso de Inventario Externo"
        '
        'LblLicense
        '
        Me.LblLicense.AutoSize = true
        Me.LblLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblLicense.Location = New System.Drawing.Point(516, 5)
        Me.LblLicense.Name = "LblLicense"
        Me.LblLicense.Size = New System.Drawing.Size(113, 24)
        Me.LblLicense.TabIndex = 33
        Me.LblLicense.Text = "No. Ingreso:"
        Me.LblLicense.Visible = false
        '
        'GPResumen
        '
        Me.GPResumen.Controls.Add(Me.LblResumen)
        Me.GPResumen.Controls.Add(Me.PictureBox1)
        Me.GPResumen.Controls.Add(Me.LblRegistros)
        Me.GPResumen.Controls.Add(Me.LblPoliza)
        Me.GPResumen.Controls.Add(Me.LblLicencia)
        Me.GPResumen.Location = New System.Drawing.Point(12, 314)
        Me.GPResumen.Name = "GPResumen"
        Me.GPResumen.Size = New System.Drawing.Size(510, 204)
        Me.GPResumen.TabIndex = 34
        Me.GPResumen.TabStop = false
        Me.GPResumen.Text = "Resumen"
        Me.GPResumen.Visible = false
        '
        'LblResumen
        '
        Me.LblResumen.AutoSize = true
        Me.LblResumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblResumen.Location = New System.Drawing.Point(119, 178)
        Me.LblResumen.Name = "LblResumen"
        Me.LblResumen.Size = New System.Drawing.Size(266, 20)
        Me.LblResumen.TabIndex = 38
        Me.LblResumen.Text = "Registros Procesados Exitosamente"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = Global.WMSOnePlan_Client.My.Resources.Resources.check
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"),System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(207, 129)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(108, 46)
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = false
        '
        'LblRegistros
        '
        Me.LblRegistros.AutoSize = true
        Me.LblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblRegistros.Location = New System.Drawing.Point(18, 92)
        Me.LblRegistros.Name = "LblRegistros"
        Me.LblRegistros.Size = New System.Drawing.Size(104, 20)
        Me.LblRegistros.TabIndex = 36
        Me.LblRegistros.Text = "No. Registos:"
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = true
        Me.LblPoliza.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblPoliza.Location = New System.Drawing.Point(18, 63)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(79, 20)
        Me.LblPoliza.TabIndex = 35
        Me.LblPoliza.Text = "No. Poliza"
        '
        'LblLicencia
        '
        Me.LblLicencia.AutoSize = true
        Me.LblLicencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LblLicencia.Location = New System.Drawing.Point(18, 30)
        Me.LblLicencia.Name = "LblLicencia"
        Me.LblLicencia.Size = New System.Drawing.Size(95, 20)
        Me.LblLicencia.TabIndex = 34
        Me.LblLicencia.Text = "No. Licencia"
        '
        'FrmInventoryAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 591)
        Me.Controls.Add(Me.GPResumen)
        Me.Controls.Add(Me.GrpLog)
        Me.Controls.Add(Me.LblLicense)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LstR)
        Me.Controls.Add(Me.GrpDetail)
        Me.Controls.Add(Me.GrpHeader)
        Me.Name = "FrmInventoryAdd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manejo Externo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GrpDetail.ResumeLayout(false)
        Me.GrpDetail.PerformLayout
        CType(Me.DgvLoadInventory,System.ComponentModel.ISupportInitialize).EndInit
        Me.GrpLog.ResumeLayout(false)
        CType(Me.GLCAcuerdo.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView5,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GLUPoliza.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GLUClientes.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView2,System.ComponentModel.ISupportInitialize).EndInit
        Me.GrpHeader.ResumeLayout(false)
        Me.GrpHeader.PerformLayout
        CType(Me.DtaDate.Properties.CalendarTimeProperties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.DtaDate.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GLUUBICACIONES.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GLUBodegas.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.GrpResp.ResumeLayout(false)
        Me.GrpResp.PerformLayout
        CType(Me.PbxResult,System.ComponentModel.ISupportInitialize).EndInit
        Me.GPResumen.ResumeLayout(false)
        Me.GPResumen.PerformLayout
        CType(Me.PictureBox1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GrpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents PbrStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents BtnSend As System.Windows.Forms.Button
    Friend WithEvents LblRows As System.Windows.Forms.Label
    Friend WithEvents DgvLoadInventory As System.Windows.Forms.DataGridView
    Friend WithEvents GrpHeader As System.Windows.Forms.GroupBox
    Friend WithEvents GrpResp As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PbxResult As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LblCliente As System.Windows.Forms.Label
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LstR As System.Windows.Forms.ListBox
    Friend WithEvents LblSaldo As System.Windows.Forms.Label
    Friend WithEvents LblUtilizado As System.Windows.Forms.Label
    Friend WithEvents LblCobertura As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GLUClientes As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLUBodegas As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLUUBICACIONES As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLUPoliza As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GLCAcuerdo As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents DtaDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GrpLog As System.Windows.Forms.GroupBox
    Friend WithEvents LstLog As System.Windows.Forms.ListBox
    Friend WithEvents BtnData As Button
    Friend WithEvents BtnDo As Button
    Friend WithEvents LblLicense As Label
    Friend WithEvents GPResumen As GroupBox
    Friend WithEvents LblResumen As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblRegistros As Label
    Friend WithEvents LblPoliza As Label
    Friend WithEvents LblLicencia As Label
    Friend WithEvents LblErrorTrans As Label
End Class

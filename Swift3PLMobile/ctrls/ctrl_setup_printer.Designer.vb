<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_setup_printer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_setup_printer))
        Me.lbl_DefaultPrinter = New Resco.Controls.CommonControls.TransparentLabel
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.btnPrintTest = New System.Windows.Forms.MenuItem
        Me.btnMakeDefault = New System.Windows.Forms.MenuItem
        Me.toolbar_footer = New Resco.Controls.CommonControls.ToolbarControl
        Me.ToolbarItem4 = New Resco.Controls.CommonControls.ToolbarItem
        Me.ToolbarItem6 = New Resco.Controls.CommonControls.ToolbarItem
        Me.DiscoveredDevices = New Resco.Controls.AdvancedList.AdvancedList
        Me.RowTemplate1 = New Resco.Controls.AdvancedList.RowTemplate
        Me.TextCell1 = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate2 = New Resco.Controls.AdvancedList.RowTemplate
        Me.TextCell2 = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate3 = New Resco.Controls.AdvancedList.RowTemplate
        Me.TextCell3 = New Resco.Controls.AdvancedList.TextCell
        Me.btnTestThis = New System.Windows.Forms.Button
        CType(Me.lbl_DefaultPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_DefaultPrinter
        '
        Me.lbl_DefaultPrinter.AutoSize = False
        Me.lbl_DefaultPrinter.BackColor = System.Drawing.Color.Black
        Me.lbl_DefaultPrinter.BorderColor = System.Drawing.Color.White
        Me.lbl_DefaultPrinter.BorderCornerSize = 5
        Me.lbl_DefaultPrinter.BorderStyle = Resco.Controls.RescoBorderStyle.Rounded
        Me.lbl_DefaultPrinter.ContextMenu = Me.ContextMenu1
        Me.lbl_DefaultPrinter.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lbl_DefaultPrinter.ForeColor = System.Drawing.Color.DarkOrange
        Me.lbl_DefaultPrinter.Location = New System.Drawing.Point(3, 344)
        Me.lbl_DefaultPrinter.Name = "lbl_DefaultPrinter"
        Me.lbl_DefaultPrinter.Size = New System.Drawing.Size(237, 22)
        Me.lbl_DefaultPrinter.Text = "Conectado a:"
        Me.lbl_DefaultPrinter.TextAlignment = Resco.Controls.CommonControls.Alignment.MiddleCenter
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.Add(Me.MenuItem1)
        Me.ContextMenu1.MenuItems.Add(Me.MenuItem2)
        Me.ContextMenu1.MenuItems.Add(Me.btnPrintTest)
        Me.ContextMenu1.MenuItems.Add(Me.btnMakeDefault)
        '
        'MenuItem1
        '
        Me.MenuItem1.Text = "&Pair"
        '
        'MenuItem2
        '
        Me.MenuItem2.Text = "-"
        '
        'btnPrintTest
        '
        Me.btnPrintTest.Text = "Print Test"
        '
        'btnMakeDefault
        '
        Me.btnMakeDefault.Text = "Make this default"
        '
        'toolbar_footer
        '
        Me.toolbar_footer.ArrowsTransparency = CType(140, Byte)
        Me.toolbar_footer.BackgroundImage = CType(resources.GetObject("toolbar_footer.BackgroundImage"), System.Drawing.Bitmap)
        Me.toolbar_footer.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.toolbar_footer.Items.Add(Me.ToolbarItem4)
        Me.toolbar_footer.Items.Add(Me.ToolbarItem6)
        Me.toolbar_footer.Location = New System.Drawing.Point(0, 372)
        Me.toolbar_footer.Name = "toolbar_footer"
        Me.toolbar_footer.Size = New System.Drawing.Size(240, 28)
        Me.toolbar_footer.StretchBackgroundImage = True
        Me.toolbar_footer.TabIndex = 27
        '
        'ToolbarItem4
        '
        Me.ToolbarItem4.BackColor = System.Drawing.Color.Transparent
        Me.ToolbarItem4.CustomSize = New System.Drawing.Size(100, 28)
        Me.ToolbarItem4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolbarItem4.ForeColor = System.Drawing.Color.White
        Me.ToolbarItem4.ImagePressed = CType(resources.GetObject("ToolbarItem4.ImagePressed"), System.Drawing.Bitmap)
        Me.ToolbarItem4.ItemSizeType = Resco.Controls.CommonControls.ToolbarItemSizeType.ByCustomSize
        Me.ToolbarItem4.Name = "ToolbarItem4"
        Me.ToolbarItem4.StretchImage = True
        Me.ToolbarItem4.Text = "Explorar Printers"
        Me.ToolbarItem4.ToolbarItemBehavior = Resco.Controls.CommonControls.ToolbarItemBehaviorType.UnselectAfterClick
        '
        'ToolbarItem6
        '
        Me.ToolbarItem6.BackColor = System.Drawing.Color.Transparent
        Me.ToolbarItem6.CustomSize = New System.Drawing.Size(140, 28)
        Me.ToolbarItem6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolbarItem6.ForeColor = System.Drawing.Color.White
        Me.ToolbarItem6.ImageAlignment = Resco.Controls.CommonControls.Alignment.BottomCenter
        Me.ToolbarItem6.ImagePressed = CType(resources.GetObject("ToolbarItem6.ImagePressed"), System.Drawing.Bitmap)
        Me.ToolbarItem6.ItemSizeType = Resco.Controls.CommonControls.ToolbarItemSizeType.ByCustomSize
        Me.ToolbarItem6.Name = "ToolbarItem6"
        Me.ToolbarItem6.StretchImage = True
        Me.ToolbarItem6.Text = "Salir"
        Me.ToolbarItem6.ToolbarItemBehavior = Resco.Controls.CommonControls.ToolbarItemBehaviorType.UnselectAfterClick
        '
        'DiscoveredDevices
        '
        Me.DiscoveredDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DiscoveredDevices.ContextMenu = Me.ContextMenu1
        Me.DiscoveredDevices.DataRows.Clear()
        Me.DiscoveredDevices.DataRows.Add(New Resco.Controls.AdvancedList.Row(1, 1, -1, -1, New String() {resources.GetString("DiscoveredDevices.DataRows")}))
        Me.DiscoveredDevices.FocusOnClick = True
        Me.DiscoveredDevices.HeaderRow = New Resco.Controls.AdvancedList.HeaderRow(0, New String() {resources.GetString("DiscoveredDevices.HeaderRow")})
        Me.DiscoveredDevices.Location = New System.Drawing.Point(3, 3)
        Me.DiscoveredDevices.Name = "DiscoveredDevices"
        Me.DiscoveredDevices.SelectedTemplateIndex = 3
        Me.DiscoveredDevices.SelectionMode = Resco.Controls.AdvancedList.SelectionMode.SelectDeselect
        Me.DiscoveredDevices.ShowHeader = True
        Me.DiscoveredDevices.Size = New System.Drawing.Size(234, 335)
        Me.DiscoveredDevices.TabIndex = 0
        Me.DiscoveredDevices.TemplateIndex = 1
        Me.DiscoveredDevices.Templates.Add(Me.RowTemplate1)
        Me.DiscoveredDevices.Templates.Add(Me.RowTemplate2)
        Me.DiscoveredDevices.Templates.Add(Me.RowTemplate3)
        Me.DiscoveredDevices.TouchScrolling = True
        '
        'RowTemplate1
        '
        Me.RowTemplate1.BackColor = System.Drawing.Color.SteelBlue
        Me.RowTemplate1.CellTemplates.Add(Me.TextCell1)
        Me.RowTemplate1.ForeColor = System.Drawing.Color.White
        Me.RowTemplate1.Height = 32
        Me.RowTemplate1.Name = "RowTemplate1"
        '
        'TextCell1
        '
        Me.TextCell1.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter
        Me.TextCell1.Border = Resco.Controls.AdvancedList.BorderType.Raised
        Me.TextCell1.CellSource.ConstantData = "Discovered Devices"
        Me.TextCell1.DesignName = "TextCell1"
        Me.TextCell1.Location = New System.Drawing.Point(0, 0)
        Me.TextCell1.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell1.TextFont = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        '
        'RowTemplate2
        '
        Me.RowTemplate2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RowTemplate2.CellTemplates.Add(Me.TextCell2)
        Me.RowTemplate2.ForeColor = System.Drawing.Color.White
        Me.RowTemplate2.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.Black, System.Drawing.Color.DimGray, System.Drawing.Color.DimGray, System.Drawing.Color.Black, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate2.Height = 32
        Me.RowTemplate2.Name = "RowTemplate2"
        '
        'TextCell2
        '
        Me.TextCell2.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter
        Me.TextCell2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextCell2.CellSource.ColumnName = "DEVICE_NAME"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.Location = New System.Drawing.Point(0, 0)
        Me.TextCell2.Selectable = True
        Me.TextCell2.SelectedBackColor = System.Drawing.Color.Transparent
        Me.TextCell2.SelectedForeColor = System.Drawing.Color.DarkOrange
        Me.TextCell2.Size = New System.Drawing.Size(-1, 32)
        '
        'RowTemplate3
        '
        Me.RowTemplate3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RowTemplate3.CellTemplates.Add(Me.TextCell3)
        Me.RowTemplate3.ForeColor = System.Drawing.Color.DarkOrange
        Me.RowTemplate3.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.Black, System.Drawing.Color.DimGray, System.Drawing.Color.DimGray, System.Drawing.Color.Black, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate3.Height = 32
        Me.RowTemplate3.Name = "RowTemplate3"
        '
        'TextCell3
        '
        Me.TextCell3.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter
        Me.TextCell3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextCell3.CellSource.ColumnName = "DEVICE_NAME"
        Me.TextCell3.DesignName = "TextCell3"
        Me.TextCell3.Location = New System.Drawing.Point(0, 0)
        Me.TextCell3.Selectable = True
        Me.TextCell3.SelectedBackColor = System.Drawing.Color.Transparent
        Me.TextCell3.SelectedForeColor = System.Drawing.Color.DarkOrange
        Me.TextCell3.Size = New System.Drawing.Size(-1, 32)
        '
        'btnTestThis
        '
        Me.btnTestThis.Location = New System.Drawing.Point(297, 235)
        Me.btnTestThis.Name = "btnTestThis"
        Me.btnTestThis.Size = New System.Drawing.Size(20, 20)
        Me.btnTestThis.TabIndex = 29
        Me.btnTestThis.Text = "?"
        '
        'ctrl_setup_printer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.btnTestThis)
        Me.Controls.Add(Me.DiscoveredDevices)
        Me.Controls.Add(Me.toolbar_footer)
        Me.Controls.Add(Me.lbl_DefaultPrinter)
        Me.Name = "ctrl_setup_printer"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lbl_DefaultPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_DefaultPrinter As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents toolbar_footer As Resco.Controls.CommonControls.ToolbarControl
    Friend WithEvents ToolbarItem4 As Resco.Controls.CommonControls.ToolbarItem
    Friend WithEvents ToolbarItem6 As Resco.Controls.CommonControls.ToolbarItem
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents btnPrintTest As System.Windows.Forms.MenuItem
    Friend WithEvents btnMakeDefault As System.Windows.Forms.MenuItem
    Friend WithEvents DiscoveredDevices As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents RowTemplate1 As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents TextCell1 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate2 As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate3 As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents TextCell3 As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents btnTestThis As System.Windows.Forms.Button

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Login))
        Me.ToolbarItem4 = New Resco.Controls.CommonControls.ToolbarItem
        Me.ToolbarItem6 = New Resco.Controls.CommonControls.ToolbarItem
        Me.txtPass = New Resco.Controls.CommonControls.TouchTextBox
        Me.ToolbarItem5 = New Resco.Controls.CommonControls.ToolbarItem
        Me.txtUserID = New Resco.Controls.CommonControls.TouchTextBox
        Me.toolbar_footer = New Resco.Controls.CommonControls.ToolbarControl
        Me.lblLicenseTo = New Resco.Controls.CommonControls.TransparentLabel
        Me.LblLastPrinter = New Resco.Controls.CommonControls.TransparentLabel
        Me.lblServer = New Resco.Controls.CommonControls.TransparentLabel
        Me.ImageList1 = New System.Windows.Forms.ImageList
        Me.tblHeader = New Resco.Controls.CommonControls.ToolbarControl
        Me.ToolbarItem2 = New Resco.Controls.CommonControls.ToolbarItem
        CType(Me.lblLicenseTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblLastPrinter, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblServer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolbarItem4
        '
        Me.ToolbarItem4.BackColor = System.Drawing.Color.Transparent
        Me.ToolbarItem4.CustomSize = New System.Drawing.Size(75, 28)
        Me.ToolbarItem4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ToolbarItem4.ForeColor = System.Drawing.Color.White
        Me.ToolbarItem4.ImagePressed = CType(resources.GetObject("ToolbarItem4.ImagePressed"), System.Drawing.Bitmap)
        Me.ToolbarItem4.ItemSizeType = Resco.Controls.CommonControls.ToolbarItemSizeType.ByCustomSize
        Me.ToolbarItem4.Name = "ToolbarItem4"
        Me.ToolbarItem4.StretchImage = True
        Me.ToolbarItem4.Text = "Printers"
        Me.ToolbarItem4.ToolbarItemBehavior = Resco.Controls.CommonControls.ToolbarItemBehaviorType.UnselectAfterClick
        '
        'ToolbarItem6
        '
        Me.ToolbarItem6.BackColor = System.Drawing.Color.Transparent
        Me.ToolbarItem6.CustomSize = New System.Drawing.Size(75, 28)
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
        'txtPass
        '
        Me.txtPass.BorderStyle = Resco.Controls.RescoBorderStyle.Rounded
        Me.txtPass.DefaultText = "Password"
        Me.txtPass.Location = New System.Drawing.Point(6, 175)
        Me.txtPass.MaxLength = 25
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(229, 33)
        Me.txtPass.TabIndex = 1
        '
        'ToolbarItem5
        '
        Me.ToolbarItem5.BackColor = System.Drawing.Color.Transparent
        Me.ToolbarItem5.CustomSize = New System.Drawing.Size(40, 28)
        Me.ToolbarItem5.ForeColor = System.Drawing.Color.White
        Me.ToolbarItem5.ImagePressed = CType(resources.GetObject("ToolbarItem5.ImagePressed"), System.Drawing.Bitmap)
        Me.ToolbarItem5.ItemSizeType = Resco.Controls.CommonControls.ToolbarItemSizeType.ByCustomSize
        Me.ToolbarItem5.Name = "ToolbarItem5"
        Me.ToolbarItem5.ToolbarItemBehavior = Resco.Controls.CommonControls.ToolbarItemBehaviorType.UnselectAfterClick
        '
        'txtUserID
        '
        Me.txtUserID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUserID.BorderStyle = Resco.Controls.RescoBorderStyle.Rounded
        Me.txtUserID.DefaultText = "Usuario"
        Me.txtUserID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtUserID.Location = New System.Drawing.Point(6, 136)
        Me.txtUserID.MaxLength = 25
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(229, 33)
        Me.txtUserID.TabIndex = 0
        Me.txtUserID.Text = "DEMO"
        '
        'toolbar_footer
        '
        Me.toolbar_footer.ArrowsTransparency = CType(140, Byte)
        Me.toolbar_footer.BackgroundImage = CType(resources.GetObject("toolbar_footer.BackgroundImage"), System.Drawing.Bitmap)
        Me.toolbar_footer.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.toolbar_footer.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.toolbar_footer.Items.Add(Me.ToolbarItem4)
        Me.toolbar_footer.Items.Add(Me.ToolbarItem5)
        Me.toolbar_footer.Items.Add(Me.ToolbarItem6)
        Me.toolbar_footer.Location = New System.Drawing.Point(0, 292)
        Me.toolbar_footer.Name = "toolbar_footer"
        Me.toolbar_footer.Size = New System.Drawing.Size(240, 28)
        Me.toolbar_footer.StretchBackgroundImage = True
        Me.toolbar_footer.TabIndex = 13
        '
        'lblLicenseTo
        '
        Me.lblLicenseTo.AutoSize = False
        Me.lblLicenseTo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblLicenseTo.BorderStyle = Resco.Controls.RescoBorderStyle.Rounded
        Me.lblLicenseTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblLicenseTo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblLicenseTo.Location = New System.Drawing.Point(6, 37)
        Me.lblLicenseTo.Name = "lblLicenseTo"
        Me.lblLicenseTo.Size = New System.Drawing.Size(229, 27)
        Me.lblLicenseTo.Text = "Licenciado a: ALSERSA"
        Me.lblLicenseTo.TextAlignment = Resco.Controls.CommonControls.Alignment.MiddleCenter
        '
        'LblLastPrinter
        '
        Me.LblLastPrinter.AutoSize = False
        Me.LblLastPrinter.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.LblLastPrinter.BorderStyle = Resco.Controls.RescoBorderStyle.Rounded
        Me.LblLastPrinter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblLastPrinter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.LblLastPrinter.Location = New System.Drawing.Point(6, 104)
        Me.LblLastPrinter.Name = "LblLastPrinter"
        Me.LblLastPrinter.Size = New System.Drawing.Size(229, 27)
        Me.LblLastPrinter.Text = "..."
        Me.LblLastPrinter.TextAlignment = Resco.Controls.CommonControls.Alignment.MiddleCenter
        '
        'lblServer
        '
        Me.lblServer.AutoSize = False
        Me.lblServer.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblServer.BorderStyle = Resco.Controls.RescoBorderStyle.Rounded
        Me.lblServer.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblServer.Location = New System.Drawing.Point(6, 71)
        Me.lblServer.Name = "lblServer"
        Me.lblServer.Size = New System.Drawing.Size(229, 27)
        Me.lblServer.Text = "Server: 192.168.1.4"
        Me.lblServer.TextAlignment = Resco.Controls.CommonControls.Alignment.MiddleCenter
        Me.ImageList1.Images.Clear()
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Icon))
        '
        'tblHeader
        '
        Me.tblHeader.ArrowsTransparency = CType(140, Byte)
        Me.tblHeader.BackgroundImage = CType(resources.GetObject("tblHeader.BackgroundImage"), System.Drawing.Bitmap)
        Me.tblHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.tblHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.tblHeader.Items.Add(Me.ToolbarItem2)
        Me.tblHeader.Location = New System.Drawing.Point(0, 0)
        Me.tblHeader.Name = "tblHeader"
        Me.tblHeader.Size = New System.Drawing.Size(240, 31)
        Me.tblHeader.StretchBackgroundImage = True
        Me.tblHeader.TabIndex = 1
        '
        'ToolbarItem2
        '
        Me.ToolbarItem2.BackColor = System.Drawing.Color.Transparent
        Me.ToolbarItem2.CustomSize = New System.Drawing.Size(250, 32)
        Me.ToolbarItem2.FocusedFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        Me.ToolbarItem2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ToolbarItem2.ForeColor = System.Drawing.Color.White
        Me.ToolbarItem2.ItemSizeType = Resco.Controls.CommonControls.ToolbarItemSizeType.ByCustomSize
        Me.ToolbarItem2.Name = "ToolbarItem2"
        Me.ToolbarItem2.Text = "..."
        Me.ToolbarItem2.ToolbarItemBehavior = Resco.Controls.CommonControls.ToolbarItemBehaviorType.Separator
        '
        'ctrl_Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tblHeader)
        Me.Controls.Add(Me.LblLastPrinter)
        Me.Controls.Add(Me.lblServer)
        Me.Controls.Add(Me.lblLicenseTo)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.toolbar_footer)
        Me.Name = "ctrl_Login"
        Me.Size = New System.Drawing.Size(240, 320)
        CType(Me.lblLicenseTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblLastPrinter, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblServer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolbarItem4 As Resco.Controls.CommonControls.ToolbarItem
    Friend WithEvents ToolbarItem6 As Resco.Controls.CommonControls.ToolbarItem
    Friend WithEvents txtPass As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents ToolbarItem5 As Resco.Controls.CommonControls.ToolbarItem
    Friend WithEvents txtUserID As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents toolbar_footer As Resco.Controls.CommonControls.ToolbarControl
    Friend WithEvents lblLicenseTo As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents LblLastPrinter As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents lblServer As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tblHeader As Resco.Controls.CommonControls.ToolbarControl
    Friend WithEvents ToolbarItem2 As Resco.Controls.CommonControls.ToolbarItem

End Class

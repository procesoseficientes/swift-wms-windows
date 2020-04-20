<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.DefaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StyleController1 = New DevExpress.XtraEditors.StyleController()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.lblLastUSER = New DevExpress.XtraEditors.LabelControl()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New DevExpress.XtraEditors.LabelControl()
        Me.CheckButton2 = New DevExpress.XtraEditors.CheckButton()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.txtUserID = New DevExpress.XtraEditors.ButtonEdit()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel1.Text = "..."
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.ForeColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.Options.UseForeColor = True
        Me.GroupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.White
        Me.GroupControl1.AppearanceCaption.Options.UseForeColor = True
        Me.GroupControl1.CaptionImage = Global.WMSOnePlan_Client.My.Resources.Resources.group_key
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.ContentImageAlignment = System.Drawing.ContentAlignment.MiddleRight
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.lblLastUSER)
        Me.GroupControl1.Controls.Add(Me.PictureBox1)
        Me.GroupControl1.Controls.Add(Me.lblStatus)
        Me.GroupControl1.Controls.Add(Me.CheckButton2)
        Me.GroupControl1.Controls.Add(Me.txtPwd)
        Me.GroupControl1.Controls.Add(Me.txtUserID)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.LookAndFeel.SkinName = "Darkroom"
        Me.GroupControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(509, 282)
        Me.GroupControl1.TabIndex = 36
        '
        'lblLastUSER
        '
        Me.lblLastUSER.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUSER.Appearance.ForeColor = System.Drawing.Color.Orange
        Me.lblLastUSER.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblLastUSER.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLastUSER.Location = New System.Drawing.Point(139, 127)
        Me.lblLastUSER.Name = "lblLastUSER"
        Me.lblLastUSER.Size = New System.Drawing.Size(222, 17)
        Me.lblLastUSER.TabIndex = 10
        Me.lblLastUSER.Text = "..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.WMSOnePlan_Client.My.Resources.Resources.Darkroom_spotlight
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.LogoCirculoMobility
        Me.PictureBox1.Location = New System.Drawing.Point(231, 58)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.Appearance.BackColor = System.Drawing.Color.Black
        Me.lblStatus.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblStatus.Location = New System.Drawing.Point(2, 264)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(505, 16)
        Me.lblStatus.TabIndex = 6
        '
        'CheckButton2
        '
        Me.CheckButton2.Appearance.ForeColor = System.Drawing.Color.Orange
        Me.CheckButton2.Appearance.Options.UseForeColor = True
        Me.CheckButton2.Image = Global.WMSOnePlan_Client.My.Resources.Resources.door_out
        Me.CheckButton2.Location = New System.Drawing.Point(465, 0)
        Me.CheckButton2.LookAndFeel.SkinName = "Darkroom"
        Me.CheckButton2.Name = "CheckButton2"
        Me.CheckButton2.Size = New System.Drawing.Size(39, 33)
        ToolTipItem1.Text = "&Salir"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.CheckButton2.SuperTip = SuperToolTip1
        Me.CheckButton2.TabIndex = 3
        '
        'txtPwd
        '
        Me.txtPwd.AcceptsReturn = True
        Me.txtPwd.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPwd.ForeColor = System.Drawing.Color.White
        Me.txtPwd.HideSelection = False
        Me.txtPwd.Location = New System.Drawing.Point(139, 150)
        Me.txtPwd.MaxLength = 25
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(222, 21)
        Me.txtPwd.TabIndex = 1
        Me.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPwd.UseSystemPasswordChar = True
        '
        'txtUserID
        '
        Me.txtUserID.EditValue = ""
        Me.txtUserID.Location = New System.Drawing.Point(139, 101)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.txtUserID.Properties.Appearance.Options.UseForeColor = True
        Me.txtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtUserID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtUserID.Properties.LookAndFeel.SkinName = "Darkroom"
        Me.txtUserID.Size = New System.Drawing.Size(222, 20)
        Me.txtUserID.TabIndex = 0
        Me.txtUserID.Visible = False
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Location = New System.Drawing.Point(139, 199)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(222, 37)
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "Login"
        '
        'frmLogin
        '
        Me.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 282)
        Me.Controls.Add(Me.GroupControl1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.LookAndFeel.SkinName = "Darkroom"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Name = "frmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Swift 3PL Login"
        CType(Me.StyleController1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DefaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents txtUserID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents CheckButton2 As DevExpress.XtraEditors.CheckButton
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblStatus As DevExpress.XtraEditors.LabelControl
    Friend WithEvents StyleController1 As DevExpress.XtraEditors.StyleController
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblLastUSER As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class

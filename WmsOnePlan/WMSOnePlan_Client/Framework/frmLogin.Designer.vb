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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DxErrorProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.lblLastUSER = New DevExpress.XtraEditors.LabelControl()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.txtUserID = New DevExpress.XtraEditors.ButtonEdit()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(16, 17)
        Me.ToolStripStatusLabel1.Text = "..."
        '
        'DxErrorProvider1
        '
        Me.DxErrorProvider1.ContainerControl = Me
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Top
        Me.SimpleButton1.Location = New System.Drawing.Point(200, 370)
        Me.SimpleButton1.Margin = New System.Windows.Forms.Padding(6)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(437, 71)
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "Login"
        '
        'lblLastUSER
        '
        Me.lblLastUSER.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastUSER.Appearance.ForeColor = System.Drawing.Color.Orange
        Me.lblLastUSER.Appearance.Options.UseFont = True
        Me.lblLastUSER.Appearance.Options.UseForeColor = True
        Me.lblLastUSER.Appearance.Options.UseTextOptions = True
        Me.lblLastUSER.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblLastUSER.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblLastUSER.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblLastUSER.Location = New System.Drawing.Point(200, 230)
        Me.lblLastUSER.Margin = New System.Windows.Forms.Padding(6)
        Me.lblLastUSER.Name = "lblLastUSER"
        Me.lblLastUSER.Size = New System.Drawing.Size(437, 33)
        Me.lblLastUSER.TabIndex = 10
        Me.lblLastUSER.Text = "..."
        '
        'txtPwd
        '
        Me.txtPwd.AcceptsReturn = True
        Me.txtPwd.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.txtPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPwd.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtPwd.ForeColor = System.Drawing.Color.White
        Me.txtPwd.HideSelection = False
        Me.txtPwd.Location = New System.Drawing.Point(200, 278)
        Me.txtPwd.Margin = New System.Windows.Forms.Padding(6)
        Me.txtPwd.MaxLength = 25
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(437, 33)
        Me.txtPwd.TabIndex = 1
        Me.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtPwd.UseSystemPasswordChar = True
        '
        'txtUserID
        '
        Me.txtUserID.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtUserID.EditValue = ""
        Me.txtUserID.Location = New System.Drawing.Point(200, 192)
        Me.txtUserID.Margin = New System.Windows.Forms.Padding(6)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.txtUserID.Properties.Appearance.Options.UseForeColor = True
        Me.txtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.txtUserID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtUserID.Size = New System.Drawing.Size(437, 38)
        Me.txtUserID.TabIndex = 0
        Me.txtUserID.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.drawable_hdpi_icon
        Me.PictureBox1.Location = New System.Drawing.Point(200, 50)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(437, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(0, 464)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(837, 47)
        Me.lblStatus.TabIndex = 14
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(200, 161)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(437, 31)
        Me.Panel1.TabIndex = 15
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(200, 263)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(437, 15)
        Me.Panel2.TabIndex = 16
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(200, 311)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(437, 59)
        Me.Panel3.TabIndex = 17
        '
        'frmLogin
        '
        Me.Appearance.Options.UseBackColor = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 511)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblLastUSER)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.PictureBox1)
        Me.DoubleBuffered = True
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.Icon = CType(resources.GetObject("frmLogin.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = CType(resources.GetObject("frmLogin.IconOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.LookAndFeel.SkinName = "DevExpress Dark Style"
        Me.LookAndFeel.UseDefaultLookAndFeel = False
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.Padding = New System.Windows.Forms.Padding(200, 50, 200, 0)
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WMS Login"
        CType(Me.DxErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents txtUserID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtPwd As System.Windows.Forms.TextBox
    Friend WithEvents DxErrorProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents lblLastUSER As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
End Class

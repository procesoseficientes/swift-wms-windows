<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangePassword
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.chkShowPass = New DevExpress.XtraEditors.CheckEdit
        Me.txtPass2 = New DevExpress.XtraEditors.TextEdit
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.txtPass1 = New DevExpress.XtraEditors.TextEdit
        Me.lblUserName = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.lblUserID = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.chkShowPass.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPass1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.chkShowPass)
        Me.GroupControl1.Controls.Add(Me.txtPass2)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.txtPass1)
        Me.GroupControl1.Controls.Add(Me.lblUserName)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.lblUserID)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(284, 262)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Cambiar Password"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(127, 228)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(145, 23)
        Me.SimpleButton2.TabIndex = 4
        Me.SimpleButton2.Text = "&Salir"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(127, 199)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(145, 23)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "Cambiar Password"
        '
        'chkShowPass
        '
        Me.chkShowPass.Location = New System.Drawing.Point(125, 150)
        Me.chkShowPass.Name = "chkShowPass"
        Me.chkShowPass.Properties.Caption = "Mostrar Password"
        Me.chkShowPass.Size = New System.Drawing.Size(147, 18)
        Me.chkShowPass.TabIndex = 2
        '
        'txtPass2
        '
        Me.txtPass2.EnterMoveNextControl = True
        Me.txtPass2.Location = New System.Drawing.Point(125, 124)
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtPass2.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass2.Size = New System.Drawing.Size(147, 20)
        Me.txtPass2.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(24, 127)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(88, 13)
        Me.LabelControl3.TabIndex = 5
        Me.LabelControl3.Text = "Repetir Password:"
        '
        'txtPass1
        '
        Me.txtPass1.EnterMoveNextControl = True
        Me.txtPass1.Location = New System.Drawing.Point(125, 98)
        Me.txtPass1.Name = "txtPass1"
        Me.txtPass1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtPass1.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass1.Size = New System.Drawing.Size(147, 20)
        Me.txtPass1.TabIndex = 0
        '
        'lblUserName
        '
        Me.lblUserName.Location = New System.Drawing.Point(125, 66)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(12, 13)
        Me.lblUserName.TabIndex = 3
        Me.lblUserName.Text = "..."
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(24, 101)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Nuevo Password:"
        '
        'lblUserID
        '
        Me.lblUserID.Location = New System.Drawing.Point(125, 47)
        Me.lblUserID.Name = "lblUserID"
        Me.lblUserID.Size = New System.Drawing.Size(12, 13)
        Me.lblUserID.TabIndex = 1
        Me.lblUserID.Text = "..."
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(24, 47)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(40, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Usuario:"
        '
        'frmChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmChangePassword"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de Password"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.chkShowPass.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPass1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkShowPass As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txtPass2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPass1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblUserName As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblUserID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class

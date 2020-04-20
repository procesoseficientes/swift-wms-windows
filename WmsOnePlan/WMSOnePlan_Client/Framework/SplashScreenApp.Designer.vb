<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreenApp
    Inherits DevExpress.XtraSplashScreen.SplashScreen

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
        Me.Copyright = New DevExpress.XtraEditors.LabelControl()
        Me.progressBarControl = New DevExpress.XtraEditors.MarqueeProgressBarControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.version = New DevExpress.XtraEditors.LabelControl()
        CType(Me.progressBarControl.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Copyright
        '
        Me.Copyright.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.Copyright.Location = New System.Drawing.Point(23, 286)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(47, 13)
        Me.Copyright.TabIndex = 11
        Me.Copyright.Text = "Copyright"
        '
        'progressBarControl
        '
        Me.progressBarControl.EditValue = 0
        Me.progressBarControl.Location = New System.Drawing.Point(12, 159)
        Me.progressBarControl.Name = "progressBarControl"
        Me.progressBarControl.Size = New System.Drawing.Size(476, 12)
        Me.progressBarControl.TabIndex = 10
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 48!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Appearance.Options.UseBackColor = true
        Me.LabelControl1.Appearance.Options.UseFont = true
        Me.LabelControl1.Appearance.Options.UseForeColor = true
        Me.LabelControl1.Location = New System.Drawing.Point(139, 56)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(243, 78)
        Me.LabelControl1.TabIndex = 15
        Me.LabelControl1.Text = "Swift 3PL"
        Me.LabelControl1.UseWaitCursor = true
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.LabelControl2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl2.Appearance.Options.UseBackColor = true
        Me.LabelControl2.Appearance.Options.UseFont = true
        Me.LabelControl2.Appearance.Options.UseForeColor = true
        Me.LabelControl2.Appearance.Options.UseTextOptions = true
        Me.LabelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl2.Location = New System.Drawing.Point(-1, 224)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(494, 29)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "Mobility SCM."
        Me.LabelControl2.UseWaitCursor = true
        '
        'version
        '
        Me.version.Appearance.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.version.Appearance.ForeColor = System.Drawing.Color.Orange
        Me.version.Appearance.Options.UseFont = true
        Me.version.Appearance.Options.UseForeColor = true
        Me.version.Location = New System.Drawing.Point(169, 177)
        Me.version.Name = "version"
        Me.version.Size = New System.Drawing.Size(143, 23)
        Me.version.TabIndex = 17
        Me.version.Text = "Version {0}.{1:00}"
        Me.version.UseWaitCursor = true
        '
        'SplashScreenApp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 326)
        Me.Controls.Add(Me.version)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.progressBarControl)
        Me.Name = "SplashScreenApp"
        Me.Text = "Form1"
        CType(Me.progressBarControl.Properties,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents Copyright As DevExpress.XtraEditors.LabelControl
    Private WithEvents progressBarControl As DevExpress.XtraEditors.MarqueeProgressBarControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents version As DevExpress.XtraEditors.LabelControl
End Class

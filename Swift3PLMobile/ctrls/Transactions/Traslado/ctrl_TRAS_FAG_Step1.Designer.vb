<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_TRAS_FAG_Step1
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
        Me.LBL_LICENSE = New Resco.Controls.CommonControls.TransparentLabel
        Me.lblTitle = New Resco.Controls.CommonControls.TransparentLabel
        CType(Me.LBL_LICENSE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBL_LICENSE
        '
        Me.LBL_LICENSE.AutoSize = False
        Me.LBL_LICENSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBL_LICENSE.BorderColor = System.Drawing.Color.Goldenrod
        Me.LBL_LICENSE.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle
        Me.LBL_LICENSE.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_LICENSE.ForeColor = System.Drawing.Color.White
        Me.LBL_LICENSE.Location = New System.Drawing.Point(-3, 25)
        Me.LBL_LICENSE.Name = "LBL_LICENSE"
        Me.LBL_LICENSE.Size = New System.Drawing.Size(243, 27)
        Me.LBL_LICENSE.Text = "..."
        Me.LBL_LICENSE.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.BackColor = System.Drawing.Color.Gold
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 23)
        Me.lblTitle.Text = "..."
        Me.lblTitle.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        '
        'ctrl_TRAS_FAG_Step1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.LBL_LICENSE)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "ctrl_TRAS_FAG_Step1"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.LBL_LICENSE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LBL_LICENSE As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents lblTitle As Resco.Controls.CommonControls.TransparentLabel

End Class

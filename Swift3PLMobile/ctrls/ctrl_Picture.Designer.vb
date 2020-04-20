<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_Picture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_Picture))
        Me.PictureBox_1 = New System.Windows.Forms.PictureBox
        Me.lblStatus = New Resco.Controls.CommonControls.TransparentLabel
        Me.btnIngreso = New Resco.Controls.CommonControls.TouchRadioButton
        Me.btnEgreso = New Resco.Controls.CommonControls.TouchRadioButton
        Me.lblScanPrompt = New System.Windows.Forms.Label
        Me.lblScannedPolicy = New System.Windows.Forms.Label
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox_1
        '
        Me.PictureBox_1.BackColor = System.Drawing.Color.White
        Me.PictureBox_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox_1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox_1.Name = "PictureBox_1"
        Me.PictureBox_1.Size = New System.Drawing.Size(240, 400)
        Me.PictureBox_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblStatus.BorderColor = System.Drawing.Color.Goldenrod
        Me.lblStatus.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular)
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(0, 376)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(240, 21)
        Me.lblStatus.Text = "..."
        Me.lblStatus.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        '
        'btnIngreso
        '
        Me.btnIngreso.BoxColor = System.Drawing.Color.Transparent
        Me.btnIngreso.Checked = True
        Me.btnIngreso.CheckedImage = CType(resources.GetObject("btnIngreso.CheckedImage"), System.Drawing.Image)
        Me.btnIngreso.CheckState = System.Windows.Forms.CheckState.Checked
        Me.btnIngreso.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.btnIngreso.Group = "PICTURE_TAG"
        Me.btnIngreso.Location = New System.Drawing.Point(4, 350)
        Me.btnIngreso.Name = "btnIngreso"
        Me.btnIngreso.Size = New System.Drawing.Size(87, 20)
        Me.btnIngreso.TabIndex = 2
        Me.btnIngreso.Text = "Ingreso"
        Me.btnIngreso.Visible = False
        '
        'btnEgreso
        '
        Me.btnEgreso.BoxColor = System.Drawing.Color.Transparent
        Me.btnEgreso.CheckedImage = CType(resources.GetObject("btnEgreso.CheckedImage"), System.Drawing.Image)
        Me.btnEgreso.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.btnEgreso.Group = "PICTURE_TAG"
        Me.btnEgreso.Location = New System.Drawing.Point(153, 350)
        Me.btnEgreso.Name = "btnEgreso"
        Me.btnEgreso.Size = New System.Drawing.Size(87, 20)
        Me.btnEgreso.TabIndex = 3
        Me.btnEgreso.Text = "Egreso"
        Me.btnEgreso.Visible = False
        '
        'lblScanPrompt
        '
        Me.lblScanPrompt.BackColor = System.Drawing.Color.Transparent
        Me.lblScanPrompt.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblScanPrompt.Location = New System.Drawing.Point(4, 2)
        Me.lblScanPrompt.Name = "lblScanPrompt"
        Me.lblScanPrompt.Size = New System.Drawing.Size(150, 21)
        Me.lblScanPrompt.Text = "Escanear Poliza:"
        '
        'lblScannedPolicy
        '
        Me.lblScannedPolicy.BackColor = System.Drawing.Color.Transparent
        Me.lblScannedPolicy.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblScannedPolicy.Location = New System.Drawing.Point(4, 34)
        Me.lblScannedPolicy.Name = "lblScannedPolicy"
        Me.lblScannedPolicy.Size = New System.Drawing.Size(233, 21)
        Me.lblScannedPolicy.Text = "..."
        Me.lblScannedPolicy.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'ctrl_Picture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblScannedPolicy)
        Me.Controls.Add(Me.lblScanPrompt)
        Me.Controls.Add(Me.btnEgreso)
        Me.Controls.Add(Me.btnIngreso)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.PictureBox_1)
        Me.Name = "ctrl_Picture"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lblStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox_1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents btnIngreso As Resco.Controls.CommonControls.TouchRadioButton
    Friend WithEvents btnEgreso As Resco.Controls.CommonControls.TouchRadioButton
    Friend WithEvents lblScanPrompt As System.Windows.Forms.Label
    Friend WithEvents lblScannedPolicy As System.Windows.Forms.Label

End Class

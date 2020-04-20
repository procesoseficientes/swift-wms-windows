<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_RecepFiscal
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
        Me.lblTitle = New Resco.Controls.CommonControls.TransparentLabel
        Me.LBL_001_001 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LBL_CONTAINER = New Resco.Controls.CommonControls.TransparentLabel
        Me.LBL_CUSTOMER = New Resco.Controls.CommonControls.TransparentLabel
        Me.btnStart = New Resco.Controls.OutlookControls.ImageButton
        Me.btnViewImages = New Resco.Controls.OutlookControls.ImageButton
        Me.LBL_WH_REGIMEN = New Resco.Controls.CommonControls.TransparentLabel
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_CONTAINER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_CUSTOMER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnViewImages, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_WH_REGIMEN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'LBL_001_001
        '
        Me.LBL_001_001.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBL_001_001.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_001_001.ForeColor = System.Drawing.Color.White
        Me.LBL_001_001.Location = New System.Drawing.Point(0, 26)
        Me.LBL_001_001.Name = "LBL_001_001"
        Me.LBL_001_001.Size = New System.Drawing.Size(240, 25)
        Me.LBL_001_001.Text = "Escanear poliza:"
        Me.LBL_001_001.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Gray
        Me.Label6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        Me.Label6.Location = New System.Drawing.Point(29, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(282, 20)
        Me.Label6.Text = "Fotografias(0)"
        '
        'LBL_CONTAINER
        '
        Me.LBL_CONTAINER.AutoSize = False
        Me.LBL_CONTAINER.BackColor = System.Drawing.Color.White
        Me.LBL_CONTAINER.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_CONTAINER.Location = New System.Drawing.Point(0, 106)
        Me.LBL_CONTAINER.Name = "LBL_CONTAINER"
        Me.LBL_CONTAINER.Size = New System.Drawing.Size(240, 20)
        Me.LBL_CONTAINER.Text = "..."
        Me.LBL_CONTAINER.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        Me.LBL_CONTAINER.Visible = False
        '
        'LBL_CUSTOMER
        '
        Me.LBL_CUSTOMER.AutoSize = False
        Me.LBL_CUSTOMER.BackColor = System.Drawing.Color.White
        Me.LBL_CUSTOMER.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_CUSTOMER.Location = New System.Drawing.Point(0, 53)
        Me.LBL_CUSTOMER.Name = "LBL_CUSTOMER"
        Me.LBL_CUSTOMER.Size = New System.Drawing.Size(240, 51)
        Me.LBL_CUSTOMER.Text = "..."
        Me.LBL_CUSTOMER.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        Me.LBL_CUSTOMER.Visible = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.Black
        Me.btnStart.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnStart.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.btnStart.ForeColor = System.Drawing.Color.White
        Me.btnStart.Location = New System.Drawing.Point(120, 292)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.PressedBackColor = System.Drawing.Color.Gold
        Me.btnStart.PressedForeColor = System.Drawing.Color.White
        Me.btnStart.Size = New System.Drawing.Size(120, 108)
        Me.btnStart.TabIndex = 14
        Me.btnStart.Text = "Iniciar ingreso a bodega"
        Me.btnStart.Visible = False
        Me.btnStart.WordWrap = True
        '
        'btnViewImages
        '
        Me.btnViewImages.BackColor = System.Drawing.Color.Black
        Me.btnViewImages.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnViewImages.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.btnViewImages.ForeColor = System.Drawing.Color.White
        Me.btnViewImages.Location = New System.Drawing.Point(-1, 292)
        Me.btnViewImages.Name = "btnViewImages"
        Me.btnViewImages.PressedBackColor = System.Drawing.Color.Gold
        Me.btnViewImages.PressedForeColor = System.Drawing.Color.White
        Me.btnViewImages.Size = New System.Drawing.Size(120, 108)
        Me.btnViewImages.TabIndex = 13
        Me.btnViewImages.Text = "..."
        Me.btnViewImages.Visible = False
        Me.btnViewImages.WordWrap = True
        '
        'LBL_WH_REGIMEN
        '
        Me.LBL_WH_REGIMEN.AutoSize = False
        Me.LBL_WH_REGIMEN.BackColor = System.Drawing.Color.White
        Me.LBL_WH_REGIMEN.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_WH_REGIMEN.Location = New System.Drawing.Point(-1, 128)
        Me.LBL_WH_REGIMEN.Name = "LBL_WH_REGIMEN"
        Me.LBL_WH_REGIMEN.Size = New System.Drawing.Size(241, 20)
        Me.LBL_WH_REGIMEN.Text = "..."
        Me.LBL_WH_REGIMEN.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        Me.LBL_WH_REGIMEN.Visible = False
        '
        'ctrl_RecepFiscal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.LBL_WH_REGIMEN)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnViewImages)
        Me.Controls.Add(Me.LBL_CONTAINER)
        Me.Controls.Add(Me.LBL_CUSTOMER)
        Me.Controls.Add(Me.LBL_001_001)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "ctrl_RecepFiscal"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_CONTAINER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_CUSTOMER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnViewImages, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_WH_REGIMEN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents LBL_001_001 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LBL_CONTAINER As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents LBL_CUSTOMER As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents btnStart As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents btnViewImages As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents LBL_WH_REGIMEN As Resco.Controls.CommonControls.TransparentLabel

End Class

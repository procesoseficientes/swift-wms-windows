<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_traslado_a_general
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
        Me.LBL_CONTAINER = New Resco.Controls.CommonControls.TransparentLabel
        Me.LBL_CUSTOMER = New Resco.Controls.CommonControls.TransparentLabel
        Me.LBL_001_001 = New System.Windows.Forms.Label
        Me.btnReception = New Resco.Controls.OutlookControls.ImageButton
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_CONTAINER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_CUSTOMER, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnReception, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'LBL_CONTAINER
        '
        Me.LBL_CONTAINER.AutoSize = False
        Me.LBL_CONTAINER.BackColor = System.Drawing.Color.White
        Me.LBL_CONTAINER.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_CONTAINER.Location = New System.Drawing.Point(0, 109)
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
        Me.LBL_CUSTOMER.Location = New System.Drawing.Point(0, 60)
        Me.LBL_CUSTOMER.Name = "LBL_CUSTOMER"
        Me.LBL_CUSTOMER.Size = New System.Drawing.Size(240, 48)
        Me.LBL_CUSTOMER.Text = "..."
        Me.LBL_CUSTOMER.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        Me.LBL_CUSTOMER.Visible = False
        '
        'LBL_001_001
        '
        Me.LBL_001_001.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBL_001_001.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_001_001.ForeColor = System.Drawing.Color.White
        Me.LBL_001_001.Location = New System.Drawing.Point(0, 26)
        Me.LBL_001_001.Name = "LBL_001_001"
        Me.LBL_001_001.Size = New System.Drawing.Size(240, 32)
        Me.LBL_001_001.Text = "Escanear poliza:"
        Me.LBL_001_001.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnReception
        '
        Me.btnReception.BackColor = System.Drawing.Color.Black
        Me.btnReception.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnReception.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular)
        Me.btnReception.ForeColor = System.Drawing.Color.White
        Me.btnReception.Location = New System.Drawing.Point(51, 204)
        Me.btnReception.Name = "btnReception"
        Me.btnReception.PressedBackColor = System.Drawing.Color.Gold
        Me.btnReception.PressedForeColor = System.Drawing.Color.White
        Me.btnReception.Size = New System.Drawing.Size(135, 122)
        Me.btnReception.TabIndex = 15
        Me.btnReception.Text = "Iniciar traslado a general"
        Me.btnReception.Visible = False
        Me.btnReception.WordWrap = True
        '
        'ctrl_traslado_a_general
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.btnReception)
        Me.Controls.Add(Me.LBL_CONTAINER)
        Me.Controls.Add(Me.LBL_CUSTOMER)
        Me.Controls.Add(Me.LBL_001_001)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "ctrl_traslado_a_general"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_CONTAINER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_CUSTOMER, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnReception, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents LBL_CONTAINER As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents LBL_CUSTOMER As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents LBL_001_001 As System.Windows.Forms.Label
    Friend WithEvents btnReception As Resco.Controls.OutlookControls.ImageButton

End Class

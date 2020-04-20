<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_RECFIS_Step1
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
        Me.btnGen_Print_licence = New Resco.Controls.OutlookControls.ImageButton
        Me.btnRePrintLicense = New Resco.Controls.OutlookControls.ImageButton
        Me.Panel_SKU = New System.Windows.Forms.Panel
        Me.txtSKU_Desc = New Resco.Controls.CommonControls.TouchTextBox
        Me.txtQTY = New Resco.Controls.CommonControls.TouchTextBox
        Me.TransparentLabel3 = New Resco.Controls.CommonControls.TransparentLabel
        Me.lblSKU = New Resco.Controls.CommonControls.TransparentLabel
        Me.btnRecords = New Resco.Controls.OutlookControls.ImageButton
        Me.btnCamara = New Resco.Controls.OutlookControls.ImageButton
        Me.LBL_LICENSE = New Resco.Controls.CommonControls.TransparentLabel
        Me.cmbCommercialAggrements = New Resco.Controls.AdvancedComboBox.TouchComboBox
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnGen_Print_licence, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRePrintLicense, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_SKU.SuspendLayout()
        CType(Me.TransparentLabel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSKU, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRecords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCamara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_LICENSE, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'btnGen_Print_licence
        '
        Me.btnGen_Print_licence.BackColor = System.Drawing.Color.Black
        Me.btnGen_Print_licence.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnGen_Print_licence.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnGen_Print_licence.ForeColor = System.Drawing.Color.White
        Me.btnGen_Print_licence.Location = New System.Drawing.Point(-1, 323)
        Me.btnGen_Print_licence.Name = "btnGen_Print_licence"
        Me.btnGen_Print_licence.PressedBackColor = System.Drawing.Color.Gold
        Me.btnGen_Print_licence.PressedForeColor = System.Drawing.Color.White
        Me.btnGen_Print_licence.Size = New System.Drawing.Size(61, 74)
        Me.btnGen_Print_licence.TabIndex = 14
        Me.btnGen_Print_licence.Text = "Generar licencia"
        Me.btnGen_Print_licence.WordWrap = True
        '
        'btnRePrintLicense
        '
        Me.btnRePrintLicense.BackColor = System.Drawing.Color.Black
        Me.btnRePrintLicense.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnRePrintLicense.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnRePrintLicense.ForeColor = System.Drawing.Color.White
        Me.btnRePrintLicense.Location = New System.Drawing.Point(117, 323)
        Me.btnRePrintLicense.Name = "btnRePrintLicense"
        Me.btnRePrintLicense.PressedBackColor = System.Drawing.Color.Gold
        Me.btnRePrintLicense.PressedForeColor = System.Drawing.Color.White
        Me.btnRePrintLicense.Size = New System.Drawing.Size(61, 74)
        Me.btnRePrintLicense.TabIndex = 16
        Me.btnRePrintLicense.Text = "Reimprimir licencia"
        Me.btnRePrintLicense.WordWrap = True
        '
        'Panel_SKU
        '
        Me.Panel_SKU.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel_SKU.Controls.Add(Me.txtSKU_Desc)
        Me.Panel_SKU.Controls.Add(Me.txtQTY)
        Me.Panel_SKU.Controls.Add(Me.TransparentLabel3)
        Me.Panel_SKU.Controls.Add(Me.lblSKU)
        Me.Panel_SKU.Location = New System.Drawing.Point(3, 88)
        Me.Panel_SKU.Name = "Panel_SKU"
        Me.Panel_SKU.Size = New System.Drawing.Size(236, 122)
        Me.Panel_SKU.Visible = False
        '
        'txtSKU_Desc
        '
        Me.txtSKU_Desc.AcceptsReturn = False
        Me.txtSKU_Desc.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSKU_Desc.BorderColor = System.Drawing.Color.Goldenrod
        Me.txtSKU_Desc.BorderSize = 2
        Me.txtSKU_Desc.CharacterCasing = Resco.Controls.CommonControls.TouchTextBoxCharacterCasing.Upper
        Me.txtSKU_Desc.DefaultText = "Comentarios"
        Me.txtSKU_Desc.DisabledForeColor = System.Drawing.SystemColors.Control
        Me.txtSKU_Desc.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtSKU_Desc.ForeColor = System.Drawing.Color.White
        Me.txtSKU_Desc.Location = New System.Drawing.Point(0, 33)
        Me.txtSKU_Desc.Multiline = True
        Me.txtSKU_Desc.Name = "txtSKU_Desc"
        Me.txtSKU_Desc.ReadOnly = True
        Me.txtSKU_Desc.Size = New System.Drawing.Size(236, 47)
        Me.txtSKU_Desc.TabIndex = 31
        Me.txtSKU_Desc.Text = "..."
        '
        'txtQTY
        '
        Me.txtQTY.BackColor = System.Drawing.Color.White
        Me.txtQTY.BorderColor = System.Drawing.Color.Goldenrod
        Me.txtQTY.BorderSize = 2
        Me.txtQTY.DisabledForeColor = System.Drawing.SystemColors.Control
        Me.txtQTY.Enabled = False
        Me.txtQTY.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtQTY.Location = New System.Drawing.Point(130, 86)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(86, 29)
        Me.txtQTY.TabIndex = 26
        Me.txtQTY.Text = "1"
        Me.txtQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TransparentLabel3
        '
        Me.TransparentLabel3.AutoSize = False
        Me.TransparentLabel3.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.TransparentLabel3.ForeColor = System.Drawing.Color.White
        Me.TransparentLabel3.Location = New System.Drawing.Point(3, 86)
        Me.TransparentLabel3.Name = "TransparentLabel3"
        Me.TransparentLabel3.Size = New System.Drawing.Size(89, 20)
        Me.TransparentLabel3.Text = "Cantidad:"
        '
        'lblSKU
        '
        Me.lblSKU.AutoSize = False
        Me.lblSKU.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblSKU.ForeColor = System.Drawing.Color.White
        Me.lblSKU.Location = New System.Drawing.Point(-10, 2)
        Me.lblSKU.Name = "lblSKU"
        Me.lblSKU.Size = New System.Drawing.Size(240, 22)
        Me.lblSKU.Text = "Escanear SKU..."
        Me.lblSKU.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        '
        'btnRecords
        '
        Me.btnRecords.BackColor = System.Drawing.Color.Black
        Me.btnRecords.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnRecords.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnRecords.ForeColor = System.Drawing.Color.White
        Me.btnRecords.Location = New System.Drawing.Point(58, 323)
        Me.btnRecords.Name = "btnRecords"
        Me.btnRecords.PressedBackColor = System.Drawing.Color.Gold
        Me.btnRecords.PressedForeColor = System.Drawing.Color.White
        Me.btnRecords.Size = New System.Drawing.Size(61, 74)
        Me.btnRecords.TabIndex = 27
        Me.btnRecords.Text = "SKUs(0)"
        Me.btnRecords.WordWrap = True
        '
        'btnCamara
        '
        Me.btnCamara.BackColor = System.Drawing.Color.Black
        Me.btnCamara.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnCamara.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        Me.btnCamara.ForeColor = System.Drawing.Color.White
        Me.btnCamara.Location = New System.Drawing.Point(176, 323)
        Me.btnCamara.Name = "btnCamara"
        Me.btnCamara.PressedBackColor = System.Drawing.Color.Gold
        Me.btnCamara.PressedForeColor = System.Drawing.Color.White
        Me.btnCamara.Size = New System.Drawing.Size(61, 74)
        Me.btnCamara.TabIndex = 17
        Me.btnCamara.Text = "Camara (0)"
        Me.btnCamara.WordWrap = True
        '
        'LBL_LICENSE
        '
        Me.LBL_LICENSE.AutoSize = False
        Me.LBL_LICENSE.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LBL_LICENSE.BorderColor = System.Drawing.Color.Goldenrod
        Me.LBL_LICENSE.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle
        Me.LBL_LICENSE.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_LICENSE.ForeColor = System.Drawing.Color.White
        Me.LBL_LICENSE.Location = New System.Drawing.Point(0, 24)
        Me.LBL_LICENSE.Name = "LBL_LICENSE"
        Me.LBL_LICENSE.Size = New System.Drawing.Size(240, 27)
        Me.LBL_LICENSE.Text = "..."
        Me.LBL_LICENSE.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        '
        'cmbCommercialAggrements
        '
        Me.cmbCommercialAggrements.ArrowBoxArrowSize = 7
        Me.cmbCommercialAggrements.BorderColor = System.Drawing.Color.Goldenrod
        Me.cmbCommercialAggrements.BorderSize = 2
        Me.cmbCommercialAggrements.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle
        Me.cmbCommercialAggrements.FontDropDownList = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.cmbCommercialAggrements.FullScreenList = True
        Me.cmbCommercialAggrements.GyroSensorNavigation = True
        Me.cmbCommercialAggrements.ItemHeight = 40
        Me.cmbCommercialAggrements.Location = New System.Drawing.Point(0, 57)
        Me.cmbCommercialAggrements.Name = "cmbCommercialAggrements"
        Me.cmbCommercialAggrements.NavSensorNavigation = True
        Me.cmbCommercialAggrements.SelectedBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmbCommercialAggrements.Size = New System.Drawing.Size(239, 26)
        Me.cmbCommercialAggrements.TabIndex = 33
        '
        'ctrl_RECFIS_Step1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.Black
        Me.Controls.Add(Me.cmbCommercialAggrements)
        Me.Controls.Add(Me.btnRecords)
        Me.Controls.Add(Me.Panel_SKU)
        Me.Controls.Add(Me.LBL_LICENSE)
        Me.Controls.Add(Me.btnRePrintLicense)
        Me.Controls.Add(Me.btnCamara)
        Me.Controls.Add(Me.btnGen_Print_licence)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "ctrl_RECFIS_Step1"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnGen_Print_licence, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRePrintLicense, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_SKU.ResumeLayout(False)
        CType(Me.TransparentLabel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSKU, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRecords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCamara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_LICENSE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents btnGen_Print_licence As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents btnRePrintLicense As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents Panel_SKU As System.Windows.Forms.Panel
    Friend WithEvents lblSKU As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents txtQTY As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents TransparentLabel3 As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents btnRecords As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents btnCamara As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents txtSKU_Desc As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents LBL_LICENSE As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents cmbCommercialAggrements As Resco.Controls.AdvancedComboBox.TouchComboBox

End Class

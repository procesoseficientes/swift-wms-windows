<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_RECFIS_Step2
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
        Me.LBL_LOCATION = New Resco.Controls.CommonControls.TransparentLabel
        Me.btnStatus = New Resco.Controls.OutlookControls.ImageButton
        Me.txtMT2 = New System.Windows.Forms.TextBox
        Me.lblMT2 = New System.Windows.Forms.Label
        Me.UiBotonImprimirLicencia = New Resco.Controls.OutlookControls.ImageButton
        Me.UIVistaUbicacionesSugeridas = New Resco.Controls.SmartGrid.SmartGrid
        Me.UIColUbicacion = New Resco.Controls.SmartGrid.Column
        Me.UIColMaterial = New Resco.Controls.SmartGrid.Column
        Me.UIMaterialName = New Resco.Controls.SmartGrid.Column
        Me.UIColQty = New Resco.Controls.SmartGrid.Column
        Me.UIColTono = New Resco.Controls.SmartGrid.Column
        Me.UIColCalibre = New Resco.Controls.SmartGrid.Column
        Me.UIColBatch = New Resco.Controls.SmartGrid.Column
        Me.UIDateExpiration = New Resco.Controls.SmartGrid.Column
        Me.UIbtnUbicacionesSugeridas = New Resco.Controls.OutlookControls.ImageButton
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LBL_LOCATION, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiBotonImprimirLicencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UIbtnUbicacionesSugeridas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = False
        Me.lblTitle.BackColor = System.Drawing.Color.Gold
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(240, 23)
        Me.lblTitle.Text = "..."
        Me.lblTitle.TextAlignment = Resco.Controls.CommonControls.Alignment.TopCenter
        '
        'LBL_LOCATION
        '
        Me.LBL_LOCATION.AutoSize = False
        Me.LBL_LOCATION.BorderColor = System.Drawing.SystemColors.Menu
        Me.LBL_LOCATION.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle
        Me.LBL_LOCATION.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        Me.LBL_LOCATION.ForeColor = System.Drawing.Color.White
        Me.LBL_LOCATION.Location = New System.Drawing.Point(0, 29)
        Me.LBL_LOCATION.Name = "LBL_LOCATION"
        Me.LBL_LOCATION.Size = New System.Drawing.Size(240, 39)
        Me.LBL_LOCATION.Text = "Escanear ubicación destino..."
        Me.LBL_LOCATION.TextAlignment = Resco.Controls.CommonControls.Alignment.MiddleCenter
        '
        'btnStatus
        '
        Me.btnStatus.BackColor = System.Drawing.Color.Black
        Me.btnStatus.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnStatus.ForeColor = System.Drawing.Color.White
        Me.btnStatus.Location = New System.Drawing.Point(14, 304)
        Me.btnStatus.Name = "btnStatus"
        Me.btnStatus.PressedBackColor = System.Drawing.Color.Gold
        Me.btnStatus.PressedForeColor = System.Drawing.Color.White
        Me.btnStatus.Size = New System.Drawing.Size(203, 36)
        Me.btnStatus.TabIndex = 15
        Me.btnStatus.Text = "Recepcion OK"
        Me.btnStatus.Visible = False
        '
        'txtMT2
        '
        Me.txtMT2.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtMT2.Location = New System.Drawing.Point(19, 110)
        Me.txtMT2.Name = "txtMT2"
        Me.txtMT2.Size = New System.Drawing.Size(203, 29)
        Me.txtMT2.TabIndex = 18
        Me.txtMT2.Visible = False
        '
        'lblMT2
        '
        Me.lblMT2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.lblMT2.ForeColor = System.Drawing.Color.White
        Me.lblMT2.Location = New System.Drawing.Point(19, 87)
        Me.lblMT2.Name = "lblMT2"
        Me.lblMT2.Size = New System.Drawing.Size(203, 20)
        Me.lblMT2.Text = "Metros Cuadrados Utilizados:"
        Me.lblMT2.Visible = False
        '
        'UiBotonImprimirLicencia
        '
        Me.UiBotonImprimirLicencia.BackColor = System.Drawing.Color.Black
        Me.UiBotonImprimirLicencia.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.UiBotonImprimirLicencia.ForeColor = System.Drawing.Color.White
        Me.UiBotonImprimirLicencia.Location = New System.Drawing.Point(14, 351)
        Me.UiBotonImprimirLicencia.Name = "UiBotonImprimirLicencia"
        Me.UiBotonImprimirLicencia.PressedBackColor = System.Drawing.Color.Gold
        Me.UiBotonImprimirLicencia.PressedForeColor = System.Drawing.Color.White
        Me.UiBotonImprimirLicencia.Size = New System.Drawing.Size(203, 36)
        Me.UiBotonImprimirLicencia.TabIndex = 21
        Me.UiBotonImprimirLicencia.Text = "Imprimir Licencia"
        Me.UiBotonImprimirLicencia.Visible = False
        '
        'UIVistaUbicacionesSugeridas
        '
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIColUbicacion)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIColMaterial)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIMaterialName)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIColQty)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIColTono)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIColCalibre)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIColBatch)
        Me.UIVistaUbicacionesSugeridas.Columns.Add(Me.UIDateExpiration)
        Me.UIVistaUbicacionesSugeridas.Location = New System.Drawing.Point(0, 110)
        Me.UIVistaUbicacionesSugeridas.Name = "UIVistaUbicacionesSugeridas"
        Me.UIVistaUbicacionesSugeridas.Size = New System.Drawing.Size(240, 287)
        Me.UIVistaUbicacionesSugeridas.TabIndex = 25
        Me.UIVistaUbicacionesSugeridas.Text = "SmartGrid1"
        Me.UIVistaUbicacionesSugeridas.Visible = False
        '
        'UIColUbicacion
        '
        Me.UIColUbicacion.DataMember = "LOCATION"
        Me.UIColUbicacion.HeaderText = "Ubicación"
        Me.UIColUbicacion.Name = "UIColUbicacion"
        Me.UIColUbicacion.Width = 100
        '
        'UIColMaterial
        '
        Me.UIColMaterial.DataMember = "MATERIAL_ID"
        Me.UIColMaterial.HeaderText = "Material Común"
        Me.UIColMaterial.Name = "UIColMaterial"
        Me.UIColMaterial.Width = 100
        '
        'UIMaterialName
        '
        Me.UIMaterialName.DataMember = "MATERIAL_NAME"
        Me.UIMaterialName.HeaderText = "Descripción"
        Me.UIMaterialName.Name = "UIMaterialName"
        Me.UIMaterialName.Width = 125
        '
        'UIColQty
        '
        Me.UIColQty.DataMember = "QTY"
        Me.UIColQty.HeaderText = "QTY"
        Me.UIColQty.Name = "UIColQty"
        Me.UIColQty.Width = 40
        '
        'UIColTono
        '
        Me.UIColTono.DataMember = "TONE"
        Me.UIColTono.HeaderText = "Tono"
        Me.UIColTono.Name = "UIColTono"
        Me.UIColTono.Width = 40
        '
        'UIColCalibre
        '
        Me.UIColCalibre.DataMember = "CALIBER"
        Me.UIColCalibre.HeaderText = "Calibre"
        Me.UIColCalibre.Name = "UIColCalibre"
        Me.UIColCalibre.Width = 40
        '
        'UIColBatch
        '
        Me.UIColBatch.DataMember = "BATCH"
        Me.UIColBatch.HeaderText = "Lote"
        Me.UIColBatch.Name = "UIColBatch"
        Me.UIColBatch.Width = 40
        '
        'UIDateExpiration
        '
        Me.UIDateExpiration.DataMember = "DATE_EXPIRATION"
        Me.UIDateExpiration.HeaderText = "Fec. Expira"
        Me.UIDateExpiration.Name = "UIDateExpiration"
        '
        'UIbtnUbicacionesSugeridas
        '
        Me.UIbtnUbicacionesSugeridas.BackColor = System.Drawing.Color.Black
        Me.UIbtnUbicacionesSugeridas.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.UIbtnUbicacionesSugeridas.ForeColor = System.Drawing.Color.White
        Me.UIbtnUbicacionesSugeridas.Location = New System.Drawing.Point(0, 74)
        Me.UIbtnUbicacionesSugeridas.Name = "UIbtnUbicacionesSugeridas"
        Me.UIbtnUbicacionesSugeridas.PressedBackColor = System.Drawing.Color.Gold
        Me.UIbtnUbicacionesSugeridas.PressedForeColor = System.Drawing.Color.White
        Me.UIbtnUbicacionesSugeridas.Size = New System.Drawing.Size(240, 36)
        Me.UIbtnUbicacionesSugeridas.TabIndex = 26
        Me.UIbtnUbicacionesSugeridas.Text = "Ubicaciones Sugeridas"
        '
        'ctrl_RECFIS_Step2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.UIbtnUbicacionesSugeridas)
        Me.Controls.Add(Me.UIVistaUbicacionesSugeridas)
        Me.Controls.Add(Me.UiBotonImprimirLicencia)
        Me.Controls.Add(Me.lblMT2)
        Me.Controls.Add(Me.txtMT2)
        Me.Controls.Add(Me.LBL_LOCATION)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnStatus)
        Me.Name = "ctrl_RECFIS_Step2"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LBL_LOCATION, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiBotonImprimirLicencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UIbtnUbicacionesSugeridas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMT2 As System.Windows.Forms.TextBox
    Friend WithEvents lblMT2 As System.Windows.Forms.Label
    Friend WithEvents LBL_LOCATION As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents btnStatus As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents UiBotonImprimirLicencia As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents lblTitle As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents UIVistaUbicacionesSugeridas As Resco.Controls.SmartGrid.SmartGrid
    Friend WithEvents UIbtnUbicacionesSugeridas As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents UIColUbicacion As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColMaterial As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIMaterialName As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColQty As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColTono As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColCalibre As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColBatch As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIDateExpiration As Resco.Controls.SmartGrid.Column

End Class

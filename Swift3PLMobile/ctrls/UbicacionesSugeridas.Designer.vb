<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class UbicacionesSugeridas
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
        Me.UIVistaUbicacionesSugeridas = New Resco.Controls.SmartGrid.SmartGrid
        Me.UIColUbicacion = New Resco.Controls.SmartGrid.Column
        Me.UIColMaterial = New Resco.Controls.SmartGrid.Column
        Me.UIMaterialName = New Resco.Controls.SmartGrid.Column
        Me.UIColQty = New Resco.Controls.SmartGrid.Column
        Me.UIColTono = New Resco.Controls.SmartGrid.Column
        Me.UIColCalibre = New Resco.Controls.SmartGrid.Column
        Me.UIColBatch = New Resco.Controls.SmartGrid.Column
        Me.UIDateExpiration = New Resco.Controls.SmartGrid.Column
        Me.UiTitleUbicacionesSugeridas = New Resco.UIElements.UILabel
        Me.panelLabelTitle = New Resco.UIElements.Controls.UIElementPanelControl
        Me.panelLabelTitle.SuspendElementLayout()
        Me.SuspendLayout()
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
        Me.UIVistaUbicacionesSugeridas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UIVistaUbicacionesSugeridas.Location = New System.Drawing.Point(0, 30)
        Me.UIVistaUbicacionesSugeridas.Name = "UIVistaUbicacionesSugeridas"
        Me.UIVistaUbicacionesSugeridas.Size = New System.Drawing.Size(240, 370)
        Me.UIVistaUbicacionesSugeridas.TabIndex = 26
        Me.UIVistaUbicacionesSugeridas.Text = "SmartGrid1"
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
        'UiTitleUbicacionesSugeridas
        '
        Me.UiTitleUbicacionesSugeridas.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Regular)
        Me.UiTitleUbicacionesSugeridas.ForeColor = System.Drawing.Color.White
        Me.UiTitleUbicacionesSugeridas.Layout = New Resco.UIElements.ElementLayout(Resco.UIElements.HAlignment.Stretch, Resco.UIElements.VAlignment.Top, 16, 0, 14, 0, 210, 26)
        Me.UiTitleUbicacionesSugeridas.Name = "UiTitleUbicacionesSugeridas"
        Me.UiTitleUbicacionesSugeridas.Text = "Ubicaciones Sugeridas"
        '
        'panelLabelTitle
        '
        Me.panelLabelTitle.BackColor = System.Drawing.SystemColors.ControlText
        Me.panelLabelTitle.Children.Add(Me.UiTitleUbicacionesSugeridas)
        Me.panelLabelTitle.Name = "panelLabelTitle"
        Me.panelLabelTitle.Size = New System.Drawing.Size(240, 30)
        Me.panelLabelTitle.TabIndex = 27
        '
        'UbicacionesSugeridas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.panelLabelTitle)
        Me.Controls.Add(Me.UIVistaUbicacionesSugeridas)
        Me.Name = "UbicacionesSugeridas"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.panelLabelTitle.ResumeElementLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UIVistaUbicacionesSugeridas As Resco.Controls.SmartGrid.SmartGrid
    Friend WithEvents UIColUbicacion As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColMaterial As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIMaterialName As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColQty As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColTono As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColCalibre As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIColBatch As Resco.Controls.SmartGrid.Column
    Friend WithEvents UIDateExpiration As Resco.Controls.SmartGrid.Column
    Friend WithEvents UiTitleUbicacionesSugeridas As Resco.UIElements.UILabel
    Friend WithEvents panelLabelTitle As Resco.UIElements.Controls.UIElementPanelControl

End Class

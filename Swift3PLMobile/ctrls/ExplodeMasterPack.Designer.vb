<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ExplodeMasterPack
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
        Me.UiVistaMasterPack = New Resco.Controls.DetailView.DetailView
        Me.UiSeparador = New Resco.Controls.DetailView.Item
        Me.UiEtiquetaEncabezado = New Resco.Controls.DetailView.Item
        Me.UiTextoIngresoLicencia = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoDescripcionCodigo = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoDescripcionMaterial = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoCantidadMaterial = New Resco.Controls.DetailView.ItemTextBox
        Me.UiBotonDetalleMasterPack = New Resco.Controls.OutlookControls.ImageButton
        Me.UiBotonExplocionMaterPack = New Resco.Controls.OutlookControls.ImageButton
        CType(Me.UiBotonDetalleMasterPack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiBotonExplocionMaterPack, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiVistaMasterPack
        '
        Me.UiVistaMasterPack.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UiVistaMasterPack.DisabledForeColor = System.Drawing.Color.Gray
        Me.UiVistaMasterPack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiVistaMasterPack.EnableDesignTimeCustomItems = True
        Me.UiVistaMasterPack.ForeColor = System.Drawing.Color.White
        Me.UiVistaMasterPack.GradientBackColor = New Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.DetailView.FillDirection.Vertical)
        Me.UiVistaMasterPack.Items.Add(Me.UiSeparador)
        Me.UiVistaMasterPack.Items.Add(Me.UiEtiquetaEncabezado)
        Me.UiVistaMasterPack.Items.Add(Me.UiTextoIngresoLicencia)
        Me.UiVistaMasterPack.Items.Add(Me.UiTextoDescripcionCodigo)
        Me.UiVistaMasterPack.Items.Add(Me.UiTextoDescripcionMaterial)
        Me.UiVistaMasterPack.Items.Add(Me.UiTextoCantidadMaterial)
        Me.UiVistaMasterPack.KeyNavigation = True
        Me.UiVistaMasterPack.KeyTabNavigation = True
        Me.UiVistaMasterPack.LabelWidth = 90
        Me.UiVistaMasterPack.Location = New System.Drawing.Point(0, 0)
        Me.UiVistaMasterPack.Name = "UiVistaMasterPack"
        Me.UiVistaMasterPack.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots
        Me.UiVistaMasterPack.SeparatorWidth = 0
        Me.UiVistaMasterPack.Size = New System.Drawing.Size(240, 400)
        Me.UiVistaMasterPack.TabIndex = 3
        Me.UiVistaMasterPack.TabStop = False
        Me.UiVistaMasterPack.TouchScrolling = True
        Me.UiVistaMasterPack.UseClickVisualize = True
        Me.UiVistaMasterPack.UseGradient = True
        '
        'UiSeparador
        '
        Me.UiSeparador.Height = 0
        Me.UiSeparador.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        Me.UiSeparador.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiSeparador.LabelBackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.UiSeparador.LabelHeight = 3
        Me.UiSeparador.Name = "UiSeparador"
        Me.UiSeparador.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiSeparador.TextBackColor = System.Drawing.Color.Black
        '
        'UiEtiquetaEncabezado
        '
        Me.UiEtiquetaEncabezado.Height = 0
        Me.UiEtiquetaEncabezado.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        Me.UiEtiquetaEncabezado.Label = "Explosión Master Pack"
        Me.UiEtiquetaEncabezado.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiEtiquetaEncabezado.LabelBackColor = System.Drawing.Color.Black
        Me.UiEtiquetaEncabezado.LabelFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UiEtiquetaEncabezado.LabelForeColor = System.Drawing.Color.White
        Me.UiEtiquetaEncabezado.LabelHeight = 24
        Me.UiEtiquetaEncabezado.Name = "UiEtiquetaEncabezado"
        Me.UiEtiquetaEncabezado.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiEtiquetaEncabezado.TextBackColor = System.Drawing.Color.White
        Me.UiEtiquetaEncabezado.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'UiTextoIngresoLicencia
        '
        Me.UiTextoIngresoLicencia.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper
        Me.UiTextoIngresoLicencia.Height = 24
        Me.UiTextoIngresoLicencia.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoIngresoLicencia.Label = "Licencia"
        Me.UiTextoIngresoLicencia.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiTextoIngresoLicencia.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoLicencia.LabelForeColor = System.Drawing.Color.DarkOrange
        Me.UiTextoIngresoLicencia.LabelHeight = 24
        Me.UiTextoIngresoLicencia.Name = "UiTextoIngresoLicencia"
        Me.UiTextoIngresoLicencia.ReadOnly = True
        Me.UiTextoIngresoLicencia.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoIngresoLicencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiTextoIngresoLicencia.TextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.UiTextoIngresoLicencia.TextForeColor = System.Drawing.Color.DarkOrange
        '
        'UiTextoDescripcionCodigo
        '
        Me.UiTextoDescripcionCodigo.Height = 24
        Me.UiTextoDescripcionCodigo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoDescripcionCodigo.Label = "Código"
        Me.UiTextoDescripcionCodigo.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoDescripcionCodigo.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoDescripcionCodigo.LabelForeColor = System.Drawing.Color.Yellow
        Me.UiTextoDescripcionCodigo.LabelHeight = 24
        Me.UiTextoDescripcionCodigo.Name = "UiTextoDescripcionCodigo"
        Me.UiTextoDescripcionCodigo.ReadOnly = True
        Me.UiTextoDescripcionCodigo.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoDescripcionCodigo.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoDescripcionCodigo.TextForeColor = System.Drawing.Color.Yellow
        '
        'UiTextoDescripcionMaterial
        '
        Me.UiTextoDescripcionMaterial.Height = 24
        Me.UiTextoDescripcionMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoDescripcionMaterial.Label = "Descripción"
        Me.UiTextoDescripcionMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoDescripcionMaterial.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoDescripcionMaterial.LabelForeColor = System.Drawing.Color.Yellow
        Me.UiTextoDescripcionMaterial.LabelHeight = 24
        Me.UiTextoDescripcionMaterial.Name = "UiTextoDescripcionMaterial"
        Me.UiTextoDescripcionMaterial.ReadOnly = True
        Me.UiTextoDescripcionMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoDescripcionMaterial.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoDescripcionMaterial.TextForeColor = System.Drawing.Color.Yellow
        '
        'UiTextoCantidadMaterial
        '
        Me.UiTextoCantidadMaterial.Height = 24
        Me.UiTextoCantidadMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoCantidadMaterial.Label = "Cantidad"
        Me.UiTextoCantidadMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoCantidadMaterial.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoCantidadMaterial.LabelForeColor = System.Drawing.Color.Yellow
        Me.UiTextoCantidadMaterial.LabelHeight = 24
        Me.UiTextoCantidadMaterial.Name = "UiTextoCantidadMaterial"
        Me.UiTextoCantidadMaterial.ReadOnly = True
        Me.UiTextoCantidadMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoCantidadMaterial.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoCantidadMaterial.TextForeColor = System.Drawing.Color.Yellow
        '
        'UiBotonDetalleMasterPack
        '
        Me.UiBotonDetalleMasterPack.BackColor = System.Drawing.Color.Black
        Me.UiBotonDetalleMasterPack.BorderColor = System.Drawing.Color.Orange
        Me.UiBotonDetalleMasterPack.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.UiBotonDetalleMasterPack.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Me.UiBotonDetalleMasterPack.ForeColor = System.Drawing.Color.White
        Me.UiBotonDetalleMasterPack.Location = New System.Drawing.Point(157, 322)
        Me.UiBotonDetalleMasterPack.Name = "UiBotonDetalleMasterPack"
        Me.UiBotonDetalleMasterPack.PressedBackColor = System.Drawing.Color.Orange
        Me.UiBotonDetalleMasterPack.PressedForeColor = System.Drawing.Color.White
        Me.UiBotonDetalleMasterPack.Size = New System.Drawing.Size(80, 75)
        Me.UiBotonDetalleMasterPack.TabIndex = 18
        Me.UiBotonDetalleMasterPack.Text = "Detalle"
        Me.UiBotonDetalleMasterPack.Visible = False
        Me.UiBotonDetalleMasterPack.VistaButtonInflate = New System.Drawing.Size(-2, -2)
        Me.UiBotonDetalleMasterPack.WordWrap = True
        '
        'UiBotonExplocionMaterPack
        '
        Me.UiBotonExplocionMaterPack.BackColor = System.Drawing.Color.Black
        Me.UiBotonExplocionMaterPack.BorderColor = System.Drawing.Color.Goldenrod
        Me.UiBotonExplocionMaterPack.BorderStyle = Resco.Controls.RescoBorderStyle.FixedSingle
        Me.UiBotonExplocionMaterPack.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.UiBotonExplocionMaterPack.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Me.UiBotonExplocionMaterPack.ForeColor = System.Drawing.Color.White
        Me.UiBotonExplocionMaterPack.Location = New System.Drawing.Point(3, 322)
        Me.UiBotonExplocionMaterPack.Name = "UiBotonExplocionMaterPack"
        Me.UiBotonExplocionMaterPack.PressedBackColor = System.Drawing.Color.Orange
        Me.UiBotonExplocionMaterPack.PressedForeColor = System.Drawing.Color.White
        Me.UiBotonExplocionMaterPack.Size = New System.Drawing.Size(80, 75)
        Me.UiBotonExplocionMaterPack.TabIndex = 17
        Me.UiBotonExplocionMaterPack.Text = "Explosión"
        Me.UiBotonExplocionMaterPack.Visible = False
        Me.UiBotonExplocionMaterPack.VistaButtonInflate = New System.Drawing.Size(-2, -2)
        Me.UiBotonExplocionMaterPack.WordWrap = True
        '
        'ExplodeMasterPack
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.UiBotonDetalleMasterPack)
        Me.Controls.Add(Me.UiBotonExplocionMaterPack)
        Me.Controls.Add(Me.UiVistaMasterPack)
        Me.Name = "ExplodeMasterPack"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.UiBotonDetalleMasterPack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiBotonExplocionMaterPack, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiVistaMasterPack As Resco.Controls.DetailView.DetailView
    Friend WithEvents UiBotonDetalleMasterPack As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents UiBotonExplocionMaterPack As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents UiSeparador As Resco.Controls.DetailView.Item
    Friend WithEvents UiEtiquetaEncabezado As Resco.Controls.DetailView.Item
    Friend WithEvents UiTextoIngresoLicencia As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoDescripcionCodigo As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoDescripcionMaterial As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoCantidadMaterial As Resco.Controls.DetailView.ItemTextBox

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class SerialNumberProcess
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
        Me.UiVistaDetalleIngresoSeries = New Resco.Controls.DetailView.DetailView
        Me.UiListaSeriesDiscrecional = New Resco.Controls.AdvancedList.AdvancedList
        Me.Material = New Resco.Controls.AdvancedList.RowTemplate
        Me.SERIAL = New Resco.Controls.AdvancedList.TextCell
        Me.UiBotonConsultarSeries = New Resco.Controls.OutlookControls.ImageButton
        Me.UiSeparador = New Resco.Controls.DetailView.Item
        Me.UiEtiquetaEncabezado = New Resco.Controls.DetailView.Item
        Me.UiTextoMaterial = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoSerie = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoUltimaSerie = New Resco.Controls.DetailView.ItemTextBox
        CType(Me.UiBotonConsultarSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiVistaDetalleIngresoSeries
        '
        Me.UiVistaDetalleIngresoSeries.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UiVistaDetalleIngresoSeries.DisabledForeColor = System.Drawing.Color.Gray
        Me.UiVistaDetalleIngresoSeries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiVistaDetalleIngresoSeries.EnableDesignTimeCustomItems = True
        Me.UiVistaDetalleIngresoSeries.ForeColor = System.Drawing.Color.White
        Me.UiVistaDetalleIngresoSeries.GradientBackColor = New Resco.Controls.DetailView.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.DetailView.FillDirection.Vertical)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiSeparador)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiEtiquetaEncabezado)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoMaterial)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoSerie)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoUltimaSerie)
        Me.UiVistaDetalleIngresoSeries.KeyNavigation = True
        Me.UiVistaDetalleIngresoSeries.KeyTabNavigation = True
        Me.UiVistaDetalleIngresoSeries.LabelWidth = 90
        Me.UiVistaDetalleIngresoSeries.Location = New System.Drawing.Point(0, 0)
        Me.UiVistaDetalleIngresoSeries.Name = "UiVistaDetalleIngresoSeries"
        Me.UiVistaDetalleIngresoSeries.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots
        Me.UiVistaDetalleIngresoSeries.SeparatorWidth = 0
        Me.UiVistaDetalleIngresoSeries.Size = New System.Drawing.Size(240, 400)
        Me.UiVistaDetalleIngresoSeries.TabIndex = 3
        Me.UiVistaDetalleIngresoSeries.TabStop = False
        Me.UiVistaDetalleIngresoSeries.TouchScrolling = True
        Me.UiVistaDetalleIngresoSeries.UseClickVisualize = True
        Me.UiVistaDetalleIngresoSeries.UseGradient = True
        '
        'UiListaSeriesDiscrecional
        '
        Me.UiListaSeriesDiscrecional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UiListaSeriesDiscrecional.DataRows.Clear()
        Me.UiListaSeriesDiscrecional.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedList.FillDirection.Horizontal)
        Me.UiListaSeriesDiscrecional.Location = New System.Drawing.Point(16, 60)
        Me.UiListaSeriesDiscrecional.Name = "UiListaSeriesDiscrecional"
        Me.UiListaSeriesDiscrecional.Size = New System.Drawing.Size(210, 256)
        Me.UiListaSeriesDiscrecional.TabIndex = 4
        Me.UiListaSeriesDiscrecional.Templates.Add(Me.Material)
        Me.UiListaSeriesDiscrecional.Visible = False
        '
        'Material
        '
        Me.Material.BackColor = System.Drawing.Color.Transparent
        Me.Material.CellTemplates.Add(Me.SERIAL)
        Me.Material.Height = 22
        Me.Material.Name = "Material"
        '
        'SERIAL
        '
        Me.SERIAL.CellSource.ColumnName = "SERIAL"
        Me.SERIAL.DesignName = "SERIAL"
        Me.SERIAL.ForeColor = System.Drawing.Color.White
        Me.SERIAL.Location = New System.Drawing.Point(1, 4)
        Me.SERIAL.Name = "SERIAL"
        Me.SERIAL.Size = New System.Drawing.Size(239, 16)
        Me.SERIAL.TextFont = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        '
        'UiBotonConsultarSeries
        '
        Me.UiBotonConsultarSeries.BackColor = System.Drawing.Color.Black
        Me.UiBotonConsultarSeries.BorderColor = System.Drawing.Color.Orange
        Me.UiBotonConsultarSeries.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.UiBotonConsultarSeries.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Me.UiBotonConsultarSeries.ForeColor = System.Drawing.Color.White
        Me.UiBotonConsultarSeries.Location = New System.Drawing.Point(3, 322)
        Me.UiBotonConsultarSeries.Name = "UiBotonConsultarSeries"
        Me.UiBotonConsultarSeries.PressedBackColor = System.Drawing.Color.Orange
        Me.UiBotonConsultarSeries.PressedForeColor = System.Drawing.Color.White
        Me.UiBotonConsultarSeries.Size = New System.Drawing.Size(78, 75)
        Me.UiBotonConsultarSeries.TabIndex = 22
        Me.UiBotonConsultarSeries.Text = "Series"
        Me.UiBotonConsultarSeries.VistaButtonInflate = New System.Drawing.Size(-2, -2)
        Me.UiBotonConsultarSeries.WordWrap = True
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
        Me.UiEtiquetaEncabezado.Label = "Escanear Serie"
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
        'UiTextoMaterial
        '
        Me.UiTextoMaterial.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper
        Me.UiTextoMaterial.Height = 24
        Me.UiTextoMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoMaterial.Label = "Material"
        Me.UiTextoMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiTextoMaterial.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoMaterial.LabelForeColor = System.Drawing.Color.DarkOrange
        Me.UiTextoMaterial.LabelHeight = 24
        Me.UiTextoMaterial.Name = "UiTextoMaterial"
        Me.UiTextoMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiTextoMaterial.TextFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UiTextoMaterial.TextForeColor = System.Drawing.Color.DarkOrange
        '
        'UiTextoSerie
        '
        Me.UiTextoSerie.Height = 24
        Me.UiTextoSerie.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoSerie.Label = "Número de Serie"
        Me.UiTextoSerie.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoSerie.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoSerie.LabelForeColor = System.Drawing.Color.White
        Me.UiTextoSerie.LabelHeight = 24
        Me.UiTextoSerie.MaxLength = 50
        Me.UiTextoSerie.Name = "UiTextoSerie"
        Me.UiTextoSerie.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoSerie.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoSerie.TextForeColor = System.Drawing.Color.White
        '
        'UiTextoUltimaSerie
        '
        Me.UiTextoUltimaSerie.Height = 24
        Me.UiTextoUltimaSerie.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoUltimaSerie.Label = "Cant. 0/Serie Anterior"
        Me.UiTextoUltimaSerie.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoUltimaSerie.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoUltimaSerie.LabelForeColor = System.Drawing.Color.Yellow
        Me.UiTextoUltimaSerie.LabelHeight = 24
        Me.UiTextoUltimaSerie.Name = "UiTextoUltimaSerie"
        Me.UiTextoUltimaSerie.ReadOnly = True
        Me.UiTextoUltimaSerie.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoUltimaSerie.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoUltimaSerie.TextForeColor = System.Drawing.Color.Yellow
        '
        'SerialNumberProcess
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.UiBotonConsultarSeries)
        Me.Controls.Add(Me.UiListaSeriesDiscrecional)
        Me.Controls.Add(Me.UiVistaDetalleIngresoSeries)
        Me.Name = "SerialNumberProcess"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.UiBotonConsultarSeries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiVistaDetalleIngresoSeries As Resco.Controls.DetailView.DetailView
    Friend WithEvents UiListaSeriesDiscrecional As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents Material As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents SERIAL As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents UiBotonConsultarSeries As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents UiSeparador As Resco.Controls.DetailView.Item
    Friend WithEvents UiEtiquetaEncabezado As Resco.Controls.DetailView.Item
    Friend WithEvents UiTextoMaterial As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoSerie As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoUltimaSerie As Resco.Controls.DetailView.ItemTextBox

End Class

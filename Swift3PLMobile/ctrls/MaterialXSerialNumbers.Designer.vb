<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MaterialXSerialNumbers
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
        Me.UiSeparador = New Resco.Controls.DetailView.Item
        Me.UiEtiquetaEncabezado = New Resco.Controls.DetailView.Item
        Me.UiTextoIngresoSerieMaterial = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoIngresoSerieLote = New Resco.Controls.DetailView.ItemTextBox
        Me.UiFechaIngresoSerieFechaLote = New Resco.Controls.DetailView.ItemDateTime
        Me.UiTextoIngresoSerieNumeroSerie = New Resco.Controls.DetailView.ItemTextBox
        Me.UiTextoIngresoSerieSerieAnterior = New Resco.Controls.DetailView.ItemTextBox
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
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoIngresoSerieMaterial)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoIngresoSerieLote)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiFechaIngresoSerieFechaLote)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoIngresoSerieNumeroSerie)
        Me.UiVistaDetalleIngresoSeries.Items.Add(Me.UiTextoIngresoSerieSerieAnterior)
        Me.UiVistaDetalleIngresoSeries.KeyNavigation = True
        Me.UiVistaDetalleIngresoSeries.KeyTabNavigation = True
        Me.UiVistaDetalleIngresoSeries.LabelWidth = 90
        Me.UiVistaDetalleIngresoSeries.Location = New System.Drawing.Point(0, 0)
        Me.UiVistaDetalleIngresoSeries.Name = "UiVistaDetalleIngresoSeries"
        Me.UiVistaDetalleIngresoSeries.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots
        Me.UiVistaDetalleIngresoSeries.SeparatorWidth = 0
        Me.UiVistaDetalleIngresoSeries.Size = New System.Drawing.Size(240, 400)
        Me.UiVistaDetalleIngresoSeries.TabIndex = 2
        Me.UiVistaDetalleIngresoSeries.TabStop = False
        Me.UiVistaDetalleIngresoSeries.TouchScrolling = True
        Me.UiVistaDetalleIngresoSeries.UseClickVisualize = True
        Me.UiVistaDetalleIngresoSeries.UseGradient = True
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
        Me.UiEtiquetaEncabezado.Label = "Ingreso de Series"
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
        'UiTextoIngresoSerieMaterial
        '
        Me.UiTextoIngresoSerieMaterial.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper
        Me.UiTextoIngresoSerieMaterial.Height = 24
        Me.UiTextoIngresoSerieMaterial.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoIngresoSerieMaterial.Label = "Material"
        Me.UiTextoIngresoSerieMaterial.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiTextoIngresoSerieMaterial.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieMaterial.LabelForeColor = System.Drawing.Color.DarkOrange
        Me.UiTextoIngresoSerieMaterial.LabelHeight = 24
        Me.UiTextoIngresoSerieMaterial.Name = "UiTextoIngresoSerieMaterial"
        Me.UiTextoIngresoSerieMaterial.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoIngresoSerieMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.UiTextoIngresoSerieMaterial.TextFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UiTextoIngresoSerieMaterial.TextForeColor = System.Drawing.Color.DarkOrange
        '
        'UiTextoIngresoSerieLote
        '
        Me.UiTextoIngresoSerieLote.Height = 24
        Me.UiTextoIngresoSerieLote.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoIngresoSerieLote.Label = "Número de Lote"
        Me.UiTextoIngresoSerieLote.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoIngresoSerieLote.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieLote.LabelForeColor = System.Drawing.Color.White
        Me.UiTextoIngresoSerieLote.LabelHeight = 24
        Me.UiTextoIngresoSerieLote.MaxLength = 50
        Me.UiTextoIngresoSerieLote.Name = "UiTextoIngresoSerieLote"
        Me.UiTextoIngresoSerieLote.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoIngresoSerieLote.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieLote.TextForeColor = System.Drawing.Color.White
        '
        'UiFechaIngresoSerieFechaLote
        '
        Me.UiFechaIngresoSerieFechaLote.DateTime = New Date(2016, 11, 7, 11, 38, 57, 0)
        Me.UiFechaIngresoSerieFechaLote.DateTimeStyle = Resco.Controls.DetailView.RescoDateTimePickerStyle.[Date]
        Me.UiFechaIngresoSerieFechaLote.Format = "dd/MMMM/yyyy"
        Me.UiFechaIngresoSerieFechaLote.Height = 24
        Me.UiFechaIngresoSerieFechaLote.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiFechaIngresoSerieFechaLote.Label = "Fecha de Expiración"
        Me.UiFechaIngresoSerieFechaLote.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiFechaIngresoSerieFechaLote.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiFechaIngresoSerieFechaLote.LabelForeColor = System.Drawing.Color.White
        Me.UiFechaIngresoSerieFechaLote.LabelHeight = 24
        Me.UiFechaIngresoSerieFechaLote.Name = "UiFechaIngresoSerieFechaLote"
        Me.UiFechaIngresoSerieFechaLote.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiFechaIngresoSerieFechaLote.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiFechaIngresoSerieFechaLote.TextForeColor = System.Drawing.Color.White
        '
        'UiTextoIngresoSerieNumeroSerie
        '
        Me.UiTextoIngresoSerieNumeroSerie.Height = 24
        Me.UiTextoIngresoSerieNumeroSerie.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoIngresoSerieNumeroSerie.Label = "Número de Serie"
        Me.UiTextoIngresoSerieNumeroSerie.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoIngresoSerieNumeroSerie.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieNumeroSerie.LabelForeColor = System.Drawing.Color.White
        Me.UiTextoIngresoSerieNumeroSerie.LabelHeight = 24
        Me.UiTextoIngresoSerieNumeroSerie.MaxLength = 50
        Me.UiTextoIngresoSerieNumeroSerie.Name = "UiTextoIngresoSerieNumeroSerie"
        Me.UiTextoIngresoSerieNumeroSerie.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoIngresoSerieNumeroSerie.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieNumeroSerie.TextForeColor = System.Drawing.Color.White
        '
        'UiTextoIngresoSerieSerieAnterior
        '
        Me.UiTextoIngresoSerieSerieAnterior.Height = 24
        Me.UiTextoIngresoSerieSerieAnterior.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.UiTextoIngresoSerieSerieAnterior.Label = "Cant. 0/Serie Anterior"
        Me.UiTextoIngresoSerieSerieAnterior.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.UiTextoIngresoSerieSerieAnterior.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieSerieAnterior.LabelForeColor = System.Drawing.Color.Yellow
        Me.UiTextoIngresoSerieSerieAnterior.LabelHeight = 24
        Me.UiTextoIngresoSerieSerieAnterior.Name = "UiTextoIngresoSerieSerieAnterior"
        Me.UiTextoIngresoSerieSerieAnterior.ReadOnly = True
        Me.UiTextoIngresoSerieSerieAnterior.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.UiTextoIngresoSerieSerieAnterior.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.UiTextoIngresoSerieSerieAnterior.TextForeColor = System.Drawing.Color.Yellow
        '
        'MaterialXSerialNumbers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.UiVistaDetalleIngresoSeries)
        Me.Name = "MaterialXSerialNumbers"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiVistaDetalleIngresoSeries As Resco.Controls.DetailView.DetailView
    Friend WithEvents UiSeparador As Resco.Controls.DetailView.Item
    Friend WithEvents UiEtiquetaEncabezado As Resco.Controls.DetailView.Item
    Friend WithEvents UiTextoIngresoSerieMaterial As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoIngresoSerieLote As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiFechaIngresoSerieFechaLote As Resco.Controls.DetailView.ItemDateTime
    Friend WithEvents UiTextoIngresoSerieNumeroSerie As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents UiTextoIngresoSerieSerieAnterior As Resco.Controls.DetailView.ItemTextBox

End Class

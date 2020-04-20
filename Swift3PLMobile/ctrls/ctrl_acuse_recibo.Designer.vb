<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_acuse_recibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_acuse_recibo))
        Me.DetailView1 = New Resco.Controls.DetailView.DetailView
        Me.ItemTemplate24 = New Resco.Controls.AdvancedComboBox.ItemTemplate
        Me.TextCell27 = New Resco.Controls.AdvancedComboBox.TextCell
        Me.btnDis = New Resco.Controls.OutlookControls.ImageButton
        Me.btn_Satis = New Resco.Controls.OutlookControls.ImageButton
        Me.btnPhoto = New Resco.Controls.OutlookControls.ImageButton
        Me.Separator1 = New Resco.Controls.DetailView.Item
        Me.Header1 = New Resco.Controls.DetailView.Item
        Me.txtScanPoliza = New Resco.Controls.DetailView.ItemTextBox
        Me.txtFob = New Resco.Controls.DetailView.ItemTextBox
        Me.txtCodigoTransporte = New Resco.Controls.DetailView.ItemTextBox
        Me.txtPlacaTransporte = New Resco.Controls.DetailView.ItemTextBox
        Me.txtNoContenedor = New Resco.Controls.DetailView.ItemTextBox
        Me.txtNoMarchamo = New Resco.Controls.DetailView.ItemTextBox
        CType(Me.btnDis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_Satis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DetailView1
        '
        Me.DetailView1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.DetailView1.BackgroundImage = CType(resources.GetObject("DetailView1.BackgroundImage"), System.Drawing.Image)
        Me.DetailView1.DisabledForeColor = System.Drawing.Color.Gray
        Me.DetailView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DetailView1.EnableDesignTimeCustomItems = True
        Me.DetailView1.ForeColor = System.Drawing.Color.White
        Me.DetailView1.GradientBackColor = New Resco.Controls.DetailView.GradientColor(System.Drawing.Color.Black, System.Drawing.Color.Silver, Resco.Controls.DetailView.FillDirection.Vertical)
        Me.DetailView1.Items.Add(Me.Separator1)
        Me.DetailView1.Items.Add(Me.Header1)
        Me.DetailView1.Items.Add(Me.txtScanPoliza)
        Me.DetailView1.Items.Add(Me.txtFob)
        Me.DetailView1.Items.Add(Me.txtCodigoTransporte)
        Me.DetailView1.Items.Add(Me.txtPlacaTransporte)
        Me.DetailView1.Items.Add(Me.txtNoContenedor)
        Me.DetailView1.Items.Add(Me.txtNoMarchamo)
        Me.DetailView1.KeyNavigation = True
        Me.DetailView1.KeyTabNavigation = True
        Me.DetailView1.LabelWidth = 90
        Me.DetailView1.Location = New System.Drawing.Point(0, 0)
        Me.DetailView1.Name = "DetailView1"
        Me.DetailView1.PagingStyle = Resco.Controls.DetailView.RescoPageStyle.Dots
        Me.DetailView1.SeparatorWidth = 0
        Me.DetailView1.Size = New System.Drawing.Size(240, 400)
        Me.DetailView1.TabIndex = 1
        Me.DetailView1.TabStop = False
        Me.DetailView1.TouchScrolling = True
        Me.DetailView1.UseClickVisualize = True
        Me.DetailView1.UseGradient = True
        '
        'ItemTemplate24
        '
        Me.ItemTemplate24.CellTemplates.Add(Me.TextCell27)
        Me.ItemTemplate24.Height = 32
        Me.ItemTemplate24.Name = "ItemTemplate24"
        '
        'TextCell27
        '
        Me.TextCell27.CellSource.ColumnName = "DESCRIPCION"
        Me.TextCell27.DesignName = "TextCell27"
        Me.TextCell27.Location = New System.Drawing.Point(0, 0)
        Me.TextCell27.Selectable = True
        Me.TextCell27.SelectedBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextCell27.SelectedForeColor = System.Drawing.Color.White
        Me.TextCell27.Size = New System.Drawing.Size(-1, 32)
        Me.TextCell27.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'btnDis
        '
        Me.btnDis.BackColor = System.Drawing.Color.Black
        Me.btnDis.BorderColor = System.Drawing.Color.Orange
        Me.btnDis.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnDis.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Me.btnDis.ForeColor = System.Drawing.Color.White
        Me.btnDis.Location = New System.Drawing.Point(172, 322)
        Me.btnDis.Name = "btnDis"
        Me.btnDis.PressedBackColor = System.Drawing.Color.Orange
        Me.btnDis.PressedForeColor = System.Drawing.Color.White
        Me.btnDis.Size = New System.Drawing.Size(65, 75)
        Me.btnDis.TabIndex = 21
        Me.btnDis.Text = "Discre pancia "
        Me.btnDis.VistaButtonInflate = New System.Drawing.Size(-2, -2)
        Me.btnDis.WordWrap = True
        '
        'btn_Satis
        '
        Me.btn_Satis.BackColor = System.Drawing.Color.Black
        Me.btn_Satis.BorderColor = System.Drawing.Color.Orange
        Me.btn_Satis.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btn_Satis.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Me.btn_Satis.ForeColor = System.Drawing.Color.White
        Me.btn_Satis.Location = New System.Drawing.Point(101, 322)
        Me.btn_Satis.Name = "btn_Satis"
        Me.btn_Satis.PressedBackColor = System.Drawing.Color.Orange
        Me.btn_Satis.PressedForeColor = System.Drawing.Color.White
        Me.btn_Satis.Size = New System.Drawing.Size(65, 75)
        Me.btn_Satis.TabIndex = 20
        Me.btn_Satis.Text = "Satis factorio"
        Me.btn_Satis.VistaButtonInflate = New System.Drawing.Size(-2, -2)
        Me.btn_Satis.WordWrap = True
        '
        'btnPhoto
        '
        Me.btnPhoto.BackColor = System.Drawing.Color.Black
        Me.btnPhoto.BorderColor = System.Drawing.Color.Orange
        Me.btnPhoto.ButtonStyle = Resco.Controls.OutlookControls.ImageButton.ButtonType.VistaStyleImageButton
        Me.btnPhoto.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Regular)
        Me.btnPhoto.ForeColor = System.Drawing.Color.White
        Me.btnPhoto.Location = New System.Drawing.Point(7, 322)
        Me.btnPhoto.Name = "btnPhoto"
        Me.btnPhoto.PressedBackColor = System.Drawing.Color.Orange
        Me.btnPhoto.PressedForeColor = System.Drawing.Color.White
        Me.btnPhoto.Size = New System.Drawing.Size(65, 75)
        Me.btnPhoto.TabIndex = 19
        Me.btnPhoto.Text = "Foto"
        Me.btnPhoto.VistaButtonInflate = New System.Drawing.Size(-2, -2)
        Me.btnPhoto.WordWrap = True
        '
        'Separator1
        '
        Me.Separator1.Height = 0
        Me.Separator1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        Me.Separator1.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.Separator1.LabelBackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Separator1.LabelHeight = 3
        Me.Separator1.Name = "Separator1"
        Me.Separator1.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.Separator1.TextBackColor = System.Drawing.Color.Black
        '
        'Header1
        '
        Me.Header1.Height = 0
        Me.Header1.ItemBorder = Resco.Controls.DetailView.ItemBorder.None
        Me.Header1.Label = "Acuse de Recibo"
        Me.Header1.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Header1.LabelBackColor = System.Drawing.Color.Black
        Me.Header1.LabelFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Header1.LabelForeColor = System.Drawing.Color.White
        Me.Header1.LabelHeight = 24
        Me.Header1.Name = "Header1"
        Me.Header1.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.Header1.TextBackColor = System.Drawing.Color.White
        Me.Header1.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'txtScanPoliza
        '
        Me.txtScanPoliza.CharacterCasing = Resco.Controls.DetailView.ItemTextBoxCharacterCasing.Upper
        Me.txtScanPoliza.Height = 24
        Me.txtScanPoliza.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.txtScanPoliza.Label = "Poliza:"
        Me.txtScanPoliza.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtScanPoliza.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtScanPoliza.LabelForeColor = System.Drawing.Color.DarkOrange
        Me.txtScanPoliza.LabelHeight = 24
        Me.txtScanPoliza.Name = "txtScanPoliza"
        Me.txtScanPoliza.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.txtScanPoliza.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtScanPoliza.TextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtScanPoliza.TextForeColor = System.Drawing.Color.DarkOrange
        '
        'txtFob
        '
        Me.txtFob.Height = 24
        Me.txtFob.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.txtFob.Label = "Fob Dolares"
        Me.txtFob.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtFob.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtFob.LabelForeColor = System.Drawing.Color.White
        Me.txtFob.LabelHeight = 24
        Me.txtFob.Name = "txtFob"
        Me.txtFob.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.txtFob.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtFob.TextForeColor = System.Drawing.Color.White
        '
        'txtCodigoTransporte
        '
        Me.txtCodigoTransporte.Height = 24
        Me.txtCodigoTransporte.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.txtCodigoTransporte.Label = "Codigo Transporte"
        Me.txtCodigoTransporte.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtCodigoTransporte.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtCodigoTransporte.LabelForeColor = System.Drawing.Color.White
        Me.txtCodigoTransporte.LabelHeight = 24
        Me.txtCodigoTransporte.Name = "txtCodigoTransporte"
        Me.txtCodigoTransporte.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.txtCodigoTransporte.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtCodigoTransporte.TextForeColor = System.Drawing.Color.White
        '
        'txtPlacaTransporte
        '
        Me.txtPlacaTransporte.Height = 24
        Me.txtPlacaTransporte.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.txtPlacaTransporte.Label = "Placa Transporte"
        Me.txtPlacaTransporte.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtPlacaTransporte.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtPlacaTransporte.LabelForeColor = System.Drawing.Color.White
        Me.txtPlacaTransporte.LabelHeight = 24
        Me.txtPlacaTransporte.Name = "txtPlacaTransporte"
        Me.txtPlacaTransporte.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.txtPlacaTransporte.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtPlacaTransporte.TextForeColor = System.Drawing.Color.White
        '
        'txtNoContenedor
        '
        Me.txtNoContenedor.Height = 24
        Me.txtNoContenedor.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.txtNoContenedor.Label = "No. Contenedor"
        Me.txtNoContenedor.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNoContenedor.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtNoContenedor.LabelForeColor = System.Drawing.Color.White
        Me.txtNoContenedor.LabelHeight = 24
        Me.txtNoContenedor.Name = "txtNoContenedor"
        Me.txtNoContenedor.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.txtNoContenedor.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtNoContenedor.TextForeColor = System.Drawing.Color.White
        '
        'txtNoMarchamo
        '
        Me.txtNoMarchamo.Height = 24
        Me.txtNoMarchamo.ItemBorder = Resco.Controls.DetailView.ItemBorder.Flat
        Me.txtNoMarchamo.Label = "No. Marchamo"
        Me.txtNoMarchamo.LabelAlignment = System.Windows.Forms.HorizontalAlignment.Left
        Me.txtNoMarchamo.LabelFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtNoMarchamo.LabelForeColor = System.Drawing.Color.White
        Me.txtNoMarchamo.LabelHeight = 24
        Me.txtNoMarchamo.Name = "txtNoMarchamo"
        Me.txtNoMarchamo.Style = Resco.Controls.DetailView.RescoItemStyle.LabelTop
        Me.txtNoMarchamo.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtNoMarchamo.TextForeColor = System.Drawing.Color.White
        '
        'ctrl_acuse_recibo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.btnDis)
        Me.Controls.Add(Me.btn_Satis)
        Me.Controls.Add(Me.btnPhoto)
        Me.Controls.Add(Me.DetailView1)
        Me.Name = "ctrl_acuse_recibo"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.btnDis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_Satis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DetailView1 As Resco.Controls.DetailView.DetailView
    Friend WithEvents ItemTemplate24 As Resco.Controls.AdvancedComboBox.ItemTemplate
    Friend WithEvents TextCell27 As Resco.Controls.AdvancedComboBox.TextCell
    Friend WithEvents btnDis As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents btn_Satis As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents btnPhoto As Resco.Controls.OutlookControls.ImageButton
    Friend WithEvents Separator1 As Resco.Controls.DetailView.Item
    Friend WithEvents Header1 As Resco.Controls.DetailView.Item
    Friend WithEvents txtScanPoliza As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents txtFob As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents txtCodigoTransporte As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents txtPlacaTransporte As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents txtNoContenedor As Resco.Controls.DetailView.ItemTextBox
    Friend WithEvents txtNoMarchamo As Resco.Controls.DetailView.ItemTextBox

End Class

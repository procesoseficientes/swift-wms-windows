<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_ScanDocument
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
        Me.UiPanelScanDocument = New Resco.UIElements.UIPanel
        Me.UiEtiquetaTitulo = New Resco.UIElements.UILabel
        Me.UiTextoDocumento = New Resco.UIElements.UITextBox
        Me.UiTextBoxButton1 = New Resco.UIElements.UITextBoxButton
        Me.UiTextBoxButton2 = New Resco.UIElements.UITextBoxButton
        Me.UiBotonGenerar = New Resco.UIElements.UIButton
        Me.UiElementPanelControl1 = New Resco.UIElements.Controls.UIElementPanelControl
        Me.UiElementPanelControl1.SuspendElementLayout()
        Me.SuspendLayout()
        '
        'UiPanelScanDocument
        '
        Me.UiPanelScanDocument.BackColor = System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.UiPanelScanDocument.BackgroundGradient = New Resco.Drawing.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), 50, 50, Resco.Drawing.FillDirection.Horizontal)
        Me.UiPanelScanDocument.Children.Add(Me.UiEtiquetaTitulo)
        Me.UiPanelScanDocument.Children.Add(Me.UiTextoDocumento)
        Me.UiPanelScanDocument.Children.Add(Me.UiBotonGenerar)
        Me.UiPanelScanDocument.Layout = New Resco.UIElements.ElementLayout(Resco.UIElements.HAlignment.Stretch, Resco.UIElements.VAlignment.Stretch, 0, 0, 0, 0, 240, 400)
        Me.UiPanelScanDocument.Name = "UiPanelScanDocument"
        '
        'UiEtiquetaTitulo
        '
        Me.UiEtiquetaTitulo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.UiEtiquetaTitulo.ForeColor = System.Drawing.Color.White
        Me.UiEtiquetaTitulo.Layout = New Resco.UIElements.ElementLayout(Resco.UIElements.HAlignment.Left, Resco.UIElements.VAlignment.Top, 9, 79, 0, 0, 108, 15)
        Me.UiEtiquetaTitulo.Name = "UiEtiquetaTitulo"
        Me.UiEtiquetaTitulo.Text = "Ingresar documento"
        '
        'UiTextoDocumento
        '
        Me.UiTextoDocumento.Buttons.Add(Me.UiTextBoxButton1)
        Me.UiTextoDocumento.Buttons.Add(Me.UiTextBoxButton2)
        Me.UiTextoDocumento.Layout = New Resco.UIElements.ElementLayout(Resco.UIElements.HAlignment.Stretch, Resco.UIElements.VAlignment.Top, 9, 112, 6, 0, 225, 32)
        Me.UiTextoDocumento.Name = "UiTextoDocumento"
        Me.UiTextoDocumento.TabIndex = 1
        '
        'UiTextBoxButton1
        '
        Me.UiTextBoxButton1.Action = Resco.UIElements.TextBoxAction.Clear
        Me.UiTextBoxButton1.BackColor = System.Drawing.Color.Transparent
        Me.UiTextBoxButton1.BorderThickness = 0
        Me.UiTextBoxButton1.HorizontalAlignment = Resco.UIElements.HAlignment.Right
        Me.UiTextBoxButton1.Name = "UiTextBoxButton1"
        Me.UiTextBoxButton1.PressedBackground.BackColor = System.Drawing.Color.Transparent
        Me.UiTextBoxButton1.Size = New System.Drawing.Size(18, 18)
        Me.UiTextBoxButton1.StateIcon = Resco.UIElements.StateIcon.Delete
        Me.UiTextBoxButton1.VisibleMode = Resco.UIElements.UITextBoxButtonVisibleMode.WhileEditing
        '
        'UiTextBoxButton2
        '
        Me.UiTextBoxButton2.Name = "UiTextBoxButton2"
        '
        'UiBotonGenerar
        '
        Me.UiBotonGenerar.BackgroundGradient = New Resco.Drawing.GradientColor(System.Drawing.Color.Gray, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Black, 50, 50, Resco.Drawing.FillDirection.Vertical)
        Me.UiBotonGenerar.BorderColor = System.Drawing.Color.Orange
        Me.UiBotonGenerar.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.UiBotonGenerar.ForeColor = System.Drawing.Color.White
        Me.UiBotonGenerar.Layout = New Resco.UIElements.ElementLayout(Resco.UIElements.HAlignment.Left, Resco.UIElements.VAlignment.Top, 31, 177, 0, 0, 186, 61)
        Me.UiBotonGenerar.Name = "UiBotonGenerar"
        Me.UiBotonGenerar.TabIndex = 2
        Me.UiBotonGenerar.Text = "Generar Tareas"
        '
        'UiElementPanelControl1
        '
        Me.UiElementPanelControl1.Children.Add(Me.UiPanelScanDocument)
        Me.UiElementPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiElementPanelControl1.Name = "UiElementPanelControl1"
        Me.UiElementPanelControl1.Size = New System.Drawing.Size(240, 400)
        '
        'ctrl_ScanDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.UiElementPanelControl1)
        Me.Name = "ctrl_ScanDocument"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.UiElementPanelControl1.ResumeElementLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UiPanelScanDocument As Resco.UIElements.UIPanel
    Friend WithEvents UiEtiquetaTitulo As Resco.UIElements.UILabel
    Friend WithEvents UiTextoDocumento As Resco.UIElements.UITextBox
    Friend WithEvents UiTextBoxButton1 As Resco.UIElements.UITextBoxButton
    Friend WithEvents UiTextBoxButton2 As Resco.UIElements.UITextBoxButton
    Friend WithEvents UiElementPanelControl1 As Resco.UIElements.Controls.UIElementPanelControl
    Friend WithEvents UiBotonGenerar As Resco.UIElements.UIButton


End Class

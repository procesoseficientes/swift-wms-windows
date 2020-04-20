<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_RECFIS_LogisInfo
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
        Me.lblVolumen = New Resco.Controls.CommonControls.TransparentLabel
        Me.lblPeso = New Resco.Controls.CommonControls.TransparentLabel
        Me.lblSerie = New Resco.Controls.CommonControls.TransparentLabel
        Me.txtVolumen = New Resco.Controls.CommonControls.TouchTextBox
        Me.txtPeso = New Resco.Controls.CommonControls.TouchTextBox
        Me.txtSerie = New Resco.Controls.CommonControls.TouchTextBox
        Me.txtComments = New Resco.Controls.CommonControls.TouchTextBox
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPeso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSerie, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblVolumen
        '
        Me.lblVolumen.AutoSize = False
        Me.lblVolumen.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblVolumen.ForeColor = System.Drawing.Color.White
        Me.lblVolumen.Location = New System.Drawing.Point(15, 43)
        Me.lblVolumen.Name = "lblVolumen"
        Me.lblVolumen.Size = New System.Drawing.Size(89, 25)
        Me.lblVolumen.Text = "Volumen:"
        '
        'lblPeso
        '
        Me.lblPeso.AutoSize = False
        Me.lblPeso.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblPeso.ForeColor = System.Drawing.Color.White
        Me.lblPeso.Location = New System.Drawing.Point(15, 109)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.Size = New System.Drawing.Size(89, 25)
        Me.lblPeso.Text = "Peso:"
        '
        'lblSerie
        '
        Me.lblSerie.AutoSize = False
        Me.lblSerie.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.lblSerie.ForeColor = System.Drawing.Color.White
        Me.lblSerie.Location = New System.Drawing.Point(15, 185)
        Me.lblSerie.Name = "lblSerie"
        Me.lblSerie.Size = New System.Drawing.Size(89, 25)
        Me.lblSerie.Text = "Serie:"
        '
        'txtVolumen
        '
        Me.txtVolumen.BackColor = System.Drawing.Color.White
        Me.txtVolumen.BorderColor = System.Drawing.Color.Goldenrod
        Me.txtVolumen.BorderSize = 2
        Me.txtVolumen.DisabledForeColor = System.Drawing.SystemColors.Control
        Me.txtVolumen.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtVolumen.Location = New System.Drawing.Point(15, 74)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(208, 29)
        Me.txtVolumen.TabIndex = 0
        Me.txtVolumen.Text = "1"
        Me.txtVolumen.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPeso
        '
        Me.txtPeso.BackColor = System.Drawing.Color.White
        Me.txtPeso.BorderColor = System.Drawing.Color.Goldenrod
        Me.txtPeso.BorderSize = 2
        Me.txtPeso.DisabledForeColor = System.Drawing.SystemColors.Control
        Me.txtPeso.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtPeso.Location = New System.Drawing.Point(15, 140)
        Me.txtPeso.Name = "txtPeso"
        Me.txtPeso.Size = New System.Drawing.Size(208, 29)
        Me.txtPeso.TabIndex = 1
        Me.txtPeso.Text = "1"
        Me.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSerie
        '
        Me.txtSerie.BackColor = System.Drawing.Color.White
        Me.txtSerie.BorderColor = System.Drawing.Color.Goldenrod
        Me.txtSerie.BorderSize = 2
        Me.txtSerie.DisabledForeColor = System.Drawing.SystemColors.Control
        Me.txtSerie.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtSerie.Location = New System.Drawing.Point(15, 216)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(208, 29)
        Me.txtSerie.TabIndex = 2
        Me.txtSerie.Text = "1"
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtComments
        '
        Me.txtComments.BackColor = System.Drawing.Color.White
        Me.txtComments.BorderColor = System.Drawing.Color.Goldenrod
        Me.txtComments.BorderSize = 2
        Me.txtComments.CharacterCasing = Resco.Controls.CommonControls.TouchTextBoxCharacterCasing.Upper
        Me.txtComments.DefaultText = "Comentarios"
        Me.txtComments.DisabledForeColor = System.Drawing.SystemColors.Control
        Me.txtComments.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtComments.Location = New System.Drawing.Point(15, 263)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(208, 121)
        Me.txtComments.TabIndex = 3
        Me.txtComments.Text = "..."
        '
        'ctrl_RECFIS_LogisInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.txtSerie)
        Me.Controls.Add(Me.txtPeso)
        Me.Controls.Add(Me.txtVolumen)
        Me.Controls.Add(Me.lblSerie)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.lblVolumen)
        Me.Controls.Add(Me.lblTitle)
        Me.Name = "ctrl_RECFIS_LogisInfo"
        Me.Size = New System.Drawing.Size(240, 400)
        CType(Me.lblTitle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPeso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSerie, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTitle As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents lblVolumen As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents lblPeso As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents lblSerie As Resco.Controls.CommonControls.TransparentLabel
    Friend WithEvents txtVolumen As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents txtPeso As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents txtSerie As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents txtComments As Resco.Controls.CommonControls.TouchTextBox

End Class

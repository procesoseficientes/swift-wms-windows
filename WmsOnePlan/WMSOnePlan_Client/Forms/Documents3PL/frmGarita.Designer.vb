<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGarita
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGarita))
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.btnEnSitio = New DevExpress.XtraEditors.SimpleButton()
        Me.txtDocId = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.lblFecha = New DevExpress.XtraEditors.LabelControl()
        Me.txtContenedor = New DevExpress.XtraEditors.TextEdit()
        Me.txtAduana = New DevExpress.XtraEditors.TextEdit()
        Me.txtPolizas = New DevExpress.XtraEditors.TextEdit()
        Me.btnDocumento = New DevExpress.XtraEditors.ButtonEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtDocId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtContenedor.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAduana.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPolizas.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDocumento.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.btnEnSitio)
        Me.GroupControl1.Controls.Add(Me.txtDocId)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.lblFecha)
        Me.GroupControl1.Controls.Add(Me.txtContenedor)
        Me.GroupControl1.Controls.Add(Me.txtAduana)
        Me.GroupControl1.Controls.Add(Me.txtPolizas)
        Me.GroupControl1.Controls.Add(Me.btnDocumento)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(608, 180)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Escaneo de Entradas o pases de salida..."
        '
        'btnEnSitio
        '
        Me.btnEnSitio.Image = CType(resources.GetObject("btnEnSitio.Image"), System.Drawing.Image)
        Me.btnEnSitio.Location = New System.Drawing.Point(414, 40)
        Me.btnEnSitio.Name = "btnEnSitio"
        Me.btnEnSitio.Size = New System.Drawing.Size(84, 44)
        Me.btnEnSitio.TabIndex = 11
        Me.btnEnSitio.Text = "Aceptar"
        Me.btnEnSitio.Visible = False
        '
        'txtDocId
        '
        Me.txtDocId.Enabled = False
        Me.txtDocId.Location = New System.Drawing.Point(166, 63)
        Me.txtDocId.Name = "txtDocId"
        Me.txtDocId.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtDocId.Properties.Appearance.Options.UseBackColor = True
        Me.txtDocId.Size = New System.Drawing.Size(242, 20)
        Me.txtDocId.TabIndex = 10
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(17, 66)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(143, 13)
        Me.LabelControl5.TabIndex = 9
        Me.LabelControl5.Text = "Se escaneo la Carta de Cupo:"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(17, 144)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(61, 13)
        Me.LabelControl4.TabIndex = 8
        Me.LabelControl4.Text = "Contenedor:"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(17, 118)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(81, 13)
        Me.LabelControl3.TabIndex = 7
        Me.LabelControl3.Text = "Nombre Aduana:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(17, 92)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(36, 13)
        Me.LabelControl2.TabIndex = 6
        Me.LabelControl2.Text = "Polizas:"
        '
        'lblFecha
        '
        Me.lblFecha.Location = New System.Drawing.Point(17, 205)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(4, 13)
        Me.lblFecha.TabIndex = 5
        Me.lblFecha.Text = "."
        '
        'txtContenedor
        '
        Me.txtContenedor.Enabled = False
        Me.txtContenedor.Location = New System.Drawing.Point(132, 141)
        Me.txtContenedor.Name = "txtContenedor"
        Me.txtContenedor.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtContenedor.Properties.Appearance.Options.UseBackColor = True
        Me.txtContenedor.Size = New System.Drawing.Size(276, 20)
        Me.txtContenedor.TabIndex = 4
        '
        'txtAduana
        '
        Me.txtAduana.Enabled = False
        Me.txtAduana.Location = New System.Drawing.Point(132, 115)
        Me.txtAduana.Name = "txtAduana"
        Me.txtAduana.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtAduana.Properties.Appearance.Options.UseBackColor = True
        Me.txtAduana.Size = New System.Drawing.Size(276, 20)
        Me.txtAduana.TabIndex = 3
        '
        'txtPolizas
        '
        Me.txtPolizas.Enabled = False
        Me.txtPolizas.Location = New System.Drawing.Point(132, 89)
        Me.txtPolizas.Name = "txtPolizas"
        Me.txtPolizas.Properties.Appearance.BackColor = System.Drawing.Color.LightYellow
        Me.txtPolizas.Properties.Appearance.Options.UseBackColor = True
        Me.txtPolizas.Size = New System.Drawing.Size(276, 20)
        Me.txtPolizas.TabIndex = 2
        '
        'btnDocumento
        '
        Me.btnDocumento.Location = New System.Drawing.Point(132, 37)
        Me.btnDocumento.Name = "btnDocumento"
        Me.btnDocumento.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.btnDocumento.Size = New System.Drawing.Size(276, 20)
        Me.btnDocumento.TabIndex = 1
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(17, 40)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(113, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Escanee carta de cupo:"
        '
        'frmGarita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 202)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "frmGarita"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Garita"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtDocId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtContenedor.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAduana.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPolizas.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDocumento.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents lblFecha As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtContenedor As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAduana As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPolizas As DevExpress.XtraEditors.TextEdit
    Friend WithEvents btnDocumento As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDocId As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnEnSitio As DevExpress.XtraEditors.SimpleButton
End Class

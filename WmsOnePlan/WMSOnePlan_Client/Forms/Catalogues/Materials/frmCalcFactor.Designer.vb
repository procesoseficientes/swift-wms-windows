<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcFactor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.txtAncho = New DevExpress.XtraEditors.CalcEdit
        Me.txtLargo = New DevExpress.XtraEditors.CalcEdit
        Me.txtAlto = New DevExpress.XtraEditors.CalcEdit
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.txtAncho.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLargo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.SimpleButton2)
        Me.GroupControl1.Controls.Add(Me.txtAncho)
        Me.GroupControl1.Controls.Add(Me.txtLargo)
        Me.GroupControl1.Controls.Add(Me.txtAlto)
        Me.GroupControl1.Controls.Add(Me.SimpleButton1)
        Me.GroupControl1.Controls.Add(Me.LabelControl6)
        Me.GroupControl1.Controls.Add(Me.LabelControl5)
        Me.GroupControl1.Controls.Add(Me.LabelControl4)
        Me.GroupControl1.Controls.Add(Me.PictureBox1)
        Me.GroupControl1.Controls.Add(Me.LabelControl3)
        Me.GroupControl1.Controls.Add(Me.LabelControl2)
        Me.GroupControl1.Controls.Add(Me.LabelControl1)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(366, 186)
        Me.GroupControl1.TabIndex = 0
        Me.GroupControl1.Text = "Calculo del factor volumetrico"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Location = New System.Drawing.Point(254, 137)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton2.TabIndex = 10
        Me.SimpleButton2.Text = "&Salir"
        '
        'txtAncho
        '
        Me.txtAncho.Location = New System.Drawing.Point(254, 82)
        Me.txtAncho.Name = "txtAncho"
        Me.txtAncho.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtAncho.Size = New System.Drawing.Size(75, 20)
        Me.txtAncho.TabIndex = 2
        '
        'txtLargo
        '
        Me.txtLargo.Location = New System.Drawing.Point(255, 56)
        Me.txtLargo.Name = "txtLargo"
        Me.txtLargo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtLargo.Size = New System.Drawing.Size(75, 20)
        Me.txtLargo.TabIndex = 1
        '
        'txtAlto
        '
        Me.txtAlto.Location = New System.Drawing.Point(255, 30)
        Me.txtAlto.Name = "txtAlto"
        Me.txtAlto.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAlto.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtAlto.Size = New System.Drawing.Size(75, 20)
        Me.txtAlto.TabIndex = 0
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Location = New System.Drawing.Point(254, 108)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(75, 23)
        Me.SimpleButton1.TabIndex = 3
        Me.SimpleButton1.Text = "&Aceptar"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(335, 82)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl6.TabIndex = 9
        Me.LabelControl6.Text = "cm."
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(335, 56)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl5.TabIndex = 8
        Me.LabelControl5.Text = "cm."
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(335, 30)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(17, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "cm."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.EjemploCaja
        Me.PictureBox1.Location = New System.Drawing.Point(5, 23)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(211, 144)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(222, 82)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(30, 13)
        Me.LabelControl3.TabIndex = 2
        Me.LabelControl3.Text = "Ancho"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(222, 56)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(27, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Largo"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(222, 30)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(19, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Alto"
        '
        'frmCalcFactor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 186)
        Me.Controls.Add(Me.GroupControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmCalcFactor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calculo del factor"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.txtAncho.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLargo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAncho As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents txtLargo As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents txtAlto As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class

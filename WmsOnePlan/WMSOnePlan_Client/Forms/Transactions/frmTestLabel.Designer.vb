<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestLabel
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtPrinter = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtDireccion = New System.Windows.Forms.TextBox
        Me.txtPedido = New System.Windows.Forms.TextBox
        Me.txtRuta = New System.Windows.Forms.TextBox
        Me.txtSector = New System.Windows.Forms.TextBox
        Me.txtBultos = New System.Windows.Forms.TextBox
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.txtSpare_Nombre = New System.Windows.Forms.TextBox
        Me.txtSpare_Direccion = New System.Windows.Forms.TextBox
        Me.txtDireccion2 = New System.Windows.Forms.TextBox
        Me.txtSpareDir2 = New System.Windows.Forms.TextBox
        Me.txtSpareDir3 = New System.Windows.Forms.TextBox
        Me.txtDireccion3 = New System.Windows.Forms.TextBox
        Me.txtSparePedido = New System.Windows.Forms.TextBox
        Me.txtSpareRuta = New System.Windows.Forms.TextBox
        Me.txtSpareSector = New System.Windows.Forms.TextBox
        Me.txtSpareFecha = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSpareBulto = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(579, 478)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PrinterName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Direccion:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Pedido:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 219)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Ruta:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Sector:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 318)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Bultos:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 417)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Usuario:"
        '
        'txtPrinter
        '
        Me.txtPrinter.Location = New System.Drawing.Point(119, 15)
        Me.txtPrinter.Name = "txtPrinter"
        Me.txtPrinter.Size = New System.Drawing.Size(301, 20)
        Me.txtPrinter.TabIndex = 10
        Me.txtPrinter.Text = "ZDesigner ZM400 200 dpi (ZPL) (Copy 1)"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(119, 41)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(301, 20)
        Me.txtNombre.TabIndex = 11
        Me.txtNombre.Text = "CARLA VIVIANA VASQUEZ RAMIREZ"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(119, 76)
        Me.txtDireccion.Multiline = True
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(301, 29)
        Me.txtDireccion.TabIndex = 12
        Me.txtDireccion.Text = "98765432109876543213210"
        '
        'txtPedido
        '
        Me.txtPedido.Location = New System.Drawing.Point(119, 179)
        Me.txtPedido.Multiline = True
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(91, 27)
        Me.txtPedido.TabIndex = 13
        Me.txtPedido.Text = "300196521"
        '
        'txtRuta
        '
        Me.txtRuta.Location = New System.Drawing.Point(119, 219)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.Size = New System.Drawing.Size(91, 20)
        Me.txtRuta.TabIndex = 14
        Me.txtRuta.Text = "ZACC36A02"
        '
        'txtSector
        '
        Me.txtSector.Location = New System.Drawing.Point(119, 252)
        Me.txtSector.Name = "txtSector"
        Me.txtSector.Size = New System.Drawing.Size(91, 20)
        Me.txtSector.TabIndex = 15
        Me.txtSector.Text = "36"
        '
        'txtBultos
        '
        Me.txtBultos.Location = New System.Drawing.Point(119, 318)
        Me.txtBultos.Name = "txtBultos"
        Me.txtBultos.Size = New System.Drawing.Size(91, 20)
        Me.txtBultos.TabIndex = 17
        Me.txtBultos.Text = "1"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(119, 417)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(91, 20)
        Me.txtUsuario.TabIndex = 18
        Me.txtUsuario.Text = "CXETEY"
        '
        'txtSpare_Nombre
        '
        Me.txtSpare_Nombre.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpare_Nombre.Location = New System.Drawing.Point(426, 41)
        Me.txtSpare_Nombre.Multiline = True
        Me.txtSpare_Nombre.Name = "txtSpare_Nombre"
        Me.txtSpare_Nombre.Size = New System.Drawing.Size(301, 29)
        Me.txtSpare_Nombre.TabIndex = 19
        Me.txtSpare_Nombre.Text = "^FO15,10^A0N,80,50^FN4^FS(NOMBRE)"
        '
        'txtSpare_Direccion
        '
        Me.txtSpare_Direccion.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpare_Direccion.Location = New System.Drawing.Point(426, 76)
        Me.txtSpare_Direccion.Multiline = True
        Me.txtSpare_Direccion.Name = "txtSpare_Direccion"
        Me.txtSpare_Direccion.Size = New System.Drawing.Size(301, 29)
        Me.txtSpare_Direccion.TabIndex = 20
        Me.txtSpare_Direccion.Text = "^FO15,90^AAN,30,20^FN9^FS(direccion1)"
        '
        'txtDireccion2
        '
        Me.txtDireccion2.Location = New System.Drawing.Point(119, 112)
        Me.txtDireccion2.Multiline = True
        Me.txtDireccion2.Name = "txtDireccion2"
        Me.txtDireccion2.Size = New System.Drawing.Size(301, 28)
        Me.txtDireccion2.TabIndex = 21
        Me.txtDireccion2.Text = "123456789012345678901234567890"
        '
        'txtSpareDir2
        '
        Me.txtSpareDir2.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpareDir2.Location = New System.Drawing.Point(426, 111)
        Me.txtSpareDir2.Multiline = True
        Me.txtSpareDir2.Name = "txtSpareDir2"
        Me.txtSpareDir2.Size = New System.Drawing.Size(301, 29)
        Me.txtSpareDir2.TabIndex = 22
        Me.txtSpareDir2.Text = "^FO15,125^AAN,25,15^FN10^FS"
        '
        'txtSpareDir3
        '
        Me.txtSpareDir3.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpareDir3.Location = New System.Drawing.Point(426, 146)
        Me.txtSpareDir3.Multiline = True
        Me.txtSpareDir3.Name = "txtSpareDir3"
        Me.txtSpareDir3.Size = New System.Drawing.Size(301, 27)
        Me.txtSpareDir3.TabIndex = 24
        Me.txtSpareDir3.Text = "^FO15,155^AAN,25,15^FN11^FS^FO15,190^GB740,0,5^FS"
        '
        'txtDireccion3
        '
        Me.txtDireccion3.Location = New System.Drawing.Point(119, 146)
        Me.txtDireccion3.Multiline = True
        Me.txtDireccion3.Name = "txtDireccion3"
        Me.txtDireccion3.Size = New System.Drawing.Size(301, 27)
        Me.txtDireccion3.TabIndex = 23
        Me.txtDireccion3.Text = "123456789012345678901234567890"
        '
        'txtSparePedido
        '
        Me.txtSparePedido.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSparePedido.Location = New System.Drawing.Point(426, 179)
        Me.txtSparePedido.Multiline = True
        Me.txtSparePedido.Name = "txtSparePedido"
        Me.txtSparePedido.Size = New System.Drawing.Size(301, 27)
        Me.txtSparePedido.TabIndex = 25
        Me.txtSparePedido.Text = "^FO15,220^A0N,80,50^FN8^FS(pedido)"
        '
        'txtSpareRuta
        '
        Me.txtSpareRuta.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpareRuta.Location = New System.Drawing.Point(426, 212)
        Me.txtSpareRuta.Multiline = True
        Me.txtSpareRuta.Name = "txtSpareRuta"
        Me.txtSpareRuta.Size = New System.Drawing.Size(301, 27)
        Me.txtSpareRuta.TabIndex = 26
        Me.txtSpareRuta.Text = "^FO15,300^A0N,80,50^FN5^FS(ruta)"
        '
        'txtSpareSector
        '
        Me.txtSpareSector.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpareSector.Location = New System.Drawing.Point(426, 245)
        Me.txtSpareSector.Multiline = True
        Me.txtSpareSector.Name = "txtSpareSector"
        Me.txtSpareSector.Size = New System.Drawing.Size(301, 27)
        Me.txtSpareSector.TabIndex = 27
        Me.txtSpareSector.Text = "^FO15,380^A0N,80,50^FN6^FS(sector)"
        '
        'txtSpareFecha
        '
        Me.txtSpareFecha.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpareFecha.Location = New System.Drawing.Point(426, 281)
        Me.txtSpareFecha.Multiline = True
        Me.txtSpareFecha.Name = "txtSpareFecha"
        Me.txtSpareFecha.Size = New System.Drawing.Size(299, 50)
        Me.txtSpareFecha.TabIndex = 28
        Me.txtSpareFecha.Text = "^FO130,950^AAN,30,20^FN12^FS^FO15,520^GB740,0,5^F^FS^FO450,190^GB0,330,5^FS(fecha" & _
            ")"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 281)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "fecha"
        '
        'txtSpareBulto
        '
        Me.txtSpareBulto.BackColor = System.Drawing.Color.YellowGreen
        Me.txtSpareBulto.Location = New System.Drawing.Point(426, 338)
        Me.txtSpareBulto.Multiline = True
        Me.txtSpareBulto.Name = "txtSpareBulto"
        Me.txtSpareBulto.Size = New System.Drawing.Size(301, 37)
        Me.txtSpareBulto.TabIndex = 30
        Me.txtSpareBulto.Text = "^FO315,985^A0N,100,60^FN14^FS(numcaja)"
        '
        'frmTestLabel
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(737, 519)
        Me.Controls.Add(Me.txtSpareBulto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtSpareFecha)
        Me.Controls.Add(Me.txtSpareSector)
        Me.Controls.Add(Me.txtSpareRuta)
        Me.Controls.Add(Me.txtSparePedido)
        Me.Controls.Add(Me.txtSpareDir3)
        Me.Controls.Add(Me.txtDireccion3)
        Me.Controls.Add(Me.txtSpareDir2)
        Me.Controls.Add(Me.txtDireccion2)
        Me.Controls.Add(Me.txtSpare_Direccion)
        Me.Controls.Add(Me.txtSpare_Nombre)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtBultos)
        Me.Controls.Add(Me.txtSector)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.txtPedido)
        Me.Controls.Add(Me.txtDireccion)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtPrinter)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTestLabel"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmTestLabel"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPrinter As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion As System.Windows.Forms.TextBox
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtSector As System.Windows.Forms.TextBox
    Friend WithEvents txtBultos As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtSpare_Nombre As System.Windows.Forms.TextBox
    Friend WithEvents txtSpare_Direccion As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSpareDir2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSpareDir3 As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccion3 As System.Windows.Forms.TextBox
    Friend WithEvents txtSparePedido As System.Windows.Forms.TextBox
    Friend WithEvents txtSpareRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtSpareSector As System.Windows.Forms.TextBox
    Friend WithEvents txtSpareFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSpareBulto As System.Windows.Forms.TextBox

End Class

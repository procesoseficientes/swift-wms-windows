<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintLast
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
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.grpFactura = New System.Windows.Forms.GroupBox
        Me.grpPedido = New System.Windows.Forms.GroupBox
        Me.btnCambiarCajas = New System.Windows.Forms.Button
        Me.lblTotalCajas = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtCajas = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnVerInfo = New System.Windows.Forms.Button
        Me.lblRuta = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblSector = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblCliente = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtPedido = New System.Windows.Forms.TextBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lblInputTitle = New System.Windows.Forms.Label
        Me.RB_Invoice = New System.Windows.Forms.RadioButton
        Me.RB_Label = New System.Windows.Forms.RadioButton
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grpFactura.SuspendLayout()
        Me.grpPedido.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(198, 252)
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
        Me.OK_Button.Text = "Imprimir"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Salir"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.AllowPrintToFile = False
        Me.PrintDialog1.UseEXDialog = True
        '
        'grpFactura
        '
        Me.grpFactura.Controls.Add(Me.TextBox1)
        Me.grpFactura.Controls.Add(Me.lblInputTitle)
        Me.grpFactura.Controls.Add(Me.RB_Invoice)
        Me.grpFactura.Controls.Add(Me.RB_Label)
        Me.grpFactura.Location = New System.Drawing.Point(12, 12)
        Me.grpFactura.Name = "grpFactura"
        Me.grpFactura.Size = New System.Drawing.Size(352, 234)
        Me.grpFactura.TabIndex = 1
        Me.grpFactura.TabStop = False
        Me.grpFactura.Text = "Elemento a Imprimir "
        '
        'grpPedido
        '
        Me.grpPedido.Controls.Add(Me.btnCambiarCajas)
        Me.grpPedido.Controls.Add(Me.lblTotalCajas)
        Me.grpPedido.Controls.Add(Me.Label7)
        Me.grpPedido.Controls.Add(Me.Label5)
        Me.grpPedido.Controls.Add(Me.txtCajas)
        Me.grpPedido.Controls.Add(Me.Label3)
        Me.grpPedido.Controls.Add(Me.btnVerInfo)
        Me.grpPedido.Controls.Add(Me.lblRuta)
        Me.grpPedido.Controls.Add(Me.Label6)
        Me.grpPedido.Controls.Add(Me.lblSector)
        Me.grpPedido.Controls.Add(Me.Label4)
        Me.grpPedido.Controls.Add(Me.lblCliente)
        Me.grpPedido.Controls.Add(Me.Label2)
        Me.grpPedido.Controls.Add(Me.Label1)
        Me.grpPedido.Controls.Add(Me.txtPedido)
        Me.grpPedido.Location = New System.Drawing.Point(12, 12)
        Me.grpPedido.Name = "grpPedido"
        Me.grpPedido.Size = New System.Drawing.Size(344, 234)
        Me.grpPedido.TabIndex = 2
        Me.grpPedido.TabStop = False
        Me.grpPedido.Text = "Reimprimir Etiquetas"
        '
        'btnCambiarCajas
        '
        Me.btnCambiarCajas.Location = New System.Drawing.Point(194, 129)
        Me.btnCambiarCajas.Name = "btnCambiarCajas"
        Me.btnCambiarCajas.Size = New System.Drawing.Size(75, 23)
        Me.btnCambiarCajas.TabIndex = 14
        Me.btnCambiarCajas.Text = "<-- Cambiar"
        Me.btnCambiarCajas.UseVisualStyleBackColor = True
        '
        'lblTotalCajas
        '
        Me.lblTotalCajas.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTotalCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCajas.Location = New System.Drawing.Point(127, 132)
        Me.lblTotalCajas.Name = "lblTotalCajas"
        Me.lblTotalCajas.Size = New System.Drawing.Size(60, 20)
        Me.lblTotalCajas.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 132)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Total de Cajas:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(8, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(305, 28)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Ingrese numeros de caja a imprimr, separados por coma, luego haga click en el bot" & _
            "on ""Imprimir"""
        '
        'txtCajas
        '
        Me.txtCajas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCajas.Location = New System.Drawing.Point(139, 161)
        Me.txtCajas.Name = "txtCajas"
        Me.txtCajas.Size = New System.Drawing.Size(174, 26)
        Me.txtCajas.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Cajas a Imprimir:"
        '
        'btnVerInfo
        '
        Me.btnVerInfo.Location = New System.Drawing.Point(248, 19)
        Me.btnVerInfo.Name = "btnVerInfo"
        Me.btnVerInfo.Size = New System.Drawing.Size(54, 23)
        Me.btnVerInfo.TabIndex = 8
        Me.btnVerInfo.Text = "Ver Info"
        Me.btnVerInfo.UseVisualStyleBackColor = True
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.Location = New System.Drawing.Point(203, 103)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(0, 20)
        Me.lblRuta.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(149, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ruta:"
        '
        'lblSector
        '
        Me.lblSector.AutoSize = True
        Me.lblSector.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSector.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSector.Location = New System.Drawing.Point(75, 103)
        Me.lblSector.Name = "lblSector"
        Me.lblSector.Size = New System.Drawing.Size(0, 20)
        Me.lblSector.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Sector:"
        '
        'lblCliente
        '
        Me.lblCliente.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(75, 51)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(264, 47)
        Me.lblCliente.TabIndex = 3
        Me.lblCliente.Text = "Pedido #:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Pedido #:"
        '
        'txtPedido
        '
        Me.txtPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPedido.Location = New System.Drawing.Point(84, 19)
        Me.txtPedido.Name = "txtPedido"
        Me.txtPedido.Size = New System.Drawing.Size(158, 26)
        Me.txtPedido.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(71, 105)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(185, 26)
        Me.TextBox1.TabIndex = 3
        '
        'lblInputTitle
        '
        Me.lblInputTitle.AutoSize = True
        Me.lblInputTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInputTitle.Location = New System.Drawing.Point(67, 82)
        Me.lblInputTitle.Name = "lblInputTitle"
        Me.lblInputTitle.Size = New System.Drawing.Size(142, 20)
        Me.lblInputTitle.TabIndex = 2
        Me.lblInputTitle.Text = "Numbero Etiqueta:"
        '
        'RB_Invoice
        '
        Me.RB_Invoice.AutoSize = True
        Me.RB_Invoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RB_Invoice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_Invoice.Location = New System.Drawing.Point(110, 29)
        Me.RB_Invoice.Name = "RB_Invoice"
        Me.RB_Invoice.Size = New System.Drawing.Size(65, 19)
        Me.RB_Invoice.TabIndex = 1
        Me.RB_Invoice.Text = "Factura"
        Me.RB_Invoice.UseVisualStyleBackColor = True
        Me.RB_Invoice.Visible = False
        '
        'RB_Label
        '
        Me.RB_Label.AutoSize = True
        Me.RB_Label.Checked = True
        Me.RB_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RB_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_Label.Location = New System.Drawing.Point(23, 29)
        Me.RB_Label.Name = "RB_Label"
        Me.RB_Label.Size = New System.Drawing.Size(69, 19)
        Me.RB_Label.TabIndex = 0
        Me.RB_Label.TabStop = True
        Me.RB_Label.Text = "Etiqueta"
        Me.RB_Label.UseVisualStyleBackColor = True
        Me.RB_Label.Visible = False
        '
        'PrintLast
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(369, 290)
        Me.Controls.Add(Me.grpPedido)
        Me.Controls.Add(Me.grpFactura)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PrintLast"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Servicio de Reimpresion"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.grpFactura.ResumeLayout(False)
        Me.grpFactura.PerformLayout()
        Me.grpPedido.ResumeLayout(False)
        Me.grpPedido.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents grpFactura As System.Windows.Forms.GroupBox
    Friend WithEvents RB_Label As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lblInputTitle As System.Windows.Forms.Label
    Friend WithEvents RB_Invoice As System.Windows.Forms.RadioButton
    Friend WithEvents grpPedido As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPedido As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSector As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnVerInfo As System.Windows.Forms.Button
    Friend WithEvents txtCajas As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotalCajas As System.Windows.Forms.Label
    Friend WithEvents btnCambiarCajas As System.Windows.Forms.Button

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RptQuotaInputData
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
        Me.DataCupo = New System.Windows.Forms.GroupBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.TxtFirma = New System.Windows.Forms.TextBox()
        Me.TxtMedida = New System.Windows.Forms.TextBox()
        Me.TxtPoliza = New System.Windows.Forms.TextBox()
        Me.LblFirma = New System.Windows.Forms.Label()
        Me.LblMedida = New System.Windows.Forms.Label()
        Me.LblPoliza = New System.Windows.Forms.Label()
        Me.DataCupo.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataCupo
        '
        Me.DataCupo.Controls.Add(Me.BtnPrint)
        Me.DataCupo.Controls.Add(Me.TxtFirma)
        Me.DataCupo.Controls.Add(Me.TxtMedida)
        Me.DataCupo.Controls.Add(Me.TxtPoliza)
        Me.DataCupo.Controls.Add(Me.LblFirma)
        Me.DataCupo.Controls.Add(Me.LblMedida)
        Me.DataCupo.Controls.Add(Me.LblPoliza)
        Me.DataCupo.Location = New System.Drawing.Point(12, 12)
        Me.DataCupo.Name = "DataCupo"
        Me.DataCupo.Size = New System.Drawing.Size(400, 240)
        Me.DataCupo.TabIndex = 1
        Me.DataCupo.TabStop = False
        Me.DataCupo.Text = "Datos Carta Cupo"
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(306, 192)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(56, 33)
        Me.BtnPrint.TabIndex = 6
        Me.BtnPrint.Text = "Imprimir"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'TxtFirma
        '
        Me.TxtFirma.Location = New System.Drawing.Point(138, 166)
        Me.TxtFirma.Name = "TxtFirma"
        Me.TxtFirma.Size = New System.Drawing.Size(121, 20)
        Me.TxtFirma.TabIndex = 5
        '
        'TxtMedida
        '
        Me.TxtMedida.Location = New System.Drawing.Point(138, 113)
        Me.TxtMedida.Name = "TxtMedida"
        Me.TxtMedida.Size = New System.Drawing.Size(121, 20)
        Me.TxtMedida.TabIndex = 4
        '
        'TxtPoliza
        '
        Me.TxtPoliza.Location = New System.Drawing.Point(138, 62)
        Me.TxtPoliza.Name = "TxtPoliza"
        Me.TxtPoliza.Size = New System.Drawing.Size(121, 20)
        Me.TxtPoliza.TabIndex = 3
        '
        'LblFirma
        '
        Me.LblFirma.AutoSize = True
        Me.LblFirma.Location = New System.Drawing.Point(16, 166)
        Me.LblFirma.Name = "LblFirma"
        Me.LblFirma.Size = New System.Drawing.Size(72, 13)
        Me.LblFirma.TabIndex = 2
        Me.LblFirma.Text = "Nombre Firma"
        '
        'LblMedida
        '
        Me.LblMedida.AutoSize = True
        Me.LblMedida.Location = New System.Drawing.Point(16, 120)
        Me.LblMedida.Name = "LblMedida"
        Me.LblMedida.Size = New System.Drawing.Size(97, 13)
        Me.LblMedida.TabIndex = 1
        Me.LblMedida.Text = "Unidad de Medida:"
        '
        'LblPoliza
        '
        Me.LblPoliza.AutoSize = True
        Me.LblPoliza.Location = New System.Drawing.Point(16, 62)
        Me.LblPoliza.Name = "LblPoliza"
        Me.LblPoliza.Size = New System.Drawing.Size(49, 13)
        Me.LblPoliza.TabIndex = 0
        Me.LblPoliza.Text = "Regimen"
        '
        'RptQuotaInputData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 261)
        Me.Controls.Add(Me.DataCupo)
        Me.Name = "RptQuotaInputData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RptQuotaInputData"
        Me.DataCupo.ResumeLayout(False)
        Me.DataCupo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataCupo As System.Windows.Forms.GroupBox
    Friend WithEvents LblFirma As System.Windows.Forms.Label
    Friend WithEvents LblMedida As System.Windows.Forms.Label
    Friend WithEvents LblPoliza As System.Windows.Forms.Label
    Friend WithEvents TxtFirma As System.Windows.Forms.TextBox
    Friend WithEvents TxtMedida As System.Windows.Forms.TextBox
    Friend WithEvents TxtPoliza As System.Windows.Forms.TextBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
End Class

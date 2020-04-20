<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class popupList
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
        Me.UiEtiquetaTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiLista = New DevExpress.XtraEditors.ListBoxControl()
        CType(Me.UiLista,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'UiEtiquetaTitulo
        '
        Me.UiEtiquetaTitulo.Appearance.Font = New System.Drawing.Font("Tahoma", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.UiEtiquetaTitulo.Location = New System.Drawing.Point(351, 12)
        Me.UiEtiquetaTitulo.Name = "UiEtiquetaTitulo"
        Me.UiEtiquetaTitulo.Size = New System.Drawing.Size(87, 42)
        Me.UiEtiquetaTitulo.TabIndex = 0
        Me.UiEtiquetaTitulo.Text = "Titulo"
        '
        'UiLista
        '
        Me.UiLista.Location = New System.Drawing.Point(12, 80)
        Me.UiLista.Name = "UiLista"
        Me.UiLista.Size = New System.Drawing.Size(908, 518)
        Me.UiLista.TabIndex = 1
        '
        'popupList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 622)
        Me.Controls.Add(Me.UiLista)
        Me.Controls.Add(Me.UiEtiquetaTitulo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "popupList"
        Me.ShowIcon = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Listado"
        CType(Me.UiLista,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents UiEtiquetaTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiLista As DevExpress.XtraEditors.ListBoxControl
End Class

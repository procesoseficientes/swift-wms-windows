<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRectificarPoliza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRectificarPoliza))
        Me.UiPanelPrincipal = New DevExpress.XtraEditors.PanelControl()
        Me.UiEtiquetaClasePolizaTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaClasePoliza = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroDocumentoTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroDocumento = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroOrdenTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroOrden = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaPolizaTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiqeutaPoliza = New DevExpress.XtraEditors.LabelControl()
        Me.UiBotonAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.UiBotonCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.UIEtiquetaComentario = New DevExpress.XtraEditors.LabelControl()
        Me.UiMemoComentario = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.UiPanelPrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UiPanelPrincipal.SuspendLayout()
        CType(Me.UiMemoComentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiPanelPrincipal
        '
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaClasePolizaTitulo)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaClasePoliza)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaNumeroDocumentoTitulo)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaNumeroDocumento)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaNumeroOrdenTitulo)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaNumeroOrden)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiquetaPolizaTitulo)
        Me.UiPanelPrincipal.Controls.Add(Me.UiEtiqeutaPoliza)
        Me.UiPanelPrincipal.Controls.Add(Me.UiBotonAceptar)
        Me.UiPanelPrincipal.Controls.Add(Me.UiBotonCancelar)
        Me.UiPanelPrincipal.Controls.Add(Me.UIEtiquetaComentario)
        Me.UiPanelPrincipal.Controls.Add(Me.UiMemoComentario)
        Me.UiPanelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiPanelPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.UiPanelPrincipal.Name = "UiPanelPrincipal"
        Me.UiPanelPrincipal.Size = New System.Drawing.Size(435, 211)
        Me.UiPanelPrincipal.TabIndex = 15
        '
        'UiEtiquetaClasePolizaTitulo
        '
        Me.UiEtiquetaClasePolizaTitulo.Location = New System.Drawing.Point(221, 38)
        Me.UiEtiquetaClasePolizaTitulo.Name = "UiEtiquetaClasePolizaTitulo"
        Me.UiEtiquetaClasePolizaTitulo.Size = New System.Drawing.Size(75, 13)
        Me.UiEtiquetaClasePolizaTitulo.TabIndex = 27
        Me.UiEtiquetaClasePolizaTitulo.Text = "Clase de Poliza:"
        '
        'UiEtiquetaClasePoliza
        '
        Me.UiEtiquetaClasePoliza.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiquetaClasePoliza.Appearance.Options.UseFont = True
        Me.UiEtiquetaClasePoliza.Location = New System.Drawing.Point(302, 36)
        Me.UiEtiquetaClasePoliza.Name = "UiEtiquetaClasePoliza"
        Me.UiEtiquetaClasePoliza.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiquetaClasePoliza.TabIndex = 26
        Me.UiEtiquetaClasePoliza.Text = "..."
        '
        'UiEtiquetaNumeroDocumentoTitulo
        '
        Me.UiEtiquetaNumeroDocumentoTitulo.Location = New System.Drawing.Point(12, 12)
        Me.UiEtiquetaNumeroDocumentoTitulo.Name = "UiEtiquetaNumeroDocumentoTitulo"
        Me.UiEtiquetaNumeroDocumentoTitulo.Size = New System.Drawing.Size(58, 13)
        Me.UiEtiquetaNumeroDocumentoTitulo.TabIndex = 25
        Me.UiEtiquetaNumeroDocumentoTitulo.Text = "Documento:"
        '
        'UiEtiquetaNumeroDocumento
        '
        Me.UiEtiquetaNumeroDocumento.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiquetaNumeroDocumento.Appearance.Options.UseFont = True
        Me.UiEtiquetaNumeroDocumento.Location = New System.Drawing.Point(77, 10)
        Me.UiEtiquetaNumeroDocumento.Name = "UiEtiquetaNumeroDocumento"
        Me.UiEtiquetaNumeroDocumento.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiquetaNumeroDocumento.TabIndex = 24
        Me.UiEtiquetaNumeroDocumento.Text = "..."
        '
        'UiEtiquetaNumeroOrdenTitulo
        '
        Me.UiEtiquetaNumeroOrdenTitulo.Location = New System.Drawing.Point(207, 12)
        Me.UiEtiquetaNumeroOrdenTitulo.Name = "UiEtiquetaNumeroOrdenTitulo"
        Me.UiEtiquetaNumeroOrdenTitulo.Size = New System.Drawing.Size(89, 13)
        Me.UiEtiquetaNumeroOrdenTitulo.TabIndex = 23
        Me.UiEtiquetaNumeroOrdenTitulo.Text = "Numero de Orden:"
        '
        'UiEtiquetaNumeroOrden
        '
        Me.UiEtiquetaNumeroOrden.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiquetaNumeroOrden.Appearance.Options.UseFont = True
        Me.UiEtiquetaNumeroOrden.Location = New System.Drawing.Point(302, 10)
        Me.UiEtiquetaNumeroOrden.Name = "UiEtiquetaNumeroOrden"
        Me.UiEtiquetaNumeroOrden.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiquetaNumeroOrden.TabIndex = 22
        Me.UiEtiquetaNumeroOrden.Text = "..."
        '
        'UiEtiquetaPolizaTitulo
        '
        Me.UiEtiquetaPolizaTitulo.Location = New System.Drawing.Point(12, 38)
        Me.UiEtiquetaPolizaTitulo.Name = "UiEtiquetaPolizaTitulo"
        Me.UiEtiquetaPolizaTitulo.Size = New System.Drawing.Size(31, 13)
        Me.UiEtiquetaPolizaTitulo.TabIndex = 21
        Me.UiEtiquetaPolizaTitulo.Text = "Poliza:"
        '
        'UiEtiqeutaPoliza
        '
        Me.UiEtiqeutaPoliza.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiqeutaPoliza.Appearance.Options.UseFont = True
        Me.UiEtiqeutaPoliza.Location = New System.Drawing.Point(77, 36)
        Me.UiEtiqeutaPoliza.Name = "UiEtiqeutaPoliza"
        Me.UiEtiqeutaPoliza.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiqeutaPoliza.TabIndex = 20
        Me.UiEtiqeutaPoliza.Text = "..."
        '
        'UiBotonAceptar
        '
        Me.UiBotonAceptar.ImageOptions.Image = CType(resources.GetObject("UiBotonAceptar.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonAceptar.Location = New System.Drawing.Point(267, 171)
        Me.UiBotonAceptar.Name = "UiBotonAceptar"
        Me.UiBotonAceptar.Size = New System.Drawing.Size(75, 23)
        Me.UiBotonAceptar.TabIndex = 18
        Me.UiBotonAceptar.Text = "Aceptar"
        '
        'UiBotonCancelar
        '
        Me.UiBotonCancelar.ImageOptions.Image = CType(resources.GetObject("UiBotonCancelar.ImageOptions.Image"), System.Drawing.Image)
        Me.UiBotonCancelar.Location = New System.Drawing.Point(348, 171)
        Me.UiBotonCancelar.Name = "UiBotonCancelar"
        Me.UiBotonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.UiBotonCancelar.TabIndex = 19
        Me.UiBotonCancelar.Text = "Cencelar"
        '
        'UIEtiquetaComentario
        '
        Me.UIEtiquetaComentario.Location = New System.Drawing.Point(12, 63)
        Me.UIEtiquetaComentario.Name = "UIEtiquetaComentario"
        Me.UIEtiquetaComentario.Size = New System.Drawing.Size(59, 13)
        Me.UIEtiquetaComentario.TabIndex = 17
        Me.UIEtiquetaComentario.Text = "Comentario:"
        '
        'UiMemoComentario
        '
        Me.UiMemoComentario.Location = New System.Drawing.Point(77, 60)
        Me.UiMemoComentario.Name = "UiMemoComentario"
        Me.UiMemoComentario.Size = New System.Drawing.Size(346, 93)
        Me.UiMemoComentario.TabIndex = 16
        '
        'FrmRectificarPoliza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 211)
        Me.Controls.Add(Me.UiPanelPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "FrmRectificarPoliza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rectificar Poliza"
        CType(Me.UiPanelPrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UiPanelPrincipal.ResumeLayout(False)
        Me.UiPanelPrincipal.PerformLayout()
        CType(Me.UiMemoComentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiPanelPrincipal As DevExpress.XtraEditors.PanelControl
    Friend WithEvents UIEtiquetaComentario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiMemoComentario As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents UiEtiquetaPolizaTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiqeutaPoliza As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiBotonAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UiBotonCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UiEtiquetaNumeroDocumentoTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaNumeroDocumento As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaNumeroOrdenTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaNumeroOrden As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaClasePolizaTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaClasePoliza As DevExpress.XtraEditors.LabelControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRectificacionPoliza
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRectificacionPoliza))
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.UiEtiquetaNumeroDocumentoTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroDocumento = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroOrdenTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaNumeroOrden = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaPolizaTitulo = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiqeutaPoliza = New DevExpress.XtraEditors.LabelControl()
        Me.UiBotonAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.UiBotonCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.UiListaPolizasParaRectificar = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiEtiqeutaPolizasParaRectificar = New DevExpress.XtraEditors.LabelControl()
        Me.UIEtiquetaComentario = New DevExpress.XtraEditors.LabelControl()
        Me.UiMemoComentario = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.UiListaPolizasParaRectificar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UiMemoComentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UiEtiquetaNumeroDocumentoTitulo
        '
        Me.UiEtiquetaNumeroDocumentoTitulo.Location = New System.Drawing.Point(12, 12)
        Me.UiEtiquetaNumeroDocumentoTitulo.Name = "UiEtiquetaNumeroDocumentoTitulo"
        Me.UiEtiquetaNumeroDocumentoTitulo.Size = New System.Drawing.Size(58, 13)
        Me.UiEtiquetaNumeroDocumentoTitulo.TabIndex = 37
        Me.UiEtiquetaNumeroDocumentoTitulo.Text = "Documento:"
        '
        'UiEtiquetaNumeroDocumento
        '
        Me.UiEtiquetaNumeroDocumento.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiquetaNumeroDocumento.Location = New System.Drawing.Point(77, 10)
        Me.UiEtiquetaNumeroDocumento.Name = "UiEtiquetaNumeroDocumento"
        Me.UiEtiquetaNumeroDocumento.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiquetaNumeroDocumento.TabIndex = 36
        Me.UiEtiquetaNumeroDocumento.Text = "..."
        '
        'UiEtiquetaNumeroOrdenTitulo
        '
        Me.UiEtiquetaNumeroOrdenTitulo.Location = New System.Drawing.Point(183, 12)
        Me.UiEtiquetaNumeroOrdenTitulo.Name = "UiEtiquetaNumeroOrdenTitulo"
        Me.UiEtiquetaNumeroOrdenTitulo.Size = New System.Drawing.Size(89, 13)
        Me.UiEtiquetaNumeroOrdenTitulo.TabIndex = 35
        Me.UiEtiquetaNumeroOrdenTitulo.Text = "Numero de Orden:"
        '
        'UiEtiquetaNumeroOrden
        '
        Me.UiEtiquetaNumeroOrden.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiquetaNumeroOrden.Location = New System.Drawing.Point(278, 10)
        Me.UiEtiquetaNumeroOrden.Name = "UiEtiquetaNumeroOrden"
        Me.UiEtiquetaNumeroOrden.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiquetaNumeroOrden.TabIndex = 34
        Me.UiEtiquetaNumeroOrden.Text = "..."
        '
        'UiEtiquetaPolizaTitulo
        '
        Me.UiEtiquetaPolizaTitulo.Location = New System.Drawing.Point(12, 38)
        Me.UiEtiquetaPolizaTitulo.Name = "UiEtiquetaPolizaTitulo"
        Me.UiEtiquetaPolizaTitulo.Size = New System.Drawing.Size(31, 13)
        Me.UiEtiquetaPolizaTitulo.TabIndex = 33
        Me.UiEtiquetaPolizaTitulo.Text = "Poliza:"
        '
        'UiEtiqeutaPoliza
        '
        Me.UiEtiqeutaPoliza.Appearance.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UiEtiqeutaPoliza.Location = New System.Drawing.Point(77, 36)
        Me.UiEtiqeutaPoliza.Name = "UiEtiqeutaPoliza"
        Me.UiEtiqeutaPoliza.Size = New System.Drawing.Size(12, 16)
        Me.UiEtiqeutaPoliza.TabIndex = 32
        Me.UiEtiqeutaPoliza.Text = "..."
        '
        'UiBotonAceptar
        '
        Me.UiBotonAceptar.Image = CType(resources.GetObject("UiBotonAceptar.Image"), System.Drawing.Image)
        Me.UiBotonAceptar.Location = New System.Drawing.Point(197, 214)
        Me.UiBotonAceptar.Name = "UiBotonAceptar"
        Me.UiBotonAceptar.Size = New System.Drawing.Size(75, 23)
        Me.UiBotonAceptar.TabIndex = 30
        Me.UiBotonAceptar.Text = "Aceptar"
        '
        'UiBotonCancelar
        '
        Me.UiBotonCancelar.Image = CType(resources.GetObject("UiBotonCancelar.Image"), System.Drawing.Image)
        Me.UiBotonCancelar.Location = New System.Drawing.Point(287, 214)
        Me.UiBotonCancelar.Name = "UiBotonCancelar"
        Me.UiBotonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.UiBotonCancelar.TabIndex = 31
        Me.UiBotonCancelar.Text = "Cencelar"
        '
        'UiListaPolizasParaRectificar
        '
        Me.UiListaPolizasParaRectificar.EditValue = "Seleccione una Poliza"
        Me.UiListaPolizasParaRectificar.Location = New System.Drawing.Point(12, 87)
        Me.UiListaPolizasParaRectificar.Name = "UiListaPolizasParaRectificar"
        Me.UiListaPolizasParaRectificar.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Refrescar", -1, True, True, True, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("UiListaPolizasParaRectificar.Properties.Buttons"), System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", "REFRESH", Nothing, True)})
        Me.UiListaPolizasParaRectificar.Properties.NullText = "Seleccione una Poliza..."
        Me.UiListaPolizasParaRectificar.Properties.View = Me.GridView2
        Me.UiListaPolizasParaRectificar.Size = New System.Drawing.Size(350, 22)
        Me.UiListaPolizasParaRectificar.TabIndex = 38
        '
        'GridView2
        '
        Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'UiEtiqeutaPolizasParaRectificar
        '
        Me.UiEtiqeutaPolizasParaRectificar.Location = New System.Drawing.Point(12, 68)
        Me.UiEtiqeutaPolizasParaRectificar.Name = "UiEtiqeutaPolizasParaRectificar"
        Me.UiEtiqeutaPolizasParaRectificar.Size = New System.Drawing.Size(109, 13)
        Me.UiEtiqeutaPolizasParaRectificar.TabIndex = 39
        Me.UiEtiqeutaPolizasParaRectificar.Text = "Polizas para Rectificar:"
        '
        'UIEtiquetaComentario
        '
        Me.UIEtiquetaComentario.Location = New System.Drawing.Point(12, 118)
        Me.UIEtiquetaComentario.Name = "UIEtiquetaComentario"
        Me.UIEtiquetaComentario.Size = New System.Drawing.Size(59, 13)
        Me.UIEtiquetaComentario.TabIndex = 41
        Me.UIEtiquetaComentario.Text = "Comentario:"
        '
        'UiMemoComentario
        '
        Me.UiMemoComentario.Location = New System.Drawing.Point(77, 115)
        Me.UiMemoComentario.Name = "UiMemoComentario"
        Me.UiMemoComentario.Size = New System.Drawing.Size(284, 93)
        Me.UiMemoComentario.TabIndex = 40
        '
        'FrmRectificacionPoliza
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 249)
        Me.Controls.Add(Me.UIEtiquetaComentario)
        Me.Controls.Add(Me.UiMemoComentario)
        Me.Controls.Add(Me.UiEtiqeutaPolizasParaRectificar)
        Me.Controls.Add(Me.UiListaPolizasParaRectificar)
        Me.Controls.Add(Me.UiEtiquetaNumeroDocumentoTitulo)
        Me.Controls.Add(Me.UiEtiquetaNumeroDocumento)
        Me.Controls.Add(Me.UiEtiquetaNumeroOrdenTitulo)
        Me.Controls.Add(Me.UiEtiquetaNumeroOrden)
        Me.Controls.Add(Me.UiEtiquetaPolizaTitulo)
        Me.Controls.Add(Me.UiEtiqeutaPoliza)
        Me.Controls.Add(Me.UiBotonAceptar)
        Me.Controls.Add(Me.UiBotonCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmRectificacionPoliza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRectificacionPoliza"
        CType(Me.UiListaPolizasParaRectificar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UiMemoComentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UiEtiquetaNumeroDocumentoTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaNumeroDocumento As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaNumeroOrdenTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaNumeroOrden As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaPolizaTitulo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiqeutaPoliza As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiBotonAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UiBotonCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents UiListaPolizasParaRectificar As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiEtiqeutaPolizasParaRectificar As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UIEtiquetaComentario As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiMemoComentario As DevExpress.XtraEditors.MemoEdit
End Class

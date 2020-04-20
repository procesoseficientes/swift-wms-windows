<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmIngresoTypeChange
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.menComentario = New DevExpress.XtraEditors.MemoEdit()
        Me.lblRegimen = New DevExpress.XtraEditors.LabelControl()
        Me.chekRegimenGeneral = New DevExpress.XtraEditors.CheckEdit()
        Me.chekRegimenFiscal = New DevExpress.XtraEditors.CheckEdit()
        Me.chekRegimenTodos = New DevExpress.XtraEditors.CheckEdit()
        Me.ComentarioÑ = New DevExpress.XtraEditors.LabelControl()
        Me.menDescripcion = New DevExpress.XtraEditors.MemoEdit()
        Me.cmbCobro = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnAceptar = New DevExpress.XtraEditors.SimpleButton()
        Me.btnhCancelar = New DevExpress.XtraEditors.SimpleButton()
        Me.chekHabilitadad = New DevExpress.XtraEditors.CheckEdit()
        Me.lblJornada = New DevExpress.XtraEditors.LabelControl()
        Me.cmbJornada = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.dxError = New DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(Me.components)
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.cmbTipoServicio = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.chkMovil = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.menComentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chekRegimenGeneral.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chekRegimenFiscal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chekRegimenTodos.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.menDescripcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbCobro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chekHabilitadad.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbJornada.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTipoServicio.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkMovil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(33, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Cobro:"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(11, 147)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(58, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Descripción:"
        '
        'menComentario
        '
        Me.menComentario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menComentario.Location = New System.Drawing.Point(12, 357)
        Me.menComentario.Name = "menComentario"
        Me.menComentario.Properties.MaxLength = 200
        Me.menComentario.Size = New System.Drawing.Size(538, 181)
        Me.menComentario.TabIndex = 8
        '
        'lblRegimen
        '
        Me.lblRegimen.Location = New System.Drawing.Point(12, 41)
        Me.lblRegimen.Name = "lblRegimen"
        Me.lblRegimen.Size = New System.Drawing.Size(45, 13)
        Me.lblRegimen.TabIndex = 5
        Me.lblRegimen.Text = "Regimen:"
        '
        'chekRegimenGeneral
        '
        Me.chekRegimenGeneral.Enabled = False
        Me.chekRegimenGeneral.Location = New System.Drawing.Point(150, 38)
        Me.chekRegimenGeneral.Name = "chekRegimenGeneral"
        Me.chekRegimenGeneral.Properties.Caption = "General"
        Me.chekRegimenGeneral.Size = New System.Drawing.Size(63, 19)
        Me.chekRegimenGeneral.TabIndex = 2
        '
        'chekRegimenFiscal
        '
        Me.chekRegimenFiscal.Enabled = False
        Me.chekRegimenFiscal.Location = New System.Drawing.Point(219, 38)
        Me.chekRegimenFiscal.Name = "chekRegimenFiscal"
        Me.chekRegimenFiscal.Properties.Caption = "Fiscal"
        Me.chekRegimenFiscal.Size = New System.Drawing.Size(51, 19)
        Me.chekRegimenFiscal.TabIndex = 3
        '
        'chekRegimenTodos
        '
        Me.chekRegimenTodos.EditValue = True
        Me.chekRegimenTodos.Location = New System.Drawing.Point(81, 38)
        Me.chekRegimenTodos.Name = "chekRegimenTodos"
        Me.chekRegimenTodos.Properties.Caption = "Todos"
        Me.chekRegimenTodos.Size = New System.Drawing.Size(70, 19)
        Me.chekRegimenTodos.TabIndex = 1
        '
        'ComentarioÑ
        '
        Me.ComentarioÑ.Location = New System.Drawing.Point(12, 338)
        Me.ComentarioÑ.Name = "ComentarioÑ"
        Me.ComentarioÑ.Size = New System.Drawing.Size(59, 13)
        Me.ComentarioÑ.TabIndex = 11
        Me.ComentarioÑ.Text = "Comentario:"
        '
        'menDescripcion
        '
        Me.menDescripcion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menDescripcion.Location = New System.Drawing.Point(11, 166)
        Me.menDescripcion.Name = "menDescripcion"
        Me.menDescripcion.Properties.MaxLength = 250
        Me.menDescripcion.Size = New System.Drawing.Size(538, 166)
        Me.menDescripcion.TabIndex = 7
        '
        'cmbCobro
        '
        Me.cmbCobro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCobro.Location = New System.Drawing.Point(81, 12)
        Me.cmbCobro.Name = "cmbCobro"
        Me.cmbCobro.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbCobro.Properties.Items.AddRange(New Object() {"AREA SECA", "AREA CONGELADA Y REFRIGERADA", "MANEJO DE MERCDERIA ", "OTROS TIPOS"})
        Me.cmbCobro.Size = New System.Drawing.Size(469, 20)
        Me.cmbCobro.TabIndex = 0
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(391, 544)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnhCancelar
        '
        Me.btnhCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnhCancelar.Location = New System.Drawing.Point(474, 544)
        Me.btnhCancelar.Name = "btnhCancelar"
        Me.btnhCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnhCancelar.TabIndex = 10
        Me.btnhCancelar.Text = "Cancelar"
        '
        'chekHabilitadad
        '
        Me.chekHabilitadad.Enabled = False
        Me.chekHabilitadad.Location = New System.Drawing.Point(276, 38)
        Me.chekHabilitadad.Name = "chekHabilitadad"
        Me.chekHabilitadad.Properties.Caption = "Bodega Habilitadad"
        Me.chekHabilitadad.Size = New System.Drawing.Size(117, 19)
        Me.chekHabilitadad.TabIndex = 4
        '
        'lblJornada
        '
        Me.lblJornada.Enabled = False
        Me.lblJornada.Location = New System.Drawing.Point(12, 92)
        Me.lblJornada.Name = "lblJornada"
        Me.lblJornada.Size = New System.Drawing.Size(43, 13)
        Me.lblJornada.TabIndex = 12
        Me.lblJornada.Text = "Jornada:"
        '
        'cmbJornada
        '
        Me.cmbJornada.EditValue = "N/A"
        Me.cmbJornada.Enabled = False
        Me.cmbJornada.Location = New System.Drawing.Point(81, 89)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbJornada.Properties.Items.AddRange(New Object() {"N/A", "Diurno", "Nocturno", "Fin de Semana/Dias Festivos"})
        Me.cmbJornada.Size = New System.Drawing.Size(269, 20)
        Me.cmbJornada.TabIndex = 6
        '
        'dxError
        '
        Me.dxError.ContainerControl = Me
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(11, 66)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(64, 13)
        Me.LabelControl3.TabIndex = 13
        Me.LabelControl3.Text = "Tipo Servicio:"
        '
        'cmbTipoServicio
        '
        Me.cmbTipoServicio.Location = New System.Drawing.Point(81, 63)
        Me.cmbTipoServicio.Name = "cmbTipoServicio"
        Me.cmbTipoServicio.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup
        Me.cmbTipoServicio.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbTipoServicio.Properties.NullText = ""
        Me.cmbTipoServicio.Properties.PopupFormMinSize = New System.Drawing.Size(560, 0)
        Me.cmbTipoServicio.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.cmbTipoServicio.Properties.View = Me.GridView1
        Me.cmbTipoServicio.Size = New System.Drawing.Size(468, 20)
        Me.cmbTipoServicio.TabIndex = 5
        '
        'GridView1
        '
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(11, 118)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(53, 13)
        Me.LabelControl4.TabIndex = 14
        Me.LabelControl4.Text = "Para Movil:"
        '
        'chkMovil
        '
        Me.chkMovil.Location = New System.Drawing.Point(81, 115)
        Me.chkMovil.Name = "chkMovil"
        Me.chkMovil.Properties.Caption = ""
        Me.chkMovil.Size = New System.Drawing.Size(70, 19)
        Me.chkMovil.TabIndex = 15
        '
        'FrmIngresoTypeChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(561, 579)
        Me.Controls.Add(Me.chkMovil)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.cmbTipoServicio)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.cmbJornada)
        Me.Controls.Add(Me.lblJornada)
        Me.Controls.Add(Me.chekHabilitadad)
        Me.Controls.Add(Me.btnhCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cmbCobro)
        Me.Controls.Add(Me.menDescripcion)
        Me.Controls.Add(Me.ComentarioÑ)
        Me.Controls.Add(Me.chekRegimenTodos)
        Me.Controls.Add(Me.chekRegimenFiscal)
        Me.Controls.Add(Me.chekRegimenGeneral)
        Me.Controls.Add(Me.lblRegimen)
        Me.Controls.Add(Me.menComentario)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Name = "FrmIngresoTypeChange"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ingreso de Tipo de Cobro"
        CType(Me.menComentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chekRegimenGeneral.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chekRegimenFiscal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chekRegimenTodos.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.menDescripcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbCobro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chekHabilitadad.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbJornada.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTipoServicio.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkMovil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents menComentario As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblRegimen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chekRegimenGeneral As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chekRegimenFiscal As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chekRegimenTodos As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ComentarioÑ As DevExpress.XtraEditors.LabelControl
    Friend WithEvents menDescripcion As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents cmbCobro As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnAceptar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnhCancelar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chekHabilitadad As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblJornada As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbJornada As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents dxError As DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cmbTipoServicio As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents chkMovil As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
End Class

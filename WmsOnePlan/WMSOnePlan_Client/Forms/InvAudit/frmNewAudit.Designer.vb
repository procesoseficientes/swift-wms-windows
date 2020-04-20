<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewAudit
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
        Me.WizardControl1 = New DevExpress.XtraWizard.WizardControl()
        Me.WelcomeWizardPage1 = New DevExpress.XtraWizard.WelcomeWizardPage()
        Me.WizardPage1 = New DevExpress.XtraWizard.WizardPage()
        Me.rgTipoConteo = New DevExpress.XtraEditors.RadioGroup()
        Me.CompletionWizardPage1 = New DevExpress.XtraWizard.CompletionWizardPage()
        Me.GridUbicaciones = New DevExpress.XtraGrid.GridControl()
        Me.GridViewUbicaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.WizardPage2 = New DevExpress.XtraWizard.WizardPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Filtro = New DevExpress.XtraWizard.WizardPage()
        Me.btnAgregarFiltro = New DevExpress.XtraEditors.SimpleButton()
        Me.GridFiltros = New DevExpress.XtraGrid.GridControl()
        Me.GridViewFiltros = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbOpcion = New DevExpress.XtraEditors.GridLookUpEdit()
        Me.cmbOpcionView = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cmbFiltro = New DevExpress.XtraEditors.ComboBoxEdit()
        CType(Me.WizardControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WizardControl1.SuspendLayout()
        Me.WizardPage1.SuspendLayout()
        CType(Me.rgTipoConteo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CompletionWizardPage1.SuspendLayout()
        CType(Me.GridUbicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewUbicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.WizardPage2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Filtro.SuspendLayout()
        CType(Me.GridFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOpcion.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOpcionView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFiltro.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WizardControl1
        '
        Me.WizardControl1.Controls.Add(Me.WelcomeWizardPage1)
        Me.WizardControl1.Controls.Add(Me.WizardPage1)
        Me.WizardControl1.Controls.Add(Me.CompletionWizardPage1)
        Me.WizardControl1.Controls.Add(Me.WizardPage2)
        Me.WizardControl1.Controls.Add(Me.Filtro)
        Me.WizardControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WizardControl1.Location = New System.Drawing.Point(0, 0)
        Me.WizardControl1.Name = "WizardControl1"
        Me.WizardControl1.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WelcomeWizardPage1, Me.WizardPage1, Me.Filtro, Me.WizardPage2, Me.CompletionWizardPage1})
        Me.WizardControl1.Size = New System.Drawing.Size(543, 424)
        Me.WizardControl1.Text = "Configuracion de Conteos"
        '
        'WelcomeWizardPage1
        '
        Me.WelcomeWizardPage1.IntroductionText = "El configurador de conteos lo guiara a traves del proceso de creacion de una nuev" & _
            "a auditoria"
        Me.WelcomeWizardPage1.Name = "WelcomeWizardPage1"
        Me.WelcomeWizardPage1.ProceedText = "Para avanzar, click Next"
        Me.WelcomeWizardPage1.Size = New System.Drawing.Size(326, 291)
        Me.WelcomeWizardPage1.Text = "Configurador de conteos"
        '
        'WizardPage1
        '
        Me.WizardPage1.AllowNext = False
        Me.WizardPage1.Controls.Add(Me.rgTipoConteo)
        Me.WizardPage1.DescriptionText = "Debe seleccionar un tipo de conteo a realizar"
        Me.WizardPage1.Name = "WizardPage1"
        Me.WizardPage1.Size = New System.Drawing.Size(511, 279)
        Me.WizardPage1.Text = "Tipo de Conteo"
        '
        'rgTipoConteo
        '
        Me.rgTipoConteo.Location = New System.Drawing.Point(4, 4)
        Me.rgTipoConteo.Name = "rgTipoConteo"
        Me.rgTipoConteo.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("MATERIAL_ID", "Producto"), New DevExpress.XtraEditors.Controls.RadioGroupItem("CLIENT_CODE", "Cliente"), New DevExpress.XtraEditors.Controls.RadioGroupItem("CODIGO_POLIZA", "Poliza"), New DevExpress.XtraEditors.Controls.RadioGroupItem("REGIMEN", "Regimen"), New DevExpress.XtraEditors.Controls.RadioGroupItem("WAREHOUSE_ID", "Bodega"), New DevExpress.XtraEditors.Controls.RadioGroupItem("COMPLETO", "Completo")})
        Me.rgTipoConteo.Size = New System.Drawing.Size(387, 251)
        Me.rgTipoConteo.TabIndex = 0
        '
        'CompletionWizardPage1
        '
        Me.CompletionWizardPage1.Controls.Add(Me.GridUbicaciones)
        Me.CompletionWizardPage1.FinishText = "al dar click en Finish se creara el conteo con las ubicaciones siguientes"
        Me.CompletionWizardPage1.Name = "CompletionWizardPage1"
        Me.CompletionWizardPage1.ProceedText = "para cerrar el asistente, click Finish"
        Me.CompletionWizardPage1.Size = New System.Drawing.Size(326, 291)
        Me.CompletionWizardPage1.Text = "Se procedera a crear el conteo"
        '
        'GridUbicaciones
        '
        Me.GridUbicaciones.Location = New System.Drawing.Point(4, 36)
        Me.GridUbicaciones.MainView = Me.GridViewUbicaciones
        Me.GridUbicaciones.Name = "GridUbicaciones"
        Me.GridUbicaciones.Size = New System.Drawing.Size(319, 232)
        Me.GridUbicaciones.TabIndex = 0
        Me.GridUbicaciones.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewUbicaciones})
        '
        'GridViewUbicaciones
        '
        Me.GridViewUbicaciones.GridControl = Me.GridUbicaciones
        Me.GridViewUbicaciones.Name = "GridViewUbicaciones"
        Me.GridViewUbicaciones.OptionsBehavior.Editable = False
        Me.GridViewUbicaciones.OptionsView.ShowGroupPanel = False
        '
        'WizardPage2
        '
        Me.WizardPage2.Controls.Add(Me.GridControl1)
        Me.WizardPage2.DescriptionText = "Criterios de conteo: debe seleccionar criterios de conteo segun el tipo seleccion" & _
            "ado"
        Me.WizardPage2.Name = "WizardPage2"
        Me.WizardPage2.Size = New System.Drawing.Size(511, 279)
        Me.WizardPage2.Text = "Seleccione criterios de conteo"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(511, 279)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Filtro
        '
        Me.Filtro.Controls.Add(Me.btnAgregarFiltro)
        Me.Filtro.Controls.Add(Me.GridFiltros)
        Me.Filtro.Controls.Add(Me.cmbOpcion)
        Me.Filtro.Controls.Add(Me.cmbFiltro)
        Me.Filtro.DescriptionText = "Seleccione los filtros adicionales a la forma de conteo"
        Me.Filtro.Name = "Filtro"
        Me.Filtro.Size = New System.Drawing.Size(511, 279)
        Me.Filtro.Text = "Seleccione filtros"
        '
        'btnAgregarFiltro
        '
        Me.btnAgregarFiltro.Location = New System.Drawing.Point(424, 3)
        Me.btnAgregarFiltro.Name = "btnAgregarFiltro"
        Me.btnAgregarFiltro.Size = New System.Drawing.Size(84, 44)
        Me.btnAgregarFiltro.TabIndex = 3
        Me.btnAgregarFiltro.Text = "Agregar"
        '
        'GridFiltros
        '
        Me.GridFiltros.Location = New System.Drawing.Point(4, 57)
        Me.GridFiltros.MainView = Me.GridViewFiltros
        Me.GridFiltros.Name = "GridFiltros"
        Me.GridFiltros.Size = New System.Drawing.Size(504, 219)
        Me.GridFiltros.TabIndex = 2
        Me.GridFiltros.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewFiltros})
        '
        'GridViewFiltros
        '
        Me.GridViewFiltros.GridControl = Me.GridFiltros
        Me.GridViewFiltros.Name = "GridViewFiltros"
        Me.GridViewFiltros.OptionsBehavior.Editable = False
        Me.GridViewFiltros.OptionsView.ShowGroupPanel = False
        '
        'cmbOpcion
        '
        Me.cmbOpcion.Location = New System.Drawing.Point(4, 31)
        Me.cmbOpcion.Name = "cmbOpcion"
        Me.cmbOpcion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbOpcion.Properties.NullValuePrompt = "Seleccione una opcion"
        Me.cmbOpcion.Properties.NullValuePromptShowForEmptyValue = True
        Me.cmbOpcion.Properties.View = Me.cmbOpcionView
        Me.cmbOpcion.Size = New System.Drawing.Size(414, 20)
        Me.cmbOpcion.TabIndex = 1
        '
        'cmbOpcionView
        '
        Me.cmbOpcionView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.cmbOpcionView.Name = "cmbOpcionView"
        Me.cmbOpcionView.OptionsBehavior.ReadOnly = True
        Me.cmbOpcionView.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.cmbOpcionView.OptionsView.ShowAutoFilterRow = True
        Me.cmbOpcionView.OptionsView.ShowGroupPanel = False
        '
        'cmbFiltro
        '
        Me.cmbFiltro.Location = New System.Drawing.Point(4, 4)
        Me.cmbFiltro.Name = "cmbFiltro"
        Me.cmbFiltro.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbFiltro.Properties.Items.AddRange(New Object() {"Regimen", "Cliente", "Bodega"})
        Me.cmbFiltro.Size = New System.Drawing.Size(414, 20)
        Me.cmbFiltro.TabIndex = 0
        '
        'frmNewAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 424)
        Me.Controls.Add(Me.WizardControl1)
        Me.Name = "frmNewAudit"
        Me.Text = "Nueva Auditoria de Inventario"
        CType(Me.WizardControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WizardControl1.ResumeLayout(False)
        Me.WizardPage1.ResumeLayout(False)
        CType(Me.rgTipoConteo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CompletionWizardPage1.ResumeLayout(False)
        CType(Me.GridUbicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewUbicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.WizardPage2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Filtro.ResumeLayout(False)
        CType(Me.GridFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOpcion.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOpcionView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFiltro.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WizardControl1 As DevExpress.XtraWizard.WizardControl
    Friend WithEvents WelcomeWizardPage1 As DevExpress.XtraWizard.WelcomeWizardPage
    Friend WithEvents WizardPage1 As DevExpress.XtraWizard.WizardPage
    Friend WithEvents CompletionWizardPage1 As DevExpress.XtraWizard.CompletionWizardPage
    Friend WithEvents rgTipoConteo As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents WizardPage2 As DevExpress.XtraWizard.WizardPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Filtro As DevExpress.XtraWizard.WizardPage
    Friend WithEvents btnAgregarFiltro As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GridFiltros As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewFiltros As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbOpcion As DevExpress.XtraEditors.GridLookUpEdit
    Friend WithEvents cmbOpcionView As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbFiltro As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents GridUbicaciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewUbicaciones As DevExpress.XtraGrid.Views.Grid.GridView
End Class

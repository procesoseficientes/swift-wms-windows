<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserLogin
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserLogin))
        Dim StyleFormatCondition1 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition2 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim StyleFormatCondition3 As DevExpress.XtraGrid.StyleFormatCondition = New DevExpress.XtraGrid.StyleFormatCondition()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject9 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject10 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject11 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject12 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GridColumnIsLogged = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryIsLogged = New DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup()
        Me.GridColumnStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnKillBroadcast = New System.Windows.Forms.ToolStripButton()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.btnAsociarCliente = New System.Windows.Forms.ToolStripButton()
        Me.SmallIconsList = New System.Windows.Forms.ImageList(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_Access = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_ID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Name = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Plataforma = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnEnviroment = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumnLineID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiContenedorTab = New DevExpress.XtraBars.Navigation.TabPane()
        Me.UiTabCentroDistribucion = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.UiContenedorDeVistasBodegaAsociada = New DevExpress.XtraGrid.GridControl()
        Me.UiVistaBodegasAsociadas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colEnEliminar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiBotonEliminarBodega = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.UiColCodigoBodega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreBodega = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiListaBodegasDisponibles = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.UiListavistaBodegasDisponibles = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiColCodigoBodegaDisponible = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColNombreBodegaDisponilbe = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiEtiquetaBodegasDisponibles = New DevExpress.XtraEditors.LabelControl()
        Me.UiEtiquetaCentroDistribucion = New DevExpress.XtraEditors.LabelControl()
        Me.UiListaCentroDistribucion = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.UiListaVistaCentrosDistribucion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.UiColCodigoCentroDistribucion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UiColDescripcionCentroDistribucion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.UiTabDatosGenerales = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.PropertyGridControl1 = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.PropertyDescriptionControl1 = New DevExpress.XtraVerticalGrid.PropertyDescriptionControl()
        Me.UiBarManagerCentroDistriubicion = New DevExpress.XtraBars.BarManager(Me.components)
        Me.UiBarraCentroDistribucion = New DevExpress.XtraBars.Bar()
        Me.UiBotonAgregarBodegas = New DevExpress.XtraBars.BarButtonItem()
        Me.UiColDominio = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.RepositoryIsLogged,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip1.SuspendLayout
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SplitContainer1.Panel1.SuspendLayout
        Me.SplitContainer1.Panel2.SuspendLayout
        Me.SplitContainer1.SuspendLayout
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiContenedorTab,System.ComponentModel.ISupportInitialize).BeginInit
        Me.UiContenedorTab.SuspendLayout
        Me.UiTabCentroDistribucion.SuspendLayout
        CType(Me.UiContenedorDeVistasBodegaAsociada,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiVistaBodegasAsociadas,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiBotonEliminarBodega,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaBodegasDisponibles.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListavistaBodegasDisponibles,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaCentroDistribucion.Properties,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiListaVistaCentrosDistribucion,System.ComponentModel.ISupportInitialize).BeginInit
        Me.UiTabDatosGenerales.SuspendLayout
        CType(Me.PropertyGridControl1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.UiBarManagerCentroDistriubicion,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'GridColumnIsLogged
        '
        Me.GridColumnIsLogged.Caption = "EstatusSesion"
        Me.GridColumnIsLogged.ColumnEdit = Me.RepositoryIsLogged
        Me.GridColumnIsLogged.FieldName = "IS_LOGGED"
        Me.GridColumnIsLogged.Name = "GridColumnIsLogged"
        Me.GridColumnIsLogged.OptionsColumn.AllowEdit = false
        Me.GridColumnIsLogged.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.GridColumnIsLogged.Visible = true
        Me.GridColumnIsLogged.VisibleIndex = 6
        Me.GridColumnIsLogged.Width = 90
        '
        'RepositoryIsLogged
        '
        Me.RepositoryIsLogged.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryIsLogged.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value
        Me.RepositoryIsLogged.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem(1, "LogIn"), New DevExpress.XtraEditors.Controls.RadioGroupItem(0, "LogOut")})
        Me.RepositoryIsLogged.Name = "RepositoryIsLogged"
        Me.RepositoryIsLogged.NullText = "1"
        '
        'GridColumnStatus
        '
        Me.GridColumnStatus.Caption = "Estatus"
        Me.GridColumnStatus.FieldName = "LOGIN_STATUS"
        Me.GridColumnStatus.Name = "GridColumnStatus"
        Me.GridColumnStatus.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.GridColumnStatus.Visible = true
        Me.GridColumnStatus.VisibleIndex = 5
        Me.GridColumnStatus.Width = 85
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnKillBroadcast, Me.NewToolStripButton, Me.SaveToolStripButton, Me.CutToolStripButton, Me.toolStripSeparator, Me.PrintToolStripButton, Me.toolStripSeparator1, Me.btnAsociarCliente})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(325, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnKillBroadcast
        '
        Me.btnKillBroadcast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnKillBroadcast.Image = Global.WMSOnePlan_Client.My.Resources.Resources.exclamation
        Me.btnKillBroadcast.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnKillBroadcast.Name = "btnKillBroadcast"
        Me.btnKillBroadcast.Size = New System.Drawing.Size(23, 22)
        Me.btnKillBroadcast.Text = "ToolStripButton1"
        Me.btnKillBroadcast.ToolTipText = "Cerrar todas las sesiones abiertas de los usuarios"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"),System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"),System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"),System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'btnAsociarCliente
        '
        Me.btnAsociarCliente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAsociarCliente.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ac0052_32
        Me.btnAsociarCliente.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAsociarCliente.Name = "btnAsociarCliente"
        Me.btnAsociarCliente.Size = New System.Drawing.Size(23, 22)
        Me.btnAsociarCliente.Text = "Asociar Cliente"
        '
        'SmallIconsList
        '
        Me.SmallIconsList.ImageStream = CType(resources.GetObject("SmallIconsList.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.SmallIconsList.TransparentColor = System.Drawing.Color.Transparent
        Me.SmallIconsList.Images.SetKeyName(0, "small_edit.png")
        Me.SmallIconsList.Images.SetKeyName(1, "about.png")
        Me.SmallIconsList.Images.SetKeyName(2, "CLSDFOLD.BMP")
        Me.SmallIconsList.Images.SetKeyName(3, "OPENFOLD.BMP")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Transparent
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GridControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.UiContenedorTab)
        Me.SplitContainer1.Size = New System.Drawing.Size(1009, 624)
        Me.SplitContainer1.SplitterDistance = 662
        Me.SplitContainer1.TabIndex = 6
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryIsLogged})
        Me.GridControl1.Size = New System.Drawing.Size(662, 624)
        Me.GridControl1.TabIndex = 16
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_Access, Me.GridColumn_ID, Me.GridColumn_Name, Me.GridColumn_Plataforma, Me.GridColumnEnviroment, Me.GridColumnStatus, Me.GridColumnLineID, Me.UiColDominio, Me.GridColumnIsLogged})
        StyleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Transparent
        StyleFormatCondition1.Appearance.Options.UseBackColor = true
        StyleFormatCondition1.Column = Me.GridColumnIsLogged
        StyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition1.Value1 = 0
        StyleFormatCondition1.Value2 = "0"
        StyleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Lime
        StyleFormatCondition2.Appearance.Options.UseBackColor = true
        StyleFormatCondition2.Column = Me.GridColumnIsLogged
        StyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        StyleFormatCondition2.Value1 = 1
        StyleFormatCondition2.Value2 = "1"
        StyleFormatCondition3.Appearance.BackColor = System.Drawing.Color.Red
        StyleFormatCondition3.Appearance.Options.UseBackColor = true
        StyleFormatCondition3.Column = Me.GridColumnStatus
        StyleFormatCondition3.Condition = DevExpress.XtraGrid.FormatConditionEnum.NotEqual
        StyleFormatCondition3.Value1 = "ACTIVO"
        Me.GridView1.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {StyleFormatCondition1, StyleFormatCondition2, StyleFormatCondition3})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.GroupPanelText = "Organizar por columna"
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LOGIN_ID", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowAutoFilterRow = true
        Me.GridView1.OptionsView.ShowFooter = true
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn_Access, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.GridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Never
        Me.GridView1.ViewCaption = "Clientes"
        '
        'GridColumn_Access
        '
        Me.GridColumn_Access.Caption = "Nivel de Accesso"
        Me.GridColumn_Access.FieldName = "ROLE_ID"
        Me.GridColumn_Access.Name = "GridColumn_Access"
        Me.GridColumn_Access.OptionsColumn.AllowEdit = false
        Me.GridColumn_Access.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList
        Me.GridColumn_Access.Width = 70
        '
        'GridColumn_ID
        '
        Me.GridColumn_ID.Caption = "Codigo"
        Me.GridColumn_ID.FieldName = "LOGIN_ID"
        Me.GridColumn_ID.Name = "GridColumn_ID"
        Me.GridColumn_ID.OptionsColumn.AllowEdit = false
        Me.GridColumn_ID.OptionsColumn.FixedWidth = true
        Me.GridColumn_ID.OptionsColumn.ReadOnly = true
        Me.GridColumn_ID.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn_ID.Visible = true
        Me.GridColumn_ID.VisibleIndex = 1
        Me.GridColumn_ID.Width = 100
        '
        'GridColumn_Name
        '
        Me.GridColumn_Name.Caption = "Nombre"
        Me.GridColumn_Name.FieldName = "LOGIN_NAME"
        Me.GridColumn_Name.Name = "GridColumn_Name"
        Me.GridColumn_Name.OptionsColumn.AllowEdit = false
        Me.GridColumn_Name.OptionsColumn.ReadOnly = true
        Me.GridColumn_Name.Visible = true
        Me.GridColumn_Name.VisibleIndex = 2
        Me.GridColumn_Name.Width = 226
        '
        'GridColumn_Plataforma
        '
        Me.GridColumn_Plataforma.Caption = "Plataforma"
        Me.GridColumn_Plataforma.FieldName = "LOGIN_TYPE"
        Me.GridColumn_Plataforma.Name = "GridColumn_Plataforma"
        Me.GridColumn_Plataforma.OptionsColumn.AllowEdit = false
        Me.GridColumn_Plataforma.OptionsColumn.AllowFocus = false
        Me.GridColumn_Plataforma.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Plataforma.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn_Plataforma.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.GridColumn_Plataforma.Visible = true
        Me.GridColumn_Plataforma.VisibleIndex = 3
        Me.GridColumn_Plataforma.Width = 107
        '
        'GridColumnEnviroment
        '
        Me.GridColumnEnviroment.Caption = "AmbienteTrabajo"
        Me.GridColumnEnviroment.FieldName = "ENVIRONMENT"
        Me.GridColumnEnviroment.Name = "GridColumnEnviroment"
        Me.GridColumnEnviroment.OptionsColumn.AllowEdit = false
        Me.GridColumnEnviroment.OptionsColumn.AllowFocus = false
        Me.GridColumnEnviroment.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.List
        Me.GridColumnEnviroment.Visible = true
        Me.GridColumnEnviroment.VisibleIndex = 4
        Me.GridColumnEnviroment.Width = 97
        '
        'GridColumnLineID
        '
        Me.GridColumnLineID.Caption = "Linea"
        Me.GridColumnLineID.FieldName = "LINE_ID"
        Me.GridColumnLineID.Name = "GridColumnLineID"
        Me.GridColumnLineID.OptionsColumn.AllowEdit = false
        Me.GridColumnLineID.OptionsColumn.ReadOnly = true
        Me.GridColumnLineID.Visible = true
        Me.GridColumnLineID.VisibleIndex = 0
        '
        'UiContenedorTab
        '
        Me.UiContenedorTab.Controls.Add(Me.UiTabCentroDistribucion)
        Me.UiContenedorTab.Controls.Add(Me.UiTabDatosGenerales)
        Me.UiContenedorTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiContenedorTab.Location = New System.Drawing.Point(0, 0)
        Me.UiContenedorTab.Name = "UiContenedorTab"
        Me.UiContenedorTab.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.UiTabCentroDistribucion, Me.UiTabDatosGenerales})
        Me.UiContenedorTab.RegularSize = New System.Drawing.Size(343, 624)
        Me.UiContenedorTab.SelectedPage = Me.UiTabDatosGenerales
        Me.UiContenedorTab.Size = New System.Drawing.Size(343, 624)
        Me.UiContenedorTab.TabIndex = 17
        Me.UiContenedorTab.Text = "TabPane1"
        '
        'UiTabCentroDistribucion
        '
        Me.UiTabCentroDistribucion.Caption = "Centro de Distribución"
        Me.UiTabCentroDistribucion.Controls.Add(Me.UiContenedorDeVistasBodegaAsociada)
        Me.UiTabCentroDistribucion.Controls.Add(Me.UiListaBodegasDisponibles)
        Me.UiTabCentroDistribucion.Controls.Add(Me.UiEtiquetaBodegasDisponibles)
        Me.UiTabCentroDistribucion.Controls.Add(Me.UiEtiquetaCentroDistribucion)
        Me.UiTabCentroDistribucion.Controls.Add(Me.UiListaCentroDistribucion)
        Me.UiTabCentroDistribucion.Controls.Add(Me.barDockControlLeft)
        Me.UiTabCentroDistribucion.Controls.Add(Me.barDockControlRight)
        Me.UiTabCentroDistribucion.Controls.Add(Me.barDockControlBottom)
        Me.UiTabCentroDistribucion.Controls.Add(Me.barDockControlTop)
        Me.UiTabCentroDistribucion.Name = "UiTabCentroDistribucion"
        Me.UiTabCentroDistribucion.Size = New System.Drawing.Size(325, 579)
        '
        'UiContenedorDeVistasBodegaAsociada
        '
        Me.UiContenedorDeVistasBodegaAsociada.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.UiContenedorDeVistasBodegaAsociada.Location = New System.Drawing.Point(3, 89)
        Me.UiContenedorDeVistasBodegaAsociada.MainView = Me.UiVistaBodegasAsociadas
        Me.UiContenedorDeVistasBodegaAsociada.Name = "UiContenedorDeVistasBodegaAsociada"
        Me.UiContenedorDeVistasBodegaAsociada.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.UiBotonEliminarBodega})
        Me.UiContenedorDeVistasBodegaAsociada.Size = New System.Drawing.Size(319, 490)
        Me.UiContenedorDeVistasBodegaAsociada.TabIndex = 21
        Me.UiContenedorDeVistasBodegaAsociada.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.UiVistaBodegasAsociadas})
        '
        'UiVistaBodegasAsociadas
        '
        Me.UiVistaBodegasAsociadas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEnEliminar, Me.UiColCodigoBodega, Me.UiColNombreBodega})
        Me.UiVistaBodegasAsociadas.GridControl = Me.UiContenedorDeVistasBodegaAsociada
        Me.UiVistaBodegasAsociadas.Name = "UiVistaBodegasAsociadas"
        Me.UiVistaBodegasAsociadas.OptionsView.ShowAutoFilterRow = true
        '
        'colEnEliminar
        '
        Me.colEnEliminar.Caption = "Eliminar"
        Me.colEnEliminar.ColumnEdit = Me.UiBotonEliminarBodega
        Me.colEnEliminar.Name = "colEnEliminar"
        Me.colEnEliminar.Visible = true
        Me.colEnEliminar.VisibleIndex = 0
        Me.colEnEliminar.Width = 50
        '
        'UiBotonEliminarBodega
        '
        Me.UiBotonEliminarBodega.AutoHeight = false
        Me.UiBotonEliminarBodega.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("UiBotonEliminarBodega.Buttons"),System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, true)})
        Me.UiBotonEliminarBodega.Name = "UiBotonEliminarBodega"
        Me.UiBotonEliminarBodega.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'UiColCodigoBodega
        '
        Me.UiColCodigoBodega.Caption = "Código Bodega"
        Me.UiColCodigoBodega.FieldName = "WAREHOUSE_ID"
        Me.UiColCodigoBodega.Name = "UiColCodigoBodega"
        Me.UiColCodigoBodega.Visible = true
        Me.UiColCodigoBodega.VisibleIndex = 1
        '
        'UiColNombreBodega
        '
        Me.UiColNombreBodega.Caption = "Nombre Bodega"
        Me.UiColNombreBodega.FieldName = "NAME"
        Me.UiColNombreBodega.Name = "UiColNombreBodega"
        Me.UiColNombreBodega.Visible = true
        Me.UiColNombreBodega.VisibleIndex = 2
        '
        'UiListaBodegasDisponibles
        '
        Me.UiListaBodegasDisponibles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.UiListaBodegasDisponibles.Location = New System.Drawing.Point(119, 63)
        Me.UiListaBodegasDisponibles.Name = "UiListaBodegasDisponibles"
        Me.UiListaBodegasDisponibles.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("UiListaBodegasDisponibles.Properties.Buttons"),System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", "UiBotonRefrescarBodegasDisponibles", Nothing, true)})
        Me.UiListaBodegasDisponibles.Properties.View = Me.UiListavistaBodegasDisponibles
        Me.UiListaBodegasDisponibles.Size = New System.Drawing.Size(206, 22)
        Me.UiListaBodegasDisponibles.TabIndex = 3
        '
        'UiListavistaBodegasDisponibles
        '
        Me.UiListavistaBodegasDisponibles.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColCodigoBodegaDisponible, Me.UiColNombreBodegaDisponilbe})
        Me.UiListavistaBodegasDisponibles.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListavistaBodegasDisponibles.Name = "UiListavistaBodegasDisponibles"
        Me.UiListavistaBodegasDisponibles.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.UiListavistaBodegasDisponibles.OptionsSelection.MultiSelect = true
        Me.UiListavistaBodegasDisponibles.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.UiListavistaBodegasDisponibles.OptionsView.ShowGroupPanel = false
        '
        'UiColCodigoBodegaDisponible
        '
        Me.UiColCodigoBodegaDisponible.Caption = "Codigo"
        Me.UiColCodigoBodegaDisponible.FieldName = "WAREHOUSE_ID"
        Me.UiColCodigoBodegaDisponible.Name = "UiColCodigoBodegaDisponible"
        Me.UiColCodigoBodegaDisponible.Visible = true
        Me.UiColCodigoBodegaDisponible.VisibleIndex = 1
        '
        'UiColNombreBodegaDisponilbe
        '
        Me.UiColNombreBodegaDisponilbe.Caption = "Nombre"
        Me.UiColNombreBodegaDisponilbe.FieldName = "NAME"
        Me.UiColNombreBodegaDisponilbe.Name = "UiColNombreBodegaDisponilbe"
        Me.UiColNombreBodegaDisponilbe.Visible = true
        Me.UiColNombreBodegaDisponilbe.VisibleIndex = 2
        '
        'UiEtiquetaBodegasDisponibles
        '
        Me.UiEtiquetaBodegasDisponibles.Location = New System.Drawing.Point(3, 66)
        Me.UiEtiquetaBodegasDisponibles.Name = "UiEtiquetaBodegasDisponibles"
        Me.UiEtiquetaBodegasDisponibles.Size = New System.Drawing.Size(101, 13)
        Me.UiEtiquetaBodegasDisponibles.TabIndex = 2
        Me.UiEtiquetaBodegasDisponibles.Text = "Bodegas Disponibles:"
        '
        'UiEtiquetaCentroDistribucion
        '
        Me.UiEtiquetaCentroDistribucion.Location = New System.Drawing.Point(0, 40)
        Me.UiEtiquetaCentroDistribucion.Name = "UiEtiquetaCentroDistribucion"
        Me.UiEtiquetaCentroDistribucion.Size = New System.Drawing.Size(110, 13)
        Me.UiEtiquetaCentroDistribucion.TabIndex = 1
        Me.UiEtiquetaCentroDistribucion.Text = "Centro de Distribución:"
        '
        'UiListaCentroDistribucion
        '
        Me.UiListaCentroDistribucion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.UiListaCentroDistribucion.Location = New System.Drawing.Point(119, 37)
        Me.UiListaCentroDistribucion.Name = "UiListaCentroDistribucion"
        Me.UiListaCentroDistribucion.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, CType(resources.GetObject("UiListaCentroDistribucion.Properties.Buttons"),System.Drawing.Image), New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject9, SerializableAppearanceObject10, SerializableAppearanceObject11, SerializableAppearanceObject12, "", "UiBotonRefrescarCentrosDistribucion", Nothing, true)})
        Me.UiListaCentroDistribucion.Properties.DisplayMember = "PARAM_CAPTION"
        Me.UiListaCentroDistribucion.Properties.ValueMember = "PARAM_NAME"
        Me.UiListaCentroDistribucion.Properties.View = Me.UiListaVistaCentrosDistribucion
        Me.UiListaCentroDistribucion.Size = New System.Drawing.Size(206, 22)
        Me.UiListaCentroDistribucion.TabIndex = 0
        '
        'UiListaVistaCentrosDistribucion
        '
        Me.UiListaVistaCentrosDistribucion.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.UiColCodigoCentroDistribucion, Me.UiColDescripcionCentroDistribucion})
        Me.UiListaVistaCentrosDistribucion.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.UiListaVistaCentrosDistribucion.Name = "UiListaVistaCentrosDistribucion"
        Me.UiListaVistaCentrosDistribucion.OptionsSelection.EnableAppearanceFocusedCell = false
        Me.UiListaVistaCentrosDistribucion.OptionsView.ShowGroupPanel = false
        '
        'UiColCodigoCentroDistribucion
        '
        Me.UiColCodigoCentroDistribucion.Caption = "Código"
        Me.UiColCodigoCentroDistribucion.FieldName = "PARAM_NAME"
        Me.UiColCodigoCentroDistribucion.Name = "UiColCodigoCentroDistribucion"
        Me.UiColCodigoCentroDistribucion.Visible = true
        Me.UiColCodigoCentroDistribucion.VisibleIndex = 0
        '
        'UiColDescripcionCentroDistribucion
        '
        Me.UiColDescripcionCentroDistribucion.Caption = "Descripción"
        Me.UiColDescripcionCentroDistribucion.FieldName = "PARAM_CAPTION"
        Me.UiColDescripcionCentroDistribucion.Name = "UiColDescripcionCentroDistribucion"
        Me.UiColDescripcionCentroDistribucion.Visible = true
        Me.UiColDescripcionCentroDistribucion.VisibleIndex = 1
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = false
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 31)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 548)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = false
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(325, 31)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 548)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = false
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 579)
        Me.barDockControlBottom.Size = New System.Drawing.Size(325, 0)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = false
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(325, 31)
        '
        'UiTabDatosGenerales
        '
        Me.UiTabDatosGenerales.Caption = "Datos Generales"
        Me.UiTabDatosGenerales.Controls.Add(Me.PropertyGridControl1)
        Me.UiTabDatosGenerales.Controls.Add(Me.PropertyDescriptionControl1)
        Me.UiTabDatosGenerales.Controls.Add(Me.ToolStrip1)
        Me.UiTabDatosGenerales.Name = "UiTabDatosGenerales"
        Me.UiTabDatosGenerales.Size = New System.Drawing.Size(325, 579)
        '
        'PropertyGridControl1
        '
        Me.PropertyGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGridControl1.Location = New System.Drawing.Point(0, 25)
        Me.PropertyGridControl1.Name = "PropertyGridControl1"
        Me.PropertyGridControl1.Size = New System.Drawing.Size(325, 497)
        Me.PropertyGridControl1.TabIndex = 7
        '
        'PropertyDescriptionControl1
        '
        Me.PropertyDescriptionControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PropertyDescriptionControl1.Location = New System.Drawing.Point(0, 522)
        Me.PropertyDescriptionControl1.Name = "PropertyDescriptionControl1"
        Me.PropertyDescriptionControl1.PropertyGrid = Me.PropertyGridControl1
        Me.PropertyDescriptionControl1.Size = New System.Drawing.Size(325, 57)
        Me.PropertyDescriptionControl1.TabIndex = 6
        Me.PropertyDescriptionControl1.TabStop = false
        '
        'UiBarManagerCentroDistriubicion
        '
        Me.UiBarManagerCentroDistriubicion.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.UiBarraCentroDistribucion})
        Me.UiBarManagerCentroDistriubicion.DockControls.Add(Me.barDockControlTop)
        Me.UiBarManagerCentroDistriubicion.DockControls.Add(Me.barDockControlBottom)
        Me.UiBarManagerCentroDistriubicion.DockControls.Add(Me.barDockControlLeft)
        Me.UiBarManagerCentroDistriubicion.DockControls.Add(Me.barDockControlRight)
        Me.UiBarManagerCentroDistriubicion.Form = Me.UiTabCentroDistribucion
        Me.UiBarManagerCentroDistriubicion.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.UiBotonAgregarBodegas})
        Me.UiBarManagerCentroDistriubicion.MaxItemId = 1
        '
        'UiBarraCentroDistribucion
        '
        Me.UiBarraCentroDistribucion.BarName = "Tools"
        Me.UiBarraCentroDistribucion.DockCol = 0
        Me.UiBarraCentroDistribucion.DockRow = 0
        Me.UiBarraCentroDistribucion.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.UiBarraCentroDistribucion.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.UiBotonAgregarBodegas, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)})
        Me.UiBarraCentroDistribucion.OptionsBar.AllowQuickCustomization = false
        Me.UiBarraCentroDistribucion.OptionsBar.DrawDragBorder = false
        Me.UiBarraCentroDistribucion.OptionsBar.UseWholeRow = true
        Me.UiBarraCentroDistribucion.Text = "Tools"
        '
        'UiBotonAgregarBodegas
        '
        Me.UiBotonAgregarBodegas.Caption = "Agregar"
        Me.UiBotonAgregarBodegas.Glyph = CType(resources.GetObject("UiBotonAgregarBodegas.Glyph"),System.Drawing.Image)
        Me.UiBotonAgregarBodegas.Id = 0
        Me.UiBotonAgregarBodegas.LargeGlyph = CType(resources.GetObject("UiBotonAgregarBodegas.LargeGlyph"),System.Drawing.Image)
        Me.UiBotonAgregarBodegas.Name = "UiBotonAgregarBodegas"
        '
        'UiColDominio
        '
        Me.UiColDominio.Caption = "Dominio"
        Me.UiColDominio.FieldName = "DOMAIN"
        Me.UiColDominio.Name = "UiColDominio"
        Me.UiColDominio.OptionsColumn.AllowEdit = false
        '
        'frmUserLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1009, 624)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmUserLogin"
        Me.Text = "Settings: Users"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryIsLogged,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.SplitContainer1.Panel1.ResumeLayout(false)
        Me.SplitContainer1.Panel2.ResumeLayout(false)
        CType(Me.SplitContainer1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainer1.ResumeLayout(false)
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiContenedorTab,System.ComponentModel.ISupportInitialize).EndInit
        Me.UiContenedorTab.ResumeLayout(false)
        Me.UiTabCentroDistribucion.ResumeLayout(false)
        Me.UiTabCentroDistribucion.PerformLayout
        CType(Me.UiContenedorDeVistasBodegaAsociada,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiVistaBodegasAsociadas,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiBotonEliminarBodega,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaBodegasDisponibles.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListavistaBodegasDisponibles,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaCentroDistribucion.Properties,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiListaVistaCentrosDistribucion,System.ComponentModel.ISupportInitialize).EndInit
        Me.UiTabDatosGenerales.ResumeLayout(false)
        Me.UiTabDatosGenerales.PerformLayout
        CType(Me.PropertyGridControl1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.UiBarManagerCentroDistriubicion,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SmallIconsList As System.Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_Access As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_ID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Name As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Plataforma As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnEnviroment As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumnIsLogged As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryIsLogged As DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup
    Friend WithEvents GridColumnLineID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnKillBroadcast As System.Windows.Forms.ToolStripButton
    Friend WithEvents PropertyGridControl1 As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents PropertyDescriptionControl1 As DevExpress.XtraVerticalGrid.PropertyDescriptionControl
    Friend WithEvents btnAsociarCliente As System.Windows.Forms.ToolStripButton
    Friend WithEvents UiContenedorTab As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents UiTabCentroDistribucion As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents UiTabDatosGenerales As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents UiListaBodegasDisponibles As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents UiListavistaBodegasDisponibles As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiEtiquetaBodegasDisponibles As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiEtiquetaCentroDistribucion As DevExpress.XtraEditors.LabelControl
    Friend WithEvents UiListaCentroDistribucion As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents UiListaVistaCentrosDistribucion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents UiBarManagerCentroDistriubicion As DevExpress.XtraBars.BarManager
    Friend WithEvents UiBarraCentroDistribucion As DevExpress.XtraBars.Bar
    Friend WithEvents UiBotonAgregarBodegas As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents UiColCodigoCentroDistribucion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDescripcionCentroDistribucion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColCodigoBodegaDisponible As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreBodegaDisponilbe As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiContenedorDeVistasBodegaAsociada As DevExpress.XtraGrid.GridControl
    Friend WithEvents UiVistaBodegasAsociadas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colEnEliminar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiBotonEliminarBodega As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents UiColCodigoBodega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColNombreBodega As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UiColDominio As DevExpress.XtraGrid.Columns.GridColumn
End Class

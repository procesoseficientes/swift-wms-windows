<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptTransOnLine
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrLabel39 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel52 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel51 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel57 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel54 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel53 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel47 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel46 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel37 = New DevExpress.XtraReports.UI.XRLabel()
        Me.OP_WMS_TRANSAdapter1 = New WMSOnePlan_Client.rpt_DS_TransOnLineTableAdapters.OP_WMS_TRANSAdapter()
        Me.Rpt_DS_TransOnLine1 = New WMSOnePlan_Client.rpt_DS_TransOnLine()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrPageInfo5 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPageInfo4 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPageInfo3 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel71 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel79 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel78 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel24 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel21 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.GroupHeaderBand1 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLabel30 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupHeaderBand2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
        Me.XrLabel33 = New DevExpress.XtraReports.UI.XRLabel()
        Me.GroupFooterBand2 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel34 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ParamFilterApplied = New DevExpress.XtraReports.Parameters.Parameter()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.UiImagenLogo = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.logoImg = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.Rpt_DS_TransOnLine1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel39, Me.XrLabel52, Me.XrLabel51, Me.XrLabel57, Me.XrLabel54, Me.XrLabel53, Me.XrLabel47, Me.XrLabel46, Me.XrLabel37})
        Me.Detail.HeightF = 18!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel39
        '
        Me.XrLabel39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.LOGIN_NAME")})
        Me.XrLabel39.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel39.LocationFloat = New DevExpress.Utils.PointFloat(717!, 0!)
        Me.XrLabel39.Name = "XrLabel39"
        Me.XrLabel39.SizeF = New System.Drawing.SizeF(83!, 18!)
        Me.XrLabel39.StyleName = "DataField"
        Me.XrLabel39.StylePriority.UseFont = false
        '
        'XrLabel52
        '
        Me.XrLabel52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.TARGET_BIN", "{0:#0}")})
        Me.XrLabel52.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel52.LocationFloat = New DevExpress.Utils.PointFloat(650!, 0!)
        Me.XrLabel52.Name = "XrLabel52"
        Me.XrLabel52.SizeF = New System.Drawing.SizeF(58!, 18!)
        Me.XrLabel52.StyleName = "DataField"
        Me.XrLabel52.StylePriority.UseFont = false
        '
        'XrLabel51
        '
        Me.XrLabel51.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.SOURCE_BIN", "{0:#0}")})
        Me.XrLabel51.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel51.LocationFloat = New DevExpress.Utils.PointFloat(583!, 0!)
        Me.XrLabel51.Name = "XrLabel51"
        Me.XrLabel51.SizeF = New System.Drawing.SizeF(58!, 18!)
        Me.XrLabel51.StyleName = "DataField"
        Me.XrLabel51.StylePriority.UseFont = false
        '
        'XrLabel57
        '
        Me.XrLabel57.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.QUANTITY_UNITS", "{0:#.00}")})
        Me.XrLabel57.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel57.LocationFloat = New DevExpress.Utils.PointFloat(808!, 0!)
        Me.XrLabel57.Name = "XrLabel57"
        Me.XrLabel57.SizeF = New System.Drawing.SizeF(83!, 18!)
        Me.XrLabel57.StyleName = "DataField"
        Me.XrLabel57.StylePriority.UseFont = false
        Me.XrLabel57.StylePriority.UseTextAlignment = false
        Me.XrLabel57.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel54
        '
        Me.XrLabel54.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.TARGET_LOCATION")})
        Me.XrLabel54.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel54.LocationFloat = New DevExpress.Utils.PointFloat(500!, 0!)
        Me.XrLabel54.Name = "XrLabel54"
        Me.XrLabel54.SizeF = New System.Drawing.SizeF(67!, 18!)
        Me.XrLabel54.StyleName = "DataField"
        Me.XrLabel54.StylePriority.UseFont = false
        '
        'XrLabel53
        '
        Me.XrLabel53.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.SOURCE_LOCATION")})
        Me.XrLabel53.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel53.LocationFloat = New DevExpress.Utils.PointFloat(408!, 0!)
        Me.XrLabel53.Name = "XrLabel53"
        Me.XrLabel53.SizeF = New System.Drawing.SizeF(83!, 18!)
        Me.XrLabel53.StyleName = "DataField"
        Me.XrLabel53.StylePriority.UseFont = false
        '
        'XrLabel47
        '
        Me.XrLabel47.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.MATERIAL_DESCRIPTION")})
        Me.XrLabel47.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel47.LocationFloat = New DevExpress.Utils.PointFloat(200!, 0!)
        Me.XrLabel47.Name = "XrLabel47"
        Me.XrLabel47.SizeF = New System.Drawing.SizeF(200!, 18!)
        Me.XrLabel47.StyleName = "DataField"
        Me.XrLabel47.StylePriority.UseFont = false
        '
        'XrLabel46
        '
        Me.XrLabel46.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.MATERIAL_CODE")})
        Me.XrLabel46.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(125!, 0!)
        Me.XrLabel46.Name = "XrLabel46"
        Me.XrLabel46.SizeF = New System.Drawing.SizeF(67!, 18!)
        Me.XrLabel46.StyleName = "DataField"
        Me.XrLabel46.StylePriority.UseFont = false
        '
        'XrLabel37
        '
        Me.XrLabel37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.TRANS_DATE", "{0:dd MMM hh:mmtt}")})
        Me.XrLabel37.Font = New System.Drawing.Font("Segoe Condensed", 8!)
        Me.XrLabel37.LocationFloat = New DevExpress.Utils.PointFloat(8!, 0!)
        Me.XrLabel37.Name = "XrLabel37"
        Me.XrLabel37.SizeF = New System.Drawing.SizeF(108!, 18!)
        Me.XrLabel37.StyleName = "DataField"
        Me.XrLabel37.StylePriority.UseFont = false
        Me.XrLabel37.Text = "XrLabel37"
        '
        'OP_WMS_TRANSAdapter1
        '
        Me.OP_WMS_TRANSAdapter1.ClearBeforeFill = true
        '
        'Rpt_DS_TransOnLine1
        '
        Me.Rpt_DS_TransOnLine1.DataSetName = "rpt_DS_TransOnLine"
        Me.Rpt_DS_TransOnLine1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3})
        Me.PageFooter.HeightF = 29!
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(888!, 2!)
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine4, Me.XrPageInfo5, Me.XrPageInfo4, Me.XrLabel3, Me.XrLabel16, Me.XrPageInfo3, Me.XrLabel2, Me.XrLabel71, Me.XrLabel1, Me.XrLabel18, Me.XrLabel20, Me.XrLabel79, Me.XrLabel78, Me.XrLine2, Me.XrLine1, Me.XrLabel24, Me.XrLabel21, Me.XrLabel4})
        Me.PageHeader.HeightF = 116!
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine4
        '
        Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(8!, 33!)
        Me.XrLine4.Name = "XrLine4"
        Me.XrLine4.SizeF = New System.Drawing.SizeF(875!, 8!)
        '
        'XrPageInfo5
        '
        Me.XrPageInfo5.Font = New System.Drawing.Font("Calibri", 8!, System.Drawing.FontStyle.Bold)
        Me.XrPageInfo5.Format = "Pg {0} de {1} "
        Me.XrPageInfo5.LocationFloat = New DevExpress.Utils.PointFloat(833!, 42!)
        Me.XrPageInfo5.Name = "XrPageInfo5"
        Me.XrPageInfo5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrPageInfo5.SizeF = New System.Drawing.SizeF(50!, 25!)
        Me.XrPageInfo5.StylePriority.UseFont = false
        Me.XrPageInfo5.StylePriority.UseTextAlignment = false
        Me.XrPageInfo5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrPageInfo4
        '
        Me.XrPageInfo4.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Bold)
        Me.XrPageInfo4.Format = "{0:MM/dd/yyyy HH:mm:ss tt}"
        Me.XrPageInfo4.LocationFloat = New DevExpress.Utils.PointFloat(683!, 42!)
        Me.XrPageInfo4.Name = "XrPageInfo4"
        Me.XrPageInfo4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrPageInfo4.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo4.SizeF = New System.Drawing.SizeF(142!, 25!)
        Me.XrPageInfo4.StylePriority.UseFont = false
        '
        'XrLabel3
        '
        Me.XrLabel3.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(683!, 8!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(200!, 25!)
        Me.XrLabel3.StylePriority.UseFont = false
        Me.XrLabel3.StylePriority.UseTextAlignment = false
        Me.XrLabel3.Text = "Cosmetica Global."
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel16
        '
        Me.XrLabel16.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(125!, 42!)
        Me.XrLabel16.Name = "XrLabel16"
        Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel16.SizeF = New System.Drawing.SizeF(550!, 25!)
        Me.XrLabel16.StylePriority.UseFont = false
        Me.XrLabel16.StylePriority.UseTextAlignment = false
        Me.XrLabel16.Text = "Listado de Transacciones "
        Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrPageInfo3
        '
        Me.XrPageInfo3.Font = New System.Drawing.Font("Calibri", 11!, System.Drawing.FontStyle.Bold)
        Me.XrPageInfo3.LocationFloat = New DevExpress.Utils.PointFloat(8!, 42!)
        Me.XrPageInfo3.Name = "XrPageInfo3"
        Me.XrPageInfo3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrPageInfo3.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName
        Me.XrPageInfo3.SizeF = New System.Drawing.SizeF(100!, 25!)
        Me.XrPageInfo3.StylePriority.UseFont = false
        '
        'XrLabel2
        '
        Me.XrLabel2.Font = New System.Drawing.Font("Calibri", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(8!, 8!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(200!, 25!)
        Me.XrLabel2.StylePriority.UseFont = false
        Me.XrLabel2.Text = "Swift 3PL."
        '
        'XrLabel71
        '
        Me.XrLabel71.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel71.LocationFloat = New DevExpress.Utils.PointFloat(708!, 83!)
        Me.XrLabel71.Name = "XrLabel71"
        Me.XrLabel71.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel71.SizeF = New System.Drawing.SizeF(72!, 20!)
        Me.XrLabel71.StyleName = "FieldCaption"
        Me.XrLabel71.StylePriority.UseFont = false
        Me.XrLabel71.Text = "Usuario"
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(642!, 83!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(50!, 20!)
        Me.XrLabel1.StyleName = "FieldCaption"
        Me.XrLabel1.StylePriority.UseFont = false
        Me.XrLabel1.Text = "BinDestino"
        '
        'XrLabel18
        '
        Me.XrLabel18.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(583!, 83!)
        Me.XrLabel18.Name = "XrLabel18"
        Me.XrLabel18.SizeF = New System.Drawing.SizeF(50!, 17!)
        Me.XrLabel18.StyleName = "FieldCaption"
        Me.XrLabel18.StylePriority.UseFont = false
        Me.XrLabel18.Text = "BinOrigen"
        '
        'XrLabel20
        '
        Me.XrLabel20.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(500!, 83!)
        Me.XrLabel20.Name = "XrLabel20"
        Me.XrLabel20.SizeF = New System.Drawing.SizeF(75!, 17!)
        Me.XrLabel20.StyleName = "FieldCaption"
        Me.XrLabel20.StylePriority.UseFont = false
        Me.XrLabel20.Text = "UbicacionOrigen"
        '
        'XrLabel79
        '
        Me.XrLabel79.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel79.LocationFloat = New DevExpress.Utils.PointFloat(200!, 83!)
        Me.XrLabel79.Name = "XrLabel79"
        Me.XrLabel79.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel79.SizeF = New System.Drawing.SizeF(200!, 17!)
        Me.XrLabel79.StyleName = "FieldCaption"
        Me.XrLabel79.StylePriority.UseFont = false
        Me.XrLabel79.Text = "Descripcion"
        '
        'XrLabel78
        '
        Me.XrLabel78.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel78.LocationFloat = New DevExpress.Utils.PointFloat(117!, 83!)
        Me.XrLabel78.Name = "XrLabel78"
        Me.XrLabel78.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel78.SizeF = New System.Drawing.SizeF(67!, 17!)
        Me.XrLabel78.StyleName = "FieldCaption"
        Me.XrLabel78.StylePriority.UseFont = false
        Me.XrLabel78.Text = "Producto"
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(8!, 108!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(888!, 2!)
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(8!, 75!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(875!, 2!)
        '
        'XrLabel24
        '
        Me.XrLabel24.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel24.LocationFloat = New DevExpress.Utils.PointFloat(800!, 83!)
        Me.XrLabel24.Name = "XrLabel24"
        Me.XrLabel24.SizeF = New System.Drawing.SizeF(82!, 20!)
        Me.XrLabel24.StyleName = "FieldCaption"
        Me.XrLabel24.StylePriority.UseFont = false
        Me.XrLabel24.StylePriority.UseTextAlignment = false
        Me.XrLabel24.Text = "Unidades"
        Me.XrLabel24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrLabel21
        '
        Me.XrLabel21.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel21.LocationFloat = New DevExpress.Utils.PointFloat(408!, 83!)
        Me.XrLabel21.Name = "XrLabel21"
        Me.XrLabel21.SizeF = New System.Drawing.SizeF(83!, 17!)
        Me.XrLabel21.StyleName = "FieldCaption"
        Me.XrLabel21.StylePriority.UseFont = false
        Me.XrLabel21.Text = "UbicacionDestino"
        '
        'XrLabel4
        '
        Me.XrLabel4.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(8!, 83!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(83!, 17!)
        Me.XrLabel4.StyleName = "FieldCaption"
        Me.XrLabel4.StylePriority.UseFont = false
        Me.XrLabel4.Text = "Fecha"
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.White
        Me.Title.BorderColor = System.Drawing.SystemColors.ControlText
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1!
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 20!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Maroon
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.White
        Me.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.FieldCaption.BorderWidth = 1!
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Maroon
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.White
        Me.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1!
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 10!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.White
        Me.DataField.BorderColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1!
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 10!)
        Me.DataField.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DataField.Name = "DataField"
        '
        'GroupHeaderBand1
        '
        Me.GroupHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel30})
        Me.GroupHeaderBand1.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SOURCE_WAREHOUSE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeaderBand1.HeightF = 23!
        Me.GroupHeaderBand1.Level = 1
        Me.GroupHeaderBand1.Name = "GroupHeaderBand1"
        '
        'XrLabel30
        '
        Me.XrLabel30.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.SOURCE_WAREHOUSE")})
        Me.XrLabel30.Font = New System.Drawing.Font("Segoe Condensed", 10!, System.Drawing.FontStyle.Bold)
        Me.XrLabel30.LocationFloat = New DevExpress.Utils.PointFloat(8!, 0!)
        Me.XrLabel30.Name = "XrLabel30"
        Me.XrLabel30.SizeF = New System.Drawing.SizeF(142!, 23!)
        Me.XrLabel30.StyleName = "DataField"
        Me.XrLabel30.StylePriority.UseFont = false
        '
        'GroupHeaderBand2
        '
        Me.GroupHeaderBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel33})
        Me.GroupHeaderBand2.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("TRANS_TYPE", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
        Me.GroupHeaderBand2.HeightF = 24!
        Me.GroupHeaderBand2.Name = "GroupHeaderBand2"
        '
        'XrLabel33
        '
        Me.XrLabel33.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.TRANS_TYPE")})
        Me.XrLabel33.Font = New System.Drawing.Font("Segoe Condensed", 10!, System.Drawing.FontStyle.Bold)
        Me.XrLabel33.LocationFloat = New DevExpress.Utils.PointFloat(33!, 0!)
        Me.XrLabel33.Name = "XrLabel33"
        Me.XrLabel33.SizeF = New System.Drawing.SizeF(142!, 23!)
        Me.XrLabel33.StyleName = "DataField"
        Me.XrLabel33.StylePriority.UseFont = false
        '
        'GroupFooterBand2
        '
        Me.GroupFooterBand2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel34})
        Me.GroupFooterBand2.HeightF = 18!
        Me.GroupFooterBand2.Name = "GroupFooterBand2"
        '
        'XrLabel34
        '
        Me.XrLabel34.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OP_WMS_TRANS.QUANTITY_UNITS", "{0:C2}")})
        Me.XrLabel34.Font = New System.Drawing.Font("Segoe Condensed", 8!, System.Drawing.FontStyle.Bold)
        Me.XrLabel34.LocationFloat = New DevExpress.Utils.PointFloat(808!, 0!)
        Me.XrLabel34.Name = "XrLabel34"
        Me.XrLabel34.SizeF = New System.Drawing.SizeF(83!, 18!)
        Me.XrLabel34.StyleName = "FieldCaption"
        Me.XrLabel34.StylePriority.UseFont = false
        Me.XrLabel34.StylePriority.UseTextAlignment = false
        XrSummary1.FormatString = "{0:#.00}"
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
        Me.XrLabel34.Summary = XrSummary1
        Me.XrLabel34.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5})
        Me.ReportHeader.HeightF = 42!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLabel5
        '
        Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding(Me.ParamFilterApplied, "Text", "")})
        Me.XrLabel5.Font = New System.Drawing.Font("Calibri", 8!, System.Drawing.FontStyle.Italic)
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(17!, 0!)
        Me.XrLabel5.Multiline = true
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(867!, 33!)
        Me.XrLabel5.StylePriority.UseFont = false
        Me.XrLabel5.Text = "XrLabel5"
        '
        'ParamFilterApplied
        '
        Me.ParamFilterApplied.Name = "ParamFilterApplied"
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.UiImagenLogo})
        Me.TopMarginBand1.HeightF = 229.1667!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 100!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'UiImagenLogo
        '
        Me.UiImagenLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.UiImagenLogo.Name = "UiImagenLogo"
        Me.UiImagenLogo.SizeF = New System.Drawing.SizeF(900!, 229.1667!)
        Me.UiImagenLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'logoImg
        '
        Me.logoImg.Description = "Logo Empresa"
        Me.logoImg.Name = "logoImg"
        Me.logoImg.Visible = false
        '
        'rptTransOnLine
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageFooter, Me.PageHeader, Me.GroupHeaderBand1, Me.GroupHeaderBand2, Me.GroupFooterBand2, Me.ReportHeader, Me.TopMarginBand1, Me.BottomMarginBand1})
        Me.DataAdapter = Me.OP_WMS_TRANSAdapter1
        Me.DataMember = "OP_WMS_TRANS"
        Me.DataSource = Me.Rpt_DS_TransOnLine1
        Me.Landscape = true
        Me.Margins = New System.Drawing.Printing.Margins(100, 100, 229, 100)
        Me.PageHeight = 850
        Me.PageWidth = 1100
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.ParamFilterApplied, Me.logoImg})
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "15.2"
        CType(Me.Rpt_DS_TransOnLine1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrLabel57 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel54 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel53 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel52 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel51 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel47 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel46 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel39 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel37 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents OP_WMS_TRANSAdapter1 As WMSOnePlan_Client.rpt_DS_TransOnLineTableAdapters.OP_WMS_TRANSAdapter
    Friend WithEvents Rpt_DS_TransOnLine1 As WMSOnePlan_Client.rpt_DS_TransOnLine
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel24 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel21 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents GroupHeaderBand1 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrLabel30 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupHeaderBand2 As DevExpress.XtraReports.UI.GroupHeaderBand
    Friend WithEvents XrLabel33 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents GroupFooterBand2 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabel34 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel79 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel78 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel71 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPageInfo5 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPageInfo4 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo3 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents ParamFilterApplied As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents UiImagenLogo As DevExpress.XtraReports.UI.XRPictureBox
    Private WithEvents logoImg As DevExpress.XtraReports.Parameters.Parameter
End Class

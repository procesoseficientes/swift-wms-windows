<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImgAudit
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
        Dim GalleryItemGroup1 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Dim GalleryItemGroup2 As DevExpress.XtraBars.Ribbon.GalleryItemGroup = New DevExpress.XtraBars.Ribbon.GalleryItemGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmImgAudit))
        Dim Transition1 As DevExpress.Utils.Animation.Transition = New DevExpress.Utils.Animation.Transition()
        Dim SlideFadeTransition1 As DevExpress.Utils.Animation.SlideFadeTransition = New DevExpress.Utils.Animation.SlideFadeTransition()
        Me.GalleryControlGallery1 = New DevExpress.XtraBars.Ribbon.Gallery.GalleryControlGallery()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.glrImg = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.pctImg = New DevExpress.XtraEditors.PictureEdit()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnGrabar = New DevExpress.XtraEditors.SimpleButton()
        Me.menComentario = New DevExpress.XtraEditors.MemoEdit()
        Me.TransitionManager1 = New DevExpress.Utils.Animation.TransitionManager()
        CType(Me.glrImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.glrImg.SuspendLayout()
        CType(Me.pctImg.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.menComentario.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GalleryControlGallery1
        '
        GalleryItemGroup1.Caption = "grp1"
        Me.GalleryControlGallery1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup1})
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.glrImg
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(221, 522)
        '
        'glrImg
        '
        Me.glrImg.Controls.Add(Me.GalleryControlClient1)
        Me.glrImg.DesignGalleryGroupIndex = 0
        Me.glrImg.DesignGalleryItemIndex = 0
        Me.glrImg.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'GalleryControlGallery2
        '
        Me.glrImg.Gallery.AllowHoverImages = True
        GalleryItemGroup2.Caption = "Fotografias"
        Me.glrImg.Gallery.Groups.AddRange(New DevExpress.XtraBars.Ribbon.GalleryItemGroup() {GalleryItemGroup2})
        Me.glrImg.Gallery.HoverImageSize = New System.Drawing.Size(150, 150)
        Me.glrImg.Gallery.ImageSize = New System.Drawing.Size(200, 150)
        Me.glrImg.Location = New System.Drawing.Point(0, 0)
        Me.glrImg.Name = "glrImg"
        Me.glrImg.Size = New System.Drawing.Size(242, 526)
        Me.glrImg.TabIndex = 0
        Me.glrImg.Text = "GalleryControl1"
        '
        'pctImg
        '
        Me.pctImg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pctImg.Location = New System.Drawing.Point(1, 103)
        Me.pctImg.Name = "pctImg"
        Me.pctImg.Properties.ShowMenu = False
        Me.pctImg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.pctImg.Size = New System.Drawing.Size(693, 420)
        Me.pctImg.TabIndex = 1
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.glrImg)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.LabelControl1)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.btnGrabar)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.menComentario)
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.pctImg)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(953, 526)
        Me.SplitContainerControl1.SplitterPosition = 242
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(1, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(69, 15)
        Me.LabelControl1.TabIndex = 4
        Me.LabelControl1.Text = "Comentario:"
        '
        'btnGrabar
        '
        Me.btnGrabar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGrabar.Appearance.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.Appearance.Options.UseFont = True
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.Location = New System.Drawing.Point(611, 27)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(83, 70)
        Me.btnGrabar.TabIndex = 3
        Me.btnGrabar.Text = "Grabar"
        '
        'menComentario
        '
        Me.menComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.menComentario.Location = New System.Drawing.Point(0, 28)
        Me.menComentario.Name = "menComentario"
        Me.menComentario.Properties.MaxLength = 250
        Me.menComentario.Size = New System.Drawing.Size(605, 69)
        Me.menComentario.TabIndex = 2
        '
        'TransitionManager1
        '
        Transition1.Control = Nothing
        Transition1.ShowWaitingIndicator = DevExpress.Utils.DefaultBoolean.[False]
        SlideFadeTransition1.Parameters.Background = System.Drawing.Color.Empty
        SlideFadeTransition1.Parameters.FrameCount = Nothing
        Transition1.TransitionType = SlideFadeTransition1
        Me.TransitionManager1.Transitions.Add(Transition1)
        '
        'FrmImgAudit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 526)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "FrmImgAudit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fotografias"
        CType(Me.glrImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.glrImg.ResumeLayout(False)
        CType(Me.pctImg.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.menComentario.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GalleryControlGallery1 As DevExpress.XtraBars.Ribbon.Gallery.GalleryControlGallery
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents glrImg As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents pctImg As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TransitionManager1 As DevExpress.Utils.Animation.TransitionManager
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnGrabar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents menComentario As DevExpress.XtraEditors.MemoEdit
End Class

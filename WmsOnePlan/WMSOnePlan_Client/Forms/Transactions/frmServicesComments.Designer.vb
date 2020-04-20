<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicesComments
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
        Me.txtComments = New DevExpress.XtraEditors.MemoEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.btnSaveComments = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtReferences = New DevExpress.XtraEditors.MemoEdit()
        Me.lblService = New DevExpress.XtraEditors.LabelControl()
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReferences.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(12, 90)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(574, 119)
        Me.txtComments.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Location = New System.Drawing.Point(12, 71)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(81, 14)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Comentarios:"
        '
        'btnSaveComments
        '
        Me.btnSaveComments.Location = New System.Drawing.Point(500, 332)
        Me.btnSaveComments.Name = "btnSaveComments"
        Me.btnSaveComments.Size = New System.Drawing.Size(86, 44)
        Me.btnSaveComments.TabIndex = 2
        Me.btnSaveComments.Text = "Grabar"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl2.Location = New System.Drawing.Point(12, 225)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(74, 14)
        Me.LabelControl2.TabIndex = 3
        Me.LabelControl2.Text = "Referencias:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtReferences
        '
        Me.txtReferences.Location = New System.Drawing.Point(12, 244)
        Me.txtReferences.Name = "txtReferences"
        Me.txtReferences.Size = New System.Drawing.Size(574, 69)
        Me.txtReferences.TabIndex = 1
        '
        'lblService
        '
        Me.lblService.Appearance.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblService.Location = New System.Drawing.Point(13, 12)
        Me.lblService.Name = "lblService"
        Me.lblService.Size = New System.Drawing.Size(94, 25)
        Me.lblService.TabIndex = 5
        Me.lblService.Text = "lblServicio"
        '
        'frmServicesComments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(598, 388)
        Me.Controls.Add(Me.lblService)
        Me.Controls.Add(Me.txtReferences)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.btnSaveComments)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtComments)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmServicesComments"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Comentarios y referencias"
        CType(Me.txtComments.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReferences.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtComments As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents btnSaveComments As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtReferences As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents lblService As DevExpress.XtraEditors.LabelControl
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerarServicios
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.rchSQLPreview = New System.Windows.Forms.RichTextBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbServiceType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtServiceDesription = New System.Windows.Forms.TextBox
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.rchClassCode = New System.Windows.Forms.RichTextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chklst_keycols = New System.Windows.Forms.CheckedListBox
        Me.cmbWebReference = New System.Windows.Forms.ComboBox
        Me.btn_GenerateClass = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.btnGenerateClientCode = New System.Windows.Forms.Button
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.rchtxtClientCode = New System.Windows.Forms.RichTextBox
        Me.cmbTableName = New System.Windows.Forms.ComboBox
        Me.txtServiceName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 100)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(870, 489)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(862, 463)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "SQL"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbServiceType)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtServiceDesription)
        Me.GroupBox1.Controls.Add(Me.btnGenerate)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(856, 457)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SQL Services Params"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rchSQLPreview)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox6.Location = New System.Drawing.Point(242, 16)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(611, 438)
        Me.GroupBox6.TabIndex = 24
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Generated code:"
        '
        'rchSQLPreview
        '
        Me.rchSQLPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rchSQLPreview.Font = New System.Drawing.Font("OCR A Extended", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchSQLPreview.Location = New System.Drawing.Point(3, 16)
        Me.rchSQLPreview.Name = "rchSQLPreview"
        Me.rchSQLPreview.Size = New System.Drawing.Size(605, 419)
        Me.rchSQLPreview.TabIndex = 6
        Me.rchSQLPreview.Text = ""
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox7.Location = New System.Drawing.Point(19, 153)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(201, 298)
        Me.GroupBox7.TabIndex = 23
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Select index columns"
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(3, 16)
        Me.CheckedListBox1.MultiColumn = True
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(195, 274)
        Me.CheckedListBox1.TabIndex = 2
        Me.CheckedListBox1.UseTabStops = False
        Me.CheckedListBox1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "ServiceType"
        '
        'cmbServiceType
        '
        Me.cmbServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbServiceType.FormattingEnabled = True
        Me.cmbServiceType.Items.AddRange(New Object() {"Create", "Update", "Delete", "SearchPartial", "SearchByKey"})
        Me.cmbServiceType.Location = New System.Drawing.Point(19, 43)
        Me.cmbServiceType.Name = "cmbServiceType"
        Me.cmbServiceType.Size = New System.Drawing.Size(201, 21)
        Me.cmbServiceType.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "ServiceDescription"
        '
        'txtServiceDesription
        '
        Me.txtServiceDesription.Location = New System.Drawing.Point(19, 88)
        Me.txtServiceDesription.Name = "txtServiceDesription"
        Me.txtServiceDesription.Size = New System.Drawing.Size(201, 20)
        Me.txtServiceDesription.TabIndex = 4
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(19, 114)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(201, 21)
        Me.btnGenerate.TabIndex = 5
        Me.btnGenerate.Text = "Copy Code"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(862, 463)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Clases"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.GroupBox5)
        Me.GroupBox3.Controls.Add(Me.cmbWebReference)
        Me.GroupBox3.Controls.Add(Me.btn_GenerateClass)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(856, 457)
        Me.GroupBox3.TabIndex = 23
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Class Code Serviceses Params"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rchClassCode)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox4.Location = New System.Drawing.Point(242, 16)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(611, 438)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Generated code:"
        '
        'rchClassCode
        '
        Me.rchClassCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rchClassCode.Font = New System.Drawing.Font("Segoe Condensed", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rchClassCode.Location = New System.Drawing.Point(3, 16)
        Me.rchClassCode.Name = "rchClassCode"
        Me.rchClassCode.Size = New System.Drawing.Size(605, 419)
        Me.rchClassCode.TabIndex = 6
        Me.rchClassCode.Text = ""
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chklst_keycols)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 111)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(233, 340)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "KeyColums"
        '
        'chklst_keycols
        '
        Me.chklst_keycols.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chklst_keycols.FormattingEnabled = True
        Me.chklst_keycols.Location = New System.Drawing.Point(3, 16)
        Me.chklst_keycols.MultiColumn = True
        Me.chklst_keycols.Name = "chklst_keycols"
        Me.chklst_keycols.Size = New System.Drawing.Size(227, 319)
        Me.chklst_keycols.TabIndex = 7
        Me.chklst_keycols.UseTabStops = False
        '
        'cmbWebReference
        '
        Me.cmbWebReference.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbWebReference.Font = New System.Drawing.Font("Segoe Condensed", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbWebReference.FormattingEnabled = True
        Me.cmbWebReference.Items.AddRange(New Object() {"OnePlanServices_Security.WMS_Security", "OnePlanServices_Settings.WMS_Settings", "OnePlanServices_Locations.WMS_Locations"})
        Me.cmbWebReference.Location = New System.Drawing.Point(6, 28)
        Me.cmbWebReference.Name = "cmbWebReference"
        Me.cmbWebReference.Size = New System.Drawing.Size(230, 21)
        Me.cmbWebReference.TabIndex = 6
        '
        'btn_GenerateClass
        '
        Me.btn_GenerateClass.Location = New System.Drawing.Point(109, 55)
        Me.btn_GenerateClass.Name = "btn_GenerateClass"
        Me.btn_GenerateClass.Size = New System.Drawing.Size(127, 24)
        Me.btn_GenerateClass.TabIndex = 9
        Me.btn_GenerateClass.Text = "Copy Code"
        Me.btn_GenerateClass.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(862, 463)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Client Code"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox9)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox8)
        Me.SplitContainer1.Size = New System.Drawing.Size(856, 457)
        Me.SplitContainer1.SplitterDistance = 285
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnGenerateClientCode)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(285, 457)
        Me.GroupBox9.TabIndex = 0
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Params"
        '
        'btnGenerateClientCode
        '
        Me.btnGenerateClientCode.Location = New System.Drawing.Point(171, 36)
        Me.btnGenerateClientCode.Name = "btnGenerateClientCode"
        Me.btnGenerateClientCode.Size = New System.Drawing.Size(96, 29)
        Me.btnGenerateClientCode.TabIndex = 0
        Me.btnGenerateClientCode.Text = "Generate code"
        Me.btnGenerateClientCode.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.rchtxtClientCode)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(567, 457)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Client generated code"
        '
        'rchtxtClientCode
        '
        Me.rchtxtClientCode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rchtxtClientCode.Location = New System.Drawing.Point(3, 16)
        Me.rchtxtClientCode.Name = "rchtxtClientCode"
        Me.rchtxtClientCode.Size = New System.Drawing.Size(561, 438)
        Me.rchtxtClientCode.TabIndex = 0
        Me.rchtxtClientCode.Text = ""
        '
        'cmbTableName
        '
        Me.cmbTableName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTableName.FormattingEnabled = True
        Me.cmbTableName.Items.AddRange(New Object() {"SONDA_DOCS", "SONDA_ORDERS_BY_DOC", "SONDA_TRANSPORT_COMPANIES", "SONDA_TRANSPORT_DRIVERS", "SONDA_TRANSPORT_VEHICULES"})
        Me.cmbTableName.Location = New System.Drawing.Point(6, 25)
        Me.cmbTableName.Name = "cmbTableName"
        Me.cmbTableName.Size = New System.Drawing.Size(320, 21)
        Me.cmbTableName.TabIndex = 0
        '
        'txtServiceName
        '
        Me.txtServiceName.Location = New System.Drawing.Point(125, 58)
        Me.txtServiceName.Name = "txtServiceName"
        Me.txtServiceName.Size = New System.Drawing.Size(201, 20)
        Me.txtServiceName.TabIndex = 1
        Me.txtServiceName.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "ServiceName" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbTableName)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtServiceName)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(870, 100)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "CommonGroup"
        '
        'frmGenerarServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(870, 589)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmGenerarServicios"
        Me.Text = "frmGenerarServicios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtServiceDesription As System.Windows.Forms.TextBox
    Friend WithEvents cmbTableName As System.Windows.Forms.ComboBox
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents txtServiceName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbServiceType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbWebReference As System.Windows.Forms.ComboBox
    Friend WithEvents btn_GenerateClass As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents chklst_keycols As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents rchSQLPreview As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rchClassCode As System.Windows.Forms.RichTextBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents rchtxtClientCode As System.Windows.Forms.RichTextBox
    Friend WithEvents btnGenerateClientCode As System.Windows.Forms.Button
    'Friend WithEvents ListBar1 As vbAccelerator.Components.ListBarControl.ListBar
End Class

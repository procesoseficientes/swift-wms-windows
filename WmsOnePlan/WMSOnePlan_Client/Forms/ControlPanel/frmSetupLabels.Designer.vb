<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetupLabels
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
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Dim SuperToolTip2 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem2 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Dim SuperToolTip3 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
        Dim ToolTipItem3 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl
        Me.grp_Etiquetas = New DevExpress.XtraNavBar.NavBarGroup
        Me.btnShow_4by4 = New DevExpress.XtraNavBar.NavBarItem
        Me.btnShow_4by6 = New DevExpress.XtraNavBar.NavBarItem
        Me.grp_info = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl3 = New DevExpress.XtraEditors.PanelControl
        Me.txtZPLCommands = New DevExpress.XtraEditors.MemoEdit
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl
        Me.PanelControl4 = New DevExpress.XtraEditors.PanelControl
        Me.lblLastUser = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblLastUpdated = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl
        Me.chkListLineas = New DevExpress.XtraEditors.CheckedListBoxControl
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl
        Me.btnUnLock = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel4 = New System.Windows.Forms.Panel
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grp_info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_info.SuspendLayout()
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl3.SuspendLayout()
        CType(Me.txtZPLCommands.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl4.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.chkListLineas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.grp_Etiquetas
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.grp_Etiquetas})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.btnShow_4by6, Me.btnShow_4by4})
        Me.NavBarControl1.Location = New System.Drawing.Point(10, 10)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.OptionsNavPane.ExpandedWidth = 140
        Me.NavBarControl1.Size = New System.Drawing.Size(178, 418)
        Me.NavBarControl1.SkinExplorerBarViewScrollStyle = DevExpress.XtraNavBar.SkinExplorerBarViewScrollStyle.Buttons
        Me.NavBarControl1.TabIndex = 5
        Me.NavBarControl1.Text = "Opciones"
        Me.NavBarControl1.View = New DevExpress.XtraNavBar.ViewInfo.SkinNavigationPaneViewInfoRegistrator
        '
        'grp_Etiquetas
        '
        Me.grp_Etiquetas.Caption = "Etiquetas Empaque"
        Me.grp_Etiquetas.Expanded = True
        Me.grp_Etiquetas.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText
        Me.grp_Etiquetas.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.btnShow_4by4), New DevExpress.XtraNavBar.NavBarItemLink(Me.btnShow_4by6)})
        Me.grp_Etiquetas.Name = "grp_Etiquetas"
        '
        'btnShow_4by4
        '
        Me.btnShow_4by4.Caption = "Etiqueta 4X4"
        Me.btnShow_4by4.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources._4_x_4_Label1
        Me.btnShow_4by4.Name = "btnShow_4by4"
        '
        'btnShow_4by6
        '
        Me.btnShow_4by6.Caption = "Etiqueta 4X6"
        Me.btnShow_4by6.LargeImage = Global.WMSOnePlan_Client.My.Resources.Resources._4_x_6_Label
        Me.btnShow_4by6.Name = "btnShow_4by6"
        '
        'grp_info
        '
        Me.grp_info.Controls.Add(Me.PanelControl3)
        Me.grp_info.Controls.Add(Me.PanelControl2)
        Me.grp_info.Controls.Add(Me.PanelControl1)
        Me.grp_info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grp_info.Location = New System.Drawing.Point(188, 10)
        Me.grp_info.Name = "grp_info"
        Me.grp_info.Size = New System.Drawing.Size(572, 418)
        Me.grp_info.TabIndex = 6
        Me.grp_info.Text = "Información General"
        '
        'PanelControl3
        '
        Me.PanelControl3.Controls.Add(Me.txtZPLCommands)
        Me.PanelControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl3.Location = New System.Drawing.Point(2, 67)
        Me.PanelControl3.Name = "PanelControl3"
        Me.PanelControl3.Size = New System.Drawing.Size(568, 241)
        Me.PanelControl3.TabIndex = 4
        '
        'txtZPLCommands
        '
        Me.txtZPLCommands.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtZPLCommands.EditValue = ""
        Me.txtZPLCommands.Location = New System.Drawing.Point(2, 2)
        Me.txtZPLCommands.Name = "txtZPLCommands"
        Me.txtZPLCommands.Properties.NullText = "No Hay Info"
        Me.txtZPLCommands.Properties.ReadOnly = True
        Me.txtZPLCommands.Size = New System.Drawing.Size(564, 237)
        Me.txtZPLCommands.TabIndex = 0
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.GroupControl3)
        Me.PanelControl2.Controls.Add(Me.Panel7)
        Me.PanelControl2.Controls.Add(Me.GroupControl2)
        Me.PanelControl2.Controls.Add(Me.Panel5)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl2.Location = New System.Drawing.Point(2, 308)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(568, 108)
        Me.PanelControl2.TabIndex = 1
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.PanelControl4)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupControl3.Location = New System.Drawing.Point(207, 2)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(339, 104)
        Me.GroupControl3.TabIndex = 12
        Me.GroupControl3.Text = "Asignar a linea(s):"
        '
        'PanelControl4
        '
        Me.PanelControl4.Controls.Add(Me.lblLastUser)
        Me.PanelControl4.Controls.Add(Me.Label2)
        Me.PanelControl4.Controls.Add(Me.lblLastUpdated)
        Me.PanelControl4.Controls.Add(Me.Label1)
        Me.PanelControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl4.Location = New System.Drawing.Point(2, 22)
        Me.PanelControl4.Name = "PanelControl4"
        Me.PanelControl4.Size = New System.Drawing.Size(335, 80)
        Me.PanelControl4.TabIndex = 0
        '
        'lblLastUser
        '
        Me.lblLastUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastUser.Location = New System.Drawing.Point(113, 34)
        Me.lblLastUser.Name = "lblLastUser"
        Me.lblLastUser.Size = New System.Drawing.Size(217, 13)
        Me.lblLastUser.TabIndex = 3
        Me.lblLastUser.Text = "..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ultimo usuario:"
        '
        'lblLastUpdated
        '
        Me.lblLastUpdated.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastUpdated.Location = New System.Drawing.Point(113, 6)
        Me.lblLastUpdated.Name = "lblLastUpdated"
        Me.lblLastUpdated.Size = New System.Drawing.Size(217, 13)
        Me.lblLastUpdated.TabIndex = 1
        Me.lblLastUpdated.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ultima modificación:"
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(197, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(10, 104)
        Me.Panel7.TabIndex = 11
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.chkListLineas)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupControl2.Location = New System.Drawing.Point(12, 2)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(185, 104)
        Me.GroupControl2.TabIndex = 10
        Me.GroupControl2.Text = "Asignar a linea(s):"
        '
        'chkListLineas
        '
        Me.chkListLineas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.chkListLineas.Items.AddRange(New DevExpress.XtraEditors.Controls.CheckedListBoxItem() {New DevExpress.XtraEditors.Controls.CheckedListBoxItem("LINEA_1"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("LINEA_2"), New DevExpress.XtraEditors.Controls.CheckedListBoxItem("LINEA_3")})
        Me.chkListLineas.Location = New System.Drawing.Point(2, 22)
        Me.chkListLineas.Name = "chkListLineas"
        Me.chkListLineas.Size = New System.Drawing.Size(181, 80)
        Me.chkListLineas.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel6)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(2, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(10, 104)
        Me.Panel5.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(10, 104)
        Me.Panel6.TabIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnUnLock)
        Me.PanelControl1.Controls.Add(Me.SimpleButton1)
        Me.PanelControl1.Controls.Add(Me.SimpleButton2)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(2, 22)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(568, 45)
        Me.PanelControl1.TabIndex = 0
        '
        'btnUnLock
        '
        Me.btnUnLock.Image = Global.WMSOnePlan_Client.My.Resources.Resources.small_edit
        Me.btnUnLock.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.btnUnLock.Location = New System.Drawing.Point(5, 5)
        Me.btnUnLock.Name = "btnUnLock"
        Me.btnUnLock.Size = New System.Drawing.Size(29, 30)
        ToolTipItem1.Text = "Editar comando ZPL"
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.btnUnLock.SuperTip = SuperToolTip1
        Me.btnUnLock.TabIndex = 4
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Image = Global.WMSOnePlan_Client.My.Resources.Resources.id_qa_file_save
        Me.SimpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(40, 5)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(29, 30)
        ToolTipItem2.Text = "Grabar cambios"
        SuperToolTip2.Items.Add(ToolTipItem2)
        Me.SimpleButton1.SuperTip = SuperToolTip2
        Me.SimpleButton1.TabIndex = 2
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Image = Global.WMSOnePlan_Client.My.Resources.Resources.UndoSmall
        Me.SimpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(75, 5)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(29, 30)
        ToolTipItem3.Text = "Restaurar ultimo comando grabado"
        SuperToolTip3.Items.Add(ToolTipItem3)
        Me.SimpleButton2.SuperTip = SuperToolTip3
        Me.SimpleButton2.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 438)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(760, 10)
        Me.Panel2.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(760, 10)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 428)
        Me.Panel3.TabIndex = 9
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(10, 428)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(750, 10)
        Me.Panel4.TabIndex = 10
        '
        'frmSetupLabels
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 438)
        Me.Controls.Add(Me.grp_info)
        Me.Controls.Add(Me.NavBarControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmSetupLabels"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configurar Etiquetas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grp_info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_info.ResumeLayout(False)
        CType(Me.PanelControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl3.ResumeLayout(False)
        CType(Me.txtZPLCommands.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.PanelControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl4.ResumeLayout(False)
        Me.PanelControl4.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.chkListLineas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents grp_Etiquetas As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents btnShow_4by4 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents btnShow_4by6 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents grp_info As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PanelControl3 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtZPLCommands As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnUnLock As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chkListLineas As DevExpress.XtraEditors.CheckedListBoxControl
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents PanelControl4 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents lblLastUser As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblLastUpdated As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
End Class

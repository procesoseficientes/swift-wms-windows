<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_info_handler_tree
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_info_handler_tree))
        Me.txtInputedData = New Resco.Controls.CommonControls.TouchTextBox
        Me.AdvancedTree_Default = New Resco.Controls.AdvancedTree.AdvancedTree
        Me.PANEL_TITLE = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate1 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.LICENSE_ID = New Resco.Controls.AdvancedTree.TextCell
        Me.CURRENT_LOCATION = New Resco.Controls.AdvancedTree.TextCell
        Me.QTY = New Resco.Controls.AdvancedTree.TextCell
        Me.MATERIAL_NAME_EXTENDED = New Resco.Controls.AdvancedTree.TextCell
        Me.IS_MASTER_PACK = New Resco.Controls.AdvancedTree.TextCell
        Me.CODIGO_POLIZA = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell1 = New Resco.Controls.AdvancedTree.TextCell
        Me.TextCell2 = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate2 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.SERIE = New Resco.Controls.AdvancedTree.TextCell
        Me.NodeTemplate3 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.SuspendLayout()
        '
        'txtInputedData
        '
        Me.txtInputedData.BackColor = System.Drawing.Color.White
        Me.txtInputedData.DefaultText = "..."
        Me.txtInputedData.DefaultTextFont = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Italic)
        Me.txtInputedData.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtInputedData.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        Me.txtInputedData.Location = New System.Drawing.Point(0, 0)
        Me.txtInputedData.Name = "txtInputedData"
        Me.txtInputedData.Size = New System.Drawing.Size(240, 24)
        Me.txtInputedData.TabIndex = 1
        Me.txtInputedData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AdvancedTree_Default
        '
        Me.AdvancedTree_Default.AutoScroll = True
        Me.AdvancedTree_Default.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedTree_Default.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedTree_Default.Footer = New Resco.Controls.AdvancedTree.Header(3, New String() {""})
        Me.AdvancedTree_Default.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.AdvancedTree_Default.GridColor = System.Drawing.Color.Transparent
        Me.AdvancedTree_Default.Header = New Resco.Controls.AdvancedTree.Header(0, New String() {""})
        Me.AdvancedTree_Default.Location = New System.Drawing.Point(0, 24)
        Me.AdvancedTree_Default.MinusImage = CType(resources.GetObject("AdvancedTree_Default.MinusImage"), System.Drawing.Image)
        Me.AdvancedTree_Default.Name = "AdvancedTree_Default"
        Me.AdvancedTree_Default.PlusImage = CType(resources.GetObject("AdvancedTree_Default.PlusImage"), System.Drawing.Image)
        Me.AdvancedTree_Default.PlusMinusMargin = New System.Drawing.Size(4, 4)
        Me.AdvancedTree_Default.PlusMinusSize = New System.Drawing.Size(64, 64)
        Me.AdvancedTree_Default.ScrollbarSmallChange = 24
        Me.AdvancedTree_Default.ScrollbarWidth = 24
        Me.AdvancedTree_Default.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect
        Me.AdvancedTree_Default.ShowFooter = True
        Me.AdvancedTree_Default.ShowHeader = True
        Me.AdvancedTree_Default.Size = New System.Drawing.Size(240, 376)
        Me.AdvancedTree_Default.TabIndex = 2
        Me.AdvancedTree_Default.Templates.Add(Me.NodeTemplate1)
        Me.AdvancedTree_Default.Templates.Add(Me.NodeTemplate2)
        Me.AdvancedTree_Default.Templates.Add(Me.NodeTemplate3)
        Me.AdvancedTree_Default.TouchScrolling = True
        Me.AdvancedTree_Default.TouchSensitivity = 9
        Me.AdvancedTree_Default.UseGradient = True
        '
        'PANEL_TITLE
        '
        Me.PANEL_TITLE.Alignment = Resco.Controls.AdvancedTree.Alignment.MiddleCenter
        Me.PANEL_TITLE.Border = Resco.Controls.AdvancedTree.BorderType.Flat
        Me.PANEL_TITLE.CellSource.ConstantData = "Scan SKU"
        Me.PANEL_TITLE.DesignName = "PANEL_TITLE"
        Me.PANEL_TITLE.ForeColor = System.Drawing.Color.White
        Me.PANEL_TITLE.Location = New System.Drawing.Point(0, 0)
        Me.PANEL_TITLE.Size = New System.Drawing.Size(-1, 30)
        Me.PANEL_TITLE.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        '
        'NodeTemplate1
        '
        Me.NodeTemplate1.BackColor = System.Drawing.Color.White
        Me.NodeTemplate1.CellTemplates.Add(Me.PANEL_TITLE)
        Me.NodeTemplate1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.DimGray, System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.Black, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate1.Height = 31
        Me.NodeTemplate1.Name = "NodeTemplate1"
        Me.NodeTemplate1.UseGradient = True
        '
        'LICENSE_ID
        '
        Me.LICENSE_ID.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.LICENSE_ID.CellSource.ColumnName = "LICENSE_ID"
        Me.LICENSE_ID.DesignName = "LICENSE_ID"
        Me.LICENSE_ID.ForeColor = System.Drawing.Color.White
        Me.LICENSE_ID.Location = New System.Drawing.Point(0, 0)
        Me.LICENSE_ID.SelectedBackColor = System.Drawing.Color.White
        Me.LICENSE_ID.Size = New System.Drawing.Size(97, 32)
        Me.LICENSE_ID.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'CURRENT_LOCATION
        '
        Me.CURRENT_LOCATION.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.CURRENT_LOCATION.CellSource.ColumnName = "CURRENT_LOCATION"
        Me.CURRENT_LOCATION.DesignName = "CURRENT_LOCATION"
        Me.CURRENT_LOCATION.ForeColor = System.Drawing.Color.White
        Me.CURRENT_LOCATION.Location = New System.Drawing.Point(98, 0)
        Me.CURRENT_LOCATION.SelectedBackColor = System.Drawing.Color.White
        Me.CURRENT_LOCATION.Size = New System.Drawing.Size(313, 32)
        Me.CURRENT_LOCATION.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'QTY
        '
        Me.QTY.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.QTY.CellSource.ColumnName = "QTY"
        Me.QTY.DesignName = "QTY"
        Me.QTY.ForeColor = System.Drawing.Color.White
        Me.QTY.Location = New System.Drawing.Point(304, 33)
        Me.QTY.SelectedBackColor = System.Drawing.Color.White
        Me.QTY.Size = New System.Drawing.Size(107, 64)
        Me.QTY.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'MATERIAL_NAME_EXTENDED
        '
        Me.MATERIAL_NAME_EXTENDED.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.MATERIAL_NAME_EXTENDED.CellSource.ColumnName = "MATERIAL_NAME_EXTENDED"
        Me.MATERIAL_NAME_EXTENDED.DesignName = "MATERIAL_NAME_EXTENDED"
        Me.MATERIAL_NAME_EXTENDED.ForeColor = System.Drawing.Color.White
        Me.MATERIAL_NAME_EXTENDED.Location = New System.Drawing.Point(0, 33)
        Me.MATERIAL_NAME_EXTENDED.SelectedBackColor = System.Drawing.Color.White
        Me.MATERIAL_NAME_EXTENDED.Size = New System.Drawing.Size(302, 64)
        Me.MATERIAL_NAME_EXTENDED.TextFont = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)
        '
        'IS_MASTER_PACK
        '
        Me.IS_MASTER_PACK.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.IS_MASTER_PACK.CellSource.ColumnName = "IS_MASTER_PACK"
        Me.IS_MASTER_PACK.DesignName = "IS_MASTER_PACK"
        Me.IS_MASTER_PACK.ForeColor = System.Drawing.Color.White
        Me.IS_MASTER_PACK.Location = New System.Drawing.Point(200, 98)
        Me.IS_MASTER_PACK.SelectedBackColor = System.Drawing.Color.White
        Me.IS_MASTER_PACK.Size = New System.Drawing.Size(210, 32)
        Me.IS_MASTER_PACK.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'CODIGO_POLIZA
        '
        Me.CODIGO_POLIZA.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.CODIGO_POLIZA.CellSource.ColumnName = "CODIGO_POLIZA"
        Me.CODIGO_POLIZA.DesignName = "CODIGO_POLIZA"
        Me.CODIGO_POLIZA.ForeColor = System.Drawing.Color.White
        Me.CODIGO_POLIZA.Location = New System.Drawing.Point(0, 98)
        Me.CODIGO_POLIZA.SelectedBackColor = System.Drawing.Color.White
        Me.CODIGO_POLIZA.Size = New System.Drawing.Size(200, 32)
        Me.CODIGO_POLIZA.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell1
        '
        Me.TextCell1.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell1.CellSource.ColumnName = "BATCH"
        Me.TextCell1.DesignName = "TextCell1"
        Me.TextCell1.ForeColor = System.Drawing.Color.White
        Me.TextCell1.Location = New System.Drawing.Point(0, 127)
        Me.TextCell1.SelectedBackColor = System.Drawing.Color.White
        Me.TextCell1.Size = New System.Drawing.Size(180, 32)
        Me.TextCell1.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'TextCell2
        '
        Me.TextCell2.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.TextCell2.CellSource.ColumnName = "DATE_EXPIRATION"
        Me.TextCell2.DesignName = "TextCell2"
        Me.TextCell2.ForeColor = System.Drawing.Color.White
        Me.TextCell2.FormatString = "{0:dd/MMM/yyyy}"
        Me.TextCell2.Location = New System.Drawing.Point(184, 127)
        Me.TextCell2.SelectedBackColor = System.Drawing.Color.White
        Me.TextCell2.Size = New System.Drawing.Size(225, 32)
        Me.TextCell2.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'NodeTemplate2
        '
        Me.NodeTemplate2.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate2.CellTemplates.Add(Me.LICENSE_ID)
        Me.NodeTemplate2.CellTemplates.Add(Me.CURRENT_LOCATION)
        Me.NodeTemplate2.CellTemplates.Add(Me.QTY)
        Me.NodeTemplate2.CellTemplates.Add(Me.MATERIAL_NAME_EXTENDED)
        Me.NodeTemplate2.CellTemplates.Add(Me.IS_MASTER_PACK)
        Me.NodeTemplate2.CellTemplates.Add(Me.CODIGO_POLIZA)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell1)
        Me.NodeTemplate2.CellTemplates.Add(Me.TextCell2)
        Me.NodeTemplate2.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate2.Height = 159
        Me.NodeTemplate2.Name = "NodeTemplate2"
        '
        'SERIE
        '
        Me.SERIE.Border = Resco.Controls.AdvancedTree.BorderType.Raised
        Me.SERIE.CellSource.ColumnName = "SERIAL"
        Me.SERIE.CustomizeCell = True
        Me.SERIE.DesignName = "SERIE"
        Me.SERIE.ForeColor = System.Drawing.Color.White
        Me.SERIE.Location = New System.Drawing.Point(0, 0)
        Me.SERIE.SelectedBackColor = System.Drawing.Color.White
        Me.SERIE.Size = New System.Drawing.Size(413, 32)
        Me.SERIE.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'NodeTemplate3
        '
        Me.NodeTemplate3.BackColor = System.Drawing.Color.Transparent
        Me.NodeTemplate3.CellTemplates.Add(Me.SERIE)
        Me.NodeTemplate3.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.SystemColors.ControlLightLight, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.NodeTemplate3.Height = 35
        Me.NodeTemplate3.Name = "NodeTemplate3"
        '
        'ctrl_info_handler_tree
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.AdvancedTree_Default)
        Me.Controls.Add(Me.txtInputedData)
        Me.Name = "ctrl_info_handler_tree"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtInputedData As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents AdvancedTree_Default As Resco.Controls.AdvancedTree.AdvancedTree
    Friend WithEvents NodeTemplate1 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents PANEL_TITLE As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents NodeTemplate2 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents LICENSE_ID As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents CURRENT_LOCATION As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents QTY As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents MATERIAL_NAME_EXTENDED As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents IS_MASTER_PACK As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents CODIGO_POLIZA As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell1 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents TextCell2 As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents NodeTemplate3 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents SERIE As Resco.Controls.AdvancedTree.TextCell

End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_info_handler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_info_handler))
        Me.txtInputedData = New Resco.Controls.CommonControls.TouchTextBox
        Me.AdvancedList_Default = New Resco.Controls.AdvancedList.AdvancedList
        Me.PANEL_TITLE = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate_Header = New Resco.Controls.AdvancedList.RowTemplate
        Me.CODIGO_POLIZA = New Resco.Controls.AdvancedList.TextCell
        Me.CURRENT_LOCATION = New Resco.Controls.AdvancedList.TextCell
        Me.QTY = New Resco.Controls.AdvancedList.TextCell
        Me.SKU = New Resco.Controls.AdvancedList.TextCell
        Me.BATCH = New Resco.Controls.AdvancedList.TextCell
        Me.DATE_EXPIRATION = New Resco.Controls.AdvancedList.TextCell
        Me.VIN = New Resco.Controls.AdvancedList.TextCell
        Me.HANDLE_SERIAL_DESCRIPTION = New Resco.Controls.AdvancedList.TextCell
        Me.IS_MASTER_PACK = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate_Row = New Resco.Controls.AdvancedList.RowTemplate
        Me.ButtonCell_RePrint = New Resco.Controls.AdvancedList.ButtonCell
        Me.ButtonCell_ReAllocPartial = New Resco.Controls.AdvancedList.ButtonCell
        Me.RowTemplate_Footer = New Resco.Controls.AdvancedList.RowTemplate
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
        Me.txtInputedData.TabIndex = 0
        Me.txtInputedData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AdvancedList_Default
        '
        Me.AdvancedList_Default.BackColor = System.Drawing.Color.White
        Me.AdvancedList_Default.DataRows.Clear()
        Me.AdvancedList_Default.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedList_Default.EnableHTCGyroSensor = True
        Me.AdvancedList_Default.EnableHTCNavSensor = True
        Me.AdvancedList_Default.FocusOnClick = True
        Me.AdvancedList_Default.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedList.FillDirection.Horizontal)
        Me.AdvancedList_Default.HeaderRow = New Resco.Controls.AdvancedList.HeaderRow(0, New String() {resources.GetString("AdvancedList_Default.HeaderRow")})
        Me.AdvancedList_Default.KeyNavigation = True
        Me.AdvancedList_Default.Location = New System.Drawing.Point(0, 24)
        Me.AdvancedList_Default.Name = "AdvancedList_Default"
        Me.AdvancedList_Default.NavSensorNavigation = True
        Me.AdvancedList_Default.SelectedTemplateIndex = 1
        Me.AdvancedList_Default.ShowHeader = True
        Me.AdvancedList_Default.ShowScrollbar = False
        Me.AdvancedList_Default.Size = New System.Drawing.Size(240, 376)
        Me.AdvancedList_Default.TabIndex = 1
        Me.AdvancedList_Default.TemplateIndex = 1
        Me.AdvancedList_Default.Templates.Add(Me.RowTemplate_Header)
        Me.AdvancedList_Default.Templates.Add(Me.RowTemplate_Row)
        Me.AdvancedList_Default.Templates.Add(Me.RowTemplate_Footer)
        Me.AdvancedList_Default.TouchScrolling = True
        Me.AdvancedList_Default.TouchSensitivity = 9
        '
        'PANEL_TITLE
        '
        Me.PANEL_TITLE.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter
        Me.PANEL_TITLE.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.PANEL_TITLE.CellSource.ConstantData = "Scan/Ingrese Licencia"
        Me.PANEL_TITLE.DesignName = "PANEL_TITLE"
        Me.PANEL_TITLE.ForeColor = System.Drawing.Color.White
        Me.PANEL_TITLE.Location = New System.Drawing.Point(0, 0)
        Me.PANEL_TITLE.Size = New System.Drawing.Size(-1, 24)
        Me.PANEL_TITLE.TextFont = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular)
        '
        'RowTemplate_Header
        '
        Me.RowTemplate_Header.BackColor = System.Drawing.Color.White
        Me.RowTemplate_Header.CellTemplates.Add(Me.PANEL_TITLE)
        Me.RowTemplate_Header.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.DimGray, System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.Black, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate_Header.Height = 24
        Me.RowTemplate_Header.Name = "RowTemplate_Header"
        '
        'CODIGO_POLIZA
        '
        Me.CODIGO_POLIZA.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.CODIGO_POLIZA.CellSource.ColumnName = "CODIGO_POLIZA"
        Me.CODIGO_POLIZA.DesignName = "CODIGO_POLIZA"
        Me.CODIGO_POLIZA.ForeColor = System.Drawing.Color.White
        Me.CODIGO_POLIZA.Location = New System.Drawing.Point(0, 0)
        Me.CODIGO_POLIZA.SelectedBackColor = System.Drawing.Color.White
        Me.CODIGO_POLIZA.Size = New System.Drawing.Size(75, 24)
        Me.CODIGO_POLIZA.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'CURRENT_LOCATION
        '
        Me.CURRENT_LOCATION.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.CURRENT_LOCATION.CellSource.ColumnName = "CURRENT_LOCATION"
        Me.CURRENT_LOCATION.DesignName = "CURRENT_LOCATION"
        Me.CURRENT_LOCATION.ForeColor = System.Drawing.Color.White
        Me.CURRENT_LOCATION.Location = New System.Drawing.Point(77, 0)
        Me.CURRENT_LOCATION.SelectedBackColor = System.Drawing.Color.White
        Me.CURRENT_LOCATION.Size = New System.Drawing.Size(90, 24)
        Me.CURRENT_LOCATION.TextFont = New System.Drawing.Font("Arial", 6.0!, System.Drawing.FontStyle.Regular)
        '
        'QTY
        '
        Me.QTY.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.QTY.CellSource.ColumnName = "QTY"
        Me.QTY.CustomizeCell = True
        Me.QTY.DesignName = "QTY"
        Me.QTY.ForeColor = System.Drawing.Color.White
        Me.QTY.Location = New System.Drawing.Point(169, 0)
        Me.QTY.Selectable = True
        Me.QTY.SelectedBackColor = System.Drawing.Color.White
        Me.QTY.Size = New System.Drawing.Size(71, 24)
        Me.QTY.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
        '
        'SKU
        '
        Me.SKU.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.SKU.CellSource.ColumnName = "MATERIAL_NAME_EXTENDED"
        Me.SKU.DesignName = "SKU"
        Me.SKU.ForeColor = System.Drawing.Color.White
        Me.SKU.Location = New System.Drawing.Point(0, 25)
        Me.SKU.SelectedBackColor = System.Drawing.Color.White
        Me.SKU.Size = New System.Drawing.Size(350, 24)
        Me.SKU.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'BATCH
        '
        Me.BATCH.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.BATCH.CellSource.ColumnName = "BATCH"
        Me.BATCH.DesignName = "BATCH"
        Me.BATCH.ForeColor = System.Drawing.Color.White
        Me.BATCH.Location = New System.Drawing.Point(0, 50)
        Me.BATCH.SelectedBackColor = System.Drawing.Color.White
        Me.BATCH.Size = New System.Drawing.Size(100, 24)
        Me.BATCH.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'DATE_EXPIRATION
        '
        Me.DATE_EXPIRATION.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.DATE_EXPIRATION.CellSource.ColumnName = "DATE_EXPIRATION"
        Me.DATE_EXPIRATION.DesignName = "DATE_EXPIRATION"
        Me.DATE_EXPIRATION.ForeColor = System.Drawing.Color.White
        Me.DATE_EXPIRATION.FormatString = "{0:dd/MMMM/yyyy}"
        Me.DATE_EXPIRATION.Location = New System.Drawing.Point(102, 51)
        Me.DATE_EXPIRATION.SelectedBackColor = System.Drawing.Color.White
        Me.DATE_EXPIRATION.Size = New System.Drawing.Size(77, 24)
        Me.DATE_EXPIRATION.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'VIN
        '
        Me.VIN.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.VIN.CellSource.ColumnName = "VIN"
        Me.VIN.DesignName = "VIN"
        Me.VIN.ForeColor = System.Drawing.Color.White
        Me.VIN.Location = New System.Drawing.Point(178, 51)
        Me.VIN.SelectedBackColor = System.Drawing.Color.White
        Me.VIN.Size = New System.Drawing.Size(62, 25)
        Me.VIN.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'HANDLE_SERIAL_DESCRIPTION
        '
        Me.HANDLE_SERIAL_DESCRIPTION.CellSource.ColumnName = "HANDLE_SERIAL_DESCRIPTION"
        Me.HANDLE_SERIAL_DESCRIPTION.DesignName = "HANDLE_SERIAL_DESCRIPTION"
        Me.HANDLE_SERIAL_DESCRIPTION.Location = New System.Drawing.Point(0, 75)
        Me.HANDLE_SERIAL_DESCRIPTION.SelectedBackColor = System.Drawing.Color.White
        Me.HANDLE_SERIAL_DESCRIPTION.Size = New System.Drawing.Size(137, 24)
        Me.HANDLE_SERIAL_DESCRIPTION.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'IS_MASTER_PACK
        '
        Me.IS_MASTER_PACK.CellSource.ColumnName = "IS_MASTER_PACK"
        Me.IS_MASTER_PACK.DesignName = "IS_MASTER_PACK"
        Me.IS_MASTER_PACK.Location = New System.Drawing.Point(139, 75)
        Me.IS_MASTER_PACK.SelectedBackColor = System.Drawing.Color.White
        Me.IS_MASTER_PACK.Size = New System.Drawing.Size(-1, 24)
        Me.IS_MASTER_PACK.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'RowTemplate_Row
        '
        Me.RowTemplate_Row.BackColor = System.Drawing.Color.Transparent
        Me.RowTemplate_Row.CellTemplates.Add(Me.CODIGO_POLIZA)
        Me.RowTemplate_Row.CellTemplates.Add(Me.CURRENT_LOCATION)
        Me.RowTemplate_Row.CellTemplates.Add(Me.QTY)
        Me.RowTemplate_Row.CellTemplates.Add(Me.SKU)
        Me.RowTemplate_Row.CellTemplates.Add(Me.BATCH)
        Me.RowTemplate_Row.CellTemplates.Add(Me.DATE_EXPIRATION)
        Me.RowTemplate_Row.CellTemplates.Add(Me.VIN)
        Me.RowTemplate_Row.CellTemplates.Add(Me.HANDLE_SERIAL_DESCRIPTION)
        Me.RowTemplate_Row.CellTemplates.Add(Me.IS_MASTER_PACK)
        Me.RowTemplate_Row.ForeColor = System.Drawing.Color.White
        Me.RowTemplate_Row.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate_Row.Height = 100
        Me.RowTemplate_Row.Name = "RowTemplate_Row"
        '
        'ButtonCell_RePrint
        '
        Me.ButtonCell_RePrint.ButtonStyle = Resco.Controls.AdvancedList.ButtonCell.ButtonType.VistaStyleImageButton
        Me.ButtonCell_RePrint.DesignName = "ButtonCell_RePrint"
        Me.ButtonCell_RePrint.Location = New System.Drawing.Point(0, 0)
        Me.ButtonCell_RePrint.PressedBackColor = System.Drawing.Color.DarkOrange
        Me.ButtonCell_RePrint.Selectable = True
        Me.ButtonCell_RePrint.Size = New System.Drawing.Size(119, 48)
        Me.ButtonCell_RePrint.Text = "Imprimir"
        Me.ButtonCell_RePrint.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'ButtonCell_ReAllocPartial
        '
        Me.ButtonCell_ReAllocPartial.ButtonStyle = Resco.Controls.AdvancedList.ButtonCell.ButtonType.VistaStyleImageButton
        Me.ButtonCell_ReAllocPartial.DesignName = "ButtonCell_ReAllocPartial"
        Me.ButtonCell_ReAllocPartial.Location = New System.Drawing.Point(119, 0)
        Me.ButtonCell_ReAllocPartial.PressedBackColor = System.Drawing.Color.DarkOrange
        Me.ButtonCell_ReAllocPartial.Selectable = True
        Me.ButtonCell_ReAllocPartial.Size = New System.Drawing.Size(121, 48)
        Me.ButtonCell_ReAllocPartial.Text = "Reubicar Parcial"
        Me.ButtonCell_ReAllocPartial.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'RowTemplate_Footer
        '
        Me.RowTemplate_Footer.BackColor = System.Drawing.Color.Transparent
        Me.RowTemplate_Footer.CellTemplates.Add(Me.ButtonCell_RePrint)
        Me.RowTemplate_Footer.CellTemplates.Add(Me.ButtonCell_ReAllocPartial)
        Me.RowTemplate_Footer.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate_Footer.Height = 48
        Me.RowTemplate_Footer.Name = "RowTemplate_Footer"
        '
        'ctrl_info_handler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.AdvancedList_Default)
        Me.Controls.Add(Me.txtInputedData)
        Me.Name = "ctrl_info_handler"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtInputedData As Resco.Controls.CommonControls.TouchTextBox
    Friend WithEvents AdvancedList_Default As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents RowTemplate_Header As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents PANEL_TITLE As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate_Row As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents CODIGO_POLIZA As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents CURRENT_LOCATION As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents QTY As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents SKU As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents BATCH As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents DATE_EXPIRATION As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents VIN As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents HANDLE_SERIAL_DESCRIPTION As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents IS_MASTER_PACK As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate_Footer As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents ButtonCell_RePrint As Resco.Controls.AdvancedList.ButtonCell
    Friend WithEvents ButtonCell_ReAllocPartial As Resco.Controls.AdvancedList.ButtonCell

End Class

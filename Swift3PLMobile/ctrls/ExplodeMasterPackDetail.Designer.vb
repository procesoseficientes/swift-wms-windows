<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ExplodeMasterPackDetail
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExplodeMasterPackDetail))
        Me.UiListaDetalleComponente = New Resco.Controls.AdvancedList.AdvancedList
        Me.RowTemplate_Header = New Resco.Controls.AdvancedList.RowTemplate
        Me.PANEL_TITLE = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate_Row = New Resco.Controls.AdvancedList.RowTemplate
        Me.MATERIAL_ID = New Resco.Controls.AdvancedList.TextCell
        Me.MATERIAL_NAME = New Resco.Controls.AdvancedList.TextCell
        Me.QTY = New Resco.Controls.AdvancedList.TextCell
        Me.BATCH = New Resco.Controls.AdvancedList.TextCell
        Me.DATE_EXPIRATION = New Resco.Controls.AdvancedList.TextCell
        Me.MEASUREMENT_UNIT = New Resco.Controls.AdvancedList.TextCell
        Me.SuspendLayout()
        '
        'UiListaDetalleComponente
        '
        Me.UiListaDetalleComponente.BackColor = System.Drawing.Color.White
        Me.UiListaDetalleComponente.DataRows.Clear()
        Me.UiListaDetalleComponente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UiListaDetalleComponente.EnableHTCGyroSensor = True
        Me.UiListaDetalleComponente.EnableHTCNavSensor = True
        Me.UiListaDetalleComponente.FocusOnClick = True
        Me.UiListaDetalleComponente.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedList.FillDirection.Horizontal)
        Me.UiListaDetalleComponente.HeaderRow = New Resco.Controls.AdvancedList.HeaderRow(0, New String() {resources.GetString("UiListaDetalleComponente.HeaderRow")})
        Me.UiListaDetalleComponente.KeyNavigation = True
        Me.UiListaDetalleComponente.Location = New System.Drawing.Point(0, 0)
        Me.UiListaDetalleComponente.Name = "UiListaDetalleComponente"
        Me.UiListaDetalleComponente.NavSensorNavigation = True
        Me.UiListaDetalleComponente.SelectedTemplateIndex = 1
        Me.UiListaDetalleComponente.ShowHeader = True
        Me.UiListaDetalleComponente.ShowScrollbar = False
        Me.UiListaDetalleComponente.Size = New System.Drawing.Size(240, 400)
        Me.UiListaDetalleComponente.TabIndex = 2
        Me.UiListaDetalleComponente.TemplateIndex = 1
        Me.UiListaDetalleComponente.Templates.Add(Me.RowTemplate_Header)
        Me.UiListaDetalleComponente.Templates.Add(Me.RowTemplate_Row)
        Me.UiListaDetalleComponente.TouchScrolling = True
        Me.UiListaDetalleComponente.TouchSensitivity = 9
        '
        'RowTemplate_Header
        '
        Me.RowTemplate_Header.BackColor = System.Drawing.Color.White
        Me.RowTemplate_Header.CellTemplates.Add(Me.PANEL_TITLE)
        Me.RowTemplate_Header.GradientBackColor = New Resco.Controls.AdvancedList.GradientColor(System.Drawing.Color.DimGray, System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer)), System.Drawing.Color.Black, Resco.Controls.AdvancedList.FillDirection.Vertical)
        Me.RowTemplate_Header.Height = 24
        Me.RowTemplate_Header.Name = "RowTemplate_Header"
        '
        'PANEL_TITLE
        '
        Me.PANEL_TITLE.Alignment = Resco.Controls.AdvancedList.Alignment.MiddleCenter
        Me.PANEL_TITLE.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.PANEL_TITLE.CellSource.ConstantData = "Detalle"
        Me.PANEL_TITLE.DesignName = "PANEL_TITLE"
        Me.PANEL_TITLE.ForeColor = System.Drawing.Color.White
        Me.PANEL_TITLE.Location = New System.Drawing.Point(0, 0)
        Me.PANEL_TITLE.Size = New System.Drawing.Size(-1, 24)
        Me.PANEL_TITLE.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'RowTemplate_Row
        '
        Me.RowTemplate_Row.BackColor = System.Drawing.Color.Transparent
        Me.RowTemplate_Row.CellTemplates.Add(Me.MATERIAL_ID)
        Me.RowTemplate_Row.CellTemplates.Add(Me.MATERIAL_NAME)
        Me.RowTemplate_Row.CellTemplates.Add(Me.QTY)
        Me.RowTemplate_Row.CellTemplates.Add(Me.BATCH)
        Me.RowTemplate_Row.CellTemplates.Add(Me.DATE_EXPIRATION)
        Me.RowTemplate_Row.CellTemplates.Add(Me.MEASUREMENT_UNIT)
        Me.RowTemplate_Row.ForeColor = System.Drawing.Color.White
        Me.RowTemplate_Row.Height = 100
        Me.RowTemplate_Row.Name = "RowTemplate_Row"
        '
        'MATERIAL_ID
        '
        Me.MATERIAL_ID.CellSource.ColumnName = "MATERIAL_ID"
        Me.MATERIAL_ID.DesignName = "MATERIAL_ID"
        Me.MATERIAL_ID.ForeColor = System.Drawing.Color.White
        Me.MATERIAL_ID.Location = New System.Drawing.Point(0, 0)
        Me.MATERIAL_ID.SelectedBackColor = System.Drawing.Color.White
        Me.MATERIAL_ID.Size = New System.Drawing.Size(109, 24)
        Me.MATERIAL_ID.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'MATERIAL_NAME
        '
        Me.MATERIAL_NAME.CellSource.ColumnName = "MATERIAL_NAME"
        Me.MATERIAL_NAME.DesignName = "MATERIAL_NAME"
        Me.MATERIAL_NAME.ForeColor = System.Drawing.Color.White
        Me.MATERIAL_NAME.Location = New System.Drawing.Point(0, 25)
        Me.MATERIAL_NAME.SelectedBackColor = System.Drawing.Color.White
        Me.MATERIAL_NAME.Size = New System.Drawing.Size(350, 24)
        Me.MATERIAL_NAME.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'QTY
        '
        Me.QTY.Border = Resco.Controls.AdvancedList.BorderType.Raised
        Me.QTY.CellSource.ColumnName = "QTY"
        Me.QTY.DesignName = "QTY"
        Me.QTY.ForeColor = System.Drawing.Color.White
        Me.QTY.Location = New System.Drawing.Point(115, 0)
        Me.QTY.SelectedBackColor = System.Drawing.Color.White
        Me.QTY.Size = New System.Drawing.Size(124, 24)
        Me.QTY.TextFont = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular)
        '
        'BATCH
        '
        Me.BATCH.CellSource.ColumnName = "BATCH"
        Me.BATCH.DesignName = "BATCH"
        Me.BATCH.ForeColor = System.Drawing.Color.White
        Me.BATCH.Location = New System.Drawing.Point(1, 51)
        Me.BATCH.SelectedBackColor = System.Drawing.Color.White
        Me.BATCH.Size = New System.Drawing.Size(110, 24)
        Me.BATCH.TextFont = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular)
        '
        'DATE_EXPIRATION
        '
        Me.DATE_EXPIRATION.CellSource.ColumnName = "DATE_EXPIRATION"
        Me.DATE_EXPIRATION.DesignName = "DATE_EXPIRATION"
        Me.DATE_EXPIRATION.ForeColor = System.Drawing.Color.White
        Me.DATE_EXPIRATION.Location = New System.Drawing.Point(113, 51)
        Me.DATE_EXPIRATION.SelectedBackColor = System.Drawing.Color.White
        Me.DATE_EXPIRATION.Size = New System.Drawing.Size(-1, 24)
        Me.DATE_EXPIRATION.TextFont = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular)
        '
        'MEASUREMENT_UNIT
        '
        Me.MEASUREMENT_UNIT.CellSource.ColumnName = "MEASUREMENT_UNIT"
        Me.MEASUREMENT_UNIT.DesignName = "MEASUREMENT_UNIT"
        Me.MEASUREMENT_UNIT.ForeColor = System.Drawing.Color.White
        Me.MEASUREMENT_UNIT.Location = New System.Drawing.Point(0, 75)
        Me.MEASUREMENT_UNIT.SelectedBackColor = System.Drawing.Color.White
        Me.MEASUREMENT_UNIT.Size = New System.Drawing.Size(-1, 24)
        Me.MEASUREMENT_UNIT.TextFont = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular)
        '
        'ExplodeMasterPackDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.UiListaDetalleComponente)
        Me.Name = "ExplodeMasterPackDetail"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UiListaDetalleComponente As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents RowTemplate_Header As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents PANEL_TITLE As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate_Row As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents MATERIAL_ID As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents MATERIAL_NAME As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents QTY As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents BATCH As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents DATE_EXPIRATION As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents MEASUREMENT_UNIT As Resco.Controls.AdvancedList.TextCell

End Class

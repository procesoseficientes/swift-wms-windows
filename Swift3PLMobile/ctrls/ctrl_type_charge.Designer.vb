<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class ctrl_type_charge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ctrl_type_charge))
        Me.AdvancedList_Default = New Resco.Controls.AdvancedList.AdvancedList
        Me.RowTemplate_Header = New Resco.Controls.AdvancedList.RowTemplate
        Me.PANEL_TITLE = New Resco.Controls.AdvancedList.TextCell
        Me.RowTemplate_Row = New Resco.Controls.AdvancedList.RowTemplate
        Me.CODIGO_TIPO_COBRO = New Resco.Controls.AdvancedList.TextCell
        Me.DESCRIPTION = New Resco.Controls.AdvancedList.TextCell
        Me.QTY = New Resco.Controls.AdvancedList.TextCell
        Me.btnQty = New Resco.Controls.AdvancedList.ButtonCell
        Me.pnlCantidad = New System.Windows.Forms.Panel
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtQTY = New System.Windows.Forms.TextBox
        Me.pnlCantidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdvancedList_Default
        '
        Me.AdvancedList_Default.BackColor = System.Drawing.Color.White
        Me.AdvancedList_Default.BackgroundImage = CType(resources.GetObject("AdvancedList_Default.BackgroundImage"), System.Drawing.Image)
        Me.AdvancedList_Default.DataRows.Clear()
        Me.AdvancedList_Default.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedList_Default.EnableHTCGyroSensor = True
        Me.AdvancedList_Default.EnableHTCNavSensor = True
        Me.AdvancedList_Default.FocusOnClick = True
        Me.AdvancedList_Default.HeaderRow = New Resco.Controls.AdvancedList.HeaderRow(0, New String() {resources.GetString("AdvancedList_Default.HeaderRow")})
        Me.AdvancedList_Default.KeyNavigation = True
        Me.AdvancedList_Default.Location = New System.Drawing.Point(0, 0)
        Me.AdvancedList_Default.Name = "AdvancedList_Default"
        Me.AdvancedList_Default.NavSensorNavigation = True
        Me.AdvancedList_Default.SelectedTemplateIndex = 1
        Me.AdvancedList_Default.ShowHeader = True
        Me.AdvancedList_Default.ShowScrollbar = False
        Me.AdvancedList_Default.Size = New System.Drawing.Size(240, 400)
        Me.AdvancedList_Default.TabIndex = 2
        Me.AdvancedList_Default.TemplateIndex = 1
        Me.AdvancedList_Default.Templates.Add(Me.RowTemplate_Header)
        Me.AdvancedList_Default.Templates.Add(Me.RowTemplate_Row)
        Me.AdvancedList_Default.TouchScrolling = True
        Me.AdvancedList_Default.TouchSensitivity = 9
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
        Me.PANEL_TITLE.CellSource.ConstantData = "Tipos de Cobro"
        Me.PANEL_TITLE.DesignName = "PANEL_TITLE"
        Me.PANEL_TITLE.ForeColor = System.Drawing.Color.White
        Me.PANEL_TITLE.Location = New System.Drawing.Point(0, 0)
        Me.PANEL_TITLE.Size = New System.Drawing.Size(-1, 24)
        Me.PANEL_TITLE.TextFont = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular)
        '
        'RowTemplate_Row
        '
        Me.RowTemplate_Row.BackColor = System.Drawing.Color.Transparent
        Me.RowTemplate_Row.CellTemplates.Add(Me.CODIGO_TIPO_COBRO)
        Me.RowTemplate_Row.CellTemplates.Add(Me.DESCRIPTION)
        Me.RowTemplate_Row.CellTemplates.Add(Me.QTY)
        Me.RowTemplate_Row.CellTemplates.Add(Me.btnQty)
        Me.RowTemplate_Row.ForeColor = System.Drawing.Color.White
        Me.RowTemplate_Row.Height = 50
        Me.RowTemplate_Row.Name = "RowTemplate_Row"
        '
        'CODIGO_TIPO_COBRO
        '
        Me.CODIGO_TIPO_COBRO.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.CODIGO_TIPO_COBRO.CellSource.ColumnName = "TYPE_CHARGE_ID"
        Me.CODIGO_TIPO_COBRO.DesignName = "CODIGO_TIPO_COBRO"
        Me.CODIGO_TIPO_COBRO.ForeColor = System.Drawing.Color.White
        Me.CODIGO_TIPO_COBRO.Location = New System.Drawing.Point(0, 0)
        Me.CODIGO_TIPO_COBRO.SelectedBackColor = System.Drawing.Color.White
        Me.CODIGO_TIPO_COBRO.Size = New System.Drawing.Size(20, 50)
        Me.CODIGO_TIPO_COBRO.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        Me.CODIGO_TIPO_COBRO.Visible = False
        '
        'DESCRIPTION
        '
        Me.DESCRIPTION.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.DESCRIPTION.CellSource.ColumnName = "DESCRIPTION"
        Me.DESCRIPTION.DesignName = "DESCRIPTION"
        Me.DESCRIPTION.ForeColor = System.Drawing.Color.White
        Me.DESCRIPTION.Location = New System.Drawing.Point(0, 0)
        Me.DESCRIPTION.SelectedBackColor = System.Drawing.Color.White
        Me.DESCRIPTION.Size = New System.Drawing.Size(195, 50)
        Me.DESCRIPTION.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'QTY
        '
        Me.QTY.Border = Resco.Controls.AdvancedList.BorderType.Flat
        Me.QTY.CellSource.ColumnName = "QTY"
        Me.QTY.CustomizeCell = True
        Me.QTY.DesignName = "QTY"
        Me.QTY.ForeColor = System.Drawing.Color.White
        Me.QTY.Location = New System.Drawing.Point(195, 0)
        Me.QTY.Selectable = True
        Me.QTY.SelectedBackColor = System.Drawing.Color.White
        Me.QTY.Size = New System.Drawing.Size(25, 50)
        Me.QTY.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
        '
        'btnQty
        '
        Me.btnQty.BackColor = System.Drawing.Color.Gainsboro
        Me.btnQty.DesignName = "btnQty"
        Me.btnQty.ForeColor = System.Drawing.Color.Black
        Me.btnQty.Location = New System.Drawing.Point(220, 0)
        Me.btnQty.Selectable = True
        Me.btnQty.Size = New System.Drawing.Size(20, 50)
        Me.btnQty.Text = "..."
        Me.btnQty.TextFont = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular)
        '
        'pnlCantidad
        '
        Me.pnlCantidad.BackColor = System.Drawing.Color.Silver
        Me.pnlCantidad.Controls.Add(Me.btnAceptar)
        Me.pnlCantidad.Controls.Add(Me.btnCancelar)
        Me.pnlCantidad.Controls.Add(Me.Label1)
        Me.pnlCantidad.Controls.Add(Me.txtQTY)
        Me.pnlCantidad.Location = New System.Drawing.Point(13, 151)
        Me.pnlCantidad.Name = "pnlCantidad"
        Me.pnlCantidad.Size = New System.Drawing.Size(214, 99)
        Me.pnlCantidad.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(28, 60)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(85, 32)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Grabar"
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(121, 60)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 32)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(13, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.Text = "Cantidad"
        '
        'txtQTY
        '
        Me.txtQTY.Location = New System.Drawing.Point(13, 33)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(188, 21)
        Me.txtQTY.TabIndex = 0
        '
        'ctrl_type_charge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.pnlCantidad)
        Me.Controls.Add(Me.AdvancedList_Default)
        Me.Name = "ctrl_type_charge"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.pnlCantidad.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvancedList_Default As Resco.Controls.AdvancedList.AdvancedList
    Friend WithEvents RowTemplate_Header As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents PANEL_TITLE As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents RowTemplate_Row As Resco.Controls.AdvancedList.RowTemplate
    Friend WithEvents CODIGO_TIPO_COBRO As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents DESCRIPTION As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents QTY As Resco.Controls.AdvancedList.TextCell
    Friend WithEvents pnlCantidad As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtQTY As System.Windows.Forms.TextBox
    Friend WithEvents btnQty As Resco.Controls.AdvancedList.ButtonCell

End Class

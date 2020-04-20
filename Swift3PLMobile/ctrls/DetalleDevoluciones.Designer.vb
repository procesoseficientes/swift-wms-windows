<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class DetalleDevoluciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DetalleDevoluciones))
        Me.AdvancedTree1 = New Resco.Controls.AdvancedTree.AdvancedTree
        Me.colMaterial = New Resco.Controls.AdvancedTree.TextCell
        Me.colCantidad = New Resco.Controls.AdvancedTree.TextCell
        Me.colDescripcion = New Resco.Controls.AdvancedTree.TextCell
        Me.colLicencia = New Resco.Controls.AdvancedTree.TextCell
        Me.nodeTemplate1 = New Resco.Controls.AdvancedTree.NodeTemplate
        Me.SuspendLayout()
        '
        'AdvancedTree1
        '
        Me.AdvancedTree1.AutoScroll = True
        Me.AdvancedTree1.BackColor = System.Drawing.Color.Transparent
        Me.AdvancedTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvancedTree1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(71, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(132, Byte), Integer)), Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.AdvancedTree1.KeyNavigation = True
        Me.AdvancedTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvancedTree1.MinusImage = CType(resources.GetObject("AdvancedTree1.MinusImage"), System.Drawing.Image)
        Me.AdvancedTree1.Name = "AdvancedTree1"
        Me.AdvancedTree1.PlusImage = CType(resources.GetObject("AdvancedTree1.PlusImage"), System.Drawing.Image)
        Me.AdvancedTree1.PlusMinusMargin = New System.Drawing.Size(4, 4)
        Me.AdvancedTree1.PlusMinusSize = New System.Drawing.Size(32, 32)
        Me.AdvancedTree1.ScrollbarSmallChange = 24
        Me.AdvancedTree1.ScrollbarWidth = 24
        Me.AdvancedTree1.SelectionMode = Resco.Controls.AdvancedTree.SelectionMode.SelectDeselect
        Me.AdvancedTree1.ShowPlusMinus = False
        Me.AdvancedTree1.ShowScrollbar = False
        Me.AdvancedTree1.Size = New System.Drawing.Size(240, 400)
        Me.AdvancedTree1.TabIndex = 0
        Me.AdvancedTree1.Templates.Add(Me.nodeTemplate1)
        Me.AdvancedTree1.TouchScrolling = True
        Me.AdvancedTree1.TouchSensitivity = 9
        Me.AdvancedTree1.TreeNodeLines = True
        Me.AdvancedTree1.UseGradient = True
        '
        'colMaterial
        '
        Me.colMaterial.CellSource.ColumnIndex = 1
        Me.colMaterial.DesignName = "colMaterial"
        Me.colMaterial.ForeColor = System.Drawing.Color.White
        Me.colMaterial.Location = New System.Drawing.Point(0, 0)
        Me.colMaterial.Size = New System.Drawing.Size(150, 30)
        '
        'colCantidad
        '
        Me.colCantidad.CellSource.ColumnIndex = 3
        Me.colCantidad.DesignName = "colCantidad"
        Me.colCantidad.ForeColor = System.Drawing.Color.White
        Me.colCantidad.Location = New System.Drawing.Point(150, 0)
        Me.colCantidad.Size = New System.Drawing.Size(-1, 30)
        '
        'colDescripcion
        '
        Me.colDescripcion.CellSource.ColumnIndex = 2
        Me.colDescripcion.DesignName = "colDescripcion"
        Me.colDescripcion.ForeColor = System.Drawing.Color.White
        Me.colDescripcion.Location = New System.Drawing.Point(0, 30)
        Me.colDescripcion.Size = New System.Drawing.Size(-1, 30)
        '
        'colLicencia
        '
        Me.colLicencia.CellSource.ColumnIndex = 0
        Me.colLicencia.DesignName = "colLicencia"
        Me.colLicencia.ForeColor = System.Drawing.Color.White
        Me.colLicencia.FormatString = "Licencia: {0}"
        Me.colLicencia.Location = New System.Drawing.Point(0, 60)
        Me.colLicencia.Size = New System.Drawing.Size(-1, 30)
        '
        'nodeTemplate1
        '
        Me.nodeTemplate1.BackColor = System.Drawing.Color.Transparent
        Me.nodeTemplate1.CellTemplates.Add(Me.colMaterial)
        Me.nodeTemplate1.CellTemplates.Add(Me.colCantidad)
        Me.nodeTemplate1.CellTemplates.Add(Me.colDescripcion)
        Me.nodeTemplate1.CellTemplates.Add(Me.colLicencia)
        Me.nodeTemplate1.ForeColor = System.Drawing.Color.Transparent
        Me.nodeTemplate1.GradientBackColor = New Resco.Controls.AdvancedTree.GradientColor(System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent, Resco.Controls.AdvancedTree.FillDirection.Vertical)
        Me.nodeTemplate1.Height = 90
        Me.nodeTemplate1.Name = "nodeTemplate1"
        Me.nodeTemplate1.UseTemplateBackground = True
        '
        'DetalleDevoluciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.AdvancedTree1)
        Me.Name = "DetalleDevoluciones"
        Me.Size = New System.Drawing.Size(240, 400)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AdvancedTree1 As Resco.Controls.AdvancedTree.AdvancedTree
    Friend WithEvents nodeTemplate1 As Resco.Controls.AdvancedTree.NodeTemplate
    Friend WithEvents colMaterial As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents colCantidad As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents colDescripcion As Resco.Controls.AdvancedTree.TextCell
    Friend WithEvents colLicencia As Resco.Controls.AdvancedTree.TextCell

End Class

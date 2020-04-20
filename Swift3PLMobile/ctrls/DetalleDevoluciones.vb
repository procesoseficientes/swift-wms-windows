Imports System.Text
Imports System.IO
Imports Resco.Controls.AdvancedList
Imports Resco.Controls.MessageBox
Imports System.Runtime.CompilerServices
Imports MobilityScm.Keyboard
Imports Resco.Controls.AdvancedTree

Public Class DetalleDevoluciones

#Region "Eventos de Controles"
    Private Sub SerialNumberProcess_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Sub UiVistaDetalleIngresoSeries_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        ProcessLastKey(e)
    End Sub

    Private Sub AdvancedTree1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AdvancedTree1.KeyUp
        ProcessLastKey(e)
    End Sub
#End Region

#Region "Metodos"
    Sub ProcessLastKey(ByVal e As System.Windows.Forms.KeyEventArgs)
        Try
            Select Case e.ObtenerActionDeBoton(GlobalEnviroment, Global_WS_HOST)
                Case MobilityScm.Modelo.Tipos.FuncionBoton.SALIR
                    Dim xctrl As Control, xFoundCtrl As Control = Nothing
                    For Each xctrl In frmBase.Controls
                        If xctrl.Name = gLastPanelName Then
                            xFoundCtrl = xctrl
                            Exit For
                        End If
                    Next

                    gCurrentScannerService = gSCANNER_SERVICES.LEER_SKU_EN_RECEPCION_FISCAL
                    gCurrentPage = "sku_license"
                    ShowPanel(CType(xFoundCtrl, UserControl))
            End Select
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Public Sub CargarListaDetalle(ByVal Tarea As Integer)
        Try
            Dim serviceTrans As New WMS_InfoTrans.WMS_InfoTrans
            Dim detalle As New Data.DataSet
            Dim resultado As String = ""
            detalle = serviceTrans.ObtenerDetalleDeRecepcionPorDevolucionPorTarea(Tarea, GlobalEnviroment, resultado)
            AdvancedTree1.Nodes.Clear()
            ArmarArbol(detalle)
        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub

    Sub ArmarArbol(ByVal detalle As Data.DataSet)
        Try
            For Each row As Data.DataRow In detalle.Tables(0).Rows
                Dim nodo As BoundNode = New BoundNode(0, 0, row)
                AdvancedTree1.Nodes.Add(nodo)
                nodo.HidePlusMinus = True
                nodo.Collapse()
            Next
            Dim filaExtra = detalle.Tables(0).NewRow
            Dim nodoExtra = New BoundNode(0, 0, filaExtra)
            AdvancedTree1.Nodes.Add(nodoExtra)
            nodoExtra.HidePlusMinus = True
            nodoExtra.Collapse()

        Catch ex As Exception
            Notify(ex.Message, True)
        End Try
    End Sub
#End Region

End Class

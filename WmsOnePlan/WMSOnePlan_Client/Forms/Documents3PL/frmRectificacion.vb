Imports System.IO
Imports System.Data
Public Class frmRectificacion
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim pRESULT As String = String.Empty
    Public stCUST As String
    Public stRELPOL As String
    Public inDOCID As Integer

    Private Sub frmRectificacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim strPath As String
        Try
            gLastScreenShowed = Me.Name

            'grabamos el layout del grid 
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmRectificaciongrid1" & PublicLoginInfo.LoginID & ".xml"
            GridView1.SaveLayoutToXml(strPath)
            strPath = String.Empty

        Catch ex As Exception
            MsgBox("Error al Cerrar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")

        End Try
    End Sub
    Private Sub frmRectificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strPath As String
        Dim dsHead As New DataSet
        Try
            strPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location).ToString() & "\frmRectificaciongrid1" & PublicLoginInfo.LoginID & ".xml"

            If File.Exists(strPath) Then
                GridView1.RestoreLayoutFromXml(strPath)
            End If

            dsHead = xserv.get_all_Poliza_Headers(" where tipo = 'INGRESO' and STATUS <> 'RECTIFICADO' and CLIENT_CODE = '" + stCUST + "' ", PublicLoginInfo.Environment, pRESULT)
            If pRESULT = "OK" Then
                GridControl1.DataSource = dsHead.Tables(0)
                GridView1.BestFitColumns()
            Else
                MsgBox("Error: " & pRESULT, MsgBoxStyle.Critical, "Error")
            End If

            strPath = String.Empty
        Catch ex As Exception
            MsgBox("Error al Cargar la Forma : " + ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnEnviar_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEnviar.ItemClick
        Try
            If MessageBox.Show("¿ Confirma la rectificacion de la DUA # " + GridView1.GetFocusedRowCellValue("NUMERO_DUA").ToString + " NUMERO ORDEN # " + GridView1.GetFocusedRowCellValue("NUMERO_DUA").ToString + " ?", "Swift 3PL", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) Then
                xserv.set_rectify(GridView1.GetFocusedRowCellValue("CODIGO_POLIZA").ToString, Val(GridView1.GetFocusedRowCellValue("DOC_ID").ToString), stRELPOL, inDOCID, _
                                  PublicLoginInfo.LoginID, PublicLoginInfo.Environment, pRESULT)
                If pRESULT = "OK" Then
                    MsgBox("Poliza Rectificada con Exito!!!")
                Else
                    MsgBox(pRESULT)
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
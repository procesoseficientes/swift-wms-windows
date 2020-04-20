Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports System.Configuration.ConfigurationManager
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class frmTestLabel

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim pStr As String = ""
        HeaderPartOne(pStr)

        For J = 1 To CInt(txtBultos.Text)

            HeadPartTwo(Me.txtPedido.Text + "-" + J.ToString, _
                        "000193", Me.txtNombre.Text, _
                        Me.txtRuta.Text, Me.txtSector.Text, _
                        0, Me.txtPedido.Text, Me.txtDireccion.Text, _
                        Me.txtDireccion2.Text, Me.txtDireccion3.Text, _
                        Now.ToString, Me.txtUsuario.Text, 1, pStr)

            'RawPrinterHelper_Consol1.SendStringToPrinter(Me.txtPrinter.Text, pStr)

            'Me.Close()
        Next
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub HeaderPartOne(ByRef pStr As String)
        Dim pLine1 As String = "", pLine2 As String = "", pLine3 As String = ""

        pStr = "^XA"
        pStr = pStr + " ^DFR:SAMPLE.GRF"
        pStr = pStr + " ^FS"
        pStr = pStr + " ^q500"

        pStr = pStr + " ^LH20,80^PW14000" 'sets home position
        
        pStr = pStr + Me.txtSpare_Nombre.Text
        pStr = pStr + Me.txtSpare_Direccion.Text
        pStr = pStr + Me.txtSpareDir2.Text
        pStr = pStr + Me.txtSpareDir3.Text

        pStr = pStr + Me.txtSparePedido.Text
        pStr = pStr + Me.txtSpareRuta.Text
        pStr = pStr + Me.txtSpareSector.Text

        pStr = pStr + Me.txtSpareFecha.Text

        pStr = pStr + GetBarcodeFormat("CAJA_CONSOLIDACION")
        pStr = pStr + " ^FO300,920^AAN,30,20^FN13^FS(usuario)"

        pStr = pStr + txtSpareBulto.Text


    End Sub
   
    Sub HeadPartTwo(ByVal pBoxId As String, ByVal pClientId As String, ByVal pClientName As String, ByVal pRoute As String, ByVal pSector As String, ByVal pQtyProdsInBox As String, ByVal pOrderID As String, ByVal pAddress1 As String, ByVal pAddress2 As String, ByVal pAddress3 As String, ByVal pClosingDate As String, ByVal pUserID As String, ByVal pBoxNum As String, ByRef pStr As String)

        pStr = pStr + " ^XZ"
        pStr = pStr + " ^XA"
        pStr = pStr + " ^XFR:SAMPLE.GRF"

        'pStr = pStr + " ^FN3^FD" + pClientId + "^FS"
        pStr = pStr + " ^FN4^FD" + pClientName + "^FS"

        pStr = pStr + " ^FN9^FD" + pAddress1 + "^FS"
        pStr = pStr + " ^FN10^FD" + pAddress2 + "^FS"
        pStr = pStr + " ^FN11^FD" + pAddress3 + "^FS"


        'pStr = pStr + " ^FN8^FD" + pOrderID + "^FS"
        pStr = pStr + " ^FN8^FD" + pOrderID + "^FS"

        pStr = pStr + " ^FN5^FD" + "Ruta: " + pRoute + "^FS"
        pStr = pStr + " ^FN6^FD" + "Sector:" + pSector + "^FS"
        pStr = pStr + " ^FN12^FD" + Now.ToString + "^FS"
        pStr = pStr + " ^FN2^FD" + pBoxId + "^FS" 'codigo barras
        pStr = pStr + " ^FN13^FD" + pUserID + "^FS"
        pStr = pStr + " ^FN14^CFG^FD" + pBoxNum + "^FS"

        pStr = pStr + " ^XZ"

    End Sub
    Public Function GetBarcodeFormat(ByVal pSize As String)
        Dim XStr(0) As String
        Dim I As Integer = 0
        Dim xserv As New OnePlanServices_Settings.WMS_SettingsSoapClient("WMS_SettingsSoap", "http://localhost/WMSOnePlan_BusinessServices/Catalogues/wms_settings.asmx")
        Dim xds As New DataSet
        Dim pResult As String = ""
        Try
            xds = xserv.GetParam_ByParamKey("SISTEMA", "TIPO_ETIQUETAS", pSize, pResult, "DESARROLLO")
            If pResult = "OK" Then
                Return xds.Tables(0).Rows(0)("SPARE1")
            Else
                Return "^FO01,140^BY3^B3N,N,200,N,N^FN4^FS"
            End If
        Catch ex As Exception
            Return "Money Twins"
        End Try
    End Function
End Class

Imports Microsoft.Office.Interop

Public Class frmUpLoadInitFile

    Dim xDT As New DataTable

    Dim xCol_Bodega As New DataColumn("BODEGA", System.Type.GetType("System.String"))
    Dim xCol_Linea As New DataColumn("LINEA", System.Type.GetType("System.String"))
    Dim xCol_Ubicacion As New DataColumn("UBICACION", System.Type.GetType("System.String"))
    Dim xCol_Producto As New DataColumn("PRODUCTO", System.Type.GetType("System.String"))
    Dim xCol_Descripcion As New DataColumn("DESCRIPCION", System.Type.GetType("System.String"))
    Dim xCol_Inventario As New DataColumn("INVENTARIO", System.Type.GetType("System.Double"))

    Dim xRow As DataRow = Nothing

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        OpenExcelFile()
    End Sub
    Sub OpenExcelFile()
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ProcessExcelFile(OpenFileDialog1.FileName)
            lblLastFile.Text = OpenFileDialog1.FileName
        End If
    End Sub
    Sub ProcessExcelFile(ByVal pFile As String)
        Dim xlsApp As Excel.Application = Nothing
        Dim xlsWB As Excel.Workbook = Nothing
        Dim xlsSheet As Excel.Worksheet = Nothing
        Dim xlsCell As Excel.Range



        Dim Obj As Object

        Try
            xlsApp = New Excel.Application
            xlsApp.Visible = False
            xlsWB = xlsApp.Workbooks.Open(pFile)
            xlsSheet = xlsWB.Worksheets(1)

            xlsCell = xlsSheet.UsedRange
            xDT.Rows.Clear()
            For rCnt = 2 To xlsCell.Rows.Count
                Obj = CType(xlsCell.Cells(rCnt, 1), Excel.Range) 'TEST
                If IsDBNull(Obj.value) Then
                    Exit For
                Else
        
                    xRow = xDT.NewRow()

                    Obj = CType(xlsCell.Cells(rCnt, 1), Excel.Range) 'BODEGA
                    xRow("BODEGA") = Obj.value

                    Obj = CType(xlsCell.Cells(rCnt, 2), Excel.Range) 'LINEA
                    xRow("LINEA") = Obj.value

                    Obj = CType(xlsCell.Cells(rCnt, 3), Excel.Range) 'UBICACION
                    xRow("UBICACION") = Obj.value

                    Obj = CType(xlsCell.Cells(rCnt, 4), Excel.Range) 'PRODUCTO
                    xRow("PRODUCTO") = Obj.value

                    Obj = CType(xlsCell.Cells(rCnt, 5), Excel.Range) 'DESCRIPCION
                    xRow("DESCRIPCION") = Obj.value

                    Obj = CType(xlsCell.Cells(rCnt, 6), Excel.Range) 'INVENTARIO
                    xRow("INVENTARIO") = Obj.value

                    xDT.Rows.Add(xRow)


                End If

            Next
            xlsApp.Quit()
            xlsApp = Nothing

            'releaseObject(xlsApp)
            releaseObject(xlsWB)
            releaseObject(xlsSheet)

            GridControl_Process.DataSource = xDT

            

        Catch ex As Exception
            Try
                MessageBox.Show(ex.Message)

                releaseObject(xlsApp)
                releaseObject(xlsWB)
                releaseObject(xlsSheet)

            Catch ex1 As Exception

            End Try

        End Try



    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub frmUpLoadInitFile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PrepareStructure()
        OpenExcelFile()
    End Sub
    Sub PrepareStructure()
        xDT.Columns.Add(xCol_Bodega)
        xDT.Columns.Add(xCol_Linea)
        xDT.Columns.Add(xCol_Ubicacion)
        xDT.Columns.Add(xCol_Producto)
        xDT.Columns.Add(xCol_Descripcion)
        xDT.Columns.Add(xCol_Inventario)

    End Sub
    Private Sub btnProc_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnProc.ItemClick
        Dim pResponse As DialogResult = DialogResult.No
        Dim pResult As String = ""
        Dim tmpLoc As String = ""
        Dim tmpProd As String = ""

        Try
            pResponse = MessageBox.Show("Confirma procesar el archivo? -Esta accion reemplazara la informacion de inventarios, inventarios por ubicacion y la relacion ubicacion-producto. ", "Confirme accion", MessageBoxButtons.YesNo)

            Me.ProgressBarControl1.Position = 0
            If pResponse = DialogResult.Yes Then

                Dim xserv_mat As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_materials.asmx")
                'Dim xserv_mat As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", "http://localhost/WMSOnePlan_BusinessServices/Catalogues/wms_materials.asmx")

                'Dim xserv_init As New OnePlanServices_InitInventory.WMS_InitInventorySoapClient("WMS_InitInventorySoap", PublicLoginInfo.WSHost + "/Trans/wms_initInventory.asmx")

                'Dim xserv_init As New OnePlanServices_InitInventory.WMS_InitInventorySoapClient("WMS_InitInventorySoap", "http://localhost/WMSOnePlan_BusinessServices/Trans/wms_initInventory.asmx")

                For i = 0 To xDT.Rows.Count - 1
                    tmpLoc = xDT.Rows(i)("UBICACION").ToString
                    tmpProd = xDT.Rows(i)("PRODUCTO").ToString

                    'If Not xserv_init.InitBasicInventory_Location(xDT.Rows(i)("BODEGA").ToString, xDT.Rows(i)("UBICACION").ToString, "", xDT.Rows(i)("PRODUCTO").ToString, xDT.Rows(i)("DESCRIPCION").ToString, CDbl(xDT.Rows(i)("INVENTARIO").ToString), PublicLoginInfo.LoginID, xDT.Rows(i)("LINEA").ToString, PublicLoginInfo.Environment, pResult) Then
                    '    MessageBox.Show(pResult)
                    '    Me.lblLastFile.Text = "INIT:" + xDT.Rows(i)("UBICACION").ToString + "/" + xDT.Rows(i)("PRODUCTO").ToString + "/" + pResult
                    '    Exit Sub
                    'End If

                    If xserv_mat.CreateMaterial_Join_SpotLocations(xDT.Rows(i)("PRODUCTO").ToString,xDT.Rows(i)("BODEGA").ToString,xDT.Rows(i)("UBICACION").ToString,PublicLoginInfo.LoginID, 100, CInt(xDT.Rows(i)("INVENTARIO").ToString),pResult, PublicLoginInfo.Environment) Then
                    'If xserv_mat.CreateMaterial_Join_SpotLocations(xDT.Rows(i)("PRODUCTO").ToString, xDT.Rows(i)("DESCRIPCION").ToString, xDT.Rows(i)("LINEA").ToString, PublicLoginInfo.LoginID, xDT.Rows(i)("BODEGA").ToString, xDT.Rows(i)("UBICACION").ToString, PublicLoginInfo.LoginID, 100, CInt(xDT.Rows(i)("INVENTARIO").ToString), pResult, PublicLoginInfo.Environment) Then
                        ''init the location
                        'If Not xserv_init.InitBasicInventory_Location(xDT.Rows(i)("BODEGA").ToString, xDT.Rows(i)("UBICACION").ToString, "", xDT.Rows(i)("PRODUCTO").ToString, xDT.Rows(i)("DESCRIPCION").ToString, CDbl(xDT.Rows(i)("INVENTARIO").ToString), PublicLoginInfo.LoginID, xDT.Rows(i)("LINEA").ToString, PublicLoginInfo.Environment, pResult) Then
                        '    MessageBox.Show(pResult)
                        '    Me.lblLastFile.Text = "INIT:" + xDT.Rows(i)("UBICACION").ToString + "/" + xDT.Rows(i)("PRODUCTO").ToString + "/" + pResult
                        '    Exit Sub
                        'End If
                    Else
                        Me.lblLastFile.Text = "JOIN:" + xDT.Rows(i)("UBICACION").ToString + "/" + xDT.Rows(i)("PRODUCTO").ToString + "/" + pResult
                    End If


                    Me.lblLastFile.Text = "Procesando: " & i
                    Me.lblLastFile.Refresh()
                    Me.ProgressBarControl1.Position = (i * 100) / (xDT.Rows.Count - 1)
                    Me.ProgressBarControl1.Refresh()
                Next
            End If


        Catch ex As Exception
            Me.lblLastFile.Text = tmpLoc + " " + tmpProd + " / " + ex.Message
            Me.ProgressBarControl1.Position = 0
            Me.ProgressBarControl1.Refresh()
        End Try


    End Sub
End Class
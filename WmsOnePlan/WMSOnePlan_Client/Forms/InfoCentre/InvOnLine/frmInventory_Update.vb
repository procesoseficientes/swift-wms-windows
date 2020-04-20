Public Class frmInventory_Update
    Public dataTableInventory As New DataTable("Inventory")
    Private Sub frmInventory_Update_Load(sender As Object, e As EventArgs) Handles Me.Load
        gridChancesInventory.DataSource = dataTableInventory
        GridView1.Columns("PK_LINE").Visible = False
        GridView1.Columns("PK_LINE").OptionsColumn.ShowInCustomizationForm = False
        GridView1.Columns("BATCH_REQUESTED").Visible = False
        GridView1.Columns("BATCH_REQUESTED").OptionsColumn.ShowInCustomizationForm = False
        GridView1.Columns("STATUS_ID").Visible = False
        GridView1.Columns("STATUS_ID").OptionsColumn.ShowInCustomizationForm = False
        GridView1.Columns("TONE_AND_CALIBER_ID").Visible = False
        GridView1.Columns("TONE_AND_CALIBER_ID").OptionsColumn.ShowInCustomizationForm = False
        GridView1.Columns("USER").Visible = False
        GridView1.Columns("USER").OptionsColumn.ShowInCustomizationForm = False
        GridView1.Columns("HANDLE_TONE").Visible = False
        GridView1.Columns("HANDLE_TONE").OptionsColumn.ShowInCustomizationForm = False
        GridView1.Columns("HANDLE_CALIBER").Visible = False
        GridView1.Columns("HANDLE_CALIBER").OptionsColumn.ShowInCustomizationForm = False

        GridView1.Columns("inv.Licencia").Caption = "Inv.Licencia"
        GridView1.Columns("Numero_Lote").Caption = "Numero de Lote"
        GridView1.Columns("Fecha_Expiracion").Caption = "Fecha de Expiracion"

    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        saveChanges()
        ''xmlDataTable()
        Dim frm As New frmInfo_Inventory
        frm.DataTableInvUpdate.Clear()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub saveChanges()

        Dim xserv As New OnePlanServices_InfoInventory.WMS_InfoInventorySoapClient("WMS_InfoInventorySoap", PublicLoginInfo.WSHost + "/Info/wms_infoinventory.asmx")

        Dim xSave As Boolean = False
        Dim xml As String = xmlDataTable()
        Dim pResult As String = ""

        Try

            xSave = xserv.UpdateInventoryOnline(xml, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                dataTableInventory.Clear()
                Me.Close()
            Else
                MsgBox("Vuelva a intentarlo.", MsgBoxStyle.Exclamation, "Proceso de actualizacion: Fallida")
            End If
        Catch ex As Exception
            xserv = Nothing
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Function xmlDataTable() As String
        Try

            Dim ds As New DataSet("DataSet")
            Dim result As String

            ds.Tables.Clear()

            dataTableInventory.TableName = "Inventory"
            ds.Tables.Add(dataTableInventory)

            result = ""
            result = ds.GetXml

            Console.WriteLine(result)
            ds.Tables.Clear()

            Return result

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try
    End Function
End Class
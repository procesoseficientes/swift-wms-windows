
Public Class frmKardexFiscal
    Dim xserv As New OnePlan3PLServices_Polizas._3PL_PolizasSoapClient("_3PL_PolizasSoap", PublicLoginInfo.WSHost + "/3PL/3PL_Polizas.asmx")
    Dim xClientsServ As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/wms_clients.asmx")
    Dim pResult As String
    Private Sub frmKardexFiscal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dsIn As New DataSet
            Dim dsDummy As New DataTable 

            dsDummy = xserv.get_all_poliza_kardex("INGRESO", PublicLoginInfo.Environment, pResult)
            If pResult = "OK" Then
                dsDummy.TableName = "INGRESOS_HEAD"
                dsIn.Tables.Add(dsDummy)
                pResult = String.Empty
                dsDummy = xserv.get_all_poliza_kardex("EGRESO", PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then

                    dsDummy.TableName = "EGRESOS_HEAD"

                    dsIn.Tables.Add(dsDummy.Copy)
                    Dim KC As DataColumn = dsIn.Tables("INGRESOS_HEAD").Columns("DOCUMENTO")
                    Dim FK1 As DataColumn = dsIn.Tables("EGRESOS_HEAD").Columns("DOCUMENTO_ORIGEN")

                    Try
                        dsIn.Relations.Add("EGRESOS", KC, FK1)
                    Catch ex As Exception
                        NotifyStatus("ERROR, EGRESOS_HEAD: " & ex.Message, False, True)
                    End Try


                    pResult = String.Empty
                    dsDummy = xserv.get_all_poliza_kardex("DETALLE_EGRESO", PublicLoginInfo.Environment, pResult)
                    If pResult = "OK" Then
                        Try
                            dsDummy.TableName = "EGRESOS_DETALLE"
                            dsIn.Tables.Add(dsDummy.Copy)
                            Dim KC1 As DataColumn = dsIn.Tables("EGRESOS_HEAD").Columns("LLAVE")
                            Dim FK2 As DataColumn = dsIn.Tables("EGRESOS_DETALLE").Columns("LLAVE")
                            Try
                                dsIn.Relations.Add("EGRESOS_DETALLE", KC1, FK2)
                            Catch ex As Exception
                                NotifyStatus("ERROR, EGRESOS_HEAD: " & ex.Message, True, True)
                            End Try


                        Catch ex As Exception
                            NotifyStatus("ERROR, EGRESOS_DETALLE: " & ex.Message, True, True)
                        End Try
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If

                pResult = String.Empty
                dsDummy = xserv.get_all_poliza_kardex("DETALLE_INGRESO", PublicLoginInfo.Environment, pResult)
                If pResult = "OK" Then

                    Try
                        dsDummy.TableName = "DETALLE_INGRESO"
                        dsIn.Tables.Add(dsDummy.Copy)
                        Dim KC2 As DataColumn = dsIn.Tables("INGRESOS_HEAD").Columns("DOCUMENTO")
                        Dim FK3 As DataColumn = dsIn.Tables("DETALLE_INGRESO").Columns("DOCUMENTO")

                        dsIn.Relations.Add("DETALLE_INGRESO", KC2, FK3)

                    Catch ex As Exception
                        NotifyStatus("ERROR, DETALLE_INGRESO: " & ex.Message, True, True)
                    End Try
                Else
                    NotifyStatus(pResult, True, True)
                End If

                GridControl1.DataSource = dsIn.Tables("INGRESOS_HEAD")
                GridControl1.ForceInitialize()

                GridView1.OptionsPrint.PrintDetails = True
                GridView1.BestFitColumns()

            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub btnExcel_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExcel.ItemClick
        Try
            SaveFileDialog1.DefaultExt = "xlsx"
            SaveFileDialog1.Filter = "Documentos de Excel (*.xlsx)|*.xlsx"
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                GridView1.ExportToXlsx(SaveFileDialog1.FileName)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPrint.ItemClick
        Try

            PrintableComponentLink1.ShowPreview()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
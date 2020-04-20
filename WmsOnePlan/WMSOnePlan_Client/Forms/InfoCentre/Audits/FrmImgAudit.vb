Imports DevExpress.XtraBars.Ribbon
Imports System.Windows.Forms.VisualStyles
Imports System.IO

Public Class FrmImgAudit

    Private _codigoPoliza As String = ""

    Public Sub New(ByVal pCodigoPliza As String)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        _codigoPoliza = pCodigoPliza
        LlenarGaleria()
    End Sub

    Private Sub LlenarGaleria()
        Try
            Dim result As String = ""

            Dim servInfTrans As New OnePlanServices_InfoTrans.WMS_InfoTransSoapClient("WMS_InfoTransSoap", PublicLoginInfo.WSHost + "/Info/wms_InfoTrans.asmx")

            Dim dt As DataSet
            dt = servInfTrans.GetImgAudi(_codigoPoliza, result, PublicLoginInfo.Environment)
            If result = "OK" Then
                glrImg.Gallery.Groups(0).Items.Clear()
                For Each row As DataRow In dt.Tables(0).Rows
                    If CType(row("IMAGEN"), Byte()).Length > 0 Then
                        Dim itemGalery As New GalleryItem()
                        itemGalery.Image = New Bitmap(New MemoryStream(CType(row("IMAGEN"), Byte())))
                        itemGalery.Description = row("COMMENTS").ToString()
                        itemGalery.Value = row("PHOTO_ID")
                        glrImg.Gallery.Groups(0).Items.Add(itemGalery)

                    End If
                Next
            End If



        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
    

    Private Sub glrImg_Gallery_ItemClick(sender As Object, e As GalleryItemClickEventArgs) Handles glrImg.Gallery.ItemClick
        If TransitionManager1.IsTransition Then
            TransitionManager1.EndTransition()
        End If
        TransitionManager1.StartTransition(pctImg)
        Try
            menComentario.Text = e.Item.Description
            pctImg.Image = e.Item.Image
            pctImg.Tag = e.Item.Value
        Catch ex As Exception
            TransitionManager1.EndTransition()
        End Try
    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Not pctImg.Image Is Nothing And Not String.IsNullOrEmpty(menComentario.Text) Then
            GrabarComentario()
        End If
    End Sub

    Private Sub GrabarComentario()
        Try
            Dim result As String = ""

            Dim servInfTrans As New WMS_Polizas.WMS_PolizasSoapClient("WMS_PolizasSoap", PublicLoginInfo.WSHost + "/Trans/WMS_Polizas.asmx")

            If servInfTrans.UpdatePolizaImg(Val(pctImg.Tag.ToString()), menComentario.Text, result, PublicLoginInfo.Environment) Then
                NotifyStatus("Se grabo exitosamente", True, False)
                LlenarGaleria()
            Else
                NotifyStatus(result, True, True)
            End If

        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub
End Class
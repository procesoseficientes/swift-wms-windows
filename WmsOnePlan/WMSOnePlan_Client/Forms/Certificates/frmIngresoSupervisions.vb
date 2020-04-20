Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class frmIngresoSupervisions

    Private Property SuperIdEnc As Integer
    Public Property GraboEnc As Boolean
    Private Property EsNuevoDet As Boolean = True

    Private Sub ClearBag_SupervisionDetail()
        EsNuevoDet = True
        With Bag_Supervisions_Detail
            .Codigo = ""
            .Descripcion = ""
            .Cantidad = 0
            .Costo = 0
            Me.PropertyGrid1.SelectedObject = Bag_Supervisions_Detail
            Me.PropertyGrid1.Refresh()
        End With
    End Sub

#Region "Encabezado"

    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        SuperIdEnc = 0
        tbDetalle.PageEnabled = False
        ClearBag_SupervisionDetail()
    End Sub

    Public Sub New(ByVal pSuperId As Integer)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        GraboEnc = False
        SuperIdEnc = pSuperId
        tbDetalle.PageEnabled = True
        LlenarControles()
        FilListView()
        ClearBag_SupervisionDetail()
    End Sub

    Private Sub LlenarControles()
        Try
            Dim pResult As String = ""
            Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")

            Dim xdata As DataSet = xserv.FillSupervisions(SuperIdEnc, pResult, PublicLoginInfo.Environment)

            If pResult = "OK" Then
                txtDireccion.Text = xdata.Tables(0).Rows(0)("AUDIT_ADDRESS").ToString
                chkInicial.Checked = IIf(Integer.Parse(xdata.Tables(0).Rows(0)("IS_INITIAL").ToString) = 1, True, False)
                memComentario.Text = xdata.Tables(0).Rows(0)("COMMENTS").ToString
                txtCliente.Text = xdata.Tables(0).Rows(0)("CLIENT_OWHEN").ToString
            Else
                MessageBox.Show(pResult)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub CrearSupervisions()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")

            Dim superId As Integer
            Dim grabo As New Boolean
            grabo = xserv.CreateSupervisions(superId, txtCliente.Text, txtDireccion.Text, memComentario.Text, IIf(chkInicial.Checked, 1, 0), PublicLoginInfo.LoginID, pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
                    If pResult = "OK" Then
                        NotifyStatus("Se grabo existosamente", True, False)
                        SuperIdEnc = superId
                        GraboEnc = True
                        tbDetalle.PageEnabled = True
                        tbSupervisions.SelectedTabPage = tbDetalle
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Sub UpdateSupervisions()
        Dim pResult As String = ""
        Try
            Dim xserv As New OnePlanServices_Supervisions.WMS_SupervisionsSoapClient("WMS_SupervisionsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Supervisions.asmx")

            Dim grabo As New Boolean
            grabo = xserv.Updatesupervision(SuperIdEnc, txtCliente.Text, txtDireccion.Text, memComentario.Text, IIf(chkInicial.Checked, 1, 0), pResult, PublicLoginInfo.Environment)
            If grabo Then
                If grabo Then
                    If pResult = "OK" Then
                        NotifyStatus("Se grabo existosamente", True, False)
                        GraboEnc = True
                        tbSupervisions.SelectedTabPage = tbDetalle
                    Else
                        NotifyStatus(pResult, True, True)
                    End If
                Else
                    NotifyStatus(pResult, True, True)
                End If
            Else
                NotifyStatus(pResult, True, True)
            End If
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

    Private Function ValidarDatosGenerales() As Boolean
        Try
            If String.IsNullOrEmpty(txtCliente.Text) Then
                NotifyStatus("Ingrese el cliente", True, True)
                txtCliente.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(txtDireccion.Text) Then
                NotifyStatus("Ingrese la dirección", True, True)
                txtDireccion.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(memComentario.Text) Then
                NotifyStatus("Ingrese el comentario", True, True)
                memComentario.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
            Return False
        End Try
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ValidarDatosGenerales() Then
            If SuperIdEnc = 0 Then
                CrearSupervisions()
            Else
                UpdateSupervisions()
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If SuperIdEnc = 0 Then
            txtDireccion.Text = ""
            chkInicial.Checked = False
            memComentario.Text = ""
        Else
            LlenarControles()
        End If
        GraboEnc = False
    End Sub

#End Region

#Region "Detalle"

    Public Function LlenarGridDet()
        Dim i As Integer = 0
        Dim pResult As String = ""
        Dim xdataset As New DataSet
        Dim xgrp As New ListViewGroup

        Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

        Try
            xdataset = xserv.GetSupervisionsDetail(SuperIdEnc, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                GridDet.DataSource = xdataset.Tables(0)
            End If
        Catch ex As Exception
            xdataset = Nothing
            xserv = Nothing

            MessageBox.Show(ex.Message)
        End Try
        xdataset = Nothing
        xserv = Nothing
        Return True
    End Function

    Public Function FilListView()
        Me.Cursor = Cursors.WaitCursor
        LlenarGridDet()
        Me.Cursor = Cursors.Default
        Return True
    End Function

    Sub ShowRegistro(ByVal pid As String)
        ClearBag_SupervisionDetail()
        EsNuevoDet = False
        Dim pResult As String = ""
        Dim xserv As New OnePlanServices_SupervisionsDetail.WMS_SupervisionsDetailSoapClient("WMS_SupervisionsDetailSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_SupervisionsDetail.asmx")

        Dim xdata As DataSet = xserv.FillSupervisionsDetail(SuperIdEnc, pid, pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            With Bag_Supervisions_Detail
                .Codigo = xdata.Tables(0).Rows(0)("CODE").ToString
                .Descripcion = xdata.Tables(0).Rows(0)("DESCRIPTION").ToString
                .Cantidad = xdata.Tables(0).Rows(0)("QTY").ToString
                .Costo = xdata.Tables(0).Rows(0)("COST").ToString
            End With
            PropertyGrid1.SelectedObject = Bag_Supervisions_Detail
        Else
            MessageBox.Show(pResult)
        End If
    End Sub

    Private Function ValidarDet() As Boolean
        Try
            Dim esDecimal As Decimal
            If String.IsNullOrEmpty(Bag_Supervisions_Detail.Cantidad) Then
                NotifyStatus("Ingrese la cantidad", True, True)
                Return False
            End If

            If Not Decimal.TryParse(Bag_Supervisions_Detail.Cantidad, esDecimal) Then
                NotifyStatus("La cantidad ingresada tiene que ser numerico", True, True)
                Return False
            End If

            If Decimal.Parse(Bag_Supervisions_Detail.Cantidad) <= 0 Then
                NotifyStatus("La cantidad ingresado debe ser mayor a cero", True, True)
                Return False
            End If

            If String.IsNullOrEmpty(Bag_Supervisions_Detail.Codigo) Then
                NotifyStatus("Ingrese el Codigo", True, True)
                Return False
            End If

            If String.IsNullOrEmpty(Bag_Supervisions_Detail.Costo) Then
                NotifyStatus("Ingrese el costo", True, True)
                Return False
            End If

            If Not Decimal.TryParse(Bag_Supervisions_Detail.Costo, esDecimal) Then
                NotifyStatus("El costo ingresado debe numerico", True, True)
                Return False
            End If

            If Decimal.Parse(Bag_Supervisions_Detail.Costo) <= 0 Then
                NotifyStatus("El costo ingresado debe ser mayor a cero", True, True)
                Return False
            End If

            If String.IsNullOrEmpty(Bag_Supervisions_Detail.Descripcion) Then
                NotifyStatus("Ingrese el descripcion", True, True)
                Return False
            End If

            Return True
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
            Return False
        End Try
    End Function

    Public Sub SaveAndRefresh()
        If ValidarDet() Then
            Dim pResult As String = ""
            If EsNuevoDet Then
                If Bag_Supervisions_Detail.Create(SuperIdEnc, pResult) Then
                    FilListView()
                    ClearBag_SupervisionDetail()
                Else
                    MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If Bag_Supervisions_Detail.Update(SuperIdEnc, pResult) Then
                    FilListView()
                    ClearBag_SupervisionDetail()
                Else
                    MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub DeleteAndRefresh()
        Dim pResult As String = ""
        If Bag_Supervisions_Detail.Delete(SuperIdEnc, pResult) Then
            FilListView()
            ClearBag_SupervisionDetail()
        Else
            MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        ClearBag_SupervisionDetail()
    End Sub

    Private Sub SaveToolStripButton_Click(sender As Object, e As EventArgs) Handles SaveToolStripButton.Click
        SaveAndRefresh()
    End Sub

    Private Sub CutToolStripButton_Click(sender As Object, e As EventArgs) Handles CutToolStripButton.Click
        If Not EsNuevoDet Then
            If Not String.IsNullOrEmpty(Bag_Supervisions_Detail.Codigo) Then
                If MessageBox.Show("Desea borrar el registro?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    DeleteAndRefresh()
                End If
            End If
        Else
            NotifyStatus("Seleccione un registro del grid", True, True)
        End If
        
    End Sub

    Private Sub GridDet_Click(sender As Object, e As EventArgs) Handles GridDet.Click
        Try
            Dim xdatarow As DataRow = GridViewDet.GetDataRow(GridViewDet.FocusedRowHandle)
            Dim code As String = xdatarow("CODE").ToString
            ShowRegistro(code)
        Catch ex As Exception
            NotifyStatus(ex.Message, True, True)
        End Try
    End Sub

#End Region
    
End Class
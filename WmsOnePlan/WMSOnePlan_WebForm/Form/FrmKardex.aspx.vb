Imports DevExpress.Web

Public Class FrmKardex
    Inherits System.Web.UI.Page

    Public Class KardexOperacion
        Private _kardexId As Integer
        Private _certificadoId As Integer
        Private _sku As String
        Private _skuDescription As String
        Private _currentBalace As Decimal
        Private _receipts As Decimal
        Private _dispactil As Decimal
        Private _newCurrentBalace As Decimal
        Private _cost As Decimal
        Private _costTotal As Decimal

        Public Property KardexId As Integer
            Get
                Return _kardexId
            End Get
            Set(value As Integer)
                _kardexId = value
            End Set
        End Property
        Public Property CertificadoId As Integer
            Get
                Return _certificadoId
            End Get
            Set(value As Integer)
                _certificadoId = value
            End Set
        End Property
        Public Property Sku As String
            Get
                Return _sku
            End Get
            Set(value As String)
                _sku = value
            End Set
        End Property
        Public Property SkuDescription As String
            Get
                Return _skuDescription
            End Get
            Set(value As String)
                _skuDescription = value
            End Set
        End Property
        Public Property CurrentBalace As Decimal
            Get
                Return _currentBalace
            End Get
            Set(value As Decimal)
                _currentBalace = value
            End Set
        End Property
        Public Property Receipts As Decimal
            Get
                Return _receipts
            End Get
            Set(value As Decimal)
                _receipts = value
            End Set
        End Property
        Public Property Dispactil As Decimal
            Get
                Return _dispactil
            End Get
            Set(value As Decimal)
                _dispactil = value
            End Set
        End Property
        Public Property NewCurrentBalace As Decimal
            Get

                Return (CurrentBalace + Receipts) - Dispactil
            End Get
            Set(value As Decimal)
                _newCurrentBalace = value
            End Set
        End Property

        Public Property Cost As Decimal
            Get

                Return _cost
            End Get
            Set(value As Decimal)
                _cost = value
            End Set
        End Property

        Public Property CostTotal As Decimal
            Get

                Return Cost * NewCurrentBalace
            End Get
            Set(value As Decimal)
                _costTotal = value
            End Set
        End Property



        Public Sub New()
            KardexId = 0
            CertificadoId = 0
            Sku = ""
            SkuDescription = ""
            CurrentBalace = 0
            Receipts = 0
            Dispactil = 0
            Cost = 0
            CostTotal = 0
        End Sub
    End Class

    Property CertificateId() As String
        Get
            Return Session("CertificateId")
        End Get
        Set(ByVal value As String)
            Session("CertificateId") = value
        End Set
    End Property

    Property LstKardexCertificate() As DataTable
        Get
            Return Session("LstKardexCertificate")
        End Get
        Set(ByVal value As DataTable)
            Session("LstKardexCertificate") = value
        End Set
    End Property

    Property LstKardexTxns() As DataTable
        Get
            Return Session("LstKardexTxns")
        End Get
        Set(ByVal value As DataTable)
            Session("LstKardexTxns") = value
        End Set
    End Property

    Property LstKardexOperacion() As List(Of KardexOperacion)
        Get
            Return CType(Session("LstKardexOperacion"), List(Of KardexOperacion))
        End Get
        Set(ByVal value As List(Of KardexOperacion))
            Session("LstKardexOperacion") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("users") Is Nothing Then
            Response.Redirect("LogOff.aspx")

        ElseIf String.IsNullOrEmpty(Session("users")) Then
            Response.Redirect("LogOff.aspx")
        End If

        If Not IsPostBack Then
            LstKardexOperacion = New List(Of KardexOperacion)
            dtFecha.Value = Date.Today
            dtFechaInicio.Value = Date.Today.AddMonths(-2)
            dtFechaFinal.Value = Date.Today.AddMonths(1)
            LlenarGridKardex()
            LlenarGridOperacionKardex()
            LlenarGridKardexTxns()
        Else
            GridKardexCertificate.DataSource = LstKardexCertificate
            GridKardexCertificate.DataBind()

            GridKardexCons.DataSource = LstKardexOperacion
            GridKardexCons.DataBind()

            GridKardexTxns.DataSource = LstKardexTxns
            GridKardexTxns.DataBind()
        End If
    End Sub
    
    Private Sub LlenarGridKardex()
        Try
            Dim result As String = ""
            Dim svCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient
            Dim dt As New DataTable
            dt = svCertificate.GetKardexCertificate(Session("users").ToString(), "GetKardexCertificate", result, Session("environmentName").ToString())
            If (Not result.Equals("OK")) Then
                lblError.Text = result
            Else
                CertificateId = dt.Rows(0)("CERTIFICATE_ID")
                result = ""
                If svCertificate.InsertKardex(CertificateId, result, Session("environmentName").ToString()) Then
                    If (Not result.Equals("OK")) Then
                        lblError.Text = result
                    End If
                End If
                LstKardexCertificate = dt
                GridKardexCertificate.DataSource = LstKardexCertificate
                GridKardexCertificate.DataBind()
            End If

        Catch ex As Exception
            lblError.Text = "LlenarGridKardex, Ha ocurrido el siguiente error: " + ex.Message
        End Try
    End Sub

    Private Sub LlenarGridOperacionKardex()
        Try
            Dim result As String = ""
            Dim svCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient
            Dim dt As New DataTable
            dt = svCertificate.GetKardexConsultation(CertificateId, "LlenarGridConsultaKardex", result, Session("environmentName").ToString())

            If (Not result.Equals("OK")) Then
                lblError.Text = result
            Else
                LstKardexOperacion = New List(Of KardexOperacion)()
                For Each row As DataRow In dt.Rows
                    Dim kardexOperacion As New KardexOperacion
                    kardexOperacion.KardexId = Integer.Parse(row("KARDEX_ID").ToString())
                    kardexOperacion.CertificadoId = Integer.Parse(row("CERTIFATE_ID").ToString())
                    kardexOperacion.Sku = row("SKU").ToString()
                    kardexOperacion.SkuDescription = row("SKU_DESCRIPTION").ToString()
                    kardexOperacion.CurrentBalace = Decimal.Parse(row("CURRENT_BALACE").ToString())
                    kardexOperacion.Cost = Decimal.Parse(row("COST").ToString())
                    LstKardexOperacion.Add(kardexOperacion)
                Next

                GridKardexCons.DataSource = LstKardexOperacion
                GridKardexCons.DataBind()
            End If

        Catch ex As Exception
            lblError.Text = "LlenarGridKardex, Ha ocurrido el siguiente error: " + ex.Message
        End Try
    End Sub

    Protected Sub GridKardexCons_BatchUpdate(sender As Object, e As DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs) Handles GridKardexCons.BatchUpdate
        For Each o In e.UpdateValues
            ActualizarLstKardexConsul(Integer.Parse(o.Keys("KardexId")), Decimal.Parse(o.NewValues("Receipts").ToString()), Decimal.Parse(o.NewValues("Dispactil").ToString()))
        Next
        e.Handled = True
    End Sub

    Private Sub ActualizarLstKardexConsul(ByVal pKardexId As Integer, ByVal pReceipts As Decimal, ByVal pDispactil As Decimal)
        Try
            For Each o In From o1 In LstKardexOperacion Where o1.KardexId = pKardexId
                o.Receipts = pReceipts
                o.Dispactil = pDispactil
                Exit For
            Next
        Catch ex As Exception
            lblErrorKardexCon.Text = "ActualizarLstKardexConsul, Ha ocurrido el siguiente error: " + ex.Message
        End Try
    End Sub

    Protected Sub menOpciones_ItemClick(source As Object, e As DevExpress.Web.MenuItemEventArgs) Handles menOpciones.ItemClick
        lblErrorKardexCon.Text = ""
        lblInformation.Text = ""
        If e.Item.Name.Equals("btnSave") Then
            If ValidarOperacionKardex() Then
                Grabar()
            End If
        ElseIf e.Item.Name.Equals("btnExExel") Then
            gridExportKardexOperation.WriteXlsToResponse()
        ElseIf e.Item.Name.Equals("btnExPdf") Then

            gridExportKardexOperation.WritePdfToResponse()
        End If
    End Sub

    Function ValidarOperacionKardex() As Boolean
        Dim modificaron As Boolean = LstKardexOperacion.Any(Function(item) Not item.Receipts = 0 Or Not item.Dispactil = 0)
        If Not modificaron Then
            lblErrorKardexCon.Text = "No se han hecho operaciones"
            GridKardexCons.Focus()
            Return False
        End If

        If dtFecha.Value Is Nothing Then
            lblErrorKardexCon.Text = "Ingrese la fehca"
            dtFecha.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub Grabar()
        Try
            Dim result As String = ""
            Dim svCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient
            For Each item In From item1 In LstKardexOperacion Where Not item1.Receipts = 0 Or Not item1.Dispactil = 0
                If svCertificate.InsertKardexTxns(item.CertificadoId, Date.Parse(dtFecha.Value.ToString()), item.Receipts, item.Dispactil, item.CurrentBalace,
                                                  item.NewCurrentBalace, item.Sku, item.SkuDescription, item.Cost, result, Session("environmentName").ToString()) Then
                    If result.Equals("OK") Then
                        result = ""
                        If svCertificate.UpdatedKardex(item.KardexId, item.NewCurrentBalace, result, Session("environmentName").ToString()) Then
                            If result.Equals("OK") Then
                                lblInformation.Text = "Se grabo existosamente."
                                LlenarGridKardexTxns()
                                LlenarGridOperacionKardex()
                            Else
                                lblError.Text = result
                                Exit For
                            End If
                        End If
                    Else
                        lblError.Text = result
                        Exit For
                    End If
                Else
                    lblError.Text = result
                    Exit For
                End If
            Next
        Catch ex As Exception
            lblErrorKardexCon.Text = "Grabar, Ha ocurrido el siguiente error: " + ex.Message
        End Try
    End Sub

    Private Sub LlenarGridKardexTxns()
        Try
            Dim result As String = ""
            Dim svCertificate As New OnePlanServices_Certificates.WMS_CertificatesSoapClient
            Dim dt As New DataTable
            dt = svCertificate.GetKardexTxns(CertificateId, Date.Parse(dtFechaInicio.Value.ToString()),
                                             Date.Parse(dtFechaFinal.Value.ToString()), "LlenarGridKardexTxns", result, Session("environmentName").ToString())
            If (Not result.Equals("OK")) Then
                lblError.Text = result
            End If
            LstKardexTxns = dt
            GridKardexTxns.DataSource = LstKardexTxns
            GridKardexTxns.DataBind()
            GridKardexTxns.GroupBy(GridKardexTxns.Columns("TX_DATE"))
            GridKardexTxns.GroupBy(GridKardexTxns.Columns("SKU"))
            GridKardexTxns.ExpandAll()
        Catch ex As Exception
            lblError.Text = "LlenarGridKardexTxns, Ha ocurrido el siguiente error: " + ex.Message
        End Try
    End Sub
    
    Protected Sub btnBuscarKardexTxns_Click(sender As Object, e As EventArgs) Handles btnBuscarKardexTxns.Click
        If dtFechaInicio.Value Is Nothing Then
            lblErrorKardexTxns.Text = "Ingrese la fecha de inicio" '    dtFechaInicio.Focus()
            Exit Sub
        End If
        If dtFechaFinal.Value Is Nothing Then
            lblErrorKardexTxns.Text = "Ingrese la fecha de final"
            dtFechaFinal.Focus()
            Exit Sub
        End If
        If Date.Parse(dtFechaInicio.Value.ToString()) > Date.Parse(dtFechaFinal.Value.ToString()) Then
            lblErrorKardexTxns.Text = "La fecha de inicio no puede ser moyor a la fecha final"
            dtFechaInicio.Focus()
            Exit Sub
        End If
        LlenarGridKardexTxns()
    End Sub

    Protected Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Response.Redirect("LogOff.aspx")
    End Sub

    Protected Sub GridKardexCons_RowValidating(sender As Object, e As Data.ASPxDataValidationEventArgs) Handles GridKardexCons.RowValidating
        If Decimal.Parse(e.NewValues("Receipts").ToString()) < 0 Then
            AddError(e.Errors, GridKardexCons.Columns("Receipts"), "El ingreso no puede ser negativo")
        ElseIf Decimal.Parse(e.NewValues("Dispactil").ToString()) < 0 Then
            AddError(e.Errors, GridKardexCons.Columns("Dispactil"), "El egreso no puede ser negativo")
        Else
            lblErrorKardexCon.Text = ""
            Dim invehntarioTotal As Decimal = Decimal.Parse(e.Keys("CurrentBalace").ToString()) + Decimal.Parse(e.NewValues("Receipts").ToString())

            If (invehntarioTotal < Decimal.Parse(e.NewValues("Dispactil").ToString())) Then
                AddError(e.Errors, GridKardexCons.Columns("Dispactil"), "El egreso sobrepasa  la cantidad en inventario.")
            End If
        End If
    End Sub

    Private Sub AddError(ByVal errors As Dictionary(Of GridViewColumn, String), ByVal column As GridViewColumn, ByVal errorText As String)
        If errors.ContainsKey(column) Then
            Return
        End If
        errors(column) = errorText
    End Sub

    Protected Sub menInvCertificado_ItemClick(source As Object, e As MenuItemEventArgs) Handles menInvCertificado.ItemClick
        If e.Item.Name.Equals("btnExExel") Then
            gridExportInvCertificate.WriteXlsToResponse()
        ElseIf e.Item.Name.Equals("btnExPdf") Then

            gridExportInvCertificate.WritePdfToResponse()
        End If
    End Sub

    Protected Sub menKardexTxns_ItemClick(source As Object, e As MenuItemEventArgs) Handles menKardexTxns.ItemClick
        If e.Item.Name.Equals("btnExExel") Then
            gridExportKardexTxns.WriteXlsToResponse()
        ElseIf e.Item.Name.Equals("btnExPdf") Then
            gridExportKardexTxns.WritePdfToResponse()
        End If
    End Sub

End Class
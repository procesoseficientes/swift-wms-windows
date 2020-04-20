Public Class frmCreatePickingD

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub GroupControl1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupControl1.Paint

    End Sub

    Private Sub frmCreatePickingD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pResult As String = ""
        Dim xserver As New OnePlanServices_Locations.WMS_LocationsSoapClient("WMS_LocationsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Locations.asmx")

        Dim xdata As DataSet = xserver.GetPickingLines("PICKING", pResult, PublicLoginInfo.Environment)
        If pResult = "OK" Then
            With cmbLine.Properties
                .DataSource = xdata.Tables(0)
                .ValueMember = "PICKING_LINE"
                .DisplayMember = "PICKING_LINE"
            End With

        End If
    End Sub

    Private Sub txtMaterialID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaterialID.Leave
        Dim pResult As String = ""
        Dim pMaterialName As String = ""
        If Not ValidateInfo("PROD", pResult, pMaterialName) Then
            txtMaterialID.ErrorText = pResult
            txtMaterialID.Text = ""
            lblMaterialName.Text = ""
            txtMaterialID.Focus()
        Else
            cmbLine.ErrorText = ""
            lblMaterialName.Text = pMaterialName
        End If
    End Sub

    Function ValidateInfo(ByVal pType As String, ByRef pResult As String, ByRef pReturnedValue As String) As Boolean

        Try
            Cursor = Cursors.WaitCursor
            Select Case pType
                Case "PROD"
                    Dim xserv As New OnePlanServices_Materials.WMS_MaterialsSoapClient("WMS_MaterialsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Materials.asmx")
                    Dim pMaterial As String = txtMaterialID.Text
                    Dim xdata As DataSet = xserv.SearchByKeyMaterials(pMaterial, pResult, PublicLoginInfo.Environment)
                    If Not pResult = "OK" Then
                        pResult = "Producto No Existe"
                        pReturnedValue = ""

                        Cursor = Cursors.Default
                        Return False
                    Else
                        pResult = "OK"
                        pReturnedValue = xdata.Tables(0).Rows(0)("MATERIAL_NAME").ToString.ToUpper
                        Cursor = Cursors.Default
                        Return True
                    End If
                Case "CUST"
                    Dim xserv As New OnePlanServices_Clients.WMS_ClientsSoapClient("WMS_ClientsSoap", PublicLoginInfo.WSHost + "/Catalogues/WMS_Clients.asmx")
                    Dim pClient As String = txtSAPClient.Text
                    Dim xdata As DataSet = xserv.SearchByKeyClients(pClient, pResult, PublicLoginInfo.Environment)
                    If Not pResult = "OK" Then
                        pResult = "Cliente No Existe"
                        pReturnedValue = ""
                        Cursor = Cursors.Default
                        Return False
                    Else
                        pResult = "OK"
                        pReturnedValue = xdata.Tables(0).Rows(0)("CLIENT_NAME").ToString.ToUpper + "/" + xdata.Tables(0).Rows(0)("CLIENT_ROUTE").ToString.ToUpper
                        Cursor = Cursors.Default
                        Return True
                    End If

            End Select
        Catch ex As Exception
            Cursor = Cursors.Default
            pResult = "ERROR: " + ex.Message
            Return False
        End Try
        Cursor = Cursors.Default
        Return True
    End Function

    Private Sub txtSAPClient_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSAPClient.Leave
        Dim pResult As String = ""
        Dim pClientName As String = ""
        If Not ValidateInfo("CUST", pResult, pClientName) Then
            txtSAPClient.ErrorText = pResult
            txtSAPClient.Text = ""
            lblClientName.Text = ""
            txtSAPClient.Focus()
        Else
            cmbLine.ErrorText = ""
            lblClientName.Text = pClientName
        End If

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim pResult As String = "", pReturnedValue As String = ""
        Dim pLastReturned As Integer = 0

        If txtMaterialID.Text = "" Then
            txtMaterialID.ErrorText = "Ingrese Producto"
            Exit Sub
        End If

        If txtQty.Value <= 0 Then
            txtQty.ErrorText = "Ingrese una cantidad valida"
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If ValidateInfo("CUST", pResult, pReturnedValue) Then
            If ValidateInfo("PROD", pResult, pReturnedValue) Then
                If CreatePickingTask(pResult) Then
                    Cursor = Cursors.Default
                    Me.txtMaterialID.Text = ""
                    Me.lblMaterialName.Text = "..."
                    Me.txtQty.Text = "0"
                    Me.txtMaterialID.Focus()
                Else
                    Cursor = Cursors.Default
                    MessageBox.Show(pResult, "Swift 3PL", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                Cursor = Cursors.Default
                Me.txtMaterialID.ErrorText = pResult
                Me.txtMaterialID.Text = ""
                Me.txtMaterialID.Focus()
            End If
        Else
            Cursor = Cursors.Default
            Me.txtSAPClient.ErrorText = pResult
            Me.lblClientName.Text = "..."
            Me.txtSAPClient.Text = ""
            Me.txtSAPClient.Focus()
        End If
        Cursor = Cursors.Default
    End Sub
    Function CreatePickingTask(ByRef pResult As String) As Boolean
        Try
            Dim xserver As New OnePlanServices_TasksAdmin.WMS_TasksAdminSoapClient("WMS_TasksAdminSoap", PublicLoginInfo.WSHost + "/trans/WMS_TasksAdmin.asmx")

            Call xserver.CreatePickingManual(Me.cmbWarehouse.Text, cmbLine.Text, Me.txtSAPDoc.Text, Me.txtSAPClient.Text, PublicLoginInfo.LoginID, "TAREA CREADA MANUALMENTE", Me.txtQty.Value, Me.txtMaterialID.Text, pResult, PublicLoginInfo.Environment)
            If pResult = "OK" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            pResult = ex.Message
            Return False
        End Try
    End Function

End Class
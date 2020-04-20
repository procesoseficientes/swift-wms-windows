Imports System.Data.SqlClient


Public Class frmGenerarServicios
    Public miscDS As DataSet
    Public Class_miscDS As DataSet

    Sub ReadTableColumns()
        Dim sqldb_conexion As SqlConnection = New SqlConnection("Server=(local);Database=SONDA;User=sa;Pwd=Server1237710")
        Dim miscDA As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM " + cmbTableName.Text, sqldb_conexion)

        miscDS = New DataSet()
        Class_miscDS = New DataSet()

        miscDA.Fill(miscDS)
        miscDA.Fill(Class_miscDS)
    End Sub

    Public Sub SQLParseTable()

        Dim xWhereLine As String = ""
        Dim ParamsLine As String = ""
        Dim FunctionLine As String = ""
        Dim WebMethodLine As String = "<WebMethod(Description:=""" + Me.txtServiceDesription.Text + """)> _"
        Dim xcol As New DataColumn


        Select Case cmbServiceType.Text
            Case "Create", "Update"
                For Each xcol In miscDS.Tables(0).Columns
                    ParamsLine = ParamsLine + "byval p" + xcol.ColumnName + " as " + EvalColType(xcol.DataType.ToString) + ", "
                Next xcol
                ParamsLine = ParamsLine + " ByRef pResult As String) as Boolean"
            Case Else
                xWhereLine = xWhereLine + " XSQL = XSQL + """ + " WHERE """ + Chr(13)

                For I = 1 To CheckedListBox1.Items.Count

                    If CheckedListBox1.GetItemChecked(I - 1) Then
                        Dim xcolType As String

                        xcolType = miscDS.Tables(0).Columns(CheckedListBox1.Items(I - 1).ToString).DataType.ToString
                        ParamsLine = ParamsLine + "byval p" + CheckedListBox1.Items(I - 1).ToString + " as " + EvalColType(xcolType) + ", "



                        xcolType = miscDS.Tables(0).Columns(CheckedListBox1.Items(I - 1).ToString).DataType.ToString
                        Select Case xcolType
                            Case "System.String"
                                xWhereLine = xWhereLine + " XSQL = XSQL + """ + CheckedListBox1.Items(I - 1).ToString + " = '""+" + "p" + CheckedListBox1.Items(I - 1).ToString + "+" + """' AND """ + Chr(13)
                            Case Else
                                xWhereLine = xWhereLine + " XSQL = XSQL + """ + CheckedListBox1.Items(I - 1).ToString + " = ""+" + "p" + CheckedListBox1.Items(I - 1).ToString + ".tostring +" + """ AND """ + Chr(13)
                        End Select
                        xWhereLine = Mid(xWhereLine, 1, Len(xWhereLine) - 7) + """" + Chr(13)
                    End If
                Next
                ParamsLine = ParamsLine + " ByRef pResult As String) as " + IIf(cmbServiceType.Text = "Delete", "Boolean", "Dataset")

        End Select

        FunctionLine = "Public Function " + cmbServiceType.Text + txtServiceName.Text

        Dim HeaderLine As String = ""
        Dim BodyLine As String = ""
        Dim MiddleLine As String = ""
        Dim EndOfLine As String = "End Function" + Chr(13)
        Dim FirstCol As String = ""

        HeaderLine = WebMethodLine + Chr(13)
        HeaderLine = HeaderLine + FunctionLine + "(" + ParamsLine + Chr(13)
        BodyLine = "Dim XSQL As String = """"" + Chr(13)

        Select Case cmbServiceType.Text
            Case "Create"
                BodyLine = BodyLine + "Try" + Chr(13)
                BodyLine = BodyLine + "XSQL = ""INSERT INTO " + cmbTableName.Text + "(""" + Chr(13)
                For Each xcol In miscDS.Tables(0).Columns
                    BodyLine = BodyLine + "XSQL = XSQL +""" + xcol.ColumnName + "," + """" + Chr(13)
                Next xcol
                BodyLine = Mid(BodyLine, 1, Len(BodyLine) - 3)
                BodyLine = BodyLine + ")" + """" + Chr(13)
                BodyLine = BodyLine + "XSQL = XSQL +""" + "VALUES (" + """" + Chr(13)
                For Each xcol In miscDS.Tables(0).Columns
                    Select Case xcol.DataType.ToString
                        Case "System.String"
                            BodyLine = BodyLine + "XSQL = XSQL +""'""+" + "p" + xcol.ColumnName + "+" + """',""" + Chr(13)
                        Case "System.Decimal"
                            BodyLine = BodyLine + "XSQL = XSQL + " + "+p" + xcol.ColumnName + ".tostring +" + """,""" + Chr(13)
                        Case "System.DateTime"
                            MiddleLine = "IIf(IsValidDate(" + xcol.ColumnName + ")," + """'""" + "+p" + xcol.ColumnName + ".tostring +" + """'""," + """" + "NULL" + """" + ")"
                            BodyLine = BodyLine + "XSQL = XSQL + " + MiddleLine + Chr(13)
                        Case Else
                            BodyLine = BodyLine + "XSQL = XSQL + " + "+p" + xcol.ColumnName + ".tostring +" + """,""" + Chr(13)
                    End Select
                Next xcol
                BodyLine = Mid(BodyLine, 1, Len(BodyLine) - 3) + ")" + """" + Chr(13)

            Case "Update"
                BodyLine = BodyLine + "Try" + Chr(13)
                BodyLine = BodyLine + "XSQL = ""UPDATE " + cmbTableName.Text + " SET """ + Chr(13)
                For Each xcol In miscDS.Tables(0).Columns
                    Select Case xcol.DataType.ToString
                        Case "System.String"
                            BodyLine = BodyLine + "XSQL = XSQL + """ + xcol.ColumnName + " = '""+" + "p" + xcol.ColumnName + "+" + """',""" + Chr(13)
                        Case "System.DateTime"
                            MiddleLine = "IIf(IsValidDate(" + xcol.ColumnName + ")," + """'""" + "+p" + xcol.ColumnName + ".tostring +" + """'""," + """" + "NULL" + """" + ")"
                            BodyLine = BodyLine + "XSQL = XSQL + """ + xcol.ColumnName + " = " + MiddleLine + Chr(13)
                        Case Else
                            BodyLine = BodyLine + "XSQL = XSQL + """ + xcol.ColumnName + " = " + """+p" + xcol.ColumnName + ".tostring +" + """,""" + Chr(13)
                    End Select
                Next xcol
                BodyLine = Mid(BodyLine, 1, Len(BodyLine) - 1) + Chr(13)
                BodyLine = BodyLine + " XSQL = XSQL + """ + " WHERE """ + Chr(13)
                Dim I As Integer
                For I = 1 To CheckedListBox1.Items.Count
                    If CheckedListBox1.GetItemChecked(I - 1) Then

                        Dim xcolType As String
                        xcolType = miscDS.Tables(0).Columns(CheckedListBox1.Items(I - 1).ToString).DataType.ToString
                        Select Case xcolType
                            Case "System.String"
                                BodyLine = BodyLine + " XSQL = XSQL + """ + CheckedListBox1.Items(I - 1).ToString + " = '""+" + "p" + CheckedListBox1.Items(I - 1).ToString + "+" + """' AND """ + Chr(13)
                            Case Else
                                BodyLine = BodyLine + " XSQL = XSQL + """ + CheckedListBox1.Items(I - 1).ToString + " = ""+" + "p" + CheckedListBox1.Items(I - 1).ToString + ".tostring +" + """ AND """ + Chr(13)
                        End Select
                    End If
                Next

                BodyLine = Mid(BodyLine, 1, Len(BodyLine) - 7) + """" + Chr(13)


            Case "Delete"
                BodyLine = BodyLine + "XSQL = ""DELETE " + cmbTableName.Text + """" + Chr(13)
                BodyLine = BodyLine + xWhereLine + Chr(13)
            Case Else

                BodyLine = BodyLine + "XSQL = """ + "SELECT * FROM " + cmbTableName.Text + """" + Chr(13)
                BodyLine = BodyLine + "XSQL = XSQL + """ + " WHERE " + """" + Chr(13)
                Dim xcolType As String = ""
                For I = 1 To CheckedListBox1.Items.Count
                    If CheckedListBox1.GetItemChecked(I - 1) Then
                        xcolType = miscDS.Tables(0).Columns(CheckedListBox1.Items(I - 1).ToString).DataType.ToString
                        Select Case xcolType
                            Case "System.String"
                                BodyLine = BodyLine + " XSQL = XSQL + ""UPPER(" + CheckedListBox1.Items(I - 1).ToString + ") = '""+" + "p" + CheckedListBox1.Items(I - 1).ToString + ".ToUpper+" + """' " + IIf(cmbServiceType.Text = "SearchPartial", "OR", "AND") + """" + Chr(13)
                            Case Else
                                BodyLine = BodyLine + " XSQL = XSQL + """ + CheckedListBox1.Items(I - 1).ToString + " = ""+" + "p" + CheckedListBox1.Items(I - 1).ToString + ".tostring +" + """ AND """ + Chr(13)
                        End Select
                    End If
                Next
                BodyLine = Mid(BodyLine, 1, Len(BodyLine) - 7) + """" + IIf(xcolType = "System.String", "'", "") + """" + Chr(13)
                BodyLine = BodyLine + "XSQL = XSQL + """ + " ORDER BY " + """" + Chr(13)

                For I = 1 To CheckedListBox1.Items.Count
                    If CheckedListBox1.GetItemChecked(I - 1) Then

                        xcolType = miscDS.Tables(0).Columns(CheckedListBox1.Items(I - 1).ToString).DataType.ToString
                        If I = 1 Then
                            FirstCol = CheckedListBox1.Items(I - 1).ToString
                        End If
                        BodyLine = BodyLine + " XSQL = XSQL + """ + CheckedListBox1.Items(I - 1).ToString + ", """ + Chr(13)
                    End If
                Next
                BodyLine = Mid(BodyLine, 1, Len(BodyLine) - 4) + """" + Chr(13)
                BodyLine = BodyLine + "Catch ex as exception" + Chr(13)
                BodyLine = BodyLine + " pResult = ex.Message " + Chr(13) + "Return False" + Chr(13)
                BodyLine = BodyLine + "end try" + Chr(13)
        End Select

        If cmbServiceType.Text = "SearchPartial" Or cmbServiceType.Text = "SearchByKey" Then
            BodyLine = BodyLine + "Dim miscDA As SqlDataAdapter = New SqlDataAdapter(XSQL, sqldb_conexion) " + Chr(13)
            BodyLine = BodyLine + "Dim miscDS As DataSet = New DataSet()" + Chr(13)
            BodyLine = BodyLine + "Try" + Chr(13)
            BodyLine = BodyLine + "miscDA.Fill(miscDS, """ + cmbServiceType.Text + "_" + txtServiceName.Text + """" + ")" + Chr(13)
            BodyLine = BodyLine + "Catch ex As Exception" + Chr(13)
            BodyLine = BodyLine + "pResult = """ + "ERROR," + """+" + "ex.Message" + Chr(13)
            BodyLine = BodyLine + "Return Nothing" + Chr(13)
            BodyLine = BodyLine + "End Try" + Chr(13)
            BodyLine = BodyLine + "If miscDS.Tables(0).Rows.Count <= 0 Then" + Chr(13)
            BodyLine = BodyLine + "pResult = """ + "ERROR,No existe " + txtServiceName.Text + " : ""+ p" + FirstCol + Chr(13)
            BodyLine = BodyLine + "Return Nothing" + Chr(13)
            BodyLine = BodyLine + "Else" + Chr(13)
            BodyLine = BodyLine + "pResult = """ + "OK" + """" + Chr(13)
            BodyLine = BodyLine + "Return miscDS" + Chr(13)
            BodyLine = BodyLine + "End If" + Chr(13)

        Else

            BodyLine = BodyLine + "If ExecuteSqlTransaction(sqldb_conexion.ConnectionString, XSQL, pResult) Then" + Chr(13)
            BodyLine = BodyLine + "  Return True" + Chr(13)
            BodyLine = BodyLine + "Else " + Chr(13) + "Return False " + Chr(13) + "End If" + Chr(13)

            BodyLine = BodyLine + "Catch ex As Exception" + Chr(13)
            BodyLine = BodyLine + " pResult = ex.Message " + Chr(13) + "Return False" + Chr(13)
            BodyLine = BodyLine + " End Try" + Chr(13)

        End If
        Me.rchSQLPreview.Text = ""
        Me.rchSQLPreview.Text = HeaderLine + Chr(13) + BodyLine + Chr(13) + EndOfLine + Chr(13)

    End Sub

    Public Function EvalColType(ByVal pColType As String) As String
        Dim pTipo As String = ""
        Select Case pColType.ToLower
            Case "system.string"
                pTipo = "String"
            Case "system.datetime"
                pTipo = "Date"
            Case "system.decimal"
                pTipo = "Integer"
            Case Else
                pTipo = pColType
        End Select
        Return pTipo
    End Function

    Private Sub frmGenerarServicios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbTableName.SelectedIndex = 0
        Me.cmbServiceType.SelectedIndex = 1

    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Try
            Clipboard.SetText(Me.rchSQLPreview.Text)
            MessageBox.Show("Code Copied")
            End
        Catch ex As Exception
            MessageBox.Show("Not Code Copied")
        End Try
    End Sub

    Private Sub cmbServiceType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbServiceType.SelectedIndexChanged
        If cmbServiceType.Text = "Update" Or cmbServiceType.Text = "Delete" Or cmbServiceType.Text = "SearchPartial" Or cmbServiceType.Text = "SearchByKey" Then
            CheckedListBox1.Visible = True
        Else
            CheckedListBox1.Visible = False
        End If
        GenerateCode("SQL")
    End Sub

    Private Sub cmbTableName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTableName.SelectedIndexChanged
        Cursor = Cursors.WaitCursor
        ReadTableColumns()
        FillUpGrids()
        GenerateCode("BOTH")
        Cursor = Cursors.Default
    End Sub
    Sub FillUpGrids()
        CheckedListBox1.Items.Clear()
        chklst_keycols.Items.Clear()

        For Each xcol In miscDS.Tables(0).Columns
            CheckedListBox1.Items.Insert(xcol.Ordinal, xcol.ColumnName)
        Next
        For Each xcol In Class_miscDS.Tables(0).Columns
            chklst_keycols.Items.Insert(xcol.Ordinal, xcol.ColumnName)
        Next

    End Sub
    Sub GenerateCode(ByVal ServiceID As String)
        Select Case ServiceID
            Case "BOTH"
                SQLParseTable()
                ClassParseTable()
            Case "SQL"
                SQLParseTable()
            Case "CLASS"
                ClassParseTable()
            Case "CLIENT"
                ClientParseTable()
        End Select
    End Sub
    Sub ClassParseTable()
        Dim xWhereLine As String = ""
        Dim ParamsLine As String = ""
        Dim FunctionLine As String = ""
        Dim ConstructorLine As String = ""
        Dim xcol As New DataColumn



        rchClassCode.Text = ""

        ConstructorLine = "Imports System.ComponentModel" + Chr(13)
        ConstructorLine = ConstructorLine + "Public Class cls" + txtServiceName.Text + Chr(13)

        For Each xcol In Class_miscDS.Tables(0).Columns
            ConstructorLine = ConstructorLine + "public _" + xcol.ColumnName + " as " + EvalColType(xcol.DataType.ToString) + Chr(13)
        Next xcol

        For Each xcol In Class_miscDS.Tables(0).Columns

            Dim xColCategory As String = GetColInfo(xcol, "Category")
            Dim xColDescription As String = GetColInfo(xcol, "Description")
            Dim xColCaption As String = GetColInfo(xcol, "Caption")

            ConstructorLine = ConstructorLine + "<Category(""" + xColCategory + """)" + ", Description(""" + xColDescription + """)> _" + Chr(13)
            ConstructorLine = ConstructorLine + "   Public Property " + xColCaption + "() As String" + Chr(13)
            ConstructorLine = ConstructorLine + "Get " + Chr(13) + " Return _" + xcol.ColumnName + Chr(13) + " End Get " + Chr(13) + " Set(ByVal Value As String) " + Chr(13) + " _" + xcol.ColumnName + " = Value " + Chr(13) + " End Set" + Chr(13)
            ConstructorLine = ConstructorLine + "    End Property" + Chr(13)

        Next xcol

        ConstructorLine = ConstructorLine + Chr(13) + "Public Function Grabar(ByRef pResult As String) As Boolean" + Chr(13)
        ConstructorLine = ConstructorLine + "Dim pLocalResult As String = """"" + Chr(13)
        ConstructorLine = ConstructorLine + "try" + Chr(13)
        ConstructorLine = ConstructorLine + "Dim xserv As New " + Me.cmbWebReference.Text + "SoapClient" + Chr(13)
        ConstructorLine = ConstructorLine + "xserv.SearchByKey" + txtServiceName.Text + "("

        For I = 1 To chklst_keycols.Items.Count
            If chklst_keycols.GetItemChecked(I - 1) Then
                Dim xColCaption As String = GetColInfo(Class_miscDS.Tables(0).Columns(I - 1), "Caption")
                ConstructorLine = ConstructorLine + xColCaption + ","
            End If
        Next

        ConstructorLine = Mid(ConstructorLine, 1, Len(ConstructorLine) - 1)
        ConstructorLine = ConstructorLine + ",pLocalResult)" + Chr(13)
        ConstructorLine = ConstructorLine + "If pLocalResult = " + """OK""" + " Then" + " 'Update the record" + Chr(13)
        ConstructorLine = ConstructorLine + "If xserv.Update" + txtServiceName.Text + "("
        For I = 1 To chklst_keycols.Items.Count
            Dim xColCaption As String = GetColInfo(Class_miscDS.Tables(0).Columns(I - 1), "Caption")
            ConstructorLine = ConstructorLine + xColCaption + ","
        Next
        ConstructorLine = Mid(ConstructorLine, 1, Len(ConstructorLine) - 1)
        ConstructorLine = ConstructorLine + ",pLocalResult) Then" + Chr(13)
        ConstructorLine = ConstructorLine + "Return True" + Chr(13)
        ConstructorLine = ConstructorLine + "Else" + Chr(13)
        ConstructorLine = ConstructorLine + "pResult = pLocalResult" + Chr(13)
        ConstructorLine = ConstructorLine + "Return False" + Chr(13)
        ConstructorLine = ConstructorLine + "end if" + Chr(13)
        ConstructorLine = ConstructorLine + "Else 'Add new record" + Chr(13)
        ConstructorLine = ConstructorLine + "If xserv.Create" + txtServiceName.Text + "("
        For I = 1 To chklst_keycols.Items.Count
            Dim xColCaption As String = GetColInfo(Class_miscDS.Tables(0).Columns(I - 1), "Caption")
            ConstructorLine = ConstructorLine + xColCaption + ","
        Next
        Call SetFunctionBottom(ConstructorLine, True)

        ConstructorLine = ConstructorLine + "Public Function Delete(ByRef pResult As String) As Boolean" + Chr(13)
        ConstructorLine = ConstructorLine + "Dim pLocalResult As String = """"" + Chr(13)
        ConstructorLine = ConstructorLine + "Try" + Chr(13)
        ConstructorLine = ConstructorLine + "Dim xserv As New " + cmbWebReference.Text + "SoapClient" + Chr(13)

        ConstructorLine = ConstructorLine + "If xserv.Delete" + txtServiceName.Text + "("

        For I = 1 To chklst_keycols.Items.Count
            If chklst_keycols.GetItemChecked(I - 1) Then
                Dim xColCaption As String = GetColInfo(Class_miscDS.Tables(0).Columns(I - 1), "Caption")
                ConstructorLine = ConstructorLine + xColCaption + ","
            End If
        Next

        Call SetFunctionBottom(ConstructorLine, False)

        ConstructorLine = ConstructorLine + "End Class" + Chr(13)
        Me.rchClassCode.Text = ""
        Me.rchClassCode.Text = ConstructorLine

    End Sub
    Public Function GetColInfo(ByVal xCol As DataColumn, ByVal InfoType As String) As String

        Dim xsql As String

        xsql = "Select value"
        xsql = xsql + " from"
        xsql = xsql + "::fn_listextendedproperty"
        xsql = xsql + "('MS_Description', 'user', 'dbo', "
        xsql = xsql + "'table', '" + Me.cmbTableName.Text + "', 'column', '" + xCol.ColumnName.ToString + "')"

        Dim sqldb_conexion As SqlConnection = New SqlConnection("Server=MOBILITYSCM-PC\SQL2008_LOCAL;Database=OP_WMS;Integrated Security=SSPI")
        Dim Local_miscDS As DataSet = New DataSet()
        Dim Local_miscDA As SqlDataAdapter = New SqlDataAdapter(xsql, sqldb_conexion)

        Try
            Local_miscDA.Fill(Local_miscDS, "SingleParam")

            Dim xstring() As String = Split(Local_miscDS.Tables(0).Rows(0)("value").ToString, "|")
            Select Case InfoType
                Case "Category"
                    Return xstring(2).ToString
                Case "Description"
                    Return xstring(1).ToString
                Case "Caption"
                    Return xstring(0).ToString
            End Select

        Catch ex As Exception

        End Try



        Return ""
    End Function

    Private Sub btn_GenerateClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_GenerateClass.Click
        Try
            Clipboard.Clear()
            Clipboard.SetText(rchClassCode.Text)
            MessageBox.Show("Code Copied")
            End
        Catch ex As Exception
            MessageBox.Show("Not Code Copied")
        End Try
    End Sub
    Public Function SetFunctionBottom(ByRef xstr As String, ByVal IfOption As Boolean) As String

        xstr = Mid(xstr, 1, Len(xstr) - 1)
        xstr = xstr + ",pLocalResult) Then" + Chr(13)
        xstr = xstr + "Return True" + Chr(13)
        xstr = xstr + "Else" + Chr(13)
        xstr = xstr + "pResult = pLocalResult" + Chr(13)
        xstr = xstr + "Return False" + Chr(13)
        xstr = xstr + "end if" + Chr(13)
        If IfOption Then
            xstr = xstr + "end if" + Chr(13)
        End If

        xstr = xstr + "Catch ex As Exception" + Chr(13)
        xstr = xstr + "pResult = ex.Message" + Chr(13)
        xstr = xstr + "return false" + Chr(13)
        xstr = xstr + "end try" + Chr(13)
        xstr = xstr + "end function" + Chr(13) + Chr(13)

        Return xstr
    End Function

    Private Sub txtServiceName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceName.TextChanged
        GenerateCode("BOTH")
    End Sub

    Private Sub txtServiceDesription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtServiceDesription.TextChanged
        GenerateCode("SQL")
    End Sub

    Private Sub cmbWebReference_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWebReference.SelectedIndexChanged
        ClassParseTable()
    End Sub

    Private Sub chklst_keycols_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklst_keycols.ItemCheck

    End Sub

    Private Sub rchSQLPreview_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles rchSQLPreview.GotFocus
        SQLParseTable()
    End Sub

    Private Sub rchSQLPreview_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rchSQLPreview.TextChanged

    End Sub

    Private Sub CheckedListBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CheckedListBox1.KeyUp
        SQLParseTable()
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub chklst_keycols_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklst_keycols.KeyUp
        ClassParseTable()
    End Sub

    Private Sub btnGenerateClientCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateClientCode.Click
        GenerateCode("CLIENT")
    End Sub
    Sub ClientParseTable()
        Dim xcol As DataColumn
        Dim ConstructorLine As String = ""
        ConstructorLine = "Private Sub ClearBag_" + Me.txtServiceName.Text + "()" + Chr(13)
        ConstructorLine = ConstructorLine + "With Bag_" + Me.txtServiceName.Text + "_Class" + Chr(13)

        For Each xcol In Class_miscDS.Tables(0).Columns
            Dim xColCaption As String = GetColInfo(xcol, "Caption")
            ConstructorLine = ConstructorLine + "." + xColCaption + "=" + SetNullValue(xcol.DataType.ToString) + "" + Chr(13)
        Next xcol

        ConstructorLine = ConstructorLine + "Me.PropertyGrid1.SelectedObject = Bag_" + Me.txtServiceName.Text + "_Class" + Chr(13)
        ConstructorLine = ConstructorLine + "Me.PropertyGrid1.Refresh()" + Chr(13)
        ConstructorLine = ConstructorLine + "End With" + Chr(13)
        ConstructorLine = ConstructorLine + "End Sub" + Chr(13)

        ConstructorLine = ConstructorLine + "Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged" + Chr(13)
        ConstructorLine = ConstructorLine + "Select e.ChangedItem.Label" + Chr(13)

        For Each xcol In Class_miscDS.Tables(0).Columns
            Dim xColCaption As String = GetColInfo(xcol, "Caption")
            ConstructorLine = ConstructorLine + "case" + """" + xColCaption + """" + ":" + Chr(13)
            ConstructorLine = ConstructorLine + "Bag_" + Me.txtServiceName.Text + "_Class." + xColCaption + " = e.ChangedItem.Value" + Chr(13)
        Next xcol

        ConstructorLine = ConstructorLine + "End Select" + Chr(13)
        ConstructorLine = ConstructorLine + "SaveAndRefresh()" + Chr(13)
        ConstructorLine = ConstructorLine + "End Sub" + Chr(13)

        ConstructorLine = ConstructorLine + "Public Sub SaveAndRefresh()" + Chr(13)
        ConstructorLine = ConstructorLine + "Dim pResult As String = " + """" + Chr(13)
        ConstructorLine = ConstructorLine + "If Bag_" + Me.txtServiceName.Text + "_Class.Grabar(pResult) Then" + Chr(13)
        ConstructorLine = ConstructorLine + "FilListView()" + Chr(13)
        ConstructorLine = ConstructorLine + "Else" + Chr(13)
        ConstructorLine = ConstructorLine + "MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)" + Chr(13)
        ConstructorLine = ConstructorLine + "End If" + Chr(13)
        ConstructorLine = ConstructorLine + "End Sub" + Chr(13)

        ConstructorLine = ConstructorLine + "Private Sub SaveToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripButton.Click" + Chr(13)
        ConstructorLine = ConstructorLine + "SaveAndRefresh()" + Chr(13)
        ConstructorLine = ConstructorLine + "End Sub" + Chr(13)

        ConstructorLine = ConstructorLine + "Private Sub CutToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CutToolStripButton.Click" + Chr(13)
        ConstructorLine = ConstructorLine + "Dim pResult As String = " + """" + Chr(13)
        ConstructorLine = ConstructorLine + "If Bag_CheckPoint_Class.Delete(pResult) Then" + Chr(13)
        ConstructorLine = ConstructorLine + "    FilListView()" + Chr(13)
        ConstructorLine = ConstructorLine + "    ClearBag_" + Me.txtServiceName.Text + "()" + Chr(13)
        ConstructorLine = ConstructorLine + "else" + Chr(13)
        ConstructorLine = ConstructorLine + "    MessageBox.Show(pResult, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)" + Chr(13)
        ConstructorLine = ConstructorLine + "end if" + Chr(13)
        ConstructorLine = ConstructorLine + "End Sub" + Chr(13)

        ConstructorLine = ConstructorLine + "Private Sub NewToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripButton.Click" + Chr(13)
        ConstructorLine = ConstructorLine + "    ClearBag_" + Me.txtServiceName.Text + "()" + Chr(13)
        ConstructorLine = ConstructorLine + "End Sub" + Chr(13)



        Me.rchtxtClientCode.Text = ""
        Me.rchtxtClientCode.Text = ConstructorLine

        Try
            Clipboard.Clear()
            Clipboard.SetText(Me.rchtxtClientCode.Text)
            MessageBox.Show("copied")
            End
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try




    End Sub

    Private Function SetNullValue(ByVal xType As String) As String
        Select Case xType
            Case "System.String"
                Return " """" "
            Case "System.Date"
                Return "Nothing"
            Case Else
                Return "0"
        End Select
    End Function

    Private Sub chklst_keycols_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklst_keycols.SelectedIndexChanged

    End Sub
End Class

Public Class MyAppSettings
    Private XmlDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument
    Private XmlDefaultConfigurationFileString As String = _
            "<?xml version=""1.0"" encoding=""utf-8"" ?>" & _
            "<configuration>" & _
                "<appSettings>" & _
                    "<add key=""FileCreated"" value=""" & Now & """ />" & _
                    "<add key=""FileModified"" value="""" />" & _
                    "<add key=""UserName"" value="""" />" & _
                    "<add key=""ServerUrl"" value=""http://190.56.115.28:9090"" />" & _
                    "<add key=""Environment"" value=""DEMO"" />" & _
                    "<add key=""LoginCount"" value=""0"" />" & _
                    "<add key=""Printer"" value="""" /> " & _
                    "<add key=""LICENSE_OWNER"" value=""ALSERSA"" /> " & _
                "</appSettings>" & _
            "</configuration>"
    'Kind of data access storage method
    Enum enumXmlSaveMethod
        StreamWrite = 1     'Basic
        XmlTextWriter = 2   'Good
        XmlDocument = 3     'Good as knowledgement

    End Enum '               'Try with the 3
    Private XmlSaveMethod As enumXmlSaveMethod = enumXmlSaveMethod.XmlDocument

    Private _ListItems As New System.Collections.Specialized.NameValueCollection



#Region "Properties"
    Public Property Printer() As String
        Get
            Return Me.ListItems.Get("Printer")
        End Get
        Set(ByVal value As String)
            Me.ListItems.Set("Printer", value)
        End Set
    End Property

    Public Property ListItems() As System.Collections.Specialized.NameValueCollection
        Get
            Return _ListItems
        End Get
        Set(ByVal value As System.Collections.Specialized.NameValueCollection)
            _ListItems = value
        End Set
    End Property

    Public Property Environment() As String
        Get
            Return Me.ListItems.Get("Environment")
        End Get
        Set(ByVal value As String)
            Me.ListItems.Set("Environment", value)
        End Set
    End Property
    Public Property ServerUrl() As String
        Get
            Return Me.ListItems.Get("ServerUrl")
        End Get
        Set(ByVal value As String)
            Me.ListItems.Set("ServerUrl", value)
        End Set
    End Property

    

    Public Property LICENSE_OWNER() As String
        Get
            Return Me.ListItems.Get("LICENSE_OWNER")
        End Get
        Set(ByVal value As String)
            Me.ListItems.Set("LICENSE_OWNER", value)
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return Me.ListItems.Get("UserName")
        End Get
        Set(ByVal value As String)
            Me.ListItems.Set("UserName", value)
        End Set
    End Property
    Public Property LoginCount() As Integer
        Get
            Return CType(Me.ListItems.Get("LoginCount"), Integer)
        End Get
        Set(ByVal value As Integer)
            Me.ListItems.Set("LoginCount", value)
        End Set
    End Property
    'If you don't want to complicated, don't write custom properties code, or write the ones you can -as it by time or priority needed-
    '                                'in that case, no intellinse will be available on forms for that xmlElements
    '                                'W/O properties you'll neeed to use in forms, MyAppSettings.

#End Region



    Sub New(Optional ByVal StrPath As String = Nothing, Optional ByVal StrFilename As String = "AppSettings.xml")
        'Conform the Path
        Dim FilePath As String = IIf(Not StrPath = Nothing, StrPath, _
                                     System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)) _
                                     & "\" & StrFilename

        'Check for the existence of a valid XML configuration file
        If Not System.IO.File.Exists(FilePath) Then
            'Try to save the XmlDefaultConfigurationFile
            If SaveXmlDefaultConfigurationFile(FilePath) = False Then
                Throw New System.IO.IOException
            Else
                XmlDoc.Load(New System.IO.StringReader(XmlDefaultConfigurationFileString))
            End If
        Else
            XmlDoc.Load(FilePath)
        End If

        'Load Settings
        Dim xRoot As System.Xml.XmlElement = XmlDoc.DocumentElement
        '                                        'Configuration   .(appSettings).Elements
        Dim xNodeList As System.Xml.XmlNodeList = xRoot.ChildNodes.Item(0).ChildNodes
        For Each xNode As System.Xml.XmlNode In xNodeList
            ListItems.Add(xNode.Attributes("key").Value, xNode.Attributes("value").Value)
        Next





    End Sub

    Public Function SaveXmlDefaultConfigurationFile(ByVal FilePath As String, Optional ByVal XmlConfigurationFileString As String = Nothing) As Boolean
        Dim theXmlString As String = IIf(Not XmlConfigurationFileString Is Nothing, XmlConfigurationFileString, XmlDefaultConfigurationFileString)
        Select Case XmlSaveMethod
            Case enumXmlSaveMethod.StreamWrite
                Using StreamWriter As System.IO.StreamWriter = New System.IO.StreamWriter(FilePath)
                    StreamWriter.Write(theXmlString)
                    StreamWriter.Close()
                End Using
                Return True


            Case enumXmlSaveMethod.XmlTextWriter
                Using XmlTextWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(FilePath, System.Text.UTF8Encoding.UTF8)
                    XmlTextWriter.WriteStartDocument()
                    XmlTextWriter.WriteStartElement("configuration")
                    XmlTextWriter.WriteStartElement("appSettings")
                    For Each Item As String In GetListItems(theXmlString)
                        XmlTextWriter.WriteStartElement("add")

                        XmlTextWriter.WriteStartAttribute("key", String.Empty)
                        XmlTextWriter.WriteRaw(GetKey(Item)) : XmlTextWriter.WriteEndAttribute()

                        XmlTextWriter.WriteStartAttribute("value", String.Empty)
                        XmlTextWriter.WriteRaw(GetValue(Item)) : XmlTextWriter.WriteEndAttribute()

                        XmlTextWriter.WriteEndElement()

                    Next

                    XmlTextWriter.WriteEndElement()
                    XmlTextWriter.WriteEndElement()
                    XmlTextWriter.Close()

                End Using
                Return True


            Case enumXmlSaveMethod.XmlDocument 'Method you will practice
                Dim XmlDoc As New System.Xml.XmlDocument
                Dim xRoot As System.Xml.XmlElement = XmlDoc.CreateElement("configuration")
                XmlDoc.AppendChild(xRoot)
                Dim xAppSettingsElement As System.Xml.XmlElement = XmlDoc.CreateElement("appSettings")
                xRoot.AppendChild(xAppSettingsElement)


                Dim xElement As System.Xml.XmlElement
                Dim xAttrKey As System.Xml.XmlAttribute
                Dim xAttrValue As System.Xml.XmlAttribute
                For Each Item As String In GetListItems(theXmlString)
                    xElement = XmlDoc.CreateElement("add")
                    xAttrKey = XmlDoc.CreateAttribute("key")
                    xAttrValue = XmlDoc.CreateAttribute("value")
                    xAttrKey.InnerText = GetKey(Item) : xElement.SetAttributeNode(xAttrKey)
                    xAttrValue.InnerText = GetValue(Item) : xElement.SetAttributeNode(xAttrValue)
                    xAppSettingsElement.AppendChild(xElement)
                Next
                Dim XmlPI As System.Xml.XmlProcessingInstruction = XmlDoc.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'")
                XmlDoc.InsertBefore(XmlPI, XmlDoc.ChildNodes(0)) : XmlDoc.Save(FilePath)
                Return True


        End Select

    End Function


    Public Function SaveXmlCurrentConfiguration(Optional ByVal StrPath As String = Nothing, Optional ByVal StrFilename As String = "AppSettings.xml")
        Dim FilePath As String = IIf(Not StrPath = Nothing, StrPath, _
                                     System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)) _
                                     & "\" & StrFilename

        Dim XmlDoc As New System.Xml.XmlDocument
        Dim xRoot As System.Xml.XmlElement = XmlDoc.CreateElement("configuration")
        XmlDoc.AppendChild(xRoot)
        Dim xAppSettingsElement As System.Xml.XmlElement = XmlDoc.CreateElement("appSettings")
        xRoot.AppendChild(xAppSettingsElement)


        Dim xElement As System.Xml.XmlElement
        Dim xAttrKey As System.Xml.XmlAttribute
        Dim xAttrValue As System.Xml.XmlAttribute
        For i As Integer = 0 To Me.ListItems.Count - 1
            xElement = XmlDoc.CreateElement("add")
            xAttrKey = XmlDoc.CreateAttribute("key")
            xAttrValue = XmlDoc.CreateAttribute("value")
            xAttrKey.InnerText = Me.ListItems.GetKey(i) : xElement.SetAttributeNode(xAttrKey)
            xAttrValue.InnerText = Me.ListItems(i) : xElement.SetAttributeNode(xAttrValue)
            xAppSettingsElement.AppendChild(xElement)
        Next
        Dim XmlPI As System.Xml.XmlProcessingInstruction = XmlDoc.CreateProcessingInstruction("xml", "version='1.0' encoding='utf-8'")
        XmlDoc.InsertBefore(XmlPI, XmlDoc.ChildNodes(0)) : XmlDoc.Save(FilePath)
        Return True

    End Function


#Region "Element (Items) Functions to retrieve"
    Public Function GetListItems(ByVal XmlConfigurationFileString As String) As ArrayList
        Dim ListItemsString As String = XmlConfigurationFileString.Substring(XmlConfigurationFileString.IndexOf("<appSettings>") + "<appSettings>".Length, XmlConfigurationFileString.IndexOf("</appSettings>") - (XmlConfigurationFileString.IndexOf("<appSettings>") + "<appSettings>".Length))
        ListItemsString = ListItemsString.Replace("<add", "|<add")
        ListItemsString = ListItemsString.Substring(1)
        Dim result As ArrayList = New ArrayList
        For i = 0 To ListItemsString.ToString.Split("|").Length - 1
            result.Add(ListItemsString.ToString.Split("|")(i))
        Next
        Return result



    End Function

    Private Function GetKey(ByVal Item As String) As String
        Return Item.Substring(Item.IndexOf("=""") + "=""".Length, Item.IndexOf(""" value=""") - (Item.IndexOf("=""") + "=""".Length))

    End Function

    Private Function GetValue(ByVal Item As String) As String
        Return Item.Substring(Item.IndexOf("value=""") + "value=""".Length, Item.IndexOf("""", Item.IndexOf("value=""") + "value=""".Length) - (Item.IndexOf("value=""") + "value=""".Length))

    End Function

#End Region


End Class

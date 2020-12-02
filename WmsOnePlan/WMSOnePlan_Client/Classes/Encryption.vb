Public Class Encryption
    Public Function Cypher(input As String) As String
        Dim asciis As Byte() = System.Text.Encoding.ASCII.GetBytes(input)
        Dim str = ""
        For i As Int32 = 0 To asciis.Length - 1
            str += Hex(CByte(asciis(i) + 1)) & "G"
        Next
        Return str
    End Function

    Public Function Decypher(input As String) As String
        Dim hexs = input.Split("G")
        Dim str = ""
        For i As Int32 = 0 To hexs.Length - 1
            If Not String.IsNullOrEmpty(hexs(i)) Then
                str += Chr(CInt("&H" & hexs(i)) - 1)
            End If
        Next
        Return str
    End Function
End Class

Public Class popupList
    Dim _titulo As String
    Dim _listaDeMensajes As String()

    Public Sub New (ByVal titulo As String, ByVal listaDeMensajes As String())
        InitializeComponent()
        _titulo = titulo
        _listaDeMensajes = listaDeMensajes
    End Sub


    Private Sub popupList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UiEtiquetaTitulo.Text = _titulo
        UiLista.DataSource = _listaDeMensajes
        Me.Text = _titulo
    End Sub
End Class
Friend Class contacto
    Inherits persona

    Private telefono As String
    Private correoInterno As String

    Public Property telefono_ As String
        Get
            Return telefono
        End Get
        Set(ByVal value As String)
            telefono = value
            telefono = telefono.Replace(" ", "").Replace("-", "")
        End Set
    End Property

    Public Property correoElectronico As String
        Get
            Return correoInterno
        End Get
        Set(ByVal value As String)
            correoInterno = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        telefono = String.Empty
        correoInterno = String.Empty
    End Sub

    Public Sub New(ByVal nombre As String, ByVal fechaDenacimiento As DateTime, ByVal telefono As String, ByVal correo As String)
        MyBase.New(nombre, fechaDenacimiento)
        Me.telefono = telefono
        Me.correoInterno = correo
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.ToString() & " " & telefono & " " & correoInterno
    End Function
End Class

Friend Class persona
    Protected Nombre As String
    Protected FechaDenacimiento As DateTime?

    Public Property Nombre_ As String
        Get
            Return Nombre
        End Get
        Set(ByVal value As String)
            Nombre = value
        End Set
    End Property

    Public Property FechaDenacimiento_ As DateTime?
        Get
            Return FechaDenacimiento
        End Get
        Set(ByVal value As DateTime?)
            FechaDenacimiento = value
        End Set
    End Property

    Public ReadOnly Property Edad As Integer
        Get
            Dim Edad_ As Integer
            Edad_ = (DateTime.Now.Year - FechaDenacimiento.Value.Year)
            Return Edad_
        End Get
    End Property

    Public Sub New()
        Nombre = ""
        FechaDenacimiento = Nothing
    End Sub

    Public Sub New(ByVal nombre_ As String, ByVal fechaDenacimento_ As DateTime?)
        Me.Nombre = nombre_
        Me.FechaDenacimiento = fechaDenacimento_
    End Sub

    Public Overrides Function ToString() As String
        Return Nombre.ToUpper() & " " & Edad
    End Function
End Class


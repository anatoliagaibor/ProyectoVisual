Public Class Libro
    Dim titulo As String
    Dim autores As String
    Dim descripcion As String
    Dim categoria As String
    Dim cant_disponible As Integer

    Public Property Titulo1 As String
        Get
            Return titulo
        End Get
        Set(value As String)
            titulo = value
        End Set
    End Property

    Public Property Autores1 As String
        Get
            Return autores
        End Get
        Set(value As String)
            autores = value
        End Set
    End Property

    Public Property Descripcion1 As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    Public Property Categoria1 As String
        Get
            Return categoria
        End Get
        Set(value As String)
            categoria = value
        End Set
    End Property

    Public Property Cant_disponible1 As Integer
        Get
            Return cant_disponible
        End Get
        Set(value As Integer)
            cant_disponible = value
        End Set
    End Property

    Public Sub New(titulo As String, autores As String, descripcion As String, categoria As String, cant_disponible As Integer)
        Me.Titulo1 = titulo
        Me.Autores1 = autores
        Me.Descripcion1 = descripcion
        Me.Categoria1 = categoria
        Me.Cant_disponible1 = cant_disponible
    End Sub
End Class

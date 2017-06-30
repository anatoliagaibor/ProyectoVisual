Public Class Libros
    Dim titulo As String
    Dim autores As String
    Dim descripcion As String
    Dim categoria As String
    Dim cantidad_disponible As Integer

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

    Public Property Cantidad_disponible1 As Integer
        Get
            Return cantidad_disponible
        End Get
        Set(value As Integer)
            cantidad_disponible = value
        End Set
    End Property

    Public Sub buscarLibros()

    End Sub

    Public Sub reservarLibros()

    End Sub

    Public Sub regresarLibros()

    End Sub

    Public Sub generarHistorial()

    End Sub

    Public Sub New(titulo As String, autores As String, descripcion As String, categoria As String, cantidad_disponible As Integer)
        Me.titulo = titulo
        Me.autores = autores
        Me.descripcion = descripcion
        Me.categoria = categoria
        Me.cantidad_disponible = cantidad_disponible
    End Sub

End Class

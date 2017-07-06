Imports avnce1proyecto
Imports System.Xml
Public Class Reservas
    Dim libro As Libros = New Libros()
    Dim persona As Persona = New Persona()
    Dim arrlibro As New ArrayList
    Dim arrpersona As New ArrayList

    Public Sub New(libro As Libros, persona As Persona)
        Me.libro = libro
        Me.persona = persona
    End Sub

    Public Sub New(arrlibro As ArrayList, arrpersona As ArrayList)
        Me.arrlibro = arrlibro
        Me.arrpersona = arrpersona
    End Sub

    Public Property Libro1 As Libros
        Get
            Return libro
        End Get
        Set(value As Libros)
            libro = value
        End Set
    End Property

    Public Property Persona1 As Persona
        Get
            Return persona
        End Get
        Set(value As Persona)
            persona = value
        End Set
    End Property

    Public Property Arrlibro1 As ArrayList
        Get
            Return arrlibro
        End Get
        Set(value As ArrayList)
            arrlibro = value
        End Set
    End Property

    Public Property Arrpersona1 As ArrayList
        Get
            Return arrpersona
        End Get
        Set(value As ArrayList)
            arrpersona = value
        End Set
    End Property
End Class

Imports avnce1proyecto

Public Class Persona
    Dim usuario As Usuario = New Usuario()
    Dim libro As Libros = New Libros()
    Dim reservas As registro = New registro()
    Private path As String = "..\..\Usuario.xml"
    Dim id As Integer
    Dim nombre As String
    Dim apellido As String
    Dim direccion As String
    Dim correo As String
    Dim num_matricula As Integer
    Dim carrera As String
    Dim cantidad_user As Integer = 3



    Public Property Id1 As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property Nombre1 As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property Apellido1 As String
        Get
            Return apellido
        End Get
        Set(value As String)
            apellido = value
        End Set
    End Property

    Public Property Direccion1 As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property Num_matricula1 As Integer
        Get
            Return num_matricula
        End Get
        Set(value As Integer)
            num_matricula = value
        End Set
    End Property

    Public Property Carrera1 As String
        Get
            Return carrera
        End Get
        Set(value As String)
            carrera = value
        End Set
    End Property

    Public Property Correo1 As String
        Get
            Return correo
        End Get
        Set(value As String)
            correo = value
        End Set
    End Property

    Public Property Cantidad_user1 As Integer
        Get
            Return cantidad_user
        End Get
        Set(value As Integer)
            cantidad_user = value
        End Set
    End Property

    Public Property Usuario1 As Usuario
        Get
            Return usuario
        End Get
        Set(value As Usuario)
            usuario = value
        End Set
    End Property

    Public Property Libro1 As Libros
        Get
            Return libro
        End Get
        Set(value As Libros)
            libro = value
        End Set
    End Property
    Public Sub New()

    End Sub

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, correo As String)
        Me.id = id
        Me.nombre = nombre
        Me.apellido = apellido
        Me.direccion = direccion
        Me.correo = correo
    End Sub

    Public Sub New(nombre As String)
        Me.nombre = nombre
    End Sub

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, correo As String, num_matricula As Integer, carrera As String)
        Me.id = id
        Me.nombre = nombre
        Me.apellido = apellido
        Me.direccion = direccion
        Me.correo = correo
        Me.num_matricula = num_matricula
        Me.carrera = carrera
    End Sub




    Public Sub menuAdmnistrador()

        Dim opcion As String = ""
        Dim continuar As Boolean
        Dim libro As Libros = New Libros()
        Console.Clear()
        continuar = True
        While (continuar)
            Console.WriteLine(".....Menu Administrador.....")
            Console.WriteLine()
            Console.WriteLine("1. Buscar libro")
            Console.WriteLine("2. Reservar libro")
            Console.WriteLine("3. Regeresar libro")
            Console.WriteLine("4. imprimir historial")
            Console.WriteLine("5. salir")
            Console.Write("Eliga una opcion:  ")
            opcion = Console.ReadLine()
            If opcion = "1" Then
                continuar = False
                libro.buscarLibros()

            ElseIf opcion = "2" Then
                continuar = False
                libro.reservarLibros()
            ElseIf opcion = "3" Then
                continuar = False
                libro.regresarLibros()
            ElseIf opcion = "4" Then
                Console.WriteLine("4. imprimir historial")
                reservas.menu()
                reservas.menu_libro()
                reservas.menu_usuario()

                continuar = False
            ElseIf opcion = "5" Then
                continuar = False
            Else
                Console.Clear()
            End If
        End While
    End Sub
End Class

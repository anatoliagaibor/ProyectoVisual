Imports avnce1proyecto

Public Class Usuario
    Dim login As String
    Dim password As String
    Dim arr_user As ArrayList
    Dim persona As New Persona
    Dim reserva As New Reservas
    Dim libros As New Libros

    Public Sub New(login As String, password As String, arr_user As ArrayList, persona As Persona, reserva As Reservas)
        Me.login = login
        Me.password = password
        Me.arr_user = arr_user
        Me.persona = persona
        Me.reserva = reserva
    End Sub

    Public Property Login1 As String
        Get
            Return login
        End Get
        Set(value As String)
            login = value
        End Set
    End Property

    Public Property Password1 As String
        Get
            Return password
        End Get
        Set(value As String)
            password = value
        End Set
    End Property

    Public Property Arr_user1 As ArrayList
        Get
            Return arr_user
        End Get
        Set(value As ArrayList)
            arr_user = value
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

    Public Property Reserva1 As Reservas
        Get
            Return reserva
        End Get
        Set(value As Reservas)
            reserva = value
        End Set
    End Property


    Public Sub menu()
        Console.WriteLine("BIENVENIDO AL MENÚ")
        Console.WriteLine("Elija la opcion: ")
        Console.WriteLine(" 1.- Buscar Libros")
        Console.WriteLine(" 2.- Mostrar informacion de perfil")
        Console.WriteLine(" 3.- Salir")

        Dim op As Integer = 3

        Do
            Dim opcion As Integer = Console.ReadLine
            Select Case opcion
                Case 1
                    libros.buscarLibros()
                Case 2
                    cargarDatos()
                Case 3
                    Environment.Exit(0)
            End Select
        Loop While (op = 3)



        Console.ReadLine()


    End Sub

    Public Sub cargarDatos()

    End Sub
End Class

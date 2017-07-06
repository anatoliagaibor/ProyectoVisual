Imports avnce1proyecto

Public Class Usuario
    Dim login As String
    Dim password As String
    Dim arr_user As ArrayList

    Public Sub New(login As String, password As String)
        Me.login = login
        Me.password = password
    End Sub
    Public Sub New()

    End Sub
    Public Sub New(login As String, password As String, arr_user As ArrayList)
        Me.login = login
        Me.password = password
        Me.arr_user = arr_user
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

    Public Sub menu()
        Dim libro As Libros = New Libros()
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
                    libro.buscarLibros()
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

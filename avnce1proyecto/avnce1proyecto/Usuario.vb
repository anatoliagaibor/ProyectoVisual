Imports avnce1proyecto
Imports System.Xml

Public Class Usuario
    Dim login As String
    Dim password As String
    Dim arr_user As ArrayList
    Dim validador As Boolean = False


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

    Public Sub pedirinfo()
        Console.Write("usuario:  ")
        login = Console.ReadLine()
        Console.Write("contraseña:  ")
        password = Console.ReadLine()
        Dim path As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
        Dim xmlDoc As XmlDocument = New XmlDocument()
        xmlDoc.Load(path)
        Dim personas As XmlNodeList = xmlDoc.GetElementsByTagName("persona")
        Dim u As String = ""
        Dim c As String = ""
        For Each usu As XmlNode In personas
            If usu.Attributes(0).Value = "si" Then
                If usu.Attributes(1).Value = login And usu.Attributes(2).Value = password Then
                    validador = True
                    u = usu.Attributes(1).Value
                    c = usu.Attributes(2).Value
                End If
            End If
        Next

        If validador = True Then
            menu()
        Else
            Console.WriteLine("ingreso mal los datos")
            Console.ReadLine()
        End If
    End Sub
End Class

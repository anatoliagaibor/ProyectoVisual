Imports avnce1proyecto
Imports System.Xml

Public Class UsuarioAdministrador
    Inherits Persona

    Dim pathW As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
    Private xmlDoc As XmlDocument = New XmlDocument()

    Public Sub New(nombre As String)
        MyBase.New(nombre)
    End Sub

    Public Sub menuadministrador()
        Dim op As Integer
        Dim continuar As Boolean
        Dim libro As Libros = New Libros()
        continuar = True
        While (continuar)
            Console.WriteLine("******************************************")
            Console.WriteLine("MENU ADMINISTRADOR")
            Console.WriteLine("hola soy la administradora" & Nombre1)
            Console.WriteLine("1.- Buscar libro ")
            Console.WriteLine("2.- Reservar libro ")
            Console.WriteLine("3.- Regresar libro ")
            Console.WriteLine("4.- Imprimir historial")
            Console.WriteLine("5.- Salir")
            Console.Write("Eliga una opcion:  ")

            op = Console.ReadLine()

            Select Case op
                Case 1
                    continuar = False
                    Dim doc As New XmlDocument()
                    Dim elemList As XmlNodeList = doc.GetElementsByTagName("title")
                    Dim i As Integer
                    For i = 0 To elemList.Count - 1
                        Console.WriteLine(elemList(i).InnerXml)
                        Console.WriteLine("-----------------------------------------")
                    Next i
                    Console.WriteLine("*******************BUSCAR LIBRO***************************")
                    libro.buscarLibros()
                Case 2
                    continuar = False
                    Console.WriteLine("*******************RESERVAR LIBRO***************************")
                    libro.reservarLibros()
                Case 3
                    continuar = False
                    Console.WriteLine("*******************REGRESAR LIBRO***************************")
                    libro.regresarLibros()
                Case 4
                    continuar = False
                    Console.WriteLine("*******************IMPRIMIR LIBRO***************************")
                Case Else
                    continuar = False
                    Console.WriteLine("salir")
                    Console.Clear()
            End Select
        End While
    End Sub
End Class

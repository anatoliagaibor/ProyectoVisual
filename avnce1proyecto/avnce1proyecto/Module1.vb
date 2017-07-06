Imports System.Xml

Module Module1


    Sub Main()
        Dim pathW As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
        LeerDom(pathW)

        Console.WriteLine("******************************************")
        Console.WriteLine("MENU")
        Console.WriteLine("1.- Buscar libro ")
        Console.WriteLine("2.- Reservar libro ")
        Console.WriteLine("3.- Regresar libro ")
        Console.WriteLine("4.- Imprimir historial")
        Console.WriteLine("5.- Salir")

        Dim a As Integer = 5

        Do


            Dim op As Integer = Console.ReadLine()

            Select Case op
                Case 1
                    Dim doc As New XmlDocument()
                    Dim elemList As XmlNodeList = doc.GetElementsByTagName("title")
                    Dim i As Integer
                    For i = 0 To elemList.Count - 1
                        Console.WriteLine(elemList(i).InnerXml)
                        Console.WriteLine("-----------------------------------------")
                    Next i
                    Console.WriteLine("*******************BUSCAR LIBRO***************************")
                    Console.WriteLine("digite el nombre del libro a buscar: ")
                    Dim librobuscar As String = Console.ReadLine
                    buscarLibro(librobuscar, pathW)
                Case 2

                Case 3

                Case 4

                Case Else
                    Console.WriteLine("salir")
                    Environment.Exit(0)
            End Select
        Loop While a = 5
        Console.ReadLine()

    End Sub

    Private Sub buscarLibro(libroBuscar As String, pathW As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(pathW)
        Dim libros As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim book As XmlNode

        For Each book In libros
            If book.HasChildNodes Then
                For Each child As XmlNode In book.ChildNodes
                    If book.ChildNodes("title").Value = libroBuscar Then
                        Console.WriteLine(child.Name & ": " & child.InnerText)
                    End If
                Next

            End If
        Next

        Console.WriteLine("-------------------------------------")
    End Sub

    Public Sub LeerDom(pathW As String)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(pathW)
        Dim libritos As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        For Each book As XmlElement In libritos
            Console.WriteLine(book.Name & ": " & book.Attributes("id").Value)
            For Each child As XmlNode In book.ChildNodes
                Console.WriteLine(child.Name & ": " & child.InnerText)
            Next
            Console.WriteLine("-------------------------------------")
        Next
    End Sub

End Module




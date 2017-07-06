Imports System.Xml

Module Module1


    Sub Main()

        Dim administrador As UsuarioAdministrador = New UsuarioAdministrador("Roberto")
        Dim estPost As EstudiantePosgrado = New EstudiantePosgrado("1", "julia", "mora", "urdenor", "200078659", "ing. computacion", "julia@espol.edu.ec", "3")
        Dim estPreg As estudiantePregrado = New estudiantePregrado("2", "nancy", "chalen", "kennedy", "20147896235", "lic. diseño web", "nchalen@espol.edu.ec", "1")
        Dim profesor As profesor = New profesor("3", "jessica", "gaibor", "urdesa", "manuel@espol.edu.ec", "5")

        Dim validador As Boolean = False
        Dim libro As Libros = New Libros()


        Dim pathW As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
        LeerDom(pathW)

        Console.ReadLine()

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




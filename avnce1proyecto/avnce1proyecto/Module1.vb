Imports System.Xml

Module Module1


    Sub Main()

        Dim pathW As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
        LeerDom(pathW)

        Dim administrador As UsuarioAdministrador = New UsuarioAdministrador("Roberto")
        Dim estPost As EstudiantePosgrado = New EstudiantePosgrado(1, "julia", "mora", "urdenor", "ing. computacion", 200078659, "julia@espol.edu.ec", 3)
        Dim estPreg As estudiantePregrado = New estudiantePregrado(2, "nancy", "chalen", "kennedy", "lic. diseño web", 201478962, "nchalen@espol.edu.ec", 1)
        Dim profesor As profesor = New profesor(3, "jessica", "gaibor", "urdesa", "jessica@espol.edu.ec", 5)

        Dim libro As Libros = New Libros()
        Dim op As Integer
        Dim user As Usuario = New Usuario()

        Console.WriteLine("usted que tipo de persona es: ")
        Console.WriteLine("1.- Estudiante Pregrado? ")
        Console.WriteLine("2.- Estudiante Postgrado? ")
        Console.WriteLine("3.- Estudiante Profesor? ")
        Console.Write("Eliga una opcion:  ")

        op = Console.ReadLine()

        Select Case op
            Case 1
                Console.WriteLine("elegir cualquiera de las 2 opciones: ")
                Console.WriteLine("1.- ingreso por usuario")
                Console.WriteLine("2.- ingreso por administrador")
                Dim item As Integer = Console.ReadLine()
                Select Case op
                    Case 1
                        user.pedirinfo()
                    Case 2
                        Console.WriteLine("informacion del estudiante Pregrado: " & estPreg.Id1 & " " & estPreg.Nombre1 & " " &
                                  estPreg.Apellido1 & " " & estPreg.Direccion1 & " " & estPreg.Num_matricula1 & " " &
                                  estPreg.Carrera1 & " " & estPreg.Correo1 & " " & estPreg.Cantidad_venta1)

                        Dim cantidad As Integer = 1
                        If estPreg.Cantidad_venta1 > 0 Then
                            cantidad = estPreg.Cantidad_venta1 - cantidad
                            estPreg.Cantidad_venta1 = cantidad
                            Console.WriteLine("cantidad de venta: " & estPreg.Cantidad_venta1)
                            administrador.menuadministrador()
                        Else
                            Console.WriteLine("ya no puede reservar!! :(")
                            Console.Clear()
                        End If

                End Select

            Case 2
                Console.WriteLine("elegir cualquiera de las 2 opciones: ")
                Console.WriteLine("1.- ingreso por usuario")
                Console.WriteLine("2.- ingreso por administrador")
                Dim item As Integer = Console.ReadLine()
                Select Case op
                    Case 1
                        user.pedirinfo()
                    Case 2
                        Console.WriteLine("informacion del estudiante Postgrado: " & estPost.Id1 & " " & estPost.Nombre1 & " " &
                                  estPost.Apellido1 & " " & estPost.Direccion1 & " " & estPost.Num_matricula1 & " " &
                                  estPost.Carrera1 & " " & estPost.Correo1 & " " & estPost.Cantidad_venta1)
                        Dim cantidad As Integer = 1
                        If estPost.Cantidad_venta1 > 0 Then
                            cantidad = estPost.Cantidad_venta1 - cantidad
                            estPost.Cantidad_venta1 = cantidad
                            Console.WriteLine("cantidad de venta: " & estPost.Cantidad_venta1)
                            administrador.menuadministrador()
                        Else
                            Console.WriteLine("ya no puede reservar!! :(")
                            Console.Clear()
                        End If
                End Select


            Case 3
                Console.WriteLine("elegir cualquiera de las 2 opciones: ")
                Console.WriteLine("1.- ingreso por usuario")
                Console.WriteLine("2.- ingreso por administrador")
                Dim item As Integer = Console.ReadLine()
                Select Case op
                    Case 1
                        user.pedirinfo()
                    Case 2
                        Console.WriteLine("informacion del estudiante Profesor: " & profesor.Id1 & " " & profesor.Nombre1 & " " &
                                 profesor.Apellido1 & " " & profesor.Direccion1 & " " & profesor.Correo1 & " " &
                                 profesor.Cantidad_venta1)
                        Dim cantidad As Integer = 1
                        If profesor.Cantidad_venta1 > 0 Then
                            cantidad = profesor.Cantidad_venta1 - cantidad
                            profesor.Cantidad_venta1 = cantidad
                            Console.WriteLine("cantidad de venta: " & profesor.Cantidad_venta1)
                            administrador.menuadministrador()
                        Else
                            Console.WriteLine("ya no puede reservar!! :(")
                            Console.Clear()
                        End If
                End Select

            Case Else
                Console.WriteLine("usted no es un estudiante!!!")
                Console.Clear()
        End Select
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




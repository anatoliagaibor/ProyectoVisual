Imports System.Xml

Public Class Libros
    Private path As String = "..\..\inventario.xml"
    Private pathW As String = "..\..\Usuarios.xml"
    Private xmlDoc As XmlDocument = New XmlDocument()

    Private title As String
    Private author As String
    Private category As String
    Private price As String
    Private description As String
    Private disponible As Integer

    Public Property Title1 As String
        Get
            Return title
        End Get
        Set(value As String)
            title = value
        End Set
    End Property

    Public Property Author1 As String
        Get
            Return author
        End Get
        Set(value As String)
            author = value
        End Set
    End Property

    Public Property Category1 As String
        Get
            Return category
        End Get
        Set(value As String)
            category = value
        End Set
    End Property

    Public Property Price1 As String
        Get
            Return price
        End Get
        Set(value As String)
            price = value
        End Set
    End Property

    Public Property Description1 As String
        Get
            Return description
        End Get
        Set(value As String)
            description = value
        End Set
    End Property

    Public Property Disponible1 As Integer
        Get
            Return disponible
        End Get
        Set(value As Integer)
            disponible = value
        End Set
    End Property

    Public Sub New(title As String, author As String, category As String, price As String, description As String, disponible As Integer)
        Me.title = title
        Me.author = author
        Me.category = category
        Me.price = price
        Me.description = description
        Me.disponible = disponible
    End Sub
    Public Sub New()

    End Sub





    Public Sub buscarLibros()

        Dim opcion As String = ""
        Console.Clear()
        Console.WriteLine(".....Menu Buscar Libro.....")
        Console.WriteLine()
        Console.WriteLine("1.Por Nombre")
        Console.WriteLine("2.Por Autor")
        Console.WriteLine("3.Por Categoria")
        Console.WriteLine("4. salir")
        Console.Write("Eliga una opcion:  ")
        opcion = Console.ReadLine()
        If opcion = "1" Then
            Dim busquedaLibro As String = ""
            Console.WriteLine()
            Console.Write("Ingrese nombre del libro: ")
            busquedaLibro = Console.ReadLine()
            buscarxnombre(busquedaLibro)
        ElseIf opcion = "2" Then
            Dim busquedaAutor As String = ""
            Console.WriteLine()
            Console.Write("Ingrese autor del libro: ")
            busquedaAutor = Console.ReadLine()
            buscarxautor(busquedaAutor)
        ElseIf opcion = "3" Then
            Dim busquedaCategoria As String = ""
            Console.WriteLine()
            Console.Write("Ingrese categoria del libro: ")
            busquedaCategoria = Console.ReadLine()
            buscarxcategoria(busquedaCategoria)
        ElseIf opcion = "4" Then
        Else
            Console.WriteLine("ingreso mal la opcion")
            Console.ReadLine()
        End If

        Console.WriteLine("-------------------------------------")
    End Sub

    Public Sub reservarLibros()

        Dim nombreUser As String = ""
        Dim titulolibro As String = ""
        Dim fechareserva As String = ""
        Console.Clear()
        Console.WriteLine(".....Menu Reservar Libro.....")
        Console.WriteLine()
        Console.Write("Ingrese Nombre del Usuario: ")
        nombreUser = Console.ReadLine()
        Console.Write("Ingrese Titulo del Libro: ")
        titulolibro = Console.ReadLine()
        Console.Write("Ingrese fecha del reserva: ")
        fechareserva = Console.ReadLine()
        Console.WriteLine("")
        xmlDoc.Load(path)
        xmlDoc.Load(pathW)

        Dim validadortitulo As Boolean = False
        Dim titulos As XmlNodeList = xmlDoc.GetElementsByTagName("title")
        For Each titul As XmlNode In titulos
            For Each child As XmlNode In titul.ChildNodes
                If child.LocalName = "title" Then
                    If child.InnerText = titulolibro Then
                        validadortitulo = True
                    End If
                End If
            Next
        Next


        Dim validadornombre As Boolean = False
        Dim autores As XmlNodeList = xmlDoc.GetElementsByTagName("persona")
        For Each autor As XmlNode In autores
            For Each child As XmlNode In autor.ChildNodes
                If child.LocalName = "nombre" Then
                    If child.InnerText = nombreUser Then
                        validadornombre = True
                    End If
                End If
            Next
        Next


        If validadortitulo = False Or validadornombre = False Then
            Console.WriteLine("ingreso mal los datosfdf")

            Console.ReadLine()
        End If


        If validadornombre = True And validadortitulo = True Then
            Dim contadorl As Integer = 0
            For Each titul As XmlNode In titulos
                For Each child As XmlNode In titul.ChildNodes
                    If child.LocalName = "title" Then
                        If child.InnerText = titulolibro Then
                            contadorl = Integer.Parse(titul.ChildNodes.Item(3).InnerText)
                        End If
                    End If
                Next
            Next

            Dim contador_a As Integer = 0
            Dim contador_b As Integer = 0
            For Each autor As XmlNode In autores
                For Each child As XmlNode In autor.ChildNodes
                    If child.LocalName = "nombre" Then
                        If child.InnerText = nombreUser Then
                            contador_a = Integer.Parse(autor.ChildNodes.Item(2).InnerText)
                            contador_b = Integer.Parse(autor.ChildNodes.Item(5).InnerText)
                        End If
                    End If
                Next
            Next


            Dim valib As Boolean = False
            Dim valic As Boolean = False

            If contadorl = 0 Then
                Console.WriteLine("no hay libros disponibles")
            Else
                valib = True
            End If
            If contador_a >= contador_b Then
                Console.WriteLine("no se puede alquilar")
            Else
                valic = True
            End If


            If valib = True And valic = True Then
                For Each titul As XmlNode In titulos
                    For Each child As XmlNode In titul.ChildNodes
                        If child.LocalName = "title" Then
                            If child.InnerText = titulolibro Then
                                contadorl = Integer.Parse(titul.ChildNodes.Item(3).InnerText) - 1
                                titul.ChildNodes.Item(3).InnerText = contadorl
                            End If
                        End If
                    Next
                Next


                For Each autor As XmlNode In autores
                    For Each child As XmlNode In autor.ChildNodes
                        If child.LocalName = "nombre" Then
                            If child.InnerText = nombreUser Then
                                contador_a = Integer.Parse(autor.ChildNodes.Item(2).InnerText) + 1
                                autor.ChildNodes.Item(2).InnerText = contador_a
                            End If
                        End If
                    Next
                Next


                Dim registro As XmlElement = xmlDoc.CreateElement("registro")
                Dim entregado As XmlAttribute = xmlDoc.CreateAttribute("entregado")
                entregado.InnerText = "no"

                registro.SetAttribute("entregado", "no")
                Dim libro As XmlElement = xmlDoc.CreateElement("libro")
                libro.InnerText = title
                registro.AppendChild(libro)
                Dim name As XmlElement = xmlDoc.CreateElement("name")
                name.InnerText = nombreUser
                registro.AppendChild(name)
                Dim tiempo As XmlElement = xmlDoc.CreateElement("tiempo")
                tiempo.InnerText = "0"
                registro.AppendChild(tiempo)
                Dim fecha As XmlElement = xmlDoc.CreateElement("fecha")
                fecha.InnerText = fechareserva
                registro.AppendChild(fecha)
                Dim contador As Integer = xmlDoc.GetElementsByTagName("historial").Count - 1
                Dim coleccion As XmlNode = xmlDoc.GetElementsByTagName("historial").Item(contador)
                coleccion.AppendChild(registro)
                xmlDoc.Save("..\..\reservas.xml")
            End If
            Console.ReadLine()
        End If
    End Sub

    Public Sub regresarLibros()
        Dim nom As String = ""
        Dim tit As String = ""
        Dim fechaa As String = ""
        Dim tiempo As String = ""
        Console.Clear()
        Console.WriteLine(".....Menu Regresar Libro.....")
        Console.WriteLine()
        Console.Write("Ingrese Nombre del Usuario: ")
        nom = Console.ReadLine()
        Console.Write("Ingrese Titulo del Libro: ")
        tit = Console.ReadLine()
        Console.Write("Ingrese fecha de regreso: ")
        fechaa = Console.ReadLine()
        Console.Write("Ingrese tiempo de regreso: ")
        tiempo = Console.ReadLine()
        Console.WriteLine("")
        xmlDoc.Load(path)

        Dim validador As Boolean = False
        Dim registros As XmlNodeList = xmlDoc.GetElementsByTagName("registro")
        Dim tnom As String = ""
        Dim ttit As String = ""
        For Each registro As XmlNode In registros
            Console.WriteLine(registro.Attributes(0).Value)
            If registro.Attributes(0).Value = "no" Then
                Console.WriteLine("entro")
                For Each child As XmlNode In registro.ChildNodes
                    If child.LocalName = "libro" Then
                        ttit = child.InnerText
                    End If
                    If child.LocalName = "name" Then
                        tnom = child.InnerText
                    End If
                Next
                If tnom = nom And ttit = tit Then
                    validador = True
                End If
            End If
        Next
        If validador = False Then
            Console.WriteLine("datos mal ingresados o no se encuentra en el sistema")
            Console.ReadLine()
        Else
            For Each registro As XmlNode In registros
                If registro.Attributes(0).Value = "no" Then
                    For Each child As XmlNode In registro.ChildNodes
                        If child.LocalName = "sistema" Then
                            ttit = child.InnerText
                        End If
                        If child.LocalName = "name" Then
                            tnom = child.InnerText
                        End If
                    Next
                    If tnom = nom And ttit = tit Then
                        registro.Attributes(0).Value = "si"
                        registro.ChildNodes.Item(2).InnerText = tiempo
                        registro.ChildNodes.Item(3).InnerText = fechaa

                    End If
                End If

            Next
            Dim contadorl As Integer = 1
            Dim titulos As XmlNodeList = xmlDoc.GetElementsByTagName("book")
            For Each titul As XmlNode In titulos
                For Each child As XmlNode In titul.ChildNodes
                    If child.LocalName = "title" Then
                        If child.InnerText = tit Then
                            contadorl = Integer.Parse(titul.ChildNodes.Item(3).InnerText) + 1
                            titul.ChildNodes.Item(3).InnerText = contadorl
                        End If
                    End If
                Next
            Next
            Dim contadora As Integer = 1
            Dim autores As XmlNodeList = xmlDoc.GetElementsByTagName("book")
            For Each autor As XmlNode In autores
                For Each child As XmlNode In autor.ChildNodes
                    If child.LocalName = "nombre" Then
                        If child.InnerText = nom Then
                            contadora = Integer.Parse(autor.ChildNodes.Item(2).InnerText) - 1
                            autor.ChildNodes.Item(2).InnerText = contadora
                        End If
                    End If
                Next
            Next
            xmlDoc.Save("..\..\libro.xml")
        End If


    End Sub

    Public Sub generarHistorial()

    End Sub
    Public Sub buscarxnombre(nombre As String)
        xmlDoc.Load(path)
        Dim libros As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim validador As Boolean = False
        Dim valid As Boolean = False
        Dim book As Libros = New Libros()


        Dim title As String = ""
        Dim author As String = ""
        Dim category As String = ""
        Dim price As String = ""
        Dim description As String = ""
        Dim disponible As String = " "
        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "title" Then
                    title = child.InnerText
                End If
                If child.LocalName = "author" Then
                    author = child.InnerText
                End If
                If child.LocalName = "category" Then
                    category = child.InnerText
                End If
                If child.LocalName = "price" Then
                    price = Integer.Parse(child.InnerText)
                End If
                If child.LocalName = "description" Then
                    description = child.InnerText
                End If
                If child.LocalName = "disponible" Then
                    disponible = child.InnerText
                End If
            Next
            If (title = nombre) Then
                validador = True
                book = New Libros(title, author, category, price, description, disponible)
            End If
            If validador = True Then
                Console.WriteLine(".....Libro.....")
                Console.WriteLine()
                Console.Write("title libro: ")
                Console.WriteLine(book.Title1)
                Console.Write("autor libro: ")
                Console.WriteLine(book.Author1)
                Console.Write("categoria libro: ")
                Console.WriteLine(book.Category1)
                Console.Write("price libro: ")
                Console.WriteLine(book.Price1)
                Console.Write("descripcion del libro: ")
                Console.WriteLine(book.Description1)
                Console.Write("disponibilidad del  libro: ")
                Console.WriteLine(book.Disponible1)

                valid = True
            End If
        Next
        If valid = False Then
            Console.WriteLine("libro no encontrado  o ingreso datos erroneos")
            Console.ReadLine()
        End If
        Console.ReadLine()
    End Sub
    Public Sub buscarxautor(escritor As String)
        xmlDoc.Load(path)
        Dim libros As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim validador As Boolean = False
        Dim valid As Boolean = False
        Dim book As Libros = New Libros()

        Dim title As String = ""
        Dim author As String = ""
        Dim category As String = ""
        Dim price As String = ""
        Dim description As String = ""
        Dim disponible As String = ""


        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "title" Then
                    title = child.InnerText
                End If
                If child.LocalName = "author" Then
                    author = child.InnerText
                End If
                If child.LocalName = "category" Then
                    category = child.InnerText
                End If
                If child.LocalName = "price" Then
                    price = Integer.Parse(child.InnerText)
                End If
                If child.LocalName = "description" Then
                    description = child.InnerText
                End If
                If child.LocalName = "disponible" Then
                    disponible = child.InnerText
                End If
            Next
            If (author = escritor) Then
                validador = True
                book = New Libros(title, author, category, price, description, disponible)
            End If
            If validador = True Then
                Console.WriteLine(".....Libro.....")
                Console.WriteLine()
                Console.Write("title libro: ")
                Console.WriteLine(book.Title1)
                Console.Write("autor libro: ")
                Console.WriteLine(book.Author1)
                Console.Write("categoria libro: ")
                Console.WriteLine(book.Category1)
                Console.Write("price libro: ")
                Console.WriteLine(book.Price1)
                Console.Write("descripcion del libro: ")
                Console.WriteLine(book.Description1)
                Console.Write("disponibilidad del  libro: ")
                Console.WriteLine(book.Disponible1)

                valid = True
            End If
        Next
    End Sub
    Public Sub buscarxcategoria(categoria As String)
        xmlDoc.Load(path)
        Dim libros As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim validador As Boolean = False
        Dim valid As Boolean = False
        Dim book As Libros = New Libros()


        Dim title As String = ""
        Dim author As String = ""
        Dim category As String = ""
        Dim price As Integer = ""
        Dim description As String = ""
        Dim disponible As String = ""
        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "title" Then
                    title = child.InnerText
                End If
                If child.LocalName = "author" Then
                    author = child.InnerText
                End If
                If child.LocalName = "category" Then
                    category = child.InnerText
                End If
                If child.LocalName = "price" Then
                    price = Integer.Parse(child.InnerText)
                End If
                If child.LocalName = "description" Then
                    description = child.InnerText
                End If
                If child.LocalName = "disponible" Then
                    disponible = child.InnerText
                End If
            Next
            If (category = categoria) Then
                validador = True
                book = New Libros(title, author, category, price, description, disponible)
            End If
            If validador = True Then
                Console.WriteLine(".....Libro.....")
                Console.WriteLine()
                Console.Write("title libro: ")
                Console.WriteLine(book.Title1)
                Console.Write("autor libro: ")
                Console.WriteLine(book.Author1)
                Console.Write("categoria libro: ")
                Console.WriteLine(book.Category1)
                Console.Write("price libro: ")
                Console.WriteLine(book.Price1)
                Console.Write("descripcion del libro: ")
                Console.WriteLine(book.Description1)
                Console.Write("disponibilidad del  libro: ")
                Console.WriteLine(book.Disponible1)

                valid = True
            End If
        Next
        If valid = False Then
            Console.WriteLine("libro no encontrado  o ingreso datos erroneos")
            Console.ReadLine()
        End If
        Console.ReadLine()
    End Sub

End Class


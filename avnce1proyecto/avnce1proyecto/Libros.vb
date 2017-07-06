Imports System.Xml

Public Class Libros
    Private path As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
    Private pathW As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\Usuarios.xml"
    Private xmlDoc As XmlDocument = New XmlDocument()
    Dim titulo As String
    Dim autores As String
    Dim descripcion As String
    Dim categoria As String
    Dim cantidad_disponible As Integer

    Public Sub New()

    End Sub
    Public Property Titulo1 As String
        Get
            Return titulo
        End Get
        Set(value As String)
            titulo = value
        End Set
    End Property

    Public Property Autores1 As String
        Get
            Return autores
        End Get
        Set(value As String)
            autores = value
        End Set
    End Property

    Public Property Descripcion1 As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    Public Property Categoria1 As String
        Get
            Return categoria
        End Get
        Set(value As String)
            categoria = value
        End Set
    End Property

    Public Property Cantidad_disponible1 As Integer
        Get
            Return cantidad_disponible
        End Get
        Set(value As Integer)
            cantidad_disponible = value
        End Set
    End Property

    Public Sub buscarLibros()
        Dim opcion As String = ""
        Console.WriteLine(".....Menu Buscar Libro.....")
        Console.WriteLine()
        Console.WriteLine("1.Por Nombre")
        Console.WriteLine("2.Por Autor")
        Console.WriteLine("3.Por Categoria")
        Console.WriteLine("4. salir")
        Console.Write("Eliga una opcion:  ")
        opcion = Console.ReadLine()
        If opcion = "1" Then
            Dim bn As String = ""
            Console.WriteLine()
            Console.Write("Ingrese nombre del libro: ")
            bn = Console.ReadLine()
            buscarxnombre(bn)
        ElseIf opcion = "2" Then
            Dim bn As String = ""
            Console.WriteLine()
            Console.Write("Ingrese autor del libro: ")
            bn = Console.ReadLine()
            buscarxautor(bn)
        ElseIf opcion = "3" Then
            Dim bn As String = ""
            Console.WriteLine()
            Console.Write("Ingrese categoria del libro: ")
            bn = Console.ReadLine()
            buscarxcategoria(bn)
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
                libro.InnerText = titulo
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
                xmlDoc.Save("C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\reservas.xml")
            End If
            Console.ReadLine()
        End If
    End Sub

    Public Sub regresarLibros()
        Dim nom As String = ""
        Dim tit As String = ""
        Dim fechaa As String = ""
        Dim tiempo As String = ""
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
                        If child.LocalName = "libro" Then
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
                    If child.LocalName = "titulo" Then
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
            xmlDoc.Save("C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml")
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
        Dim name As String = ""
        Dim auto As String = ""
        Dim cate As String = ""
        Dim cant As String = ""
        Dim prec As String = ""
        Dim desc As String = ""
        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "author" Then
                    auto = child.InnerText
                End If
                If child.LocalName = "title" Then
                    name = child.InnerText
                End If
                If child.LocalName = "category" Then
                    cate = child.InnerText
                End If
                If child.LocalName = "disponible" Then
                    cant = Integer.Parse(child.InnerText)
                End If
                If child.LocalName = "price" Then
                    prec = child.InnerText
                End If
                If child.LocalName = "description" Then
                    desc = child.InnerText
                End If
            Next
            If (name = nombre) Then
                validador = True
                book = New Libros(auto, name, cate, cant, desc)
            End If
            If validador = True Then
                Console.WriteLine(".....Libro.....")
                Console.WriteLine()
                Console.Write("autor: ")
                Console.WriteLine(book.autores)
                Console.Write("nombre: ")
                Console.WriteLine(book.titulo)
                Console.Write("categoria: ")
                Console.WriteLine(book.categoria)
                Console.Write("cantidad: ")
                Console.WriteLine(book.cantidad_disponible)
                Console.Write("descripcion: ")
                Console.WriteLine(book.descripcion)
                valid = True
            End If
        Next
        If valid = False Then
            Console.WriteLine("libro no encontrado  o ingreso datos erroneos")
            Console.ReadLine()
        End If
        Console.ReadLine()
    End Sub
    Public Sub buscarxautor(autor As String)
        xmlDoc.Load(path)
        Dim libros As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim validador As Boolean = False
        Dim valid As Boolean = False
        Dim book As Libros = New Libros()
        Dim name As String = ""
        Dim auto As String = ""
        Dim cate As String = ""
        Dim cant As String = ""
        Dim desc As String = ""
        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "author" Then
                    auto = child.InnerText
                End If
                If child.LocalName = "title" Then
                    name = child.InnerText
                End If
                If child.LocalName = "category" Then
                    cate = child.InnerText
                End If
                If child.LocalName = "disponible" Then
                    cant = Integer.Parse(child.InnerText)
                End If
                If child.LocalName = "description" Then
                    desc = child.InnerText
                End If
            Next
            If (auto = autor) Then
                validador = True
                book = New Libros(auto, name, cate, cant, desc)
            End If
            If validador = True Then
                Console.WriteLine(".....Libro.....")
                Console.WriteLine()
                Console.Write("autor: ")
                Console.WriteLine(book.autores)
                Console.Write("nombre: ")
                Console.WriteLine(book.titulo)
                Console.Write("categoria: ")
                Console.WriteLine(book.categoria)
                Console.Write("cantidad: ")
                Console.WriteLine(book.cantidad_disponible)
                Console.Write("descripcion: ")
                Console.WriteLine(book.descripcion)
                valid = True
            End If
        Next
        If valid = False Then
            Console.WriteLine("libro no encontrado  o ingreso datos erroneos")
            Console.ReadLine()
        End If
        Console.ReadLine()
    End Sub
    Public Sub buscarxcategoria(categoria As String)
        xmlDoc.Load(path)
        Dim libros As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim validador As Boolean = False
        Dim valid As Boolean = False
        Dim book As Libros = New Libros()
        Dim name As String = ""
        Dim auto As String = ""
        Dim cate As String = ""
        Dim cant As String = ""
        Dim desc As String = ""
        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "author" Then
                    auto = child.InnerText
                End If
                If child.LocalName = "title" Then
                    name = child.InnerText
                End If
                If child.LocalName = "category" Then
                    cate = child.InnerText
                End If
                If child.LocalName = "disponible" Then
                    cant = Integer.Parse(child.InnerText)
                End If
                If child.LocalName = "description" Then
                    desc = child.InnerText
                End If
            Next
            If (cate = categoria) Then
                validador = True
                book = New Libros(auto, name, cate, cant, desc)
            End If
            If validador = True Then
                Console.WriteLine(".....Libro.....")
                Console.WriteLine()
                Console.Write("autor: ")
                Console.WriteLine(book.autores)
                Console.Write("nombre: ")
                Console.WriteLine(book.titulo)
                Console.Write("categoria: ")
                Console.WriteLine(book.categoria)
                Console.Write("cantidad: ")
                Console.WriteLine(book.cantidad_disponible)
                Console.Write("descripcion: ")
                Console.WriteLine(book.descripcion)
                valid = True
            End If
        Next
        If valid = False Then
            Console.WriteLine("libro no encontrado  o ingreso datos erroneos")
            Console.ReadLine()
        End If
        Console.ReadLine()
    End Sub
    Public Sub New(titulo As String, autores As String, descripcion As String, categoria As String, cantidad_disponible As Integer)
        Me.titulo = titulo
        Me.autores = autores
        Me.descripcion = descripcion
        Me.categoria = categoria
        Me.cantidad_disponible = cantidad_disponible
    End Sub

End Class

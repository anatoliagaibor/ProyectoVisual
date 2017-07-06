Imports System.Xml

Public Class Libros
    Private path As String = "C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\inventario.xml"
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
        Dim nom As String = ""
        Dim tit As String = ""
        Console.Clear()
        Console.WriteLine(".....Menu Reservar Libro.....")
        Console.WriteLine()
        Console.Write("Ingrese Nombre del Usuario: ")
        nom = Console.ReadLine()
        Console.Write("Ingrese Titulo del Libro: ")
        tit = Console.ReadLine()
        Console.WriteLine("")
        xmlDoc.Load(path)
        Dim validadortitulo As Boolean = False
        Dim titulos As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        For Each titul As XmlNode In titulos
            For Each child As XmlNode In titul.ChildNodes
                If child.LocalName = "title" Then
                    If child.InnerText = tit Then
                        validadortitulo = True
                    End If
                End If
            Next
        Next
        Dim validadornombre As Boolean = False
        Dim autores As XmlNodeList = xmlDoc.GetElementsByTagName("persona")
        For Each autor As XmlNode In autores
            For Each child As XmlNode In autor.ChildNodes
                If child.LocalName = "author" Then
                    If child.InnerText = nom Then
                        validadornombre = True
                    End If
                End If
            Next
        Next
        If validadortitulo = False Or validadornombre = False Then
            Console.WriteLine("ingreso mal los datos")
            Console.ReadLine()
        End If
        If validadornombre = True And validadortitulo = True Then
            Dim contadorl As Integer = 0
            For Each titul As XmlNode In titulos
                For Each child As XmlNode In titul.ChildNodes
                    If child.LocalName = "titulo" Then
                        If child.InnerText = tit Then
                            contadorl = Integer.Parse(titul.ChildNodes.Item(3).InnerText)
                        End If
                    End If
                Next
            Next
            Dim contadora As Integer = 0
            Dim contadorb As Integer = 0
            For Each autor As XmlNode In autores
                For Each child As XmlNode In autor.ChildNodes
                    If child.LocalName = "nombre" Then
                        If child.InnerText = nom Then
                            contadora = Integer.Parse(autor.ChildNodes.Item(2).InnerText)
                            contadorb = Integer.Parse(autor.ChildNodes.Item(5).InnerText)
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
            If contadora >= contadorb Then
                Console.WriteLine("no se puede alquilar")
            Else
                valic = True
            End If
            If valib = True And valic = True Then
                For Each titul As XmlNode In titulos
                    For Each child As XmlNode In titul.ChildNodes
                        If child.LocalName = "titulo" Then
                            If child.InnerText = tit Then
                                contadorl = Integer.Parse(titul.ChildNodes.Item(3).InnerText) - 1
                                titul.ChildNodes.Item(3).InnerText = contadorl
                            End If
                        End If
                    Next
                Next
                For Each autor As XmlNode In autores
                    For Each child As XmlNode In autor.ChildNodes
                        If child.LocalName = "nombre" Then
                            If child.InnerText = nom Then
                                contadora = Integer.Parse(autor.ChildNodes.Item(2).InnerText) + 1
                                autor.ChildNodes.Item(2).InnerText = contadora
                            End If
                        End If
                    Next
                Next
                xmlDoc.Save("C:\Users\jessica\Downloads\avnce1proyecto\avnce1proyecto\libros2.xml")
            End If
            Console.ReadLine()
        End If
    End Sub

    Public Sub regresarLibros()

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
        Dim desc As String = ""
        For Each libro As XmlNode In libros
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "autor" Then
                    auto = child.InnerText
                End If
                If child.LocalName = "titulo" Then
                    name = child.InnerText
                End If
                If child.LocalName = "categoria" Then
                    cate = child.InnerText
                End If
                If child.LocalName = "cantidad" Then
                    cant = Integer.Parse(child.InnerText)
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
                If child.LocalName = "autor" Then
                    auto = child.InnerText
                End If
                If child.LocalName = "titulo" Then
                    name = child.InnerText
                End If
                If child.LocalName = "categoria" Then
                    cate = child.InnerText
                End If
                If child.LocalName = "cantidad" Then
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
                If child.LocalName = "autor" Then
                    auto = child.InnerText
                End If
                If child.LocalName = "titulo" Then
                    name = child.InnerText
                End If
                If child.LocalName = "categoria" Then
                    cate = child.InnerText
                End If
                If child.LocalName = "cantidad" Then
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

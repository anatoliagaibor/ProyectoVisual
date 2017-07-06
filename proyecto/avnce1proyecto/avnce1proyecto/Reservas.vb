Imports System.Xml

Public Class registro

    Private path As String = "..\..\inventario.xml"
    Private xmlDoc As XmlDocument = New XmlDocument()
    Private nombre As String
    Private usuario As String
    Private fecha As String
    Private tiempo As String
    Private estado As Boolean = False

    Public Property nombre1 As String

        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property
    Public Property usuario1 As String

        Get
            Return usuario
        End Get
        Set(value As String)
            usuario = value
        End Set
    End Property
    Public Property fecha1 As String

        Get
            Return fecha
        End Get
        Set(value As String)
            fecha = value
        End Set
    End Property
    Public Property tiempo1 As String

        Get
            Return tiempo
        End Get
        Set(value As String)
            tiempo = value
        End Set
    End Property
    Public Property estado1 As Boolean

        Get
            Return estado
        End Get
        Set(value As Boolean)
            estado = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub menu()
        Dim registroPersona As String = ""
        Dim registroLibro As String = ""
        Dim op As String = ""
        Console.Clear()
        Console.WriteLine(".....Menu registro.....")
        Console.WriteLine()
        Console.Write("1. mostrar registro por persona: ")
        registroPersona = Console.ReadLine()
        Console.Write("2 mostrar registro por libro: ")
        registroLibro = Console.ReadLine()
        Console.Write("eliga una opcion")
        op = Console.ReadLine()
        If op = "1" Then
            menu_usuario()
        ElseIf op = "2" Then
            menu_libro()
        ElseIf op = "3" Then
            Console.ReadLine()
        Else
            Console.WriteLine("ingreso mal la opcion")
            Console.ReadLine()

        End If
    End Sub
    Public Sub menu_usuario()
        Dim op As String = ""
        Console.Write("ingrese nombre de usuario: ")
        op = Console.ReadLine()
        xmlDoc.Load(path)
        Dim tnom As String = ""
        Dim teda As String = ""
        Dim numr As String = ""
        Dim tcor As String = ""
        Dim trol As String = ""
        Dim usuarios As XmlNodeList = xmlDoc.GetElementsByTagName("usuario")
        Console.WriteLine("datos")
        For Each usuario As XmlNode In usuarios
            For Each child As XmlNode In usuario.ChildNodes
                If child.LocalName = "nombre" Then
                    tnom = child.InnerText
                End If
                If child.LocalName = "rol" Then
                    trol = child.InnerText
                End If
                If child.LocalName = "edad" Then
                    teda = child.InnerText
                End If
                If child.LocalName = "numerorenta" Then
                    numr = child.InnerText
                End If
                If child.LocalName = "correo" Then
                    tcor = child.InnerText
                End If
            Next
            If op = tnom Then
                Console.WriteLine("nombre: " & tnom)
                Console.WriteLine("edad: " & teda)
                Console.WriteLine("numero de renta: " & numr)
                Console.WriteLine("correo: " & tcor)
                Console.WriteLine("rol: " & trol)
            End If
        Next
        Dim test As String = ""
        Dim tlib As String = ""
        Dim tnam As String = ""
        Dim ttie As String = ""
        Dim tfec As String = ""
        Console.WriteLine("registroHistorial")
        Dim book As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        For Each libro As XmlNode In book
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "libro" Then
                    tlib = child.InnerText
                End If
                If child.LocalName = "name" Then
                    tnam = child.InnerText
                End If
                If child.LocalName = "tiempo" Then
                    ttie = child.InnerText
                End If
                If child.LocalName = "fecha" Then
                    tfec = child.InnerText
                End If
            Next
            If tnam = op Then
                Console.WriteLine("estado del libro" & libro.Attributes(0).Value)
                Console.WriteLine("nombre del libro" & tlib)
                Console.WriteLine("tiempo del libro" & ttie)
                Console.WriteLine("fecha del libro" & tfec)
            End If
        Next
        Console.ReadLine()
    End Sub
    Public Sub menu_libro()
        Dim op As String = ""
        Console.Write("ingrese titulo del libro: ")
        op = Console.ReadLine()
        xmlDoc.Load(path)
        Console.WriteLine("registroHistorial")
        Dim book As XmlNodeList = xmlDoc.GetElementsByTagName("book")
        Dim test As String = ""
        Dim historialLibro As String = ""
        Dim historialNombre As String = ""
        Dim historialTiempo As String = ""
        Dim historialFecha As String = ""
        For Each libro As XmlNode In book
            For Each child As XmlNode In libro.ChildNodes
                If child.LocalName = "libro" Then
                    historialLibro = child.InnerText
                End If
                If child.LocalName = "name" Then
                    historialNombre = child.InnerText
                End If
                If child.LocalName = "tiempo" Then
                    historialTiempo = child.InnerText
                End If
                If child.LocalName = "fecha" Then
                    historialFecha = child.InnerText
                End If
            Next
            If historialTiempo = op Then
                Console.WriteLine("estado del libro" & libro.Attributes(0).Value)
                Console.WriteLine("nombre del libro" & historialLibro)
                Console.WriteLine("nombre del usuario" & historialNombre)
                Console.WriteLine("tiempo del libro" & historialTiempo)
                Console.WriteLine("fecha del libro" & historialFecha)
            End If
        Next
        Console.ReadLine()
    End Sub
End Class
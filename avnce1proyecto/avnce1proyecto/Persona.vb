﻿Public Class Persona


    Dim id As Integer
    Dim nombre As String
    Dim apellido As String
    Dim direccion As String
    Dim correo As String
    Dim num_matricula As Integer
    Dim carrera As String


    Public Property Id1 As Integer
        Get
            Return id
        End Get
        Set(value As Integer)
            id = value
        End Set
    End Property

    Public Property Nombre1 As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property Apellido1 As String
        Get
            Return apellido
        End Get
        Set(value As String)
            apellido = value
        End Set
    End Property

    Public Property Direccion1 As String
        Get
            Return direccion
        End Get
        Set(value As String)
            direccion = value
        End Set
    End Property

    Public Property Num_matricula1 As Integer
        Get
            Return num_matricula
        End Get
        Set(value As Integer)
            num_matricula = value
        End Set
    End Property

    Public Property Carrera1 As String
        Get
            Return carrera
        End Get
        Set(value As String)
            carrera = value
        End Set
    End Property

    Public Property Correo1 As String
        Get
            Return correo
        End Get
        Set(value As String)
            correo = value
        End Set
    End Property

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, num_matricula As Integer, carrera As String, correo As String)
        Me.Id1 = id
        Me.Nombre1 = nombre
        Me.Apellido1 = apellido
        Me.Direccion1 = direccion
        Me.Num_matricula1 = num_matricula
        Me.Carrera1 = carrera
        Me.Correo1 = correo
    End Sub

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, correo As String)
        Me.id = id
        Me.nombre = nombre
        Me.apellido = apellido
        Me.direccion = direccion
        Me.correo = correo
    End Sub
End Class
﻿Public Class EstudiantePosgrado

    Inherits Persona
    Dim cantidad_venta As Integer = 3

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, correo As String, num_matricula As Integer, carrera As String, cantidad_venta As Integer)
        MyBase.New(id, nombre, apellido, direccion, correo, num_matricula, carrera)
        Me.Cantidad_venta1 = cantidad_venta
    End Sub


    Public Property Cantidad_venta1 As Integer
        Get
            Return cantidad_venta
        End Get
        Set(value As Integer)
            cantidad_venta = value
        End Set
    End Property
End Class



Public Class profesor

    Inherits Persona
    Dim cantidad_venta As Integer = 5

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, correo As String, cantidad_venta As Integer)
        MyBase.New(id, nombre, apellido, direccion, correo)
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

Public Class UsuarioAdministrador
    Inherits Persona

    Public Sub New(id As Integer, nombre As String, apellido As String, direccion As String, num_matricula As Integer, carrera As String, correo As String)
        MyBase.New(id, nombre, apellido, direccion, num_matricula, carrera, correo)
    End Sub
End Class

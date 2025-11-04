Imports MySql.Data.MySqlClient

Public Class Conexion
    Dim conexionn As New MySqlConnection("server=localhost; port=3000; user id=root;password=;database=estudiantes")

    Public Overridable Function AbrirConexion()
        If conexionn.State = ConnectionState.Closed Then
            conexionn.Open()
        End If
    End Function

    Public Overridable Function CerrarConexion()
        If conexionn.State = ConnectionState.Open Then
            conexionn.Close()
        End If
    End Function
End Class

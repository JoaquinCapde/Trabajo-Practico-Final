Imports MySql.Data.MySqlClient

Public Class Clientes
    Inherits Conexion
    Dim conexionn As New MySqlConnection("server=localhost; port=3000; user id=root;password=;database=estudiantes")
    Private _Telefono As Integer
    Private ReadOnly _Id As Integer
    Private _Nombre, _Correo As String

    Public Property Telefono As Integer
        Get
            Return _Telefono
        End Get
        Set(value As Integer)
            If value > 0 Then
                _Telefono = value
            End If
        End Set
    End Property

    Public ReadOnly Property Id As Integer
        Get
            Return _Id
        End Get
    End Property

    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            If value <> "" And value <> "  " Then
                _Nombre = value
            End If
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            If value <> "" And value <> "  " Then
                _Correo = value
            End If
        End Set
    End Property

    Public Sub New(telefono As Integer, id As Integer, Nombre As String, Correo As String)
        Me.Telefono = telefono
        Me.Nombre = Nombre
        Me.Correo = Correo
        id = id
    End Sub

    Public Sub New()

    End Sub

    Public Function CargarCliente()
        Try
            AbrirConexion()
            Dim consulta As String = "Select * from clientes"
            Dim adaptador As New MySqlDataAdapter(consulta, conexionn)
            Dim tabla As New DataTable()
            adaptador.Fill(tabla)
            Return tabla
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Function

    Public Function BorrarCliente(Nombre As String, Telefono As Integer, Correo As String)
        Try
            AbrirConexion()
            Dim consulta As String = "Insert into clientes (Cliente, Telefono, Correo) VALUES (@Cliente, @Telefono, @Correo)"
            Dim comando = New MySqlCommand(consulta, conexionn)
            comando.Parameters.AddWithValue("@Cliente", Nombre)
            comando.Parameters.AddWithValue("@Telefono", Telefono)
            comando.Parameters.AddWithValue("@Correo", Correo)
            comando.ExecuteNonQuery()
            MessageBox.Show("Cliente borrado")
            CargarCliente()
        Catch ex As Exception
            MessageBox.Show("Error" & ex.Message)
        End Try
    End Function

    Public Function ModificarCliente(Nombre As String, Telefono As Integer, Correo As String, Id As String)
        Try
            AbrirConexion()
            Dim consulta As String = "UPDATE cliente SET Id=@Id, Cliente=@Cliente, Telefono=@Telefono, Correo=@Correo WHERE id=@id"
            Dim comando = New MySqlCommand(consulta, conexionn)
            comando.Parameters.AddWithValue("@Cliente", Nombre)
            comando.Parameters.AddWithValue("@Telefono", Telefono)
            comando.Parameters.AddWithValue("@Correo", Correo)
            comando.Parameters.AddWithValue("@Id", Id)
            comando.ExecuteNonQuery()
            MessageBox.Show("Cliente actualizado")
            CargarCliente()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
        End Try
    End Function
End Class

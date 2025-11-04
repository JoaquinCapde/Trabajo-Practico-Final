Imports MySql.Data.MySqlClient

Public Class Producto
    Inherits Conexion
    Dim conexionn As New MySqlConnection("server=localhost; port=3000; user id=root;password=;database=estudiantes")
    Private ReadOnly _id As Integer
    Private _Nombre As String
    Private _precio As Integer
    Private _categoria As String

    Public ReadOnly Property Id As Integer
        Get
            Return _id
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

    Public Property Categoria As String
        Get
            Return _categoria
        End Get
        Set(value As String)
            If value <> "" And value <> "  " Then
                _categoria = value
            End If
        End Set
    End Property

    Public Property Precio As Integer
        Get
            Return _precio
        End Get
        Set(value As Integer)
            If value > 0 Then
                _precio = value
            End If
        End Set
    End Property

    Public Sub New(id As Integer, nombre As String, categoria As String, precio As Integer)
        id = id
        Me.Categoria = categoria
        Me.Precio = precio
        Me.Nombre = nombre
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

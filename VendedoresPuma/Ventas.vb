Public Class Ventas
    Inherits Conexion
    Private ReadOnly _id, _idcliente As Integer
    Private _fecha As Date
    Private _total As Integer

    Public Property fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            If value <= Date.Today Then
                _fecha = value
            End If
        End Set
    End Property

    Public Property total As Integer
        Get
            Return _total
        End Get
        Set(value As Integer)
            If value > 0 Then
                _total = value
            End If
        End Set
    End Property

    Public ReadOnly Property id As Integer
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property idcliente As Integer
        Get
            Return _idcliente
        End Get
    End Property

    Public Sub New(id As Integer, idcliente As Integer, fecha As Date, total As Integer)
        id = id
        idcliente = idcliente
        Me.fecha = fecha
        Me.total = total
    End Sub

    Public Sub New()

    End Sub
End Class

Public Class ItemVenta
    Public Property ID As Integer
    Public Property IDVenta As Integer
    Public Property Producto As Producto
    Public Property Cantidad As Integer
    Public Property Subtotal As Decimal

    ' Constructor vacío
    Public Sub New()
        Producto = New Producto() ' Inicializar la instancia de Producto
    End Sub

    ' Constructor con parámetros
    Public Sub New(ByVal id As Integer, ByVal idVenta As Integer, ByVal producto As Producto, ByVal cantidad As Integer, ByVal subtotal As Decimal)
        Me.ID = id
        Me.IDVenta = idVenta
        Me.Producto = producto
        Me.Cantidad = cantidad
        Me.Subtotal = subtotal
    End Sub
End Class

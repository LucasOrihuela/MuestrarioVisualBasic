Imports System.Data.SqlClient
Public Class Venta
    Public Property ID As Integer
    Public Property IDCliente As Integer
    Public Property Fecha As DateTime
    Public Property Total As Decimal
    Public Property Items As List(Of ItemVenta)

    ' Constructor vacío
    Public Sub New()
        Items = New List(Of ItemVenta)()
    End Sub

    ' Constructor con parámetros
    Public Sub New(ByVal id As Integer, ByVal idCliente As Integer, ByVal fecha As DateTime, ByVal total As Decimal, ByVal items As List(Of ItemVenta))
        Me.ID = id
        Me.IDCliente = idCliente
        Me.Fecha = fecha
        Me.Total = total
        Me.Items = items
    End Sub

    Public Sub GuardarVenta(ByVal itemsVenta As List(Of ItemVenta))
        Try
            Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If

                Using transaction As SqlTransaction = conexion.BeginTransaction()
                    ' Insertar la venta en la tabla Ventas
                    Dim insertVentaQuery As String = "INSERT INTO ventas (IDCliente, Fecha, Total) VALUES (@IDCliente, @Fecha, @Total); SELECT SCOPE_IDENTITY();"
                    Dim ventaCommand As New SqlCommand(insertVentaQuery, conexion)
                    ventaCommand.Parameters.AddWithValue("@IDCliente", Me.IDCliente)
                    ventaCommand.Parameters.AddWithValue("@Fecha", Me.Fecha)
                    ventaCommand.Parameters.AddWithValue("@Total", Me.Total)
                    ventaCommand.Transaction = transaction

                    ' Obtener el ID de la venta insertada
                    Dim idVenta As Integer = Convert.ToInt32(ventaCommand.ExecuteScalar())

                    ' Insertar los items de venta en la tabla VentasItems
                    For Each itemVenta As ItemVenta In itemsVenta
                        Dim insertItemVentaQuery As String = "INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @Subtotal)"
                        Dim itemVentaCommand As New SqlCommand(insertItemVentaQuery, conexion)
                        itemVentaCommand.Parameters.AddWithValue("@IDVenta", idVenta)
                        itemVentaCommand.Parameters.AddWithValue("@IDProducto", itemVenta.Producto.ID)
                        itemVentaCommand.Parameters.AddWithValue("@PrecioUnitario", itemVenta.Producto.Precio)
                        itemVentaCommand.Parameters.AddWithValue("@Cantidad", itemVenta.Cantidad)
                        itemVentaCommand.Parameters.AddWithValue("@Subtotal", itemVenta.Subtotal)
                        itemVentaCommand.Transaction = transaction
                        itemVentaCommand.ExecuteNonQuery()
                    Next

                    ' Confirmar la transacción
                    transaction.Commit()
                End Using
            End Using
        Catch ex As Exception
            ' En caso de error, hacer rollback de la transacción
            Throw New Exception("Error al guardar la venta en la base de datos.", ex)
        End Try
    End Sub

    Public Shared Function ObtenerVentas(ByVal idCliente As Integer?, ByVal fecha As Date?, ByVal total As Decimal?) As List(Of Venta)
        Dim ventas As New List(Of Venta)()

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            conexion.Open()

            Dim consulta As String = "SELECT ID, IDCliente, Fecha, Total FROM ventas WHERE 1=1 "
            Dim parametros As New List(Of SqlParameter)()

            If idCliente.HasValue AndAlso idCliente.Value <> 0 Then
                consulta &= "AND IDCliente = @IDCliente "
                parametros.Add(New SqlParameter("@IDCliente", idCliente.Value))
            End If

            If fecha.HasValue Then
                ' Filtrar por fecha sin tener en cuenta la hora
                consulta &= "AND CONVERT(date, Fecha) = @Fecha "
                parametros.Add(New SqlParameter("@Fecha", fecha.Value.Date.ToString("yyyy-MM-dd")))
            End If

            If total.HasValue Then
                consulta &= "AND Total = @Total "
                parametros.Add(New SqlParameter("@Total", total.Value))
            End If

            Using comando As New SqlCommand(consulta, conexion)
                For Each parametro As SqlParameter In parametros
                    comando.Parameters.Add(parametro)
                Next

                Using lector As SqlDataReader = comando.ExecuteReader()
                    While lector.Read()
                        Dim venta As New Venta()
                        venta.ID = Convert.ToInt32(lector("ID"))
                        venta.IDCliente = Convert.ToInt32(lector("IDCliente"))
                        venta.Fecha = Convert.ToDateTime(lector("Fecha"))
                        venta.Total = Convert.ToDecimal(lector("Total"))
                        ventas.Add(venta)
                    End While
                End Using
            End Using
        End Using

        Return ventas
    End Function
    Public Sub EliminarVenta(ByVal idVenta As Integer)
        Try
            Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If

                Using transaction As SqlTransaction = conexion.BeginTransaction()
                    ' Eliminar los registros de la tabla VentasItems
                    Dim deleteItemsQuery As String = "DELETE FROM ventasitems WHERE IDVenta = @IDVenta"
                    Dim deleteItemsCommand As New SqlCommand(deleteItemsQuery, conexion)
                    deleteItemsCommand.Parameters.AddWithValue("@IDVenta", idVenta)
                    deleteItemsCommand.Transaction = transaction
                    deleteItemsCommand.ExecuteNonQuery()

                    ' Eliminar el registro de la tabla Ventas
                    Dim deleteVentaQuery As String = "DELETE FROM ventas WHERE ID = @IDVenta"
                    Dim deleteVentaCommand As New SqlCommand(deleteVentaQuery, conexion)
                    deleteVentaCommand.Parameters.AddWithValue("@IDVenta", idVenta)
                    deleteVentaCommand.Transaction = transaction
                    deleteVentaCommand.ExecuteNonQuery()

                    ' Confirmar la transacción
                    transaction.Commit()
                End Using
            End Using
        Catch ex As Exception
            ' En caso de error, hacer rollback de la transacción
            Throw New Exception("Error al eliminar la venta de la base de datos.", ex)
        End Try
    End Sub
    Public Shared Sub CargarVenta(ByVal idVenta As Integer, ByVal formVentas As FormVentas)
        ' Obtener datos de la venta desde la base de datos
        Dim venta As Venta = ObtenerVentaPorId(idVenta)

        If venta IsNot Nothing Then
            ' Almacenar el ID de la venta en una propiedad del formulario
            formVentas.IdVenta = venta.ID
            formVentas.ClienteSeleccionadoID = venta.IDCliente
            ' Cargar datos de la venta en los controles del formulario
            formVentas.lblTotalPrecio.Text = venta.Total.ToString()

            ' Obtener y cargar los elementos relacionados de ventasitems en la ListView
            Dim itemsVenta As List(Of ItemVenta) = ObtenerItemsVentaPorIdVenta(idVenta)
            formVentas.listViewVentas.Items.Clear()
            For Each item As ItemVenta In itemsVenta
                Dim listItem As New ListViewItem(item.Producto.ID.ToString())
                listItem.SubItems.Add(item.Producto.Nombre)
                listItem.SubItems.Add(item.Producto.Categoria)
                listItem.SubItems.Add(item.Producto.Precio.ToString())
                listItem.SubItems.Add(item.Cantidad.ToString())
                listItem.SubItems.Add(item.Subtotal.ToString())
                formVentas.listViewVentas.Items.Add(listItem)
            Next
        Else
            ' Manejar el caso en que no se encuentre la venta
            MessageBox.Show("No se encontró la venta con el ID especificado.")
        End If
    End Sub

    Public Sub ModificarVenta(ByVal idVenta As Integer, ByVal itemsVenta As List(Of ItemVenta))
        Try
            Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
                If conexion.State = ConnectionState.Closed Then
                    conexion.Open()
                End If

                Using transaction As SqlTransaction = conexion.BeginTransaction()
                    ' Eliminar los registros existentes en ventasitems
                    Dim deleteItemsQuery As String = "DELETE FROM ventasitems WHERE IDVenta = @IDVenta"
                    Dim deleteItemsCommand As New SqlCommand(deleteItemsQuery, conexion)
                    deleteItemsCommand.Parameters.AddWithValue("@IDVenta", idVenta)
                    deleteItemsCommand.Transaction = transaction
                    deleteItemsCommand.ExecuteNonQuery()

                    ' Insertar los nuevos items de venta
                    For Each itemVenta As ItemVenta In itemsVenta
                        Dim insertItemVentaQuery As String = "INSERT INTO ventasitems (IDVenta, IDProducto, PrecioUnitario, Cantidad, PrecioTotal) VALUES (@IDVenta, @IDProducto, @PrecioUnitario, @Cantidad, @Subtotal)"
                        Dim itemVentaCommand As New SqlCommand(insertItemVentaQuery, conexion)
                        itemVentaCommand.Parameters.AddWithValue("@IDVenta", idVenta)
                        itemVentaCommand.Parameters.AddWithValue("@IDProducto", itemVenta.Producto.ID)
                        itemVentaCommand.Parameters.AddWithValue("@PrecioUnitario", itemVenta.Producto.Precio)
                        itemVentaCommand.Parameters.AddWithValue("@Cantidad", itemVenta.Cantidad)
                        itemVentaCommand.Parameters.AddWithValue("@Subtotal", itemVenta.Subtotal)
                        itemVentaCommand.Transaction = transaction
                        itemVentaCommand.ExecuteNonQuery()
                    Next

                    ' Modificar el registro en la tabla ventas
                    Dim updateVentaQuery As String = "UPDATE ventas SET IDCliente = @IDCliente, Fecha = @Fecha, Total = @Total WHERE ID = @IDVenta"
                    Dim updateVentaCommand As New SqlCommand(updateVentaQuery, conexion)
                    updateVentaCommand.Parameters.AddWithValue("@IDVenta", idVenta)
                    updateVentaCommand.Parameters.AddWithValue("@IDCliente", Me.IDCliente)
                    updateVentaCommand.Parameters.AddWithValue("@Fecha", Me.Fecha)
                    updateVentaCommand.Parameters.AddWithValue("@Total", Me.Total)
                    updateVentaCommand.Transaction = transaction
                    updateVentaCommand.ExecuteNonQuery()

                    ' Confirmar la transacción
                    transaction.Commit()
                End Using
            End Using
        Catch ex As Exception
            ' En caso de error, hacer rollback de la transacción
            Throw New Exception("Error al modificar la venta en la base de datos.", ex)
        End Try
    End Sub

    Public Shared Function ObtenerVentaPorId(ByVal idVenta As Integer) As Venta
        Dim venta As New Venta()

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            conexion.Open()
            Dim consulta As String = "SELECT IDCliente, Fecha, Total FROM ventas WHERE ID = @IdVenta"
            Using comando As New SqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@IdVenta", idVenta)
                Using reader As SqlDataReader = comando.ExecuteReader()
                    If reader.Read() Then
                        venta.ID = idVenta
                        venta.IDCliente = Convert.ToInt32(reader("IDCliente"))
                        venta.Fecha = Convert.ToDateTime(reader("Fecha"))
                        venta.Total = Convert.ToDecimal(reader("Total"))
                    End If
                End Using
            End Using
        End Using

        Return venta
    End Function

    Public Shared Function ObtenerItemsVentaPorIdVenta(ByVal idVenta As Integer) As List(Of ItemVenta)
        Dim itemsVenta As New List(Of ItemVenta)()

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            conexion.Open()

            Dim consulta As String = "SELECT ID, IDProducto, PrecioUnitario, Cantidad, PrecioTotal FROM ventasitems WHERE IDVenta = @idVenta"

            Using comando As New SqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@idVenta", idVenta)
                Using lector As SqlDataReader = comando.ExecuteReader()
                    While lector.Read()
                        Dim producto As New Producto()
                        Dim nombreProducto As String = Producto.ObtenerNombreProductoPorId(Convert.ToInt32(lector("IDProducto")))
                        Dim categoriaProducto As String = Producto.ObtenerCategoriaProductoPorId(Convert.ToInt32(lector("IDProducto")))

                        producto.ID = Convert.ToInt32(lector("IDProducto"))
                        producto.Nombre = nombreProducto
                        producto.Categoria = categoriaProducto
                        producto.Precio = Convert.ToDecimal(lector("PrecioUnitario"))

                        ' Crear una instancia de ItemVenta con la información obtenida
                        Dim itemVenta As New ItemVenta()
                        itemVenta.ID = Convert.ToInt32(lector("ID"))
                        itemVenta.IDVenta = idVenta
                        itemVenta.Producto = producto
                        itemVenta.Cantidad = Convert.ToInt32(lector("Cantidad"))
                        itemVenta.Subtotal = Convert.ToDecimal(lector("PrecioTotal"))
                        itemsVenta.Add(itemVenta)
                    End While
                End Using
            End Using
        End Using

        ' Devolver Nothing si no se encontraron ítems
        If itemsVenta.Count = 0 Then
            Return Nothing
        End If

        Return itemsVenta
    End Function

End Class

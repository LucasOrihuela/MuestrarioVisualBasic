Imports System.Data.SqlClient
Public Class Producto
    Public Property ID As Integer
    Public Property Nombre As String
    Public Property Precio As Decimal
    Public Property Categoria As String

    ' Constructor vacío
    Public Sub New()
    End Sub

    ' Constructor con parámetros
    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal precio As Decimal, ByVal categoria As String)
        Me.ID = id
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Categoria = categoria
    End Sub

    Public Sub GuardarProducto()
        Dim query As String = "INSERT INTO productos (Nombre, Precio, Categoria) VALUES (@Nombre, @Precio, @Categoria)"

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@Nombre", Nombre)
                comando.Parameters.AddWithValue("@Precio", Precio)
                comando.Parameters.AddWithValue("@Categoria", Categoria)

                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    Console.WriteLine("Producto guardado en la base de datos.")
                Catch ex As Exception
                    Console.WriteLine("Error al guardar el producto en la base de datos: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub CargarProductosEnListView(listView As ListView)

        Dim query As String = "SELECT ID, Nombre, Precio, Categoria FROM Productos"

        ' Establecer la conexión a la base de datos y ejecutar la consulta
        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                conexion.Open()
                Dim reader As SqlDataReader = comando.ExecuteReader()

                ' Limpiar el ListView antes de agregar nuevos elementos
                listView.Items.Clear()

                ' Leer los datos de los productos y agregarlos al ListView
                While reader.Read()
                    Dim id As Integer = reader("ID")
                    Dim nombre As String = reader("Nombre").ToString()
                    Dim precio As Decimal = reader("Precio").ToString()
                    Dim categoria As String = reader("Categoria").ToString()

                    ' Crear un nuevo ListViewItem para el producto actual
                    Dim item As New ListViewItem(id.ToString()) ' Agregar el ID como primer subítem
                    item.SubItems.Add(nombre)
                    item.SubItems.Add(precio)
                    item.SubItems.Add(categoria)

                    ' Establecer el Tag del ListViewItem con el ID del producto
                    item.Tag = id

                    ' Agregar el ListViewItem al ListView
                    listView.Items.Add(item)
                End While

                reader.Close()
            End Using
        End Using

    End Sub

    Public Sub ModificarProducto()

        Dim query As String = "UPDATE productos SET Nombre = @Nombre, Precio = @Precio, Categoria = @Categoria where ID = @ID"

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@ID", ID)
                comando.Parameters.AddWithValue("@Nombre", Nombre)
                comando.Parameters.AddWithValue("@Precio", Precio)
                comando.Parameters.AddWithValue("@Categoria", Categoria)

                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    Console.WriteLine("Producto modificado en la base de datos.")
                Catch ex As Exception
                    Console.WriteLine("Error al modificar el producto en la base de datos: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub EliminarProducto()

        Dim query As String = "DELETE productos where ID = @ID"

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@ID", ID)

                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    Console.WriteLine("Producto eliminado en la base de datos.")
                Catch ex As Exception
                    Console.WriteLine("Error al eliminar el producto en la base de datos: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub FiltrarProductosEnListView(listView As ListView, textoBusqueda As String)
        ' Crear una lista para almacenar los elementos actuales de la ListView
        Dim listProductos As New List(Of ListViewItem)()

        ' Guardar los elementos actuales de la ListView
        For Each item As ListViewItem In listView.Items
            listProductos.Add(item)
        Next

        ' Limpiar el ListView
        listView.Items.Clear()

        ' Filtrar los productos en función del texto de búsqueda
        Dim productosFiltrados As List(Of Producto) = FiltrarProductos(listProductos, textoBusqueda)

        ' Mostrar los productos filtrados en el ListView
        For Each producto As Producto In productosFiltrados
            Dim item As New ListViewItem(producto.ID.ToString())
            item.SubItems.Add(producto.Nombre)
            item.SubItems.Add(producto.Precio)
            item.SubItems.Add(producto.Categoria)

            listView.Items.Add(item)
        Next
    End Sub

    Private Function FiltrarProductos(listProductos As List(Of ListViewItem), textoBusqueda As String) As List(Of Producto)
        ' Crear una lista para almacenar los producto filtrados
        Dim productosFiltrados As New List(Of Producto)()

        ' Filtrar los elementos de la ListView basándose en la columna "Nombre"
        For Each item As ListViewItem In listProductos
            ' Obtener los valores de las columnas para el producto actual
            Dim productoID As Integer = Integer.Parse(item.SubItems(0).Text)
            Dim productoNombre As String = item.SubItems(1).Text
            Dim precio As Decimal = item.SubItems(2).Text
            Dim Categoria As String = item.SubItems(3).Text

            ' Verificar si el texto de búsqueda está contenido en el nombre del producto
            If productoNombre.ToLower().Contains(textoBusqueda.ToLower()) Then
                ' Crear un objeto Producto y agregarlo a la lista de productos filtrados
                Dim producto As New Producto()
                producto.ID = productoID
                producto.Nombre = productoNombre
                producto.Precio = precio
                producto.Categoria = Categoria
                productosFiltrados.Add(producto)
            End If
        Next

        Return productosFiltrados
    End Function

    Public Shared Function ObtenerNombreProductoPorId(ByVal idProducto As Integer) As String
        Dim nombreProducto As String = ""
        Dim query As String = "SELECT Nombre FROM productos WHERE ID = @ID"

        Using connection As SqlConnection = GestorConexion.ObtenerConexion()
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", idProducto)

                Try
                    connection.Open()
                    nombreProducto = Convert.ToString(command.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error al obtener el nombre del producto: " & ex.Message)
                End Try
            End Using
        End Using

        Return nombreProducto
    End Function

    Public Shared Function ObtenerCategoriaProductoPorId(ByVal idProducto As Integer) As String
        Dim categoriaProducto As String = ""
        Dim query As String = "SELECT Categoria FROM productos WHERE ID = @ID"

        Using connection As SqlConnection = GestorConexion.ObtenerConexion()
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ID", idProducto)

                Try
                    connection.Open()
                    categoriaProducto = Convert.ToString(command.ExecuteScalar())
                Catch ex As Exception
                    Console.WriteLine("Error al obtener la categoria del producto: " & ex.Message)
                End Try
            End Using
        End Using

        Return categoriaProducto
    End Function

    Public Shared Function CargarProductos(Optional categoria As String = Nothing) As List(Of Producto)
        Dim productos As New List(Of Producto)()

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            ' Consulta SQL base para obtener todos los productos
            Dim query As String = "SELECT ID, Nombre, Precio, Categoria FROM Productos"

            ' Si se especifica una categoría, filtrar por esa categoría
            If Not String.IsNullOrEmpty(categoria) Then
                query &= " WHERE Categoria = @Categoria"
            End If

            Using comando As SqlCommand = New SqlCommand(query, conexion)
                ' Si se especifica una categoría, agregar el parámetro correspondiente
                If Not String.IsNullOrEmpty(categoria) Then
                    comando.Parameters.AddWithValue("@Categoria", categoria)
                End If

                conexion.Open()
                Using reader As SqlDataReader = comando.ExecuteReader()
                    While reader.Read()
                        ' Crear un nuevo objeto Producto y asignar sus propiedades
                        Dim producto As New Producto()
                        producto.ID = reader.GetInt32(0)
                        producto.Nombre = reader.GetString(1)
                        producto.Precio = Convert.ToDecimal(reader.GetDouble(2))
                        producto.Categoria = reader.GetString(3)

                        ' Agregar el producto a la lista
                        productos.Add(producto)
                    End While
                End Using
            End Using
        End Using

        Return productos
    End Function

    Public Shared Sub CargarComboCategorias(comboBox As ComboBox)
        comboBox.Items.Clear()

        Try
            Using conexion As SqlConnection = GestorConexion.ObtenerConexion()                '
                Dim query As String = "SELECT DISTINCT Categoria FROM Productos"

                Using comando As New SqlCommand(query, conexion)
                    conexion.Open()
                    Using reader As SqlDataReader = comando.ExecuteReader()
                        ' Leer los resultados y agregar cada categoría al ComboBox
                        While reader.Read()
                            comboBox.Items.Add(reader("Categoria").ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar las categorías: " & ex.Message)
        End Try
    End Sub

    Public Overrides Function ToString() As String
        Return Nombre
    End Function

End Class

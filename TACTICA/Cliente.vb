Imports System.Data.SqlClient

Public Class Cliente
    Public Property ID As Integer
    Public Property Cliente As String
    Public Property Telefono As String
    Public Property Correo As String

    ' Constructor vacío
    Public Sub New()
    End Sub

    ' Constructor con parámetros
    Public Sub New(ByVal id As Integer, ByVal cliente As String, ByVal telefono As String, ByVal correo As String)
        Me.ID = id
        Me.Cliente = cliente
        Me.Telefono = telefono
        Me.Correo = correo
    End Sub

    Public Sub GuardarCliente()
        Dim query As String = "INSERT INTO clientes (Cliente, Telefono, Correo) VALUES (@Cliente, @Telefono, @Correo)"

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@Cliente", Cliente)
                comando.Parameters.AddWithValue("@Telefono", Telefono)
                comando.Parameters.AddWithValue("@Correo", Correo)

                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    Console.WriteLine("Cliente guardado en la base de datos.")
                Catch ex As Exception
                    Console.WriteLine("Error al guardar el cliente en la base de datos: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub CargarClientesEnListView(listView As ListView)

        Dim query As String = "SELECT ID, Cliente, Telefono, Correo FROM Clientes"

        ' Establecer la conexión a la base de datos y ejecutar la consulta
        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                conexion.Open()
                Dim reader As SqlDataReader = comando.ExecuteReader()

                ' Limpiar el ListView antes de agregar nuevos elementos
                listView.Items.Clear()

                ' Leer los datos de los clientes y agregarlos al ListView
                While reader.Read()
                    Dim id As Integer = reader("ID")
                    Dim cliente As String = reader("Cliente").ToString()
                    Dim telefono As String = reader("Telefono").ToString()
                    Dim correo As String = reader("Correo").ToString()

                    ' Crear un nuevo ListViewItem para el cliente actual
                    Dim item As New ListViewItem(id.ToString()) ' Agregar el ID como primer subítem
                    item.SubItems.Add(cliente)
                    item.SubItems.Add(telefono)
                    item.SubItems.Add(correo)

                    ' Establecer el Tag del ListViewItem con el ID del cliente
                    item.Tag = id

                    ' Agregar el ListViewItem al ListView
                    listView.Items.Add(item)
                End While

                reader.Close()
            End Using
        End Using

    End Sub

    Public Sub ModificarCliente()

        Dim query As String = "UPDATE clientes SET Cliente = @Cliente, Telefono = @Telefono, Correo = @Correo where ID = @ID"

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@ID", ID)
                comando.Parameters.AddWithValue("@Cliente", Cliente)
                comando.Parameters.AddWithValue("@Telefono", Telefono)
                comando.Parameters.AddWithValue("@Correo", Correo)

                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    Console.WriteLine("Cliente modificado en la base de datos.")
                Catch ex As Exception
                    Console.WriteLine("Error al modificar el cliente en la base de datos: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub EliminarCliente()

        Dim query As String = "DELETE clientes where ID = @ID"

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            Using comando As New SqlCommand(query, conexion)
                comando.Parameters.AddWithValue("@ID", ID)

                Try
                    conexion.Open()
                    comando.ExecuteNonQuery()
                    Console.WriteLine("Cliente eliminado en la base de datos.")
                Catch ex As Exception
                    Console.WriteLine("Error al eliminar el cliente en la base de datos: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub FiltrarClientesEnListView(listView As ListView, textoBusqueda As String)
        ' Crear una lista para almacenar los elementos actuales de la ListView
        Dim listClientes As New List(Of ListViewItem)()

        ' Guardar los elementos actuales de la ListView
        For Each item As ListViewItem In listView.Items
            listClientes.Add(item)
        Next

        ' Limpiar el ListView
        listView.Items.Clear()

        ' Filtrar los clientes en función del texto de búsqueda
        Dim clientesFiltrados As List(Of Cliente) = FiltrarClientes(listClientes, textoBusqueda)

        ' Mostrar los clientes filtrados en el ListView
        For Each cliente As Cliente In clientesFiltrados
            Dim item As New ListViewItem(cliente.ID.ToString())
            item.SubItems.Add(cliente.Cliente)
            item.SubItems.Add(cliente.Telefono)
            item.SubItems.Add(cliente.Correo)

            listView.Items.Add(item)
        Next
    End Sub

    Private Function FiltrarClientes(listClientes As List(Of ListViewItem), textoBusqueda As String) As List(Of Cliente)
        ' Crear una lista para almacenar los clientes filtrados
        Dim clientesFiltrados As New List(Of Cliente)()

        ' Filtrar los elementos de la ListView basándose en la columna "Cliente"
        For Each item As ListViewItem In listClientes
            ' Obtener los valores de las columnas para el cliente actual
            Dim clienteID As Integer = Integer.Parse(item.SubItems(0).Text)
            Dim clienteNombre As String = item.SubItems(1).Text
            Dim telefono As String = item.SubItems(2).Text
            Dim correo As String = item.SubItems(3).Text

            ' Verificar si el texto de búsqueda está contenido en el nombre del cliente
            If clienteNombre.ToLower().Contains(textoBusqueda.ToLower()) Then
                ' Crear un objeto Cliente y agregarlo a la lista de clientes filtrados
                Dim cliente As New Cliente()
                cliente.ID = clienteID
                cliente.Cliente = clienteNombre
                cliente.Telefono = telefono
                cliente.Correo = correo
                clientesFiltrados.Add(cliente)
            End If
        Next

        Return clientesFiltrados
    End Function
    Public Shared Function CargarComboClientes() As List(Of Cliente)
        Dim listaClientes As New List(Of Cliente)()

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            conexion.Open()
            Dim query As String = "SELECT ID, Cliente, Telefono, Correo FROM Clientes"
            Using comando As New SqlCommand(query, conexion)
                Using reader As SqlDataReader = comando.ExecuteReader()
                    While reader.Read()
                        Dim cliente As New Cliente()
                        cliente.ID = Convert.ToInt32(reader("ID"))
                        cliente.Cliente = reader("Cliente").ToString()
                        cliente.Telefono = reader("Telefono").ToString()
                        cliente.Correo = reader("Correo").ToString()
                        listaClientes.Add(cliente)
                    End While
                End Using
            End Using
        End Using

        Return listaClientes
    End Function

    Public Shared Function ObtenerNombreClientePorID(ByVal idCliente As Integer) As String
        Dim nombreCliente As String = ""

        Using conexion As SqlConnection = GestorConexion.ObtenerConexion()
            conexion.Open()

            Dim consulta As String = "SELECT Cliente FROM clientes WHERE ID = @ID"
            Using comando As New SqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@ID", idCliente)

                Dim resultado As Object = comando.ExecuteScalar()

                ' Verificar si se encontró un cliente con el ID proporcionado
                If resultado IsNot DBNull.Value AndAlso resultado IsNot Nothing Then
                    nombreCliente = resultado.ToString()
                End If
            End Using
        End Using

        Return nombreCliente
    End Function

End Class

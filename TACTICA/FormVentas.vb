Public Class FormVentas
    Public Property IdVenta As Integer
    Public Property ClienteSeleccionadoID As Integer

    Private Sub FormVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Iniciar()
    End Sub

    Private Sub Iniciar()
        ' Establece los controles y sus propiedades para iniciar
        cbClientes.DisplayMember = "Cliente"
        EstablecerControlesPredeterminados()
        If Me.IdVenta <> 0 Then
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub EstablecerControlesPredeterminados()
        ' Carga controles y sus propiedades
        Producto.CargarComboCategorias(cbCategoria)
        CargarComboClientes()
        For Each cliente As Cliente In cbClientes.Items
            If cliente.ID = ClienteSeleccionadoID Then
                cbClientes.SelectedItem = cliente
                Exit For
            End If
        Next
        cbProductos.Enabled = False
        btnEliminar.Enabled = False
        btnAgregarProducto.Enabled = False
        btnGuardar.Enabled = False
        txtCantidad.Text = "1"
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        ' Verificar si hay elementos seleccionados en la ListView
        If listViewVentas.SelectedItems.Count > 0 Then
            ' Eliminar el elemento seleccionado de la ListView
            listViewVentas.SelectedItems(0).Remove()

            ' Verificar si la ListView está vacía después de eliminar el elemento
            If listViewVentas.Items.Count = 0 Then
                ' Si la ListView está vacía, bloquear el botón btnGuardar
                btnGuardar.Enabled = False
            End If

            ActualizarTotal()
        End If
    End Sub
    Private Sub btnAgregarProducto_Click(sender As Object, e As EventArgs) Handles btnAgregarProducto.Click
        ' Agrega el item de venta a la ListView y limpia controles
        AgregarVenta()
        ActualizarTotal()
        LimpiarControlesVenta()
        btnGuardar.Enabled = True
    End Sub

    Private Sub ObtenerPrecioProducto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged
        ' Obtener el producto seleccionado
        Dim productoSeleccionado As Producto = DirectCast(cbProductos.SelectedItem, Producto)

        ' Cargar precio unitario del producto en lblPrecio
        If productoSeleccionado IsNot Nothing Then
            lblPrecio.Text = productoSeleccionado.Precio.ToString()
        End If
    End Sub

    Private Function ObtenerProductoSeleccionado() As Producto
        ' Obtener el producto seleccionado del ComboBox
        Dim productoSeleccionado As Producto = DirectCast(cbProductos.SelectedItem, Producto)

        Return productoSeleccionado
    End Function

    Private Sub txtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidad.KeyPress
        ' Permitir solo números y la tecla de retroceso
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub cbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProductos.SelectedIndexChanged
        ' Si selecciona un producto habilita boton para agregar el item
        btnAgregarProducto.Enabled = True
        CalcularSubtotal()
    End Sub

    Private Sub txtCantidad_TextChanged(sender As Object, e As EventArgs) Handles txtCantidad.TextChanged
        ' Verificar si el TextBox está vacío o no contiene un valor numérico válido y establece su valor en 1 por defecto
        If String.IsNullOrEmpty(txtCantidad.Text) OrElse Not IsNumeric(txtCantidad.Text) Then
            txtCantidad.Text = "1"
        Else
            Dim cantidad As Integer
            If Integer.TryParse(txtCantidad.Text, cantidad) Then
                If cantidad <= 0 Then
                    txtCantidad.Text = "1"
                End If
            Else
                txtCantidad.Text = "1"
            End If
        End If
        ' Actualiza subtotal del item de venta
        CalcularSubtotal()
    End Sub
    Private Sub CalcularSubtotal()
        ' Obtener el producto seleccionado del ComboBox
        Dim productoSeleccionado As Producto = DirectCast(cbProductos.SelectedItem, Producto)

        ' Verificar si se seleccionó un producto
        If productoSeleccionado IsNot Nothing Then
            Dim precio As Decimal = productoSeleccionado.Precio
            Dim cantidad As Integer

            ' Verificar si el valor del TextBox es un entero válido
            If String.IsNullOrEmpty(txtCantidad.Text) OrElse Not Integer.TryParse(txtCantidad.Text, cantidad) OrElse cantidad <= 0 Then
                ' Si el valor del TextBox está vacío, no es un número válido o es menor o igual a cero, establecer la cantidad en 1
                cantidad = 1
                txtCantidad.Text = "1"
            End If

            ' Calcular el subtotal
            Dim subtotal As Decimal = precio * cantidad

            ' Mostrar el subtotal en el Label
            lblSubtotalPrecio.Text = subtotal.ToString()
        End If
    End Sub

    Private Sub CargarComboProductos(Optional ByVal categoria As String = Nothing)
        ' Obtener la lista de productos según la categoría especificada
        Dim listaProductos As List(Of Producto) = Producto.CargarProductos(categoria)

        cbProductos.Items.Clear()

        For Each producto As Producto In listaProductos
            cbProductos.Items.Add(producto)
        Next
    End Sub

    Private Sub cbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCategoria.SelectedIndexChanged
        ' Verificar si hay un elemento seleccionado en el ComboBox
        If cbCategoria.SelectedItem IsNot Nothing Then
            ' Obtener la categoría seleccionada
            Dim categoriaSeleccionada As String = cbCategoria.SelectedItem.ToString()

            ' Llamar al método para cargar los productos según la categoría seleccionada
            CargarComboProductos(categoriaSeleccionada)
            cbProductos.Enabled = True
        End If
    End Sub

    Private Sub AgregarVenta()
        ' Obtener los datos de los controles
        Dim productoSeleccionado As Producto = DirectCast(cbProductos.SelectedItem, Producto)
        Dim idProducto As Integer = productoSeleccionado.ID
        Dim nombreProducto As String = productoSeleccionado.Nombre
        Dim categoria As String = cbCategoria.SelectedItem.ToString()
        Dim precioUnitario As Decimal = Decimal.Parse(lblPrecio.Text)
        Dim cantidad As Integer = Integer.Parse(txtCantidad.Text)
        Dim subtotal As Decimal = Decimal.Parse(lblSubtotalPrecio.Text)

        ' Crear un nuevo ListViewItem con los datos
        Dim item As New ListViewItem(idProducto.ToString())
        item.Tag = idProducto ' Establecer el Tag con el ID del producto
        item.SubItems.Add(nombreProducto)
        item.SubItems.Add(categoria)
        item.SubItems.Add(precioUnitario.ToString())
        item.SubItems.Add(cantidad.ToString())
        item.SubItems.Add(subtotal.ToString())

        ' Agregar el nuevo item a la ListView de ventas
        listViewVentas.Items.Add(item)
    End Sub


    Private Sub LimpiarControlesVenta()
        cbProductos.Enabled = False
        cbCategoria.SelectedIndex = -1
        cbProductos.SelectedIndex = -1
        lblPrecio.Text = "0"
        txtCantidad.Text = ""
        lblSubtotalPrecio.Text = "0"
        btnAgregarProducto.Enabled = False

    End Sub

    Private Sub listViewVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewVentas.SelectedIndexChanged
        If listViewVentas.SelectedItems.Count > 0 Then
            btnEliminar.Enabled = True
        Else
            btnEliminar.Enabled = False
        End If
    End Sub

    Private Sub ActualizarTotal()
        Dim total As Decimal = 0

        For Each item As ListViewItem In listViewVentas.Items
            ' Obtener el subtotal del elemento y sumarlo al total
            total += Decimal.Parse(item.SubItems(5).Text)
        Next

        lblTotalPrecio.Text = total.ToString()
    End Sub

    Private Sub CargarComboClientes()
        Dim listaClientes As List(Of Cliente) = Cliente.CargarComboClientes()

        cbClientes.Items.Clear()

        For Each cliente As Cliente In listaClientes
            cbClientes.Items.Add(cliente)
        Next
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If cbClientes.SelectedItem Is Nothing Then
            MessageBox.Show("Por favor, seleccione un cliente antes de guardar la venta.", "Cliente no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return ' Salir del evento sin guardar la venta
        End If

        Dim itemsVenta As New List(Of ItemVenta)

        For Each item As ListViewItem In listViewVentas.Items
            Dim idProducto As Integer = Integer.Parse(item.SubItems(0).Text)
            Dim categoria As String = item.SubItems(2).Text
            Dim precioUnitario As Decimal = Decimal.Parse(item.SubItems(3).Text)
            Dim cantidad As Integer = Integer.Parse(item.SubItems(4).Text)
            Dim subtotal As Decimal = Decimal.Parse(item.SubItems(5).Text)

            ' Crear un objeto ItemVenta con los datos
            Dim itemVenta As New ItemVenta()
            itemVenta.Producto.ID = idProducto
            itemVenta.Producto.Categoria = categoria
            itemVenta.Producto.Precio = precioUnitario
            itemVenta.Cantidad = cantidad
            itemVenta.Subtotal = subtotal

            ' Agregar el item de venta a la lista
            itemsVenta.Add(itemVenta)
        Next

        Dim venta As New Venta()
        venta.IDCliente = ObtenerIDClienteSeleccionado()
        venta.Fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        venta.Total = itemsVenta.Sum(Function(i) i.Subtotal) ' Calcular el total sumando los subtotales de los items de venta

        ' Guardar nueva venta en la base de datos
        If Me.IdVenta <> 0 Then
            venta.ModificarVenta(Me.IdVenta, itemsVenta)
        Else
            venta.GuardarVenta(itemsVenta)
        End If

        LimpiarControlesVenta()
        cbClientes.SelectedIndex = -1
        lblTotalPrecio.Text = "0"
        listViewVentas.Items.Clear()
        MessageBox.Show("Venta guardada correctamente.")
    End Sub
    Private Function ObtenerIDClienteSeleccionado() As Integer
        Dim clienteSeleccionado As Cliente = DirectCast(cbClientes.SelectedItem, Cliente)

        Return clienteSeleccionado.ID
    End Function

End Class
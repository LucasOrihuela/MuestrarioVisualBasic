Public Class FormProductos
    Private productos As List(Of Producto)
    Private productosFiltrados As List(Of Producto)
    Private Sub listBoxProductos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llama al método para cargar los datos en el ListBox (listProductos) cuando el formulario se carga
        Dim producto As New Producto()
        producto.CargarProductosEnListView(listProductos)

        ' Verificar si hay ítems seleccionados en el ListView
        VerificarSeleccion()
    End Sub

    Private Sub FormProductos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Limpiar la selección de elementos al cerrar el formulario
        listProductos.SelectedItems.Clear()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        FormAgregarProducto.ShowDialog()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim producto As New Producto()

        ' Obtener el primer ítem seleccionado
        Dim itemSeleccionado As ListViewItem = listProductos.SelectedItems(0)

        ' Obtener la información del ítem seleccionado
        producto.ID = CInt(itemSeleccionado.Text)
        producto.Nombre = itemSeleccionado.SubItems(1).Text
        producto.Precio = itemSeleccionado.SubItems(2).Text
        producto.Categoria = itemSeleccionado.SubItems(3).Text

        Dim formularioModificar As New FormModificarProducto(producto)
        formularioModificar.ShowDialog()
        VerificarSeleccion()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim producto As New Producto()
        ' Obtener el primer ítem seleccionado
        Dim itemSeleccionado As ListViewItem = listProductos.SelectedItems(0)

        ' Obtener la información del ítem seleccionado
        producto.ID = CInt(itemSeleccionado.Text)
        producto.EliminarProducto()
        producto.CargarProductosEnListView(listProductos)
        VerificarSeleccion()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim producto As New Producto()
        ' Filtrar la lista de productos en función del texto de búsqueda
        Dim textoBusqueda As String = txtBuscar.Text.ToLower()

        If String.IsNullOrEmpty(textoBusqueda) Then
            ' Si no hay texto de búsqueda, mostrar todos los productos
            producto.CargarProductosEnListView(listProductos)
        Else
            ' Filtrar los productos que coinciden con el texto de búsqueda y mostrarlos
            producto.FiltrarProductosEnListView(listProductos, textoBusqueda)
        End If

        ' Verificar si hay ítems seleccionados
        VerificarSeleccion()
    End Sub

    Private Sub FormProductos_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ' Actualizar la información del listBox cuando se activa el formulario
        Dim producto As New Producto()
        producto.CargarProductosEnListView(listProductos)
    End Sub

    Private Sub listView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listProductos.SelectedIndexChanged
        ' Verificar si hay ítems seleccionados en el ListView
        VerificarSeleccion()
    End Sub

    Private Sub VerificarSeleccion()
        ' Verificar si hay ítems seleccionados en el ListView
        If listProductos.SelectedItems.Count > 0 Then
            ' Hay ítems seleccionados, habilitar los botones
            btnEliminar.Enabled = True
            btnModificar.Enabled = True
        Else
            ' No hay ítems seleccionados, deshabilitar los botones
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
        End If
    End Sub
End Class
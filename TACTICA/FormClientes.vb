Public Class FormClientes

    Private clientes As List(Of Cliente)
    Private clientesFiltrados As List(Of Cliente)

    Private Sub listBoxClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Llama al método para cargar los datos en el ListBox (listClientes) cuando el formulario se carga
        Dim cliente As New Cliente()
        cliente.CargarClientesEnListView(listClientes)

        ' Verificar si hay ítems seleccionados en el ListView
        VerificarSeleccion()
    End Sub

    Private Sub FormClientes_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' Limpiar la selección de elementos al cerrar el formulario
        listClientes.SelectedItems.Clear()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        FormAgregarCliente.ShowDialog()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim cliente As New Cliente()

        ' Obtener el primer ítem seleccionado
        Dim itemSeleccionado As ListViewItem = listClientes.SelectedItems(0)

        ' Obtener la información del ítem seleccionado
        cliente.ID = CInt(itemSeleccionado.Text)
        cliente.Cliente = itemSeleccionado.SubItems(1).Text
        cliente.Telefono = itemSeleccionado.SubItems(2).Text
        cliente.Correo = itemSeleccionado.SubItems(3).Text

        Dim formularioModificar As New FormModificarCliente(cliente)
        formularioModificar.ShowDialog()
        VerificarSeleccion()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim cliente As New Cliente()
        ' Obtener el primer ítem seleccionado
        Dim itemSeleccionado As ListViewItem = listClientes.SelectedItems(0)

        ' Obtener la información del ítem seleccionado
        cliente.ID = CInt(itemSeleccionado.Text)
        cliente.EliminarCliente()
        cliente.CargarClientesEnListView(listClientes)
        VerificarSeleccion()
    End Sub

    Private Sub FormClientes_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ' Actualizar la información del listBox cuando se activa el formulario
        Dim cliente As New Cliente()
        cliente.CargarClientesEnListView(listClientes)
    End Sub
    Private Sub listView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listClientes.SelectedIndexChanged
        ' Verificar si hay ítems seleccionados en el ListView
        VerificarSeleccion()
    End Sub
    Private Sub txtBuscar_TextChanged(sender As Object, e As EventArgs) Handles txtBuscar.TextChanged
        Dim cliente As New Cliente()
        ' Filtrar la lista de clientes en función del texto de búsqueda
        Dim textoBusqueda As String = txtBuscar.Text.ToLower()

        If String.IsNullOrEmpty(textoBusqueda) Then
            ' Si no hay texto de búsqueda, mostrar todos los clientes
            Cliente.CargarClientesEnListView(listClientes)
        Else
            ' Filtrar los clientes que coinciden con el texto de búsqueda y mostrarlos
            Cliente.FiltrarClientesEnListView(listClientes, textoBusqueda)
        End If

        ' Verificar si hay ítems seleccionados
        VerificarSeleccion()
    End Sub
    Private Sub VerificarSeleccion()
        ' Verificar si hay ítems seleccionados en el ListView
        If listClientes.SelectedItems.Count > 0 Then
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
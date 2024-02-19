Public Class FormBuscadorVenta
    Private Sub FormBuscadorVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Iniciar()
    End Sub
    Private Sub Iniciar()
        dtFecha.Format = DateTimePickerFormat.Custom
        dtFecha.CustomFormat = "yyyy-MM-dd"
        cbClientes.DisplayMember = "Cliente"
        btnEliminar.Enabled = False
        btnModificar.Enabled = False
        CargarComboClientes()
        ActualizarListViewVentas()
    End Sub
    Private Sub CargarComboClientes()
        Dim listaClientes As List(Of Cliente) = Cliente.CargarComboClientes()

        cbClientes.Items.Clear()

        For Each cliente As Cliente In listaClientes
            cbClientes.Items.Add(cliente)
        Next
    End Sub

    Private Sub ActualizarListViewVentas()
        ' Obtener todas las ventas al cargar el formulario
        Dim ventas As List(Of Venta) = Venta.ObtenerVentas(Nothing, Nothing, Nothing)

        listViewVentas.Items.Clear()

        ' Agregar las ventas obtenidas a la ListView
        For Each venta As Venta In ventas
            Dim clienteNombre As String = Cliente.ObtenerNombreClientePorID(venta.IDCliente) ' Obtener el nombre del cliente por ID
            Dim item As New ListViewItem(venta.ID.ToString())
            item.SubItems.Add(clienteNombre)
            Dim fechaFormateada As String = DateTime.Parse(venta.Fecha).ToString("yyyy-MM-dd")
            item.SubItems.Add(fechaFormateada)
            item.SubItems.Add(venta.Total.ToString())
            listViewVentas.Items.Add(item)
        Next
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        ' Capturar los valores de los controles de filtro
        Dim idCliente As Integer? = If(cbClientes.SelectedIndex <> -1, DirectCast(cbClientes.SelectedItem, Cliente).ID, Nothing)
        Dim fecha As Date? = If(dtFecha.Value <> DateTime.MinValue, dtFecha.Value.Date, Nothing)
        Dim total As Decimal? = Nothing

        If Not String.IsNullOrWhiteSpace(txtTotal.Text) Then
            ' Si tiene un valor, intenta convertirlo a decimal
            Dim parsedTotal As Decimal
            If Decimal.TryParse(txtTotal.Text, parsedTotal) Then
                total = parsedTotal
            Else
                ' Si no se puede convertir, muestra un mensaje de error o toma otra acción apropiada
                MessageBox.Show("El valor en el campo Total no es válido. Por favor, ingrese un número válido.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Sale del método sin continuar
            End If
        End If

        ' Obtener las ventas con los filtros aplicados
        Dim ventas As List(Of Venta) = Venta.ObtenerVentas(idCliente, fecha, total)
        MostrarVentasEnListView(ventas)
    End Sub

    Private Sub MostrarVentasEnListView(ByVal ventas As List(Of Venta))
        listViewVentas.Items.Clear()

        ' Agregar las ventas obtenidas a la ListView
        For Each venta As Venta In ventas
            Dim clienteNombre As String = Cliente.ObtenerNombreClientePorID(venta.IDCliente) ' Obtener el nombre del cliente por ID
            Dim item As New ListViewItem(venta.ID.ToString()) ' Añadir el ID como primer subitem
            item.SubItems.Add(clienteNombre)
            Dim fechaFormateada As String = venta.Fecha.ToString("yyyy-MM-dd") ' Formatear la fecha
            item.SubItems.Add(fechaFormateada)
            item.SubItems.Add(venta.Total.ToString())
            listViewVentas.Items.Add(item)
        Next
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim IdVenta As Integer
        Dim venta As New Venta
        If Integer.TryParse(listViewVentas.SelectedItems(0).SubItems(0).Text, IdVenta) Then
            venta.EliminarVenta(IdVenta)
            listViewVentas.SelectedItems(0).Remove()
        End If
    End Sub

    Private Sub txtTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotal.KeyPress
        ' Permitir solo números, punto decimal y teclas de control
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Bloquear el carácter ingresado
        End If

        ' Permitir solo un punto decimal
        If e.KeyChar = "." AndAlso txtTotal.Text.Contains(".") Then
            e.Handled = True ' Bloquear el carácter ingresado si ya hay un punto decimal
        End If
    End Sub
    Private Sub listViewVentas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listViewVentas.SelectedIndexChanged
        If listViewVentas.SelectedItems.Count > 0 Then
            btnEliminar.Enabled = True
            btnModificar.Enabled = True
        Else
            btnEliminar.Enabled = False
            btnModificar.Enabled = False
        End If
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Dim formVentas As New FormVentas()
        Dim IdVenta As Integer
        If Integer.TryParse(listViewVentas.SelectedItems(0).SubItems(0).Text, IdVenta) Then
            Venta.CargarVenta(IdVenta, formVentas)
            formVentas.ShowDialog()
        End If
    End Sub
End Class
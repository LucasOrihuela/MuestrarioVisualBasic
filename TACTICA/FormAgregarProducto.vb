Public Class FormAgregarProducto
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim producto As New Producto()

        'Obtengo los datos del producto
        producto.Nombre = txtNombre.Text
        producto.Precio = txtPrecio.Text
        producto.Categoria = txtCategoria.Text

        'Guardo en base de datos
        producto.GuardarProducto()
        LimpiarControlesVenta()
        Me.Close()

    End Sub
    Private Sub LimpiarControlesVenta()
        ' Deshabilitar los controles
        txtNombre.Text = ""
        txtPrecio.Text = ""
        txtCategoria.Text = ""
    End Sub

    Private Sub txtPrecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrecio.KeyPress
        ' Verifica si la tecla presionada es un número o la tecla de retroceso
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            ' Si la tecla no es un número y no es la tecla de retroceso, cancela la entrada
            e.Handled = True
        End If
    End Sub
End Class
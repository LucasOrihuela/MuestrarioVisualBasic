Public Class FormHome
    Private Sub BntVentas_Click(sender As Object, e As EventArgs) Handles btnVentas.Click
        FormRedireccionadorVentas.ShowDialog()
    End Sub

    Private Sub BtnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        FormClientes.ShowDialog()
    End Sub

    Private Sub BtnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        FormProductos.ShowDialog()
    End Sub

End Class

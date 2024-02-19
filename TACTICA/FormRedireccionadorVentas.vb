Public Class FormRedireccionadorVentas
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        FormVentas.ShowDialog()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        FormBuscadorVenta.ShowDialog()
    End Sub
End Class
Imports System.Text.RegularExpressions

Public Class FormAgregarCliente
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim utilidades As New Utilidades()
        Dim cliente As New Cliente()
        Dim resultado As Integer = utilidades.ValidarEmail(txtCorreo.Text)

        'Valido email
        If resultado = 1 Then
            'Obtengo los datos del cliente
            cliente.Cliente = txtCliente.Text
            cliente.Telefono = txtTelefono.Text
            cliente.Correo = txtCorreo.Text

            'Guardo en base de datos
            cliente.GuardarCliente()
            LimpiarControlesVenta()
            Me.Close()
        Else
            MessageBox.Show("El email no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub LimpiarControlesVenta()
        ' Deshabilitar los controles
        txtCliente.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
    End Sub
    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        ' Verifica si la tecla presionada es un número o la tecla de retroceso
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            ' Si la tecla no es un número y no es la tecla de retroceso, cancela la entrada
            e.Handled = True
        End If
    End Sub


End Class
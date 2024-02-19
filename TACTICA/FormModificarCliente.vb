Public Class FormModificarCliente

    Private _cliente As Cliente

    Public Sub New(cliente As Cliente)
        ' Constructor que acepta un objeto Cliente como parámetro
        InitializeComponent()

        ' Almacena el objeto Cliente en la propiedad
        _cliente = cliente
    End Sub

    Private Sub FormModificarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verificar si el objeto Cliente no es nulo
        If _cliente IsNot Nothing Then
            ' Utilizar la información del objeto Cliente para rellenar los TextBox
            txtCliente.Text = _cliente.Cliente
            txtTelefono.Text = _cliente.Telefono
            txtCorreo.Text = _cliente.Correo
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim utilidades As New Utilidades()
        Dim cliente As New Cliente()
        Dim resultado As Integer = utilidades.ValidarEmail(txtCorreo.Text)

        'Valido email
        If resultado = 1 Then
            'Obtengo los datos del cliente
            cliente.ID = _cliente.ID
            cliente.Cliente = txtCliente.Text
            cliente.Telefono = txtTelefono.Text
            cliente.Correo = txtCorreo.Text

            'Guardo en base de datos
            cliente.ModificarCliente()
            LimpiarControles()
            Me.Close()
        Else
            MessageBox.Show("El email no es válido.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub txtTelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelefono.KeyPress
        ' Verifica si la tecla presionada es un número o la tecla de retroceso
        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            ' Si la tecla no es un número y no es la tecla de retroceso, cancela la entrada
            e.Handled = True
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarControles()
        Me.Close()
    End Sub
    Private Sub LimpiarControles()
        txtCliente.Text = ""
        txtTelefono.Text = ""
        txtCorreo.Text = ""
    End Sub
End Class
Public Class FormModificarProducto
    Private _producto As Producto
    Public Sub New(producto As Producto)
        ' Constructor que acepta un objeto Producto como parámetro
        InitializeComponent()

        ' Almacena el objeto Producto en la propiedad
        _producto = producto
    End Sub

    Private Sub FormModificarCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Verificar si el objeto Cliente no es nulo
        If _producto IsNot Nothing Then
            ' Utilizar la información del objeto Cliente para rellenar los TextBox
            txtNombre.Text = _producto.Nombre
            txtPrecio.Text = _producto.Precio
            txtCategoria.Text = _producto.Categoria
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim producto As New Producto()
        producto.ID = _producto.ID
        producto.Nombre = txtNombre.Text
        producto.Precio = txtPrecio.Text
        producto.Categoria = txtCategoria.Text

        'Guardo en base de datos
        producto.ModificarProducto()
        LimpiarControles()
        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        LimpiarControles()
        Me.Close()
    End Sub

    Private Sub LimpiarControles()
        txtNombre.Text = ""
        txtPrecio.Text = ""
        txtCategoria.Text = ""
    End Sub
End Class
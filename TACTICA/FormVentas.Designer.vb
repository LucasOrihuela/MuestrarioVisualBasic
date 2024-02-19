<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVentas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cbProductos = New System.Windows.Forms.ComboBox()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblPrecioUnitario = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.lblSubTotalProducto = New System.Windows.Forms.Label()
        Me.lblSubtotalPrecio = New System.Windows.Forms.Label()
        Me.listViewVentas = New System.Windows.Forms.ListView()
        Me.columnIdProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnProducto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnPrecioUnitario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCantidad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnSubtotal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAgregarProducto = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalPrecio = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.lblCategoria = New System.Windows.Forms.Label()
        Me.cbCategoria = New System.Windows.Forms.ComboBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.cbClientes = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(12, 550)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 35)
        Me.btnCancelar.TabIndex = 0
        Me.btnCancelar.Text = "CANCELAR"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'cbProductos
        '
        Me.cbProductos.FormattingEnabled = True
        Me.cbProductos.Location = New System.Drawing.Point(94, 143)
        Me.cbProductos.Name = "cbProductos"
        Me.cbProductos.Size = New System.Drawing.Size(178, 21)
        Me.cbProductos.TabIndex = 1
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.Location = New System.Drawing.Point(26, 146)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(62, 16)
        Me.lblProducto.TabIndex = 2
        Me.lblProducto.Text = "Producto"
        '
        'lblPrecioUnitario
        '
        Me.lblPrecioUnitario.AutoSize = True
        Me.lblPrecioUnitario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecioUnitario.Location = New System.Drawing.Point(302, 146)
        Me.lblPrecioUnitario.Name = "lblPrecioUnitario"
        Me.lblPrecioUnitario.Size = New System.Drawing.Size(112, 16)
        Me.lblPrecioUnitario.TabIndex = 3
        Me.lblPrecioUnitario.Text = "Precio Unitario : $"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(625, 144)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(67, 20)
        Me.txtCantidad.TabIndex = 4
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.Location = New System.Drawing.Point(416, 146)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(16, 16)
        Me.lblPrecio.TabIndex = 5
        Me.lblPrecio.Text = "0"
        '
        'lblCantidad
        '
        Me.lblCantidad.AutoSize = True
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.Location = New System.Drawing.Point(555, 146)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(68, 16)
        Me.lblCantidad.TabIndex = 6
        Me.lblCantidad.Text = "Cantidad :"
        '
        'lblSubTotalProducto
        '
        Me.lblSubTotalProducto.AutoSize = True
        Me.lblSubTotalProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubTotalProducto.Location = New System.Drawing.Point(762, 146)
        Me.lblSubTotalProducto.Name = "lblSubTotalProducto"
        Me.lblSubTotalProducto.Size = New System.Drawing.Size(73, 16)
        Me.lblSubTotalProducto.TabIndex = 7
        Me.lblSubTotalProducto.Text = "Subtotal : $"
        '
        'lblSubtotalPrecio
        '
        Me.lblSubtotalPrecio.AutoSize = True
        Me.lblSubtotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtotalPrecio.Location = New System.Drawing.Point(832, 146)
        Me.lblSubtotalPrecio.Name = "lblSubtotalPrecio"
        Me.lblSubtotalPrecio.Size = New System.Drawing.Size(16, 16)
        Me.lblSubtotalPrecio.TabIndex = 8
        Me.lblSubtotalPrecio.Text = "0"
        '
        'listViewVentas
        '
        Me.listViewVentas.AutoArrange = False
        Me.listViewVentas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnIdProducto, Me.columnProducto, Me.columnCategoria, Me.columnPrecioUnitario, Me.columnCantidad, Me.columnSubtotal})
        Me.listViewVentas.FullRowSelect = True
        Me.listViewVentas.HideSelection = False
        Me.listViewVentas.Location = New System.Drawing.Point(12, 205)
        Me.listViewVentas.MultiSelect = False
        Me.listViewVentas.Name = "listViewVentas"
        Me.listViewVentas.Size = New System.Drawing.Size(915, 229)
        Me.listViewVentas.TabIndex = 9
        Me.listViewVentas.UseCompatibleStateImageBehavior = False
        Me.listViewVentas.View = System.Windows.Forms.View.Details
        '
        'columnIdProducto
        '
        Me.columnIdProducto.Text = "ID Producto"
        Me.columnIdProducto.Width = 69
        '
        'columnProducto
        '
        Me.columnProducto.Text = "Producto"
        Me.columnProducto.Width = 152
        '
        'columnCategoria
        '
        Me.columnCategoria.Text = "Categoria"
        Me.columnCategoria.Width = 167
        '
        'columnPrecioUnitario
        '
        Me.columnPrecioUnitario.Text = "Precio Unitario"
        Me.columnPrecioUnitario.Width = 106
        '
        'columnCantidad
        '
        Me.columnCantidad.Text = "Cantidad"
        Me.columnCantidad.Width = 110
        '
        'columnSubtotal
        '
        Me.columnSubtotal.Text = "Subtotal"
        Me.columnSubtotal.Width = 191
        '
        'btnAgregarProducto
        '
        Me.btnAgregarProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarProducto.Location = New System.Drawing.Point(936, 143)
        Me.btnAgregarProducto.Name = "btnAgregarProducto"
        Me.btnAgregarProducto.Size = New System.Drawing.Size(100, 25)
        Me.btnAgregarProducto.TabIndex = 10
        Me.btnAgregarProducto.Text = "Agregar item"
        Me.btnAgregarProducto.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(758, 456)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(84, 18)
        Me.lblTotal.TabIndex = 11
        Me.lblTotal.Text = "TOTAL : $"
        '
        'lblTotalPrecio
        '
        Me.lblTotalPrecio.AutoSize = True
        Me.lblTotalPrecio.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalPrecio.Location = New System.Drawing.Point(844, 456)
        Me.lblTotalPrecio.Name = "lblTotalPrecio"
        Me.lblTotalPrecio.Size = New System.Drawing.Size(17, 18)
        Me.lblTotalPrecio.TabIndex = 12
        Me.lblTotalPrecio.Text = "0"
        '
        'btnEliminar
        '
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ForeColor = System.Drawing.Color.Red
        Me.btnEliminar.Location = New System.Drawing.Point(936, 205)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(100, 25)
        Me.btnEliminar.TabIndex = 14
        Me.btnEliminar.Text = "Eliminar item"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Location = New System.Drawing.Point(936, 550)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(113, 35)
        Me.btnGuardar.TabIndex = 15
        Me.btnGuardar.Text = "GUARDAR"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(403, 21)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(262, 31)
        Me.lblTitulo.TabIndex = 16
        Me.lblTitulo.Text = "VENTAS TACTICA"
        '
        'lblCategoria
        '
        Me.lblCategoria.AutoSize = True
        Me.lblCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategoria.Location = New System.Drawing.Point(26, 109)
        Me.lblCategoria.Name = "lblCategoria"
        Me.lblCategoria.Size = New System.Drawing.Size(67, 16)
        Me.lblCategoria.TabIndex = 18
        Me.lblCategoria.Text = "Categoria"
        '
        'cbCategoria
        '
        Me.cbCategoria.FormattingEnabled = True
        Me.cbCategoria.Location = New System.Drawing.Point(94, 106)
        Me.cbCategoria.Name = "cbCategoria"
        Me.cbCategoria.Size = New System.Drawing.Size(178, 21)
        Me.cbCategoria.TabIndex = 17
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.Location = New System.Drawing.Point(482, 458)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(49, 16)
        Me.lblCliente.TabIndex = 19
        Me.lblCliente.Text = "Cliente"
        '
        'cbClientes
        '
        Me.cbClientes.FormattingEnabled = True
        Me.cbClientes.Location = New System.Drawing.Point(537, 455)
        Me.cbClientes.Name = "cbClientes"
        Me.cbClientes.Size = New System.Drawing.Size(178, 21)
        Me.cbClientes.TabIndex = 20
        '
        'FormVentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 597)
        Me.Controls.Add(Me.cbClientes)
        Me.Controls.Add(Me.lblCliente)
        Me.Controls.Add(Me.lblCategoria)
        Me.Controls.Add(Me.cbCategoria)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.lblTotalPrecio)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.btnAgregarProducto)
        Me.Controls.Add(Me.listViewVentas)
        Me.Controls.Add(Me.lblSubtotalPrecio)
        Me.Controls.Add(Me.lblSubTotalProducto)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblPrecio)
        Me.Controls.Add(Me.txtCantidad)
        Me.Controls.Add(Me.lblPrecioUnitario)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.cbProductos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Name = "FormVentas"
        Me.Text = "Ventas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancelar As Button
    Friend WithEvents cbProductos As ComboBox
    Friend WithEvents lblProducto As Label
    Friend WithEvents lblPrecioUnitario As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents lblPrecio As Label
    Friend WithEvents lblCantidad As Label
    Friend WithEvents lblSubTotalProducto As Label
    Friend WithEvents lblSubtotalPrecio As Label
    Friend WithEvents listViewVentas As ListView
    Friend WithEvents columnProducto As ColumnHeader
    Friend WithEvents columnPrecioUnitario As ColumnHeader
    Friend WithEvents columnCantidad As ColumnHeader
    Friend WithEvents columnSubtotal As ColumnHeader
    Friend WithEvents btnAgregarProducto As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalPrecio As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblTitulo As Label
    Friend WithEvents columnCategoria As ColumnHeader
    Friend WithEvents lblCategoria As Label
    Friend WithEvents cbCategoria As ComboBox
    Friend WithEvents lblCliente As Label
    Friend WithEvents cbClientes As ComboBox
    Friend WithEvents columnIdProducto As ColumnHeader
End Class

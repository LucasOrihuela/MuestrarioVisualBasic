<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormClientes
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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.listClientes = New System.Windows.Forms.ListView()
        Me.columnID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnTelefono = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCorreo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblClientesTactica = New System.Windows.Forms.Label()
        Me.lblBuscar = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(603, 353)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(71, 25)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnAgregar
        '
        Me.btnAgregar.Location = New System.Drawing.Point(555, 100)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(64, 20)
        Me.btnAgregar.TabIndex = 2
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Location = New System.Drawing.Point(555, 125)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(64, 20)
        Me.btnModificar.TabIndex = 3
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.ForeColor = System.Drawing.Color.Red
        Me.btnEliminar.Location = New System.Drawing.Point(555, 150)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(64, 20)
        Me.btnEliminar.TabIndex = 4
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'listClientes
        '
        Me.listClientes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnID, Me.columnCliente, Me.columnTelefono, Me.columnCorreo})
        Me.listClientes.FullRowSelect = True
        Me.listClientes.HideSelection = False
        Me.listClientes.Location = New System.Drawing.Point(11, 97)
        Me.listClientes.MultiSelect = False
        Me.listClientes.Name = "listClientes"
        Me.listClientes.Size = New System.Drawing.Size(538, 222)
        Me.listClientes.TabIndex = 5
        Me.listClientes.UseCompatibleStateImageBehavior = False
        Me.listClientes.View = System.Windows.Forms.View.Details
        '
        'columnID
        '
        Me.columnID.Text = "ID"
        Me.columnID.Width = 40
        '
        'columnCliente
        '
        Me.columnCliente.Text = "Cliente"
        '
        'columnTelefono
        '
        Me.columnTelefono.Text = "Telefono"
        Me.columnTelefono.Width = 165
        '
        'columnCorreo
        '
        Me.columnCorreo.Text = "Correo"
        Me.columnCorreo.Width = 245
        '
        'lblClientesTactica
        '
        Me.lblClientesTactica.AutoSize = True
        Me.lblClientesTactica.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientesTactica.Location = New System.Drawing.Point(216, 9)
        Me.lblClientesTactica.Name = "lblClientesTactica"
        Me.lblClientesTactica.Size = New System.Drawing.Size(202, 24)
        Me.lblClientesTactica.TabIndex = 6
        Me.lblClientesTactica.Text = "CLIENTES TACTICA"
        Me.lblClientesTactica.UseWaitCursor = True
        '
        'lblBuscar
        '
        Me.lblBuscar.AutoSize = True
        Me.lblBuscar.Location = New System.Drawing.Point(13, 70)
        Me.lblBuscar.Name = "lblBuscar"
        Me.lblBuscar.Size = New System.Drawing.Size(43, 13)
        Me.lblBuscar.TabIndex = 7
        Me.lblBuscar.Text = "Buscar:"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(63, 70)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(176, 20)
        Me.txtBuscar.TabIndex = 8
        '
        'FormClientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 390)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.lblBuscar)
        Me.Controls.Add(Me.lblClientesTactica)
        Me.Controls.Add(Me.listClientes)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnModificar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Name = "FormClientes"
        Me.Text = "Clientes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents listClientes As ListView
    Friend WithEvents lblClientesTactica As Label
    Friend WithEvents columnID As ColumnHeader
    Friend WithEvents columnCliente As ColumnHeader
    Friend WithEvents columnTelefono As ColumnHeader
    Friend WithEvents columnCorreo As ColumnHeader
    Friend WithEvents lblBuscar As Label
    Friend WithEvents txtBuscar As TextBox
End Class

Public Class Form3

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ProveedorToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        If (InventarioDataSet.HasChanges()) Then
            Me.ProveedorTableAdapter.Update(Me.InventarioDataSet.Proveedor)
            MessageBox.Show("Usted ha ingresado un proveedor correctamente", "ingreso")
        End If
        'Ir al primer resgistro de la tabla
        BindingSource1.Position = 0

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim modificar As DialogResult
        modificar = MessageBox.Show("¿Esta seguro de modificar los datos?", "Modificar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True

        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

        If (InventarioDataSet.HasChanges()) Then
            modificar = MessageBox.Show("¿Desea modificar el cliente?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (modificar = DialogResult.Yes) Then

                Me.ProveedorTableAdapter.Update(Me.InventarioDataSet.Proveedor)
                MessageBox.Show("Datos modificados correctaamente")
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False
                TextBox6.Enabled = False
                TextBox7.Enabled = False

                Button1.Enabled = False
                Button3.Enabled = True
                Button4.Enabled = True
            End If
        End If
        'Ir al primer resgistro de la tabla
        BindingSource1.Position = 0


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim vistaFilaActual As DataRowView
        Dim NL As String = Environment.NewLine

        If (MessageBox.Show(("¿Esta seguro de eliminar el proveedor? " & NL), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            vistaFilaActual = BindingSource1.Current
            vistaFilaActual.Row.Delete()
            BindingSource1.Position = BindingSource1.Count - 1
            If (InventarioDataSet.HasChanges()) Then
                Me.ProveedorTableAdapter.Update(Me.InventarioDataSet.Proveedor)
                MessageBox.Show("Usted ha eliminado el proveedor correctamente", "Eliminar")
            End If
            'Ir al primer resgistro de la tabla
            BindingSource1.Position = 0
        End If

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.Proveedor' Puede moverla o quitarla según sea necesario.
        'Me.ProveedorTableAdapter.Fill(Me.InventarioDataSet.Proveedor)
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        Dim mitabla As DataTable = InventarioDataSet.Proveedor
        Dim cfilas As DataRowCollection = mitabla.Rows
        Dim filaBuscada() As DataRow 'Matriz de filas
        Dim NL As String = Environment.NewLine
        'Buscar en la columna Nombre de cada fila

        Dim buscar, criterio As String
        buscar = InputBox("Digite el nombre del proveedor")
        criterio = "Nombre Like '*" & buscar & "*'"

        'Utilizar el metodo Slect para encontrar todas las filas que pasen el filtro y el filtro y almacenarlas en la matriz filaBuscada
        filaBuscada = mitabla.Select(criterio)

        If (filaBuscada.GetUpperBound(0) = -1) Then
            MessageBox.Show("No se encontraron registros coincidentes", "Buscar")
            Exit Sub
        End If

        'Seleccionar de las filas encontradas la que buscamos

        Dim i, j As Integer

        For i = 0 To filaBuscada.GetUpperBound(0)
            If (MessageBox.Show("¿Este es el el nombre del proveedor? " & buscar, "Buscar", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                'Si: mostrar en el formulario la fila seleccionada
                For j = 0 To cfilas.Count - 1
                    If (cfilas(j).Equals(filaBuscada(i))) Then
                        BindingSource1.Position = j
                    End If
                Next j
            End If
        Next i

    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMoveNextItem.Click
        Button2.Enabled = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form10.Show()
        Form10.WindowState = FormWindowState.Maximized
    End Sub
End Class
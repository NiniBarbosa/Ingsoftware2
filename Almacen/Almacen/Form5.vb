Imports System.Data.SQLite

Public Class Form5
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ClienteToolStripMenuItem.Enabled = True
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False

        If (InventarioDataSet.HasChanges()) Then
            Me.ClienteTableAdapter.Update(Me.InventarioDataSet.cliente)
            MessageBox.Show("Ingreso de cliente correctamente")
        End If
        'Ir al primer resgistro de la tabla
        BindingSource1.Position = 0
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.cliente' Puede moverla o quitarla según sea necesario.
        'Me.ClienteTableAdapter.Fill(Me.InventarioDataSet.cliente)
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Form9.Show()
        Form9.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True

        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button1.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim vistaFilaActual As DataRowView
        Dim NL As String = Environment.NewLine
        If (MessageBox.Show(("¿Esta seguro de eliminar el Cliente? " & NL), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            vistaFilaActual = BindingSource1.Current
            vistaFilaActual.Row.Delete()
            BindingSource1.Position = BindingSource1.Count - 1
            If (InventarioDataSet.HasChanges()) Then
                Me.ClienteTableAdapter.Update(Me.InventarioDataSet.cliente)
                MessageBox.Show("Cliente eliminado correctamente")
            End If
            'Ir al primer resgistro de la tabla
            BindingSource1.Position = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim modificar As DialogResult

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True

        Button1.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

        If (InventarioDataSet.HasChanges()) Then
            modificar = MessageBox.Show("¿Desea modificar el cliente?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If (modificar = DialogResult.Yes) Then
                Me.ClienteTableAdapter.Update(Me.InventarioDataSet.cliente)
                MessageBox.Show("Datos modificados correctaamente")

                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                TextBox5.Enabled = False

                Button1.Enabled = False
                Button3.Enabled = True
                Button4.Enabled = True

            End If
        End If
        'Ir al primer resgistro de la tabla
        BindingSource1.Position = 0

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False

        Dim mitabla As DataTable = InventarioDataSet.cliente
        Dim cfilas As DataRowCollection = mitabla.Rows
        Dim filaBuscada() As DataRow 'Matriz de filas
        Dim NL As String = Environment.NewLine
        'Buscar en la columna Nombre de cada fila

        Dim buscar, criterio As String
        buscar = InputBox("Digite el nombre del clienteque desea buscar", "Buscar")
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
            If (MessageBox.Show("¿Este es el nombre buscado? " & buscar, "Buscar", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                'Si: mostrar en el formulario la fila seleccionada
                For j = 0 To cfilas.Count - 1
                    If (cfilas(j).Equals(filaBuscada(i))) Then
                        BindingSource1.Position = j
                    End If
                Next j
            End If
        Next i

    End Sub
End Class
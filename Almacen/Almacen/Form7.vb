Public Class Form7

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.Tallas' Puede moverla o quitarla según sea necesario.
        Me.TallasTableAdapter.Fill(Me.InventarioDataSet.Tallas)
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.producto' Puede moverla o quitarla según sea necesario.
        Me.ProductoTableAdapter.Fill(Me.InventarioDataSet.producto)

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ProductoToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False

        Dim mitabla As DataTable = InventarioDataSet.producto
        Dim cfilas As DataRowCollection = mitabla.Rows
        Dim filaBuscada() As DataRow 'Matriz de filas
        Dim NL As String = Environment.NewLine
        'Buscar en la columna Nombre de cada fila

        Dim buscar, criterio As String
        buscar = InputBox("Digite el codigo del zapato")
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
            If (MessageBox.Show("¿Este es el codigo del zapato? " & buscar, "Buscar", MessageBoxButtons.YesNo) = DialogResult.Yes) Then
                'Si: mostrar en el formulario la fila seleccionada
                For j = 0 To cfilas.Count - 1
                    If (cfilas(j).Equals(filaBuscada(i))) Then
                        BindingSource1.Position = j
                    End If
                Next j
            End If
        Next i
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form12.Show()
        Form12.WindowState = FormWindowState.Maximized
    End Sub
End Class
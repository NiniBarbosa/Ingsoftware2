Public Class Form8

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

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False

        If (inventarioDataSet.HasChanges()) Then
            Me.Det_ventaTableAdapter.Update(Me.InventarioDataSet.det_venta)
            MessageBox.Show("Venta realizada correctamente")
        End If
        'Ir al primer resgistro de la tabla
        BindingSource1.Position = 0
    End Sub

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.det_venta' Puede moverla o quitarla según sea necesario.
        Me.Det_ventaTableAdapter.Fill(Me.InventarioDataSet.det_venta)
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

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim vistaFilaActual As DataRowView
        Dim NL As String = Environment.NewLine
        If (MessageBox.Show(("¿Esta seguro de eliminar la factura? " & NL), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            vistaFilaActual = BindingSource1.Current
            vistaFilaActual.Row.Delete()
            BindingSource1.Position = BindingSource1.Count - 1
            If (InventarioDataSet.HasChanges()) Then
                Me.Det_ventaTableAdapter.Update(Me.InventarioDataSet.det_venta)
                MessageBox.Show("Factura Eliminada correctamente")
            End If
            'Ir al primer resgistro de la tabla
            BindingSource1.Position = 0
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form14.Show()
        Form14.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem.Click
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.VentaToolStripMenuItem.Enabled = True
        End If
    End Sub
End Class
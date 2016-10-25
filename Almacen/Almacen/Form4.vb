Public Class Form4

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.Tallas' Puede moverla o quitarla según sea necesario.
        Me.TallasTableAdapter.Fill(Me.InventarioDataSet.Tallas)
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.ingreso_mercancia' Puede moverla o quitarla según sea necesario.
        Me.Ingreso_mercanciaTableAdapter.Fill(Me.InventarioDataSet.ingreso_mercancia)
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False

        Button1.Enabled = False
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        TextBox7.Enabled = True
    End Sub

    Private Sub BindingNavigatorAddNewItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorAddNewItem1.Click
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        TextBox7.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False

        Button1.Enabled = False

        If (InventarioDataSet.HasChanges()) Then
            Me.Ingreso_mercanciaTableAdapter.Update(Me.InventarioDataSet.ingreso_mercancia)
            Me.TallasTableAdapter.Update(Me.InventarioDataSet.Tallas)
            MessageBox.Show("Usted ha ingresado un un producto correctamente", "ingreso")
        End If
        'Ir al primer resgistro de la tabla
        BindingSource1.Position = 0
    End Sub

    Private Sub BindingNavigatorMovePreviousItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BindingNavigatorMovePreviousItem1.Click
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ProductoToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form11.Show()
        Form11.WindowState = FormWindowState.Maximized
    End Sub
End Class
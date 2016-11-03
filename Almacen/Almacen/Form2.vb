Public Class Form2
    Private Sub ClienteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClienteToolStripMenuItem.Click
        Form5.MdiParent = Me
        Form5.Show()
        Form5.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub ProveedorToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProveedorToolStripMenuItem.Click
        Form3.MdiParent = Me
        Form3.Show()
        Form3.WindowState = FormWindowState.Maximized
        Me.ClienteToolStripMenuItem.Enabled = True
        Me.ProveedorToolStripMenuItem.Enabled = False
        Me.ProductoToolStripMenuItem.Enabled = True
        Me.MercanciaToolStripMenuItem.Enabled = True
        Me.SalidaToolStripMenuItem.Enabled = True
        Me.IngresoToolStripMenuItem.Enabled = True
        Me.VentaToolStripMenuItem.Enabled = True

    End Sub
    Private Sub ProductoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductoToolStripMenuItem.Click
        Form7.MdiParent = Me
        Form7.Show()
        Form7.WindowState = FormWindowState.Maximized
        Me.ClienteToolStripMenuItem.Enabled = True
        Me.ProveedorToolStripMenuItem.Enabled = True
        Me.ProductoToolStripMenuItem.Enabled = False
        Me.MercanciaToolStripMenuItem.Enabled = True
        Me.IngresoToolStripMenuItem.Enabled = True
        Me.SalidaToolStripMenuItem.Enabled = True
        Me.VentaToolStripMenuItem.Enabled = True
    End Sub


    Private Sub IngresoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IngresoToolStripMenuItem.Click
        Form4.MdiParent = Me
        Form4.Show()
        Form4.WindowState = FormWindowState.Maximized
        Me.ClienteToolStripMenuItem.Enabled = True
        Me.ProveedorToolStripMenuItem.Enabled = True
        Me.ProductoToolStripMenuItem.Enabled = True
        Me.MercanciaToolStripMenuItem.Enabled = True
        Me.IngresoToolStripMenuItem.Enabled = False
        Me.SalidaToolStripMenuItem.Enabled = True
        Me.VentaToolStripMenuItem.Enabled = True
    End Sub

    Private Sub SalidaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalidaToolStripMenuItem.Click
        Form6.MdiParent = Me
        Form6.Show()
        Form6.WindowState = FormWindowState.Maximized
        Me.ClienteToolStripMenuItem.Enabled = True
        Me.ProveedorToolStripMenuItem.Enabled = True
        Me.ProductoToolStripMenuItem.Enabled = True
        Me.MercanciaToolStripMenuItem.Enabled = True
        Me.IngresoToolStripMenuItem.Enabled = True
        Me.SalidaToolStripMenuItem.Enabled = False
        Me.VentaToolStripMenuItem.Enabled = True
    End Sub

    Private Sub VentaToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentaToolStripMenuItem.Click
        Form8.MdiParent = Me
        Form8.Show()
        Form8.WindowState = FormWindowState.Maximized
        Me.ClienteToolStripMenuItem.Enabled = True
        Me.ProveedorToolStripMenuItem.Enabled = True
        Me.ProductoToolStripMenuItem.Enabled = True
        Me.MercanciaToolStripMenuItem.Enabled = True
        Me.IngresoToolStripMenuItem.Enabled = True
        Me.SalidaToolStripMenuItem.Enabled = True
        Me.VentaToolStripMenuItem.Enabled = False
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
        End If
    End Sub
End Class
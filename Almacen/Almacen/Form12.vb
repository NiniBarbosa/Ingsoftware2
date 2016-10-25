Public Class Form12

    Private Sub Form12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'inventarioDataSet.producto' Puede moverla o quitarla según sea necesario.
        Me.productoTableAdapter.Fill(Me.inventarioDataSet.producto)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
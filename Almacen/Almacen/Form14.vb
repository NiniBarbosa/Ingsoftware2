Public Class Form14

    Private Sub Form14_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'inventarioDataSet.det_venta' Puede moverla o quitarla según sea necesario.
        Me.det_ventaTableAdapter.Fill(Me.inventarioDataSet.det_venta)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
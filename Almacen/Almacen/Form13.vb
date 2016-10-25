Public Class Form13

    Private Sub Form13_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'inventarioDataSet.salida_mercancia' Puede moverla o quitarla según sea necesario.
        Me.salida_mercanciaTableAdapter.Fill(Me.inventarioDataSet.salida_mercancia)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
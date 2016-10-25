Public Class Form11

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'inventarioDataSet.ingreso_mercancia' Puede moverla o quitarla según sea necesario.
        Me.ingreso_mercanciaTableAdapter.Fill(Me.inventarioDataSet.ingreso_mercancia)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
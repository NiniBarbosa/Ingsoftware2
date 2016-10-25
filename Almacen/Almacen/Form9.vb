Public Class Form9

    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'inventarioDataSet.cliente' Puede moverla o quitarla según sea necesario.
        Me.clienteTableAdapter.Fill(Me.inventarioDataSet.cliente)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class
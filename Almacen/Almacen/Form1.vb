Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim usuario As String
        Dim contrasena As String
        Dim usu As String
        Dim contra As String
        Dim usua As String
        Dim contrase As String

        usu = TextBox1.Text
        contra = TextBox2.Text
        usuario = "administrador"
        contrasena = "admin"
        usua = "usuario"
        contrase = "usuario"


        If usu = usuario And contra = contrasena Then
            MessageBox.Show("Usted es Administrador")
            Form2.Show()
            Me.Finalize()
        Else
            If usu = usua And contra = contrase Then
                MessageBox.Show("Usted es Usuario")
                Form2.Show()
                Form2.MercanciaToolStripMenuItem.Enabled = False
                'Form3.Button4.Enabled = False
                'Form3.Button2.Enabled = False
                'Form5.Button4.Enabled = False
                Me.Finalize()
            Else
                If usu <> usuario Or usu <> usua Or contra <> contrasena Or contra <> contrase Then
                    MessageBox.Show("Usted ha ingresado un Usuario o una Contraseña erroneos")
                    MessageBox.Show("Vuelva a intentarlo")
                End If
            End If

        End If
    End Sub
End Class

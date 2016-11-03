Imports System.Data.SQLite

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM usuarios where login = '" + TextBox1.Text + "' and password = '" + TextBox2.Text + "'"


        Dim connection As String = "Data Source=Almacen.db;Version=3;New=False;Compress=True;"

        Dim SQLConn As New SQLiteConnection(connection)
        Dim SQLcmd As New SQLiteCommand(SQLConn)
        SQLcmd.CommandText = sqlconsulta
        'Dim SQLdr As SQLiteDataReader
        If SQLConn.State <> ConnectionState.Open Then
            SQLConn.Open()
        End If
        Dim dt As New DataTable()
        Dim ds As New DataSet()
        Dim da As New SQLiteDataAdapter(SQLcmd)
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            Dim campos As String() = New String(dt.Rows.Count - 1) {}
            For i As Integer = 0 To dt.Rows.Count - 1
                If DirectCast(dt.Rows(i)("login"), [String]).Equals(TextBox1.Text) And DirectCast(dt.Rows(i)("password"), [String]).Equals(TextBox2.Text) Then
                    Form2.Show()
                    Me.Finalize()
                Else
                    MessageBox.Show("Usted ha ingresado un Usuario o una Contraseña erroneos")
                    MessageBox.Show("Vuelva a intentarlo")
                End If
            Next
            SQLConn.Close()
        End If
    End Sub
End Class

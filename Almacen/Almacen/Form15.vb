Imports System.Data.SQLite
Public Class Form15

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM cliente where cedula = '" + TextBox1.Text + "'"

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

        DataGridView1.DataSource = dt
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM cliente"

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

        DataGridView1.DataSource = dt
    End Sub
End Class
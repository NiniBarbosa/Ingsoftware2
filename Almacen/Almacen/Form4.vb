Imports System.Data.SQLite
Public Class Form4
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'DataGridView1.Visible = False
        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then
                    If ComboBox1.Text <> "" Then
                        'DataGridView1.Visible = False
                        Dim SQLSelect As String
                        Dim vId As Long
                        vId = IdTable()

                        Dim sqlconsulta As String
                        Dim id_prd As Long
                        sqlconsulta = "select id from producto where codigo='" + TextBox1.Text + "'and talla='" + ComboBox1.Text + "'"
                        Dim connection1 As String = "Data Source=Almacen.db;Version=3;New=False;Compress=True;"
                        Dim SQLConn1 As New SQLiteConnection(connection1)
                        Dim SQLcmd1 As New SQLiteCommand(SQLConn1)
                        SQLcmd1.CommandText = sqlconsulta
                        'Dim SQLdr As SQLiteDataReader
                        If SQLConn1.State <> ConnectionState.Open Then
                            SQLConn1.Open()
                        End If
                        Dim dt1 As New DataTable()
                        Dim ds1 As New DataSet()
                        Dim da1 As New SQLiteDataAdapter(SQLcmd1)
                        da1.Fill(dt1)

                        For Each row As DataRow In dt1.Rows
                            id_prd = CStr(row("id"))
                        Next

                        SQLSelect = "INSERT INTO ingreso_mercancia (id,idproducto,fecha_ingreso,talla,cantidad,descripcion)  VALUES(" + vId.ToString() + "," + id_prd.ToString() + ",Date('now'),'" + ComboBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "');"
                        Dim connection As String = "Data Source=Almacen.db;Version=3;New=False;Compress=True;"

                        Dim SQLConn As New SQLiteConnection(connection)
                        Dim SQLcmd As New SQLiteCommand(SQLConn)
                        SQLcmd.CommandText = SQLSelect
                        If SQLConn.State <> ConnectionState.Open Then
                            SQLConn.Open()
                        End If
                        Dim dt As New DataTable()
                        Dim ds As New DataSet()
                        Dim da As New SQLiteDataAdapter(SQLcmd)
                        ' Creamos un SQLcmd y le asignamos la cadena de consulta
                        'MessageBox.Show("   " + SQLSelect)
                        SQLcmd = SQLConn.CreateCommand()
                        SQLcmd.CommandText = SQLSelect
                        SQLcmd.ExecuteNonQuery()
                        SQLConn.Close()
                        MessageBox.Show("Ingreso de mercancia correctamente")
                        TextBox1.Text = ""
                        TextBox2.Text = ""
                        TextBox3.Text = ""
                        TextBox1.Enabled = False
                        TextBox2.Enabled = False
                        TextBox3.Enabled = False
                        ComboBox1.Enabled = False
                        Button1.Enabled = False
                        ComboBox1.Text = ""
                    Else
                        MessageBox.Show("El campo Talla no puede ir vacio")
                        TextBox3.Focus()
                    End If
                Else
                    MessageBox.Show("El campo Descripcion no puede ir vacio")
                    TextBox3.Focus()
                End If
                Else
                    MessageBox.Show("El campo Cantidad no puede ir vacio")
                    TextBox2.Focus()
                End If
        Else
            MessageBox.Show("El campo Codigo no puede ir vacio")
            TextBox1.Focus()
        End If
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
        ComboBox1.Enabled = False

        If Button2.Text = "Consultar tallas" Then
            If TextBox1.Text <> "" Then
                Dim sqlconsulta As String
                sqlconsulta = "SELECT talla FROM producto where codigo='" + TextBox1.Text + "' order by talla asc"

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
                da.Fill(ds)
                ComboBox1.DataSource = ds.Tables(0)
                ComboBox1.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
                'ComboBox1.ValueMember = "id"
                ComboBox1.Text = ""
                ComboBox1.Enabled = True
                TextBox1.Enabled = False
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                Button2.Text = "Nueva Consulta"
                SQLConn.Close()
            End If
        Else
            TextBox1.Focus()
            ComboBox1.Text = ""
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            ComboBox1.Text = ""
            ComboBox1.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            Button2.Text = "Consultar tallas"
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
    Function IdTable() As Integer
        Dim sqlconsulta As String
        Dim id As Long
        sqlconsulta = "select (id +1) as id from ingreso_mercancia order by id desc LIMIT 1"
        Dim connection1 As String = "Data Source=Almacen.db;Version=3;New=False;Compress=True;"
        Dim SQLConn1 As New SQLiteConnection(connection1)
        Dim SQLcmd1 As New SQLiteCommand(SQLConn1)
        SQLcmd1.CommandText = sqlconsulta
        'Dim SQLdr As SQLiteDataReader
        If SQLConn1.State <> ConnectionState.Open Then
            SQLConn1.Open()
        End If
        Dim dt1 As New DataTable()
        Dim ds1 As New DataSet()
        Dim da1 As New SQLiteDataAdapter(SQLcmd1)
        da1.Fill(dt1)

        For Each row As DataRow In dt1.Rows
            id = CStr(row("id"))
        Next

        Return id

    End Function

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyValue = 13 Then
            Button2_Click(Nothing, Nothing)
        End If
    End Sub
End Class
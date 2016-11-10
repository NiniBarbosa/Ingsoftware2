Imports System.Data.SQLite
Public Class Form7
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ProductoToolStripMenuItem.Enabled = True
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If (Button1.Text = "Consultar") Then

            TextBox1.Enabled = True
            TextBox2.Enabled = False
            TextBox3.Enabled = True
            TextBox1.Focus()
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            Button1.Enabled = True
            Button2.Enabled = False
            Button4.Enabled = False
            DataGridView1.Visible = False
            Label8.Visible = True
            ComboBox1.Enabled = False

            If TextBox1.Text <> "" Then
                If TextBox1.Text <> "" And TextBox3.Text <> "" Then
                    Dim sqlconsulta As String
                    sqlconsulta = "SELECT * FROM producto where codigo = '" + TextBox1.Text + "' and talla='" + TextBox3.Text + "'"

                    'MessageBox.Show("   " + sqlconsulta)
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

                    If dt.Rows.Count <= 0 Then
                        MessageBox.Show("El codigo no existe, Vuelva a intentarlo")
                        TextBox1.Text = ""
                        TextBox3.Text = ""
                    Else
                        For Each row As DataRow In dt.Rows
                            TextBox1.Text = CStr(row("codigo"))
                            TextBox2.Text = CStr(row("valor"))
                            TextBox3.Text = CStr(row("talla"))
                            TextBox4.Text = CStr(row("color"))
                            ComboBox1.Text = CStr(row("proveedor"))
                            TextBox5.Text = CStr(row("descripcion"))
                            TextBox3.Enabled = False
                            TextBox1.Enabled = False
                            Label8.Visible = False
                            Button7.Enabled = False
                            Button4.Enabled = True
                            Button3.Enabled = True
                        Next
                        Button1.Text = "Nueva Consulta"
                        Label8.Visible = False
                        Button7.Enabled = False
                        SQLConn.Close()
                        Button4.Enabled = True
                        Button3.Enabled = True
                    End If
                Else
                    Dim sqlconsulta As String
                    sqlconsulta = "SELECT * FROM producto where codigo = '" + TextBox1.Text + "'"

                    'MessageBox.Show("   " + sqlconsulta)
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

                    If dt.Rows.Count <= 0 Then
                        MessageBox.Show("El codigo no existe, Vuelva a intentarlo")
                        TextBox1.Text = ""
                        TextBox3.Text = ""
                    Else

                        DataGridView1.Visible = True
                        DataGridView1.DataSource = dt
                        Button1.Text = "Nueva Consulta"
                        TextBox3.Enabled = False
                        TextBox1.Enabled = False
                        Label8.Visible = False
                        Button7.Enabled = False
                        SQLConn.Close()
                    End If
                End If
            End If
            Else
            TextBox1.Enabled = True
            TextBox3.Enabled = True
                Button1.Text = "Consultar"
                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                ComboBox1.Text = ""
                DataGridView1.Visible = False
            Label8.Visible = True
            Button7.Enabled = True
            End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sqlconsulta As String
        sqlconsulta = "SELECT nombre FROM proveedor limit 100"

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
        SQLConn.Close()
    End Sub

    Function IdTable() As Integer
        Dim sqlconsulta As String
        Dim id As Long
        sqlconsulta = "select (id +1) as id from producto order by id desc LIMIT 1"
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


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button4.Enabled = False
        DataGridView1.Visible = False
        Label8.Visible = False

        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then
                    If TextBox4.Text <> "" Then
                        If ComboBox1.Text <> "" Then
                            If TextBox5.Text <> "" Then
                                DataGridView1.Visible = False
                                Dim SQLSelect As String
                                Dim vId As Long
                                vId = IdTable()

                                Dim sqlconsulta As String
                                sqlconsulta = "SELECT * FROM producto where codigo = '" + TextBox1.Text + "' and talla= '" + TextBox3.Text + "'"
                                MessageBox.Show("   " + sqlconsulta)
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

                                If dt1.Rows.Count > 0 Then
                                    MessageBox.Show("El producto ya existe")
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    TextBox3.Text = ""
                                    TextBox4.Text = ""
                                    TextBox5.Text = ""
                                Else


                                    SQLSelect = "INSERT INTO producto (id,codigo,valor,talla,color,proveedor,descripcion)  VALUES(" + vId.ToString() + ",'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + ComboBox1.Text + "','" + TextBox5.Text + "');"
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
                                    MessageBox.Show("Ingreso del producto correctamente")
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    TextBox3.Text = ""
                                    TextBox4.Text = ""
                                    TextBox5.Text = ""
                                    ComboBox1.Text = ""

                                    TextBox1.Enabled = False
                                    TextBox2.Enabled = False
                                    TextBox3.Enabled = False
                                    TextBox4.Enabled = False
                                    TextBox5.Enabled = False
                                    Button5.Enabled = False
                                    ComboBox1.Enabled = False
                                End If
                            Else
                                MessageBox.Show("El campo Descripcion no puede ir vacio")
                                TextBox5.Focus()
                            End If
                        Else
                            MessageBox.Show("El campo Proveedor no puede ir vacio")
                            ComboBox1.Focus()
                        End If
                        Else
                            MessageBox.Show("El campo Color no puede ir vacio")
                            TextBox4.Focus()
                        End If
                Else
                    MessageBox.Show("El campo Talla no puede ir vacio")
                    TextBox3.Focus()
                End If
            Else
                MessageBox.Show("El campo Valor no puede ir vacio")
                TextBox2.Focus()
            End If
        Else
            MessageBox.Show("El campo Codigo no puede ir vacio")
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        ComboBox1.Enabled = True
        Button5.Enabled = True
        Button3.Enabled = False
        DataGridView1.Visible = False
        Label8.Visible = False
        Button4.Enabled = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label8.Visible = False
        Button7.Enabled = False
        If (Button3.Text = "Modificar") Then
            DataGridView1.Visible = False
            Button4.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = True
            TextBox3.Enabled = False
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            ComboBox1.Enabled = True
            Button1.Enabled = False
            Button3.Text = "Actualizar"
        Else

            If TextBox1.Text <> "" Then
                If TextBox2.Text <> "" Then
                    If TextBox3.Text <> "" Then
                        If TextBox4.Text <> "" Then
                            If ComboBox1.Text <> "" Then
                                If TextBox5.Text <> "" Then
                                    DataGridView1.Visible = False
                                    Dim SQLSelect As String
                                    Dim modificar As DialogResult
                                    modificar = MessageBox.Show("¿Esta seguro de modificar los datos?", "Modificar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                    If (modificar = DialogResult.Yes) Then
                                        SQLSelect = "UPDATE producto SET valor='" + TextBox2.Text + "', color='" + TextBox4.Text + "', proveedor='" + ComboBox1.Text + "', descripcion='" + TextBox5.Text + "' WHERE codigo='" + TextBox1.Text + "' and talla='" + TextBox3.Text + "'"

                                        'MessageBox.Show("   " + SQLSelect)

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

                                        ' Creamos un SQLiteCommand y le asignamos la cadena de consulta
                                        SQLcmd = SQLConn.CreateCommand()
                                        SQLcmd.CommandText = SQLSelect
                                        SQLcmd.ExecuteNonQuery()
                                        SQLConn.Close()
                                        MessageBox.Show("Informacion modificada correctamente")
                                        'Button3.Enabled = False
                                        Button1.Enabled = True
                                        Button3.Enabled = True
                                        Button3.Text = "Modificar"

                                        TextBox1.Text = ""
                                        TextBox2.Text = ""
                                        TextBox3.Text = ""
                                        TextBox4.Text = ""
                                        TextBox5.Text = ""
                                        ComboBox1.Text = ""

                                        TextBox1.Enabled = False
                                        TextBox2.Enabled = False
                                        TextBox3.Enabled = False
                                        TextBox4.Enabled = False
                                        TextBox5.Enabled = False
                                        ComboBox1.Enabled = False
                                    End If
                                Else
                                    MessageBox.Show("El campo Descripcion no puede ir vacio")
                                    TextBox5.Focus()
                                End If
                            Else
                                MessageBox.Show("El campo Proveedor no puede ir vacio")
                                ComboBox1.Focus()
                            End If
                        Else
                            MessageBox.Show("El campo Color no puede ir vacio")
                            TextBox4.Focus()
                        End If
                    Else
                        MessageBox.Show("El campo Talla no puede ir vacio")
                        TextBox3.Focus()
                    End If
                Else
                    MessageBox.Show("El campo Valor no puede ir vacio")
                    TextBox2.Focus()
                End If
            Else
                MessageBox.Show("El campo Codigo no puede ir vacio")
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DataGridView1.Visible = True
        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM producto limit 100"

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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DataGridView1.Visible = False
        Dim NL As String = Environment.NewLine
        Label7.Visible = False
        If (MessageBox.Show(("¿Esta seguro de eliminar el producto? " & NL), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim SQLSelect As String
            SQLSelect = "DELETE FROM producto WHERE codigo='" + TextBox3.Text + "' and talla='" + TextBox3.Text + "'"
            'MessageBox.Show("   " + SQLSelect)

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

            ' Creamos un SQLiteCommand y le asignamos la cadena de consulta
            SQLcmd = SQLConn.CreateCommand()
            SQLcmd.CommandText = SQLSelect
            SQLcmd.ExecuteNonQuery()
            SQLConn.Close()
            MessageBox.Show("Informacion eliminada correctamente")
            'Ir al primer resgistro de la tabla
            'BindingSource1.Position = 0
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            ComboBox1.Text = ""
            Button4.Enabled = False
        End If
    End Sub
End Class
Imports System.Data.SQLite
Public Class Form3

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ProveedorToolStripMenuItem.Enabled = True
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Visible = False
        Button4.Enabled = False
        Label8.Visible = False

        If TextBox1.Text <> "" Then
            If TextBox2.Text <> "" Then
                If TextBox3.Text <> "" Then
                    If TextBox4.Text <> "" Then
                        If TextBox5.Text <> "" Then
                            If ComboBox1.Text <> "" Then
                                DataGridView1.Visible = False
                                Dim SQLSelect As String

                                Dim sqlconsulta1 As String
                                sqlconsulta1 = "SELECT * FROM proveedor where identificacion = " + TextBox2.Text
                                'MessageBox.Show("   " + sqlconsulta)
                                Dim connection1 As String = "Data Source=Almacen.db;Version=3;New=False;Compress=True;"
                                Dim SQLConn1 As New SQLiteConnection(connection1)
                                Dim SQLcmd1 As New SQLiteCommand(SQLConn1)
                                SQLcmd1.CommandText = sqlconsulta1
                                'Dim SQLdr As SQLiteDataReader
                                If SQLConn1.State <> ConnectionState.Open Then
                                    SQLConn1.Open()
                                End If
                                Dim dt1 As New DataTable()
                                Dim ds1 As New DataSet()
                                Dim da1 As New SQLiteDataAdapter(SQLcmd1)
                                da1.Fill(dt1)

                                If dt1.Rows.Count > 0 Then
                                    MessageBox.Show("El proveedor ya existe")
                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    TextBox3.Text = ""
                                    TextBox4.Text = ""
                                    TextBox5.Text = ""
                                    ComboBox1.Text = ""
                                Else
                                    SQLSelect = "INSERT INTO proveedor (nombre,identificacion,telefono,direccion,tipo_proveedor,correo)  VALUES(" + "'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + ComboBox1.Text + "','" + TextBox5.Text + "');"
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
                                    MessageBox.Show("Ingreso de Proveedor correctamente")

                                    TextBox1.Enabled = False
                                    TextBox2.Enabled = False
                                    TextBox3.Enabled = False
                                    TextBox4.Enabled = False
                                    TextBox5.Enabled = False
                                    ComboBox1.Enabled = False
                                    Button1.Enabled = False

                                    TextBox1.Text = ""
                                    TextBox2.Text = ""
                                    TextBox3.Text = ""
                                    TextBox4.Text = ""
                                    TextBox5.Text = ""
                                    ComboBox1.Text = ""
                                End If
                            Else
                                MessageBox.Show("El campo Topo Proveedor no puede ir vacio")
                                TextBox5.Focus()
                            End If
                            Else
                                MessageBox.Show("El campo Correo no puede ir vacio")
                                TextBox5.Focus()
                            End If
                        Else
                            MessageBox.Show("El campo Direccion no puede ir vacio")
                            TextBox4.Focus()
                        End If
                    Else
                        MessageBox.Show("El campo Telefono no puede ir vacio")
                        TextBox3.Focus()
                    End If
                Else
                    MessageBox.Show("El campo Identificacion no puede ir vacio")
                    TextBox2.Focus()
                End If
            Else
                MessageBox.Show("El campo Nombre no puede ir vacio")
                TextBox1.Focus()
            End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label8.Visible = False
        Button6.Enabled = False
        If (Button2.Text = "Modificar") Then
            DataGridView1.Visible = False
            Button4.Enabled = False
            TextBox1.Enabled = True
            TextBox2.Enabled = False
            TextBox3.Enabled = True
            TextBox4.Enabled = True
            TextBox5.Enabled = True
            ComboBox1.Enabled = True
            Button2.Text = "Actualizar"
            Button3.Enabled = False
        Else
            If TextBox1.Text <> "" Then
                If TextBox2.Text <> "" Then
                    If TextBox3.Text <> "" Then
                        If TextBox4.Text <> "" Then
                            If TextBox5.Text <> "" Then
                                If ComboBox1.Text <> "" Then
                                    DataGridView1.Visible = False

                                    Dim modificar As DialogResult
                                    modificar = MessageBox.Show("¿Esta seguro de modificar los datos?", "Modificar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                    If (modificar = DialogResult.Yes) Then
                                        Dim SQLSelect As String
                                        SQLSelect = "UPDATE proveedor SET nombre='" + TextBox1.Text + "', telefono='" + TextBox3.Text + "', direccion='" + TextBox4.Text + "', correo='" + TextBox5.Text + "', tipo_proveedor='" + ComboBox1.Text + "'  WHERE identificacion='" + TextBox2.Text + "'"
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

                                        TextBox1.Enabled = False
                                        TextBox2.Enabled = False
                                        TextBox3.Enabled = False
                                        TextBox4.Enabled = False
                                        TextBox5.Enabled = False
                                        ComboBox1.Enabled = False

                                        TextBox1.Text = ""
                                        TextBox2.Text = ""
                                        TextBox3.Text = ""
                                        TextBox4.Text = ""
                                        TextBox5.Text = ""
                                        ComboBox1.Text = ""

                                        Button2.Text = "Modificar"
                                        Button1.Enabled = False
                                        Button3.Enabled = True
                                        Button2.Enabled = False
                                        Button6.Enabled = True
                                    End If
                                    'End If
                                    'Ir al primer resgistro de la tabla
                                    'BindingSource1.Position = 0
                                Else
                                    MessageBox.Show("El campo Topo Proveedor no puede ir vacio")
                                    TextBox5.Focus()
                                End If
                            Else
                                MessageBox.Show("El campo Correo no puede ir vacio")
                                TextBox5.Focus()
                            End If
                        Else
                            MessageBox.Show("El campo Direccion no puede ir vacio")
                            TextBox4.Focus()
                        End If
                    Else
                        MessageBox.Show("El campo Telefono no puede ir vacio")
                        TextBox3.Focus()
                    End If
                Else
                    MessageBox.Show("El campo Identificacion no puede ir vacio")
                    TextBox2.Focus()
                End If
            Else
                MessageBox.Show("El campo Nombre no puede ir vacio")
                TextBox1.Focus()
            End If
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Label8.Visible = False
        DataGridView1.Visible = False
        Dim NL As String = Environment.NewLine
        If (MessageBox.Show(("¿Esta seguro de eliminar el proveedor? " & NL), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Dim SQLSelect As String
            SQLSelect = "DELETE FROM proveedor WHERE identificacion=" + TextBox2.Text + ""
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
            Button4.Enabled = False

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            ComboBox1.Text = ""
        End If

    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.Proveedor' Puede moverla o quitarla según sea necesario.
        'Me.ProveedorTableAdapter.Fill(Me.InventarioDataSet.Proveedor)
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        Button1.Enabled = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (Button3.Text = "Consultar") Then
            TextBox1.Enabled = False
            TextBox2.Enabled = True
            TextBox2.Focus()
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            ComboBox1.Enabled = False
            Button2.Enabled = False
            Button4.Enabled = False
            Label8.Visible = True
            DataGridView1.Visible = False
            Dim sqlconsulta As String

            If TextBox2.Text <> "" Then
                sqlconsulta = "SELECT * FROM proveedor where identificacion = " + TextBox2.Text
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
                    MessageBox.Show("El proveedor no existe, Vuelva a intentarlo")
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    TextBox3.Text = ""
                    TextBox4.Text = ""
                    TextBox5.Text = ""
                    ComboBox1.Text = ""
                Else
                    For Each row As DataRow In dt.Rows
                        TextBox1.Text = CStr(row("nombre"))
                        TextBox2.Text = CStr(row("identificacion"))
                        TextBox3.Text = CStr(row("telefono"))
                        TextBox4.Text = CStr(row("direccion"))
                        ComboBox1.Text = CStr(row("tipo_proveedor"))
                        TextBox5.Text = CStr(row("correo"))
                        TextBox2.Enabled = False

                        Button3.Text = "Nueva Consulta"
                        Label8.Visible = False
                        Button6.Enabled = False
                        Button2.Enabled = True
                    Next
                    SQLConn.Close()
                    Button4.Enabled = True
                End If
                'DataGridView1.Visible = True
                'DataGridView1.DataSource = dt

            End If
        Else
            TextBox2.Enabled = True
            Button3.Text = "Consultar"
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            ComboBox1.Text = ""
            Button2.Enabled = False
            Label8.Visible = True
            Button6.Enabled = True
            Button4.Enabled = False
        End If
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False

    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub BindingNavigatorMoveNextItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button2.Enabled = True
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Label8.Visible = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = False
        ComboBox1.Enabled = True
        Button4.Enabled = False
        DataGridView1.Visible = False

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Label8.Visible = False
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""

        Button4.Enabled = False
        DataGridView1.Visible = True
        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM proveedor limit 100"

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

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If (Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub
End Class
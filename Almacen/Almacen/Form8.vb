Imports System.Data.SQLite
Public Class Form8

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True

        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "Consultar cliente" Then
            If TextBox1.Text <> "" Then
                Dim sqlconsulta As String
                sqlconsulta = "SELECT cedula FROM cliente where cedula=" + TextBox1.Text

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
                    MessageBox.Show("El cliente no existe, debe crearlo")
                    TextBox1.Enabled = False
                    TextBox1.Text = ""
                    Button5.Enabled = True
                Else
                    For Each row As DataRow In dt.Rows
                        TextBox1.Text = CStr(row("cedula"))
                        TextBox1.Enabled = False
                        TextBox2.Enabled = True
                        Button8.Enabled = True
                        Button5.Enabled = False
                    Next
                    Button7.Enabled = False
                    SQLConn.Close()
                    Button4.Enabled = True
                    Button3.Enabled = True
                End If


                'ComboBox1.DataSource = ds.Tables(0)
                'ComboBox1.DisplayMember = ds.Tables(0).Columns(0).Caption.ToString
                ''ComboBox1.ValueMember = "id"
                'ComboBox1.Text = ""
                'ComboBox1.Enabled = True
                'TextBox1.Enabled = False
                'TextBox2.Enabled = True
                'TextBox3.Enabled = True
                'Button2.Text = "Nueva Consulta"
                'SQLConn.Close()
            End If
        Else
        End If
    End Sub

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True

        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button1.Enabled = True
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.VentaToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If (Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form5.Show()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If Button8.Text = "Consultar Producto" Then
            If TextBox2.Text <> "" Then
                Dim sqlconsulta As String
                Dim sqlconsulta2 As String
                sqlconsulta2 = "SELECT valor FROM producto where codigo='" + TextBox2.Text + "' order by talla asc"

                Dim connection2 As String = "Data Source=Almacen.db;Version=3;New=False;Compress=True;"

                Dim SQLConn2 As New SQLiteConnection(connection2)
                Dim SQLcmd2 As New SQLiteCommand(SQLConn2)
                SQLcmd2.CommandText = sqlconsulta2
                'Dim SQLdr As SQLiteDataReader
                If SQLConn2.State <> ConnectionState.Open Then
                    SQLConn2.Open()
                End If
                Dim dt2 As New DataTable()
                Dim ds2 As New DataSet()
                Dim da2 As New SQLiteDataAdapter(SQLcmd2)
                da2.Fill(dt2)

                For Each row As DataRow In dt2.Rows
                    TextBox3.Text = CStr(row("valor"))
                Next
                If dt2.Rows.Count <= 0 Then
                    MessageBox.Show("El codigo del producto no existe, verifique el codigo")
                    TextBox2.Focus()
                    TextBox2.Text = ""
                Else


                    sqlconsulta = "SELECT talla FROM producto where codigo='" + TextBox2.Text + "' order by talla asc"

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
                    TextBox2.Enabled = False
                    TextBox3.Enabled = False
                    ComboBox1.Enabled = True
                    ComboBox2.Enabled = True
                    TextBox4.Enabled = True
                    Button6.Enabled = True
                    Button7.Enabled = True

                    Button2.Text = "Nueva Consulta"
                    SQLConn.Close()
                End If
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM usuarios where login = '" + TextBox1.Text + "'"

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
            MessageBox.Show("el usuario no existe, por favor cree el usuario")
            Button6.Enabled = True
        Else
            Dim campos As String() = New String(dt.Rows.Count - 1) {}
            For i As Integer = 0 To dt.Rows.Count - 1

                If DirectCast(dt.Rows(i)("login"), [String]).Equals(TextBox1.Text) And DirectCast(dt.Rows(i)("password"), [String]).Equals(TextBox2.Text) Then
                    Form2.Show()
                    Me.Finalize()
                End If
            Next
            SQLConn.Close()
        End If
    End Sub
End Class
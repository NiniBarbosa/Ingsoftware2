Imports System.Data.SQLite

Public Class Form5
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim salir As DialogResult
        salir = MessageBox.Show("¿Desea Salir?", "Salir de la aplicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If (salir = DialogResult.Yes) Then
            Me.Close()
            Form2.ClienteToolStripMenuItem.Enabled = True
        End If
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Button1.Enabled = False
        'Button2.Enabled = True
        'Button3.Enabled = True
        'Button4.Enabled = True
        'Button5.Enabled = True
        'Button6.Enabled = True

        'TextBox1.Enabled = False
        'TextBox2.Enabled = False
        'TextBox3.Enabled = False
        'TextBox4.Enabled = False
        'TextBox5.Enabled = False
        DataGridView1.Visible = False
        Dim SQLSelect As String

        SQLSelect = "INSERT INTO cliente (nombre,apellido,cedula,telefono,direccion)  VALUES(" + "'" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "');"
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
        MessageBox.Show("Ingreso de cliente correctamente")
    End Sub

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InventarioDataSet.cliente' Puede moverla o quitarla según sea necesario.
        'Me.ClienteTableAdapter.Fill(Me.InventarioDataSet.cliente)
        'TextBox1.Enabled = False
        'TextBox2.Enabled = False
        'TextBox3.Enabled = False
        'TextBox4.Enabled = False
        'TextBox5.Enabled = False
        'Button1.Enabled = False
        'Button2.Enabled = True
        'Button3.Enabled = True
        'Button4.Enabled = True
        'Button5.Enabled = True
        'Button6.Enabled = True

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Form15.Show()
        'Form9.Show()
        'Form9.WindowState = FormWindowState.Maximized
        DataGridView1.Visible = True
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

    Private Sub BindingNavigatorAddNewItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'TextBox1.Enabled = True
        'TextBox2.Enabled = True
        'TextBox3.Enabled = True
        'TextBox4.Enabled = True
        'TextBox5.Enabled = True

        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
    End Sub

    Private Sub BindingNavigatorMovePreviousItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Button1.Enabled = True
        'Button2.Enabled = False
        'Button3.Enabled = False
        'Button4.Enabled = False
        'Button5.Enabled = False
        'Button6.Enabled = False
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DataGridView1.Visible = False

        Dim vistaFilaActual As DataRowView
        Dim NL As String = Environment.NewLine
        If (MessageBox.Show(("¿Esta seguro de eliminar el Cliente? " & NL), "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            vistaFilaActual = BindingSource1.Current
            vistaFilaActual.Row.Delete()
            BindingSource1.Position = BindingSource1.Count - 1
            If (InventarioDataSet.HasChanges()) Then
                Me.ClienteTableAdapter.Update(Me.InventarioDataSet.cliente)
                MessageBox.Show("Cliente eliminado correctamente")
            End If
            'Ir al primer resgistro de la tabla
            BindingSource1.Position = 0
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        DataGridView1.Visible = False

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = False
        TextBox4.Enabled = True
        TextBox5.Enabled = True

        Dim SQLSelect As String
        SQLSelect = "UPDATE cliente SET nombre='" + TextBox1.Text + "', apellido='" + TextBox2.Text + "', telefono='" + TextBox4.Text + "', direccion='" + TextBox5.Text + "' WHERE cedula='" + TextBox3.Text + "'"
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

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        DataGridView1.Visible = False

        Dim buscar, criterio As String
        buscar = InputBox("Digite el numero del cedula del cliente que desea buscar", "Buscar")
        criterio = buscar


        Dim sqlconsulta As String
        sqlconsulta = "SELECT * FROM cliente where cedula = " + criterio
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
        'DataGridView1.Visible = True
        'DataGridView1.DataSource = dt

        For Each row As DataRow In dt.Rows
            TextBox1.Text = CStr(row("nombre"))
            TextBox2.Text = CStr(row("apellido"))
            TextBox3.Text = CStr(row("cedula"))
            TextBox4.Text = CStr(row("telefono"))
            TextBox5.Text = CStr(row("direccion"))
        Next
        Button2.Visible = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
    End Sub
End Class
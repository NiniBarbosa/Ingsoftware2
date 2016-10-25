<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form11
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.inventarioDataSet = New Almacen.inventarioDataSet()
        Me.ingreso_mercanciaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ingreso_mercanciaTableAdapter = New Almacen.inventarioDataSetTableAdapters.ingreso_mercanciaTableAdapter()
        CType(Me.inventarioDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ingreso_mercanciaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.ingreso_mercanciaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Almacen.Report3.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(571, 385)
        Me.ReportViewer1.TabIndex = 0
        '
        'inventarioDataSet
        '
        Me.inventarioDataSet.DataSetName = "inventarioDataSet"
        Me.inventarioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ingreso_mercanciaBindingSource
        '
        Me.ingreso_mercanciaBindingSource.DataMember = "ingreso_mercancia"
        Me.ingreso_mercanciaBindingSource.DataSource = Me.inventarioDataSet
        '
        'ingreso_mercanciaTableAdapter
        '
        Me.ingreso_mercanciaTableAdapter.ClearBeforeFill = True
        '
        'Form11
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 385)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form11"
        Me.Text = "Form11"
        CType(Me.inventarioDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ingreso_mercanciaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ingreso_mercanciaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents inventarioDataSet As Almacen.inventarioDataSet
    Friend WithEvents ingreso_mercanciaTableAdapter As Almacen.inventarioDataSetTableAdapters.ingreso_mercanciaTableAdapter
End Class

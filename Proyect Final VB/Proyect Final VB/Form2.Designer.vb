<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Label1 = New Label()
        txtUnit1 = New TextBox()
        txtUnit2 = New TextBox()
        Label2 = New Label()
        txtUnit4 = New TextBox()
        Label3 = New Label()
        txtUnit3 = New TextBox()
        Label4 = New Label()
        txtUnit6 = New TextBox()
        Label5 = New Label()
        txtUnit5 = New TextBox()
        Label6 = New Label()
        dataGridViewStudentsGrades = New DataGridView()
        btnFilter = New Button()
        btnExportGrd = New Button()
        btnDelete = New Button()
        btnAddin = New Button()
        btnBack = New Button()
        CType(dataGridViewStudentsGrades, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(42, 75)
        Label1.Name = "Label1"
        Label1.Size = New Size(35, 15)
        Label1.TabIndex = 0
        Label1.Text = "Unit1"
        ' 
        ' txtUnit1
        ' 
        txtUnit1.Location = New Point(110, 75)
        txtUnit1.Name = "txtUnit1"
        txtUnit1.Size = New Size(100, 23)
        txtUnit1.TabIndex = 1
        ' 
        ' txtUnit2
        ' 
        txtUnit2.Location = New Point(110, 119)
        txtUnit2.Name = "txtUnit2"
        txtUnit2.Size = New Size(100, 23)
        txtUnit2.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(42, 119)
        Label2.Name = "Label2"
        Label2.Size = New Size(35, 15)
        Label2.TabIndex = 2
        Label2.Text = "Unit2"
        ' 
        ' txtUnit4
        ' 
        txtUnit4.Location = New Point(110, 206)
        txtUnit4.Name = "txtUnit4"
        txtUnit4.Size = New Size(100, 23)
        txtUnit4.TabIndex = 7
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(42, 206)
        Label3.Name = "Label3"
        Label3.Size = New Size(35, 15)
        Label3.TabIndex = 6
        Label3.Text = "Unit4"
        ' 
        ' txtUnit3
        ' 
        txtUnit3.Location = New Point(110, 162)
        txtUnit3.Name = "txtUnit3"
        txtUnit3.Size = New Size(100, 23)
        txtUnit3.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(42, 162)
        Label4.Name = "Label4"
        Label4.Size = New Size(35, 15)
        Label4.TabIndex = 4
        Label4.Text = "Unit3"
        ' 
        ' txtUnit6
        ' 
        txtUnit6.Location = New Point(110, 284)
        txtUnit6.Name = "txtUnit6"
        txtUnit6.Size = New Size(100, 23)
        txtUnit6.TabIndex = 11
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(42, 284)
        Label5.Name = "Label5"
        Label5.Size = New Size(35, 15)
        Label5.TabIndex = 10
        Label5.Text = "Unit6"
        ' 
        ' txtUnit5
        ' 
        txtUnit5.Location = New Point(110, 240)
        txtUnit5.Name = "txtUnit5"
        txtUnit5.Size = New Size(100, 23)
        txtUnit5.TabIndex = 9
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(42, 240)
        Label6.Name = "Label6"
        Label6.Size = New Size(35, 15)
        Label6.TabIndex = 8
        Label6.Text = "Unit5"
        ' 
        ' dataGridViewStudentsGrades
        ' 
        dataGridViewStudentsGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewStudentsGrades.Location = New Point(356, 54)
        dataGridViewStudentsGrades.Name = "dataGridViewStudentsGrades"
        dataGridViewStudentsGrades.Size = New Size(321, 167)
        dataGridViewStudentsGrades.TabIndex = 12
        ' 
        ' btnFilter
        ' 
        btnFilter.Location = New Point(573, 330)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(113, 55)
        btnFilter.TabIndex = 18
        btnFilter.Text = "Students in summative"
        btnFilter.UseVisualStyleBackColor = True
        ' 
        ' btnExportGrd
        ' 
        btnExportGrd.Location = New Point(454, 330)
        btnExportGrd.Name = "btnExportGrd"
        btnExportGrd.Size = New Size(113, 55)
        btnExportGrd.TabIndex = 17
        btnExportGrd.Text = "Export Files"
        btnExportGrd.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(318, 330)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(113, 55)
        btnDelete.TabIndex = 16
        btnDelete.Text = "DELTE GRADE"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnAddin
        ' 
        btnAddin.Location = New Point(170, 330)
        btnAddin.Name = "btnAddin"
        btnAddin.Size = New Size(113, 55)
        btnAddin.TabIndex = 15
        btnAddin.Text = "ADD"
        btnAddin.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(22, 383)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(113, 55)
        btnBack.TabIndex = 19
        btnBack.Text = "Back to Regist"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.MistyRose
        ClientSize = New Size(800, 450)
        Controls.Add(btnBack)
        Controls.Add(btnFilter)
        Controls.Add(btnExportGrd)
        Controls.Add(btnDelete)
        Controls.Add(btnAddin)
        Controls.Add(dataGridViewStudentsGrades)
        Controls.Add(txtUnit6)
        Controls.Add(Label5)
        Controls.Add(txtUnit5)
        Controls.Add(Label6)
        Controls.Add(txtUnit4)
        Controls.Add(Label3)
        Controls.Add(txtUnit3)
        Controls.Add(Label4)
        Controls.Add(txtUnit2)
        Controls.Add(Label2)
        Controls.Add(txtUnit1)
        Controls.Add(Label1)
        Name = "Form2"
        Text = "Form2"
        CType(dataGridViewStudentsGrades, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtUnit1 As TextBox
    Friend WithEvents txtUnit2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUnit4 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUnit3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtUnit6 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtUnit5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dataGridViewStudentsGrades As DataGridView
    Friend WithEvents btnFilter As Button
    Friend WithEvents btnExportGrd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnAddin As Button
    Friend WithEvents btnBack As Button
End Class

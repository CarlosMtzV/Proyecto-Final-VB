<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        txtRegistrationNumber = New TextBox()
        txtName = New TextBox()
        Label2 = New Label()
        txtLastname = New TextBox()
        Label3 = New Label()
        txtPhone = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        dataGridViewStudents = New DataGridView()
        btnAdd = New Button()
        btnDelete = New Button()
        btnExport = New Button()
        btnGrade = New Button()
        majorbox = New ComboBox()
        Label6 = New Label()
        CType(dataGridViewStudents, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(28, 83)
        Label1.Name = "Label1"
        Label1.Size = New Size(117, 15)
        Label1.TabIndex = 0
        Label1.Text = "Registration Number"
        ' 
        ' txtRegistrationNumber
        ' 
        txtRegistrationNumber.Location = New Point(111, 101)
        txtRegistrationNumber.Name = "txtRegistrationNumber"
        txtRegistrationNumber.Size = New Size(100, 23)
        txtRegistrationNumber.TabIndex = 1
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(111, 142)
        txtName.Name = "txtName"
        txtName.Size = New Size(100, 23)
        txtName.TabIndex = 3
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(28, 142)
        Label2.Name = "Label2"
        Label2.Size = New Size(39, 15)
        Label2.TabIndex = 2
        Label2.Text = "Name"
        ' 
        ' txtLastname
        ' 
        txtLastname.Location = New Point(111, 183)
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(100, 23)
        txtLastname.TabIndex = 5
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(28, 183)
        Label3.Name = "Label3"
        Label3.Size = New Size(63, 15)
        Label3.TabIndex = 4
        Label3.Text = "Last Name"
        ' 
        ' txtPhone
        ' 
        txtPhone.Location = New Point(111, 221)
        txtPhone.Name = "txtPhone"
        txtPhone.Size = New Size(100, 23)
        txtPhone.TabIndex = 7
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(28, 221)
        Label4.Name = "Label4"
        Label4.Size = New Size(41, 15)
        Label4.TabIndex = 6
        Label4.Text = "Phone"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(28, 269)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 15)
        Label5.TabIndex = 8
        Label5.Text = "Major"
        ' 
        ' dataGridViewStudents
        ' 
        dataGridViewStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dataGridViewStudents.Location = New Point(377, 75)
        dataGridViewStudents.Name = "dataGridViewStudents"
        dataGridViewStudents.Size = New Size(240, 150)
        dataGridViewStudents.TabIndex = 10
        ' 
        ' btnAdd
        ' 
        btnAdd.Location = New Point(169, 327)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(113, 55)
        btnAdd.TabIndex = 11
        btnAdd.Text = "ADD"
        btnAdd.UseVisualStyleBackColor = True
        ' 
        ' btnDelete
        ' 
        btnDelete.Location = New Point(317, 327)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(113, 55)
        btnDelete.TabIndex = 12
        btnDelete.Text = "DELTE ROW"
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' btnExport
        ' 
        btnExport.Location = New Point(453, 327)
        btnExport.Name = "btnExport"
        btnExport.Size = New Size(113, 55)
        btnExport.TabIndex = 13
        btnExport.Text = "Export Files"
        btnExport.UseVisualStyleBackColor = True
        ' 
        ' btnGrade
        ' 
        btnGrade.Location = New Point(572, 327)
        btnGrade.Name = "btnGrade"
        btnGrade.Size = New Size(113, 55)
        btnGrade.TabIndex = 14
        btnGrade.Text = "FORM GRADE"
        btnGrade.UseVisualStyleBackColor = True
        ' 
        ' majorbox
        ' 
        majorbox.FormattingEnabled = True
        majorbox.Items.AddRange(New Object() {"Informatica ", "Industrial", "Mecanica", "Gestion Emp", "Electronica"})
        majorbox.Location = New Point(115, 270)
        majorbox.Name = "majorbox"
        majorbox.Size = New Size(121, 23)
        majorbox.TabIndex = 15
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(226, 20)
        Label6.Name = "Label6"
        Label6.Size = New Size(135, 15)
        Label6.TabIndex = 16
        Label6.Text = "Registration Of Students"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.SeaShell
        ClientSize = New Size(800, 450)
        Controls.Add(Label6)
        Controls.Add(majorbox)
        Controls.Add(btnGrade)
        Controls.Add(btnExport)
        Controls.Add(btnDelete)
        Controls.Add(btnAdd)
        Controls.Add(dataGridViewStudents)
        Controls.Add(Label5)
        Controls.Add(txtPhone)
        Controls.Add(Label4)
        Controls.Add(txtLastname)
        Controls.Add(Label3)
        Controls.Add(txtName)
        Controls.Add(Label2)
        Controls.Add(txtRegistrationNumber)
        Controls.Add(Label1)
        Name = "Form1"
        Text = "Form1"
        CType(dataGridViewStudents, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtRegistrationNumber As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dataGridViewStudents As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnGrade As Button
    Friend WithEvents majorbox As ComboBox
    Friend WithEvents Label6 As Label

End Class

Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.IO

Public Class Form1
    Public Shared students As New List(Of Student)()

    Public Sub New()
        InitializeComponent()

        InitializeDataGridView()
    End Sub

    Private Sub InitializeDataGridView()
        ' Agregar las columnas al DataGridView
        dataGridViewStudents.ColumnCount = 6
        dataGridViewStudents.Columns(0).Name = "Registration Number"
        dataGridViewStudents.Columns(1).Name = "Name"
        dataGridViewStudents.Columns(2).Name = "LastName"
        dataGridViewStudents.Columns(3).Name = "Phone"
        dataGridViewStudents.Columns(4).Name = "Major"
        dataGridViewStudents.Columns(5).Name = "Email"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            ' Obtener datos del estudiante del formulario
            Dim registrationNumber As String = txtRegistrationNumber.Text
            Dim name As String = txtName.Text
            Dim lastname As String = txtLastname.Text
            Dim phone As String = txtPhone.Text
            Dim major As String = majorbox.Text

            ' Verificar si alguno de los campos está vacío
            If String.IsNullOrWhiteSpace(registrationNumber) OrElse
               String.IsNullOrWhiteSpace(name) OrElse
               String.IsNullOrWhiteSpace(lastname) OrElse
               String.IsNullOrWhiteSpace(phone) OrElse
               String.IsNullOrWhiteSpace(major) Then
                ' Mostrar mensaje de advertencia
                MessageBox.Show("Please fill in all the fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Generar el email
            Dim email As String = $"{registrationNumber}@monclova.tecnm.mx"

            ' Crear un nuevo objeto Student
            Dim newStudent As New Student(registrationNumber, name, lastname, phone, major, email)

            ' Agregar el estudiante a la lista
            students.Add(newStudent)

            ' Limpiar los campos del formulario
            ClearFields()

            ' Actualizar el DataGridView
            UpdateDataGridView()


            ' Mostrar la contraseña de email en un MessageBox
            MessageBox.Show("The email password has been generated.", "Email Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra y mostrar un mensaje de error
            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        txtRegistrationNumber.Clear()
        txtName.Clear()
        txtPhone.Clear()
        txtLastname.Clear()
    End Sub

    Private Sub UpdateDataGridView()
        ' Limpiar el DataGridView
        dataGridViewStudents.Rows.Clear()

        ' Agregar las columnas necesarias al DataGridView si es necesario
        If students.Count > dataGridViewStudents.Columns.Count Then
            For i As Integer = dataGridViewStudents.Columns.Count To students.Count - 1
                dataGridViewStudents.Columns.Add($"ExtraColumn{i}", $"ExtraColumn{i}")
            Next
        End If

        ' Agregar cada estudiante al DataGridView
        For Each student In students
            ' Crear una nueva fila para el estudiante
            Dim row As New DataGridViewRow()
            row.CreateCells(dataGridViewStudents)
            row.Cells(0).Value = student.RegistrationNumber
            row.Cells(1).Value = student.Name
            row.Cells(2).Value = student.LastName
            row.Cells(3).Value = student.Phone
            row.Cells(4).Value = student.Major
            row.Cells(5).Value = student.Email

            ' Agregar la fila al DataGridView
            dataGridViewStudents.Rows.Add(row)
        Next
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dataGridViewStudents.SelectedRows.Count > 0 Then
            ' Eliminar las filas seleccionadas del DataGridView y de la lista de estudiantes
            For Each row As DataGridViewRow In dataGridViewStudents.SelectedRows
                Dim registrationNumber As String = row.Cells(0).Value.ToString()

                ' Eliminar de la lista de estudiantes
                students.RemoveAll(Function(s) s.RegistrationNumber = registrationNumber)

                ' Eliminar del DataGridView
                dataGridViewStudents.Rows.Remove(row)
            Next
        Else
            MessageBox.Show("Please select at least one row to delete.")
        End If
    End Sub

    Private Sub SaveAsJson(fileName As String)
        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(students, Newtonsoft.Json.Formatting.Indented)
        File.WriteAllText(fileName, json)
    End Sub

    Private Sub SaveAsExcel(fileName As String)
        Using spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook)
            Dim workbookPart As WorkbookPart = spreadsheetDocument.AddWorkbookPart()
            workbookPart.Workbook = New Workbook()
            Dim sheets As Sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(New Sheets())
            Dim sheetData As SheetData = New SheetData()

            Dim worksheetPart As WorksheetPart = workbookPart.AddNewPart(Of WorksheetPart)()
            worksheetPart.Worksheet = New Worksheet(sheetData)

            Dim sheet As Sheet = New Sheet() With {
                .Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                .SheetId = 1,
                .Name = "Sheet1"
            }
            sheets.Append(sheet)

            Dim headerRow As Row = New Row()
            For Each column As DataGridViewColumn In dataGridViewStudents.Columns
                Dim headerCell As Cell = New Cell() With {
                    .CellValue = New CellValue(column.HeaderText),
                    .DataType = CellValues.String
                }
                headerRow.Append(headerCell)
            Next
            sheetData.Append(headerRow)

            For Each row As DataGridViewRow In dataGridViewStudents.Rows
                If Not row.IsNewRow Then
                    Dim newRow As Row = New Row()
                    For Each cell As DataGridViewCell In row.Cells
                        Dim newCell As Cell = New Cell() With {
                            .CellValue = New CellValue(If(cell.Value?.ToString(), "")),
                            .DataType = CellValues.String
                        }
                        newRow.Append(newCell)
                    Next
                    sheetData.Append(newRow)
                End If
            Next

            workbookPart.Workbook.Save()
        End Using
    End Sub

    Private Sub SaveAsText(fileName As String)
        Using writer As StreamWriter = New StreamWriter(fileName)
            ' Escribir encabezados
            For i As Integer = 0 To dataGridViewStudents.ColumnCount - 1
                writer.Write(dataGridViewStudents.Columns(i).HeaderText)
                If i < dataGridViewStudents.ColumnCount - 1 Then
                    writer.Write(vbTab)
                End If
            Next
            writer.WriteLine()

            For Each row As DataGridViewRow In dataGridViewStudents.Rows
                If Not row.IsNewRow Then
                    For i As Integer = 0 To dataGridViewStudents.ColumnCount - 1
                        writer.Write(If(row.Cells(i).Value?.ToString(), ""))
                        If i < dataGridViewStudents.ColumnCount - 1 Then
                            writer.Write(vbTab)
                        End If
                    Next
                    writer.WriteLine()
                End If
            Next
        End Using
    End Sub

    Private Sub SaveAsPdf(fileName As String)
        Using stream As FileStream = New FileStream(fileName, FileMode.Create)
            Dim pdfDoc
        End Using

    End Sub
End Class

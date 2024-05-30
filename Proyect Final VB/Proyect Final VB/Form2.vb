Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Xml.Serialization
Imports Newtonsoft.Json

Public Class Form2
    Public Shared students As New List(Of Student)()

    Public Sub New()
        InitializeComponent()
        InitializeDataGridView()
        UpdateDataGridView()
    End Sub

    Private Sub UpdateDataGridView()
        dataGridViewStudentsGrades.Rows.Clear()

        For Each student In Form1.students
            Dim row As New DataGridViewRow()
            row.CreateCells(dataGridViewStudentsGrades)
            row.Cells(0).Value = student.RegistrationNumber
            row.Cells(1).Value = student.Name
            row.Cells(2).Value = student.LastName
            For i As Integer = 3 To 10
                row.Cells(i).Value = ""
            Next
            dataGridViewStudentsGrades.Rows.Add(row)
        Next
    End Sub

    Private Sub InitializeDataGridView()
        dataGridViewStudentsGrades.ColumnCount = 11
        dataGridViewStudentsGrades.Columns(0).Name = "Registration Number"
        dataGridViewStudentsGrades.Columns(1).Name = "Name"
        dataGridViewStudentsGrades.Columns(2).Name = "LastName"
        For i As Integer = 3 To 10
            dataGridViewStudentsGrades.Columns(i).Name = $"Unit{i - 2}"
        Next
    End Sub

    Private Sub btnAddin_Click(sender As Object, e As EventArgs) Handles btnAddin.Click
        If String.IsNullOrWhiteSpace(txtUnit1.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnit2.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnit3.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnit4.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnit5.Text) OrElse
           String.IsNullOrWhiteSpace(txtUnit6.Text) Then
            MessageBox.Show("Please fill in all the unit grades.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim unit1, unit2, unit3, unit4, unit5, unit6 As Double

        Try
            If Not Double.TryParse(txtUnit1.Text, unit1) OrElse
               Not Double.TryParse(txtUnit2.Text, unit2) OrElse
               Not Double.TryParse(txtUnit3.Text, unit3) OrElse
               Not Double.TryParse(txtUnit4.Text, unit4) OrElse
               Not Double.TryParse(txtUnit5.Text, unit5) OrElse
               Not Double.TryParse(txtUnit6.Text, unit6) Then
                Throw New FormatException("One or more grades are not valid numbers.")
            End If

            If dataGridViewStudentsGrades.SelectedRows.Count > 0 Then
                For Each row As DataGridViewRow In dataGridViewStudentsGrades.SelectedRows
                    For i As Integer = 3 To 8
                        row.Cells(i).Value = If(i = 3, unit1, If(i = 4, unit2, If(i = 5, unit3, If(i = 6, unit4, If(i = 7, unit5, If(i = 8, unit6, ""))))))

                        Dim sumativas = {unit1, unit2, unit3, unit4, unit5, unit6}.Count(Function(unitGrade) unitGrade < 7)
                        row.Cells(9).Value = sumativas

                        Dim averageGrade = CalculateAverageGrade(unit1, unit2, unit3, unit4, unit5, unit6)
                        row.Cells(10).Value = averageGrade
                    Next
                Next


            Else
                MessageBox.Show("Please select at least one row to add grade.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As FormatException
            MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtUnit1.Clear()
        txtUnit2.Clear()
        txtUnit3.Clear()
        txtUnit4.Clear()
        txtUnit5.Clear()
        txtUnit6.Clear()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dataGridViewStudentsGrades.SelectedRows.Count > 0 Then
            For Each row As DataGridViewRow In dataGridViewStudentsGrades.SelectedRows
                For i As Integer = 3 To 8
                    row.Cells(i).Value = ""
                Next
            Next
        Else
            MessageBox.Show("Please select at least one row to Delete Grade.")
        End If

        ClearFields()
    End Sub

    Private Sub SaveAsJson(fileName As String)
        Dim json = JsonConvert.SerializeObject(students, Formatting.Indented)
        File.WriteAllText(fileName, json)
    End Sub

    Private Sub SaveAsExcel(fileName As String)
        Using spreadsheetDocument As SpreadsheetDocument = spreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook)
            Dim workbookPart As WorkbookPart = spreadsheetDocument.AddWorkbookPart()
            workbookPart.Workbook = New Workbook()
            Dim sheets As Sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(New Sheets())
            Dim sheetData As New SheetData()

            Dim worksheetPart As WorksheetPart = workbookPart.AddNewPart(Of WorksheetPart)()
            worksheetPart.Worksheet = New Worksheet(sheetData)

            Dim sheet As New Sheet() With {
                .Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                .SheetId = 1,
                .Name = "Sheet1"
            }
            sheets.Append(sheet)

            Dim headerRow As New Row()
            For Each column As DataGridViewColumn In dataGridViewStudentsGrades.Columns
                Dim headerCell As New Cell() With {
                    .CellValue = New CellValue(column.HeaderText),
                    .DataType = CellValues.String
                }
                headerRow.Append(headerCell)
            Next
            sheetData.Append(headerRow)

            For Each row As DataGridViewRow In dataGridViewStudentsGrades.Rows
                If Not row.IsNewRow Then
                    Dim newRow As New Row()
                    For Each cell As DataGridViewCell In row.Cells
                        Dim newCell As New Cell() With {
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
        Using writer As New StreamWriter(fileName)
            ' Escribir encabezados
            For i As Integer = 0 To dataGridViewStudentsGrades.ColumnCount - 1
                writer.Write(dataGridViewStudentsGrades.Columns(i).HeaderText)
                If i < dataGridViewStudentsGrades.ColumnCount - 1 Then
                    writer.Write(vbTab)
                End If
            Next
            writer.WriteLine()

            For Each row As DataGridViewRow In dataGridViewStudentsGrades.Rows
                If Not row.IsNewRow Then
                    For i As Integer = 0 To dataGridViewStudentsGrades.ColumnCount - 1
                        writer.Write(If(row.Cells(i).Value?.ToString(), ""))
                        If i < dataGridViewStudentsGrades.ColumnCount - 1 Then
                            writer.Write(vbTab)
                        End If
                    Next
                    writer.WriteLine()
                End If
            Next
        End Using
    End Sub

    Private Sub SaveAsPdf(fileName As String)
        Using stream As New FileStream(fileName, FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A4)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()

            Dim table As New PdfPTable(dataGridViewStudentsGrades.ColumnCount)
            For Each column As DataGridViewColumn In dataGridViewStudentsGrades.Columns
                table.AddCell(New Phrase(column.HeaderText))
            Next

            For Each row As DataGridViewRow In dataGridViewStudentsGrades.Rows
                If Not row.IsNewRow Then
                    For Each cell As DataGridViewCell In row.Cells
                        table.AddCell(New Phrase(If(cell.Value?.ToString(), "")))
                    Next
                End If
            Next

            pdfDoc.Add(table)
            pdfDoc.Close()
        End Using
    End Sub

    Private Sub SaveAsXml(fileName As String)
        Dim serializer As New XmlSerializer(GetType(List(Of Student)))
        Using writer As New StreamWriter(fileName)
            serializer.Serialize(writer, students)
        End Using
    End Sub

    Private Sub btnExportGrd_Click(sender As Object, e As EventArgs) Handles btnExportGrd.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel Workbook|*.xlsx|Text File|*.txt|JSON File|*.json|PDF File|*.pdf|XML File|*.xml"
        saveFileDialog.Title = "Save Students Data Grade"
        saveFileDialog.FileName = "Students Data Grade"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim extension As String = Path.GetExtension(saveFileDialog.FileName).ToLower()
            Select Case extension
                Case ".xlsx"
                    SaveAsExcel(saveFileDialog.FileName)
                Case ".txt"
                    SaveAsText(saveFileDialog.FileName)
                Case ".json"
                    SaveAsJson(saveFileDialog.FileName)
                Case ".pdf"
                    SaveAsPdf(saveFileDialog.FileName)
                Case ".xml"
                    SaveAsXml(saveFileDialog.FileName)
            End Select
        End If
    End Sub
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim form1 As New Form1()

        ' Mostrar el segundo formulario
        form1.Show()
        ' Ocultar el formulario actual (Form1)
        Me.Hide()
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        Try
            ' Crear una lista temporal para almacenar las filas que cumplen con el criterio
            Dim rowsToKeep As New List(Of DataGridViewRow)()

            ' Recorrer todas las filas del DataGridView
            For Each row As DataGridViewRow In dataGridViewStudentsGrades.Rows
                ' Obtener las calificaciones de las unidades
                Dim unit1 As Double = Convert.ToDouble(row.Cells(3).Value)
                Dim unit2 As Double = Convert.ToDouble(row.Cells(4).Value)
                Dim unit3 As Double = Convert.ToDouble(row.Cells(5).Value)
                Dim unit4 As Double = Convert.ToDouble(row.Cells(6).Value)
                Dim unit5 As Double = Convert.ToDouble(row.Cells(7).Value)
                Dim unit6 As Double = Convert.ToDouble(row.Cells(8).Value)

                ' Contar cuántas unidades son menores a 7
                Dim sumativas As Integer = 0
                If unit1 < 7 Then sumativas += 1
                If unit2 < 7 Then sumativas += 1
                If unit3 < 7 Then sumativas += 1
                If unit4 < 7 Then sumativas += 1
                If unit5 < 7 Then sumativas += 1
                If unit6 < 7 Then sumativas += 1

                ' Si tiene al menos una unidad con calificación menor a 7, mantener la fila
                If sumativas > 0 Then
                    rowsToKeep.Add(row)
                End If
            Next

            ' Limpiar el DataGridView y volver a agregar solo las filas que cumplen con el criterio
            dataGridViewStudentsGrades.Rows.Clear()

            For Each row As DataGridViewRow In rowsToKeep
                dataGridViewStudentsGrades.Rows.Add(row)
            Next

            MessageBox.Show("Filter applied successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            RemoveFirstEmptyRow()

            ' Calcular total alumnos en sumative
            Dim totalStudents As Integer = GetTotalStudents()
            MessageBox.Show($"Total students in Sumative is : {totalStudents}")
        Catch ex As Exception
            ' Manejar cualquier excepción que ocurra y mostrar un mensaje de error
            MessageBox.Show("An unexpected error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub RegistComplete()
        MessageBox.Show($"Register Complete Correctly")
    End Sub

    ' Método que no recibe parámetros pero devuelve algo
    Private Function GetTotalStudents() As Integer
        Return dataGridViewStudentsGrades.Rows.Count - 1
    End Function

    ' Método que recibe parámetros y devuelve algo
    Private Function CalculateAverageGrade(unit1 As Double, unit2 As Double, unit3 As Double, unit4 As Double, unit5 As Double, unit6 As Double) As Double
        Dim totalUnits As Double = 6
        Dim sumGrades As Double = unit1 + unit2 + unit3 + unit4 + unit5 + unit6
        Return sumGrades / totalUnits
    End Function

    Private Sub RemoveFirstEmptyRow()
        For Each row As DataGridViewRow In dataGridViewStudentsGrades.Rows
            Dim isEmpty As Boolean = True

            For Each cell As DataGridViewCell In row.Cells
                If cell.Value IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(cell.Value.ToString()) Then
                    isEmpty = False
                    Exit For
                End If
            Next

            If isEmpty Then
                dataGridViewStudentsGrades.Rows.Remove(row)
                Exit For ' Salir del bucle una vez que se haya eliminado la primera fila vacía
            End If
        Next
    End Sub
End Class
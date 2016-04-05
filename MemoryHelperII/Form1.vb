Public Class Form1
    Dim StrMemoryConnection As String = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " &
    Application.StartupPath & "\memory.mdb"

    Dim strSQLMem As String               'I want all records and all fields from the Memory Table
    Dim dtMem As New DataTable()          'Global DataTable - seen by all su broutines
    Dim intTotalRows As Integer           'How many rows are there
    Dim intCurrentRow As Integer          'Where I am in the table (which row)

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtMem.Clear()
        strSQLMem = "SELECT * FROM Memory"
        Dim dataAdapter As New OleDb.OleDbDataAdapter(strSQLMem, StrMemoryConnection)

        dataAdapter.Fill(dtMem)
        dataAdapter.Dispose()
        intTotalRows = dtMem.Rows.Count
        intCurrentRow = 0   'index in a data table begins at zero.
        DisplayRecord()
    End Sub

    Private Sub displayRecord()
        Me.txtTitle.Text = CStr(dtMem.Rows(intCurrentRow)("title"))
        Me.txtAuthor.Text = CStr(dtMem.Rows(intCurrentRow)("author"))
        Me.txtPublisher.Text = CStr(dtMem.Rows(intCurrentRow)("publisher"))
        Me.txtStuff.Text = CStr(dtMem.Rows(intCurrentRow)("stuff"))
    End Sub

    Private Sub btnTop_Click(sender As Object, e As EventArgs) Handles btnTop.Click
        intCurrentRow = 0
        displayRecord()
    End Sub

    Private Sub btnBot_Click(sender As Object, e As EventArgs) Handles btnBot.Click
        intCurrentRow = intTotalRows - 1
        displayRecord()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        intCurrentRow = intCurrentRow - 1

        If intCurrentRow < 0 Then
            intCurrentRow = 0
        End If

        displayRecord()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        intCurrentRow = intCurrentRow + 1

        If intCurrentRow = intTotalRows Then
            intCurrentRow = intTotalRows - 1
        End If

        displayRecord()
    End Sub
End Class

Public Class Form1
    ''' <summary>
    ''' declare global variables and path to the database
    ''' </summary>
    Dim StrMemoryConnection As String = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " &
    Application.StartupPath & "\memory.mdb"

    Dim strSQLMem As String               'I want all records and all fields from the Memory Table
    Dim dtMem As New DataTable()          'Global DataTable - seen by all su broutines
    Dim intTotalRows As Integer           'How many rows are there
    Dim intCurrentRow As Integer          'Where I am in the table (which row)

    ''' <summary>
    ''' loads form with a SQL query that conects and allows access to the database
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">loads form with a SQL query that conects and allows access to the database</param>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtMem.Clear()
        strSQLMem = "SELECT * FROM Memory"
        Dim dataAdapter As New OleDb.OleDbDataAdapter(strSQLMem, StrMemoryConnection)

        dataAdapter.Fill(dtMem)
        dataAdapter.Dispose()
        intTotalRows = dtMem.Rows.Count
        intCurrentRow = 0   'index in a data table begins at zero.
        displayRecord()
    End Sub

    ''' <summary>
    ''' populates text fields on the form from database columns
    ''' </summary>
    Private Sub displayRecord()
        Me.txtTitle.Text = CStr(dtMem.Rows(intCurrentRow)("title"))
        Me.txtAuthor.Text = CStr(dtMem.Rows(intCurrentRow)("author"))
        Me.txtPublisher.Text = CStr(dtMem.Rows(intCurrentRow)("publisher"))
        Me.txtStuff.Text = CStr(dtMem.Rows(intCurrentRow)("stuff"))
    End Sub

    ''' <summary>
    ''' tnavigate to top record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">navigate to top record</param>
    Private Sub btnTop_Click(sender As Object, e As EventArgs) Handles btnTop.Click
        intCurrentRow = 0
        displayRecord()
    End Sub

    ''' <summary>
    ''' navigate to bottom record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">navigate to bottom record</param>
    Private Sub btnBot_Click(sender As Object, e As EventArgs) Handles btnBot.Click
        intCurrentRow = intTotalRows - 1
        displayRecord()
    End Sub

    ''' <summary>
    ''' navigate to previous record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">navigate to previous record</param>
    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        intCurrentRow = intCurrentRow - 1

        If intCurrentRow < 0 Then
            intCurrentRow = 0
        End If

        displayRecord()
    End Sub

    ''' <summary>
    ''' navigate to next record
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e">navigate to next record</param>
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        intCurrentRow = intCurrentRow + 1

        If intCurrentRow = intTotalRows Then
            intCurrentRow = intTotalRows - 1
        End If

        displayRecord()
    End Sub
End Class

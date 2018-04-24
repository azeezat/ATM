Public Class Form11
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, currentrow, i, c As Integer

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form11_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.Jet.OLEDB.4.0;"
        'dbsource depends on the location of the database file on your own computer
        dbsource = "Data Source=C:\Users\Azeezat\Desktop\ATM management\atm.mdb;"
        con.ConnectionString = dbprovider & dbsource
        con.Open()
        sql = "SELECT acc_no, amnt FROM master"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count
        i = 0
        While i <> maxrows + 1
            If Label6.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label8.Text = ds.Tables("atm").Rows(i)("amnt")

                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
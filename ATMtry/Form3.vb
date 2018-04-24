Public Class Form3
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.Jet.OLEDB.4.0;"
        'dbsource depends on the location of the database file on your own computer
        dbsource = "Data Source=C:\Users\Azeezat\Desktop\ATM management\atm.mdb;"

        con.ConnectionString = dbprovider & dbsource
        con.Open()
        sql = "SELECT * FROM master"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count
        i = 0
        While i <> maxrows + 1
            If Label6.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label3.Text = ds.Tables("atm").Rows(i)("cust_name")

                Form4.Label3.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form4.Label6.Text = ds.Tables("atm").Rows(i)("acc_no")

                Form9.Label7.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form9.Label6.Text = ds.Tables("atm").Rows(i)("acc_no")

                Form11.Label3.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form11.Label6.Text = ds.Tables("atm").Rows(i)("acc_no")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form4.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form9.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form11.Show()
    End Sub
End Class
Public Class Form4
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds, ds1 As New DataSet
    Dim da, da1 As New OleDb.OleDbDataAdapter
    Dim sql, sql1, srw As String
    Dim maxrows, mr, i, currentrow As Integer
    Public balance, current As Integer
    Dim dot As Date

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.Jet.OLEDB.4.0;"
        'dbsource = "Data Source=C:\Documents and Settings\Kish\My Documents\Visual Studio 2008\Projects\New Folder\atmtry\atm.mdb;"
        dbsource = "Data Source=C:\Users\Azeezat\Desktop\ATM management\atm.mdb;"
        con.ConnectionString = dbprovider & dbsource
        con.Open()
        sql = "SELECT * FROM master"
        sql1 = "SELECT * FROM dailytrans"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, currentrow As Integer
        i = 0
        While i <> maxrows + 1
            If Label6.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                current = ds.Tables("atm").Rows(i)("amnt")

                If TextBox1.Text > current Then
                    MsgBox("Insufficient account balance")
                Else
                    balance = current - TextBox1.Text
                    Dim cb As New OleDb.OleDbCommandBuilder(da)
                    ds.Tables("atm").Rows(i).Item("amnt") = balance
                    da.Update(ds, "atm")
                    MsgBox(TextBox1.Text + " was Withdrawn from your account" + vbNewLine + "New balance is now " + balance.ToString)
                    Me.Close()
                End If
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Form3.Show()
    End Sub
End Class
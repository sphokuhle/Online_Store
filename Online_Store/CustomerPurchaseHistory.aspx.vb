Imports System.Data
Imports System.Data.SqlClient
Public Class CustomerPurchaseHistory
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim command As SqlCommand
        Dim connection As SqlConnection
        Dim reader As SqlDataReader
        Dim commandstring As String



        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")
        commandstring = "SELECT * FROM [Invoice] INNER JOIN ([Products] INNER JOIN [InvoiceProduct] ON [Products].P_Id =[InvoiceProduct].P_Id) ON [InvoiceProduct].Invoice_ID=[Invoice].Invoice_ID"
        command = New SqlCommand(commandstring)
        command.CommandType = CommandType.Text
        command.Connection = connection

        command.Connection.Open()
        command.ExecuteNonQuery()
        reader = command.ExecuteReader(CommandBehavior.CloseConnection)

        HMessage.Text = "<div id='List'><table><tr><td width=150px><b>" & "Customer Identity" & "</td>" & "<td width=150px><b>" & "Invoice Reference" & "</td>" & "<td width=250px><b>" & "Product Name" & "</td>" & "<td width=100px><b>" & "Quantity" & "</td>" & "<td width=100px><b>" & "Price" & "</td>" & "<td width=200px><b>" & "Date Of Purchase" & "</td></tr>"
        If reader.HasRows Then
            Do While reader.Read
                HMessage.Text &= "<tr><td>" & reader("UserId") & "</td>" & "<td>" & reader("InvoiceReference") & "</td>" & "<td>" & reader("Name") & "</td>" & "<td>" & reader("Quantity") & "</td>" & "<td>" & reader("Price") & "</td>" & "<td>" & reader("InvoiceDate") & "</td></tr>"
            Loop
        End If
        HMessage.Text &= "</table></div>"

        command.Connection.Close()
        command.Dispose()
        connection.Dispose()
    End Sub

End Class
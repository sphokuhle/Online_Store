Imports System.Data.SqlClient

Public Class PurchaseRecord
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim command As SqlCommand
        Dim connection As SqlConnection
        Dim reader As SqlDataReader
        Dim commandstring As String

        If Session("username") <> Nothing And Session("level") = "1" Then

            connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")
            'commandstring = "SELECT * FROM [CustomerInvoice] INNER JOIN ([InvoiceProduct] INNER JOIN [Invoice] ON [InvoiceProduct].Invoice_ID = [Invoice].Invoice_ID) ON [CustomerInvoice].P_Id = [InvoiceProduct].P_Id WHERE [Invoice].UserId ='" & Convert.ToInt32(Request.Cookies("UserIDCookie").Value) & "' ORDER BY InvoiceDate DESC;"
            commandstring = "SELECT * FROM [Product] INNER JOIN ([InvoiceProduct] INNER JOIN [Invoice] ON [InvoiceProduct].Invoice_ID = [Invoice].Invoice_ID) ON [Product].P_Id = [InvoiceProduct].P_Id WHERE [Invoice].UserId ='" & Convert.ToInt32(Request.Cookies("UserIDCookie").Value) & "' ORDER BY InvoiceDate DESC;"
            command = New SqlCommand(commandstring)
            command.CommandType = CommandType.Text
            command.Connection = connection

            command.Connection.Open()
            command.ExecuteNonQuery()
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)

            HMessage.Text = "<div id='List'><table><tr><td width=150px><b>" & "Customer Name" & "</td>" & "<td width=150px><b>" & "Invoice Reference" & "</td>" & "<td width=250px><b>" & "Product Name" & "</td>" & "<td width=100px><b>" & "Quantity" & "</td>" & "<td width=100px><b>" & "Total Cost" & "</td>" & "<td width=200px><b>" & "Date Of Purchase" & "</td></tr>"
            If reader.HasRows Then
                Do While reader.Read
                    HMessage.Text &= "<tr><td>" & Session("username").ToString & "</td>" & "<td>" & reader("InvoiceReference") & "</td>" & "<td>" & reader("Name") & "</td>" & "<td>" & reader("ProductQuantity") & "</td>" & "<td>" & reader("TotalPrice") & "</td>" & "<td>" & reader("InvoiceDate") & "</td></tr>"
                Loop
            End If
            HMessage.Text &= "</table></div>"

            command.Connection.Close()
            command.Dispose()
            connection.Dispose()

        Else
            Response.Redirect("Login.aspx")
        End If


    End Sub

End Class
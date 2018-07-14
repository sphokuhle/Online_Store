Imports System.Data
Imports System.Data.SqlClient
Public Class DeleteProduct
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Protected Sub cmdDelete_Click(sender As Object, e As EventArgs) Handles cmdDelete.Click
        Try
            Dim SelectedProductID As Integer = CInt(Request.QueryString("P_Id").ToString())
            Dim Connection As SqlConnection
            Dim Command As SqlCommand

            Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")

            Dim CommandString As String
            CommandString = "DELETE FROM [Product], [InvoiceProduct] WHERE P_Id =" & SelectedProductID & ";"

            Command = New SqlCommand(CommandString)
            Command.CommandType = CommandType.Text
            Command.Connection = Connection
            Command.Connection.Open()

            Command.ExecuteNonQuery()

            Command.Connection.Close()

            message.Text = "Product has been deleted"
            cmdDelete.Enabled = False
            message.Visible = True
            Response.Redirect("ProductList.aspx")
        Catch ex As Exception
            message.Text = "Error occured while trying to delete product"
            message.Visible = True
        End Try
    End Sub
End Class
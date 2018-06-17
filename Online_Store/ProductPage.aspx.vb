Imports System.Data
Imports System.Data.SqlClient

Public Class ProductPage
    Inherits System.Web.UI.Page

    Private Connection As SqlConnection
    Private Command As SqlCommand
    Private Reader As SqlDataReader
    Private CommandString As String
    Private Prod_ID As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            Prod_ID = Request.QueryString("P_Id").ToString()
            Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")
            CommandString = "Select * From [Product] where P_Id=" & Prod_ID & ";"

            Command = New SqlCommand(CommandString)

            Command.CommandType = CommandType.Text

            Command.Connection = Connection

            Command.Connection.Open()

            Command.ExecuteNonQuery()

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)
            Display.Text = "<table >"
            If Reader.HasRows Then
                Do While Reader.Read
                    Display.Text &= "<tr><td><img src=" & Reader("ImgLocation") & "</td>"
                    Display.Text &= "<td><p>Product:" & Reader("P_Id") & "</br>" & Reader("Name") & "<br>Full Description: " & Reader("LongDescription") & " </br>Price: R" & Reader("Price") & "</br>Quatity on hand:" & Reader("Quantity") & "</p></td></tr>"
                Loop
            End If
            Display.Text &= "</table>"
            Command.Connection.Close()
            Command.Dispose()
            Connection.Dispose()


        End If
    End Sub

End Class
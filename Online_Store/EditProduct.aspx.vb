Imports System.Data
Imports System.Data.SqlClient

Public Class EditProduct
    Inherits System.Web.UI.Page

    Private imgLoc As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username") Is Nothing Then
            Response.Redirect("Login.aspx")
        Else
            If Not Page.IsPostBack Then
                Dim Connection As SqlConnection
                Dim Command As SqlCommand
                Dim Reader As SqlDataReader
                Dim Prod_ID As Integer


                Prod_ID = Request.QueryString("P_Id").ToString()
                Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")
                Dim CommandString As String = "Select * From [Product] where P_Id=" & Prod_ID & ";"

                Command = New SqlCommand(CommandString)

                Command.CommandType = CommandType.Text

                Command.Connection = Connection

                Command.Connection.Open()

                Command.ExecuteNonQuery()

                Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

                If Reader.HasRows Then
                    Do While Reader.Read

                        txtName.Text = Reader("Name")
                        txtPrice.Text = Reader("Price")
                        txtQuantity.Text = Reader("Quantity")

                        imgLoc = Reader("ImgLocation")
                    Loop
                End If
                Command.Connection.Close()
                Command.Dispose()
                Connection.Dispose()


            End If
        End If
    End Sub

    Protected Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Try
            Dim SelectedProductID As Integer = CInt(Request.QueryString("P_Id").ToString())
            Dim Connection As SqlConnection
            Dim Command As SqlCommand
            Dim Loc As String = """" & "/Products/" & Session("userId") & "/Product_Images/"

            Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")

            Dim CommandString As String
            If txtImageUploadAdd.HasFile Then
                CommandString = "UPDATE [Product] SET ImgLocation='" & Loc & txtImageUploadAdd.FileName & """" & "', Name='" & txtName.Text & "', Price='" & txtPrice.Text & "',Quantity='" & txtQuantity.Text & "' WHERE P_Id=" & SelectedProductID & ";"
            Else
                CommandString = "UPDATE [Product] SET ImgLocation='" & imgLoc & "', Name='" & txtName.Text & "', Price='" & txtPrice.Text & "',Quantity='" & txtQuantity.Text & "' WHERE P_Id=" & SelectedProductID & ";"
            End If


            Command = New SqlCommand(CommandString)
            Command.CommandType = CommandType.Text
            Command.Connection = Connection
            Command.Connection.Open()

            Command.ExecuteNonQuery()

            Command.Connection.Close()

            message.Visible = True
            message.ForeColor = Drawing.Color.Red
            message.Text = "Succefully updated"
        Catch ex As Exception
            message.Visible = True
            message.ForeColor = Drawing.Color.Red
            message.Text = "Error occured while updating"
        End Try
    End Sub
End Class
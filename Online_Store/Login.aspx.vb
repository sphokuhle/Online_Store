Imports System.Data
Imports System.Data.SqlClient

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim command As SqlCommand
        Dim connection As SqlConnection
        Dim reader As SqlDataReader
        Dim tempusername As String = txtUser.Text
        Dim temppassword As String = txtPass.Text

        connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")

        Dim commandstring As String
        commandstring = "SELECT * FROM [User] WHERE username ='" & tempusername & "' OR Email = '" & tempusername & "';"
        command = New SqlCommand(commandstring)
        command.CommandType = CommandType.Text
        command.Connection = connection

        command.Connection.Open()
        command.ExecuteNonQuery()
        reader = command.ExecuteReader(CommandBehavior.CloseConnection)

        If reader.HasRows Then
            Do While reader.Read
                If Not (Secrecy.HashPassword(temppassword) = reader("Password")) Then
                    Label.Visible = True
                    Label.ForeColor = Drawing.Color.Red
                    Label.Text = "username/password is incorrect"
                    Exit Sub
                End If

                Dim UserIDCookie As New HttpCookie("UserIDCookie", reader("UserId"))
                Response.Cookies.Add(UserIDCookie)

                Session.Add("username", reader("username"))
                Session.Add("level", reader("level"))
                Session.Add("userId", reader("UserId"))

            Loop
            Response.Redirect("productlist.aspx")
            command.Connection.Close()
            command.Dispose()
            connection.Dispose()

        Else
            Label.Visible = True
            Label.ForeColor = Drawing.Color.Red
            Label.Text = "username/password is incorrect"

            txtUser.Text = ""
            txtPass.Text = ""
        End If
    End Sub
End Class
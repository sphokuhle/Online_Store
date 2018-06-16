Imports System.Data
Imports System.Data.SqlClient

Public Class PasswordReset
    Inherits System.Web.UI.Page

    Private check As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        Dim command As SqlCommand
        Dim connection As SqlConnection
        Dim tempusername As String = txtUsername.Text
        Dim temppassword As String = txtCurrentPass.Text
        Dim tempNewpassword As String = txtConfirm.Text()
        Dim Hashedpassword = Secrecy.HashPassword(temppassword)
        Dim NewHashedpassword = Secrecy.HashPassword(tempNewpassword)
        Dim commandstring As String
        Dim reader As SqlDataReader

        valid(tempusername, temppassword)

        If (check = "correct") Then
            connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")
            commandstring = "UPDATE [User] SET Password='" & NewHashedpassword & "' WHERE Username ='" & tempusername & "'  AND Password ='" & Hashedpassword & "' "
            command = New SqlCommand(commandstring)
            command.CommandType = CommandType.Text
            command.Connection = connection
            command.Connection.Open()
            command.ExecuteNonQuery()
            reader = command.ExecuteReader(CommandBehavior.CloseConnection)

            PRM.Text = "Password succefully changed"

            command.Connection.Close()
            command.Dispose()
            connection.Dispose()
        Else
            PRM.Text = "Incorrect password/username "

        End If
    End Sub

    Public Sub valid(ByVal name As String, ByVal pass As String)

        Dim command As SqlCommand
        Dim connection As SqlConnection

        Dim Hashedpassword = Secrecy.HashPassword(pass)
        Dim commandstring As String
        Dim reader As SqlDataReader

        connection = New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=|datadirectory|WolfPack Auto Spares.mdf;Integrated Security=True")
        commandstring = "SELECT * FROM [User] WHERE Username='" & name & "'"
        command = New SqlCommand(commandstring)
        command.CommandType = CommandType.Text
        command.Connection = connection
        command.Connection.Open()
        command.ExecuteNonQuery()
        reader = command.ExecuteReader(CommandBehavior.CloseConnection)

        If reader.HasRows Then
            Do While reader.Read
                If Not (Hashedpassword = reader("Password") And name = reader("Username")) Then
                    check = "wrong"
                Else
                    check = "correct"
                End If
            Loop
        End If

        command.Connection.Close()
        command.Dispose()
        connection.Dispose()
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient
Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim connection As SqlConnection
        Dim command As SqlCommand
        Dim reader As SqlDataReader

        Dim db As dbTablesDataContext = New dbTablesDataContext()

        For Each p As Product In db.Products
            Display.Text &= "<div class='image-container' ><a href='ProductPage.aspx?P_Id=" & p.P_Id & "'><img src=" & p.ImgLocation & "></a> <div class='overlay'><p><hr>" & p.Name & "<br>Price: R" & p.Price & "</p></div></div>"
        Next




        'connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")
        'Dim commandString As String
        'commandString = "SELECT * FROM Products"

        'command = New SqlCommand(commandString)
        'command.CommandType = CommandType.Text
        'command.Connection = connection

        'command.Connection.Open()
        'command.ExecuteNonQuery()

        'reader = command.ExecuteReader(CommandBehavior.CloseConnection)
        'Dim catalog As String = " "



        'Dim number As Integer = 6
        'If reader.HasRows Then

        '    Do While reader.Read
        '        If number > 0 Then
        '            Display.Text &= "<div class='image-container' ><a href='ProductPage.aspx?P_Id=" & reader("P_Id") & "'><img src=" & reader("ImgLocation") & "></a> <div class='overlay'><p><hr>" & reader("Name") & "<br>Price: R" & reader("Price") & "</p></div></div>"
        '        End If
        '        number = number - 1
        '    Loop
        'End If
        'command.Connection.Close()
    End Sub

End Class
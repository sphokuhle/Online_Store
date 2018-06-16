Public Class Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not (Session("username") = Nothing) Then
            Session("username") = Nothing
            Session("level") = Nothing
            LogoutMessage.ForeColor = Drawing.Color.Red
            LogoutMessage.Text = "You have successfully logged out"
        Else
            LogoutMessage.ForeColor = Drawing.Color.Red
            LogoutMessage.Text = "You have not logged out yet."
        End If
    End Sub

End Class
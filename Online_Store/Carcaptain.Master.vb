Public Class Carcaptain
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username") = Nothing And Session("level") = Nothing Then
            loginId.Visible = True
            logoutId.Visible = False
        ElseIf Session("username") <> Nothing And Session("level") <> Nothing Then
            loginId.Visible = False
            logoutId.Visible = True
        End If
    End Sub

End Class
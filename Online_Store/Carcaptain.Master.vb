Public Class Carcaptain
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username") = Nothing And Session("level") = Nothing Then
            loginId.Visible = True
            logoutId.Visible = False
            idCustomerPage.Visible = False
        ElseIf Session("username") <> Nothing And Session("level") <> Nothing Then
            loginId.Visible = False
            logoutId.Visible = True

            If Session("level") = "1" Then
                idCustomerPage.Visible = True
            Else
                idCustomerPage.Visible = False
            End If
        End If
    End Sub

End Class
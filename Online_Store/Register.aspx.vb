
Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As dbTablesDataContext = New dbTablesDataContext()

        Dim dayReg As Date = Date.Today
        Try
            Dim us As User = New User()
            Dim counter As Integer = 0

            For Each _user As User In db.Users
                If (_user.Email = txtEmail.Text) Then
                    counter += 1
                Else
                    'Do Nothing
                End If
            Next
            If counter = 0 Then
                us.FName = txtname.Text
                us.Password = Secrecy.HashPassword(txtpassword.Text)
                us.Level = 2
                us.Username = txtusername.Text
                us.Surname = txtsurname.Text
                us.Email = txtEmail.Text
                db.Users.InsertOnSubmit(us)
                db.SubmitChanges()
                Response.Redirect("Login.aspx")
            Else
                RequiredFieldValidator7.Text = "Matching Email already Exist"
                RequiredFieldValidator7.Visible = True
            End If

        Catch Ex As Exception

        End Try
    End Sub

End Class
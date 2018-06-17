Imports System.Data
Imports System.Data.SqlClient
Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim connection As SqlConnection
        'Dim command As SqlCommand
        'Dim reader As SqlDataReader

        Dim db As dbTablesDataContext = New dbTablesDataContext()

        For Each p As Product In db.Products
            Display.Text &= "<div class='image-container' ><a href='ProductPage.aspx?P_Id=" & p.P_Id & "'><img src=" & p.ImgLocation & "></a> <div class='overlay'><p><hr>" & p.Name & "<br>Price: R" & p.Price & "</p></div></div>"
        Next

    End Sub

End Class
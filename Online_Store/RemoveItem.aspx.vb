Public Class RemoveItem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Remove_Click(sender As Object, e As EventArgs) Handles Remove.Click
        If Not Request.QueryString("RemoveID") Is Nothing Then
            If Not Session("ShoppingCarts") Is Nothing Then
                Dim id As Integer = Request.QueryString("RemoveID")
                Dim ShoppingCartList As List(Of PackCart)
                ShoppingCartList = Session("ShoppingCarts")

                For Each Prod In ShoppingCartList
                    If Prod.P_Id = id Then
                        ShoppingCartList.Remove(Prod)
                        Exit For
                    End If
                Next

                Session("ShoppingCarts") = ShoppingCartList
                Response.Redirect("ShoppingCart.aspx")
            End If

        End If
    End Sub
End Class
Public Class UpdateItmQty
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub UpdateQuantity_Click(sender As Object, e As EventArgs) Handles UpdateQuantity.Click
        If Not Request.QueryString("QtyID") Is Nothing Then

            If Not Session("ShoppingCarts") Is Nothing Then
                Dim id As Integer = Request.QueryString("QtyID")
                Dim ShoppingCartList As List(Of PackCart)
                ShoppingCartList = Session("ShoppingCarts")

                For Each Prod In ShoppingCartList
                    If Prod.P_Id = id Then
                        Prod.Quantity = txtUpdateQuantity.Text

                        Exit For
                    End If
                Next

                Session("ShoppingCarts") = ShoppingCartList
                Response.Redirect("ShoppingCart.aspx")
            End If
        End If
    End Sub
End Class
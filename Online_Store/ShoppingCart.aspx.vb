Imports System.Data
Imports System.Data.SqlClient

Public Class ShoppingCart
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("username") Is Nothing Then
            Message.Visible = False
            SCLogin.Visible = False
            Checkout.Visible = True
            AddMore.Visible = True
        Else
            Message.Visible = True
            Message.ForeColor = Drawing.Color.Red
            Message.Text = "Sorry, You have to login first to use the shopping cart"
            SCLogin.Visible = True
            Checkout.Visible = False
            AddMore.Visible = False
        End If

        If Not Request.QueryString("P_Id") Is Nothing Then
            If Session("ShoppingCarts") Is Nothing Then
                Dim PValue As Integer = Request.QueryString("P_Id").ToString
                Dim NewProduct As New PackCart(PValue)
                Dim SCartList As New List(Of PackCart)

                Dim Connection As SqlConnection
                Dim Command As SqlCommand
                Dim Reader As SqlDataReader

                Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")

                Dim CommandString As String
                CommandString = "Select * FROM Product WHERE P_Id=" & PValue & ";"

                Command = New SqlCommand(CommandString)
                Command.CommandType = CommandType.Text
                Command.Connection = Connection
                Command.Connection.Open()
                Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

                If Reader.HasRows Then
                    Do While Reader.Read
                        NewProduct.Name = Reader("Name")
                        NewProduct.Price = CDbl(Reader("Price"))
                        NewProduct.Quantity = 1

                        NewProduct.ImgLocation = Reader("ImgLocation")
                    Loop
                End If
                Command.Connection.Close()
                SCartList.Add(NewProduct)
                Session.Add("ShoppingCarts", SCartList)
                Response.Redirect("ShoppingCart.aspx")
            Else

                Dim Value As Integer = Request.QueryString("P_Id")
                Dim ShoppingCartList As New List(Of PackCart)
                ShoppingCartList = Session("ShoppingCarts")

                Dim ProductExist As Boolean = False
                For Each Product As PackCart In ShoppingCartList
                    If Product.P_Id = Value Then
                        ProductExist = True
                        Product.Quantity += 1
                        Session("ShoppingCarts") = ShoppingCartList
                        Exit For
                    End If
                Next

                If ProductExist = False Then
                    Dim Connection As SqlConnection
                    Dim Command As SqlCommand
                    Dim Reader As SqlDataReader
                    Dim NewProduct As New PackCart(Value)
                    Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")
                    Dim CommandString As String
                    CommandString = "Select * FROM Product WHERE P_Id=" & Value & ";"

                    Command = New SqlCommand(CommandString)
                    Command.CommandType = CommandType.Text
                    Command.Connection = Connection
                    Command.Connection.Open()
                    Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

                    If Reader.HasRows Then
                        Do While Reader.Read
                            NewProduct.Name = Reader("Name")
                            NewProduct.Price = CDbl(Reader("Price"))
                            NewProduct.ImgLocation = Reader("ImgLocation")
                            NewProduct.Quantity = 1

                        Loop
                    End If
                    Command.Connection.Close()
                    ShoppingCartList.Add(NewProduct)
                    Session("ShoppingCarts") = ShoppingCartList
                End If
                Response.Redirect("ShoppingCart.aspx")
            End If
        End If

        If Not Session("ShoppingCarts") Is Nothing Then
            Dim ShoppingCartList As New List(Of PackCart)
            ShoppingCartList = Session("ShoppingCarts")
            Dim totaCost As Double

            Dim totalprice As Double = 0
            For Each Product As PackCart In ShoppingCartList
                totaCost = Product.Product_Total
                Display.Text &= "<div class='image-container' ><a href='ProductPage.aspx?P_Id=" & Product.P_Id & "'>" & "<img src=" & Product.ImgLocation & "></a> <div class='overlay'><p><hr>" & Product.Name & "<br>Product Price: R" & Product.Price & "<br>Quantity: " & Product.Quantity &
                                "<br/>Total price: R" & totaCost & "<br/></p>"
                Display.Text &= "<a href='RemoveItem.aspx?RemoveID=" & Product.P_Id & "'>Remove Item</a><br/>"
                Display.Text &= "<a href='UpdateItmQty.aspx?QtyID=" & Product.P_Id & "'>Update Quantity</a></div></div>"
                totalprice += totaCost

            Next
            Display.Text &= "R" & totalprice & ""
        End If
    End Sub

    Protected Sub SCLogin_Click(sender As Object, e As EventArgs) Handles SCLogin.Click
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub Checkout_Click(sender As Object, e As EventArgs) Handles Checkout.Click
        Response.Redirect("CheckoutPage.aspx")
    End Sub

    Protected Sub AddMore_Click(sender As Object, e As EventArgs) Handles AddMore.Click
        Response.Redirect("ProductList.aspx")
    End Sub


End Class
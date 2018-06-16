﻿Imports System.Data
Imports System.Data.SqlClient

Public Class CheckoutPage
    Inherits System.Web.UI.Page
    Private pro2Remove As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pro2Remove = CInt(Request.QueryString("P_Id"))
        If Not Session("ShoppingCarts") Is Nothing Then
            Dim ShoppingC As List(Of PackCart)
            ShoppingC = CType(Session("ShoppingCarts"), List(Of PackCart))

            If ShoppingC.Count <> 0 Then
                Dim ShoppingCString As String = ""

                Display.Text &= "<table width='100%'><tr><td>Tel : (011) 245 4478<br/> " &
                                "Fax : (011) 245 1478 <br/> " &
                                "E-mail : WolfPackAuto@info.com <br/> " &
                                "<b><u>Physical Address</u></b><br/> 153 Koma Road <br /> Jabulani, Johannesburg Gauteng <br />South Africa <br />2109</li></td></tr></table>"
                Display.Text &= "<table  border='1px' width='100%'> <tr><td><b>" &
                                           "Product Image" & "</td><td><b>" & "Product Name" & "</b></td><td><b>" & "Product Quantity" & "</b></td><td><b>" & "Product Price" & "</b></td><td><b>" & "Total Price" & "</b></td></tr>"
                For Each Product As PackCart In ShoppingC
                    Dim Reader As SqlDataReader = GetProduct(Product.P_Id)

                    If Reader.HasRows Then
                        Do While Reader.Read

                            Display.Text &= "<tr ><td><img width='60' hieght='60' src=" & Product.ImgLocation & "></td>" &
                                            "<td>" & Product.Name & "</td>" &
                                            "<td>" & Product.Quantity & "</td>" &
                                            "<td>R" & Product.Price & "</td>" &
                                            "<td>Total Price: R" & Product.Product_Total & "</td></tr>"
                        Loop
                    End If
                Next
                Display.Text &= "</table><p><b>VAT : 14%</b><br/>" &
                                "<b>Delivery Amount: All deliveries are free </b><br/>" &
                                "<b>Payment Total: R" & TotalCost(ShoppingC) & "</b></p>"
                Display.Text &= "<br/><br/>"
                UpdateQuantity(ShoppingC)
                CreateInvoice(ShoppingC)

                Session("ShoppingCarts") = Nothing
            End If
        Else
            Display.Text = "Shopping cart is empty"
        End If
    End Sub

    Private Sub CreateInvoice(ShoppingC As List(Of PackCart))
        Dim Connection As SqlConnection
        Dim Command As SqlCommand

        Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")

        Dim refNumber As String = "REF" & New Random().Next.ToString
        Dim CommandString As String
        CommandString = "INSERT INTO [Invoice] VALUES('" & refNumber & "','" & DateTime.Now.ToString("G") & "','" & Request.Cookies("UserIDCookie").Value & "');"

        Command = New SqlCommand(CommandString)
        Command.CommandType = CommandType.Text
        Command.Connection = Connection

        Command.Connection.Open()
        Command.ExecuteNonQuery()

        Command.CommandText = "Select * FROM [Invoice] WHERE InvoiceReference='" & refNumber & "';"
        Dim InvoiceReader As SqlDataReader = Command.ExecuteReader()

        Dim InvoiceID As String = ""
        Dim UserID As String = ""

        If InvoiceReader.HasRows Then
            Do While InvoiceReader.Read
                InvoiceID = InvoiceReader("Invoice_ID")
            Loop
        End If

        Command.Connection.Close()

        For Each Product As PackCart In ShoppingC
            Dim insert As New SqlCommand
            insert.CommandType = CommandType.Text
            insert.Connection = Connection
            insert.Connection.Open()
            insert.CommandText = "INSERT INTO [InvoiceProduct](Invoice_ID, P_Id, ProductQuantity, BuyingPrice) VALUES(" & InvoiceID & "," & Product.P_Id & "," & Product.Quantity & "," & Product.Price & ");"
            insert.ExecuteNonQuery()
            insert.Connection.Close()
        Next

    End Sub

    Private Sub UpdateQuantity(ProductList As List(Of PackCart))
        For Each Product As PackCart In ProductList
            Dim Connection As SqlConnection
            Dim Command As SqlCommand

            Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")

            Dim CommandString As String
            CommandString = "UPDATE [Products]SET Quantity =" & QuantityInDataBase() - Product.Quantity & " WHERE P_ID ='" & pro2Remove & "';"
            Command = New SqlCommand(CommandString)
            Command.CommandType = CommandType.Text
            Command.Connection = Connection
            Command.Connection.Open()

            Command.ExecuteNonQuery()

            Command.Connection.Close()
        Next
    End Sub

    '*******************************************************************************************'
    Private Function QuantityInDataBase() As Integer
        Dim Connection As SqlConnection
        Dim Command As SqlCommand
        Dim reader As SqlDataReader
        Dim QUANT As Integer
        Dim CommandString As String
        Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")
        CommandString = "SELECT Quantity FROM [Products] WHERE P_Id='" & pro2Remove & "';"
        Command = New SqlCommand(CommandString)
        Command.CommandType = CommandType.Text
        Command.Connection = Connection

        Command.Connection.Open()
        Command.ExecuteNonQuery()
        reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

        If reader.HasRows Then
            Do While reader.Read
                QUANT = CInt(reader("Quantity"))
            Loop
        End If
        Return QUANT
    End Function
    '*******************************************************************************************'

    Private Function GetProduct(P_Id As Integer) As SqlDataReader
        Dim Connection As SqlConnection
        Dim Command As SqlCommand

        Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")

        Dim CommandString As String
        CommandString = "Select * FROM Products WHERE P_Id='" & P_Id & "';"

        Command = New SqlCommand(CommandString)
        Command.CommandType = CommandType.Text
        Command.Connection = Connection

        Command.Connection.Open()

        Return Command.ExecuteReader(CommandBehavior.CloseConnection)
    End Function

    Private Function TotalCost(ShoppingC As List(Of PackCart))
        Dim total As Double
        For Each Product As PackCart In ShoppingC
            total += Product.Product_Total
        Next
        Return total.ToString
    End Function

End Class
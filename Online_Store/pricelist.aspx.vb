Imports System.Data
Imports System.Data.SqlClient

Public Class pricelist
    Inherits System.Web.UI.Page

    Private Connection As SqlConnection
    Private Command As SqlCommand
    Private Reader As SqlDataReader
    Private CommandString As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CarCaptain Autospares.mdf;Integrated Security=True")
            CommandString = "Select * From [Product] ORDER BY Price "

            Command = New SqlCommand(CommandString)

            Command.CommandType = CommandType.Text

            Command.Connection = Connection

            Command.Connection.Open()

            Command.ExecuteNonQuery()

            Reader = Command.ExecuteReader(CommandBehavior.CloseConnection)

            If Reader.HasRows Then
                Do While Reader.Read
                    If Reader("Quantity") > 0 Then
                        Display.Text &= "<div class='image-container'><a href='ProductPage.aspx?P_Id=" & Reader("P_Id") & "'><img src=" & Reader("ImgLocation") & "></a> <div class='overlay'><p><hr>" & Reader("Name") & "<br>Price: R" & Reader("Price") & "<br>"

                        If (Session("Level") = 2) Then
                            Display.Text &= "<a href='EditProduct.aspx?ProductID=" & Reader("P_Id") & "'>Update Product</a><br><a href='DeleteProduct.aspx?P_Id=" & Reader("P_Id") & "'>Delete Product</a>"
                        End If

                        If (Session("Level") = 1) Then
                            If Not Session("username") Is Nothing Then
                                Display.Text &= "<a href='ShoppingCartPage.aspx?P_Id=" & Reader("P_Id") & "'>Add to Cart</a>"
                            End If
                        End If
                        Display.Text &= "</p></div></div>"
                    End If

                Loop
            End If

            Command.Connection.Close()

            If (Session("Level") = 2) Then
                NewProductCatalog.InnerHtml = "<a href= 'AddProduct.aspx'><h3 align=center>Add Product</h3></a><a href= 'CustomerPurchaseHistory.aspx'><h3 align=center>Customer Purchase History</h3></a><a href= 'ReportPage.aspx'><h3 align=center>View Site Report</h3></a><a href= 'UserReportPage.aspx'><h3 align=center>View registered user Report</h3></a>"
            End If


        End If
    End Sub

End Class
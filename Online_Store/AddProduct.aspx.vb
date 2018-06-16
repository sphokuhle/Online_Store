Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class AddProduct
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("username") Is Nothing Then
            Response.Redirect("login.aspx")
        End If
    End Sub

    Protected Sub cmdAdd_Click(sender As Object, e As EventArgs) Handles cmdAdd.Click
        Dim db As dbTablesDataContext = New dbTablesDataContext()
        Dim imageLoc As String = ""
        Try
            Dim p As Product = New Product
            Dim id As Integer = 0
            Dim Connection As SqlConnection
            Dim Command As SqlCommand
            Dim CommandString As String

            p.Name = txtName.Text
            p.Quantity = txtQuantity.Text
            p.Price = txtPrice.Text
            p.ImgLocation = ""  '"""" & "/App_Media/" & txtImageUploadAdd.FileName & """"
            db.Products.InsertOnSubmit(p)
            db.SubmitChanges()

            id = p.P_Id
            imageLoc = uploadImage(txtImageUploadAdd, id, "Products_Images")

            Connection = New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=&quot;|DataDirectory|\CarCaptain Autospares.mdf&quot;;Integrated Security=True")
            CommandString = "UPDATE [Products] SET ImgLocation='" & imageLoc & "' WHERE P_Id=" & id & ";"

            Command = New SqlCommand(CommandString)
            Command.CommandType = CommandType.Text
            Command.Connection = Connection

            Command.Connection.Open()
            Command.ExecuteNonQuery()
            Command.Connection.Close()


            Response.Redirect("ProductList.aspx")

        Catch ex As Exception

        End Try
    End Sub

    Private Function uploadImage(ByVal fileToUpload As FileUpload, ByVal ID As String, ByVal subfolder As String) As String

        If fileToUpload.HasFile Then

            Try
                Dim filename As String = Path.GetFileName(fileToUpload.FileName)
                Dim serverLocation As String = "~/Products/" + ID + "/" + subfolder + "/" + filename
                Dim SaveLoc As String = Server.MapPath(serverLocation)
                Dim fileSize As Integer = fileToUpload.PostedFile.ContentLength
                Dim fileExtention As String = Path.GetExtension(fileToUpload.FileName)
                If ((fileExtention.ToLower() = ".jpg") Or (fileExtention.ToLower() = ".png") Or (fileExtention.ToLower() = ".jpeg") And fileSize <= 15728640) Then
                    fileToUpload.SaveAs(SaveLoc) 'saving the image
                    Return "Online_Store/Online_Store/Products/" & ID & "/" & subfolder & "/" & filename
                Else
                    Return "File Chosen Is Not an Image"
                End If
            Catch ex As Exception
                Return ex.Message
            End Try
        Else
            Return "File Not Selected"
        End If
        Return Nothing
    End Function

    Protected Sub makeDirectory(ByVal productId As String)

        Dim directoryPath As String = Server.MapPath(String.Format("~/{0}/", "Products/" + productId))
        If (Directory.Exists(directoryPath)) Then
            Directory.CreateDirectory(directoryPath)
            Directory.CreateDirectory(Path.Combine(directoryPath, "Product_Images"))
        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Directory already exists.');", True)
        End If

    End Sub

End Class
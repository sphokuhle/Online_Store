Imports System.Data
Imports System.Data.SqlClient
Imports System.IO

Public Class EditProduct
    Inherits System.Web.UI.Page

    Private adminId As String
    Private subfolder As String = "Product_Images"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        adminId = Request.Cookies("UserIDCookie").Value

        If Session("username") Is Nothing Or Session("level") <> 2 Then
            Response.Redirect("Login.aspx")
        ElseIf (Not Session("username") Is Nothing) And Session("level") <> 2
            Response.Redirect("Login.aspx")
        Else
            If Not Page.IsPostBack Then

                Dim db As dbTablesDataContext = New dbTablesDataContext()
                Dim Prod_ID As Integer = CInt(Request.QueryString("P_Id").ToString())
                For Each p As Product In db.Products
                    If p.P_Id = Prod_ID Then
                        txtName.Text = p.Name
                        txtPrice.Text = p.Price
                        txtQuantity.Text = p.Quantity
                        txtShortDesc.Text = p.ShortDescription
                        txtFulDesc.Text = p.LongDescription
                        Session("ImgLoc") = p.ImgLocation
                        Exit For
                    End If
                Next


            End If
        End If
    End Sub

    Protected Sub cmdUpdate_Click(sender As Object, e As EventArgs) Handles cmdUpdate.Click
        Try
            Dim SelectedProductID As String = (Request.QueryString("P_Id").ToString())
            updatePrdct(SelectedProductID)
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('ImageLocation = " & Session("ImgLoc").ToString & "');", True)
            message.Visible = True
            message.ForeColor = Drawing.Color.Red
            message.Text = "Error occured while updating"
        End Try
    End Sub

    Private Function uploadImage(ByVal fileToUpload As FileUpload, ByVal ID As String, ByVal subfolder As String) As String

        If fileToUpload.HasFile Then

            Try
                Dim filename As String = Path.GetFileName(fileToUpload.FileName)
                Dim serverLocation As String = "~/Products/" & ID & "/" & subfolder & "/" + filename
                Dim SaveLoc As String = Server.MapPath(serverLocation)
                Dim fileSize As Integer = fileToUpload.PostedFile.ContentLength
                Dim fileExtention As String = Path.GetExtension(fileToUpload.FileName)
                If (((fileExtention.ToLower() = ".jpg") Or (fileExtention.ToLower() = ".png") Or (fileExtention.ToLower() = ".jpeg")) Or (fileExtention.ToLower() = ".svg") And fileSize <= 15728640) Then
                    fileToUpload.SaveAs(SaveLoc) 'saving the image in the server folder
                    Return filename
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

    Protected Sub makeDirectory(ByVal userId As String)

        Dim directoryPath As String = Server.MapPath(String.Format("~/{0}/", "Products/" + userId))
        If (Directory.Exists(directoryPath) = False) Then
            Directory.CreateDirectory(directoryPath)
            Directory.CreateDirectory(Path.Combine(directoryPath, "Product_Images"))
        End If

    End Sub

    Protected Sub updatePrdct(ByVal productId As String)

        Dim Loc As String = """" & "/Products/" & Session("userId") & "/Product_Images/"
        Dim db As dbTablesDataContext = New dbTablesDataContext

        For Each p As Product In db.Products
            If p.P_Id = CInt(productId) Then
                If txtImageUploadAdd.HasFile Then
                    p.Name = txtName.Text
                    p.Quantity = CInt(txtQuantity.Text)
                    p.Price = CDbl(txtPrice.Text)
                    p.ShortDescription = txtShortDesc.Text
                    p.LongDescription = txtFulDesc.Text
                    p.ImgLocation = Loc & txtImageUploadAdd.FileName & """"
                    p.User_ID = CInt(adminId)
                    makeDirectory(adminId)
                    uploadImage(txtImageUploadAdd, adminId, subfolder)
                    db.SubmitChanges()
                Else
                    p.Name = txtName.Text
                    p.Quantity = CInt(txtQuantity.Text)
                    p.Price = CDbl(txtPrice.Text)
                    p.ShortDescription = txtShortDesc.Text
                    p.LongDescription = txtFulDesc.Text
                    p.ImgLocation = Session("ImgLoc").ToString
                    p.User_ID = CInt(adminId)
                    db.SubmitChanges()
                End If
                message.Visible = True
                message.ForeColor = Drawing.Color.Red
                message.Text = "Succefully updated"
                Exit For
            End If
        Next

    End Sub

End Class
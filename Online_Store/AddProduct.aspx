<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddProduct.aspx.vb" Inherits="Online_Store.AddProduct" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 176px;
        }
        .auto-style3
        {
            width: 818px;
        }
        .auto-style4
        {
            width: 481px;
        }
        .auto-style5 {
            width: 176px;
            height: 26px;
        }
        .auto-style6 {
            width: 481px;
            height: 26px;
        }
        .auto-style7 {
            width: 818px;
            height: 26px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table class="auto-style1">
        <tr>
            <td class="auto-style5">
                <asp:Label ID="Label1" runat="server" Text="Product Image"></asp:Label>
            </td>
            <td class="auto-style6">
                  <asp:FileUpload ID="txtImageUploadAdd" runat="server" Width="275px" />
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter product image" ControlToValidate="txtImageUploadAdd" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtName" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter product name" ControlToValidate="txtName" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Product Price"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtPrice" runat="server" Width="180px" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter product price" ControlToValidate="txtPrice" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="Quantity on Hand"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtQuantity" runat="server" Width="180px" TextMode="Number"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter number of products available" ControlToValidate="txtQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label5" runat="server" Text="Short Description"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtShortDesc" runat="server" Width="180px" TextMode="SingleLine"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter A description of the product" ControlToValidate="txtShortDesc" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label6" runat="server" Text="Full Description"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtFulDesc" runat="server" Width="180px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter A full description of the product" ControlToValidate="txtFulDesc" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="cmdAdd" runat="server" Width="180px" Text="AddProduct" />
            &nbsp;&nbsp;&nbsp;&nbsp;
                <a href="ProductList.aspx">Cancel</a>
            </td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>


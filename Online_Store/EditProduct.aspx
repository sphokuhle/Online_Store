<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditProduct.aspx.vb" Inherits="Online_Store.EditProduct" MasterPageFile="~/Carcaptain.Master" %>

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
            width: 376px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server" Text="Product Image"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:FileUpload ID="txtImageUploadAdd" runat="server" Width="275px" />
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter product image" ControlToValidate="txtImageUploadAdd" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            <td>
                &nbsp;</td>
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
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server" Text="Product Price"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtPrice" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter product price" ControlToValidate="txtPrice" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server" Text="Quantity on Hand"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:TextBox ID="txtQuantity" runat="server" Width="180px"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter number of products available" ControlToValidate="txtQuantity" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">
                <asp:Button ID="cmdUpdate" runat="server" Width="180px" Text="Udate product" />
&nbsp;&nbsp;&nbsp;&nbsp; <a href="ProductList.aspx">Cancel</a> </td>

            <td class="auto-style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>

        </tr>
    </table>
    <asp:Label ID="message" runat="server" ></asp:Label>


</asp:Content>


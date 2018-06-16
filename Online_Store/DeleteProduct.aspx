<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DeleteProduct.aspx.vb" Inherits="Online_Store.DeleteProduct" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td>
                <asp:Button ID="cmdDelete" runat="server" Text="Remove Product" Width="166px" />
                <a href="DynamicProductCatalogPage.aspx">Cancel</a>
                <br />
                <asp:Label ID="message" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

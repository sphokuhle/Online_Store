<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RemoveItem.aspx.vb" Inherits="Online_Store.RemoveItem" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Button ID="Remove" runat="server" Text="Remove Item" /><br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <a href="ShoppingCartPage.aspx"> Cancel</a>
</asp:Content>

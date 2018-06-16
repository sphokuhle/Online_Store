<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ShoppingCart.aspx.vb" Inherits="Online_Store.ShoppingCart" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p><asp:Button ID="Checkout" runat="server" Text="Checkout" Width="83px" BorderColor="Red" /></p>
   <p><asp:Button ID="AddMore" runat="server" Text="Add More Products" Width="137px" BorderColor="Red" /></p>
     <p><asp:Label ID="Display" runat="server" ></asp:Label></p>
    <p><asp:Label ID="Message" runat="server" ></asp:Label></p>
     <p> <asp:Label ID="priceDis" runat="server" ></asp:Label> </p>
    <p><asp:Button ID="SCLogin" runat="server" Text="LogIn" Width="83px" BorderColor="Red" /></p>  

</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProductList.aspx.vb" Inherits="Online_Store.ProductList" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="NewProductCatalog" runat="server" ></div>
    
             <div id="Div1" runat="server" ></div>
    
            <table class="auto-style1" >
             <tr>
                 <td>  <asp:Label ID="Display" runat="server" ></asp:Label>&nbsp;</td>
             </tr>
                <tr>
                 <td>  <asp:Label ID="DisplayAdd" runat="server" ></asp:Label>&nbsp;</td>
             </tr>
         </table>
</asp:Content>

<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="pricelist.aspx.vb" Inherits="Online_Store.pricelist" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br />
    <img src="App_Media/allProducts.jpg" />
   
     <div id="NewProductCatalog" runat="server" ></div>
    
            <table class="auto-style1" >
             <tr>
                 <td>  <asp:Label ID="Display" runat="server" ></asp:Label>&nbsp;</td>
             </tr>
                <tr>
                 <td>  <asp:Label ID="DisplayAdd" runat="server" ></asp:Label>&nbsp;</td>
             </tr>
         </table>
</asp:Content>

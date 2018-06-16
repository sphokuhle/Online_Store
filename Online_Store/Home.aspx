<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Home.aspx.vb" Inherits="Online_Store.Home" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br />
    
    <meta charset="utf-8" />
    <img src="App_Media/fProducts.jpg" />
        <iframe width="950" 
                height="350" 
                src="App_Media/vid.mp4" runat ="server"  >
        </iframe>

    <table class="auto-style1" >
             <tr>
                 <td><asp:Label ID="Display" runat="server" ></asp:Label>&nbsp;</td>
             </tr>
         </table>

</asp:Content>

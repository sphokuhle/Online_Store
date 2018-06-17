<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Online_Store.Login" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <style type="text/css">
        .auto-style3 {
        width: 67%;
    }
    .auto-style4 {
        width: 134px;
    }
    .auto-style5 {
        width: 202px;
    }
    .auto-style6 {
        width: 510px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <br />
    <img width="150" height ="100" src="App_Media/login.png" />

     <table class="auto-style3">
    <tr>
        <td class="auto-style4">Username</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtUser" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser" ErrorMessage="Please Enter Username first" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Password</td>
        <td class="auto-style5">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>

    <asp:Label ID="Label" runat="server"></asp:Label><br /><br />
    <asp:Button ID="Button1" runat="server" Text="Login" Width="69px"></asp:Button><br />
    <p>Don't have an account?<a href="Registration.aspx"> Register now</a></p>

    
</asp:Content>


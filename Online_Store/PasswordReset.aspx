<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PasswordReset.aspx.vb" Inherits="Online_Store.PasswordReset" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 139px;
        }
        .auto-style2 {
            width: 287px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
    <tr>
        <td class="auto-style1">Username:</td>
        <td >
            <asp:TextBox ID="txtUsername" runat="server" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style2" >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername" ErrorMessage="Please Enter Username first" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">Current Password:</td>
        <td >
            <asp:TextBox ID="txtCurrentPass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style2" >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCurrentPass" ErrorMessage="Enter current password" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
        <tr>
        <td class="auto-style1">New Password:</td>
        <td >
            <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style2" >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPass" ErrorMessage="Enter new password" ForeColor="Red"></asp:RequiredFieldValidator><br />

        </td>
    </tr>
        <tr>
        <td class="auto-style1">
            Confitm Password:</td>
        <td >
            <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
        </td>
        <td class="auto-style2" >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirm" ErrorMessage="Confirm your new password" ForeColor="Red"></asp:RequiredFieldValidator>

            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPass" ControlToValidate="txtConfirm" ErrorMessage="Passwords do not match!" ForeColor="Red"></asp:CompareValidator>

        </td>
    </tr>
</table><br />
<asp:Label ID="PRM" runat="server" ForeColor="Red"></asp:Label>
<br />
<asp:Button ID="Reset" runat="server" Text="Reset" Width="120px" />

</asp:Content>

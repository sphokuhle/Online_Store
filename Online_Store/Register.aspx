<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="Online_Store.Register" MasterPageFile="~/Carcaptain.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 550px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 128px;
        }
        .auto-style4 {
            width: 224px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <img src="App_Media/register.jpg" />
     <table class="auto-style2">
        <tr>
            <td class="auto-style3"><asp:Label ID="Label" runat="server" Text="Name"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtname" runat="server" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtname" ErrorMessage="Enter username " ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><asp:Label ID="Label2" runat="server" Text="Surname"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtsurname" runat="server" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsurname" ErrorMessage="Enter Surname" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><asp:Label ID="Label3" runat="server" Text="Username"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtusername" runat="server" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtusername" ErrorMessage="Enter username" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
                  <tr>
            <td class="auto-style3"><asp:Label ID="Label6" runat="server" Text="Email Address"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter Email" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td class="auto-style3"><asp:Label ID="Label1" runat="server" Text="Delivery Address"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtDelivery" runat="server" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDelivery" ErrorMessage="Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><asp:Label ID="Label4" runat="server" Text="Password"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtpassword" ErrorMessage="Enter Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"><asp:Label ID="Label5" runat="server" Text="Confirm Password"></asp:Label></td>
            <td class="auto-style4"><asp:TextBox ID="txtcpassword" runat="server" TextMode="Password" Width="180px"></asp:TextBox>
                </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcpassword" ErrorMessage="Enter confirmation password" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtcpassword" ErrorMessage="Passwords do not match" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">

    <asp:Button ID="Button1" runat="server" Text="Register" Width="150px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

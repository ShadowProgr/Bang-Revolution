<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bang_Revolution_WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                User ID:
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></div>
        <div>Password:
            <asp:TextBox ID="txtPass" TextMode="Password" runat="server"></asp:TextBox></div>
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnRegis" runat="server" Text="Register" OnClick="btnRegis_Click" />
                </div>
        </div>
    </form>
</body>
</html>

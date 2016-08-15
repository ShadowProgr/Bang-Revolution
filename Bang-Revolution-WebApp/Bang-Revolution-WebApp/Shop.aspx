<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Bang_Revolution_WebApp.Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Profile</asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Shop</asp:LinkButton>
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Logout</asp:LinkButton>
            </div>
            <div>
                <asp:LinkButton ID="Items" runat="server" OnClick="Items_Click">Item's Shop</asp:LinkButton>
                <asp:LinkButton ID="Characters" runat="server" OnClick="Characters_Click">Character's Shop</asp:LinkButton>
            </div>
        </div>
    </form>
</body>
</html>

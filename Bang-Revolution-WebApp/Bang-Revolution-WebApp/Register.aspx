<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Bang_Revolution_WebApp.Register" %>

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
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </div>
            <div>
                Password:
            <asp:TextBox ID="txtPass" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <div>
                    Email:
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
        </div>
        </div>
    </form>
</body>
</html>

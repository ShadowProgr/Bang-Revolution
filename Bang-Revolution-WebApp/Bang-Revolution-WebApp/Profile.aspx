<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Bang_Revolution_WebApp.Profile" %>
<%@ Import Namespace="UserData" %>
<%@ Import Namespace="DAL" %>
<%@ Import Namespace="System.Data.SqlClient" %>
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
            <%
                ConnectToDB conn = new ConnectToDB();
                int id = conn.getUserID(Request["username"]);
                UData ud = conn.getUserData(id);
            %>
            <div>
                User Name: <%=Request["username"] %>
            </div>
            <div>
                Level: <%=ud.exp%>
            </div>
            <div>
                Win/Lose/Rate: <%=ud.win%>/<%=ud.lose%>/<%=ud.rate%>%
            </div>
            <div>
                Money: <%=ud.money%>
            </div>
            <div>
                Items Owned:
            <br />
                <asp:GridView ID="itemGrid" runat="server"></asp:GridView>
            </div>
            <div>
                Characters Owned:
            <br />
                <asp:GridView ID="characterGrid" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

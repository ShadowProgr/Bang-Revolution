<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Bang_Revolution_WebApp.Profile" %>

<%@ Import Namespace="Entity" %>
<%@ Import Namespace="DAL" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .menu {
            float: left;
            margin-left: 900px;
            margin-top: 25px;
            margin-bottom: auto;
        }

        .table {
            margin-left: auto;
            margin-right: auto;
            text-align: center;
        }

        .header {
            background: #663300;
            width: 100%;
            min-height: 10vh;
            max-height: 100%;
        }

        .content {
            float: left;
            background: burlywood;
            width: 100%;
            min-height: 90vh;
            max-height: 100%;
        }

        .img1 {
            float: left;
            height: 50px;
            width: 200px;
            margin: 5px 0px 0px 50px;
        }

        ul {
            list-style: none;
        }

        li {
            float: left;
        }

        .link {
            background-color: burlywood;
            color: white;
            text-decoration: none;
            border-right: 1px solid black;
            border-left: 1px solid black;
        }

        .name {
            font-family: Tahoma;
            font-size: 30px;
            font-weight: bold;
            text-align: center;
            color: white;
            background-color: #665000;
        }

        .info {
            background: brown;
            font-family: Tahoma;
            font-size: 30px;
        }

        .a {
            text-align: center;
            width: 100%;
        }

        .button {
            display: inline-block;
            padding: 15px 25px;
            font-size: 24px;
            cursor: pointer;
            text-align: center;
            text-decoration: none;
            outline: none;
            color: #fff;
            background-color: #4CAF50;
            border: none;
            border-radius: 15px;
            box-shadow: 0 9px #999;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <img class="img1" alt="" src="img\bang_logo.PNG" />
                <ul class="menu">
                    <li>
                        <asp:LinkButton CssClass="link" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Profile</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton CssClass="link" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Shop</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton CssClass="link" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Logout</asp:LinkButton></li>
                </ul>
            </div>
        </div>
        <%
            ConnectToDB conn = new ConnectToDB();
            int id = conn.getUserID(Request["username"]);
            UData ud = conn.getUserData(id);
        %>
        <div class="content">
            <div class="name">
                User: <%=Request["username"] %>
            </div>
            <table class="a">
                <tr class="info">
                    <td>Lv<%=ud.exp / 1000%></td>
                    <td><%=ud.win%></td>
                    <td><%=ud.lose%></td>
                    <td><%=(ud.win / (double) (ud.win + ud.lose)) * 100%>%</td>
                    <td><%=ud.money%>$</td>
                </tr>
            </table>
            <div>
                <b style="font-size: 30px;">Items Owned:</b>
                <span>
                    <asp:GridView CssClass="table" ID="itemGrid" runat="server" Width="735px" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCommand="itemGrid_RowCommand">
                        <Columns>
                            <asp:ImageField DataImageUrlField="img" HeaderText="Image">
                            </asp:ImageField>
                            <asp:BoundField DataField="name" HeaderText="Name" />
                            <asp:CheckBoxField DataField="isBackground" HeaderText="isBackground" />
                            <asp:TemplateField HeaderText="Set as default">
                                <ItemTemplate>
                                    <asp:Button ID="SetButton" runat="server"
                                        CommandName="Set"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        Text="Set" />
                                    <asp:Label ID="lblID_hidden" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label>
                                    <asp:Label ID="lblisBg_hidden" runat="server" Visible="false" Text='<%# Eval("isBackground") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </span>
            </div>
            <div>
                <b style="font-size: 30px;">Characters Owned:</b>
                <asp:GridView CssClass="table" ID="characterGrid" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="735px">
                    <Columns>
                        <asp:ImageField DataImageUrlField="img" HeaderText="Image" ControlStyle-Height="150px">
                        </asp:ImageField>
                        <asp:BoundField DataField="name" HeaderText="Character" />
                        <asp:BoundField DataField="desc" HeaderText="Description" />
                        <asp:BoundField DataField="hp" HeaderText="HP" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>

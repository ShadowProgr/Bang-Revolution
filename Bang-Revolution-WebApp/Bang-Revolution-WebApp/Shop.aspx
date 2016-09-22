<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="Bang_Revolution_WebApp.Shop" %>


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

        .link2 {
            background-color: #663300;
            color: white;
            text-decoration: none;
            font-size: 20px;
            margin-left: 0px;
            border-right: 1px solid black;
            border-left: 1px solid black;
            font-weight:100;
        }

        .left {
            float: unset;
            background: brown;
            padding-left: 20px;
        }

        .right {
            float: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
        <div class="content">
            <div class="left">
                <asp:LinkButton CssClass="link2" ID="Items" runat="server" OnClick="Items_Click">Item's Shop</asp:LinkButton>
                <asp:LinkButton CssClass="link2" ID="Characters" runat="server" OnClick="Characters_Click">Character's Shop</asp:LinkButton>
            </div>
            <div class="right">
                <asp:MultiView ID="BangShop" runat="server" ActiveViewIndex="0">
                    <asp:View ID="ItemShop" runat="server">
                        <asp:GridView CssClass="table" ID="itemGrid" runat="server" Width="401px" AutoGenerateColumns="False" OnRowCommand="itemGrid_RowCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                            <Columns>
                                <asp:ImageField DataImageUrlField="img" HeaderText="Image"></asp:ImageField>
                                <asp:BoundField DataField="name" HeaderText="Name" />
                                <asp:CheckBoxField DataField="isBackground" HeaderText="isBackground" />
                                <asp:BoundField DataField="price" HeaderText="Price" />
                                <asp:TemplateField HeaderText="Buy"><ItemTemplate><asp:Button ID="BuyButton_Item" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Buy1" Text="Buy" /><asp:Label ID="lblID_hidden" runat="server" Text='<%# Eval("ID") %>' Visible="false"></asp:Label></ItemTemplate></asp:TemplateField>
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
                    </asp:View>
                    <asp:View ID="CharacterShop" runat="server">
                        <asp:GridView CssClass="table" ID="characterGrid" runat="server" AutoGenerateColumns="False" OnRowCommand="characterGrid_RowCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                            <Columns>
                                <asp:ImageField DataImageUrlField="img" HeaderText="Image" ControlStyle-Height="150px">
                                    <ControlStyle Height="150px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="name" HeaderText="Character" />
                                <asp:BoundField DataField="desc" HeaderText="Description" />
                                <asp:BoundField DataField="hp" HeaderText="HP" />
                                <asp:BoundField DataField="price" HeaderText="Price" />
                                <asp:TemplateField HeaderText="Buy"><ItemTemplate><asp:Button ID="BuyButton_Char" runat="server"
                                            CommandName="Buy2"
                                            CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                            Text="Buy" /><asp:Label ID="lblID_hidden" runat="server" Visible="false" Text='<%# Eval("ID") %>'></asp:Label></ItemTemplate></asp:TemplateField>
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
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </form>
</body>
</html>

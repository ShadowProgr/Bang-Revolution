<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Bang_Revolution_WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .table1 {
            float: left;
            margin-left: 600px;
            width: 30%;
            margin-top: auto;
            margin-bottom: auto;
        }

        .tr {
              background:brown;
        }
        .table2 {
            float: left;
            margin-left: 350px;
            padding: 150px 0px 0px 50px;
            width: 30%;
            text-align:center;
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

        .txt {
            color: white;
            font-weight: bold;
            font-family: Tahoma;
        }

        .button {
            background-color: burlywood;
            border: none;
            color: white;
            text-align: center;
            display: inline-block;
            font-size: 15px;
        }

        .button1 {
            background-color: black;
            border: none;
            color: white;
            text-align: center;
            display: inline-block;
            font-size: 20px;
        }

        .text {
            height: 25px;
            width: 350px;
        }

        .img1 {
            float: left;
            height: 50px;
            width: 200px;
            margin: 5px 0px 0px 50px;
        }

        .img2 {
            padding: 20px 0px 0px 100px;
            float: left;
            height: 500px;
            width: 350px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <img class="img1" alt="" src="img\bang_logo.PNG" />
            <table class="table1">
                <tr>
                    <td class="txt">User ID:</td>
                    <td class="txt">Pass:</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" BackColor="LightYellow"></asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="txtPass" TextMode="Password" runat="server" BackColor="LightYellow"></asp:TextBox></td>
                    <td>
                        <asp:Button CssClass="button" ID="Button1" runat="server" Text="Login" OnClick="btnLogin_Click" /></td>
                </tr>
            </table>
        </div>
        <div class="content">
            <img class="img2" alt="" src="img\Bang_Deck.JPG" />
            <div class="regis">
                <table class="table2">
                    <tr class="tr">
                        <td>
                            <h1>Register</h1>
                        </td>
                    </tr>
                    <tr class="tr">
                        <td>
                            <asp:TextBox CssClass="text" ID="txtName1" placeholder="Your name" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="tr">
                        <td>
                            <asp:TextBox CssClass="text" ID="txtPass1" placeholder="New password" TextMode="Password" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="tr">
                        <td>
                            <asp:TextBox CssClass="text" ID="txtEmail" placeholder="Your email" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="tr">
                        <td>
                            <asp:Button CssClass="button1" ID="btnRegis" runat="server" Text="Register" OnClick="btnRegis_Click" /></td>
                    </tr>

                </table>
            </div>
        </div>
    </form>
</body>
</html>

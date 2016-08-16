using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Bang_Revolution_WebApp
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Send data to server
            string username = txtName.Text;
            string password = txtPass.Text;
            ConnectToDB conn = new ConnectToDB();
            bool check = conn.checkLogin(username, password);
            if (check == true)
            {
                Response.Redirect("Profile.aspx?username=" + username);
            }
            else
            {
                Response.Write("<script> alert('Wrong username or password, please input again') </script>");
            }
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
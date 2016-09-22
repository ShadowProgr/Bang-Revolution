using System;
using System.Collections.Generic;
using System.Linq;
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
            ConnectToDB conn = new ConnectToDB();
            string username = txtName1.Text;
            bool check = conn.checkRegis(username);
            int countError = 0;
            String error = "";
            if (!username.Equals(""))
            {
                if (check == true)
                {
                    error += "The user name you entered is existed, please input another user name \\n";
                    countError += 1;
                }
            }
            else
            {
                error += "Please input username \\n";
                countError += 1;
            }
            string password = txtPass1.Text;
            if (password.Equals(""))
            {
                error += "Please input password \\n";
                countError += 1;
            }
            string email = txtEmail.Text;
            if (email.Equals(""))
            {
                error += "Please input email \\n";
                countError += 1;
            }
            if (countError == 0)
            {
                conn.addUser(username, password, email);
                int id = conn.getUserID(username);
                conn.addUserData(id);
                Response.Redirect("Profile.aspx?username=" + username);
            }
            else
            {
                Response.Write("<script> alert('" + error + "') </script>");
            }
        }
    }
}
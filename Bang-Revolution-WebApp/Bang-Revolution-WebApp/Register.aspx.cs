using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bang_Revolution_WebApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            ConnectToDB conn = new ConnectToDB();
            string username = txtName.Text;
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
            } else
            {
                error += "Please input username \\n";
                countError += 1;
            }
            string password = txtPass.Text;
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
            } else
            {
                Response.Write("<script> alert('" + error + "') </script>");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}
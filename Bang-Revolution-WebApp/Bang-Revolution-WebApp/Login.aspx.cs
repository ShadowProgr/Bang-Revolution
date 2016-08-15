using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            User user = new User()
            {
                name = username,
                pass = password,
            };
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {

            string username = txtName.Text;
            string password = txtPass.Text;
            User user = new User()
            {
                name = username,
                pass = password,
            };
        }
    }
}
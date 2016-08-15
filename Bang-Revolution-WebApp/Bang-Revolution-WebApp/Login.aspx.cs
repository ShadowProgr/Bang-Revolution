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
<<<<<<< HEAD
        protected void Page_Load(object sender, EventArgs e)
        {

=======
        System.Net.Sockets.TcpClient clientSocket;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientSocket = new System.Net.Sockets.TcpClient();
            clientSocket.Connect("10.22.161.139", 8888);
>>>>>>> refs/remotes/origin/master
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Send data to server
            string username = txtName.Text;
            string password = txtPass.Text;
<<<<<<< HEAD
=======
            bool checkL = true;
>>>>>>> refs/remotes/origin/master
            User user = new User()
            {
                name = username,
                pass = password,
<<<<<<< HEAD
            };
=======
                checkLogin = checkL
            };
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, user);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = ms.ToArray();
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            //Read data from server
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            if (returndata.Contains("Welcome"))
            {
                Response.Redirect("Profile.aspx?name=" + username);
            }
            else
            {
                Response.Write("<script> alert('Wrong username or password, please input again'); </script>");
            }
>>>>>>> refs/remotes/origin/master
        }

        protected void btnRegis_Click(object sender, EventArgs e)
        {

            string username = txtName.Text;
            string password = txtPass.Text;
<<<<<<< HEAD
=======
            bool checkL = false;
>>>>>>> refs/remotes/origin/master
            User user = new User()
            {
                name = username,
                pass = password,
<<<<<<< HEAD
            };
=======
                checkLogin = checkL
            };
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, user);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = ms.ToArray();
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            //Read data from server
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            if (returndata.Contains("Welcome"))
            {
                Response.Write("<script> aler('Congratulaion, your account have been successfully created'); </scipt>");
                Response.Redirect("Profile.aspx?name=" + username);
            }
            else
            {
                Response.Write("<script> alert('The username is existed, please select another username'); </script>");
            }
>>>>>>> refs/remotes/origin/master
        }
    }
}
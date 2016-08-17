using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net.Sockets;

namespace Bang_Revolution_Client
{
    public partial class frmLogin : Form
    {
        string readData = null;
        NetworkStream serverStream = default(NetworkStream);
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        TcpClient gameSocket = new TcpClient();
        public frmLogin()
        {
            clientSocket.Connect("192.168.120.170", 8888);
            InitializeComponent();
            lblMessage.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            serverStream = clientSocket.GetStream();
            string send = "Login";
            byte[] outStream = Encoding.ASCII.GetBytes(send);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            User us = new User()
            {
                name = username,
                pass = password,
                id = 0,
                email = ""
            };
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, us);
            outStream = ms.ToArray();
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            // Send login info to server and wait for reply
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returnData = System.Text.Encoding.ASCII.GetString(inStream);
            if (returnData.Contains("Accepted")) // If login succeeded
            {
                frmMain formMain = new frmMain();
                formMain.Show();
                this.Hide();
            }
            else
            {
                lblMessage.Text = "Wrong username/password";
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            serverStream = clientSocket.GetStream();
            string send = "StartHost";
            byte[] outStream = Encoding.ASCII.GetBytes(send);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returnData = System.Text.Encoding.ASCII.GetString(inStream);

            if (returnData.Contains("Host Started"))
            {
                lblMessage.Text = returnData;
                gameSocket.Connect("192.168.120.170", 8889);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Host Joined";
            gameSocket.Connect("192.168.120.170", 8889);
        }
    }
}

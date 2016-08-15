using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestClass;

namespace Clients
{
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        NetworkStream serverStream;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Send data to server
            String uname = textBox1.Text;
            int uid = int.Parse(textBox2.Text);
            bool uskilled = false;
            if (checkBox1.Checked) uskilled = true;
            TestObj to = new TestObj()
            {
                name = uname,
                id = uid,
                skill = uskilled
            };
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, to);
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = ms.ToArray();
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
            //Read data from server
            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, inStream.Length);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg("Data from Server : " + returndata);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            clientSocket.Connect("192.168.122.18", 8888);
            label1.Text = "Client Socket Program - Server Connected ...";
        }
        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }
    }
}

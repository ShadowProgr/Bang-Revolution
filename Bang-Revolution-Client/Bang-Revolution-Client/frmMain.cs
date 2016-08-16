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
using System.Reflection;
using System.IO;

namespace Bang_Revolution_Client
{
    public partial class frmMain : Form
    {
        List<Player> players = new List<Player>();
        public frmMain()
        {
            InitializeComponent();

            players = Program.generateDummyData();

            for (int i = 0; i < players.Count; i++)
            {
                Bitmap image1 = Properties.Resources.Rose_Doolan;
                Label label1 = new Label();
                label1.Size = new Size(150, 231);
                label1.Image = (Image)(new Bitmap(image1, label1.Size));
                label1.Location = new Point(i * 150 + 30 * i, 0);
                this.Controls.Add(label1);
                Label label2 = new Label();
                label2.Size = new Size(150, 24);
                label2.Location = new Point(i * 150 + 30 * i, 250);
                label2.Text = players.ElementAt(i).name;
                this.Controls.Add(label2);
            }
            
        }
    }
}

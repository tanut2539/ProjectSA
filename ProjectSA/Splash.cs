using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSA
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1250;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Login L = new Login();
            L.Show();
            this.Hide();
            timer1.Stop();
        }
    }
}

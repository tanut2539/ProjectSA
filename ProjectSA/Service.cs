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
    public partial class Service : Form
    {
        string username = null;
        public Service(string input)
        {
            InitializeComponent();
            username = input;
        }

        private void Tool1_Click(object sender, EventArgs e)
        {
            Tool1 T1 = new Tool1(this.username);
            T1.MdiParent = this;
            T1.Show();
        }

        private void Tool2_Click(object sender, EventArgs e)
        {
            Tool2 T2 = new Tool2();
            T2.MdiParent = this;
            T2.Show();
        }
    }
}

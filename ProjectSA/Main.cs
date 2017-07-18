using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectSA
{
    public partial class Main : Form
    {
        string username = null;
        public Main(string input)
        {
            InitializeComponent();
            username = input;
        }

        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True");
        SqlCommand Cmd;
        SqlDataReader read;
        string sql = null;

        private void Main_Load(object sender, EventArgs e)
        {
            Connect.Open();
            sql = "SELECT *FROM [tab_employee] WHERE emp_username = '"+username+"'";
            Cmd = new SqlCommand(sql, Connect);
            read = Cmd.ExecuteReader();
            if(read.Read()){
                lbl_empFname.Text = read["emp_fname"].ToString();
                lbl_empLname.Text = read["emp_lname"].ToString();
                lbl_empID.Text = read["emp_id"].ToString();
                switch (read["emp_position"].ToString())
                {
                    case "0": 
                              lbl_empPosition.Text = "เจ้าของร้าน";
                        break;
                    case "1": bt_Employee.Enabled = false;
                              lbl_empPosition.Text = "พนักงานชั่วคราว";
                        break;
                    case "2": bt_Employee.Enabled = false; 
                              lbl_empPosition.Text = "พนักงานประจำ";
                        break;
                }
            }
            read.Close();
            Connect.Close();
        }

        private void bt_Service_Click(object sender, EventArgs e)
        {
            Service S = new Service(this.lbl_empFname.Text);
            S.Show();
        }

        private void bt_ManageMember_Click(object sender, EventArgs e)
        {
            Members M = new Members();
            M.Show();
        }

        private void bt_ManageBooks_Click(object sender, EventArgs e)
        {
            Books B = new Books();
            B.Show();
        }

        private void bt_EndProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bt_PrintReport_Click(object sender, EventArgs e)
        {
            Report R = new Report();
            R.Show();
        }

        private void bt_Employee_Click(object sender, EventArgs e)
        {
            Employee E = new Employee();
            E.Show();
        }

    }
}

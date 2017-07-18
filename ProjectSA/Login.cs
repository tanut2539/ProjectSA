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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True"); // Select Database
        SqlCommand Cmd;
        SqlDataReader read;
        string sql = null;

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bt_Login_Click(object sender, EventArgs e)
        {
            Connect.Open();
            // Check Username & Password Employees //
            sql = "SELECT *FROM [tab_IDlogin] WHERE ((username = '" + txt_empUsername.Text + "') AND (password = '" + txt_empPassword.Text + "'))";
            Cmd = new SqlCommand(sql, Connect);
            read = Cmd.ExecuteReader();
            if(txt_empUsername.Text != "" & txt_empPassword.Text != ""){
                if (read.Read()){ // ((Username or password) [TRUE])
                    Main M = new Main(this.txt_empUsername.Text);
                    M.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("ไม่พบ ชื่อผู้ใช้งาน หรือ รหัสผ่านไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // (Username or password) [FALSE])
                }
                read.Close();
            }
            else{
                MessageBox.Show("ผิดพลาด! โปรดกรอก ชื่อผู้ใช้งาน และ รหัสผ่าน ให้ครบถ้วน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Connect.Close();
        }

    }
}

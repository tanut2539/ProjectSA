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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True");
        SqlCommand Cmd;
        SqlDataReader read;
        string sql = null;

        private void Employee_Load(object sender, EventArgs e)
        {
            SearchCombobox();
            cb_EmployeeSearch.Text = "";
            sql = "SELECT *FROM [tab_employee]";
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
            da.Fill(ds, "emp_id");
            ListViewEmployee.DataSource = ds.Tables["emp_id"];
            ListViewAddEmployee.DataSource = ds.Tables["emp_id"];
            HeaderDatagridViewEmployee();
        }

        private void bt_SearchEmployee_Click(object sender, EventArgs e)
        {
            if (cb_EmployeeSearch.Text == "")
            {
                MessageBox.Show("โปรดพิมพ์ชื่อพนักงานที่ต้องการดำเนินการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_EmployeeSearch.Focus();
            }
            else
            {
                ds.Clear();
                string emp_id = cb_EmployeeSearch.SelectedValue.ToString();
                sql = "SELECT *FROM [tab_employee] WHERE emp_id = '" + emp_id + "'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "emp_id");
                ListViewEmployee.DataSource = ds.Tables["emp_id"];
            }
        }

        private void ListViewEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ListViewEmployee.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["emp_id"].Rows[e.RowIndex];
                txt_ShowEmployeeID.Text = dr["emp_id"].ToString();
                txt_ShowEmployeeFname.Text = dr["emp_fname"].ToString();
                txt_ShowEmployeeLname.Text = dr["emp_lname"].ToString();
                switch (Convert.ToInt32(dr["emp_position"]))
                {
                    case 0: cb_ShowEmployeePosition.Text = "เจ้าของร้าน";
                        break;
                    case 1: cb_ShowEmployeePosition.Text = "พนักงานชั่วคราว";
                        break;
                    case 2: cb_ShowEmployeePosition.Text = "พนักงานประจำ";
                        break;
                }
                if (Convert.ToInt32(dr["emp_gender"]) == 1)
                {
                    radion_GenderMale.Checked = true;
                    radio_GenderFemale.Checked = false;
                }
                else
                {
                    radion_GenderMale.Checked = false;
                    radio_GenderFemale.Checked = true;
                }
                txt_ShowEmployeeCitizenID.Text = dr["emp_citizenID"].ToString();
                date_EmployeeBirthday.Value = Convert.ToDateTime(dr["emp_birthday"].ToString());
                txt_ShowEmployeeAddress.Text = dr["emp_address"].ToString();
                txt_ShowEmployeeTelephone.Text = dr["emp_telephone"].ToString();
                txt_ShowEmployeeUsername.Text = dr["emp_username"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchCombobox()
        {
            try
            {
                Connect.Open();
                SqlDataAdapter emp = new SqlDataAdapter("SELECT emp_id,emp_fname + ' ' + emp_lname AS Fullname FROM [tab_employee]", Connect);
                DataTable dt = new DataTable();
                emp.Fill(dt);
                cb_EmployeeSearch.DisplayMember = "Fullname";
                cb_EmployeeSearch.ValueMember = "emp_id";
                cb_EmployeeSearch.DataSource = dt;
                Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_SaveSuccessEmployee_Click(object sender, EventArgs e)
        {
            if(txt_ShowEmployeeFname.Text == "" & txt_ShowEmployeeLname.Text == "")
            {
                MessageBox.Show("ชื่อ หรือ นามสกุล ต้องไม่เป็นค่าว่าง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ShowEmployeeFname.Focus();
            }
            else
            {
                int age = DateTime.Today.Year - date_EmployeeBirthday.Value.Year;
                if (age <= 14)
                {
                    MessageBox.Show("รูปแบบวันที่ผิดพลาด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    date_EmployeeBirthday.Focus();
                }
                else if (age >= 100)
                {
                    MessageBox.Show("รูปแบบวันที่ผิดพลาด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    date_EmployeeBirthday.Focus();
                }
                else
                {
                    if(txt_ShowEmployeeTelephone.Text.Length < 10)
                    {
                        MessageBox.Show("กรุณากรอก เลขหมายโทรศัพท์ ให้ครบ 10 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK);
                        txt_ShowEmployeeTelephone.Focus();
                    }
                    else
                    {
                        if (MessageBox.Show("ยินยันการเปลี่ยนแปลงข้อมูล", "ยืนนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataRow[] drs = ds.Tables["emp_id"].Select("emp_id = '" + txt_ShowEmployeeID.Text + "'");
                            drs[0]["emp_fname"] = txt_ShowEmployeeFname.Text;
                            drs[0]["emp_lname"] = txt_ShowEmployeeLname.Text;
                            drs[0]["emp_address"] = txt_ShowEmployeeAddress.Text;
                            drs[0]["emp_telephone"] = txt_ShowEmployeeTelephone.Text;
                            sql = "SELECT *FROM [tab_employee]";
                            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                            SqlCommandBuilder cb = new SqlCommandBuilder(da);
                            da.Update(ds, "emp_id");
                            ds.Tables["emp_id"].AcceptChanges();
                            MessageBox.Show("เปลี่ยนแปลงข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK);
                            cb_EmployeeSearch.Text = "";
                            txt_ShowEmployeeID.Text = "";
                            txt_ShowEmployeeFname.Text = "";
                            txt_ShowEmployeeLname.Text = "";
                            cb_ShowEmployeePosition.Text = "";
                            radion_GenderMale.Checked = false;
                            radio_GenderFemale.Checked = false;
                            txt_ShowEmployeeCitizenID.Text = "";
                            date_EmployeeBirthday.Value = DateTime.Now;
                            txt_ShowEmployeeAddress.Text = "";
                            txt_ShowEmployeeTelephone.Text = "";
                            txt_ShowEmployeeUsername.Text = "";
                        }
                    }
                }
            }
        }

        private void bt_DeleteEmploye_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["emp_id"].Select("emp_id = '" + txt_ShowEmployeeID.Text + "'");
            if (drs.Length == 0)
            {
                MessageBox.Show("กรุณาค้นหาพนักงานที่ต้องการดำเนินรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_EmployeeSearch.Focus();
            }
            else
            {
                if (MessageBox.Show("คุณต้องการลบข้อมูลพนักงาน " + txt_ShowEmployeeFname.Text + " " + txt_ShowEmployeeLname.Text + " หรือไม่", "ยืนนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    drs[0].Delete();
                    sql = "SELECT *FROM [tab_employee]";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "emp_id");
                    ds.Tables["emp_id"].AcceptChanges();
                    MessageBox.Show("ดำเนินการลบข้อมูลพนักงานเสร็จสิ้น", "สำเร็จ", MessageBoxButtons.OK);
                    cb_EmployeeSearch.Text = "";
                    txt_ShowEmployeeID.Text = "";
                    txt_ShowEmployeeFname.Text = "";
                    txt_ShowEmployeeLname.Text = "";
                    cb_ShowEmployeePosition.Text = "";
                    radion_GenderMale.Checked = false;
                    radio_GenderFemale.Checked = false;
                    txt_ShowEmployeeCitizenID.Text = "";
                    date_EmployeeBirthday.Value = DateTime.Now;
                    txt_ShowEmployeeAddress.Text = "";
                    txt_ShowEmployeeTelephone.Text = "";
                    txt_ShowEmployeeUsername.Text = "";
                }
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            ds.Clear();
            sql = "SELECT *FROM [tab_employee]";
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
            da.Fill(ds, "emp_id");
            ListViewEmployee.DataSource = ds.Tables["emp_id"];
            cb_EmployeeSearch.Text = "";
            txt_ShowEmployeeID.Text = "";
            txt_ShowEmployeeFname.Text = "";
            txt_ShowEmployeeLname.Text = "";
            cb_ShowEmployeePosition.Text = "";
            radion_GenderMale.Checked = false;
            radio_GenderFemale.Checked = false;
            txt_ShowEmployeeCitizenID.Text = "";
            date_EmployeeBirthday.Value = DateTime.Now;
            txt_ShowEmployeeAddress.Text = "";
            txt_AddEmployeeTelephone.Text = "";
            txt_ShowEmployeeUsername.Text = "";
        }

        private void bt_AddSaveChange_Click(object sender, EventArgs e)
        {
            if(txt_AddEmployeeFname.Text == "")
            {
                MessageBox.Show("กรุณากรอก ชื่อพนักงาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_AddEmployeeFname.Focus();
            }
            else
            {
                if(txt_AddEmployeeLname.Text == "")
                {
                    MessageBox.Show("กรุณากรอก นามสกุลพนักงาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_AddEmployeeLname.Focus();
                }
                else
                {
                    if (radio_AddgenderMale.Checked == false & radio_AddgenderFemale.Checked == false)
                    {
                        MessageBox.Show("กรุณาระบุเพศพนักงาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if(txt_AddEmployeeCitizenID.Text == "")
                        {
                            MessageBox.Show("กรุณาระบุเรหัสบัตรประชาชน 13 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_AddEmployeeCitizenID.Focus();
                        }
                        else
                        {
                            if(cb_AddEmployeePosition.Text == "")
                            {
                                MessageBox.Show("กรุณาเลือกตำแหน่งพนักงาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cb_AddEmployeePosition.Focus();
                            }
                            else
                            {
                                if(txt_AddEmployeeTelephone.Text == "")
                                {
                                    MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ 10 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txt_AddEmployeeTelephone.Focus();
                                }
                                else
                                {
                                    if(txt_AddEmployeeUsername.Text == "")
                                    {
                                        MessageBox.Show("กรุณาระบุ Username", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        txt_AddEmployeeUsername.Focus();
                                    }
                                    else
                                    {
                                        if(txt_AddEmployeePassword.Text == "")
                                        {
                                            MessageBox.Show("กรุณาระบุ Password", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            txt_AddEmployeePassword.Focus();
                                        }
                                        else
                                        {
                                            int add_EmpBirthday = DateTime.Today.Year - dateTimeBirthday.Value.Year;
                                            if(add_EmpBirthday <= 14)
                                            {
                                                MessageBox.Show("รูปแบบวันที่ผิดพลาด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                dateTimeBirthday.Focus();
                                            }
                                            else if(add_EmpBirthday >= 100)
                                            {
                                                MessageBox.Show("รูปแบบวันที่ผิดพลาด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                                dateTimeBirthday.Focus();
                                            }
                                            else
                                            {
                                                if(txt_AddEmployeeCitizenID.Text.Length < 13)
                                                {
                                                    MessageBox.Show("กรุณากรอก เลขประจำตัวประชาชน ให้ครบ 13 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                                    txt_AddEmployeeCitizenID.Focus();
                                                }
                                                else
                                                {
                                                    if(txt_AddEmployeeTelephone.Text.Length < 10)
                                                    {
                                                        MessageBox.Show("กรุณากรอก เลขหมายโทรศัพท์ ให้ครบ 10 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                                        txt_AddEmployeeTelephone.Focus();
                                                    }
                                                    else
                                                    {
                                                        Connect.Open();
                                                        string sql1 = "SELECT username,password FROM [tab_IDlogin] WHERE ((username = '" + txt_AddEmployeeUsername.Text + "') and (password = '" + txt_AddEmployeePassword.Text + "'))";
                                                        Cmd = new SqlCommand(sql1, Connect);
                                                        read = Cmd.ExecuteReader();
                                                        if (read.Read())
                                                        {
                                                            MessageBox.Show("มีรหัสพนักงานนี้แล้วอยู่ในระบบ", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                                        }
                                                        else
                                                        {
                                                            read.Close();
                                                            string sql2 = "SELECT emp_username,emp_fname,emp_lname FROM [tab_employee] WHERE ((emp_username = '" + txt_AddEmployeeUsername.Text + "') and (emp_fname COLLATE THAI_BIN LIKE N'" + txt_AddEmployeeFname.Text + "%') and (emp_lname COLLATE THAI_BIN LIKE N'" + txt_AddEmployeeLname.Text + "%'))";
                                                            Cmd = new SqlCommand(sql2, Connect);
                                                            read = Cmd.ExecuteReader();
                                                            if (read.Read())
                                                            {
                                                                MessageBox.Show("มีชื่อพนักงานนี้อยู่แล้วในระบบ", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                                                txt_AddEmployeeUsername.Focus();
                                                            }
                                                            else
                                                            {
                                                                read.Close();
                                                                if (MessageBox.Show("ยืนยันการสมัครสมาชิก", "ยืนนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                                {
                                                                    SqlCommand sql3 = new SqlCommand("INSERT INTO [tab_IDlogin] (username,password) VALUES ('" + txt_AddEmployeeUsername.Text + "','" + txt_AddEmployeePassword.Text + "')", Connect);
                                                                    sql3.ExecuteNonQuery();
                                                                    string sql4 = "INSERT INTO [tab_employee] (emp_id,emp_username,emp_fname,emp_lname,emp_citizenID,emp_gender,emp_birthday,emp_address,emp_telephone,emp_position) VALUES (@emp_id,'" + txt_AddEmployeeUsername.Text + "',N'" + txt_AddEmployeeFname.Text + "',N'" + txt_AddEmployeeLname.Text + "','" + txt_AddEmployeeCitizenID.Text + "',@emp_gender,@emp_birthday,'" + txt_AddEmployeeAddress.Text + "','" + txt_AddEmployeeTelephone.Text + "',@emp_position)";
                                                                    Cmd = new SqlCommand(sql4, Connect);
                                                                    if (cb_AddEmployeePosition.SelectedIndex == 1)
                                                                    {
                                                                        SqlCommand check_empid = new SqlCommand("SELECT max(emp_id)+1 FROM [tab_employee] WHERE emp_position = 1", Connect);
                                                                        Cmd.Parameters.AddWithValue("@emp_id", check_empid.ExecuteScalar().ToString());
                                                                        Cmd.Parameters.AddWithValue("@emp_position", 1);
                                                                    }
                                                                    else
                                                                    {
                                                                        SqlCommand check_empid = new SqlCommand("SELECT max(emp_id)+1 FROM [tab_employee] WHERE emp_position = 2", Connect);
                                                                        Cmd.Parameters.AddWithValue("@emp_id", check_empid.ExecuteScalar().ToString());
                                                                        Cmd.Parameters.AddWithValue("@emp_position", 2);
                                                                    }
                                                                    if (radio_AddgenderMale.Checked == true)
                                                                    {
                                                                        Cmd.Parameters.AddWithValue("@emp_gender", 1);
                                                                    }
                                                                    else
                                                                    {
                                                                        Cmd.Parameters.AddWithValue("@emp_gender", 2);
                                                                    }
                                                                    Cmd.Parameters.AddWithValue("@emp_birthday", dateTimeBirthday.Value);
                                                                    Cmd.ExecuteNonQuery();
                                                                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "บันทึกสำเร็จ", MessageBoxButtons.OK);
                                                                    ds.Clear();
                                                                    sql = "SELECT *FROM [tab_employee]";
                                                                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                                                                    da.Fill(ds, "emp_id");
                                                                    ListViewEmployee.DataSource = ds.Tables["emp_id"];
                                                                    txt_AddEmployeeFname.Text = "";
                                                                    txt_AddEmployeeLname.Text = "";
                                                                    radio_AddgenderMale.Checked = false;
                                                                    radio_AddgenderFemale.Checked = false;
                                                                    txt_AddEmployeeCitizenID.Text = "";
                                                                    cb_AddEmployeePosition.Text = "";
                                                                    dateTimeBirthday.Value = DateTime.Now;
                                                                    txt_AddEmployeeAddress.Text = "";
                                                                    txt_AddEmployeeTelephone.Text = "";
                                                                    txt_AddEmployeeUsername.Text = "";
                                                                    txt_AddEmployeePassword.Text = "";
                                                                }
                                                            }
                                                        }
                                                        Connect.Close();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void bt_AddCancel_Click(object sender, EventArgs e)
        {
            txt_AddEmployeeFname.Text = "";
            txt_AddEmployeeLname.Text = "";
            radio_AddgenderMale.Checked = false;
            radio_AddgenderFemale.Checked = false;
            txt_AddEmployeeCitizenID.Text = "";
            cb_AddEmployeePosition.Text = "";
            dateTimeBirthday.Value = DateTime.Now;
            txt_AddEmployeeAddress.Text = "";
            txt_AddEmployeeTelephone.Text = "";
            txt_AddEmployeeUsername.Text = "";
            txt_AddEmployeePassword.Text = "";
        }

        public void HeaderDatagridViewEmployee()
        {
            ListViewEmployee.Columns[0].HeaderCell.Value = "รหัสพนักงาน";
            ListViewEmployee.Columns[1].HeaderCell.Value = "ชื่อผู้ใช้งาน";
            ListViewEmployee.Columns[2].HeaderCell.Value = "ชื่อพนักงาน";
            ListViewEmployee.Columns[3].HeaderCell.Value = "นามสกุลพนักงาน";
            ListViewEmployee.Columns[4].HeaderCell.Value = "เลขประจำตัวประชาชน";
            ListViewEmployee.Columns[5].HeaderCell.Value = "เพศพนักงาน";
            ListViewEmployee.Columns[6].HeaderCell.Value = "วันเกิดพนักงาน";
            ListViewEmployee.Columns[7].HeaderCell.Value = "ที่อยู่พนักงาน";
            ListViewEmployee.Columns[8].HeaderCell.Value = "เบอร์โทรศัพท์";
            ListViewEmployee.Columns[9].HeaderCell.Value = "ตำแหน่ง";
            ListViewAddEmployee.Columns[0].HeaderCell.Value = "รหัสพนักงาน";
            ListViewAddEmployee.Columns[1].HeaderCell.Value = "ชื่อผู้ใช้งาน";
            ListViewAddEmployee.Columns[2].HeaderCell.Value = "ชื่อพนักงาน";
            ListViewAddEmployee.Columns[3].HeaderCell.Value = "นามสกุลพนักงาน";
            ListViewAddEmployee.Columns[4].HeaderCell.Value = "เลขประจำตัวประชาชน";
            ListViewAddEmployee.Columns[5].HeaderCell.Value = "เพศพนักงาน";
            ListViewAddEmployee.Columns[6].HeaderCell.Value = "วันเกิดพนักงาน";
            ListViewAddEmployee.Columns[7].HeaderCell.Value = "ที่อยู่พนักงาน";
            ListViewAddEmployee.Columns[8].HeaderCell.Value = "เบอร์โทรศัพท์";
            ListViewAddEmployee.Columns[9].HeaderCell.Value = "ตำแหน่ง";
        }

        private void txt_ShowEmployeeFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowEmployeeFname.Focus();
            }
        }

        private void txt_ShowEmployeeLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowEmployeeLname.Focus();
            }
        }

        private void txt_ShowEmployeeCitizenID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowEmployeeCitizenID.Focus();
            }
        }

        private void txt_ShowEmployeeTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowEmployeeTelephone.Focus();
            }
        }

        private void txt_AddEmployeeFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddEmployeeFname.Focus();
            }
        }

        private void txt_AddEmployeeLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddEmployeeLname.Focus();
            }
        }

        private void txt_AddEmployeeCitizenID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddEmployeeCitizenID.Focus();
            }
        }

        private void txt_AddEmployeeTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddEmployeeTelephone.Focus();
            }
        }
    }
}

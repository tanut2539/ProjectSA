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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();

        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True");
        SqlCommand Cmd;
        SqlDataReader read;
        string sql = null;

        private void Members_Load(object sender, EventArgs e)
        {
            sql = "SELECT *FROM [tab_member]";
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
            da.Fill(ds, "m_id");
            ListViewMembers.DataSource = ds.Tables["m_id"];
            ListView_AddMember.DataSource = ds.Tables["m_id"];
            HeaderDatagridView();
        }

        private void bt_SearchMember_Click(object sender, EventArgs e)
        {
            if(cb_MembersSearchType.Text == "" & txt_MembersSearchID.Text == "")
            {
                MessageBox.Show("โปรดเลือก ประเภทสมาชิก หรือ ค้นหา รหัสสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_MembersSearchType.Focus();
            }
            else if(cb_MembersSearchType.Text != "" & txt_MembersSearchID.Text == "")
            {
                if (cb_MembersSearchType.SelectedIndex == 0)
                {
                    ds.Clear();
                    sql = "SELECT *FROM [tab_member] WHERE m_type = 1 ";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "m_id");
                    ListViewMembers.DataSource = ds.Tables["m_id"];
                }
                else
                {
                    ds.Clear();
                    sql = "SELECT *FROM [tab_member] WHERE m_type = 2 ";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "m_id");
                    ListViewMembers.DataSource = ds.Tables["m_id"];
                }
            }
            else if (cb_MembersSearchType.Text == "" & txt_MembersSearchID.Text != "")
            {
                ds.Clear();
                sql = "SELECT *FROM [tab_member] WHERE m_id = '"+txt_MembersSearchID.Text+"' ";
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "m_id");
                ListViewMembers.DataSource = ds.Tables["m_id"];
            }
            else if (cb_MembersSearchType.Text != "" & txt_MembersSearchID.Text != "")
            {
                MessageBox.Show("รูปแบบการค้นหาไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ListViewMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ListViewMembers.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["m_id"].Rows[e.RowIndex];
                txt_ShowMemberID.Text = dr["m_id"].ToString();
                txt_ShowMemberFName.Text = dr["m_fname"].ToString();
                txt_ShowMemberLName.Text = dr["m_lname"].ToString();
                txt_ShowMemberRent.Text = dr["m_rent"].ToString();
                txt_ShowMemberQuota.Text = dr["m_quota"].ToString();
                txt_ShowMemberCitizenID.Text = dr["m_citizenID"].ToString();
                if (Convert.ToInt32(dr["m_gender"].ToString()) == 1)
                {
                    Radio_genderMale.Checked = true;
                    Radio_genderFeMale.Checked = false;
                }
                else
                {
                    Radio_genderMale.Checked = false;
                    Radio_genderFeMale.Checked = true;
                }
                if (Convert.ToInt32(dr["m_type"].ToString()) == 1)
                {
                    txt_ShowMemberType.Text = "สมาชิกรายปี";
                }
                else
                {
                    txt_ShowMemberType.Text = "สมาชิก VIP";
                }
                dateTime_Birthday.Value = Convert.ToDateTime(dr["m_birthday"].ToString());
                txt_ShowMemberAddress.Text = dr["m_address"].ToString();
                txt_ShowMemberTelephone.Text = dr["m_telephone"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_SaveChange_Click(object sender, EventArgs e)
        {
            if(txt_ShowMemberFName.Text == "" & txt_ShowMemberLName.Text == "")
            {
                MessageBox.Show("ชื่อ หรือ นามสกุล ต้องไม่เป็นค่าว่าง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ShowMemberFName.Focus();
            }
            else
            {
                int Edit_Brithday = DateTime.Today.Year - dateTime_Birthday.Value.Year;
                if (Edit_Brithday <= 14)
                {
                    MessageBox.Show("รูปแบบวันที่ผิดพลาด!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dateTime_Birthday.Focus();
                }
                else if (Edit_Brithday >= 100)
                {
                    MessageBox.Show("รูปแบบวันที่ผิดพลาด!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dateTime_Birthday.Focus();
                }
                else
                {
                    if(txt_ShowMemberTelephone.Text.Length < 10)
                    {
                        MessageBox.Show("กรุณากรอก เลขหมายโทรศัพท์ ให้ครบ 10 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK);
                        txt_ShowMemberTelephone.Focus();
                    }
                    else
                    {
                        if (MessageBox.Show("ยินยันการเปลี่ยนแปลงข้อมูล", "ยืนนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            DataRow[] drs = ds.Tables["m_id"].Select("m_id = '" + txt_ShowMemberID.Text + "'");
                            drs[0]["m_fname"] = txt_ShowMemberFName.Text;
                            drs[0]["m_lname"] = txt_ShowMemberLName.Text;
                            drs[0]["m_address"] = txt_ShowMemberAddress.Text;
                            drs[0]["m_telephone"] = txt_ShowMemberTelephone.Text;
                            sql = "SELECT *FROM [tab_member]";
                            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                            SqlCommandBuilder cb = new SqlCommandBuilder(da);
                            da.Update(ds, "m_id");
                            ds.Tables["m_id"].AcceptChanges();
                            MessageBox.Show("เปลี่ยนแปลงข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK);
                            cb_MembersSearchType.Text = "";
                            txt_MembersSearchID.Text = "";
                            txt_ShowMemberID.Text = "";
                            txt_ShowMemberFName.Text = "";
                            txt_ShowMemberLName.Text = "";
                            txt_ShowMemberType.Text = "";
                            txt_ShowMemberRent.Text = "";
                            txt_ShowMemberQuota.Text = "";
                            txt_ShowMemberCitizenID.Text = "";
                            Radio_genderMale.Checked = false;
                            Radio_genderFeMale.Checked = false;
                            dateTime_Birthday.Value = DateTime.Now;
                            txt_ShowMemberAddress.Text = "";
                            txt_ShowMemberTelephone.Text = "";
                        }
                    }
                }
            }
        }

        private void bt_DropMember_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["m_id"].Select("m_id = '" + txt_ShowMemberID.Text + "'");
            if(drs.Length == 0)
            {
                MessageBox.Show("กรุณาค้นหาสมาชิกที่ต้องการดำเนินรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_MembersSearchID.Focus();
            }
            else
            {
                if (MessageBox.Show("คุณต้องการลบข้อมูลสมาชิก " + txt_ShowMemberFName.Text + " " + txt_ShowMemberLName.Text +" หรือไม่", "ยืนนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    drs[0].Delete();
                    sql = "SELECT *FROM [tab_member]";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "m_id");
                    ds.Tables["m_id"].AcceptChanges();
                    MessageBox.Show("ดำเนินการลบข้อมูลสมาชิกเสร็จสิ้น", "สำเร็จ", MessageBoxButtons.OK);
                    cb_MembersSearchType.Text = "";
                    txt_MembersSearchID.Text = "";
                    txt_ShowMemberID.Text = "";
                    txt_ShowMemberFName.Text = "";
                    txt_ShowMemberLName.Text = "";
                    txt_ShowMemberType.Text = "";
                    txt_ShowMemberRent.Text = "";
                    txt_ShowMemberQuota.Text = "";
                    txt_ShowMemberCitizenID.Text = "";
                    Radio_genderMale.Checked = false;
                    Radio_genderFeMale.Checked = false;
                    dateTime_Birthday.Value = DateTime.Now;
                    txt_ShowMemberAddress.Text = "";
                    txt_ShowMemberTelephone.Text = "";
                }
            }
        }

        private void bt_CancelChange_Click(object sender, EventArgs e)
        {
            // Refresh datatable
            ds.Clear();
            sql = "SELECT *FROM [tab_member]";
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
            da.Fill(ds, "m_id");
            ListViewMembers.DataSource = ds.Tables["m_id"];
            //
            cb_MembersSearchType.Text = "";
            txt_MembersSearchID.Text = "";
            txt_ShowMemberID.Text = "";
            txt_ShowMemberFName.Text = "";
            txt_ShowMemberLName.Text = "";
            txt_ShowMemberType.Text = "";
            txt_ShowMemberRent.Text = "";
            txt_ShowMemberQuota.Text = "";
            txt_ShowMemberCitizenID.Text = "";
            Radio_genderMale.Checked = false;
            Radio_genderFeMale.Checked = false;
            dateTime_Birthday.Value = DateTime.Now;
            txt_ShowMemberAddress.Text = "";
            txt_ShowMemberTelephone.Text = "";
        }

        private void bt_AddSaveChange_Click(object sender, EventArgs e)
        {
            if(txt_AddMemberFname.Text == ""){
                MessageBox.Show("กรุณากรอก ชื่อสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_AddMemberFname.Focus();
            }
            else
            {
                if (txt_AddMemberLname.Text == "")
                {
                    MessageBox.Show("กรุณากรอก นามสกุลสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_AddMemberLname.Focus();
                }
                else
                {
                    if(Radio_AddGenderMale.Checked == false & Radio_AddGenderFemale.Checked == false)
                    {
                        MessageBox.Show("กรุณาระบุเพศสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (txt_AddMemberCitizenID.Text == "")
                        {
                            MessageBox.Show("กรุณาระบุเรหัสบัตรประชาชน 13 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_AddMemberCitizenID.Focus();
                        }
                        else
                        {
                            if(cb_AddMemberType.Text == "")
                            {
                                MessageBox.Show("กรุณาเลือกประเภทสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                cb_AddMemberType.Focus();
                            }
                            else
                            {
                                if (txt_AddMemberTelephone.Text == "")
                                {
                                    MessageBox.Show("กรุณากรอกเบอร์โทรศัพท์ 10 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txt_AddMemberTelephone.Focus();
                                }
                                else
                                {
                                    int Add_BirthDay = DateTime.Today.Year - date_AddMemberBirthday.Value.Year;
                                    if (Add_BirthDay <= 14) 
                                    { 
                                        MessageBox.Show("รูปแบบวันที่ผิดพลาด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                                        date_AddMemberBirthday.Focus(); 
                                    }
                                    else if (Add_BirthDay >= 100)
                                    {
                                        MessageBox.Show("รูปแบบวันที่ผิดพลาด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        date_AddMemberBirthday.Focus(); 
                                    }
                                    else
                                    {
                                        if (txt_AddMemberCitizenID.Text.Length < 13)
                                        {
                                            MessageBox.Show("กรุณากรอก เลขประจำตัวประชาชน ให้ครบ 13 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                            txt_AddMemberCitizenID.Focus();
                                        }
                                        else
                                        {
                                            if (txt_AddMemberTelephone.Text.Length < 10)
                                            {
                                                MessageBox.Show("กรุณากรอก เลขหมายโทรศัพท์ ให้ครบ 10 หลัก", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                                txt_AddMemberTelephone.Focus();
                                            }
                                            else
                                            {
                                                Connect.Open();
                                                sql = "SELECT m_fname,m_lname FROM [tab_member] WHERE ((m_fname COLLATE THAI_BIN LIKE N'" + txt_AddMemberFname.Text + "%') and (m_lname COLLATE THAI_BIN LIKE N'" + txt_AddMemberLname.Text + "%'))";
                                                Cmd = new SqlCommand(sql, Connect);
                                                read = Cmd.ExecuteReader();
                                                if (read.Read())
                                                {
                                                    MessageBox.Show("มีชื่อสมาชิกนี้อยู่แล้วในระบบ", "ข้อผิดพลาด", MessageBoxButtons.OK);
                                                }
                                                else
                                                {
                                                    if (MessageBox.Show("ยืนยันการสมัครสมาชิก", "ยืนนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                                    {
                                                        read.Close();
                                                        sql = "INSERT INTO [tab_member] (m_id,m_date,m_fname,m_lname,m_citizenID,m_type,m_gender,m_birthday,m_address,m_telephone,m_quota) VALUES (@m_id,@m_date,N'" + txt_AddMemberFname.Text + "',N'" + txt_AddMemberLname.Text + "','" + txt_AddMemberCitizenID.Text + "',@m_type,@m_gender,@m_birthday,N'" + txt_AddMemberAddress.Text + "','" + txt_AddMemberTelephone.Text + "',@m_quota)";
                                                        Cmd = new SqlCommand(sql, Connect);
                                                        if (cb_AddMemberType.SelectedIndex == 0)
                                                        {
                                                            SqlCommand checkid = new SqlCommand("SELECT max(m_id)+1 FROM [tab_member] WHERE m_type = 1", Connect);
                                                            Cmd.Parameters.AddWithValue("@m_id", checkid.ExecuteScalar().ToString());
                                                            Cmd.Parameters.AddWithValue("@m_type", 1);
                                                            Cmd.Parameters.AddWithValue("@m_quota", 10);
                                                        }
                                                        else
                                                        {
                                                            SqlCommand checkid = new SqlCommand("SELECT max(m_id)+1 FROM [tab_member] WHERE m_type = 2", Connect);
                                                            Cmd.Parameters.AddWithValue("@m_id", checkid.ExecuteScalar().ToString());
                                                            Cmd.Parameters.AddWithValue("@m_type", 2);
                                                            Cmd.Parameters.AddWithValue("@m_quota", 15);
                                                        }
                                                        if (Radio_AddGenderMale.Checked == true)
                                                        {
                                                            Cmd.Parameters.AddWithValue("@m_gender", 1);
                                                        }
                                                        else
                                                        {
                                                            Cmd.Parameters.AddWithValue("@m_gender", 2);
                                                        }
                                                        Cmd.Parameters.AddWithValue("@m_birthday", date_AddMemberBirthday.Value);
                                                        Cmd.Parameters.AddWithValue("@m_date", SqlDbType.DateTime).Value = DateTime.Now;
                                                        Cmd.ExecuteNonQuery();
                                                        MessageBox.Show("บันทึกข้อมูลสำเร็จ", "บันทึกสำเร็จ", MessageBoxButtons.OK);
                                                        ds.Clear();
                                                        sql = "SELECT *FROM [tab_member]";
                                                        SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                                                        da.Fill(ds, "m_id");
                                                        ListViewMembers.DataSource = ds.Tables["m_id"];
                                                        // Clear New Member
                                                        txt_AddMemberFname.Text = "";
                                                        txt_AddMemberLname.Text = "";
                                                        Radio_AddGenderMale.Checked = false;
                                                        Radio_AddGenderFemale.Checked = false;
                                                        txt_AddMemberCitizenID.Text = "";
                                                        cb_AddMemberType.Text = "";
                                                        date_AddMemberBirthday.Value = DateTime.Now;
                                                        txt_AddMemberAddress.Text = "";
                                                        txt_AddMemberTelephone.Text = "";
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

        private void bt_AddCancel_Click(object sender, EventArgs e)
        {
            txt_AddMemberFname.Text = "";
            txt_AddMemberLname.Text = "";
            Radio_AddGenderMale.Checked = false;
            Radio_AddGenderFemale.Checked = false;
            txt_AddMemberCitizenID.Text = "";
            cb_AddMemberType.Text = "";
            date_AddMemberBirthday.Value = DateTime.Now;
            txt_AddMemberAddress.Text = "";
            txt_AddMemberTelephone.Text = "";
        }

        private void HeaderDatagridView()
        {
            ListViewMembers.Columns[0].HeaderCell.Value = "รหัสสมาชิก";
            ListViewMembers.Columns[1].HeaderCell.Value = "วันที่สมัครสมาชิก";
            ListViewMembers.Columns[2].HeaderCell.Value = "ชื่อ";
            ListViewMembers.Columns[3].HeaderCell.Value = "นามสกุล";
            ListViewMembers.Columns[4].HeaderCell.Value = "เลขประจำตัวประชาชน";
            ListViewMembers.Columns[5].HeaderCell.Value = "ประเภทสมาชิก";
            ListViewMembers.Columns[6].HeaderCell.Value = "เพศสมาชิก";
            ListViewMembers.Columns[7].HeaderCell.Value = "วันเกิดสมาชิก";
            ListViewMembers.Columns[8].HeaderCell.Value = "ที่อยู่สมาชิก";
            ListViewMembers.Columns[9].HeaderCell.Value = "เบอร์โทรศัพท์";
            ListViewMembers.Columns[10].HeaderCell.Value = "จำนวนหนังสือที่ค้างยืม";
            ListViewMembers.Columns[11].HeaderCell.Value = "จำนวนหนังสือที่ยืมได้";
            ListView_AddMember.Columns[0].HeaderCell.Value = "รหัสสมาชิก";
            ListView_AddMember.Columns[1].HeaderCell.Value = "วันที่สมัครสมาชิก";
            ListView_AddMember.Columns[2].HeaderCell.Value = "ชื่อ";
            ListView_AddMember.Columns[3].HeaderCell.Value = "นามสกุล";
            ListView_AddMember.Columns[4].HeaderCell.Value = "เลขประจำตัวประชาชน";
            ListView_AddMember.Columns[5].HeaderCell.Value = "ประเภทสมาชิก";
            ListView_AddMember.Columns[6].HeaderCell.Value = "เพศสมาชิก";
            ListView_AddMember.Columns[7].HeaderCell.Value = "วันเกิดสมาชิก";
            ListView_AddMember.Columns[8].HeaderCell.Value = "ที่อยู่สมาชิก";
            ListView_AddMember.Columns[9].HeaderCell.Value = "เบอร์โทรศัพท์";
            ListView_AddMember.Columns[10].HeaderCell.Value = "จำนวนหนังสือที่ค้างยืม";
            ListView_AddMember.Columns[11].HeaderCell.Value = "จำนวนหนังสือที่ยืมได้";
        }

        private void txt_AddMemberCitizenID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("ต้องกรอกเป็นตัวเลข 13 หลักเท่านั้น!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddMemberCitizenID.Focus();
            }
        }

        private void txt_AddMemberTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("ต้องกรอกเป็นตัวเลข 10 หลักเท่านั้น!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddMemberTelephone.Focus();
            }
        }

        private void txt_AddMemberFname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddMemberFname.Focus();
            }
        }

        private void txt_AddMemberLname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddMemberLname.Focus();
            }
        }

        private void txt_MembersSearchID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_MembersSearchID.Focus();
            }
        }

        private void txt_ShowMemberFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowMemberFName.Focus();
            }
        }

        private void txt_ShowMemberLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowMemberLName.Focus();
            }
        }

        private void txt_ShowMemberTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowMemberTelephone.Focus();
            }
        }
    }

}

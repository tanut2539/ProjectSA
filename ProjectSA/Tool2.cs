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
    public partial class Tool2 : Form
    {
        public Tool2()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True");
        SqlCommand Cmd;
        SqlDataReader read;
        string sql = null;

        private void Tool2_Load(object sender, EventArgs e)
        {
            
            ComboboxSearchMember();
            cb_SeachMemberName.Text = "";
            dt.Columns.Add("No", typeof(int));
            dt.Columns["No"].AutoIncrement = true;
            dt.Columns["No"].AutoIncrementSeed = 1;
            dt.Columns["No"].ReadOnly = true;
            dt.Columns.Add("รหัสหนังสือ", typeof(string));
            dt.Columns.Add("ชื่อหนังสือ", typeof(string));
            dt.Columns.Add("จำนวนวันที่ค้างยืม", typeof(string));
            dt.Columns.Add("ค่าปรับ", typeof(int));
        }

        private void bt_ServiceSearchMember_Click(object sender, EventArgs e)
        {
            if (txt_SearchMemberID.Text == "" & cb_SeachMemberName.Text == "")
            {
                MessageBox.Show("โปรดกรอก รหัสสมาชิก หรือ ชื่อสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_SearchMemberID.Text != "" & cb_SeachMemberName.Text == "")
            {
                Connect.Open();
                sql = "SELECT *FROM [tab_member] WHERE m_id = '" + txt_SearchMemberID.Text + "' ";
                Cmd = new SqlCommand(sql, Connect);
                read = Cmd.ExecuteReader();
                if (read.Read())
                {
                    txt_ShowMemberID.Text = read["m_id"].ToString();
                    txt_ShowMemberName.Text = read["m_fname"].ToString();
                    txt_ShowMemberBooks1.Text = read["m_rent"].ToString();
                    txt_ShowMemberBooks2.Text = read["m_quota"].ToString();
                    if (Convert.ToInt32(read["m_type"].ToString()) == 1)
                    {
                        txt_ShowMemberType.Text = "สมาชิกรายปี";
                    }
                    else { txt_ShowMemberType.Text = "สมาชิก VIP"; }
                    read.Close();
                    ds.Clear();
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_memID = '" + txt_ShowMemberID.Text + "') and (r_rentStatus = 1))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "r_id");
                    ListViewBookRent.DataSource = ds.Tables["r_id"];
                    HeaderTable();
                }
                else
                {
                    MessageBox.Show("ไม่พบสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }    
                Connect.Close();
            }
            else if (txt_SearchMemberID.Text == "" & cb_SeachMemberName.Text != "")
            {
                Connect.Open();
                string cb_Member = cb_SeachMemberName.SelectedValue.ToString();
                sql = "SELECT *FROM [tab_member] WHERE m_id = '" + cb_Member + "'";
                Cmd = new SqlCommand(sql, Connect);
                read = Cmd.ExecuteReader();
                if(read.Read())
                {
                    txt_ShowMemberID.Text = read["m_id"].ToString();
                    txt_ShowMemberName.Text = read["m_fname"].ToString();
                    txt_ShowMemberBooks1.Text = read["m_rent"].ToString();
                    txt_ShowMemberBooks2.Text = read["m_quota"].ToString();
                    if (Convert.ToInt32(read["m_type"].ToString()) == 1)
                    {
                        txt_ShowMemberType.Text = "สมาชิกรายปี";
                    }
                    else { txt_ShowMemberType.Text = "สมาชิก VIP"; }
                    read.Close();
                    ds.Clear();
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_memID = '" + txt_ShowMemberID.Text + "') and (r_rentStatus = 1))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "r_id");
                    ListViewBookRent.DataSource = ds.Tables["r_id"];
                    HeaderTable();
                }
                Connect.Close();
            }
            else if (txt_SearchMemberID.Text != "" & cb_SeachMemberName.Text != "")
            {
                MessageBox.Show("รูปแบบการค้นหาไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ListViewBookRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Double RentDate;
                ListViewBookRent.Rows[e.RowIndex].Selected = true;
                DataRow dr = ds.Tables["r_id"].Rows[e.RowIndex];
                txt_ShowBookID.Text = dr["r_bookID"].ToString();
                txt_ShowBookName.Text = dr["r_bookName"].ToString();
                RentDate = DateTime.Today.Day - Convert.ToDateTime(dr["r_rentDate"]).Day;
                if (RentDate < 0)
                {
                    txt_ShowBookRent.Text = "0";
                }
                else
                {
                    txt_ShowBookRent.Text = RentDate.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_AddListBookRent_Click(object sender, EventArgs e)
        {
            if(txt_ShowMemberID.Text == "")
            {
                MessageBox.Show("กรุณาเลือกหรือค้นหาสมาชิกเพื่อดำเนินรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if(txt_ShowBookID.Text == "")
                {
                    MessageBox.Show("กรุณาเลือกหนังสือที่ต้องการคืน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    int book_rate = 0;
                    Connect.Open();
                    sql = "SELECT book_rate FROM [tab_book] WHERE book_id = '" + txt_ShowBookID.Text + "' ";
                    Cmd = new SqlCommand(sql, Connect);
                    read = Cmd.ExecuteReader();
                    if(read.Read())
                    {
                        book_rate = Convert.ToInt32(read["book_rate"].ToString());
                    }
                    read.Close();
                    Connect.Close();
                    int refund = 0,Rentout = 0;
                    Rentout = Convert.ToInt32(txt_ShowBookRent.Text);
                    refund = Rentout * book_rate;
                    dt.Rows.Add(null, txt_ShowBookID.Text, txt_ShowBookName.Text, txt_ShowBookRent.Text, refund);
                    ListViewBook_refund.DataSource = dt;
                    Double Count = dt.Rows.Count;
                    Double charge = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        charge += Convert.ToInt32(ListViewBook_refund.Rows[i].Cells[4].Value);
                    }
                    txt_TotalBookRent.Text = Count.ToString();
                    txt_Charge.Text = charge.ToString();
                    txt_ShowBookID.Text = "";
                    txt_ShowBookName.Text = "";
                    txt_ShowBookRent.Text = "";
                }
            }
        }

        private void ListViewBook_refund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_ListShowBookID.Text = ListViewBook_refund.Rows[e.RowIndex].Cells["รหัสหนังสือ"].Value.ToString();
                txt_ListShowBookName.Text = ListViewBook_refund.Rows[e.RowIndex].Cells["ชื่อหนังสือ"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DeleteList_Click(object sender, EventArgs e)
        {
            if (ListViewBook_refund.Rows.Count > 1)
            {
                if (ListViewBook_refund.Rows[ListViewBook_refund.CurrentRow.Index].IsNewRow != true)
                {
                    ListViewBook_refund.Rows.Remove(ListViewBook_refund.CurrentRow);
                    txt_TotalBookRent.Text = Convert.ToString(ListViewBook_refund.Rows.Count - 1);
                    Double charge = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        charge += Convert.ToInt32(ListViewBook_refund.Rows[i].Cells[4].Value);
                    }
                    txt_Charge.Text = charge.ToString();
                    txt_ListShowBookID.Text = "";
                    txt_ListShowBookName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("เลือกรายการที่ต้องการลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt_Receive_TextChanged(object sender, EventArgs e)
        {
            if (txt_Receive.Text == "")
            {
                txt_Receive.Text = "0";
            }
            else
            {
                Double recive = Convert.ToInt32(txt_Receive.Text);
                Double Refund = recive - Convert.ToInt32(txt_Charge.Text);
                txt_Refund.Text = Refund.ToString();
            }
        }

        private void bt_success_Click(object sender, EventArgs e)
        {
            if(txt_ShowMemberID.Text == "")
            {
                MessageBox.Show("กรุณาเลือกหรือค้นหาสมาชิกเพื่อดำเนินรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ShowMemberID.Focus();
            }
            else
            {
                if (txt_Refund.Text == "")
                {
                    MessageBox.Show("กรุณาชำระเงิน !!!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_Receive.Focus();
                }
                else
                {
                    if (Convert.ToInt32(txt_Refund.Text) < 0)
                    {
                        MessageBox.Show("จำนวนเงินทอนต้องไม่ติดลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txt_Receive.Focus();
                    }
                    else
                    {
                        if (MessageBox.Show("ยืนยันการคืนหนังสือ", "ยืนนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int SQLMember_rent = 0;
                            int SQLMember_Quota = 0;
                            int UpdateMember_rent = 0;
                            int UpdateMember_Quota = 0;
                            int UpdateBookStatus = 1;
                            int UpdateRrentStauts = 2;
                            Connect.Open();
                            sql = "SELECT *FROM [tab_member] WHERE m_id = '" + txt_ShowMemberID.Text + "'";
                            Cmd = new SqlCommand(sql, Connect);
                            read = Cmd.ExecuteReader();
                            if (read.Read())
                            {
                                SQLMember_rent = Convert.ToInt32(read["m_rent"].ToString());
                                SQLMember_Quota = Convert.ToInt32(read["m_quota"].ToString());
                            }
                            read.Close();
                            UpdateMember_rent = Convert.ToInt32(SQLMember_rent) - Convert.ToInt32(txt_TotalBookRent.Text);
                            UpdateMember_Quota = Convert.ToInt32(txt_TotalBookRent.Text) + Convert.ToInt32(SQLMember_Quota);
                            SqlCommand SQLupdateMember = new SqlCommand("UPDATE [tab_member] SET m_rent = '" + UpdateMember_rent + "' , m_quota = '" + UpdateMember_Quota + "' WHERE m_id = '" + txt_ShowMemberID.Text + "'", Connect);
                            SQLupdateMember.ExecuteNonQuery();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                SqlCommand SQLupdateBook = new SqlCommand("UPDATE [tab_book] SET book_status = '" + UpdateBookStatus + "' WHERE book_id = '" + dt.Rows[i]["รหัสหนังสือ"].ToString().Trim() + "' ", Connect);
                                SqlCommand SQLupdateRecord = new SqlCommand("UPDATE [tab_rentreturn] SET r_rentStatus = '" + UpdateRrentStauts + "' WHERE r_bookID = '" + dt.Rows[i]["รหัสหนังสือ"].ToString().Trim() + "'", Connect);
                                SQLupdateBook.ExecuteNonQuery();
                                SQLupdateRecord.ExecuteNonQuery();
                            }
                            Connect.Close();
                            MessageBox.Show("คืนหนังสือเสร็จสิ้น", "สำเร็จ", MessageBoxButtons.OK);
                            FunctClear();
                        }
                    }
                }
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            FunctClear();
        }

        private void FunctClear()
        {
            dt.Clear();
            ds.Clear();
            txt_SearchMemberID.Text = "";
            cb_SeachMemberName.Text = "";
            txt_ShowMemberID.Text = "";
            txt_ShowMemberName.Text = "";
            txt_ShowMemberType.Text = "";
            txt_ShowMemberBooks1.Text = "";
            txt_ShowMemberBooks2.Text = "";
            txt_ShowBookID.Text = "";
            txt_ShowBookName.Text = "";
            txt_ShowBookRent.Text = "";
            txt_TotalBookRent.Text = "";
            txt_Charge.Text = "0";
            txt_Receive.Text = "0";
            txt_Refund.Text = "";
            txt_ListShowBookID.Text = "";
            txt_ListShowBookName.Text = "";
        }

        private void ComboboxSearchMember()
        {
            try
            {
                Connect.Open();
                SqlDataAdapter sql_member = new SqlDataAdapter("SELECT m_id,m_fname + ' ' + m_lname AS Fullname FROM [tab_member]", Connect);
                DataTable dtm = new DataTable();
                sql_member.Fill(dtm);
                cb_SeachMemberName.DisplayMember = "Fullname";
                cb_SeachMemberName.ValueMember = "m_id";
                cb_SeachMemberName.DataSource = dtm;
                Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HeaderTable()
        {
            ListViewBookRent.Columns[0].HeaderCell.Value = "No";
            ListViewBookRent.Columns[1].HeaderCell.Value = "วันที่ยืม";
            ListViewBookRent.Columns[2].HeaderCell.Value = "วันที่คืน";
            ListViewBookRent.Columns[3].HeaderCell.Value = "พนักงานขาย";
            ListViewBookRent.Columns[4].HeaderCell.Value = "รหัสสมาชิก";
            ListViewBookRent.Columns[5].HeaderCell.Value = "รหัสหนังสือ";
            ListViewBookRent.Columns[6].HeaderCell.Value = "ชื่อหนังสือ";
            ListViewBookRent.Columns[7].HeaderCell.Value = "สถานะการชำระเงิน";
            ListViewBookRent.Columns[8].HeaderCell.Value = "การชำระเงิน(บาท)";
        }

        private void txt_SearchMemberID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_SearchMemberID.Focus();
            }
        }

        private void txt_Receive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_Receive.Focus();
            }
        }
    }
}

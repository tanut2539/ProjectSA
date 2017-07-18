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
    public partial class Tool1 : Form
    {
        string username = null;
        public Tool1(string input)
        {
            InitializeComponent();
            username = input;
        }

        // Create Table DataListView

        DataTable dt = new DataTable();

        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True");
        SqlCommand Cmd;
        SqlDataReader read;
        string sql = null;
        int i = 0;

        private void Tool1_Load(object sender, EventArgs e)
        {
            CreateDataTable();
            SearchMemberCombobox();
            SearchBookCombobox();
            cb_SearchMemberName.Text = "";
            cb_SearchBookName.Text = "";
        }

        private void bt_ServiceSearchMember_Click(object sender, EventArgs e)
        {
            if (txt_SearchMemberID.Text == "" & cb_SearchMemberName.Text == "")
            {
                MessageBox.Show("โปรดกรอก รหัสสมาชิก หรือ ชื่อสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txt_SearchMemberID.Text != "" & cb_SearchMemberName.Text == "")
            {
                Connect.Open();
                sql = "SELECT *FROM [tab_member] WHERE m_id = '" + txt_SearchMemberID.Text + "' ";
                Cmd = new SqlCommand(sql, Connect);
                read = Cmd.ExecuteReader();
                if (read.Read())
                {
                    txt_ShowMemberID.Text = read["m_id"].ToString();
                    txt_ShowMemberName.Text = read["m_fname"].ToString() + " " + read["m_lname"].ToString();
                    txt_ShowMemberBooks1.Text = read["m_rent"].ToString();
                    txt_ShowMemberBooks2.Text = read["m_quota"].ToString();
                    if (Convert.ToInt32(read["m_type"].ToString()) == 1)
                    {
                        txt_ShowMemberType.Text = "สมาชิกรายปี";
                    }
                    else { txt_ShowMemberType.Text = "สมาชิก VIP"; }
                    if (Convert.ToInt32(read["m_quota"].ToString()) == 0)
                    {
                        bt_ServiceAddList.Enabled = false;
                    }
                    else
                    {
                        bt_ServiceAddList.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                read.Close();
                Connect.Close();
            }
            else if (txt_SearchMemberID.Text == "" & cb_SearchMemberName.Text != "")
            {
                Connect.Open();
                string cb_member = cb_SearchMemberName.SelectedValue.ToString();
                sql = "SELECT *FROM [tab_member] WHERE m_id = '" + cb_member + "'";
                Cmd = new SqlCommand(sql, Connect);
                read = Cmd.ExecuteReader();
                if (read.Read())
                {
                    txt_ShowMemberID.Text = read["m_id"].ToString();
                    txt_ShowMemberName.Text = read["m_fname"].ToString() + " " + read["m_lname"].ToString();
                    txt_ShowMemberBooks1.Text = read["m_rent"].ToString();
                    txt_ShowMemberBooks2.Text = read["m_quota"].ToString();
                    if (Convert.ToInt32(read["m_type"].ToString()) == 1)
                    {
                        txt_ShowMemberType.Text = "สมาชิกรายปี";
                    }
                    else { txt_ShowMemberType.Text = "สมาชิก VIP"; }
                    if (Convert.ToInt32(read["m_quota"].ToString()) == 0)
                    {
                        bt_ServiceAddList.Enabled = false;
                    }
                    else
                    {
                        bt_ServiceAddList.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                read.Close();
                Connect.Close();
            }
            else if (txt_SearchMemberID.Text != "" & cb_SearchMemberName.Text != "")
            {
                MessageBox.Show("รูปแบบการค้นหาไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_ServiceSearchBooks_Click(object sender, EventArgs e)
        {
            if (txt_SearchBookID.Text == "" & cb_SearchBookName.Text == "")
            {
                MessageBox.Show("โปรดกรอก รหัสหนังสือ หรือ ชื่อหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if(txt_SearchBookID.Text != "" & cb_SearchBookName.Text == "")
            {
                Connect.Open();
                sql = "SELECT *FROM [tab_book] WHERE book_id = '"+txt_SearchBookID.Text+"' ";
                Cmd = new SqlCommand(sql, Connect);
                read = Cmd.ExecuteReader();
                if(read.Read())
                {
                    txt_ShowBookID.Text = read["book_id"].ToString();
                    txt_ShowBookName.Text = read["book_name"].ToString();
                    txt_RentDate.Text = read["book_rate"].ToString();
                    if(Convert.ToInt32(read["book_status"].ToString()) == 1)
                    {
                        lbl_BookStatus.Text = "ว่าง";
                        bt_ServiceAddList.Enabled = true;
                    }
                    else
                    {
                        lbl_BookStatus.Text = "ไม่ว่าง";
                        bt_ServiceAddList.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                read.Close();
                Connect.Close();
            }
            else if(txt_SearchBookID.Text == "" & cb_SearchBookName.Text != "")
            {
                Connect.Open();
                string cb_book = cb_SearchBookName.SelectedValue.ToString();
                sql = "SELECT *FROM [tab_book] WHERE book_id = '" + cb_book + "'";
                Cmd = new SqlCommand(sql, Connect);
                read = Cmd.ExecuteReader();
                if (read.Read())
                {
                    txt_ShowBookID.Text = read["book_id"].ToString();
                    txt_ShowBookName.Text = read["book_name"].ToString();
                    txt_RentDate.Text = read["book_rate"].ToString();
                    if (Convert.ToInt32(read["book_status"].ToString()) == 1)
                    {
                        lbl_BookStatus.Text = "ว่าง";
                        bt_ServiceAddList.Enabled = true;
                    }
                    else
                    {
                        lbl_BookStatus.Text = "ไม่ว่าง";
                        bt_ServiceAddList.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                read.Close();
                Connect.Close();
            }
            else if (txt_SearchBookID.Text != "" & cb_SearchBookName.Text != "")
            {
                MessageBox.Show("รูปแบบการค้นหาไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_ServiceAddList_Click(object sender, EventArgs e)
        {
            if(txt_ShowMemberID.Text == "" )
            {
                MessageBox.Show("กรุณาค้นหาหรือเลือกสมาชิกเพื่อดำเนินรายดาร", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ShowMemberID.Focus();
            }
            else
            {
                if(txt_ShowBookID.Text == "")
                {
                    MessageBox.Show("กรุณาดำเนินการค้นหาหนังสือที่ต้องการทำรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_SearchBookID.Focus();
                }
                else
                {
                    int Rent_out = date_Today.Value.Day - DateTime.Today.Day;
                    if (Rent_out <= 0)
                    {
                        MessageBox.Show("รูปแบบวันที่ยืมไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        date_Today.Focus();
                    }
                    else
                    {
                        Connect.Open();
                        sql = "SELECT m_quota FROM [tab_member] WHERE m_id = '" + txt_ShowMemberID.Text + "'";
                        Cmd = new SqlCommand(sql, Connect);
                        read = Cmd.ExecuteReader();
                        if (read.Read())
                        {
                            read.Close();
                            bt_ServiceAddList.Enabled = true;
                            int total_price = 0;
                            int rent_date = Convert.ToInt32(txt_RentDate.Text);
                            total_price = Rent_out * rent_date;
                            dt.Rows.Add(null, txt_ShowBookID.Text, txt_ShowBookName.Text, Rent_out, date_Today.Text, total_price);
                            ListView.DataSource = dt;
                            txt_TotalBook.Text = Convert.ToString(ListView.Rows.Count - 1);
                            Double price = 0;
                            for (i = 0; i < ListView.Rows.Count - 1; i++)
                            {
                                price += Convert.ToInt32(ListView.Rows[i].Cells[5].Value);
                            }
                            txt_Charge.Text = price.ToString();
                            txt_ShowMemberBooks2.Text = Convert.ToString(Convert.ToInt32(txt_ShowMemberBooks2.Text) - 1);
                            // Change Status Book //
                            int upStatus = 2;
                            SqlCommand updatebook_status = new SqlCommand("UPDATE [tab_book] SET book_status = '" + upStatus + "' WHERE book_id = '" + txt_ShowBookID.Text + "' ", Connect);
                            updatebook_status.ExecuteNonQuery();
                            // Clear Last Order
                            txt_ShowBookID.Text = "";
                            txt_ShowBookName.Text = "";
                            lbl_BookStatus.Text = "";
                            //date_RentDateOut.Value = DateTime.Now;
                            txt_RentDate.Text = "";
                        }
                        Connect.Close();
                    }
                }
            }
        }

        private void ListView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txt_ListShowBookID.Text = ListView.Rows[e.RowIndex].Cells["รหัสหนังสือ"].Value.ToString();
                txt_ListShowBookName.Text = ListView.Rows[e.RowIndex].Cells["ชื่อหนังสือ"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_DeleteList_Click(object sender, EventArgs e)
        {
            if(ListView.Rows.Count > 1)
            {
                if(ListView.Rows[ListView.CurrentRow.Index].IsNewRow != true)
                {
                    // Delete Count Book
                    ListView.Rows.Remove(ListView.CurrentRow);
                    txt_TotalBook.Text = Convert.ToString(ListView.Rows.Count - 1);
                    Double price = 0;
                    for (i = 0; i < ListView.Rows.Count - 1; i++)
                    {
                        price += Convert.ToInt32(ListView.Rows[i].Cells[5].Value);
                    }
                    txt_Charge.Text = price.ToString();
                    txt_ShowMemberBooks2.Text = Convert.ToString(Convert.ToInt32(txt_ShowMemberBooks2.Text) + 1);
                    // Update Status Book
                    int ChangeStatus = 1;
                    Connect.Open();
                    SqlCommand updatebook_status = new SqlCommand("UPDATE [tab_book] SET book_status = '" + ChangeStatus + "' WHERE book_id = '" + txt_ListShowBookID.Text + "' ", Connect);
                    updatebook_status.ExecuteNonQuery();
                    Connect.Close();
                    txt_ListShowBookID.Text = "";
                    txt_ListShowBookName.Text = "";
                }
            }
            else
            {
                MessageBox.Show("เลือกรายการที่ต้องการลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_success_Click(object sender, EventArgs e)
        {
            if (txt_ShowMemberID.Text == "")
            {
                MessageBox.Show("กรุณาใส่หรือค้นหาสมาชิกเพื่อทำรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_SearchMemberID.Focus();
            }
            else
            {
                int Rent_out = date_Today.Value.Day - DateTime.Today.Day;
                if (Rent_out <= 0)
                {
                    MessageBox.Show("จำนวนวันที่ยืมต้องไม่เป็น 0", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    date_Today.Focus();
                }
                else
                {
                    if (Rent_out > 7)
                    {
                        MessageBox.Show("ยืมได้ไม่เกิน 7 วันต่อเล่ม!!!!", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        date_Today.Focus();
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
                                if (MessageBox.Show("คุณต้องการชำระเงินหรือไม่", "ยืนนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    int Member_quota = 0;
                                    int SQLMember_rent = 0;
                                    int UpdateMember_rent = 0;
                                    int rentStatus = 1;
                                    Member_quota = Convert.ToInt32(txt_ShowMemberBooks2.Text);
                                    Connect.Open();
                                    sql = "SELECT *FROM [tab_member] WHERE m_id = '" + txt_ShowMemberID.Text + "' ";
                                    Cmd = new SqlCommand(sql, Connect);
                                    read = Cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        SQLMember_rent = Convert.ToInt32(read["m_rent"].ToString());
                                    }
                                    read.Close();
                                    UpdateMember_rent = Convert.ToInt32(SQLMember_rent) + Convert.ToInt32(txt_TotalBook.Text);
                                    SqlCommand quota = new SqlCommand("UPDATE [tab_member] SET m_rent = '" + UpdateMember_rent + "' , m_quota = '" + Member_quota + "' WHERE m_id = '" + txt_ShowMemberID.Text + "'", Connect);
                                    quota.ExecuteNonQuery();
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        sql = sql + "INSERT INTO [tab_rentreturn] (r_date,r_rentDate,r_empName,r_memID,r_bookID,r_bookName,r_rentStatus,r_Income) VALUES (@DateAdd,@RentDate_out,N'" + username + "','" + txt_ShowMemberID.Text + "','" + dt.Rows[i]["รหัสหนังสือ"].ToString().Trim() + "',N'" + dt.Rows[i]["ชื่อหนังสือ"].ToString().Trim() + "','" + rentStatus + "','" + dt.Rows[i]["คิดเป็นราคา"].ToString().Trim() + "')";
                                    }
                                    Cmd = new SqlCommand(sql, Connect);
                                    Cmd.Parameters.AddWithValue("@DateAdd", SqlDbType.DateTime).Value = DateTime.Now;
                                    Cmd.Parameters.AddWithValue("@RentDate_out", SqlDbType.DateTime).Value = date_Today.Value;
                                    Cmd.ExecuteNonQuery();
                                    Connect.Close();
                                    MessageBox.Show("ชำระเงินเสร็จสิ้น", "สำเร็จ", MessageBoxButtons.OK);
                                    Clear();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txt_Receive_TextChanged(object sender, EventArgs e)
        {
            if(txt_Receive.Text == "")
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

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            UpdateStatusBook();
            Clear();
        }

        private void Clear()
        {
            dt.Clear();
            dt.AcceptChanges();
            txt_SearchMemberID.Text = "";
            cb_SearchMemberName.Text = "";
            txt_ShowMemberID.Text = "";
            txt_ShowMemberName.Text = "";
            txt_ShowMemberType.Text = "";
            txt_ShowMemberBooks1.Text = "";
            txt_ShowMemberBooks2.Text = "";
            txt_SearchBookID.Text = "";
            cb_SearchBookName.Text = "";
            txt_ShowBookID.Text = "";
            txt_ShowBookName.Text = "";
            lbl_BookStatus.Text = "";
            txt_RentDate.Text = "";
            txt_TotalBook.Text = "";
            txt_Charge.Text = "0";
            txt_Receive.Text = "0";
            txt_Refund.Text = "";
            date_Today.Value = DateTime.Now;
        }

        private void CreateDataTable()
        {
            dt.Columns.Add("No", typeof(int));
            dt.Columns["No"].AutoIncrement = true;
            dt.Columns["No"].AutoIncrementSeed = 1;
            dt.Columns["No"].ReadOnly = true;
            dt.Columns.Add("รหัสหนังสือ", typeof(string));
            dt.Columns.Add("ชื่อหนังสือ", typeof(string));
            dt.Columns.Add("จำนวนวันที่ยืม", typeof(int));
            dt.Columns.Add("วันที่คืน", typeof(DateTime));
            dt.Columns.Add("คิดเป็นราคา", typeof(int));
        }

        private void SearchMemberCombobox()
        {
            try
            {
                Connect.Open();
                SqlDataAdapter sql_member = new SqlDataAdapter ("SELECT m_id,m_fname + ' ' + m_lname AS Fullname FROM [tab_member]",Connect);
                DataTable dtm = new DataTable();
                sql_member.Fill(dtm);
                cb_SearchMemberName.DisplayMember = "Fullname";
                cb_SearchMemberName.ValueMember = "m_id";
                cb_SearchMemberName.DataSource = dtm;
                Connect.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchBookCombobox()
        {
            try
            {
                Connect.Open();
                SqlDataAdapter sql_Book = new SqlDataAdapter("SELECT book_id,book_name FROM [tab_book]", Connect);
                DataTable dtb = new DataTable();
                sql_Book.Fill(dtb);
                cb_SearchBookName.DisplayMember = "book_name";
                cb_SearchBookName.ValueMember = "book_id";
                cb_SearchBookName.DataSource = dtb;
                Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void txt_SearchBookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_SearchBookID.Focus();
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

        private void cb_SearchMemberName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                cb_SearchMemberName.Focus();
            }
        }

        private void Tool1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateStatusBook();
            Clear();
        }

        private void UpdateStatusBook()
        {
            int ChangeStatus = 1;
            Connect.Open();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SqlCommand updatebook_status = new SqlCommand("UPDATE [tab_book] SET book_status = '" + ChangeStatus + "' WHERE book_name COLLATE THAI_BIN LIKE N'" + dt.Rows[i]["ชื่อหนังสือ"].ToString().Trim() + "' ", Connect);
                updatebook_status.ExecuteNonQuery();
            }
            Connect.Close();
        }

        private void cb_SelectSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

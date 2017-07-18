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
using System.Globalization;

namespace ProjectSA
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet(); // สร้างตารางรับข้อมูล;
        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True"); // ส่วนเชื่อมต่อกับเซิฟเวอร์ฐานข้อมูล;
        SqlCommand Cmd; // คำสั่งสำหรับการ Query;
        SqlDataReader read; // คำสั่งสำหรับอ่านข้อมูล;
        string sql = null; // ตัวแปรในการ sql ข้อมูล;

        private void Books_Load(object sender, EventArgs e)
        {
            sql = "SELECT *FROM [tab_book]"; // ทำการเลือกตาราง tab_book เพื่อนำมาแสดงบน datagridview;
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect); // คำสั่งนำเอา sql ด้านบนมาทำการ connect กับ server ฐานข้อมูล;
            da.Fill(ds, "book_id"); // เลือก รหัสหนังสือ เป็น Fill Primary;
            ListView_DataBooks.DataSource = ds.Tables["book_id"]; // นำไปแสดงบล datagridview;
            ListViewAddBook.DataSource = ds.Tables["book_id"]; // นำไปแสดงบล datagridview;
            HeaderDatagridBookView();
        }

        private void ListView_DataBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ListView_DataBooks.Rows[e.RowIndex].Selected = true; // เมื่อทำการคลิกเลือก Row บน datagridview;
                DataRow dr = ds.Tables["book_id"].Rows[e.RowIndex]; // เลือก รหัสหนังสือ เป็น Primary;
                txt_ShowBooksID.Text = dr["book_id"].ToString(); // ให้ รหัสหนังสือ แสดงผลบน TextBox;
                txt_ShowBooksName.Text = dr["book_name"].ToString(); // ให้ ชื่อหนังสือ แสดงผลบน TextBox;
                if (Convert.ToInt32(dr["book_type"].ToString()) == 1)
                {
                    // ประเภทหนังสือ 1 = การ์ตูน;
                    cb_bookType.Text = "การ์ตูน";
                }
                else
                {
                    // ประเภทหนังสือ 2 = นวนิยาย;
                    cb_bookType.Text = "นวนิยาย";
                }
                txt_ShowBooksPrice.Text = dr["book_price"].ToString(); // ให้ ราคาหนังสือ แสดงผลบน TextBox;
                txt_ShowBooksPublisher.Text = dr["book_publisher"].ToString(); // ให้ สำนักพิมพ์ แสดงผลบน TextBox;
                date_BooksAddDate.Value = Convert.ToDateTime(dr["book_addDate"].ToString()); // ให้ วันที่นำเข้า แสดงผลบน TextBox;
                txt_ShowBooksRate.Text = dr["book_rate"].ToString(); // ให้ เรทราคา แสดงผลบน TextBox;
                if (Convert.ToInt32(dr["book_status"].ToString()) == 1)
                {
                    // สถานะหนังสือ 1 = ว่าง;
                    txt_ShowBooksStatus.Text = "ว่าง";
                }
                else
                {
                    // สถานะหนังสือ 2 = ไม่ว่าง
                    txt_ShowBooksStatus.Text = "ไม่ว่าง";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bt_SearchBooks_Click(object sender, EventArgs e)
        {
            if(txt_SeachBookName.Text == "" & cb_SearchBookType.Text == "")
            {
                MessageBox.Show("โปรดเลือก ประเภทสมาชิก หรือ ค้นหา รหัสสมาชิก", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_SeachBookName.Focus();
            }
            else if(txt_SeachBookName.Text != "" & cb_SearchBookType.Text == "")
            {
                ds.Clear();
                sql = "SELECT *FROM [tab_book] WHERE book_name COLLATE THAI_BIN LIKE N'"+txt_SeachBookName.Text+"%'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "book_id");
                ListView_DataBooks.DataSource = ds.Tables["book_id"];
            }
            else if(txt_SeachBookName.Text == "" & cb_SearchBookType.Text != ""){
                if (cb_SearchBookType.SelectedIndex == 0)
                {
                    ds.Clear();
                    sql = "SELECT *FROM [tab_book] WHERE book_type = 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "book_id");
                    ListView_DataBooks.DataSource = ds.Tables["book_id"];
                }
                else
                {
                    ds.Clear();
                    sql = "SELECT *FROM [tab_book] WHERE book_type = 2";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "book_id");
                    ListView_DataBooks.DataSource = ds.Tables["book_id"];
                }
            }
            else if (txt_SeachBookName.Text != "" & cb_SearchBookType.Text != "")
            {
                MessageBox.Show("รูปแบบการค้นหาไม่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void bt_SaveChangeBooks_Click(object sender, EventArgs e)
        {
            if(txt_ShowBooksName.Text == "")
            {
                MessageBox.Show("ชื่อหนังสือต้องไม่เป็นค่าว่าง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ShowBooksName.Focus();
            }
            else if(txt_ShowBooksPrice.Text == "")
            {
                MessageBox.Show("ต้องระบุราคาหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_ShowBooksPrice.Focus();
            }
            else
            {
                if (MessageBox.Show("ยินยันการเปลี่ยนแปลงข้อมูล", "ยืนนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    double ConRate;
                    ConRate = Convert.ToDouble(txt_ShowBooksPrice.Text) / 10;
                    DataRow[] drs = ds.Tables["book_id"].Select("book_id = '" + txt_ShowBooksID.Text + "' ");
                    drs[0]["book_name"] = txt_ShowBooksName.Text;
                    drs[0]["book_price"] = txt_ShowBooksPrice.Text;
                    if(cb_bookType.SelectedIndex == 0)
                    {
                        drs[0]["book_type"] = 1;
                    }
                    else
                    {
                        drs[0]["book_type"] = 2;
                    }
                    drs[0]["book_publisher"] = txt_ShowBooksPublisher.Text;
                    drs[0]["book_rate"] = ConRate;
                    MessageBox.Show("เปลี่ยนแปลงข้อมูลสำเร็จ", "สำเร็จ", MessageBoxButtons.OK);
                    cb_bookType.Text = "";
                    txt_ShowBooksID.Text = "";
                    txt_ShowBooksName.Text = "";
                    txt_ShowBooksPrice.Text = "";
                    txt_ShowBooksPublisher.Text = "";
                    date_BooksAddDate.Value = DateTime.Now;
                    txt_ShowBooksRate.Text = "";
                    txt_ShowBooksStatus.Text = "";
                }
            }
        }

        private void bt_DelBook_Click(object sender, EventArgs e)
        {
            DataRow[] drs = ds.Tables["book_id"].Select("book_id = '" + txt_ShowBooksID.Text + "'");
            if(drs.Length == 0){
                MessageBox.Show("กรุณาเลือกหนังสือที่ต้องการดำเนินรายการ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("คุณต้องการลบหนังสือ " + txt_ShowBooksName.Text + " หรือไม่", "ยืนนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    drs[0].Delete();
                    sql = "SELECT *FROM [tab_book]";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    da.Update(ds, "book_id");
                    ds.Tables["book_id"].AcceptChanges();
                    MessageBox.Show("ลบสำเร็จ", "สำเร็จ", MessageBoxButtons.OK);
                    //Clear
                    cb_bookType.Text = "";
                    txt_ShowBooksID.Text = "";
                    txt_ShowBooksName.Text = "";
                    txt_ShowBooksPrice.Text = "";
                    txt_ShowBooksPublisher.Text = "";
                    date_BooksAddDate.Value = DateTime.Now;
                    txt_ShowBooksRate.Text = "";
                    txt_ShowBooksStatus.Text = "";
                }
            }
        }

        private void bt_CancelEditBooks_Click(object sender, EventArgs e)
        {
            ds.Clear();
            sql = "SELECT *FROM [tab_book]";
            SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
            da.Fill(ds, "book_id");
            ListView_DataBooks.DataSource = ds.Tables["book_id"];
            //Clear
            txt_SeachBookName.Text = "";
            cb_SearchBookType.Text = "";
            cb_bookType.Text = "";
            txt_ShowBooksID.Text = "";
            txt_ShowBooksName.Text = "";
            txt_ShowBooksPrice.Text = "";
            txt_ShowBooksPublisher.Text = "";
            date_BooksAddDate.Value = DateTime.Now;
            txt_ShowBooksRate.Text = "";
            txt_ShowBooksStatus.Text = "";
        }

        private void txt_ShowBooksPrice_TextChanged(object sender, EventArgs e)
        {
            if(txt_ShowBooksPrice.Text == "")
            {
                txt_ShowBooksPrice.Text = "0";
            }
            else
            {
                double ConRate;
                ConRate = Convert.ToDouble(txt_ShowBooksPrice.Text) / 10;
                txt_ShowBooksRate.Text = Convert.ToString(ConRate);
            }
        }

        private void bt_AddSaveChange_Click(object sender, EventArgs e)
        {
            if(txt_AddBookName.Text == "")
            {
                MessageBox.Show("กรุณากรอกชื่อหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_AddBookName.Focus();
            }
            else
            {
                if(txt_AddBookPublisher.Text == "")
                {
                    MessageBox.Show("กรุณากรอกชื่อสำนักพิมพ์", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txt_AddBookPublisher.Focus();
                }
                else
                {
                    if(cb_AddBookType.Text == ""){
                        MessageBox.Show("กรุณาเลือกประเภทหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tabPage2.Focus();
                    }
                    else
                    {
                        if (txt_AddBookPrice.Text == "")
                        {
                            MessageBox.Show("กรุณาระบุราคาหนังสือ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txt_AddBookPrice.Focus();
                        }
                        else
                        {
                            Connect.Open();
                            sql = "SELECT book_name FROM [tab_book] WHERE book_name COLLATE THAI_BIN LIKE N'" + txt_AddBookName.Text + "%'";
                            Cmd = new SqlCommand(sql, Connect);
                            read = Cmd.ExecuteReader();
                            if (read.Read())
                            {
                                MessageBox.Show("มีชื่อหนังสือนี้อยู่แล้วในระบบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                txt_AddBookName.Focus(); 
                            }
                            else
                            {
                                read.Close();
                                if (MessageBox.Show("ยืนยันการเพิ่มหนังสือ", "ยืนนยัน", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    
                                    string Book_id1 = randomnumber(1000, 9999).ToString();
                                    string Book_id2 = randomnumber(10000, 99999).ToString();
                                    double book_Rate;
                                    book_Rate = Convert.ToInt32(txt_AddBookPrice.Text) / 10;
                                    sql = "INSERT INTO [tab_book] (book_id,book_name,book_type,book_price,book_publisher,book_addDate,book_rate,book_status) VALUES (@book_id,N'" + txt_AddBookName.Text + "',@book_type,'" + txt_AddBookPrice.Text + "',N'" + txt_AddBookPublisher.Text + "',@DateAdd,'" + book_Rate + "',@book_status)";
                                    Cmd = new SqlCommand(sql, Connect);
                                    if (cb_AddBookType.SelectedIndex == 0)
                                    {
                                        Cmd.Parameters.AddWithValue("@book_id", Book_id1);
                                        Cmd.Parameters.AddWithValue("@book_type", 1);
                                    }
                                    else
                                    {
                                        Cmd.Parameters.AddWithValue("@book_id", Book_id2);
                                        Cmd.Parameters.AddWithValue("@book_type", 2);
                                    }
                                    Cmd.Parameters.AddWithValue("@DateAdd", SqlDbType.DateTime).Value = date_AddBook.Value;
                                    Cmd.Parameters.AddWithValue("@book_status", 1);
                                    Cmd.ExecuteNonQuery();
                                    MessageBox.Show("บันทึกข้อมูลสำเร็จ", "บันทึกสำเร็จ", MessageBoxButtons.OK);
                                    ds.Clear();
                                    sql = "SELECT *FROM [tab_book]";
                                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                                    da.Fill(ds, "book_id");
                                    ListViewAddBook.DataSource = ds.Tables["book_id"];
                                    txt_AddBookName.Text = "";
                                    txt_AddBookPublisher.Text = "";
                                    cb_AddBookType.Text = "";
                                    txt_AddBookPrice.Text = "0";
                                    txt_AddBookRate.Text = "";
                                }
                            }
                            Connect.Close();
                        }
                    }
                }
            }
        }

        private void bt_AddCancel_Click(object sender, EventArgs e)
        {
            txt_AddBookName.Text = "";
            txt_AddBookPrice.Text = "";
            cb_AddBookType.Text = "";
            txt_AddBookPublisher.Text = "";
            txt_AddBookRate.Text = "";
        }

        private int randomnumber(int min, int max)
        {
            Random rnum = new Random();
            return rnum.Next(min, max);
        }

        private void txt_AddBookPrice_TextChanged(object sender, EventArgs e)
        {
            if(txt_AddBookPrice.Text == "")
            {
                txt_AddBookPrice.Text = "0";
            }
            else
            {
                double book_Rate;
                book_Rate = Convert.ToInt32(txt_AddBookPrice.Text) / 10;
                txt_AddBookRate.Text = book_Rate.ToString();
            }
        }

        private void HeaderDatagridBookView()
        {
            ListView_DataBooks.Columns[0].HeaderCell.Value = "รหัสหนังสือ";
            ListView_DataBooks.Columns[1].HeaderCell.Value = "ชื่อหนังสือ";
            ListView_DataBooks.Columns[2].HeaderCell.Value = "ประเภทหนังสือ";
            ListView_DataBooks.Columns[3].HeaderCell.Value = "ราคาหนังสิอ";
            ListView_DataBooks.Columns[4].HeaderCell.Value = "สำนักพิมพ์";
            ListView_DataBooks.Columns[5].HeaderCell.Value = "วันที่นำเข้า";
            ListView_DataBooks.Columns[6].HeaderCell.Value = "เรทราคาหนังสือ";
            ListView_DataBooks.Columns[7].HeaderCell.Value = "สถานะหนังสือ";
            ListViewAddBook.Columns[0].HeaderCell.Value = "รหัสหนังสือ";
            ListViewAddBook.Columns[1].HeaderCell.Value = "ชื่อหนังสือ";
            ListViewAddBook.Columns[2].HeaderCell.Value = "ประเภทหนังสือ";
            ListViewAddBook.Columns[3].HeaderCell.Value = "ราคาหนังสิอ";
            ListViewAddBook.Columns[4].HeaderCell.Value = "สำนักพิมพ์";
            ListViewAddBook.Columns[5].HeaderCell.Value = "วันที่นำเข้า";
            ListViewAddBook.Columns[6].HeaderCell.Value = "เรทราคาหนังสือ";
            ListViewAddBook.Columns[7].HeaderCell.Value = "สถานะหนังสือ";
        }

        private void txt_SeachBookName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 44 && (int)e.KeyChar <= 57)
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวหนังสือ!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_SeachBookName.Focus();
            }
        }

        private void txt_ShowBooksPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowBooksPrice.Focus();
            }
        }

        private void txt_ShowBooksRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_ShowBooksRate.Focus();
            }
        }

        private void txt_AddBookPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("กรอกได้เฉพาะตัวเลข!", "ข้อผิดพลาด", MessageBoxButtons.OK);
                txt_AddBookPrice.Focus();
            }
        }
    }
}

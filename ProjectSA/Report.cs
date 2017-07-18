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
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectSA
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            label3.Hide();
            txt_TotalIncome.Hide();
            label4.Hide();
        }

        DataSet ds = new DataSet();
        SqlConnection Connect = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\First-Mac\Desktop\SAD(Program)\ProjectSA\ProjectSA\Database1.mdf;Integrated Security=True");
        string sql = null;

        private void bt_Selected_Click(object sender, EventArgs e)
        {
            if (cb_Select.SelectedIndex == 0)
            {
                ds.Clear();
                ds.Reset();
                string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date = '" + date_Select.Value.ToString("2016-MM-dd") +"'";
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "No");
                dataListAll.DataSource = ds.Tables["No"];
                label3.Show();
                txt_TotalIncome.Show();
                label4.Show();
                Double TotalIncome = 0;
                for (int i = 0; i < dataListAll.Rows.Count - 1; i++)
                {
                    TotalIncome += Convert.ToInt32(dataListAll.Rows[i].Cells[8].Value);
                }
                txt_TotalIncome.Text = TotalIncome.ToString();
                bookRentHeader();
            }
            else if (cb_Select.SelectedIndex == 1)
            {
                ds.Clear();
                ds.Reset();
                string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date = '" + date_Select.Value.ToString("2016-MM-dd") + "' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "No");
                dataListAll.DataSource = ds.Tables["No"];
                dataListAll.Columns[0].HeaderCell.Value = "รหัสหนังสือ";
                dataListAll.Columns[1].HeaderCell.Value = "ชื่อหนังสือ";
            }
            else if (cb_Select.SelectedIndex == 2)
            {
                ds.Clear();
                ds.Reset();
                sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date = '" + date_Select.Value.ToString("2016-MM-dd") + "'))";
                SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                da.Fill(ds, "No");
                dataListAll.DataSource = ds.Tables["No"];
                bookRentHeader();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกประเภทรายงาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_Select.Focus();
            }
        }

        private void bookRentHeader()
        {
            dataListAll.Columns[0].HeaderCell.Value = "No";
            dataListAll.Columns[1].HeaderCell.Value = "วันที่ยืม";
            dataListAll.Columns[2].HeaderCell.Value = "วันที่คืน";
            dataListAll.Columns[3].HeaderCell.Value = "พนักงานขาย";
            dataListAll.Columns[4].HeaderCell.Value = "รหัสสมาชิก";
            dataListAll.Columns[5].HeaderCell.Value = "รหัสหนังสือ";
            dataListAll.Columns[6].HeaderCell.Value = "ชื่อหนังสือ";
            dataListAll.Columns[7].HeaderCell.Value = "สถานะการคืน";
            dataListAll.Columns[8].HeaderCell.Value = "การชำระเงิน(บาท)";
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            ds.Clear();
            ds.Reset();
            ds.AcceptChanges();
            dataListAll.Refresh();
            dataListAll.Update();
            cb_Select.Text = "- เลือกประเภทรายงาน -";
            cb_Select2.Text = "- เลือกประเภทรายงาน -";
            cb_SelectMonth.Text = "- กรุณาเลือกเดือน -";
            date_Select.Value = DateTime.Now;
        }

        private void bt_Month_Click(object sender, EventArgs e)
        {
            if(cb_Select2.SelectedIndex == 0)
            {
                if(cb_SelectMonth.SelectedIndex == 0)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-01-01' and '2016-01-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if(cb_SelectMonth.SelectedIndex == 1)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-02-01' and '2016-02-29'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 2)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-03-01' and '2016-03-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 3)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-04-01' and '2016-04-30'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 4)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-05-01' and '2016-05-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 5)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-06-01' and '2016-06-30'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 6)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-07-01' and '2016-07-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 7)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-08-01' and '2016-08-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 8)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-09-01' and '2016-09-30'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 9)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-10-01' and '2016-10-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 10)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-11-01' and '2016-11-30'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else if (cb_SelectMonth.SelectedIndex == 11)
                {
                    DS();
                    string sql = "SELECT *FROM [tab_rentreturn] WHERE r_date between '2016-12-01' and '2016-12-31'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    SummaryReport();
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกเดือน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cb_SelectMonth.Focus();
                }
            }
            else if(cb_Select2.SelectedIndex == 1)
            {
                if(cb_SelectMonth.SelectedIndex == 0)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-01-01' and '2016-01-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 1)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-02-01' and '2016-02-29' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 2)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-03-01' and '2016-03-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 3)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-04-01' and '2016-04-30' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 4)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-05-01' and '2016-05-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 5)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-06-01' and '2016-06-30' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 6)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-07-01' and '2016-07-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 7)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-08-01' and '2016-08-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 8)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-09-01' and '2016-09-30' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 9)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-10-01' and '2016-10-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 10)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-11-01' and '2016-11-30' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else if (cb_SelectMonth.SelectedIndex == 11)
                {
                    DS();
                    string sql = "SELECT r_bookID,r_bookName FROM [tab_rentreturn] WHERE r_date between '2016-12-01' and '2016-12-31' GROUP BY r_bookID,r_bookName HAVING COUNT(r_bookID) >1 ORDER BY 1";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    BookFavor();
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกเดือน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cb_SelectMonth.Focus();
                }
            }
            else if(cb_Select2.SelectedIndex == 2)
            {
                if(cb_SelectMonth.SelectedIndex == 0)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-01-01' and '2016-01-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 1)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-02-01' and '2016-02-29'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 2)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-03-01' and '2016-03-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 3)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-04-01' and '2016-04-30'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 4)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-05-01' and '2016-05-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 5)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-06-01' and '2016-01-30'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 6)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-07-01' and '2016-07-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 7)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-08-01' and '2016-08-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 8)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-09-01' and '2016-09-30'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 9)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-10-01' and '2016-10-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 10)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-11-01' and '2016-11-30'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else if (cb_SelectMonth.SelectedIndex == 11)
                {
                    sql = "SELECT *FROM [tab_rentreturn] WHERE ((r_rentStatus = 1) and (r_date between '2016-12-01' and '2016-12-31'))";
                    SqlDataAdapter da = new SqlDataAdapter(sql, Connect);
                    da.Fill(ds, "No");
                    dataListAll.DataSource = ds.Tables["No"];
                    bookRentHeader();
                }
                else
                {
                    MessageBox.Show("กรุณาเลือกเดือน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cb_SelectMonth.Focus();
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกประเภทรายงาน", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cb_Select2.Focus();
            }
        }

        private void SummaryReport()
        { 
            label3.Show();
            txt_TotalIncome.Show();
            label4.Show();
            Double TotalIncome = 0;
            for (int i = 0; i < dataListAll.Rows.Count - 1; i++)
            {
                TotalIncome += Convert.ToInt32(dataListAll.Rows[i].Cells[8].Value);
            }
            txt_TotalIncome.Text = TotalIncome.ToString();
            bookRentHeader();
        }

        private void BookFavor()
        {
            dataListAll.DataSource = ds.Tables["No"];
            dataListAll.Columns[0].HeaderCell.Value = "รหัสหนังสือ";
            dataListAll.Columns[1].HeaderCell.Value = "ชื่อหนังสือ";
        }

        private void DS()
        {
            ds.Clear();
            ds.Reset();
            ds.AcceptChanges();
            dataListAll.Refresh();
            dataListAll.Update();
        }

        private void bt_print_Click(object sender, EventArgs e)
        {
            if(cb_Select.SelectedIndex == 0)
            {
                Excel._Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel._Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                for (i = 0; i <= dataListAll.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataListAll.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataListAll[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("รายงานยอดขายประจำเดือน.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
                
                MessageBox.Show("ทำการสรุปรายการยอดขายประจำเดือนเรียบร้อยแล้ว" + "\n" + "สามารถดูสรุปยอดรายงานได้ที่ Libraries\\Documents\\รายงานยอดขายประจำเดือน.xls ค่ะ");
            }
            else if(cb_Select.SelectedIndex == 1)
            {
                Excel._Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel._Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                for (i = 0; i <= dataListAll.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataListAll.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataListAll[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("รายงานยอดขายหนังสือนิยมสูงสุด.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("ทำการสรุปรายงานยอดขายหนังสือนิยมสูงสุด เรียบร้อยแล้ว" + "\n" + "สามารถดูสรุปยอดรายงานได้ที่ Libraries\\Documents\\รายงานยอดขายหนังสือนิยมสูงสุด.xls ค่ะ");
            }
            else if(cb_Select.SelectedIndex == 2)
            {
                Excel._Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel._Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                for (i = 0; i <= dataListAll.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataListAll.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataListAll[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("รายงานหนังสือที่ยังไม่ส่งคืน.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("ทำการสรุปรายงานหนังสือที่ยังไม่ส่งคืน เรียบร้อยแล้ว" + "\n" + "สามารถดูสรุปยอดรายงานได้ที่ Libraries\\Documents\\รายงานหนังสือที่ยังไม่ส่งคืน.xls ค่ะ");
            }

            else if(cb_Select2.SelectedIndex == 0)
            {
                Excel._Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel._Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel._Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;

                for (i = 0; i <= dataListAll.RowCount - 1; i++)
                {
                    for (j = 0; j <= dataListAll.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataListAll[j, i];
                        xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                    }
                }

                xlWorkBook.SaveAs("รายงานยอดขายประจำเดือน_"+ cb_SelectMonth.Text +".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                MessageBox.Show("ทำการสรุปรายการยอดขายประจำเดือนเรียบร้อยแล้ว" + "\n" + "สามารถดูสรุปยอดรายงานได้ที่ Libraries\\Documents\\รายงานยอดขายประจำเดือน_" + cb_SelectMonth.Text + ".xls ค่ะ");
            }

        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}

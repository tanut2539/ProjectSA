namespace ProjectSA
{
    partial class Tool1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tool1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_SearchMemberName = new System.Windows.Forms.ComboBox();
            this.bt_ServiceSearchMember = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SearchMemberID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_ShowMemberType = new System.Windows.Forms.TextBox();
            this.txt_ShowMemberName = new System.Windows.Forms.TextBox();
            this.txt_ShowMemberID = new System.Windows.Forms.TextBox();
            this.txt_ShowMemberBooks2 = new System.Windows.Forms.TextBox();
            this.txt_ShowMemberBooks1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_SearchBookName = new System.Windows.Forms.ComboBox();
            this.bt_ServiceSearchBooks = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SearchBookID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.date_Today = new System.Windows.Forms.DateTimePicker();
            this.bt_ServiceAddList = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_RentDate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_BookStatus = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_ShowBookName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_ShowBookID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bt_DeleteList = new System.Windows.Forms.Button();
            this.txt_ListShowBookName = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_ListShowBookID = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.ListView = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_success = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Refund = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Receive = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Charge = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_TotalBook = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListView)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_SearchMemberName);
            this.groupBox1.Controls.Add(this.bt_ServiceSearchMember);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_SearchMemberID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหาสมาชิก";
            // 
            // cb_SearchMemberName
            // 
            this.cb_SearchMemberName.FormattingEnabled = true;
            this.cb_SearchMemberName.Location = new System.Drawing.Point(182, 96);
            this.cb_SearchMemberName.Name = "cb_SearchMemberName";
            this.cb_SearchMemberName.Size = new System.Drawing.Size(285, 28);
            this.cb_SearchMemberName.TabIndex = 5;
            this.cb_SearchMemberName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_SearchMemberName_KeyPress);
            // 
            // bt_ServiceSearchMember
            // 
            this.bt_ServiceSearchMember.Image = global::ProjectSA.Properties.Resources.Search_memberTool;
            this.bt_ServiceSearchMember.Location = new System.Drawing.Point(182, 136);
            this.bt_ServiceSearchMember.Name = "bt_ServiceSearchMember";
            this.bt_ServiceSearchMember.Size = new System.Drawing.Size(149, 48);
            this.bt_ServiceSearchMember.TabIndex = 4;
            this.bt_ServiceSearchMember.Text = "ค้นหาสมาชิก";
            this.bt_ServiceSearchMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ServiceSearchMember.UseVisualStyleBackColor = true;
            this.bt_ServiceSearchMember.Click += new System.EventHandler(this.bt_ServiceSearchMember_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ค้นหาจาก ชื่อสมาชิก";
            // 
            // txt_SearchMemberID
            // 
            this.txt_SearchMemberID.Location = new System.Drawing.Point(182, 39);
            this.txt_SearchMemberID.Name = "txt_SearchMemberID";
            this.txt_SearchMemberID.Size = new System.Drawing.Size(285, 26);
            this.txt_SearchMemberID.TabIndex = 1;
            this.txt_SearchMemberID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchMemberID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ค้นหาจากรหัสสมาชิก";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_ShowMemberType);
            this.groupBox2.Controls.Add(this.txt_ShowMemberName);
            this.groupBox2.Controls.Add(this.txt_ShowMemberID);
            this.groupBox2.Controls.Add(this.txt_ShowMemberBooks2);
            this.groupBox2.Controls.Add(this.txt_ShowMemberBooks1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(515, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 205);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลสมาชิก";
            // 
            // txt_ShowMemberType
            // 
            this.txt_ShowMemberType.Enabled = false;
            this.txt_ShowMemberType.Location = new System.Drawing.Point(142, 116);
            this.txt_ShowMemberType.Name = "txt_ShowMemberType";
            this.txt_ShowMemberType.Size = new System.Drawing.Size(328, 26);
            this.txt_ShowMemberType.TabIndex = 9;
            // 
            // txt_ShowMemberName
            // 
            this.txt_ShowMemberName.Enabled = false;
            this.txt_ShowMemberName.Location = new System.Drawing.Point(142, 77);
            this.txt_ShowMemberName.Name = "txt_ShowMemberName";
            this.txt_ShowMemberName.Size = new System.Drawing.Size(328, 26);
            this.txt_ShowMemberName.TabIndex = 8;
            // 
            // txt_ShowMemberID
            // 
            this.txt_ShowMemberID.Enabled = false;
            this.txt_ShowMemberID.Location = new System.Drawing.Point(142, 39);
            this.txt_ShowMemberID.Name = "txt_ShowMemberID";
            this.txt_ShowMemberID.Size = new System.Drawing.Size(328, 26);
            this.txt_ShowMemberID.TabIndex = 7;
            // 
            // txt_ShowMemberBooks2
            // 
            this.txt_ShowMemberBooks2.Enabled = false;
            this.txt_ShowMemberBooks2.Location = new System.Drawing.Point(391, 158);
            this.txt_ShowMemberBooks2.Name = "txt_ShowMemberBooks2";
            this.txt_ShowMemberBooks2.Size = new System.Drawing.Size(79, 26);
            this.txt_ShowMemberBooks2.TabIndex = 6;
            // 
            // txt_ShowMemberBooks1
            // 
            this.txt_ShowMemberBooks1.Enabled = false;
            this.txt_ShowMemberBooks1.Location = new System.Drawing.Point(142, 158);
            this.txt_ShowMemberBooks1.Name = "txt_ShowMemberBooks1";
            this.txt_ShowMemberBooks1.Size = new System.Drawing.Size(89, 26);
            this.txt_ShowMemberBooks1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "จำนวนหนังสือที่ยืมได้";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "หนังสือที่ค้างยืม";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "ประเภทสมาชิก";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "ชื่อสมาชิก";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "รหัสสมาชิก";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cb_SearchBookName);
            this.groupBox3.Controls.Add(this.bt_ServiceSearchBooks);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_SearchBookID);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox3.Location = new System.Drawing.Point(12, 236);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(486, 218);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ค้นหาหนังสือ";
            // 
            // cb_SearchBookName
            // 
            this.cb_SearchBookName.FormattingEnabled = true;
            this.cb_SearchBookName.Location = new System.Drawing.Point(182, 90);
            this.cb_SearchBookName.Name = "cb_SearchBookName";
            this.cb_SearchBookName.Size = new System.Drawing.Size(285, 28);
            this.cb_SearchBookName.TabIndex = 6;
            // 
            // bt_ServiceSearchBooks
            // 
            this.bt_ServiceSearchBooks.Image = global::ProjectSA.Properties.Resources.Search_memberTool;
            this.bt_ServiceSearchBooks.Location = new System.Drawing.Point(182, 136);
            this.bt_ServiceSearchBooks.Name = "bt_ServiceSearchBooks";
            this.bt_ServiceSearchBooks.Size = new System.Drawing.Size(285, 48);
            this.bt_ServiceSearchBooks.TabIndex = 5;
            this.bt_ServiceSearchBooks.Text = "ค้นหาหนังสือ";
            this.bt_ServiceSearchBooks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ServiceSearchBooks.UseVisualStyleBackColor = true;
            this.bt_ServiceSearchBooks.Click += new System.EventHandler(this.bt_ServiceSearchBooks_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(129, 20);
            this.label9.TabIndex = 2;
            this.label9.Text = "ค้นหาจาก ชื่อหนังสือ";
            // 
            // txt_SearchBookID
            // 
            this.txt_SearchBookID.Location = new System.Drawing.Point(182, 47);
            this.txt_SearchBookID.Name = "txt_SearchBookID";
            this.txt_SearchBookID.Size = new System.Drawing.Size(285, 26);
            this.txt_SearchBookID.TabIndex = 1;
            this.txt_SearchBookID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchBookID_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "ค้นหาจาก รหัสหนังสือ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.date_Today);
            this.groupBox4.Controls.Add(this.bt_ServiceAddList);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.txt_RentDate);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.lbl_BookStatus);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txt_ShowBookName);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txt_ShowBookID);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox4.Location = new System.Drawing.Point(515, 236);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 218);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ผลการค้นหา";
            // 
            // date_Today
            // 
            this.date_Today.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_Today.Location = new System.Drawing.Point(142, 122);
            this.date_Today.Name = "date_Today";
            this.date_Today.Size = new System.Drawing.Size(132, 26);
            this.date_Today.TabIndex = 18;
            // 
            // bt_ServiceAddList
            // 
            this.bt_ServiceAddList.Image = global::ProjectSA.Properties.Resources.Add_list;
            this.bt_ServiceAddList.Location = new System.Drawing.Point(315, 161);
            this.bt_ServiceAddList.Name = "bt_ServiceAddList";
            this.bt_ServiceAddList.Size = new System.Drawing.Size(155, 38);
            this.bt_ServiceAddList.TabIndex = 17;
            this.bt_ServiceAddList.Text = "เพิ่มลงรายการ";
            this.bt_ServiceAddList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ServiceAddList.UseVisualStyleBackColor = true;
            this.bt_ServiceAddList.Click += new System.EventHandler(this.bt_ServiceAddList_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 127);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 20);
            this.label15.TabIndex = 15;
            this.label15.Text = "วันที่ทำรายการ";
            // 
            // txt_RentDate
            // 
            this.txt_RentDate.Location = new System.Drawing.Point(370, 124);
            this.txt_RentDate.Name = "txt_RentDate";
            this.txt_RentDate.Size = new System.Drawing.Size(100, 26);
            this.txt_RentDate.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(284, 127);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "ค่าเช่า / วัน";
            // 
            // lbl_BookStatus
            // 
            this.lbl_BookStatus.AutoSize = true;
            this.lbl_BookStatus.Location = new System.Drawing.Point(138, 170);
            this.lbl_BookStatus.Name = "lbl_BookStatus";
            this.lbl_BookStatus.Size = new System.Drawing.Size(0, 20);
            this.lbl_BookStatus.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 20);
            this.label12.TabIndex = 11;
            this.label12.Text = "สถานะ";
            // 
            // txt_ShowBookName
            // 
            this.txt_ShowBookName.Enabled = false;
            this.txt_ShowBookName.Location = new System.Drawing.Point(142, 84);
            this.txt_ShowBookName.Name = "txt_ShowBookName";
            this.txt_ShowBookName.Size = new System.Drawing.Size(328, 26);
            this.txt_ShowBookName.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "ชื่อหนังสือ";
            // 
            // txt_ShowBookID
            // 
            this.txt_ShowBookID.Enabled = false;
            this.txt_ShowBookID.Location = new System.Drawing.Point(142, 41);
            this.txt_ShowBookID.Name = "txt_ShowBookID";
            this.txt_ShowBookID.Size = new System.Drawing.Size(328, 26);
            this.txt_ShowBookID.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "รหัสหนังสือ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.bt_DeleteList);
            this.groupBox5.Controls.Add(this.txt_ListShowBookName);
            this.groupBox5.Controls.Add(this.label25);
            this.groupBox5.Controls.Add(this.txt_ListShowBookID);
            this.groupBox5.Controls.Add(this.label24);
            this.groupBox5.Controls.Add(this.ListView);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox5.Location = new System.Drawing.Point(12, 468);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(707, 254);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "รายการเช่ายืม";
            // 
            // bt_DeleteList
            // 
            this.bt_DeleteList.Image = global::ProjectSA.Properties.Resources.cancel_list;
            this.bt_DeleteList.Location = new System.Drawing.Point(570, 210);
            this.bt_DeleteList.Name = "bt_DeleteList";
            this.bt_DeleteList.Size = new System.Drawing.Size(117, 32);
            this.bt_DeleteList.TabIndex = 5;
            this.bt_DeleteList.Text = "ลบรายการ";
            this.bt_DeleteList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_DeleteList.UseVisualStyleBackColor = true;
            this.bt_DeleteList.Click += new System.EventHandler(this.bt_DeleteList_Click);
            // 
            // txt_ListShowBookName
            // 
            this.txt_ListShowBookName.Enabled = false;
            this.txt_ListShowBookName.Location = new System.Drawing.Point(302, 213);
            this.txt_ListShowBookName.Name = "txt_ListShowBookName";
            this.txt_ListShowBookName.Size = new System.Drawing.Size(250, 26);
            this.txt_ListShowBookName.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(227, 216);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(67, 20);
            this.label25.TabIndex = 3;
            this.label25.Text = "ชื่อหนังสือ";
            // 
            // txt_ListShowBookID
            // 
            this.txt_ListShowBookID.Enabled = false;
            this.txt_ListShowBookID.Location = new System.Drawing.Point(103, 213);
            this.txt_ListShowBookID.Name = "txt_ListShowBookID";
            this.txt_ListShowBookID.Size = new System.Drawing.Size(111, 26);
            this.txt_ListShowBookID.TabIndex = 2;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(23, 216);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(74, 20);
            this.label24.TabIndex = 1;
            this.label24.Text = "รหัสหนังสือ";
            // 
            // ListView
            // 
            this.ListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListView.Location = new System.Drawing.Point(27, 35);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(660, 162);
            this.ListView.TabIndex = 0;
            this.ListView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListView_CellClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.bt_Cancel);
            this.groupBox6.Controls.Add(this.bt_success);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.txt_Refund);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txt_Receive);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Controls.Add(this.label19);
            this.groupBox6.Controls.Add(this.txt_Charge);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.txt_TotalBook);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox6.Location = new System.Drawing.Point(739, 468);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(270, 254);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "สรุปรายการเช่ายืม";
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Image = global::ProjectSA.Properties.Resources.cancel;
            this.bt_Cancel.Location = new System.Drawing.Point(136, 190);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(113, 47);
            this.bt_Cancel.TabIndex = 13;
            this.bt_Cancel.Text = "ยกเลิก";
            this.bt_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_success
            // 
            this.bt_success.Image = global::ProjectSA.Properties.Resources.Sales_success;
            this.bt_success.Location = new System.Drawing.Point(17, 190);
            this.bt_success.Name = "bt_success";
            this.bt_success.Size = new System.Drawing.Size(113, 47);
            this.bt_success.TabIndex = 12;
            this.bt_success.Text = "เสร็จสิ้น";
            this.bt_success.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_success.UseVisualStyleBackColor = true;
            this.bt_success.Click += new System.EventHandler(this.bt_success_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(213, 152);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 20);
            this.label22.TabIndex = 11;
            this.label22.Text = "บาท";
            // 
            // txt_Refund
            // 
            this.txt_Refund.Enabled = false;
            this.txt_Refund.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_Refund.Location = new System.Drawing.Point(107, 145);
            this.txt_Refund.MaxLength = 4;
            this.txt_Refund.Name = "txt_Refund";
            this.txt_Refund.Size = new System.Drawing.Size(100, 31);
            this.txt_Refund.TabIndex = 10;
            this.txt_Refund.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 152);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(58, 20);
            this.label23.TabIndex = 9;
            this.label23.Text = "ทอนเงิน";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(213, 113);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 20);
            this.label21.TabIndex = 8;
            this.label21.Text = "บาท";
            // 
            // txt_Receive
            // 
            this.txt_Receive.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_Receive.Location = new System.Drawing.Point(107, 106);
            this.txt_Receive.MaxLength = 4;
            this.txt_Receive.Name = "txt_Receive";
            this.txt_Receive.Size = new System.Drawing.Size(100, 31);
            this.txt_Receive.TabIndex = 7;
            this.txt_Receive.Text = "0";
            this.txt_Receive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Receive.TextChanged += new System.EventHandler(this.txt_Receive_TextChanged);
            this.txt_Receive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Receive_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 113);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 20);
            this.label20.TabIndex = 6;
            this.label20.Text = "รับเงิน";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(213, 74);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "บาท";
            // 
            // txt_Charge
            // 
            this.txt_Charge.Enabled = false;
            this.txt_Charge.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_Charge.Location = new System.Drawing.Point(107, 67);
            this.txt_Charge.MaxLength = 4;
            this.txt_Charge.Name = "txt_Charge";
            this.txt_Charge.Size = new System.Drawing.Size(100, 31);
            this.txt_Charge.TabIndex = 4;
            this.txt_Charge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 20);
            this.label18.TabIndex = 3;
            this.label18.Text = "ค่าบริการ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(213, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(33, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "เล่ม";
            // 
            // txt_TotalBook
            // 
            this.txt_TotalBook.Enabled = false;
            this.txt_TotalBook.Location = new System.Drawing.Point(143, 32);
            this.txt_TotalBook.MaxLength = 2;
            this.txt_TotalBook.Name = "txt_TotalBook";
            this.txt_TotalBook.Size = new System.Drawing.Size(64, 26);
            this.txt_TotalBook.TabIndex = 1;
            this.txt_TotalBook.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "จำนวนหนังสือที่ยืม";
            // 
            // Tool1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 734);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tool1";
            this.Text = "บริการเช่ายืมหนังสือ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Tool1_FormClosing);
            this.Load += new System.EventHandler(this.Tool1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SearchMemberID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_ServiceSearchMember;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ShowMemberType;
        private System.Windows.Forms.TextBox txt_ShowMemberName;
        private System.Windows.Forms.TextBox txt_ShowMemberID;
        private System.Windows.Forms.TextBox txt_ShowMemberBooks2;
        private System.Windows.Forms.TextBox txt_ShowMemberBooks1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_ServiceSearchBooks;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_SearchBookID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbl_BookStatus;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_ShowBookName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_ShowBookID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_RentDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView ListView;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button bt_ServiceAddList;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_TotalBook;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_Charge;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_Receive;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button bt_DeleteList;
        private System.Windows.Forms.TextBox txt_ListShowBookName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txt_ListShowBookID;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.Button bt_success;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_Refund;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cb_SearchMemberName;
        private System.Windows.Forms.ComboBox cb_SearchBookName;
        private System.Windows.Forms.DateTimePicker date_Today;
    }
}
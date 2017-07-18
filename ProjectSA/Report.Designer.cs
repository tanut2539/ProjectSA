namespace ProjectSA
{
    partial class Report
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Selected = new System.Windows.Forms.Button();
            this.date_Select = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_SelectMonth = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataListAll = new System.Windows.Forms.DataGridView();
            this.bt_print = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TotalIncome = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_cancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_Select2 = new System.Windows.Forms.ComboBox();
            this.bt_Month = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListAll)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Selected);
            this.groupBox1.Controls.Add(this.date_Select);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cb_Select);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(824, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เลือกรายงานแสดงผลแบบรายวัน";
            // 
            // bt_Selected
            // 
            this.bt_Selected.Image = global::ProjectSA.Properties.Resources.Search_memberTool;
            this.bt_Selected.Location = new System.Drawing.Point(700, 27);
            this.bt_Selected.Name = "bt_Selected";
            this.bt_Selected.Size = new System.Drawing.Size(109, 40);
            this.bt_Selected.TabIndex = 4;
            this.bt_Selected.Text = "แสดงผล";
            this.bt_Selected.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Selected.UseVisualStyleBackColor = true;
            this.bt_Selected.Click += new System.EventHandler(this.bt_Selected_Click);
            // 
            // date_Select
            // 
            this.date_Select.Location = new System.Drawing.Point(484, 32);
            this.date_Select.Name = "date_Select";
            this.date_Select.Size = new System.Drawing.Size(197, 26);
            this.date_Select.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(381, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "เลือกวันที่";
            // 
            // cb_Select
            // 
            this.cb_Select.FormattingEnabled = true;
            this.cb_Select.Items.AddRange(new object[] {
            "รายงานยอดขาย",
            "รายงานยอดขายหนังสือนิยมสูงสุด",
            "รายงานหนังสือที่ยังไม่ส่งคืน"});
            this.cb_Select.Location = new System.Drawing.Point(175, 32);
            this.cb_Select.Name = "cb_Select";
            this.cb_Select.Size = new System.Drawing.Size(197, 28);
            this.cb_Select.TabIndex = 1;
            this.cb_Select.Text = "- เลือกประเภทรายงาน -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "เลือกประเภทรายงาน";
            // 
            // cb_SelectMonth
            // 
            this.cb_SelectMonth.FormattingEnabled = true;
            this.cb_SelectMonth.Items.AddRange(new object[] {
            "มกราคม",
            "กุมภาพันธ์",
            "มีนาคม",
            "เมษายน",
            "พฤษภาคม",
            "มิถุนายน",
            "กรกฎาคม",
            "สิงหาคม",
            "กันยายน",
            "ตุลาคม",
            "พฤศจิกายน",
            "ธันวาคม"});
            this.cb_SelectMonth.Location = new System.Drawing.Point(484, 32);
            this.cb_SelectMonth.Name = "cb_SelectMonth";
            this.cb_SelectMonth.Size = new System.Drawing.Size(197, 28);
            this.cb_SelectMonth.TabIndex = 6;
            this.cb_SelectMonth.Text = "- กรุณาเลือกเดือน -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(381, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "ประจำเดือน";
            // 
            // dataListAll
            // 
            this.dataListAll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataListAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataListAll.Location = new System.Drawing.Point(12, 214);
            this.dataListAll.Name = "dataListAll";
            this.dataListAll.Size = new System.Drawing.Size(824, 316);
            this.dataListAll.TabIndex = 1;
            // 
            // bt_print
            // 
            this.bt_print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bt_print.Image = global::ProjectSA.Properties.Resources.PrintReport;
            this.bt_print.Location = new System.Drawing.Point(535, 545);
            this.bt_print.Name = "bt_print";
            this.bt_print.Size = new System.Drawing.Size(138, 45);
            this.bt_print.TabIndex = 2;
            this.bt_print.Text = "พิมพ์รายงาน";
            this.bt_print.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_print.UseVisualStyleBackColor = true;
            this.bt_print.Click += new System.EventHandler(this.bt_print_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(25, 563);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "รายได้สุทธิ";
            // 
            // txt_TotalIncome
            // 
            this.txt_TotalIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txt_TotalIncome.Location = new System.Drawing.Point(128, 560);
            this.txt_TotalIncome.Name = "txt_TotalIncome";
            this.txt_TotalIncome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_TotalIncome.Size = new System.Drawing.Size(125, 29);
            this.txt_TotalIncome.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(272, 563);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "บาท";
            // 
            // bt_cancel
            // 
            this.bt_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.bt_cancel.Image = global::ProjectSA.Properties.Resources.cancel;
            this.bt_cancel.Location = new System.Drawing.Point(698, 545);
            this.bt_cancel.Name = "bt_cancel";
            this.bt_cancel.Size = new System.Drawing.Size(138, 45);
            this.bt_cancel.TabIndex = 6;
            this.bt_cancel.Text = "ยกเลิก";
            this.bt_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_cancel.UseVisualStyleBackColor = true;
            this.bt_cancel.Click += new System.EventHandler(this.bt_cancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_Select2);
            this.groupBox2.Controls.Add(this.bt_Month);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cb_SelectMonth);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(824, 79);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เลือกรายงานแสดงผลแบบประจำเดือน";
            // 
            // cb_Select2
            // 
            this.cb_Select2.FormattingEnabled = true;
            this.cb_Select2.Items.AddRange(new object[] {
            "รายงานยอดขาย",
            "รายงานยอดขายหนังสือนิยมสูงสุด",
            "รายงานหนังสือที่ยังไม่ส่งคืน"});
            this.cb_Select2.Location = new System.Drawing.Point(175, 32);
            this.cb_Select2.Name = "cb_Select2";
            this.cb_Select2.Size = new System.Drawing.Size(197, 28);
            this.cb_Select2.TabIndex = 6;
            this.cb_Select2.Text = "- เลือกประเภทรายงาน -";
            // 
            // bt_Month
            // 
            this.bt_Month.Image = global::ProjectSA.Properties.Resources.Search_memberTool;
            this.bt_Month.Location = new System.Drawing.Point(700, 25);
            this.bt_Month.Name = "bt_Month";
            this.bt_Month.Size = new System.Drawing.Size(109, 40);
            this.bt_Month.TabIndex = 5;
            this.bt_Month.Text = "แสดงผล";
            this.bt_Month.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Month.UseVisualStyleBackColor = true;
            this.bt_Month.Click += new System.EventHandler(this.bt_Month_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "เลือกประเภทรายงาน";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 608);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_cancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_TotalIncome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_print);
            this.Controls.Add(this.dataListAll);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายงานแสดงผล";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListAll)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker date_Select;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_Select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataListAll;
        private System.Windows.Forms.Button bt_print;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TotalIncome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_Selected;
        private System.Windows.Forms.Button bt_cancel;
        private System.Windows.Forms.ComboBox cb_SelectMonth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_Month;
        private System.Windows.Forms.ComboBox cb_Select2;
        private System.Windows.Forms.Label label6;
    }
}
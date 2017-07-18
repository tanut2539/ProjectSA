namespace ProjectSA
{
    partial class Service
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Service));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Tool1 = new System.Windows.Forms.ToolStripButton();
            this.Tool2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tool1,
            this.Tool2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(124, 730);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Tool1
            // 
            this.Tool1.Image = global::ProjectSA.Properties.Resources.Rented;
            this.Tool1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tool1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool1.Name = "Tool1";
            this.Tool1.Size = new System.Drawing.Size(121, 36);
            this.Tool1.Text = "บริการเช่าหนังสือ";
            this.Tool1.Click += new System.EventHandler(this.Tool1_Click);
            // 
            // Tool2
            // 
            this.Tool2.Image = global::ProjectSA.Properties.Resources.Return_book;
            this.Tool2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Tool2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool2.Name = "Tool2";
            this.Tool2.Size = new System.Drawing.Size(121, 36);
            this.Tool2.Text = "คืนหนังสือ";
            this.Tool2.Click += new System.EventHandler(this.Tool2_Click);
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Tool1;
        private System.Windows.Forms.ToolStripButton Tool2;
    }
}
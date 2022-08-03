
namespace QLTV_N2
{
    partial class T_Baocao
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
            this.txtsachquahan = new System.Windows.Forms.TextBox();
            this.txtslsachcon = new System.Windows.Forms.TextBox();
            this.txtslsachmuon = new System.Windows.Forms.TextBox();
            this.txtslsach = new System.Windows.Forms.TextBox();
            this.txtsldausach = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtslsvqh = new System.Windows.Forms.TextBox();
            this.txtslsvms = new System.Windows.Forms.TextBox();
            this.txtslsv = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvsvqh = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btsvqh = new System.Windows.Forms.Button();
            this.btsachqh = new System.Windows.Forms.Button();
            this.btsvqht = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsvqh)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtsachquahan);
            this.groupBox1.Controls.Add(this.txtslsachcon);
            this.groupBox1.Controls.Add(this.txtslsachmuon);
            this.groupBox1.Controls.Add(this.txtslsach);
            this.groupBox1.Controls.Add(this.txtsldausach);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(36, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thống kê sách";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtsachquahan
            // 
            this.txtsachquahan.Enabled = false;
            this.txtsachquahan.Location = new System.Drawing.Point(653, 90);
            this.txtsachquahan.Name = "txtsachquahan";
            this.txtsachquahan.Size = new System.Drawing.Size(111, 22);
            this.txtsachquahan.TabIndex = 9;
            // 
            // txtslsachcon
            // 
            this.txtslsachcon.Enabled = false;
            this.txtslsachcon.Location = new System.Drawing.Point(653, 39);
            this.txtslsachcon.Name = "txtslsachcon";
            this.txtslsachcon.Size = new System.Drawing.Size(111, 22);
            this.txtslsachcon.TabIndex = 8;
            // 
            // txtslsachmuon
            // 
            this.txtslsachmuon.Enabled = false;
            this.txtslsachmuon.Location = new System.Drawing.Point(227, 136);
            this.txtslsachmuon.Name = "txtslsachmuon";
            this.txtslsachmuon.Size = new System.Drawing.Size(152, 22);
            this.txtslsachmuon.TabIndex = 7;
            // 
            // txtslsach
            // 
            this.txtslsach.Enabled = false;
            this.txtslsach.Location = new System.Drawing.Point(227, 90);
            this.txtslsach.Name = "txtslsach";
            this.txtslsach.Size = new System.Drawing.Size(152, 22);
            this.txtslsach.TabIndex = 6;
            // 
            // txtsldausach
            // 
            this.txtsldausach.Enabled = false;
            this.txtsldausach.Location = new System.Drawing.Point(227, 39);
            this.txtsldausach.Name = "txtsldausach";
            this.txtsldausach.Size = new System.Drawing.Size(152, 22);
            this.txtsldausach.TabIndex = 5;
            this.txtsldausach.TextChanged += new System.EventHandler(this.txtsldausach_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số sách quá hạn trả";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng sách còn lại trong thư viện";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng sách mượn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số lượng cuốn sách";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số lượng đầu sách";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtslsvqh);
            this.groupBox2.Controls.Add(this.txtslsvms);
            this.groupBox2.Controls.Add(this.txtslsv);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(36, 238);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 146);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thống kê sinh viên";
            // 
            // txtslsvqh
            // 
            this.txtslsvqh.Enabled = false;
            this.txtslsvqh.Location = new System.Drawing.Point(638, 39);
            this.txtslsvqh.Name = "txtslsvqh";
            this.txtslsvqh.Size = new System.Drawing.Size(141, 22);
            this.txtslsvqh.TabIndex = 5;
            // 
            // txtslsvms
            // 
            this.txtslsvms.Enabled = false;
            this.txtslsvms.Location = new System.Drawing.Point(285, 96);
            this.txtslsvms.Name = "txtslsvms";
            this.txtslsvms.Size = new System.Drawing.Size(135, 22);
            this.txtslsvms.TabIndex = 4;
            // 
            // txtslsv
            // 
            this.txtslsv.Enabled = false;
            this.txtslsv.Location = new System.Drawing.Point(285, 37);
            this.txtslsv.Name = "txtslsv";
            this.txtslsv.Size = new System.Drawing.Size(135, 22);
            this.txtslsv.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Số lượng sinh viên quá hạn";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Số lượng sinh viên đã mượn sách";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số lượng sinh viên đăng ký";
            // 
            // dgvsvqh
            // 
            this.dgvsvqh.AllowUserToAddRows = false;
            this.dgvsvqh.AllowUserToDeleteRows = false;
            this.dgvsvqh.AllowUserToResizeColumns = false;
            this.dgvsvqh.AllowUserToResizeRows = false;
            this.dgvsvqh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvsvqh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsvqh.Location = new System.Drawing.Point(6, 32);
            this.dgvsvqh.Name = "dgvsvqh";
            this.dgvsvqh.ReadOnly = true;
            this.dgvsvqh.RowHeadersVisible = false;
            this.dgvsvqh.RowHeadersWidth = 51;
            this.dgvsvqh.RowTemplate.Height = 24;
            this.dgvsvqh.Size = new System.Drawing.Size(784, 240);
            this.dgvsvqh.TabIndex = 2;
            this.dgvsvqh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvthongke_CellContentClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(263, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(293, 36);
            this.label9.TabIndex = 3;
            this.label9.Text = "Báo cáo - Thống kê";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvsvqh);
            this.groupBox3.Location = new System.Drawing.Point(36, 459);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(790, 278);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết";
            // 
            // btsvqh
            // 
            this.btsvqh.Location = new System.Drawing.Point(55, 401);
            this.btsvqh.Name = "btsvqh";
            this.btsvqh.Size = new System.Drawing.Size(149, 52);
            this.btsvqh.TabIndex = 5;
            this.btsvqh.Text = "Số lượng SV quá hạn";
            this.btsvqh.UseVisualStyleBackColor = true;
            this.btsvqh.Click += new System.EventHandler(this.btsvqh_Click);
            // 
            // btsachqh
            // 
            this.btsachqh.Location = new System.Drawing.Point(433, 401);
            this.btsachqh.Name = "btsachqh";
            this.btsachqh.Size = new System.Drawing.Size(163, 52);
            this.btsachqh.TabIndex = 6;
            this.btsachqh.Text = "Danh sách sách quá hạn";
            this.btsachqh.UseVisualStyleBackColor = true;
            this.btsachqh.Click += new System.EventHandler(this.btsachqh_Click);
            // 
            // btsvqht
            // 
            this.btsvqht.Location = new System.Drawing.Point(225, 401);
            this.btsvqht.Name = "btsvqht";
            this.btsvqht.Size = new System.Drawing.Size(177, 52);
            this.btsvqht.TabIndex = 7;
            this.btsvqht.Text = "Chi tiết SV quá hạn trả";
            this.btsvqht.UseVisualStyleBackColor = true;
            this.btsvqht.Click += new System.EventHandler(this.btsvqht_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(621, 401);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 52);
            this.button1.TabIndex = 8;
            this.button1.Text = "In phiếu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // T_Baocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 749);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btsvqht);
            this.Controls.Add(this.btsachqh);
            this.Controls.Add(this.btsvqh);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "T_Baocao";
            this.Text = "Báo cáo - Thống kê";
            this.Load += new System.EventHandler(this.T_Baocao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsvqh)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtsachquahan;
        private System.Windows.Forms.TextBox txtslsachcon;
        private System.Windows.Forms.TextBox txtslsachmuon;
        private System.Windows.Forms.TextBox txtslsach;
        private System.Windows.Forms.TextBox txtsldausach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtslsvqh;
        private System.Windows.Forms.TextBox txtslsvms;
        private System.Windows.Forms.TextBox txtslsv;
        private System.Windows.Forms.DataGridView dgvsvqh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btsvqh;
        private System.Windows.Forms.Button btsachqh;
        private System.Windows.Forms.Button btsvqht;
        private System.Windows.Forms.Button button1;
    }
}
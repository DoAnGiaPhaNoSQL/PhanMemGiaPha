
namespace Nhom12_NoSQL
{
    partial class ThongTinDongHoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDongHo = new System.Windows.Forms.Label();
            this.lbNgayGio = new System.Windows.Forms.Label();
            this.lbNguyenQuan = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtGridViewDSTH = new System.Windows.Forms.DataGridView();
            this.DoiThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewDSTH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbNguyenQuan);
            this.groupBox1.Controls.Add(this.lbNgayGio);
            this.groupBox1.Controls.Add(this.lbDongHo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 131);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên dòng họ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày giỗ tổ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nguyên quán :";
            // 
            // lbDongHo
            // 
            this.lbDongHo.AutoSize = true;
            this.lbDongHo.Location = new System.Drawing.Point(101, 30);
            this.lbDongHo.Name = "lbDongHo";
            this.lbDongHo.Size = new System.Drawing.Size(68, 13);
            this.lbDongHo.TabIndex = 3;
            this.lbDongHo.Text = "Tên dòng họ";
            // 
            // lbNgayGio
            // 
            this.lbNgayGio.AutoSize = true;
            this.lbNgayGio.Location = new System.Drawing.Point(98, 68);
            this.lbNgayGio.Name = "lbNgayGio";
            this.lbNgayGio.Size = new System.Drawing.Size(61, 13);
            this.lbNgayGio.TabIndex = 4;
            this.lbNgayGio.Text = "Ngày giỗ tổ";
            // 
            // lbNguyenQuan
            // 
            this.lbNguyenQuan.AutoSize = true;
            this.lbNguyenQuan.Location = new System.Drawing.Point(98, 105);
            this.lbNguyenQuan.Name = "lbNguyenQuan";
            this.lbNguyenQuan.Size = new System.Drawing.Size(71, 13);
            this.lbNguyenQuan.TabIndex = 5;
            this.lbNguyenQuan.Text = "Nguyên quán";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Danh sách các trưởng họ";
            // 
            // dtGridViewDSTH
            // 
            this.dtGridViewDSTH.AllowUserToAddRows = false;
            this.dtGridViewDSTH.AllowUserToDeleteRows = false;
            this.dtGridViewDSTH.AllowUserToResizeColumns = false;
            this.dtGridViewDSTH.AllowUserToResizeRows = false;
            this.dtGridViewDSTH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGridViewDSTH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridViewDSTH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DoiThu,
            this.HoTen,
            this.NgaySinh});
            this.dtGridViewDSTH.Location = new System.Drawing.Point(12, 175);
            this.dtGridViewDSTH.Name = "dtGridViewDSTH";
            this.dtGridViewDSTH.ReadOnly = true;
            this.dtGridViewDSTH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridViewDSTH.Size = new System.Drawing.Size(574, 150);
            this.dtGridViewDSTH.TabIndex = 7;
            // 
            // DoiThu
            // 
            this.DoiThu.HeaderText = "Đời thứ";
            this.DoiThu.Name = "DoiThu";
            this.DoiThu.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // ThongTinDongHoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 337);
            this.Controls.Add(this.dtGridViewDSTH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Name = "ThongTinDongHoForm";
            this.Text = "Thông tin dòng họ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridViewDSTH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNguyenQuan;
        private System.Windows.Forms.Label lbNgayGio;
        private System.Windows.Forms.Label lbDongHo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtGridViewDSTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoiThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
    }
}

namespace Nhom12_NoSQL
{
    partial class EducationForm
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnGhi = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.GiaoDucGridView = new System.Windows.Forms.DataGridView();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTruong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtThoiGianKT = new System.Windows.Forms.DateTimePicker();
            this.label29 = new System.Windows.Forms.Label();
            this.dtThoiGianBD = new System.Windows.Forms.DateTimePicker();
            this.label28 = new System.Windows.Forms.Label();
            this.BoxMoTa = new System.Windows.Forms.TextBox();
            this.BoxTenTruong = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lbEducationHeader = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.ckNgayBatDau = new System.Windows.Forms.CheckBox();
            this.ckNgayKetThuc = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GiaoDucGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(875, 212);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(61, 47);
            this.btnXoa.TabIndex = 38;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Location = new System.Drawing.Point(790, 212);
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(61, 47);
            this.btnGhi.TabIndex = 37;
            this.btnGhi.Text = "Ghi";
            this.btnGhi.UseVisualStyleBackColor = true;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(707, 212);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(61, 47);
            this.btnNew.TabIndex = 36;
            this.btnNew.Text = "Tạo mới";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.GiaoDucGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(935, 266);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách thông tin giáo dục";
            // 
            // GiaoDucGridView
            // 
            this.GiaoDucGridView.AllowUserToAddRows = false;
            this.GiaoDucGridView.AllowUserToDeleteRows = false;
            this.GiaoDucGridView.AllowUserToOrderColumns = true;
            this.GiaoDucGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GiaoDucGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GiaoDucGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Identity,
            this.TenTruong,
            this.ThoiGian,
            this.MoTa});
            this.GiaoDucGridView.Location = new System.Drawing.Point(6, 19);
            this.GiaoDucGridView.Name = "GiaoDucGridView";
            this.GiaoDucGridView.ReadOnly = true;
            this.GiaoDucGridView.RowHeadersVisible = false;
            this.GiaoDucGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GiaoDucGridView.Size = new System.Drawing.Size(922, 241);
            this.GiaoDucGridView.TabIndex = 0;
            this.GiaoDucGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GiaoDucGridView_CellClick);
            // 
            // Identity
            // 
            this.Identity.HeaderText = "ID";
            this.Identity.Name = "Identity";
            this.Identity.ReadOnly = true;
            this.Identity.Visible = false;
            // 
            // TenTruong
            // 
            this.TenTruong.HeaderText = "Tên trường";
            this.TenTruong.Name = "TenTruong";
            this.TenTruong.ReadOnly = true;
            // 
            // ThoiGian
            // 
            this.ThoiGian.HeaderText = "Thời gian";
            this.ThoiGian.Name = "ThoiGian";
            this.ThoiGian.ReadOnly = true;
            // 
            // MoTa
            // 
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            // 
            // dtThoiGianKT
            // 
            this.dtThoiGianKT.CustomFormat = "dd-MM-yyyy";
            this.dtThoiGianKT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtThoiGianKT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtThoiGianKT.Location = new System.Drawing.Point(292, 122);
            this.dtThoiGianKT.Name = "dtThoiGianKT";
            this.dtThoiGianKT.Size = new System.Drawing.Size(98, 24);
            this.dtThoiGianKT.TabIndex = 34;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(225, 124);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(40, 18);
            this.label29.TabIndex = 33;
            this.label29.Text = "đến :";
            // 
            // dtThoiGianBD
            // 
            this.dtThoiGianBD.CustomFormat = "dd-MM-yyyy";
            this.dtThoiGianBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtThoiGianBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtThoiGianBD.Location = new System.Drawing.Point(123, 122);
            this.dtThoiGianBD.Name = "dtThoiGianBD";
            this.dtThoiGianBD.Size = new System.Drawing.Size(96, 24);
            this.dtThoiGianBD.TabIndex = 32;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(20, 122);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(76, 18);
            this.label28.TabIndex = 31;
            this.label28.Text = "Thời gian :";
            // 
            // BoxMoTa
            // 
            this.BoxMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxMoTa.Location = new System.Drawing.Point(102, 178);
            this.BoxMoTa.Multiline = true;
            this.BoxMoTa.Name = "BoxMoTa";
            this.BoxMoTa.Size = new System.Drawing.Size(583, 70);
            this.BoxMoTa.TabIndex = 30;
            // 
            // BoxTenTruong
            // 
            this.BoxTenTruong.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxTenTruong.Location = new System.Drawing.Point(102, 73);
            this.BoxTenTruong.Name = "BoxTenTruong";
            this.BoxTenTruong.Size = new System.Drawing.Size(583, 24);
            this.BoxTenTruong.TabIndex = 29;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(42, 178);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 18);
            this.label27.TabIndex = 28;
            this.label27.Text = "Mô tả :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(9, 76);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(87, 18);
            this.label26.TabIndex = 27;
            this.label26.Text = "Tên trường :";
            // 
            // lbEducationHeader
            // 
            this.lbEducationHeader.AutoSize = true;
            this.lbEducationHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEducationHeader.Location = new System.Drawing.Point(96, 18);
            this.lbEducationHeader.Name = "lbEducationHeader";
            this.lbEducationHeader.Size = new System.Drawing.Size(326, 31);
            this.lbEducationHeader.TabIndex = 39;
            this.lbEducationHeader.Text = "Thông tin giáo dục của :";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(428, 18);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(55, 31);
            this.lbTen.TabIndex = 40;
            this.lbTen.Text = "tên";
            // 
            // ckNgayBatDau
            // 
            this.ckNgayBatDau.AutoSize = true;
            this.ckNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNgayBatDau.Location = new System.Drawing.Point(102, 127);
            this.ckNgayBatDau.Name = "ckNgayBatDau";
            this.ckNgayBatDau.Size = new System.Drawing.Size(15, 14);
            this.ckNgayBatDau.TabIndex = 41;
            this.ckNgayBatDau.UseVisualStyleBackColor = true;
            // 
            // ckNgayKetThuc
            // 
            this.ckNgayKetThuc.AutoSize = true;
            this.ckNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNgayKetThuc.Location = new System.Drawing.Point(271, 126);
            this.ckNgayKetThuc.Name = "ckNgayKetThuc";
            this.ckNgayKetThuc.Size = new System.Drawing.Size(15, 14);
            this.ckNgayKetThuc.TabIndex = 42;
            this.ckNgayKetThuc.UseVisualStyleBackColor = true;
            // 
            // EducationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 543);
            this.Controls.Add(this.ckNgayKetThuc);
            this.Controls.Add(this.ckNgayBatDau);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.lbEducationHeader);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnGhi);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtThoiGianKT);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.dtThoiGianBD);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.BoxMoTa);
            this.Controls.Add(this.BoxTenTruong);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Name = "EducationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin giáo dục";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GiaoDucGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView GiaoDucGridView;
        private System.Windows.Forms.DateTimePicker dtThoiGianKT;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.DateTimePicker dtThoiGianBD;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox BoxMoTa;
        private System.Windows.Forms.TextBox BoxTenTruong;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lbEducationHeader;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.CheckBox ckNgayBatDau;
        private System.Windows.Forms.CheckBox ckNgayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTruong;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
    }
}
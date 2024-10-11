
namespace Nhom12_NoSQL
{
    partial class JobInfoForm
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCleanTextBox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableJobs = new System.Windows.Forms.DataGridView();
            this.dtNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.dtNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.boxNgheNghiep = new System.Windows.Forms.TextBox();
            this.boxDiaChi = new System.Windows.Forms.TextBox();
            this.boxViTriCongTac = new System.Windows.Forms.TextBox();
            this.boxTenCoQuan = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lbJobHeader = new System.Windows.Forms.Label();
            this.lbTen = new System.Windows.Forms.Label();
            this.ckNgayBatDau = new System.Windows.Forms.CheckBox();
            this.ckNgayKetThuc = new System.Windows.Forms.CheckBox();
            this.Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenCoQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgheNghiep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableJobs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(769, 207);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 47);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(677, 207);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 47);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "Ghi";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCleanTextBox
            // 
            this.btnCleanTextBox.Location = new System.Drawing.Point(584, 207);
            this.btnCleanTextBox.Name = "btnCleanTextBox";
            this.btnCleanTextBox.Size = new System.Drawing.Size(61, 47);
            this.btnCleanTextBox.TabIndex = 38;
            this.btnCleanTextBox.Text = "Tạo mới";
            this.btnCleanTextBox.UseVisualStyleBackColor = true;
            this.btnCleanTextBox.Click += new System.EventHandler(this.btnCleanTextBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableJobs);
            this.groupBox1.Location = new System.Drawing.Point(9, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(821, 250);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách các công việc";
            // 
            // tableJobs
            // 
            this.tableJobs.AllowUserToAddRows = false;
            this.tableJobs.AllowUserToDeleteRows = false;
            this.tableJobs.AllowUserToOrderColumns = true;
            this.tableJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Identity,
            this.colTenCoQuan,
            this.colDiaChi,
            this.colViTri,
            this.colNgheNghiep,
            this.colThoiGian});
            this.tableJobs.Location = new System.Drawing.Point(6, 19);
            this.tableJobs.Name = "tableJobs";
            this.tableJobs.ReadOnly = true;
            this.tableJobs.RowHeadersVisible = false;
            this.tableJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableJobs.Size = new System.Drawing.Size(804, 225);
            this.tableJobs.TabIndex = 0;
            this.tableJobs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableJobs_CellClick);
            // 
            // dtNgayKetThuc
            // 
            this.dtNgayKetThuc.CustomFormat = "dd-MM-yyyy";
            this.dtNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayKetThuc.Location = new System.Drawing.Point(141, 202);
            this.dtNgayKetThuc.Name = "dtNgayKetThuc";
            this.dtNgayKetThuc.Size = new System.Drawing.Size(101, 24);
            this.dtNgayKetThuc.TabIndex = 36;
            // 
            // dtNgayBatDau
            // 
            this.dtNgayBatDau.CustomFormat = "dd-MM-yyyy";
            this.dtNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgayBatDau.Location = new System.Drawing.Point(141, 168);
            this.dtNgayBatDau.Name = "dtNgayBatDau";
            this.dtNgayBatDau.Size = new System.Drawing.Size(101, 24);
            this.dtNgayBatDau.TabIndex = 35;
            // 
            // boxNgheNghiep
            // 
            this.boxNgheNghiep.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxNgheNghiep.Location = new System.Drawing.Point(461, 130);
            this.boxNgheNghiep.Name = "boxNgheNghiep";
            this.boxNgheNghiep.Size = new System.Drawing.Size(321, 24);
            this.boxNgheNghiep.TabIndex = 34;
            // 
            // boxDiaChi
            // 
            this.boxDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxDiaChi.Location = new System.Drawing.Point(461, 86);
            this.boxDiaChi.Name = "boxDiaChi";
            this.boxDiaChi.Size = new System.Drawing.Size(321, 24);
            this.boxDiaChi.TabIndex = 33;
            // 
            // boxViTriCongTac
            // 
            this.boxViTriCongTac.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxViTriCongTac.Location = new System.Drawing.Point(120, 127);
            this.boxViTriCongTac.Name = "boxViTriCongTac";
            this.boxViTriCongTac.Size = new System.Drawing.Size(218, 24);
            this.boxViTriCongTac.TabIndex = 32;
            // 
            // boxTenCoQuan
            // 
            this.boxTenCoQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxTenCoQuan.Location = new System.Drawing.Point(120, 86);
            this.boxTenCoQuan.Name = "boxTenCoQuan";
            this.boxTenCoQuan.Size = new System.Drawing.Size(218, 24);
            this.boxTenCoQuan.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(74, 207);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(40, 18);
            this.label24.TabIndex = 30;
            this.label24.Text = "đến :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(22, 168);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 18);
            this.label23.TabIndex = 29;
            this.label23.Text = "Thời gian từ :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(357, 130);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(98, 18);
            this.label22.TabIndex = 28;
            this.label22.Text = "Nghề nghiệp :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(394, 86);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 18);
            this.label21.TabIndex = 27;
            this.label21.Text = "Địa chỉ :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 130);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(105, 18);
            this.label20.TabIndex = 26;
            this.label20.Text = "Vị trí công tác :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(19, 86);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 18);
            this.label19.TabIndex = 25;
            this.label19.Text = "Tên cơ quan :";
            // 
            // lbJobHeader
            // 
            this.lbJobHeader.AutoSize = true;
            this.lbJobHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJobHeader.Location = new System.Drawing.Point(114, 23);
            this.lbJobHeader.Name = "lbJobHeader";
            this.lbJobHeader.Size = new System.Drawing.Size(375, 31);
            this.lbJobHeader.TabIndex = 41;
            this.lbJobHeader.Text = "Thông tin nghề nghiệp của :";
            // 
            // lbTen
            // 
            this.lbTen.AutoSize = true;
            this.lbTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTen.Location = new System.Drawing.Point(495, 23);
            this.lbTen.Name = "lbTen";
            this.lbTen.Size = new System.Drawing.Size(55, 31);
            this.lbTen.TabIndex = 42;
            this.lbTen.Text = "tên";
            // 
            // ckNgayBatDau
            // 
            this.ckNgayBatDau.AutoSize = true;
            this.ckNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNgayBatDau.Location = new System.Drawing.Point(120, 172);
            this.ckNgayBatDau.Name = "ckNgayBatDau";
            this.ckNgayBatDau.Size = new System.Drawing.Size(15, 14);
            this.ckNgayBatDau.TabIndex = 43;
            this.ckNgayBatDau.UseVisualStyleBackColor = true;
            // 
            // ckNgayKetThuc
            // 
            this.ckNgayKetThuc.AutoSize = true;
            this.ckNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckNgayKetThuc.Location = new System.Drawing.Point(120, 207);
            this.ckNgayKetThuc.Name = "ckNgayKetThuc";
            this.ckNgayKetThuc.Size = new System.Drawing.Size(15, 14);
            this.ckNgayKetThuc.TabIndex = 44;
            this.ckNgayKetThuc.UseVisualStyleBackColor = true;
            // 
            // Identity
            // 
            this.Identity.HeaderText = "ID";
            this.Identity.Name = "Identity";
            this.Identity.Visible = false;
            // 
            // colTenCoQuan
            // 
            this.colTenCoQuan.HeaderText = "Tên cơ quan";
            this.colTenCoQuan.Name = "colTenCoQuan";
            // 
            // colDiaChi
            // 
            this.colDiaChi.HeaderText = "Địa chỉ";
            this.colDiaChi.Name = "colDiaChi";
            // 
            // colViTri
            // 
            this.colViTri.HeaderText = "Vị trí";
            this.colViTri.Name = "colViTri";
            // 
            // colNgheNghiep
            // 
            this.colNgheNghiep.HeaderText = "Nghề nghiệp";
            this.colNgheNghiep.Name = "colNgheNghiep";
            // 
            // colThoiGian
            // 
            this.colThoiGian.HeaderText = "Thời gian";
            this.colThoiGian.Name = "colThoiGian";
            // 
            // JobInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 522);
            this.Controls.Add(this.ckNgayKetThuc);
            this.Controls.Add(this.ckNgayBatDau);
            this.Controls.Add(this.lbTen);
            this.Controls.Add(this.lbJobHeader);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCleanTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtNgayKetThuc);
            this.Controls.Add(this.dtNgayBatDau);
            this.Controls.Add(this.boxNgheNghiep);
            this.Controls.Add(this.boxDiaChi);
            this.Controls.Add(this.boxViTriCongTac);
            this.Controls.Add(this.boxTenCoQuan);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Name = "JobInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin nghề nghiệp";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableJobs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCleanTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tableJobs;
        private System.Windows.Forms.DateTimePicker dtNgayKetThuc;
        private System.Windows.Forms.DateTimePicker dtNgayBatDau;
        private System.Windows.Forms.TextBox boxNgheNghiep;
        private System.Windows.Forms.TextBox boxDiaChi;
        private System.Windows.Forms.TextBox boxViTriCongTac;
        private System.Windows.Forms.TextBox boxTenCoQuan;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbJobHeader;
        private System.Windows.Forms.Label lbTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgheNghiep;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThoiGian;
        private System.Windows.Forms.CheckBox ckNgayBatDau;
        private System.Windows.Forms.CheckBox ckNgayKetThuc;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Nhom12_NoSQL.Controller;
using Nhom12_NoSQL.Model;
namespace Nhom12_NoSQL
{
    public partial class JobInfoForm : Form
    {
        private NgheNghiepController ngheNghiepController;
        private string name;
        private int id;
        private int idNgheNghiep = -1;
        public JobInfoForm(string name,int id)
        {
            this.name = name;
            this.id = id;
            this.ngheNghiepController = new NgheNghiepController();
            InitializeComponent();
            lbTen.Text = name;
            dtNgayBatDau.Enabled = false;
            dtNgayKetThuc.Enabled = false;
            this.ckNgayBatDau.CheckedChanged += checkedEvent;
            this.ckNgayKetThuc.CheckedChanged += checkedEvent;
            LoadData();
        }

        private void checkedEvent(object sender, EventArgs e)
        {
            if (sender==ckNgayBatDau)
            {
                dtNgayBatDau.Enabled = (ckNgayBatDau.Checked) ? true : false;
            }
            if (sender==ckNgayKetThuc)
            {
                dtNgayKetThuc.Enabled = (ckNgayKetThuc.Checked) ? true : false;
            }
        }
        private void LoadData()
        {
            tableJobs.Rows.Clear();
            List<NgheNghiep> danhSach = new List<NgheNghiep>();
            danhSach = ngheNghiepController.LayDanhSachThongTinNgheNghiep(id);
            foreach (NgheNghiep gd in danhSach)
            {
                string tgbd = (gd.ThoiGianBatDau == null) ? "" : gd.ThoiGianBatDau.Value.ToString("dd-MM-yyyy");
                string tgkt = (gd.ThoiGianKetThuc == null) ? "" : gd.ThoiGianKetThuc.Value.ToString("dd-MM-yyyy");
                string dauPhanCach = (tgkt != "") ? " ~ " : "";
                tableJobs.Rows.Add(gd.IdNgheNghiep, gd.TenCoQuan,gd.DiaChi,gd.ViTriCongTac,gd.Nghenghiep, tgbd + dauPhanCach + tgkt);
            }
        }
        private void clearTextBox()
        {
            boxNgheNghiep.Text = string.Empty;
            boxDiaChi.Text = string.Empty;
            boxTenCoQuan.Text= string.Empty;
            boxViTriCongTac.Text = string.Empty;
            ckNgayBatDau.Checked = false;
            ckNgayKetThuc.Checked = false;
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = DateTime.Now;
            idNgheNghiep = -1;
        }

        private void btnCleanTextBox_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (boxTenCoQuan.Text != "")
            {
                NgheNghiep ngheNghiep = new NgheNghiep();
                ngheNghiep.TenCoQuan = boxTenCoQuan.Text;
                if (ckNgayBatDau.Checked)
                {
                    ngheNghiep.ThoiGianBatDau = dtNgayBatDau.Value;
                }
                else
                {
                    ngheNghiep.ThoiGianBatDau = null;
                }
                if (ckNgayKetThuc.Checked)
                {
                    ngheNghiep.ThoiGianKetThuc = dtNgayKetThuc.Value;
                }
                else
                {
                    ngheNghiep.ThoiGianKetThuc = null;
                }
                ngheNghiep.DiaChi = boxDiaChi.Text;
                ngheNghiep.ViTriCongTac = boxViTriCongTac.Text;
                ngheNghiep.TenCoQuan = boxTenCoQuan.Text;
                ngheNghiep.Nghenghiep = boxNgheNghiep.Text;
                if (ngheNghiepController.ktrNgheNghiepCoTonTai(idNgheNghiep))
                {
                    ngheNghiep.IdNgheNghiep = idNgheNghiep;
                    if (ngheNghiepController.chinhSuaThongTinNgheNghiep(ngheNghiep, id))
                    {
                        MessageBox.Show(this, "Chỉnh sửa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Chỉnh sửa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (ngheNghiepController.taoNodeNgheNghiep(ngheNghiep, id))
                    {
                        MessageBox.Show(this, "Thêm thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                LoadData();
            }
            else
            {
                MessageBox.Show(this, "Ô tên cơ quan không được bỏ trống! Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (boxTenCoQuan.Text != "")
            {
                DialogResult result = MessageBox.Show(this, "Bạn có chắc muốn xóa thông tin nghề nghiệp này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    bool kq = ngheNghiepController.xoaThongTinNgheNghiep(idNgheNghiep, id);
                    if (kq)
                    {
                        MessageBox.Show(this, "Xóa thông tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Xóa thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Vui lòng chọn thông tin bạn muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tableJobs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idNgheNghiep = int.Parse(tableJobs.Rows[e.RowIndex].Cells["Identity"].Value.ToString());
                boxTenCoQuan.Text = tableJobs.Rows[e.RowIndex].Cells["colTenCoQuan"].Value.ToString();
                boxDiaChi.Text= (tableJobs.Rows[e.RowIndex].Cells["colDiaChi"].Value != null) ? tableJobs.Rows[e.RowIndex].Cells["colDiaChi"].Value.ToString() : "";
                boxNgheNghiep.Text = (tableJobs.Rows[e.RowIndex].Cells["colNgheNghiep"].Value != null) ? tableJobs.Rows[e.RowIndex].Cells["colNgheNghiep"].Value.ToString() : "";
                boxViTriCongTac.Text= (tableJobs.Rows[e.RowIndex].Cells["colViTri"].Value != null) ? tableJobs.Rows[e.RowIndex].Cells["colViTri"].Value.ToString() : "";
                string thoiGian = tableJobs.Rows[e.RowIndex].Cells["colThoiGian"].Value.ToString();
                if (thoiGian != "")
                {
                    if (thoiGian.Contains('~'))
                    {
                        string thoiGianBatDau = thoiGian.Split('~')[0].TrimEnd(' ');
                        if (thoiGianBatDau != "")
                        {
                            ckNgayBatDau.Checked = true;
                            dtNgayBatDau.Value = DateTime.ParseExact(thoiGianBatDau, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            ckNgayBatDau.Checked = false;
                            dtNgayBatDau.Value = DateTime.Now;
                        }
                        string thoiGianKetThuc = thoiGian.Split('~')[1].TrimStart(' ');
                        if (thoiGianKetThuc != "")
                        {
                            ckNgayKetThuc.Checked = true;
                            dtNgayKetThuc.Value = DateTime.ParseExact(thoiGianKetThuc, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    else
                    {
                        ckNgayBatDau.Checked = true;
                        dtNgayBatDau.Value = DateTime.ParseExact(thoiGian, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        ckNgayKetThuc.Checked = false;
                        dtNgayKetThuc.Value = DateTime.Now;
                    }
                }
                else
                {
                    ckNgayBatDau.Checked = false;
                    dtNgayBatDau.Value = DateTime.Now;
                    ckNgayKetThuc.Checked = false;
                    dtNgayKetThuc.Value = DateTime.Now;
                }
            }
        }
    }
}

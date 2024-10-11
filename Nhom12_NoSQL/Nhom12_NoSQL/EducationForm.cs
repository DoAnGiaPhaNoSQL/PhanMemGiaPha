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
    public partial class EducationForm : Form
    {
        private GiaoDucController giaoDucController;
        private string name;
        private int id;
        private int idGiaoDuc=-1;
        public EducationForm(string name,int id)
        {
            this.name = name;
            this.id = id;
            InitializeComponent();
            giaoDucController = new GiaoDucController();
            lbTen.Text = name;
            dtThoiGianBD.Enabled = false;
            dtThoiGianKT.Enabled = false;
            ckNgayBatDau.CheckedChanged += checkedEvent;
            ckNgayKetThuc.CheckedChanged += checkedEvent;
            LoadData();
        }
        private void checkedEvent(object sender, EventArgs e)
        {
            if (sender==ckNgayBatDau)
            {
                dtThoiGianBD.Enabled = (ckNgayBatDau.Checked) ? true : false;
                
            }
            if (sender==ckNgayKetThuc)
            {
                dtThoiGianKT.Enabled = (ckNgayKetThuc.Checked) ? true : false;
            }
        }
        private void LoadData()
        {
            GiaoDucGridView.Rows.Clear();
            List<GiaoDuc> danhSach = new List<GiaoDuc>();
            danhSach = giaoDucController.LayDanhSachThongTinGiaoDuc(id);
            foreach(GiaoDuc gd in danhSach)
            {
                string tgbd = (gd.ThoiGianBatDau == null) ? "" : gd.ThoiGianBatDau.Value.ToString("dd-MM-yyyy");
                string tgkt = (gd.ThoiGianKetThuc == null) ? "" : gd.ThoiGianKetThuc.Value.ToString("dd-MM-yyyy");
                string dauPhanCach = (tgkt != "") ? " ~ " : "";
                GiaoDucGridView.Rows.Add(gd.Id,gd.TenTruong, tgbd + dauPhanCach + tgkt, gd.MoTa);
            }
        }
        private void clearTextBox()
        {
            BoxTenTruong.Text = string.Empty;
            BoxMoTa.Text = string.Empty;
            ckNgayBatDau.Checked = false;
            ckNgayKetThuc.Checked = false;
            dtThoiGianBD.Value = DateTime.Now;
            dtThoiGianKT.Value = DateTime.Now;
            idGiaoDuc = -1;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }
        private void btnGhi_Click(object sender, EventArgs e)
        {
            if (BoxTenTruong.Text!="")
            {
                GiaoDuc giaoDuc = new GiaoDuc();
                giaoDuc.TenTruong = BoxTenTruong.Text;
                if (ckNgayBatDau.Checked)
                {
                    giaoDuc.ThoiGianBatDau = dtThoiGianBD.Value;
                }
                else
                {
                    giaoDuc.ThoiGianBatDau = null;
                }
                if (ckNgayKetThuc.Checked)
                {
                    giaoDuc.ThoiGianKetThuc = dtThoiGianKT.Value;
                }
                else
                {
                    giaoDuc.ThoiGianKetThuc = null;
                }
                giaoDuc.MoTa = BoxMoTa.Text;
                if (giaoDucController.ktrGiaoDucCoTonTai(idGiaoDuc))
                {
                    giaoDuc.Id = idGiaoDuc;
                    if(giaoDucController.chinhSuaThongTinGiaoDuc(giaoDuc, id))
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
                    if (giaoDucController.taoNodeGiaoDuc(giaoDuc, id))
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
                MessageBox.Show(this, "Ô tên trường không được bỏ trống! Thêm thông tin thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (BoxTenTruong.Text!="")
            {
                DialogResult result = MessageBox.Show(this, "Bạn có chắc muốn xóa thông tin giáo dục không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    bool kq = giaoDucController.xoaThongTinGiaoDuc(idGiaoDuc, id);
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
        private void GiaoDucGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                idGiaoDuc = int.Parse(GiaoDucGridView.Rows[e.RowIndex].Cells["identity"].Value.ToString());
                BoxTenTruong.Text = GiaoDucGridView.Rows[e.RowIndex].Cells["TenTruong"].Value.ToString();
                BoxMoTa.Text = (GiaoDucGridView.Rows[e.RowIndex].Cells["MoTa"].Value != null) ? GiaoDucGridView.Rows[e.RowIndex].Cells["MoTa"].Value.ToString() : "";
                string thoiGian = GiaoDucGridView.Rows[e.RowIndex].Cells["ThoiGian"].Value.ToString();
                if (thoiGian!="")
                {
                    if (thoiGian.Contains('~'))
                    {
                        string thoiGianBatDau = thoiGian.Split('~')[0].TrimEnd(' ');
                        if (thoiGianBatDau != "")
                        {
                            ckNgayBatDau.Checked = true;
                            dtThoiGianBD.Value = DateTime.ParseExact(thoiGianBatDau, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            ckNgayBatDau.Checked = false;
                            dtThoiGianBD.Value = DateTime.Now;
                        }
                        string thoiGianKetThuc = thoiGian.Split('~')[1].TrimStart(' ');
                        if (thoiGianKetThuc != "")
                        {
                            ckNgayKetThuc.Checked = true;
                            dtThoiGianKT.Value = DateTime.ParseExact(thoiGianKetThuc, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }
                    }
                    else
                    {
                        ckNgayBatDau.Checked = true;
                        dtThoiGianBD.Value = DateTime.ParseExact(thoiGian, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        ckNgayKetThuc.Checked = false;
                        dtThoiGianKT.Value = DateTime.Now;
                    }
                }
                else
                {
                    ckNgayBatDau.Checked = false;
                    dtThoiGianBD.Value = DateTime.Now;
                    ckNgayKetThuc.Checked = false;
                    dtThoiGianKT.Value = DateTime.Now;
                }
            }
        }
    }
}

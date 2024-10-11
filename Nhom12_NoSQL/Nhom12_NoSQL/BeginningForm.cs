using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nhom12_NoSQL.Controller;
using Nhom12_NoSQL.Model;
namespace Nhom12_NoSQL
{
    public partial class BeginningForm : Form
    {
        private ThanhVienController thanhVienController;
        private string name;
        public BeginningForm(string name)
        {
            this.name = name;
            this.thanhVienController = new ThanhVienController();
            InitializeComponent();
            this.rdNamThanhVien.Checked = true;
            this.dtNgayMatThanhVien.Visible = false;
        }
        private void chkDaMatThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaMatThanhVien.Checked)
            {
                dtNgayMatThanhVien.Visible = true;
            }
            else
            {
                dtNgayMatThanhVien.Visible = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThanhVien tv = new ThanhVien();
            if (BoxHoTenThanhVien.Text!="")
            {
                tv.HoTen = BoxHoTenThanhVien.Text;
                tv.NgaySinh = dtNgaySinhThanhVien.Value;
                tv.GioiTinh = "Nam";
                tv.ConThu = (int)nmConThuThanhVien.Value;
                tv.DoiThu = 1;
                tv.TenThuongGoi = BoxTenThuongGoiThanhVien.Text;
                tv.Cccd_cmnd = BoxCMNDThanhVien.Text;
                tv.NoiSinh = BoxNoiSinhThanhVien.Text;
                tv.QuocTich = cbQuocTichThanhVien.SelectedItem.ToString();
                tv.TonGiao = cbTonGiaoThanhVien.SelectedItem.ToString();
                if (chkDaMatThanhVien.Checked)
                {
                    tv.NgayMat = dtNgayMatThanhVien.Value;
                }
                if (thanhVienController.TaoThanhVienToPhu(tv))
                {
                    MessageBox.Show(this, "Thêm tổ phụ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MainForm main = new MainForm(name);
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(this, "Thêm tổ phụ thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Ô họ tên không được bỏ trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

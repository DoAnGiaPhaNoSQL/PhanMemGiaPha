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
namespace Nhom12_NoSQL
{
    public partial class SearchForm : Form
    {
        private ThanhVienController thanhVienController;
        public SearchForm()
        {
            InitializeComponent();
            thanhVienController = new ThanhVienController();
            cbGioiTinh.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckEnableDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEnableFromDate.Checked)
            {
                FromDate.Enabled = true;
            }
            else
            {
                FromDate.Enabled = false;
            }
        }

        private void ckEnableToDate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckEnableToDate.Checked)
            {
                ToDate.Enabled = true;
            }
            else
            {
                ToDate.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string gioiTinh = cbGioiTinh.SelectedItem.ToString();
            string ho = "";
            string ten = "";
            if (boxTuKhoa.Text!="")
            {
                ho = boxTuKhoa.Text.Substring(0, 1).ToUpper();
                ten = boxTuKhoa.Text.Substring(1);
            }
            string hoTen = ho + ten;
            DateTime? ngayBD;
            bool daMat = false;
            if (ckEnableFromDate.Checked)
            {
                ngayBD = FromDate.Value;
            }
            else
            {
                ngayBD = null;
            }
            DateTime? ngayKT;
            if (ckEnableToDate.Checked)
            {
                ngayKT = ToDate.Value;
            }
            else
            {
                ngayKT = null;
            }
            if (ckDaMat.Checked)
            {
                daMat = true;
            }
            else
            {
                daMat = false;
            }
            string query = "MATCH (tv:ThanhVien) ";
            string extra = "";
            if (gioiTinh != "Tất cả")
            {
                extra += "WHERE tv.GioiTinh='" + gioiTinh + "'";
            }
            if (hoTen != "")
            {
                if (extra!="")
                {
                    extra += "AND tv.HoTen CONTAINS '" + hoTen + "'";
                }
                else
                {
                    extra += "WHERE tv.HoTen CONTAINS '" + hoTen + "'";
                }
            }
            if (ngayBD != null)
            {
                if (extra != "")
                {
                    extra += "AND tv.NgaySinh >= date('" + ngayBD.Value.ToString("yyyy-MM-dd") + "')";
                }
                else
                {
                    extra += "WHERE tv.NgaySinh >= date('" + ngayBD.Value.ToString("yyyy-MM-dd") + "')";
                }
            }
            if (ngayKT!=null)
            {
                if (extra != "")
                {
                    extra += "AND tv.NgaySinh <= date('" + ngayKT.Value.ToString("yyyy-MM-dd") + "')";
                }
                else
                {
                    extra += "WHERE tv.NgaySinh <= date('" + ngayKT.Value.ToString("yyyy-MM-dd") + "')";
                }
            }
            if (daMat)
            {
                if (extra != "")
                {
                    extra += "AND tv.NgayMat IS NOT NULL";
                }
                else
                {
                    extra += "WHERE tv.NgayMat IS NOT NULL";
                }
            }
            query += extra + " RETURN tv ORDER BY tv.DoiThu ASC";
            var data = thanhVienController.selectThanhVien(query);
            tableResult.Rows.Clear();
            if (data != null)
            {
                foreach (var thanhVien in data)
                {
                    tableResult.Rows.Add(
                            thanhVien.HoTen,
                            thanhVien.GioiTinh,
                            string.Empty,
                            string.Empty,
                            thanhVien.NgaySinh.ToString("dd-MM-yyyy"),
                            thanhVien.NgayMat
                        );

                }
            }
        }

    }
}

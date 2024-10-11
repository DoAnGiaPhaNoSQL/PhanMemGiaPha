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
    public partial class ThongTinDongHoForm : Form
    {
        private ThanhVienController thanhVienController;
        public ThongTinDongHoForm()
        {
            this.thanhVienController = new ThanhVienController();
            InitializeComponent();
            this.Load += ThongTinDongHoForm_Load;
        }

        private void ThongTinDongHoForm_Load(object sender, EventArgs e)
        {
            var list = thanhVienController.danhSachTruongHo();
            foreach(var item in list)
            {
                dtGridViewDSTH.Rows.Add(item.Item3, item.Item1, item.Item2);
            }
            string query = "MATCH (t:ThanhVien) WHERE t.ToPhu IS NOT NULL RETURN t";
            ThanhVien toPhu = thanhVienController.TruyVan(query);
            lbDongHo.Text = toPhu.HoTen.Split(' ')[0];
            if (toPhu.NgayMat!=null)
            {
                lbNgayGio.Text = toPhu.NgayMat.Value.ToString("dd-MM-yyyy");
            }
            else
            {
                lbNgayGio.Text = "Không rõ";
            }
            if (toPhu.NoiSinh!="")
            {
                lbNguyenQuan.Text = toPhu.NoiSinh;
            }
            else
            {
                lbNguyenQuan.Text = "Không rõ";
            }
        }
    }
}

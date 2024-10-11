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
    public partial class RelationshipForm : Form
    {
        private ThanhVienController thanhVienController;
        private string query;
        public RelationshipForm(string name,string query)
        {
            InitializeComponent();
            thanhVienController = new ThanhVienController();
            this.txtName.Text = name;
            this.query = query;
            loadData();
        }
        private void loadData()
        {
            var data = thanhVienController.truyVanLayThuocTinh(query);
            if (data != null)
            {
                foreach (var thanhVien in data)
                {
                    tbQuanHe.Rows.Add(
                        thanhVien.GioiTinh,
                        thanhVien.HoTen,
                        thanhVien.NgaySinh.ToString("dd-MM-yyyy"),
                        thanhVien.QuanHe
                    );
                }
            }
        }

    }
}

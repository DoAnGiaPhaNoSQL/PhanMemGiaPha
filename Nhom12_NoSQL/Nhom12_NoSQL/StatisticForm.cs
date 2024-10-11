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
    public partial class StatisticForm : Form
    {
        private ThanhVienController thanhVienController;
        public StatisticForm()
        {
            InitializeComponent();
            thanhVienController = new ThanhVienController();
            loadDuLieu();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadDuLieu()
        {
            txtTongSoTv.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (t:ThanhVien) RETURN COUNT(t)")+ " người";
            txtDaMat.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (t:ThanhVien) RETURN COUNT(t.NgayMat)") + " người";
            txtConSong.Text = "" + (thanhVienController.layTongSoThanhVien("MATCH (t:ThanhVien) RETURN COUNT(t)") - thanhVienController.layTongSoThanhVien("MATCH (t:ThanhVien) RETURN COUNT(t.NgayMat)")) + " người";
            txtThanhVienNam.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (t:ThanhVien) WHERE t.GioiTinh='Nam' RETURN COUNT(t)") + " người";
            txtThanhVienNu.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (t:ThanhVien) WHERE t.GioiTinh='Nữ' RETURN COUNT(t)") + " người";
            txtDoTuoi1.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (n:ThanhVien) WHERE(date().year - n.NgaySinh.year) >= 0 AND (date().year - n.NgaySinh.year) <= 5 RETURN COUNT(n)") + " người";
            txtDoTuoi2.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (n:ThanhVien) WHERE(date().year - n.NgaySinh.year) >= 6 AND (date().year - n.NgaySinh.year) <= 17 RETURN COUNT(n)") + " người";
            txtDoTuoi3.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (n:ThanhVien) WHERE(date().year - n.NgaySinh.year) >= 18 AND (date().year - n.NgaySinh.year) <= 35 RETURN COUNT(n)") + " người";
            txtDoTuoi4.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (n:ThanhVien) WHERE(date().year - n.NgaySinh.year) >= 36 AND (date().year - n.NgaySinh.year) <= 60 RETURN COUNT(n)") + " người";
            txtDoTuoi5.Text = "" + thanhVienController.layTongSoThanhVien("MATCH (n:ThanhVien) WHERE(date().year - n.NgaySinh.year) > 60 RETURN COUNT(n)") + " người";           
        }
    }
}

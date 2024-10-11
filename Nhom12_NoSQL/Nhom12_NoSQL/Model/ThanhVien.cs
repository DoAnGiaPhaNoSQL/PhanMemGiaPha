using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_NoSQL.Model
{
    class ThanhVien
    {
        private int id;
        private string hoTen;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string tenThuongGoi;
        private string cccd_cmnd;
        private string tonGiao;
        private string quocTich;
        private string noiSinh;
        private int conThu;
        private int doiThu;
        private string tenCha;
        private string tenMe;
        private DateTime? ngayMat;
        private string quanHe;
        private int keTu;
        private List<ThanhVien> danhSachChaMe;
        private List<ThanhVien> danhSachAnhChiEm;
        private List<ThanhVien> danhSachCon;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string TenThuongGoi { get => tenThuongGoi; set => tenThuongGoi = value; }
        public string Cccd_cmnd { get => cccd_cmnd; set => cccd_cmnd = value; }
        public string TonGiao { get => tonGiao; set => tonGiao = value; }
        public string QuocTich { get => quocTich; set => quocTich = value; }
        public string NoiSinh { get => noiSinh; set => noiSinh = value; }
        public int ConThu { get => conThu; set => conThu = value; }
        public string TenCha { get => tenCha; set => tenCha = value; }
        public string TenMe { get => tenMe; set => tenMe = value; }
        public DateTime? NgayMat { get => ngayMat; set => ngayMat = value; }
        public string QuanHe { get => quanHe; set => quanHe = value; }
        public int DoiThu { get => doiThu; set => doiThu = value; }
        internal List<ThanhVien> DanhSachChaMe { get => danhSachChaMe; set => danhSachChaMe = value; }
        internal List<ThanhVien> DanhSachAnhChiEm { get => danhSachAnhChiEm; set => danhSachAnhChiEm = value; }
        internal List<ThanhVien> DanhSachCon { get => danhSachCon; set => danhSachCon = value; }
        public int Id { get => id; set => id = value; }
        public int KeTu { get => keTu; set => keTu = value; }

        public ThanhVien()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_NoSQL.Model
{
    class NgheNghiep
    {
        private int idNgheNghiep;
        private string tenCoQuan;
        private string diaChi;
        private string viTriCongTac;
        private string nghenghiep;
        private DateTime? thoiGianBatDau;
        private DateTime? thoiGianKetThuc;

        public string TenCoQuan { get => tenCoQuan; set => tenCoQuan = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string ViTriCongTac { get => viTriCongTac; set => viTriCongTac = value; }
        public string Nghenghiep { get => nghenghiep; set => nghenghiep = value; }
        public DateTime? ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public DateTime? ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public int IdNgheNghiep { get => idNgheNghiep; set => idNgheNghiep = value; }

        public NgheNghiep()
        {

        }
    }
}

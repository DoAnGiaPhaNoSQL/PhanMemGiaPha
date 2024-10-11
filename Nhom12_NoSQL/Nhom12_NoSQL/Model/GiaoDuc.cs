using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_NoSQL.Model
{
    class GiaoDuc
    {
        private int id;
        private string tenTruong;
        private string moTa;
        private DateTime? thoiGianBatDau;
        private DateTime? thoiGianKetThuc;
        public GiaoDuc()
        {

        }
        public string TenTruong { get => tenTruong; set => tenTruong = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public DateTime? ThoiGianBatDau { get => thoiGianBatDau; set => thoiGianBatDau = value; }
        public DateTime? ThoiGianKetThuc { get => thoiGianKetThuc; set => thoiGianKetThuc = value; }
        public int Id { get => id; set => id = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using Nhom12_NoSQL.Model;
namespace Nhom12_NoSQL.Controller
{
    class NgheNghiepController
    {
        private NoSQL_Connection connection;
        public NoSQL_Connection Connection { get => connection; set => connection = value; }
        public NgheNghiepController()
        {
            this.connection = new NoSQL_Connection();
        }
        public List<NgheNghiep> LayDanhSachThongTinNgheNghiep(int id)
        {
            List<NgheNghiep> danhSach = new List<NgheNghiep>();
            string query = "MATCH(nn:NgheNghiep)<-[r:LamViec]-(p:ThanhVien) WHERE id(p)=" + id + " RETURN id(nn) as identity, nn.TenCoQuan as TenCoQuan,nn.DiaChi as DiaChi,r.ThoiGianBatDau as ThoiGianBatDau,r.ThoiGianKetThuc as ThoiGianKetThuc, r.NgheNghiep as NgheNghiep, r.ViTriCongTac as ViTriCongTac";
            var listRecord = connection.SelectListProperties(query);
            if (listRecord != null)
            {
                foreach (var record in listRecord)
                {
                    NgheNghiep ngheNghiep = new NgheNghiep();
                    ngheNghiep.IdNgheNghiep = record["identity"].As<int>();
                    ngheNghiep.TenCoQuan = record["TenCoQuan"].As<string>();
                    ngheNghiep.DiaChi= record["DiaChi"].As<string>();
                    ngheNghiep.ViTriCongTac = record["ViTriCongTac"].As<string>();
                    ngheNghiep.Nghenghiep = record["NgheNghiep"].As<string>();
                    ngheNghiep.ThoiGianBatDau = record["ThoiGianBatDau"]?.As<DateTime>();
                    ngheNghiep.ThoiGianKetThuc = record["ThoiGianKetThuc"]?.As<DateTime>();
                    danhSach.Add(ngheNghiep);
                }
                return danhSach;
            }
            return null;
        }
        public bool ktrNgheNghiepCoTonTai(int id)
        {
            string query = "MATCH(nn:NgheNghiep) WHERE id(nn)=" + id + " RETURN nn";
            var node = connection.SelectNode(query);
            if (node == null)
            {
                return false;
            }
            return true;
        }
        public bool taoNodeNgheNghiep(NgheNghiep nn, int idThanhVien)
        {
            string query = "CREATE(nn:NgheNghiep{TenCoQuan:'" + nn.TenCoQuan + "',DiaChi:'"+nn.DiaChi+"'}) return id(nn)";
            int id = connection.CreateTraVeID(query);
            //Tạo kết nối giữa thành viên với node nghề nghiệp
            query = "MATCH(nn:NgheNghiep),(t:ThanhVien) WHERE id(nn)=" + id + " AND id(t)=" + idThanhVien + " CREATE (t)-[:LamViec{";
            string extra = "";
            if (nn.ThoiGianBatDau != null)
            {
                extra = extra + "ThoiGianBatDau: date('" + nn.ThoiGianBatDau.Value.ToString("yyyy-MM-dd") + "')";
            }
            if (nn.ThoiGianKetThuc != null)
            {
                if (extra=="")
                {
                    extra = extra + "ThoiGianKetThuc: date('" + nn.ThoiGianKetThuc.Value.ToString("yyyy-MM-dd") + "')";
                }
                else
                {
                    extra = extra + ",ThoiGianKetThuc: date('" + nn.ThoiGianKetThuc.Value.ToString("yyyy-MM-dd") + "')";
                }
            }
            if (nn.ViTriCongTac != "")
            {
                if (extra=="")
                {
                    extra = extra + "ViTriCongTac:'" + nn.ViTriCongTac + "'";
                }
                else
                {
                    extra = extra + ",ViTriCongTac:'" + nn.ViTriCongTac + "'";
                }
                
            }
            if (nn.Nghenghiep!="")
            {
                if (extra=="")
                {
                    extra = extra + "NgheNghiep:'" + nn.Nghenghiep + "'";
                }
                else
                {
                    extra = extra + ",NgheNghiep:'" + nn.Nghenghiep + "'";
                }
                
            }
            query = query + extra + "}]->(nn) RETURN t,nn";
            return connection.Create(query);
        }
        public bool chinhSuaThongTinNgheNghiep(NgheNghiep nn, int idThanhVien)
        {
            string query = "MATCH (nn:NgheNghiep)<-[r:LamViec]-(p:ThanhVien) WHERE id(nn)=" + nn.IdNgheNghiep + " AND id(p)=" + idThanhVien + " SET nn.TenCoQuan='" + nn.TenCoQuan + "', nn.DiaChi='"+nn.DiaChi+"' ";
            string extra = "";
            if (nn.ViTriCongTac != "")
            {
                extra += ", r.ViTriCongTac='" + nn.ViTriCongTac + "'";
            }
            if (nn.Nghenghiep!="")
            {
                extra += ", r.NgheNghiep='" + nn.Nghenghiep + "'";
            }
            if (nn.ThoiGianBatDau != null)
            {
                extra += ", r.ThoiGianBatDau= date('" + nn.ThoiGianBatDau.Value.ToString("yyyy-MM-dd") + "')";
            }
            if (nn.ThoiGianKetThuc != null)
            {
                extra += ", r.ThoiGianKetThuc = date('" + nn.ThoiGianKetThuc.Value.ToString("yyyy-MM-dd") + "')";
            }
            query += extra + " RETURN p,nn";
            return connection.Update(query);
        }
        public bool xoaThongTinNgheNghiep(int idNgheNghiep, int idThanhVien)
        {
            string query = "MATCH(nn:NgheNghiep)<-[:LamViec]-(p:ThanhVien) WHERE id(nn)=" + idNgheNghiep + " AND id(p)=" + idThanhVien + " DETACH DELETE nn";
            return connection.Delete(query);
        }
    }
}

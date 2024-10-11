using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using Nhom12_NoSQL.Model;
namespace Nhom12_NoSQL.Controller
{
    class GiaoDucController
    {
        private NoSQL_Connection connection;
        public NoSQL_Connection Connection { get => connection; set => connection = value; }
        public GiaoDucController()
        {
            this.connection = new NoSQL_Connection();
        }
        public List<GiaoDuc> LayDanhSachThongTinGiaoDuc(int id)
        {
            List<GiaoDuc> danhSach = new List<GiaoDuc>();
            string query = "MATCH(gd:GiaoDuc)<-[r:TheoHoc]-(p:ThanhVien) WHERE id(p)="+id+" RETURN id(gd) as identity, gd.TenTruong as TenTruong,r.ThoiGianBatDau as ThoiGianBatDau,r.ThoiGianKetThuc as ThoiGianKetThuc, r.MoTa as MoTa";
            var listRecord = connection.SelectListProperties(query);
            if (listRecord!=null)
            {
                foreach(var record in listRecord)
                {
                    GiaoDuc giaoDuc = new GiaoDuc();
                    giaoDuc.Id = record["identity"].As<int>();
                    giaoDuc.TenTruong = record["TenTruong"].As<string>();
                    giaoDuc.ThoiGianBatDau = record["ThoiGianBatDau"]?.As<DateTime>();
                    giaoDuc.ThoiGianKetThuc = record["ThoiGianKetThuc"]?.As<DateTime>();
                    giaoDuc.MoTa = record["MoTa"].As<string>();
                    danhSach.Add(giaoDuc);
                }
                return danhSach;
            }
            return null;
        }
        public bool ktrGiaoDucCoTonTai(int id)
        {
            string query = "MATCH(gd:GiaoDuc) WHERE id(gd)="+id+" RETURN gd";
            var node= connection.SelectNode(query);
            if (node == null) 
            {
                return false;
            }
            return true;
        }
        public bool taoNodeGiaoDuc(GiaoDuc gd,int idThanhVien)
        {
            string query = "CREATE(gd:GiaoDuc{TenTruong:'"+gd.TenTruong+"'}) return id(gd)";            
            int id= connection.CreateTraVeID(query);
            //Tạo kết nối giữa thành viên với node giáo dục
            query = "MATCH(gd:GiaoDuc),(t:ThanhVien) WHERE id(gd)=" + id + " AND id(t)=" + idThanhVien + " CREATE (t)-[:TheoHoc{";
            string extra = "";
            if (gd.ThoiGianBatDau!=null)
            {
                extra = extra + "ThoiGianBatDau: date('" + gd.ThoiGianBatDau.Value.ToString("yyyy-MM-dd") + "')";
            }
            if (gd.ThoiGianKetThuc!=null)
            {
                if (extra=="")
                {
                    extra = extra + "ThoiGianKetThuc: date('" + gd.ThoiGianKetThuc.Value.ToString("yyyy-MM-dd") + "')";
                }
                else
                {
                    extra = extra + ",ThoiGianKetThuc: date('" + gd.ThoiGianKetThuc.Value.ToString("yyyy-MM-dd") + "')";
                }
                
            }
            if (gd.MoTa!="")
            {
                if (extra=="")
                {
                    extra = extra + "MoTa:'" + gd.MoTa + "'";
                }
                else
                {
                    extra = extra + ",MoTa:'" + gd.MoTa + "'";
                }
                
            }
            query = query + extra+ "}]->(gd) RETURN t,gd";
            return connection.Create(query);
        }
        public bool chinhSuaThongTinGiaoDuc(GiaoDuc gd,int idThanhVien)
        {
            string query = "MATCH (gd:GiaoDuc)<-[r:TheoHoc]-(p:ThanhVien) WHERE id(gd)=" + gd.Id + " AND id(p)="+idThanhVien+" SET gd.TenTruong='"+gd.TenTruong+"' ";
            string extra = "";
            if (gd.MoTa != "")
            {
                extra += ", r.MoTa='" + gd.MoTa + "'";
            }
            if (gd.ThoiGianBatDau != null)
            {
                extra+= ", r.ThoiGianBatDau= date('" + gd.ThoiGianBatDau.Value.ToString("yyyy-MM-dd") + "')";
            }
            if (gd.ThoiGianKetThuc!=null)
            {
                extra += ", r.ThoiGianKetThuc = date('" + gd.ThoiGianKetThuc.Value.ToString("yyyy-MM-dd") + "')";
            }
            query += extra + " RETURN p,gd";
            return connection.Update(query);
        }
        public bool xoaThongTinGiaoDuc(int idGiaoDuc, int idThanhVien)
        {
            string query = "MATCH(gd:GiaoDuc)<-[:TheoHoc]-(p:ThanhVien) WHERE id(gd)="+ idGiaoDuc +" AND id(p)="+idThanhVien+" DETACH DELETE gd";
            return connection.Delete(query);
        }
    }
}

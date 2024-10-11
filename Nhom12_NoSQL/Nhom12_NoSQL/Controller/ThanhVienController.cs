using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Nhom12_NoSQL.Model;
using Neo4j.Driver;
namespace Nhom12_NoSQL.Controller
{
    class ThanhVienController
    {
        private NoSQL_Connection connection;
        public NoSQL_Connection Connection { get => connection; set => connection = value; }
        public ThanhVienController()
        {
            this.connection = new NoSQL_Connection();
        }
        private string CauQueryThemThanhVien(ThanhVien tv)
        {
            string query = "CREATE (t:ThanhVien{HoTen:'" + tv.HoTen + "',DoiThu:"+tv.DoiThu+",GioiTinh:'" + tv.GioiTinh + "',NgaySinh:date('" + tv.NgaySinh.ToString("yyyy-MM-dd") + "'),ConThu:" + tv.ConThu + ",QuocTich:'" + tv.QuocTich + "',TonGiao:'" + tv.TonGiao + "', created_at:date('" + DateTime.Now.ToString("yyyy-MM-dd") + "')";
            string extra_update = "";
            if (tv.Cccd_cmnd != "")
            {
                extra_update = ",CCCD_CMND: '" + tv.Cccd_cmnd + "'";
            }
            if (tv.TenThuongGoi != "")
            {
                extra_update = extra_update + " , TenThuongGoi: '" + tv.TenThuongGoi + "'";
            }
            if (tv.NoiSinh != "")
            {
                extra_update = extra_update + " , NoiSinh: '" + tv.NoiSinh + "'";
            }
            if (tv.NgayMat != null)
            {
                extra_update = extra_update + " , t.NgayMat= date('" + tv.NgayMat.Value.ToString("yyyy-MM-dd") + "')";
            }
            string end_query = "}) RETURN id(t)";
            query = query + extra_update + end_query;
            return query;
        }
        public bool ChinhLaiSoDoi()
        {
            string query = "MATCH(t:ThanhVien) SET t.DoiThu = t.DoiThu + 1 RETURN t";
            return connection.Update(query);
        }
        public bool KtrTruongHo(int id)
        {
            string query = "MATCH(t:ThanhVien) WHERE id(t)=" + id + " AND t.TruongHo IS NOT NULL RETURN COUNT(t)";
            int result =int.Parse(connection.Select(query));
            if (result==1)
            {
                return true;
            }
            return false;
        }
        public bool KtrToPhu(int id)
        {
            string query = "MATCH(t:ThanhVien) WHERE id(t)=" + id + " AND t.ToPhu IS NOT NULL RETURN COUNT(t)";
            int result = int.Parse(connection.Select(query));
            if (result == 1)
            {
                return true;
            }
            return false;
        }
        public bool TaoThanhVienToPhu(ThanhVien tv)
        {
            string query = CauQueryThemThanhVien(tv);
            int idToPhu= connection.CreateTraVeID(query);
            //Tạo làm tổ phụ
            string queryTaoToPhu = "MATCH (t:ThanhVien) WHERE id(t)=" + idToPhu + " SET t.ToPhu='Đang hoạt động' RETURN t";
            return connection.Create(queryTaoToPhu);
        }
        public bool XoaTruongHo(int idTV)
        {
            string query = "MATCH (t:ThanhVien) WHERE id(t)=" + idTV + " REMOVE t.TruongHo RETURN t";
            return connection.Update(query);
        }
        public bool DatLamTruongHo(int idTV)
        {
            string query = "MATCH (t:ThanhVien) WHERE id(t)=" + idTV + " SET t.TruongHo='Đang hoạt động' RETURN t";
            return connection.Update(query);
        }
        public bool DatLamToPhu(int id)
        {
            //Xóa tổ phụ cũ
            string queryXoaToPhuCu = "MATCH (t:ThanhVien) WHERE t.ToPhu IS NOT NULL REMOVE t.ToPhu RETURN t";
            connection.Update(queryXoaToPhuCu);
            //Tạo tổ phụ mới
            string queryTaoToPhuMoi = "MATCH (t:ThanhVien) WHERE id(t)=" + id + " SET t.ToPhu='Đang hoạt động' RETURN t";
            return connection.Create(queryTaoToPhuMoi);
        }
        public bool ktrThanhVien(string hoTen,int id)
        {
            string query = "MATCH (t:ThanhVien{HoTen:'"+hoTen+ "'})WHERE id(t) = " + id + " RETURN COUNT(t)";
            int result = int.Parse(connection.Select(query));
            if (result==0)
            {
                return false;
            }
            return true;
        }
        public bool ktrVoChongThanhVien(string hoTenThanhVien,string hoTenVoChong)
        {
            string query = "MATCH (t:ThanhVien{HoTen:'" + hoTenThanhVien + "'})-[:QuanHe{MoiQuanHe:'Vợ chồng'}]->(p:ThanhVien{HoTen:'"+hoTenVoChong+"'}) RETURN COUNT(p)";
            int result = int.Parse(connection.Select(query));
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public bool ktrThongTinCha(int id)
        {
            string query = "MATCH (t:ThanhVien)<-[:QuanHe{MoiQuanHe:'Cha của'}]-(p:ThanhVien) WHERE id(t) = " + id + " RETURN count(p)";
            int result = int.Parse(connection.Select(query));
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public bool ktrThongTinMe(int id)
        {
            string query = "MATCH (t:ThanhVien)<-[:QuanHe{MoiQuanHe:'Mẹ của'}]-(p:ThanhVien) WHERE id(t) = " + id + " RETURN count(p)";
            int result = int.Parse(connection.Select(query));
            if (result == 0)
            {
                return false;
            }
            return true;
        }
        public bool chinhSuaThongTinThanhVien(ThanhVien tv)
        {
            string query="MATCH (t:ThanhVien) WHERE id(t) ="+tv.Id+" SET t.HoTen = '"+tv.HoTen+"', t.NgaySinh= date('"+tv.NgaySinh.ToString("yyyy-MM-dd")+"'), t.ConThu="+tv.ConThu+" , t.GioiTinh= '"+tv.GioiTinh+"' , t.QuocTich='"+tv.QuocTich+"' , t.TonGiao='"+tv.TonGiao+"'";
            string extra_update = "";
            if (tv.Cccd_cmnd != "")
            {
                extra_update = ", t.CCCD_CMND = '" + tv.Cccd_cmnd + "'";
            }
            if (tv.TenThuongGoi != "")
            {
                extra_update = extra_update + " , t.TenThuongGoi= '" + tv.TenThuongGoi + "'";
            }
            if (tv.NoiSinh != "") 
            {
                extra_update = extra_update + " , t.NoiSinh= '" + tv.NoiSinh + "'";
            }
            if (tv.NgayMat!=null)
            {
                extra_update = extra_update + " , t.NgayMat= date('" + tv.NgayMat.Value.ToString("yyyy-MM-dd") + "')";
            }
            else
            {
                string xoaNgayMat = "MATCH (t:ThanhVien) WHERE id(t) =" + tv.Id + " REMOVE t.NgayMat RETURN t";
                connection.Update(xoaNgayMat);
            }
            string end_query = " RETURN t";
            query = query + extra_update + end_query;
            return connection.Update(query);
        }
        public bool chinhSuaThongTinVoChong(ThanhVien voChong,int id)
        {
            string query = "MATCH (t:ThanhVien)-[r:QuanHe{MoiQuanHe:'Vợ chồng'}]-(p:ThanhVien) WHERE id(t)=" + voChong.Id + " AND id(p)=" + id + " SET r.since="+voChong.KeTu+", r.status='"+voChong.QuanHe+"' RETURN t";
            return connection.Update(query);
        }
        public bool themVoChong(ThanhVien tv,int idVoChong)
        {
            string query = CauQueryThemThanhVien(tv);
            int id = connection.CreateTraVeID(query);
            //Tạo mối liên kết giữa vợ và chồng
            query = "MATCH (t:ThanhVien),(p:ThanhVien) WHERE id(t)=" + id + " AND id(p)=" + idVoChong + " CREATE (t)-[:QuanHe{MoiQuanHe:'Vợ chồng',since:" + tv.KeTu + ",status:'" + tv.QuanHe + "'}]->(p), (t)<-[:QuanHe{MoiQuanHe:'Vợ chồng',since:" + tv.KeTu + ",status:'" + tv.QuanHe + "'}]-(p) RETURN t";
            connection.Create(query);
            if (id!=-1)
            {
                return true;
            }
            return false;
        }
        public bool themCon(ThanhVien tv,int idCha,int idMe)
        {
            string queryThemCon = CauQueryThemThanhVien(tv);
            int id= connection.CreateTraVeID(queryThemCon);
            //Tạo mối liên kết giữa con với cha mẹ
            string query = "MATCH (t:ThanhVien),(p:ThanhVien),(m:ThanhVien) WHERE id(p) = " + idCha + " AND id(m)=" + idMe + " AND id(t)=" + id + " CREATE (t)<-[:QuanHe{MoiQuanHe:'Cha của',since:" + tv.NgaySinh.Year + "}]-(p), (t)<-[:QuanHe{MoiQuanHe:'Mẹ của',since:" + tv.NgaySinh.Year + "}]-(m) RETURN t";
            connection.Create(query);
            //Tạo mối liên kết với anh chị em
            query = "MATCH(t: ThanhVien)-[:QuanHe{ MoiQuanHe: 'Cha của'}]->(p: ThanhVien) WHERE id(p) <> "+id+" and id(t)=" + idCha + " RETURN p";
            List<ThanhVien> danhSachAnhChiEm = selectThanhVien(query);
            foreach(ThanhVien anhChiEm in danhSachAnhChiEm)
            {
                query = "MATCH(t:ThanhVien),(p:ThanhVien) WHERE id(p)=" + id + " AND id(t)=" + anhChiEm.Id + " CREATE (t)-[:QuanHe{MoiQuanHe:'Anh chị em',since:"+tv.NgaySinh.Year+ "}]->(p), (t)<-[:QuanHe{MoiQuanHe:'Anh chị em',since:" + tv.NgaySinh.Year + "}]-(p) RETURN t";
                connection.Create(query);
            }
            if (id!=-1)
            {
                return true;
            }
            return false;
        }
        public bool themCha(ThanhVien tvCha,int idCon,DateTime ngaySinhCuaCon)
        {
            string queryThemCha = CauQueryThemThanhVien(tvCha);
            int idCha = connection.CreateTraVeID(queryThemCha);
            //Kiểm tra đã có thông tin của mẹ chưa
            if (ktrThongTinMe(idCon))
            {
                //Tạo mối liên kết giữa cha và mẹ
                int idMe = layIdThanhVienMe(idCon);
                string queryTaoLienKetChaMe = "MATCH (t:ThanhVien),(p:ThanhVien) WHERE id(t)=" + idCha + " AND id(p)=" + idMe + " CREATE (t)-[:QuanHe{MoiQuanHe:'Vợ chồng',since:" + ngaySinhCuaCon.Year + ",status:'Đã kết hôn'}]->(p), (t)<-[:QuanHe{MoiQuanHe:'Vợ chồng',since:" + ngaySinhCuaCon.Year + ",status:'Đã kết hôn'}]-(p) RETURN t";
                bool result1 = connection.Create(queryTaoLienKetChaMe);
            }
            //Tạo mối liên kết giữa cha con
            string queryTaoLienKetChaCon = "MATCH (t:ThanhVien),(p:ThanhVien) WHERE id(p) = " + idCha + " AND id(t)=" + idCon + " CREATE (t)<-[:QuanHe{MoiQuanHe:'Cha của',since:" + ngaySinhCuaCon.Year + "}]-(p) RETURN t";
            bool result2 = connection.Create(queryTaoLienKetChaCon);
            if (idCha != -1 && result2)
            {
                return true;
            }
            return false;
        }
        public bool themMe(ThanhVien tvMe, int idCon, DateTime ngaySinhCuaCon)
        {
            string queryThemMe = CauQueryThemThanhVien(tvMe);
            int idMe = connection.CreateTraVeID(queryThemMe);
            //Kiểm tra đã có thông tin của cha chưa
            if (ktrThongTinCha(idCon))
            {
                //Tạo mối liên kết giữa cha và mẹ
                int idCha = layIdThanhVienCha(idCon);
                string queryTaoLienKetChaMe = "MATCH (t:ThanhVien),(p:ThanhVien) WHERE id(t)=" + idCha + " AND id(p)=" + idMe + " CREATE (t)-[:QuanHe{MoiQuanHe:'Vợ chồng',since:" + ngaySinhCuaCon.Year + ",status:'Đã kết hôn'}]->(p), (t)<-[:QuanHe{MoiQuanHe:'Vợ chồng',since:" + ngaySinhCuaCon.Year + ",status:'Đã kết hôn'}]-(p) RETURN t";
                bool result1 = connection.Create(queryTaoLienKetChaMe); 
            }
            //Tạo mối liên kết giữa mẹ con
            string queryTaoLienKetMeCon = "MATCH (t:ThanhVien),(m:ThanhVien) WHERE id(m)=" + idMe + " AND id(t)=" + idCon + " CREATE (t)<-[:QuanHe{MoiQuanHe:'Mẹ của',since:" + ngaySinhCuaCon.Year + "}]-(m) RETURN t";
            bool result2 = connection.Create(queryTaoLienKetMeCon);
            if (idMe != -1 && result2)
            {
                return true;
            }
            return false;
        }
        public bool xoaThanhVien(string hoTen,int id)
        {
            string queryXoaLienKetGiaoDuc = "MATCH(t:ThanhVien)-[h:TheoHoc]->(gd:GiaoDuc) WHERE id(t)="+id+" DETACH DELETE gd";
            connection.Delete(queryXoaLienKetGiaoDuc);
            string queryXoaLienKetNgheNghiep = "MATCH(t:ThanhVien)-[h:LamViec]->(nn:NgheNghiep) WHERE id(t)=" + id + " DETACH DELETE nn";
            connection.Delete(queryXoaLienKetNgheNghiep);
            string query= "MATCH(t:ThanhVien{HoTen:'" + hoTen + "'}) WHERE id(t)=" + id + " DETACH DELETE t";
            return connection.Delete(query);
        }
        public int layTongSoThanhVien(string query)
        {
            int tongSoThanhVien;
            tongSoThanhVien = int.Parse(connection.Select(query));
            return tongSoThanhVien;
        }      
        public int layIdThanhVienVoChong(string hoTen,int id)
        {
            string query = "MATCH (t:ThanhVien{HoTen:'" + hoTen + "'})-[:QuanHe{MoiQuanHe:'Vợ chồng'}]->(p:ThanhVien) WHERE id(p)="+id+" RETURN id(t)";
            return int.Parse(connection.Select(query));
        }
        public int layIdThanhVienCha(int idCon)
        {
            string query = "MATCH (t:ThanhVien)<-[:QuanHe{MoiQuanHe:'Cha của'}]-(p:ThanhVien) WHERE id(t) = " + idCon + " RETURN id(p)";
            int result = int.Parse(connection.Select(query));
            return result;
        }
        public int layIdThanhVienMe(int idCon)
        {
            string query = "MATCH (t:ThanhVien)<-[:QuanHe{MoiQuanHe:'Mẹ của'}]-(p:ThanhVien) WHERE id(t) = " + idCon + " RETURN id(p)";
            int result = int.Parse(connection.Select(query));
            return result;
        }
        public string layHoCuaChong(int id)
        {
            string query = "MATCH(t:ThanhVien) WHERE id(t)=" + id + " RETURN t.HoTen";
            return connection.Select(query);
        }
        public int laySoDoiCuaThanhVien(int id)
        {
            string query = "MATCH(t:ThanhVien) WHERE id(t)=" + id + " RETURN t.DoiThu";
            return int.Parse(connection.Select(query));
        }
        public List<ThanhVien> selectThanhVien()
        {
            string query = "MATCH (t:ThanhVien) RETURN t ORDER BY t.DoiThu ASC";
            List<ThanhVien> list = new List<ThanhVien>();
            var listNode = connection.SelectListNode(query);
            if (listNode!=null)
            {
                foreach( var node in listNode)
                {
                    ThanhVien tv = new ThanhVien();
                    tv.Id = (int)node.Id;
                    foreach (var prop in node.Properties)
                    {               
                        switch (prop.Key)
                        {
                            case "HoTen":
                                tv.HoTen = prop.Value.As<string>();
                                break;
                            case "GioiTinh":
                                tv.GioiTinh = prop.Value.As<string>();
                                break;
                            case "DoiThu":
                                tv.DoiThu = prop.Value.As<int>();
                                break;
                            case "NgaySinh":
                                tv.NgaySinh = prop.Value.As<DateTime>();
                                break;
                            case "CCCD_CMND":
                                tv.Cccd_cmnd = prop.Value?.As<string>();
                                break;
                            case "TenThuongGoi":
                                tv.TenThuongGoi = prop.Value?.As<string>();
                                break;
                            case "NgayMat":
                                tv.NgayMat = prop.Value?.As<DateTime>();
                                break;
                            case "TonGiao":
                                tv.TonGiao = prop.Value.As<string>();
                                break;
                            case "NoiSinh":
                                tv.NoiSinh = prop.Value?.As<string>();
                                break;
                            case "QuocTich":
                                tv.QuocTich = prop.Value.As<string>();
                                break;
                            case "ConThu":
                                tv.ConThu = prop.Value.As<int>();
                                break;
                            default:
                                break;
                        }
                    }
                    list.Add(tv);
                }
                return list;
            }            
            return null;
        }
        public List<ThanhVien> selectThanhVien(string query)
        {
            List<ThanhVien> list = new List<ThanhVien>();
            var listNode = connection.SelectListNode(query);
            if (listNode != null)
            {
                foreach (var node in listNode)
                {
                    ThanhVien tv = new ThanhVien();
                    tv.Id = (int)node.Id;
                    foreach (var prop in node.Properties)
                    {
                        switch (prop.Key)
                        {
                            case "HoTen":
                                tv.HoTen = prop.Value.As<string>();
                                break;
                            case "GioiTinh":
                                tv.GioiTinh = prop.Value.As<string>();
                                break;
                            case "DoiThu":
                                tv.DoiThu = prop.Value.As<int>();
                                break;
                            case "NgaySinh":
                                tv.NgaySinh = prop.Value.As<DateTime>();
                                break;
                            case "CCCD_CMND":
                                tv.Cccd_cmnd = prop.Value?.As<string>();
                                break;
                            case "TenThuongGoi":
                                tv.TenThuongGoi = prop.Value?.As<string>();
                                break;
                            case "NgayMat":
                                tv.NgayMat = prop.Value?.As<DateTime>();
                                break;
                            case "TonGiao":
                                tv.TonGiao = prop.Value.As<string>();
                                break;
                            case "NoiSinh":
                                tv.NoiSinh = prop.Value?.As<string>();
                                break;
                            case "QuocTich":
                                tv.QuocTich = prop.Value.As<string>();
                                break;
                            case "ConThu":
                                tv.ConThu = prop.Value.As<int>();
                                break;
                            default:
                                break;
                        }
                    }
                    list.Add(tv);
                }
                return list;
            }
            return null;
        }
        public ThanhVien TruyVan(string query)
        {
            ThanhVien tv = new ThanhVien();
            var node = connection.SelectNode(query);
            if (node != null)
            {
                tv.Id = (int)node.Id;
                foreach (var prop in node.Properties)
                {
                    switch (prop.Key)
                    {
                        case "HoTen":
                            tv.HoTen = prop.Value.As<string>();
                            break;
                        case "GioiTinh":
                            tv.GioiTinh = prop.Value.As<string>();
                            break;
                        case "DoiThu":
                            tv.DoiThu = prop.Value.As<int>();
                            break;
                        case "NgaySinh":
                            tv.NgaySinh = prop.Value.As<DateTime>();
                            break;
                        case "CCCD_CMND":
                            tv.Cccd_cmnd = prop.Value?.As<string>();
                            break;
                        case "TenThuongGoi":
                            tv.TenThuongGoi = prop.Value?.As<string>();
                            break;
                        case "NgayMat":
                            tv.NgayMat = prop.Value?.As<DateTime>();
                            break;
                        case "TonGiao":
                            tv.TonGiao = prop.Value.As<string>();
                            break;
                        case "NoiSinh":
                            tv.NoiSinh = prop.Value?.As<string>();
                            break;
                        case "QuocTich":
                            tv.QuocTich = prop.Value.As<string>();
                            break;
                        case "ConThu":
                            tv.ConThu = prop.Value.As<int>();
                            break;
                        default:
                            break;
                    }
                }
                return tv;
            }
            return null;
        }
        public List<ThanhVien> TruyVanVoChong(string hoTen)
        {
            string query = "MATCH(t:ThanhVien{HoTen:'" + hoTen + "'})-[r:QuanHe{MoiQuanHe:'Vợ chồng'}]->(p:ThanhVien)" +
                    " RETURN p , r.status , r.since ORDER BY r.since ASC";
            List<ThanhVien> danhSachTV = new List<ThanhVien>();    
            var danhSachTuple= connection.LayTTVoChongVaTinhTrangQuanHe(query);
            if (danhSachTuple != null)
            {
                foreach (var item in danhSachTuple)
                {
                    ThanhVien tv = new ThanhVien();
                    var node = item.Item1;
                    tv.Id = (int)node.Id;
                    tv.QuanHe = item.Item2;
                    tv.KeTu = item.Item3;
                    foreach (var prop in node.Properties)
                    {
                        switch (prop.Key)
                        {
                            case "HoTen":
                                tv.HoTen = prop.Value.As<string>();
                                break;
                            case "GioiTinh":
                                tv.GioiTinh = prop.Value.As<string>();
                                break;
                            case "DoiThu":
                                tv.DoiThu = prop.Value.As<int>();
                                break;
                            case "NgaySinh":
                                tv.NgaySinh = prop.Value.As<DateTime>();
                                break;
                            case "CCCD_CMND":
                                tv.Cccd_cmnd = prop.Value?.As<string>();
                                break;
                            case "TenThuongGoi":
                                tv.TenThuongGoi = prop.Value?.As<string>();
                                break;
                            case "NgayMat":
                                tv.NgayMat = prop.Value?.As<DateTime>();
                                break;
                            case "TonGiao":
                                tv.TonGiao = prop.Value.As<string>();
                                break;
                            case "NoiSinh":
                                tv.NoiSinh = prop.Value?.As<string>();
                                break;
                            case "QuocTich":
                                tv.QuocTich = prop.Value.As<string>();
                                break;
                            case "ConThu":
                                tv.ConThu = prop.Value.As<int>();
                                break;
                            default:
                                break;
                        }
                    }
                    danhSachTV.Add(tv);
                }
                return danhSachTV;
            }
            return null;
        }
        public List<ThanhVien> truyVanLayThuocTinh(string query)
        {
            List<ThanhVien> danhSach = new List<ThanhVien>();
            var properties = connection.SelectListProperties(query);
            if (properties != null)
            {
                foreach(var prop in properties)
                {
                    ThanhVien tv = new ThanhVien();
                    tv.HoTen = prop["HoTen"].As<string>();
                    tv.GioiTinh = prop["GioiTinh"].As<string>();
                    tv.NgaySinh = prop["NgaySinh"].As<DateTime>();
                    tv.QuanHe = prop["QuanHe"].As<string>().Split(' ')[0];
                    danhSach.Add(tv);
                }
                return danhSach;
            }
            return null;
        }
        public List<Tuple<string,string,string>> danhSachTruongHo()
        {
            string query = "MATCH (t:ThanhVien) WHERE t.TruongHo IS NOT NULL RETURN t.HoTen as HoTen, t.NgaySinh as NgaySinh, t.DoiThu as DoiThu";
            var list = connection.LayDSTruongHo(query);
            return list;
        }
    }
}

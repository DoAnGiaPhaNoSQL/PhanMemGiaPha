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
    public partial class MainForm : Form
    {
        private NoSQL_Connection connection;
        private ThanhVienController thanhVienController;
        private string username;
        private bool themVoChong;
        private bool themCon;
        private bool themCha;
        private bool themMe;
        private int id;
        private int idVoChong;
        private string gioiTinh1;
        private string hoTenCha;
        private DateTime ngaySinhCuaCon;
        private int currentIndex = -1;
        private List<ThanhVien> danhSachVoChong = new List<ThanhVien>();
        public MainForm(string name)
        {
            InitializeComponent();
            this.username = name;
            this.bốMẹToolStripMenuItem.Click += bốMẹToolStripMenuItem_Click;
            this.vợChồngToolStripMenuItem.Click += vợChồngToolStripMenuItem_Click;
            this.conToolStripMenuItem.Click += conToolStripMenuItem_Click;
            thanhVienController = new ThanhVienController();
            this.connection = new NoSQL_Connection();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
            this.dtNgayMat.Visible = false;
            this.dtNgayMatThanhVien.Visible = false;
            rdAllTimKiem.Checked = true;
            daMatChecked();
            LoadData();
            themVoChong = false;
            themCon = false;
            btnThemGiaoDucThanhVien.Enabled = false;
            btnThemNgheNghiepThanhVien.Enabled = false;
            btnThemGiaoDuc.Enabled = false;
            btnThemNgheNghiep.Enabled = false;
            btnThemCha.Enabled = false;
            btnThemMe.Enabled = false;
            btnThemCon.Enabled = false;
            btnPrev.Enabled = false;
            btnNext.Enabled = false;
            btnThemVoChong.Enabled = false;
            cbQuocTich.SelectedIndex = 0;
            cbQuocTichThanhVien.SelectedIndex = 0;
            cbTonGiao.SelectedIndex = 0;
            cbTonGiaoThanhVien.SelectedIndex = 0;
        }
        private void LoadData()
        {
            gridViewDanhSachTV.Rows.Clear();
            var data = thanhVienController.selectThanhVien();
            if (data != null)
            {
                foreach (var thanhVien in data)
                {
                    string tenCha = "";
                    string tenMe = "";
                    string query = "MATCH (t:ThanhVien{HoTen:'" + thanhVien.HoTen + "'})<-[:QuanHe{MoiQuanHe:'Cha của'}]-(p:ThanhVien) RETURN p";
                    ThanhVien cha = thanhVienController.TruyVan(query);
                    if (cha != null)
                    {
                        tenCha = cha.HoTen;
                    }
                    query = "MATCH (t:ThanhVien{HoTen:'" + thanhVien.HoTen + "'})<-[:QuanHe{MoiQuanHe:'Mẹ của'}]-(p:ThanhVien) RETURN p";
                    ThanhVien me = thanhVienController.TruyVan(query);
                    if (me != null)
                    {
                        tenMe = me.HoTen;
                    }
                    gridViewDanhSachTV.Rows.Add(
                        thanhVien.Id,
                        thanhVien.GioiTinh,
                        thanhVien.DoiThu,
                        thanhVien.HoTen,
                        thanhVien.NgaySinh.ToString("dd-MM-yyyy"),
                        tenCha,
                        tenMe,
                        thanhVien.NgayMat
                    );
                }
            }
        }
        private void HienThiThongTinVoChong(ThanhVien tv,int voChongThu)
        {
            BoxHoVaTen.Text = tv.HoTen;
            dtNgaySinh.Value = tv.NgaySinh;
            boxVoChongThu.Text = voChongThu.ToString();
            boxKeTu.Value = new DateTime(tv.KeTu, 1, 1);
            nmConThu.Value = (decimal)tv.ConThu;
            boxTenThuongGoi.Text = tv.TenThuongGoi;
            BoxCMND.Text = tv.Cccd_cmnd;
            boxNoiSinh.Text = tv.NoiSinh;
            cbQuocTich.SelectedItem = tv.QuocTich;
            cbTonGiao.SelectedItem = tv.TonGiao;
            if (tv.NgayMat != null)
            {
                chkDaMat.Checked = true;
                dtNgayMat.Value = (DateTime)tv.NgayMat;
            }
            if (tv.QuanHe == "Đã kết hôn")
            {
                rdbtnDaKetHon.Checked = true;
            }
            else if (tv.QuanHe=="Đã ly dị")
            {
                rdbtnDaLyDi.Checked = true;
            }
        }
        private void daMatChecked()
        {
            if (chkDaMatThanhVien.Checked)
            {
                lbNgayMatThanhVien.Visible = true;
                dtNgayMatThanhVien.Visible = true;
            }
            else
            {
                lbNgayMatThanhVien.Visible = false;
                dtNgayMatThanhVien.Visible = false;
            }
            if (chkDaMat.Checked)
            {
                lbNgayMat.Visible = true;
                dtNgayMat.Visible = true;
            }
            else
            {
                lbNgayMat.Visible = false;
                dtNgayMat.Visible = false;
            }
        }
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void thôngTinNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm(username);
            accountForm.ShowDialog();
        }
        private void bốMẹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            string hoTen = gridViewDanhSachTV.SelectedRows[0].Cells["HoTen"].Value.ToString();  
            string query = "MATCH(t:ThanhVien)<-[r:QuanHe]-(p:ThanhVien) WHERE (r.MoiQuanHe = 'Cha của' OR r.MoiQuanHe = 'Mẹ của') AND id(t) = "+id+" RETURN p.GioiTinh as GioiTinh, p.HoTen as HoTen, p.NgaySinh as NgaySinh, r.MoiQuanHe as QuanHe";
            OpenRelationshipForm(hoTen,query);
        }
        private void vợChồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            string hoTen = gridViewDanhSachTV.SelectedRows[0].Cells["HoTen"].Value.ToString();
            string gioiTinh = gridViewDanhSachTV.SelectedRows[0].Cells["GioiTinh"].Value.ToString();
            string quanHe = "";
            if (gioiTinh=="Nam")
            {
                quanHe = "Vợ";
            }
            else
            {
                quanHe = "Chồng";
            }
            string query = "MATCH(t:ThanhVien)-[r:QuanHe]->(p:ThanhVien) WHERE r.MoiQuanHe = 'Vợ chồng' AND id(t)="+id+" RETURN p.GioiTinh as GioiTinh, p.HoTen as HoTen, p.NgaySinh as NgaySinh, '"+quanHe+ "' as QuanHe ORDER BY id(p)";
            OpenRelationshipForm(hoTen, query);
        }
        private void conToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            string hoTen = gridViewDanhSachTV.SelectedRows[0].Cells["HoTen"].Value.ToString();
            string query = "MATCH(t:ThanhVien)-[r:QuanHe]->(p:ThanhVien) WHERE (r.MoiQuanHe = 'Cha của' OR r.MoiQuanHe = 'Mẹ của') AND id(t)="+id+" RETURN p.GioiTinh as GioiTinh, p.HoTen as HoTen, p.NgaySinh as NgaySinh, 'Con' as QuanHe ORDER BY id(p)";
            OpenRelationshipForm(hoTen, query);
        }
        private void OpenRelationshipForm(string name,string query)
        {
            RelationshipForm relationshipForm = new RelationshipForm(name,query);
            relationshipForm.ShowDialog();
        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticForm statisticForm = new StatisticForm();
            statisticForm.ShowDialog();
        }
        private void thôngTinDòngHọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinDongHoForm thongTinDongHoForm = new ThongTinDongHoForm();
            thongTinDongHoForm.ShowDialog();
        }
        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }
        private void chkDaMatThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaMatThanhVien.Checked)
            {
                lbNgayMatThanhVien.Visible = true;
                dtNgayMatThanhVien.Visible = true;
            }
            else
            {
                lbNgayMatThanhVien.Visible = false;
                dtNgayMatThanhVien.Visible = false;
            }
        }
        private void cbDaMat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDaMat.Checked)
            {
                lbNgayMat.Visible = true;
                dtNgayMat.Visible = true;
            }
            else
            {
                lbNgayMat.Visible = false;
                dtNgayMat.Visible = false;
            }

        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void saoLưuPhụcHồiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Lưu dữ liệu Neo4j ra file JSON";
            saveFileDialog.FileName = "Dữ Liệu Gia Phả " + DateTime.Now.ToString("yyyy-MM-dd") + ".json"; // Tên file mặc định
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn do người dùng chọn
                string selectedPath = saveFileDialog.FileName;

                // Thực hiện sao lưu với đường dẫn do người dùng cung cấp
                connection.BackupDatabase(selectedPath);
            }
        }
        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string gioiTinh = "";
            string ho = "";
            string ten = "";
            if (boxHoTenTimKiem.Text != "")
            {
                ho = boxHoTenTimKiem.Text.Substring(0, 1).ToUpper();
                ten = boxHoTenTimKiem.Text.Substring(1);
            }
            string hoTen = ho + ten;
            if (rdFemaleTimKiem.Checked)
            {
                gioiTinh = "Nữ";
            }
            else if (rdMaleTimKiem.Checked)
            {
                gioiTinh = "Nam";
            }
            else
            {
                gioiTinh = "";
            }
            string query = "";
            if (gioiTinh != "" && hoTen == "")
            {
                query = "MATCH (tv:ThanhVien{GioiTinh:'" + gioiTinh + "'}) RETURN tv ORDER BY tv.DoiThu ASC";
            }
            else if (gioiTinh == "" && hoTen != "")
            {
                query = "MATCH (tv:ThanhVien) WHERE tv.HoTen CONTAINS '" + hoTen + "' RETURN tv ORDER BY tv.DoiThu ASC";
            }
            else if (gioiTinh != "" && hoTen != "")
            {
                query = "MATCH (tv:ThanhVien) WHERE tv.HoTen CONTAINS '" + hoTen + "' AND tv.GioiTinh = '" + gioiTinh + "' RETURN tv ORDER BY tv.DoiThu ASC"; 
            }
            else
            {
                query = "MATCH (tv:ThanhVien) RETURN tv ORDER BY tv.DoiThu ASC";
            }
            var data = thanhVienController.selectThanhVien(query);
            gridViewDanhSachTV.Rows.Clear();
            if (data != null)
            {
                foreach (var thanhVien in data)
                {
                    string tenCha = "";
                    string tenMe = "";
                    string queryChaMe = "MATCH (t:ThanhVien{HoTen:'" + thanhVien.HoTen + "'})<-[:QuanHe{MoiQuanHe:'Cha của'}]-(p:ThanhVien) WHERE id(t) = "+thanhVien.Id+"  RETURN p";
                    ThanhVien cha = thanhVienController.TruyVan(queryChaMe);
                    if (cha != null)
                    {
                        tenCha = cha.HoTen;
                    }
                    queryChaMe = "MATCH (t:ThanhVien{HoTen:'" + thanhVien.HoTen + "'})<-[:QuanHe{MoiQuanHe:'Mẹ của'}]-(p:ThanhVien) WHERE id(t) = " + thanhVien.Id + " RETURN p";
                    ThanhVien me = thanhVienController.TruyVan(queryChaMe);
                    if (me != null)
                    {
                        tenMe = me.HoTen;
                    }
                    gridViewDanhSachTV.Rows.Add(
                            thanhVien.Id,
                            thanhVien.GioiTinh,
                            thanhVien.DoiThu,
                            thanhVien.HoTen,
                            thanhVien.NgaySinh.ToString("dd-MM-yyyy"),
                            tenCha,
                            tenMe,
                            thanhVien.NgayMat
                    );
                }
            }
        }
        private void gridViewDanhSachTV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                enableTextBoxVoChong(true);
                clearTextBoxThanhVien();
                clearTextBoxVoChong();
                //Thông tin thành viên trong dòng họ
                string hoTen= gridViewDanhSachTV.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                id = int.Parse(gridViewDanhSachTV.Rows[e.RowIndex].Cells["identity"].Value.ToString());
                BoxHoTenThanhVien.Text = hoTen;
                btnThemCha.Enabled= (!thanhVienController.ktrThongTinCha(id)) ? true : false;
                btnThemMe.Enabled = (!thanhVienController.ktrThongTinMe(id)) ? true : false;
                string query = "MATCH (t:ThanhVien{HoTen:'" + hoTen + "'}) WHERE id(t) ="+id+" RETURN t";
                ThanhVien thanhvien = thanhVienController.TruyVan(query);
                string gioiTinh = thanhvien.GioiTinh;
                if (gioiTinh=="Nam")
                {
                    rdNamThanhVien.Checked=true;
                }
                else
                {
                    rdNuThanhVien.Checked = true;
                }
                dtNgaySinhThanhVien.Value = thanhvien.NgaySinh;
                nmConThuThanhVien.Value = (decimal)thanhvien.ConThu;
                BoxTenThuongGoiThanhVien.Text = thanhvien.TenThuongGoi;
                BoxCMNDThanhVien.Text = thanhvien.Cccd_cmnd;
                BoxNoiSinhThanhVien.Text = thanhvien.NoiSinh;
                cbQuocTichThanhVien.SelectedItem = thanhvien.QuocTich;
                cbTonGiaoThanhVien.SelectedItem = thanhvien.TonGiao;
                if (thanhvien.NgayMat!=null)
                {
                    chkDaMatThanhVien.Checked = true;
                    dtNgayMatThanhVien.Value = (DateTime)thanhvien.NgayMat;
                }
                //Thông tin vợ/chồng của thành viên trong dòng họ
                danhSachVoChong = new List<ThanhVien>();
                danhSachVoChong = thanhVienController.TruyVanVoChong(hoTen);
                if (danhSachVoChong.Count>0)
                {
                    currentIndex = 0;
                    HienThiThongTinVoChong(danhSachVoChong[currentIndex],1);
                    if (danhSachVoChong.Count >=2)
                    {
                        btnPrev.Enabled = true;
                        btnNext.Enabled = true;
                    }
                    else
                    {
                        btnPrev.Enabled = false;
                        btnNext.Enabled = false;
                    }
                    btnThemCon.Enabled = true;
                }
                else
                {
                    clearTextBoxVoChong();
                    btnThemCon.Enabled = false;
                }
            }
        }
        private void rdNamThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNamThanhVien.Checked)
            {
                rdbtnNu.Checked = true;
            }
        }
        private void rdNuThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNuThanhVien.Checked)
            {
                rdbtnNam.Checked = true;
            }
        }
        private void btnThemGiaoDucThanhVien_Click(object sender, EventArgs e)
        {
            string hoTen = BoxHoTenThanhVien.Text;
            EducationForm educationForm = new EducationForm(hoTen,id);
            educationForm.ShowDialog();
        }
        private void btnThemNgheNghiepThanhVien_Click(object sender, EventArgs e)
        {
            string hoTen = BoxHoTenThanhVien.Text;
            JobInfoForm jobInfoForm = new JobInfoForm(hoTen,id);
            jobInfoForm.ShowDialog();
        }
        private void btnThemNgheNghiep_Click(object sender, EventArgs e)
        {
            string hoTen = BoxHoVaTen.Text;
            int idVoChong = thanhVienController.layIdThanhVienVoChong(hoTen, id);
            JobInfoForm jobInfoForm = new JobInfoForm(hoTen,idVoChong);
            jobInfoForm.ShowDialog();
        }
        private void btnThemGiaoDuc_Click(object sender, EventArgs e)
        {
            string hoTen = BoxHoVaTen.Text;
            int idVoChong = thanhVienController.layIdThanhVienVoChong(hoTen, id);
            EducationForm educationForm = new EducationForm(hoTen,idVoChong);
            educationForm.ShowDialog();
        }
        private void BoxHoTenThanhVien_TextChanged(object sender, EventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            if (sender==BoxHoTenThanhVien)
            {
                if (BoxHoTenThanhVien.Text == "")
                {
                    btnThemGiaoDucThanhVien.Enabled = false;
                    btnThemNgheNghiepThanhVien.Enabled = false;
                    btnThemCha.Enabled = false;
                    btnThemCon.Enabled = false;
                    btnThemVoChong.Enabled = false;
                }
                if (thanhVienController.ktrThanhVien(BoxHoTenThanhVien.Text, id))
                {
                    btnThemGiaoDucThanhVien.Enabled = true;
                    btnThemNgheNghiepThanhVien.Enabled = true;
                    if (!thanhVienController.ktrThongTinCha(id))
                    {
                        btnThemCha.Enabled = true;
                    }
                    btnThemCon.Enabled = true;
                    btnThemVoChong.Enabled = true;
                }
                else
                {
                    btnThemGiaoDucThanhVien.Enabled = false;
                    btnThemNgheNghiepThanhVien.Enabled = false;
                    btnThemCha.Enabled = false;
                    btnThemCon.Enabled = false;
                    btnThemVoChong.Enabled = false;
                }
            }
            else if(sender==BoxHoVaTen)
            {
                if (BoxHoVaTen.Text == "")
                {
                    btnThemGiaoDuc.Enabled = false;
                    btnThemNgheNghiep.Enabled = false;
                }
                if (thanhVienController.ktrVoChongThanhVien(BoxHoTenThanhVien.Text, BoxHoVaTen.Text))
                {
                    btnThemGiaoDuc.Enabled = true;
                    btnThemNgheNghiep.Enabled = true;
                    btnThemCon.Enabled = true;
                }
                else
                {
                    btnThemGiaoDuc.Enabled = false;
                    btnThemNgheNghiep.Enabled = false;
                    btnThemCon.Enabled = false;
                }
            }     
        }
        private void BoxHoTenThanhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void BoxTenThuongGoiThanhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void BoxCMNDThanhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void BoxNoiSinhThanhVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void BoxHoVaTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void boxTenThuongGoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void BoxCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void boxNoiSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void boxVoChongThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Nếu là ký tự đặc biệt, ngăn không cho nhập
                e.Handled = true;
            }
        }
        private void clearTextBoxThanhVien()
        {
            BoxHoTenThanhVien.Text = string.Empty;
            dtNgaySinhThanhVien.Value = DateTime.Now;
            nmConThuThanhVien.Value = 1;
            rdNamThanhVien.Checked = true;
            BoxTenThuongGoiThanhVien.Text = string.Empty;
            BoxCMNDThanhVien.Text = string.Empty;
            BoxNoiSinhThanhVien.Text = string.Empty;
            cbQuocTichThanhVien.SelectedIndex = 0;
            cbTonGiaoThanhVien.SelectedIndex = 0;
            chkDaMatThanhVien.Checked = false;
            dtNgayMatThanhVien.Value = DateTime.Now;
        }
        private void clearTextBoxVoChong()
        {
            BoxHoVaTen.Text = string.Empty;
            dtNgaySinh.Value = DateTime.Now;
            boxVoChongThu.Text = string.Empty;
            nmConThu.Value = 1;
            boxTenThuongGoi.Text = string.Empty;
            rdbtnDaKetHon.Checked = true;
            BoxCMND.Text = string.Empty;
            boxNoiSinh.Text = string.Empty;
            cbQuocTich.SelectedIndex = 0;
            cbTonGiao.SelectedIndex = 0;
            chkDaMat.Checked = false;
            dtNgayMat.Value = DateTime.Now;
            boxKeTu.Text = string.Empty;
        }
        private void enableTextBoxThanhVien(bool tf)
        {
            BoxHoTenThanhVien.Enabled = tf;
            dtNgaySinhThanhVien.Enabled = tf;
            BoxTenThuongGoiThanhVien.Enabled = tf;
            rdNamThanhVien.Enabled = tf;
            rdNuThanhVien.Enabled = tf;
            nmConThuThanhVien.Enabled = tf;
            BoxCMNDThanhVien.Enabled = tf;
            BoxNoiSinhThanhVien.Enabled = tf;
            cbQuocTichThanhVien.Enabled = tf;
            cbTonGiaoThanhVien.Enabled = tf;
            chkDaMatThanhVien.Enabled = tf;
            dtNgayMatThanhVien.Enabled = tf;
        }
        private void enableTextBoxVoChong(bool tf)
        {
            BoxHoVaTen.Enabled = tf;
            dtNgaySinh.Enabled = tf;
            rdbtnNam.Enabled = tf;
            rdbtnNu.Enabled = tf;
            nmConThu.Enabled = tf;
            boxTenThuongGoi.Enabled = tf;
            BoxCMND.Enabled = tf;
            boxNoiSinh.Enabled = tf;
            cbQuocTich.Enabled = tf;
            cbTonGiao.Enabled = tf;
            chkDaMat.Enabled = tf;
            dtNgayMat.Enabled = tf;
            boxKeTu.Enabled = tf;
            rdbtnDaKetHon.Enabled = tf;
            rdbtnDaLyDi.Enabled = tf;
        }
        private void btnXoaThanhVien_Click(object sender, EventArgs e)
        {
            string hoTen = BoxHoTenThanhVien.Text;
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            if (thanhVienController.ktrThanhVien(hoTen,id))
            {
                DialogResult result= MessageBox.Show(this, "Bạn có chắc muốn xóa thành viên " + hoTen + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result== DialogResult.Yes)
                {
                    if (thanhVienController.xoaThanhVien(hoTen,id))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadData();
                    }
                }
            }
            else
            {
                MessageBox.Show(this,"Thông tin thành viên không có trong hệ thống! Xóa thất bại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnThemCon_Click(object sender, EventArgs e)
        {
            if (rdNamThanhVien.Checked)
            {
                hoTenCha = BoxHoTenThanhVien.Text;
                gioiTinh1 = "Nam";
            }
            else
            {
                hoTenCha = BoxHoVaTen.Text;
                gioiTinh1 = "Nữ";
            }
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            idVoChong = thanhVienController.layIdThanhVienVoChong(BoxHoVaTen.Text, id);
            clearTextBoxThanhVien();
            clearTextBoxVoChong();
            enableTextBoxVoChong(false);
            var name = hoTenCha.Split(' ');
            BoxHoTenThanhVien.Text = name[0];
            themCon = true;
            themVoChong = false;         
        }
        private void btnThemVoChong_Click(object sender, EventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            if (thanhVienController.ktrThanhVien(BoxHoTenThanhVien.Text,id))
            {
                clearTextBoxVoChong();
                enableTextBoxThanhVien(false);
                enableTextBoxVoChong(true);
                themVoChong = true;
                themCon = false;
            }
            else
            {
                MessageBox.Show(this, "Vui lòng chọn thành viên muốn thêm vợ/chồng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (themVoChong)
            {
                if (BoxHoVaTen.Text != "")
                {
                    ThanhVien vochong = new ThanhVien();                    
                    vochong.HoTen = BoxHoVaTen.Text;
                    vochong.GioiTinh = (rdbtnNam.Checked) ? "Nam" : "Nữ";
                    vochong.NgaySinh = dtNgaySinh.Value;
                    vochong.ConThu = (int)nmConThu.Value;
                    vochong.DoiThu = thanhVienController.laySoDoiCuaThanhVien(id);
                    vochong.KeTu = boxKeTu.Value.Year;
                    vochong.TenThuongGoi = boxTenThuongGoi.Text;
                    vochong.NoiSinh = boxNoiSinh.Text;
                    vochong.Cccd_cmnd = BoxCMND.Text;
                    vochong.QuocTich = cbQuocTich.SelectedItem.ToString();
                    vochong.TonGiao = cbTonGiao.SelectedItem.ToString();
                    if (chkDaMat.Checked)
                    {
                        vochong.NgayMat = dtNgayMat.Value;
                    }
                    vochong.QuanHe = (rdbtnDaKetHon.Checked) ? "Đã kết hôn" : "Đã ly dị";
                    if (thanhVienController.themVoChong(vochong, id))
                    {
                        MessageBox.Show(this, "Thêm thông tin vợ chồng thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else {
                        MessageBox.Show(this, "Thêm thông tin vợ chồng thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Ô họ và tên, ô kể từ không được bỏ trông! Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                enableTextBoxThanhVien(true);
                themVoChong = false;
            }
            else if (themCon)
            {
                //Thông tin con
                if (BoxHoTenThanhVien.Text!="")
                {
                    ThanhVien temp = new ThanhVien();
                    temp.HoTen = BoxHoTenThanhVien.Text;
                    temp.GioiTinh = (rdNamThanhVien.Checked) ? "Nam" : "Nữ";
                    temp.NgaySinh = dtNgaySinhThanhVien.Value;
                    temp.DoiThu = thanhVienController.laySoDoiCuaThanhVien(id)+1;
                    temp.ConThu = (int)nmConThuThanhVien.Value;
                    temp.TenThuongGoi = BoxTenThuongGoiThanhVien.Text;
                    temp.NoiSinh = BoxNoiSinhThanhVien.Text;
                    temp.Cccd_cmnd = BoxCMNDThanhVien.Text;
                    temp.QuocTich = cbQuocTichThanhVien.SelectedItem.ToString();
                    temp.TonGiao = cbTonGiaoThanhVien.SelectedItem.ToString();
                    if (chkDaMatThanhVien.Checked)
                    {
                        temp.NgayMat = dtNgayMatThanhVien.Value;
                    }
                    bool result = (gioiTinh1 == "Nam") ? thanhVienController.themCon(temp, id, idVoChong) : thanhVienController.themCon(temp, idVoChong, id);
                    if (result)
                    {
                        MessageBox.Show(this, "Thêm thông tin con thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Thêm thông tin con thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Ô họ và tên không được bỏ trông! Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                enableTextBoxVoChong(true);
                themCon = false;
            }
            else if (themCha)
            {
                ThanhVien ttCha = new ThanhVien();
                
                if (BoxHoTenThanhVien.Text != "")
                {
                    //Thông tin cha                   
                    ttCha.HoTen = BoxHoTenThanhVien.Text;
                    ttCha.GioiTinh = "Nam";
                    ttCha.NgaySinh = dtNgaySinhThanhVien.Value;
                    ttCha.ConThu = (int)nmConThuThanhVien.Value;
                    ttCha.TenThuongGoi = BoxTenThuongGoiThanhVien.Text;
                    ttCha.NoiSinh = BoxNoiSinhThanhVien.Text;
                    if (thanhVienController.laySoDoiCuaThanhVien(id)==1)
                    {
                        thanhVienController.ChinhLaiSoDoi();
                        ttCha.DoiThu = thanhVienController.laySoDoiCuaThanhVien(id);
                    }
                    else
                    {
                        ttCha.DoiThu = thanhVienController.laySoDoiCuaThanhVien(id) - 1;
                    }
                    ttCha.Cccd_cmnd = BoxCMNDThanhVien.Text;
                    ttCha.QuocTich = cbQuocTichThanhVien.SelectedItem.ToString();
                    ttCha.TonGiao = cbTonGiaoThanhVien.SelectedItem.ToString();
                    if (chkDaMatThanhVien.Checked)
                    {
                        ttCha.NgayMat = dtNgayMatThanhVien.Value;
                    }
                    if (thanhVienController.themCha(ttCha,id,ngaySinhCuaCon))
                    {
                        MessageBox.Show(this, "Thêm thông tin cha thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Thêm thông tin cha thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Ô họ và tên của cha không được bỏ trông! Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                enableTextBoxVoChong(true);
                themCha = false;
                
            }
            else if (themMe)
            {
                //Thông tin mẹ
                ThanhVien ttMe = new ThanhVien();
                if (BoxHoTenThanhVien.Text!="")
                {
                    ttMe.HoTen = BoxHoTenThanhVien.Text;
                    rdNuThanhVien.Checked = true;
                    ttMe.GioiTinh = "Nữ";
                    ttMe.NgaySinh = dtNgaySinhThanhVien.Value;
                    ttMe.ConThu = (int)nmConThuThanhVien.Value;
                    ttMe.TenThuongGoi = BoxTenThuongGoiThanhVien.Text;
                    ttMe.NoiSinh = BoxNoiSinhThanhVien.Text;
                    if (thanhVienController.laySoDoiCuaThanhVien(id) == 1)
                    {
                        thanhVienController.ChinhLaiSoDoi();
                    }
                    ttMe.DoiThu = thanhVienController.laySoDoiCuaThanhVien(id) - 1;
                    ttMe.Cccd_cmnd = BoxCMNDThanhVien.Text;
                    ttMe.QuocTich = cbQuocTichThanhVien.SelectedItem.ToString();
                    ttMe.TonGiao = cbTonGiaoThanhVien.SelectedItem.ToString();
                    if (chkDaMatThanhVien.Checked)
                    {
                        ttMe.NgayMat = dtNgayMatThanhVien.Value;
                    }
                    if (thanhVienController.themMe(ttMe, id, ngaySinhCuaCon))
                    {
                        MessageBox.Show(this, "Thêm thông tin mẹ thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Thêm thông tin mẹ thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Ô họ và tên của mẹ không được bỏ trông! Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                enableTextBoxVoChong(true);
                themMe = false;
            }
            else
            {
                if (BoxHoTenThanhVien.Text!="")
                {
                    ThanhVien temp = new ThanhVien();
                    temp.Id=int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
                    temp.HoTen= BoxHoTenThanhVien.Text;
                    if (rdNamThanhVien.Checked)
                    {
                        temp.GioiTinh = "Nam";
                    }
                    else
                    {
                        temp.GioiTinh = "Nữ";
                    }
                    temp.NgaySinh = dtNgaySinhThanhVien.Value;
                    temp.ConThu = (int)nmConThuThanhVien.Value;
                    temp.TenThuongGoi = BoxTenThuongGoiThanhVien.Text;
                    temp.NoiSinh = BoxNoiSinhThanhVien.Text;
                    temp.Cccd_cmnd = BoxCMNDThanhVien.Text;
                    temp.QuocTich = cbQuocTichThanhVien.SelectedItem.ToString();
                    temp.TonGiao = cbTonGiaoThanhVien.SelectedItem.ToString();
                    if (chkDaMatThanhVien.Checked)
                    {
                        temp.NgayMat = dtNgayMatThanhVien.Value;
                    }
                    if (BoxHoVaTen.Text!="")
                    {
                        idVoChong = thanhVienController.layIdThanhVienVoChong(BoxHoVaTen.Text, id);
                        ThanhVien vochong = new ThanhVien();
                        vochong.Id = idVoChong;
                        vochong.HoTen = BoxHoVaTen.Text;
                        vochong.GioiTinh = (rdbtnNam.Checked) ? "Nam" : "Nữ";
                        vochong.NgaySinh = dtNgaySinh.Value;
                        vochong.ConThu = (int)nmConThu.Value;
                        vochong.DoiThu = thanhVienController.laySoDoiCuaThanhVien(id);
                        vochong.KeTu = boxKeTu.Value.Year;
                        vochong.TenThuongGoi = boxTenThuongGoi.Text;
                        vochong.NoiSinh = boxNoiSinh.Text;
                        vochong.Cccd_cmnd = BoxCMND.Text;
                        vochong.QuocTich = cbQuocTich.SelectedItem.ToString();
                        vochong.TonGiao = cbTonGiao.SelectedItem.ToString();
                        if (chkDaMat.Checked)
                        {
                            vochong.NgayMat = dtNgayMat.Value;
                        }
                        vochong.QuanHe = (rdbtnDaKetHon.Checked) ? "Đã kết hôn" : "Đã ly dị";
                        if (thanhVienController.chinhSuaThongTinThanhVien(temp) && thanhVienController.chinhSuaThongTinThanhVien(vochong) && thanhVienController.chinhSuaThongTinVoChong(vochong, id))
                        {
                            MessageBox.Show(this, "Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show(this, "Chỉnh sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (thanhVienController.chinhSuaThongTinThanhVien(temp))
                    {
                        MessageBox.Show(this, "Chỉnh sửa thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show(this, "Chỉnh sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Ô họ và tên không được bỏ trông! Chỉnh sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnThemCha_Click(object sender, EventArgs e)
        {
            ngaySinhCuaCon = dtNgaySinhThanhVien.Value;
            clearTextBoxThanhVien();
            clearTextBoxVoChong();
            enableTextBoxVoChong(false);
            themCha = true;
            themCon = false;
            rdNamThanhVien.Checked = true;
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());            
            themVoChong = false;
        }
        private void btnThemMe_Click(object sender, EventArgs e)
        {
            ngaySinhCuaCon = dtNgaySinhThanhVien.Value;
            clearTextBoxThanhVien();
            clearTextBoxVoChong();
            enableTextBoxVoChong(false);
            themMe = true;
            themCha = false;
            themCon = false;
            rdNuThanhVien.Checked = true;
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());            
            themVoChong = false;
        }
        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            themMe = false;
            themCha = false;
            themCon = false;
            themVoChong = false;
            enableTextBoxThanhVien(true);
            enableTextBoxVoChong(true);
            clearTextBoxThanhVien();
            clearTextBoxVoChong();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (danhSachVoChong.Count > 0)
            {
                currentIndex--;
                if (currentIndex <0)
                {
                    currentIndex = danhSachVoChong.Count-1;
                }
                HienThiThongTinVoChong(danhSachVoChong[currentIndex],currentIndex+1);
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (danhSachVoChong.Count > 0)
            {
                currentIndex++;
                if (currentIndex >= danhSachVoChong.Count)
                {
                    currentIndex = 0;
                }
                HienThiThongTinVoChong(danhSachVoChong[currentIndex], currentIndex + 1);
            }
        }
        private void gridViewDanhSachTV_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Lấy vị trí của chuột trên DataGridView
                var hitTestInfo = gridViewDanhSachTV.HitTest(e.X, e.Y);

                // Kiểm tra nếu chuột được click vào một dòng hợp lệ
                if (hitTestInfo.RowIndex >= 0)
                {
                    // Chọn hàng tại vị trí chuột
                    gridViewDanhSachTV.ClearSelection();
                    gridViewDanhSachTV.Rows[hitTestInfo.RowIndex].Selected = true;

                    // Hiển thị ContextMenuStrip tại vị trí chuột
                    contextMenuStrip.Show(gridViewDanhSachTV, e.Location);
                }
            }
        }
        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.SelectedRows[0].Cells["identity"].Value.ToString());
            string hoTen = gridViewDanhSachTV.SelectedRows[0].Cells["HoTen"].Value.ToString();
            if (e.ClickedItem==DatLamToPhu)
            {
                DialogResult result = MessageBox.Show(this, "Bạn có chắc muốn đặt thành viên " + hoTen + " làm tổ phụ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    thanhVienController.DatLamToPhu(id);
                }
            }
            if (e.ClickedItem==XoaThanhVien)
            {
                DialogResult result = MessageBox.Show(this, "Bạn có chắc muốn xóa thành viên " + hoTen + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                   if (thanhVienController.xoaThanhVien(hoTen,id))
                   {
                      MessageBox.Show("Xóa thành công");
                      LoadData();
                   }
                }
            }
            if (e.ClickedItem==DatLamTruongHo)
            {
                DialogResult result = MessageBox.Show(this, "Bạn có chắc muốn đặt thành viên " + hoTen + " làm trưởng họ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    thanhVienController.DatLamTruongHo(id);
                }
            }
            if (e.ClickedItem==XoaTruongHo)
            {
                DialogResult result = MessageBox.Show(this, "Bạn có chắc muốn xóa thành viên " + hoTen + " khỏi danh sách trưởng họ không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    thanhVienController.XoaTruongHo(id);
                }
            }
        }
        private void gridViewDanhSachTV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            id = int.Parse(gridViewDanhSachTV.Rows[e.RowIndex].Cells["identity"].Value.ToString());
            if (gridViewDanhSachTV.Rows[e.RowIndex].Cells["NgayMat"].Value!=null)
            {
                gridViewDanhSachTV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
            }
            if (gridViewDanhSachTV.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString()=="Nữ")
            {
                DatLamToPhu.Enabled = false;
                DatLamTruongHo.Enabled = false;
                DatLamTruongHo.Visible = true;
                XoaTruongHo.Visible = false;
            }
            else
            {
                DatLamTruongHo.Enabled = true;
                if (thanhVienController.KtrToPhu(id))
                {
                    DatLamToPhu.Enabled = false;
                }
                else
                {
                    DatLamToPhu.Enabled = true;
                }
                if (thanhVienController.KtrTruongHo(id))
                {
                    XoaTruongHo.Visible = true;
                    DatLamTruongHo.Visible = false;
                }
                else
                {
                    XoaTruongHo.Visible = false;
                    DatLamTruongHo.Visible = true;
                }
                
            }
        }
    }
}

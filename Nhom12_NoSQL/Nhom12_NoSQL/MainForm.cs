using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom12_NoSQL
{
    public partial class MainForm : Form
    {
        private string username;

        public string Username { get => username; set => username = value; }
        public MainForm(string username)
        {
            InitializeComponent();
            this.username = username;
            
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MaximizeBox = false;
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationForm informationForm = new InformationForm("Cập nhật thông tin thành viên");
            informationForm.ShowDialog();
        }

        private void bốMẹToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRelationshipForm("Đặng Hoàng Phúc");
        }

        private void vợChồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRelationshipForm("");
        }

        private void conToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenRelationshipForm("");
        }

        private void OpenRelationshipForm(string name)
        {
            RelationshipForm relationshipForm = new RelationshipForm(name);
            relationshipForm.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticForm statisticForm = new StatisticForm();
            statisticForm.ShowDialog();
        }

        private void thêmThànhViênMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InformationForm informationForm = new InformationForm("Thêm thông tin thành viên");
            informationForm.ShowDialog();
        }

        private void thôngTinDòngHọToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            AccountForm accountForm = new AccountForm(username);
            accountForm.ShowDialog();
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            InformationForm informationForm = new InformationForm("Cập nhật thông tin thành viên");
            informationForm.ShowDialog();
        }

        private void btnThemThanhVien_Click(object sender, EventArgs e)
        {
            InformationForm informationForm = new InformationForm("Thêm thông tin thành viên");
            informationForm.ShowDialog();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neo4j.Driver;
using Nhom12_NoSQL.Controller;

namespace Nhom12_NoSQL
{
    public partial class LoginForm : Form
    {
        private AccountController accountController;
        private ThanhVienController thanhVienController;
        public LoginForm()
        {
            InitializeComponent();
            accessError.Text = "";
            MaximizeBox = false;
            accountController = new AccountController();
            thanhVienController = new ThanhVienController();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = taiKhoanBox.Text.ToString();
            string pass = matKhauBox.Text.ToString();
            bool result=accountController.AccessVerification(username, pass);
            if (result)
            {
                string query = "MATCH (t:ThanhVien) RETURN count(t)";
                int soLuong=thanhVienController.layTongSoThanhVien(query);
                if (soLuong==0)
                {
                    BeginningForm beginningForm = new BeginningForm(username);
                    beginningForm.Show();
                    this.Hide();
                }
                else
                {
                    MainForm main = new MainForm(username);
                    main.Show();
                    this.Hide();
                }
                
            }
            else
            {
                accessError.Text = "Tài khoản hoặc mật khẩu không đúng";
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using Nhom12_NoSQL.Controller;
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
    public partial class AccountForm : Form
    {
        private AccountController accountController;
        private string username;

        public string Username { get => username; set => username = value; }

        public AccountForm(string username)
        {
            InitializeComponent();
            this.username = username;
            this.accountController = new AccountController();
            MaximizeBox = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {
            txtAccountName.Text = username;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string accountName = txtAccountName.Text;
            string oldPass = txtCurrentPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;
            if (newPass.Equals(confirmPass))
            {
                DialogResult result= MessageBox.Show("Mật khẩu sẽ được đổi, bạn có chắc chắn không ?", "Hệ thống thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    accountController.UpdateAccountPassword(accountName, oldPass, newPass);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng với mật khẩu mới","Hệ thống cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}

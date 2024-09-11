using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nhom12_NoSQL.Controller
{
    class AccountController
    {
        private NoSQL_Connection connection;

        public NoSQL_Connection Connection { get => connection; set => connection = value; }

        public AccountController()
        {
            this.connection = new NoSQL_Connection();
        }        

        public bool AccessVerification(string username,string password)
        {
            string query = "Match(a:Account) Where a.username='" + username + "' And a.password='" + password + "' return a";
            string result=connection.Select(query);
            if (result==null)
            {
                return false;
            }
            return true;
        }
        public bool UpdateAccountPassword(string username,string oldPassword,string newPassword)
        {
            string query = "Match(a:Account{username:'"+username+"',password:'"+oldPassword+"'}) Set a.password='"+ newPassword +"' return a";
            return connection.Update(query);
        }
    }
}

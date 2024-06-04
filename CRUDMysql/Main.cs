using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDMysql
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            DBUser db = new DBUser();
            //ilaina nanaovana ajout admin ity manaraka ity
            /*User user = new User()
            {
                Fullname = "Tholde",
                Username = "tholde",
                Password = db.passwordEncryption("tholde123"),
            };
            db.InsertUser(user);*/
            Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Election election = new Election();
            election.ShowDialog();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

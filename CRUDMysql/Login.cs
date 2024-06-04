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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            /*Environment.Exit(0);*/
            Main main = new Main();
            main.ShowDialog();
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
            passwordTextBox.PasswordChar = '*';
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = "";
        }

        private void clearAllBtn_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }

        private void connexionBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            DBUser dBUser = new DBUser();
            string password = dBUser.passwordEncryption(passwordTextBox.Text);
            User user = dBUser.GetUserInfo(username);
            if (user != null)
            {
                if(user.Password == password)
                {
                    Hide();
                    Home home = new Home(user);
                    home.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Password no much.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

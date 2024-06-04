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
    public partial class Election : Form
    {
        public Election()
        {
            InitializeComponent();
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            /*Environment.Exit(0);*/
            Main main = new Main();
            main.ShowDialog();
        }

        private void loginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string cin = usernameTextBox.Text.Trim();
            string adresse = passwordTextBox.Text.Trim();
            DBUser dBUser = new DBUser();
            Elector elector = dBUser.GetElectorInfo(cin);
            //MessageBox.Show("Button clicked");
            if (nameTextBox.Text.Trim().Length < 3 || usernameTextBox.Text.Trim().Length < 12)
            {
                MessageBox.Show("Fullname are empty or ( >3 ).");
                return;
            }
            if (usernameTextBox.Text.Trim().Length < 12)
            {
                MessageBox.Show("CIN are empty or ( >12 ).");
                return;
            }
            if (passwordTextBox.Text.Trim().Length < 3)
            {
                MessageBox.Show("Adresse are empty or ( >3 character ).");
                return;
            }

            if(elector == null)
            {
                Elector elec = new Elector
                {
                    Fullname = nameTextBox.Text,
                    Cin = usernameTextBox.Text,
                    Address = passwordTextBox.Text,
                };
                bool success = dBUser.InsertElector(elec);
                if (success)
                {
                    MessageBox.Show($"Welcome {name}.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                    Choice choice = new Choice(cin);
                    choice.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Registration no much.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("CIN already exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nameTextBox_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
        }

        private void usernameTextBox_Click(object sender, EventArgs e)
        {
            usernameTextBox.Text = "";
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
        }

        

        private void clearBtn_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            usernameTextBox.Text = "";
            passwordTextBox.Text = "";
        }
    }
}

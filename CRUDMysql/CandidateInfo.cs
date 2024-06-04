using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDMysql
{
    public partial class CandidateInfo : Form
    {
        public CandidateInfo()
        {
            InitializeComponent();
        }
        public CandidateInfo(string idElec, Candidate candidate)
        {
            InitializeComponent();
            nomTextBox.Text = candidate.Nom;
            prenomTextBox.Text = candidate.Prenom;
            politikTextBox.Text = candidate.PartiPolitique;
            MemoryStream ms = new MemoryStream(candidate.Pdp);
            pdpBox.Image = Image.FromStream(ms);
            numLabel.Text = Convert.ToString(candidate.NumeroElection);
            elecNum.Text = idElec;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            DBUser database = new DBUser();
            int elec = Convert.ToInt32(elecNum.Text);
            string cand = numLabel.Text;
            Candidate candidate = database.GetVatoCandidateInfo(cand);
            int vato = candidate.Vato + 1;
            try
            {
                database.InsertChoose(cand, elec);
                database.SaveVatoCandidateToDatabase(candidate.Id,vato);
                Hide();
                Election election = new Election();
                election.ShowDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Choice choice = new Choice();
            choice.ShowDialog();
        }
    }
}

using MySqlConnector;
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
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }
        public Choice(string cin)
        {
            InitializeComponent();
            FillDataGridView();
            DBUser db = new DBUser();
            Elector elector = db.GetElectorInfo(cin);
            usernameLabel.Text = elector.Fullname;
            idElectorLabel.Text = Convert.ToString(elector.Id);
        }
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Election election = new Election();
            election.ShowDialog();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; initial catalog='user';username=root;password=");
        public void FillDataGridView()
        {
            MySqlCommand command = new MySqlCommand("SELECT num, pdp, nom, prenom, parti_politique FROM candidate", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.Columns[0].ColumnName = "Numero";
            table.Columns[1].ColumnName = "Image";
            table.Columns[2].ColumnName = "Nom";
            table.Columns[3].ColumnName = "Prenom";
            table.Columns[4].ColumnName = "Parti Politique";
            /*Console.WriteLine(table.Columns[0].ColumnName);*/
            dataGridView.RowTemplate.Height = 80;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.DataSource = table;
            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            imgcol = (DataGridViewImageColumn)dataGridView.Columns[1];
            imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Candidate candidate = new Candidate();
            candidate.NumeroElection = (string)dataGridView.CurrentRow.Cells[0].Value;
            candidate.Pdp = (byte[])dataGridView.CurrentRow.Cells[1].Value;
            candidate.Nom = (string)dataGridView.CurrentRow.Cells[2].Value;
            candidate.Prenom = (string)dataGridView.CurrentRow.Cells[3].Value;
            candidate.PartiPolitique = (string)dataGridView.CurrentRow.Cells[4].Value;
            string idElector = idElectorLabel.Text;
            Hide();
            CandidateInfo info = new CandidateInfo(idElector,candidate);
            info.ShowDialog();
        }

        private void Choice_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }
    }
}

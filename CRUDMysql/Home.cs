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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            FillDataGridView();
        }
        public Home(User user)
        {
            InitializeComponent();
            FillDataGridView();
        }

        private void InitializeComponent()
        {
            this.logoutBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.newBtn = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.logoutBtn.Location = new System.Drawing.Point(1136, 680);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(144, 39);
            this.logoutBtn.TabIndex = 17;
            this.logoutBtn.Text = "logout";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exitBtn);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 198);
            this.panel1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(40, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Candidate Information";
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Image = global::CRUDMysql.Properties.Resources.exit;
            this.exitBtn.Location = new System.Drawing.Point(1240, 3);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(37, 36);
            this.exitBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitBtn.TabIndex = 1;
            this.exitBtn.TabStop = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(859, 237);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 32);
            this.textBox1.TabIndex = 22;
            this.textBox1.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.dataGridView);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.newBtn);
            this.panel2.Controls.Add(this.searchTextBox);
            this.panel2.Location = new System.Drawing.Point(45, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1182, 465);
            this.panel2.TabIndex = 20;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(15, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(1153, 391);
            this.dataGridView.TabIndex = 24;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CRUDMysql.Properties.Resources.Search;
            this.pictureBox1.Location = new System.Drawing.Point(1047, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // newBtn
            // 
            this.newBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            this.newBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newBtn.ForeColor = System.Drawing.Color.AliceBlue;
            this.newBtn.Location = new System.Drawing.Point(15, 15);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(121, 39);
            this.newBtn.TabIndex = 21;
            this.newBtn.Text = "new";
            this.newBtn.UseVisualStyleBackColor = false;
            this.newBtn.Click += new System.EventHandler(this.newBtn_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox.Location = new System.Drawing.Point(814, 22);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(237, 32);
            this.searchTextBox.TabIndex = 22;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(472, 696);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(244, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Copyright © 2024 Tholde Rftn . All rights reserved.";
            // 
            // Home
            // 
            this.BackgroundImage = global::CRUDMysql.Properties.Resources.brush;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            AddCandidate addStudent = new AddCandidate();
            addStudent.ShowDialog();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost; port=3306; initial catalog='user';username=root;password=");
        private void Home_Load(object sender, EventArgs e)
        {
            /*FillDataGridView();*/
        }
        public void FillDataGridView()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM candidate", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.Columns[0].ColumnName = "Id";
            table.Columns[1].ColumnName = "Numero";
            table.Columns[2].ColumnName = "Image";
            table.Columns[3].ColumnName = "Nom";
            table.Columns[4].ColumnName = "Prenom";
            table.Columns[5].ColumnName = "Adresse";
            table.Columns[6].ColumnName = "Telephone";
            table.Columns[7].ColumnName = "Numero CIN";
            table.Columns[8].ColumnName = "Parti Politique";
            table.Columns[9].ColumnName = "Date d'enregistrement";
            table.Columns[10].ColumnName = "Date de modification";
            /*Console.WriteLine(table.Columns[0].ColumnName);*/
            dataGridView.RowTemplate.Height = 80;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.DataSource = table;
            DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
            imgcol = (DataGridViewImageColumn)dataGridView.Columns[2];
            imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Candidate candidate = new Candidate();
            candidate.Id = (int)dataGridView.CurrentRow.Cells[0].Value;
            candidate.NumeroElection = (string)dataGridView.CurrentRow.Cells[1].Value;
            candidate.Pdp = (byte[])dataGridView.CurrentRow.Cells[2].Value;
            candidate.Nom = (string)dataGridView.CurrentRow.Cells[3].Value;
            candidate.Prenom = (string)dataGridView.CurrentRow.Cells[4].Value;
            candidate.Adresse = (string)dataGridView.CurrentRow.Cells[5].Value;
            candidate.Tel = (string)dataGridView.CurrentRow.Cells[6].Value;
            candidate.Cin = (string)dataGridView.CurrentRow.Cells[7].Value;
            candidate.PartiPolitique = (string)dataGridView.CurrentRow.Cells[8].Value;
            Hide();
            AddCandidate addCandidate = new AddCandidate(candidate);
            addCandidate.ShowDialog();
        }
        

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text;
            DBUser db = new DBUser();

            try
            {
                DataTable dt = db.SearchCandidate(searchText);
                dt.Columns[0].ColumnName = "Id";
                dt.Columns[1].ColumnName = "Numero";
                dt.Columns[2].ColumnName = "Image";
                dt.Columns[3].ColumnName = "Nom";
                dt.Columns[4].ColumnName = "Prenom";
                dt.Columns[5].ColumnName = "Adresse";
                dt.Columns[6].ColumnName = "Telephone";
                dt.Columns[7].ColumnName = "Numero CIN";
                dt.Columns[8].ColumnName = "Parti Politique";
                dt.Columns[9].ColumnName = "Date d'enregistrement";
                dt.Columns[10].ColumnName = "Date de modification";
                dataGridView.RowTemplate.Height = 80;
                dataGridView.DataSource = dt;
                DataGridViewImageColumn imgcol = new DataGridViewImageColumn();
                imgcol = (DataGridViewImageColumn)dataGridView.Columns[2];
                imgcol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
            }
        }
    }
}

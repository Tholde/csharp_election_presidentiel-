using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CRUDMysql
{
    public partial class AddCandidate : Form
    {
        public AddCandidate()
        {
            InitializeComponent();
        }
        public AddCandidate(Candidate candidate)
        {
            InitializeComponent();
            nomTextBox.Text = candidate.Nom;
            prenomTextBox.Text = candidate.Prenom;
            addressTextBox.Text = candidate.Adresse;
            cinTextBox.Text = candidate.Cin;
            telTextBox.Text = candidate.Tel;
            politikTextBox.Text = candidate.PartiPolitique;
            MemoryStream ms = new MemoryStream(candidate.Pdp);
            pdpBox.Image = Image.FromStream(ms);
            numLabel.Text = Convert.ToString(candidate.Id);
            addLabel.Text = "Updated Candidate";
            addBtn.Text = "update";
            deleteBtn.Enabled = true;

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            nomTextBox.Clear();
            prenomTextBox.Clear();
            addressTextBox.Clear();
            cinTextBox.Clear();
            telTextBox.Clear();
            politikTextBox.Clear();
        }

        private void browserBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pdpBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private byte[] ResizeImageAndConvertToByteArray(Image image, int targetWidth, int targetHeight)
        {
            // Redimensionner l'image à la taille cible
            Image resizedImage = new Bitmap(targetWidth, targetHeight);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, targetWidth, targetHeight);
            }

            // Convertir l'image redimensionnée en tableau d'octets
            using (MemoryStream ms = new MemoryStream())
            {
                resizedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            DBUser database = new DBUser();
            if (addBtn.Text == "save")
            {
                Image image = pdpBox.Image;
                int targetWidth = 800;  // Choisissez une largeur appropriée
                int targetHeight = 600; // Choisissez une hauteur appropriée
                // Redimensionner l'image et la convertir en tableau d'octets
                byte[] imageData = ResizeImageAndConvertToByteArray(image, targetWidth, targetHeight);

                int candidateNumberLength = 2;
                Random random = new Random();

                int randomNumber = random.Next(1, (int)Math.Pow(10, candidateNumberLength));
                string candidateNumber = randomNumber.ToString($"D{candidateNumberLength}");


                Candidate candidate = new Candidate
                {
                    NumeroElection = candidateNumber,
                    Pdp = imageData,
                    Nom = nomTextBox.Text,
                    Prenom = prenomTextBox.Text,
                    Adresse = addressTextBox.Text,
                    Tel = telTextBox.Text,
                    Cin = cinTextBox.Text,
                    PartiPolitique = politikTextBox.Text,
                    Vato = 0
                };
                try
                {
                    database.SaveCandidateToDatabase(candidate);
                    Hide();
                    Home home = new Home();
                    home.ShowDialog();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                }
            }
            else
            {
                Image image = pdpBox.Image;
                int targetWidth = 800;  // Choisissez une largeur appropriée
                int targetHeight = 600; // Choisissez une hauteur appropriée
                // Redimensionner l'image et la convertir en tableau d'octets
                byte[] imageData = ResizeImageAndConvertToByteArray(image, targetWidth, targetHeight);

                Candidate candidate = new Candidate
                {
                    Id = Convert.ToInt32(numLabel.Text),
                    Pdp = imageData,
                    Nom = nomTextBox.Text,
                    Prenom = prenomTextBox.Text,
                    Adresse = addressTextBox.Text,
                    Tel = telTextBox.Text,
                    Cin = cinTextBox.Text,
                    PartiPolitique = politikTextBox.Text
                };
                try
                {
                    database.UpdateCandidateToDatabase(candidate);
                    Hide();
                    Home home = new Home();
                    home.ShowDialog();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data: " + ex.Message);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DBUser database = new DBUser();
            int id = Convert.ToInt32(numLabel.Text);
            if (id != -1)
            {
                DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete this data?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    database.DeleteCandidate(id);
                    Hide();
                    Home home = new Home();
                    home.Show();
                }
            }
            else
            {
                MessageBox.Show("Candidate not found");
            }
        }
    }
}

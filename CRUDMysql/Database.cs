using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CRUDMysql
{
    public class DBUser
    {
        private string sql = "datasource=localhost;port=3306;username=root;password=;database=user";
        //function mi-crypter mot de pass
        public string passwordEncryption(string password)
        {
            //avadika byte en base de 16(hexamal) ilay password ary stocker-na anaty tableau byte
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = SHA256.Create(); //mi-calcul zay donnee entrer ho amin'ny sha256 hachage

            byte[] hashBytes = sha256.ComputeHash(passwordBytes); //mi-calcul ny valeur hachage amin'ilay tableau byte
            string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
            //raisina anty string amin'izay ilay izy ary afficher-na sous forme hexadecimal

            return hashString;
        }
        public User GetUserInfo(string username)
        {
            User user = null;
            using (MySqlConnection connection = new MySqlConnection(sql))
            {
                connection.Open();

                string sql = "SELECT * FROM admin WHERE username = @username";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@username", username);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        user = new User
                        {
                            Id = reader.GetInt32(0),
                            Fullname = reader.GetString(1),
                            Username = reader.GetString(2),
                            Password = reader.GetString(3)
                        };
                    }
                }
            }

            return user;
        }
        public Elector GetElectorInfo(string cin)
        {
            Elector elector = null;
            using (MySqlConnection connection = new MySqlConnection(sql))
            {
                connection.Open();

                string sql = "SELECT * FROM member WHERE cin = @cin";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@cin", cin);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        elector = new Elector
                        {
                            Id = reader.GetInt32(0),
                            Fullname = reader.GetString(1),
                            Cin = reader.GetString(2),
                            Address = reader.GetString(3),
                            CreatedDate = reader.GetDateTime(4),
                            UpdatedDate = reader.GetDateTime(5)
                        };
                    }
                }
            }

            return elector;
        }
        public Candidate GetVatoCandidateInfo(string num)
        {
            Candidate candidate = null;
            using (MySqlConnection connection = new MySqlConnection(sql))
            {
                connection.Open();

                string sql = "SELECT id, num, nom, vato FROM candidate WHERE num = @num";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@num", num);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        candidate = new Candidate
                        {
                            Id = reader.GetInt32(0),
                            NumeroElection = reader.GetString(1),
                            Nom = reader.GetString(2),
                            Vato = reader.GetInt32(3)
                        };
                    }
                }
            }

            return candidate;
        }
        public bool InsertUser(User user)
        {
            bool success = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(sql))
                {
                    connection.Open();

                    string sql = "INSERT INTO admin (fullname, username, password) VALUES (@fullname,@username, @password)";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@fullname", user.Fullname);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    /*command.Parameters.AddWithValue("@password", HashPassword(user.Password));*/

                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration no much.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }
        public void SaveCandidateToDatabase(Candidate candidate)
        {

            if (candidate == null)
            {
                throw new ArgumentNullException("Candidate cannot be null or empty.");
            }
            using (var connection = new MySqlConnection(sql))
            {
                connection.Open();

                string query = "INSERT INTO candidate (num, pdp, nom, prenom, adresse, tel, cin, parti_politique, vato) VALUES (@num, @image, @name, @prenm, @addresse, @phone, @cinum, @partiPolitik, @vato)";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@num", candidate.NumeroElection);
                command.Parameters.AddWithValue("@image", candidate.Pdp);
                command.Parameters.AddWithValue("@name", candidate.Nom);
                command.Parameters.AddWithValue("@prenm", candidate.Prenom);
                command.Parameters.AddWithValue("@addresse", candidate.Adresse);
                command.Parameters.AddWithValue("@phone", candidate.Tel);
                command.Parameters.AddWithValue("@cinum", candidate.Cin);
                command.Parameters.AddWithValue("@partiPolitik", candidate.PartiPolitique);
                command.Parameters.AddWithValue("@vato", candidate.Vato);

                command.ExecuteNonQuery();

            }
        }
        public void SaveVatoCandidateToDatabase(int id, int vato)
        {
            using (var connection = new MySqlConnection(sql))
            {
                connection.Open();

                string query = "UPDATE candidate  SET vato=@vato WHERE id=@id";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@vato", vato);

                command.ExecuteNonQuery();

            }
        }
        public bool InsertElector(Elector elector)
        {
            bool success = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(sql))
                {
                    connection.Open();

                    string sql = "INSERT INTO member (name, cin, adresse) VALUES (@fullname,@cin, @adresse)";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@fullname", elector.Fullname);
                    command.Parameters.AddWithValue("@cin", elector.Cin);
                    command.Parameters.AddWithValue("@adresse", elector.Address);

                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration no much.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }
        public bool InsertChoose(string idCand, int idMbr)
        {
            bool success = false;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(sql))
                {
                    connection.Open();

                    string sql = "INSERT INTO result (candidateNumber, idMember) VALUES (@idCandidate, @idMember)";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@idCandidate", idCand);
                    command.Parameters.AddWithValue("@idMember", idMbr);

                    int rowsAffected = command.ExecuteNonQuery();
                    success = rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration no much.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return success;
        }
        public void UpdateCandidateToDatabase(Candidate candidate)
        {

            if (candidate == null)
            {
                throw new ArgumentNullException("Candidate cannot be null or empty.");
            }
            using (var connection = new MySqlConnection(sql))
            {
                connection.Open();

                string query = "UPDATE candidate  SET pdp=@image, nom=@name, prenom=@prenm, adresse=@addresse, tel=@phone, cin=@cinum, parti_politique=@partiPolitik WHERE id=@id";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", candidate.Id);
                command.Parameters.AddWithValue("@image", candidate.Pdp);
                command.Parameters.AddWithValue("@name", candidate.Nom);
                command.Parameters.AddWithValue("@prenm", candidate.Prenom);
                command.Parameters.AddWithValue("@addresse", candidate.Adresse);
                command.Parameters.AddWithValue("@phone", candidate.Tel);
                command.Parameters.AddWithValue("@cinum", candidate.Cin);
                command.Parameters.AddWithValue("@partiPolitik", candidate.PartiPolitique);

                command.ExecuteNonQuery();

            }
        }
        public void DeleteCandidate(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException("Candidate not found.");
            }
            using (var connection = new MySqlConnection(sql))
            {
                connection.Open();

                string query = "DELETE FROM candidate WHERE id=@id";
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

            }
        }
        public DataTable SearchCandidate(string Text)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (var conn = new MySqlConnection(sql))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    string query = "SELECT * FROM candidate where nom like '%" + Text + "%' or prenom like '%" + Text + "%' or adresse like '%" + Text + "%' or parti_politique like '%" + Text + "%'";
                    MySqlCommand command = new MySqlCommand(query, conn);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    return dataTable;
                }
            }
            catch (MySqlException ex)
            {
                return null;
            }

        }
    }
}

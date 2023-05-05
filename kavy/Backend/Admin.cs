using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using kavy.Backend.Models;

namespace kavy {
    class Admin {
        public Admin() {}

        public void Create(string nom) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO admin(nom, password) VALUES(@Nom, SHA2('kavyAdmin', 256))";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom", nom);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public List<AdminModel> Find(int adminId = 0) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT id, nom, created_at FROM admin";
            if(adminId > 0) query += " WHERE id = @AdminId";
            List<AdminModel> results = new List<AdminModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if(adminId > 0) command.Parameters.AddWithValue("@AdminId", adminId);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new AdminModel
                    {
                        id = reader.GetInt16("id"),
                        nom = reader.GetString("nom"),
                        createdAt = reader.GetDateTime("created_at")
                    };
                    results.Add(data);
                }
                reader.Close();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }

            return results;
        }

        public void Update(string nom, int adminId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE admin SET nom = @Nom WHERE id = @AdminId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@AdminId", adminId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void UpdatePassword(string password, int adminId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE admin SET password = SHA2(@Password, 256) WHERE id = @AdminId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@AdminId", adminId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void Delete(int adminId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM admin WHERE id = @AdminId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@AdminId", adminId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }
    }
}
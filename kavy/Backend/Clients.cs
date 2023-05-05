using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using kavy.Backend.Models;
using System.Windows.Media;

namespace kavy {
    class Clients {
        public Clients() {}

        public void Create(string nom) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO clients(nom, password) VALUES(@Nom, SHA2('kavy', 256))";

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

        public List<ClientModel> Find(int clientId = 0) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT id, nom, created_at FROM clients";
            if(clientId > 0) query += " WHERE id = @ClientId";
            List<ClientModel> results = new List<ClientModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if(clientId > 0) command.Parameters.AddWithValue("@ClientId", clientId);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new ClientModel {
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

        public void Update(string nom, int clientId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE clients SET nom = @Nom WHERE id = @ClientId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@ClientId", clientId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void UpdatePassword(string password, int clientId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE clients SET password = SHA2(@Password, 256) WHERE id = @ClientId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@ClientId", clientId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void Delete(int clientId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM clients WHERE id = @ClientId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);
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
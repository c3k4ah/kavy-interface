using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using kavy.Backend.Models;

namespace kavy {
    class Listes {
        public Listes() {}

        public void Create(string nom) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO listes(nom) VALUES(@Nom)";

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

        public List<ListeModel> Find(int listeId = 0) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT nom FROM listes";
            if(listeId > 0) query += " WHERE id = @ListeId";
            List<ListeModel> results = new List<ListeModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if(listeId > 0) command.Parameters.AddWithValue("@ListeId", listeId);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new ListeModel {
                        id = reader.GetInt16("id"),
                        nom = reader.GetString("nom")
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

        public void Update(string nom, int listeId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE listes SET nom = @Nom WHERE id = @ListeId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", listeId);
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

        public void Delete(int listeId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM listes WHERE id = @ListeId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", listeId);
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
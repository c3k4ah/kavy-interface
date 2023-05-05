using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using kavy.Backend.Models;

namespace kavy {
    class Abonnements {
        public Abonnements() {}

        public void Create(int clientId, int listeId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO abonnements(client_id, liste_id) VALUES(@ClientId, @ListeId)";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);
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

        public List<AbonnementModel> Find() {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT a.id as id, a.client_id as client_id, c.nom as nom_client, " +
                "a.liste_id as liste_id, l.nom as nom_liste, a.created_at as created_at " +
                "FROM abonnements a " +
                "JOIN listes l ON a.liste_id = l.id " +
                "JOIN clients c ON a.client_id = c.id";
            List<AbonnementModel> results = new List<AbonnementModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new AbonnementModel {
                        id = reader.GetString("id"),
                        clientId = reader.GetString("client_id"),
                        nomClient = reader.GetString("nom_client"),
                        listeId = reader.GetString("liste_id"),
                        nomListe = reader.GetString("nom_liste"),
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

        public void Update(int listeId, int abonnementId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE abonnements SET liste_id = @ListeId WHERE id = @AbonnementId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", abonnementId);
                command.Parameters.AddWithValue("@AbonnementId", abonnementId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void Delete(int abonnementId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM abonnements WHERE id = @AbonnementId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@AbonnementId", abonnementId);
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
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
namespace kavy {
    class Abonnements {
        public Abonnements() {}

        public void Create(int client_id, int liste_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO abonnements(client_id, liste_id) VALUES(@ClientId, @ListeId)";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", client_id);
                command.Parameters.AddWithValue("@ListeId", liste_id);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public List<Dictionary<string, object>> Findall() {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT a.id as id, a.client_id as client_id, c.nom as nom_client," +
                "a.liste_id as liste_id, l.nom as nom_liste, a.created_at as created_at, a.updated_at as updated_at" +
                "FROM abonnements a" +
                "JOIN listes l ON a.liste_id = l.id" +
                "JOIN clients c ON a.client_id = c.id";
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read()) {
                    Dictionary<string, object> row = new Dictionary<string, object>();
                    for(int i = 0; i < reader.FieldCount; i++) {
                        row.Add(reader.GetName(i), reader.GetValue(i));
                    }
                    results.Add(row);
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

        public void Update(int abonnement_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE abonnements SET liste_id = @ListeId WHERE id = @AbonnementId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@AbonnementId", abonnement_id);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void Delete(int abonnement_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM abonnements WHERE id = @AbonnementId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@AbonnementId", abonnement_id);
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
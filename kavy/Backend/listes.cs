using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
namespace kavy {
    class Listes {
        public Listes() {}

        public void create(string nom) {
            MySqlConnection connection = Database.db_connection();
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

        public List<Dictionary<string, object>> findall() {
            MySqlConnection connection = Database.db_connection();
            string query = "SELECT * FROM listes";
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

        public void update(int liste_id, string nom) {
            MySqlConnection connection = Database.db_connection();
            string query = "UPDATE listes SET nom = @Nom WHERE id = @ListeId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", liste_id);
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

        public void delete(int liste_id) {
            MySqlConnection connection = Database.db_connection();
            string query = "DELETE FROM listes WHERE id = @ListeId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
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
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
namespace kavy {
    class Clients {
        public Clients() {}

        public void Create(string nom) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO clients(nom) VALUES(@Nom)";

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
        // public List<Dictionary<string, object>> Findall() {
        //     MySqlConnection connection = Database.Db_connection();
        //     string query = "SELECT * FROM clients";
        //     List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            
        //     try {
        //         connection.Open();
        //         MySqlCommand command = new MySqlCommand(query, connection);
        //         MySqlDataReader reader = command.ExecuteReader();
        //         while(reader.Read()) {
        //             Dictionary<string, object> row = new Dictionary<string, object>();
        //             for(int i = 0; i < reader.FieldCount; i++) {
        //                 row.Add(reader.GetName(i), reader.GetValue(i));
        //             }
        //             results.Add(row);
        //         }
        //         reader.Close();
        //     }
        //     catch(Exception e) {
        //         Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
        //     }
        //     finally {
        //         connection.Close();
        //     }

        //     return results;
        // }

        public DataTable Findall() {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT * FROM clients";
            DataTable dataTable = new DataTable();
            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
            return dataTable.DefaultView;
        }

        public Dictionary<string, object> Findone(int client_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT * FROM clients WHERE id = @ClientId";
            Dictionary<string, object> resultat = new Dictionary<string, object>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", client_id);
                MySqlDataReader reader = command.ExecuteReader();
                while(reader.Read()) {
                    for(int i = 0; i < reader.FieldCount; i++) {
                        resultat.Add(reader.GetName(i), reader.GetValue(i));
                    }
                }

                reader.Close();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }

            return resultat;
        }

        public void Update(string nom, int client_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE clients SET nom = @Nom WHERE id = @ClientId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@ClientId", client_id);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void Delete(int client_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM clients WHERE id = @ClientId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", client_id);
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
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace kavy {
    class Auth {
        public Auth() {}

        public int Client(string nom, string password) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT id FROM clients " + 
                "WHERE nom = @Nom AND password = @Password";
            int result = 0;

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = command.ExecuteReader();
                
                while(reader.Read()) {
                    result = reader.GetInt16("id");
                }
                reader.Close();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }

            return result;
        }

        public int Admin(string nom, string password) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT id FROM admin " + 
                "WHERE nom = @Nom AND password = @Password";
            int result = 0;

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nom", nom);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    result = reader.GetInt16("id");
                }
                reader.Close();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }

            return result;
        }
    }
}
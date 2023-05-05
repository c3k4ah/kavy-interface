using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using kavy.Backend.Models;

namespace kavy {
    class Archives {
        public Archives() {}

        public void Create(string content, int listeId, int adminId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "INSERT INTO archives(content, liste_id, admin_id) VALUES(@Content, @ListeId, @AdminId)";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Content", content);
                command.Parameters.AddWithValue("@ListeId", listeId);
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

        public List<ArchiveModel> Find(int archiveId = 0) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT a.id as id, a.content as content, a.liste_id as liste_id, l.nom as nom_liste, " +
                "a.admin_id as admin_id, ad.nom as nom_admin, a.created_at as created_at " +
                "FROM archives a " +
                "JOIN listes l ON a.liste_id = l.id " + 
                "JOIN admin ad ON a.admin_id = ad.id";
            if(archiveId > 0) query += " WHERE id = @ArchiveId";
            List<ArchiveModel> results = new List<ArchiveModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                if(archiveId > 0) command.Parameters.AddWithValue("@ArchiveId", archiveId);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new ArchiveModel {
                        id = reader.GetInt16("id"),
                        content = reader.GetString("content"),
                        listeId = reader.GetInt16("liste_id"),
                        nomListe = reader.GetString("nom_liste"),
                        adminId = reader.GetInt16("admin_id"),
                        nomAdmin = reader.GetString("nom_admin"),
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

        public List<ArchiveModel> FindByListeId(int listeId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT a.id as id, a.content as content, a.liste_id as liste_id, l.nom as nom_liste, " +
                "a.admin_id as admin_id, ad.nom as nom_admin, a.created_at as created_at " +
                "FROM archives a " +
                "JOIN listes l ON a.liste_id = l.id " + 
                "JOIN admin ad ON a.admin_id = ad.id " +
                "WHERE liste_id = @ListeId";
            List<ArchiveModel> results = new List<ArchiveModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ListeId", listeId);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new ArchiveModel {
                        id = reader.GetInt16("id"),
                        content = reader.GetString("content"),
                        listeId = reader.GetInt16("liste_id"),
                        nomListe = reader.GetString("nom_liste"),
                        adminId = reader.GetInt16("admin_id"),
                        nomAdmin = reader.GetString("nom_admin"),
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

        public List<ArchiveModel> FindByClientId(int clientId) {
            MySqlConnection connection = Database.Db_connection();
           string query = "SELECT a.id as id, a.content as content, a.liste_id as liste_id, l.nom as nom_liste, " +
                "a.admin_id as admin_id, ad.nom as nom_admin, a.created_at as created_at " +
                "FROM archives a " +
                "JOIN listes l ON a.liste_id = l.id " + 
                "JOIN admin ad ON a.admin_id = ad.id " +
                "WHERE liste_id IN (SELECT DISTINCT(liste_id) FROM abonnements WHERE client_id = @ClientId)";
            List<ArchiveModel> results = new List<ArchiveModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ClientId", clientId);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new ArchiveModel {
                        id = reader.GetInt16("id"),
                        content = reader.GetString("content"),
                        listeId = reader.GetInt16("liste_id"),
                        nomListe = reader.GetString("nom_liste"),
                        adminId = reader.GetInt16("admin_id"),
                        nomAdmin = reader.GetString("nom_admin"),
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

        public List<ArchiveModel> Filtre(string search) {
            MySqlConnection connection = Database.Db_connection();
            string query = "SELECT a.id as id, a.content as content, a.liste_id as liste_id, l.nom as nom_liste, " +
                "a.admin_id as admin_id, ad.nom as nom_admin, a.created_at as created_at " +
                "FROM archives a " +
                "JOIN listes l ON a.liste_id = l.id " + 
                "JOIN admin ad ON a.admin_id = ad.id " +
                "WHERE content LIKE %@Search%";
            List<ArchiveModel> results = new List<ArchiveModel>();

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Search", search);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read()) {
                    var data = new ArchiveModel {
                        id = reader.GetInt16("id"),
                        content = reader.GetString("content"),
                        listeId = reader.GetInt16("liste_id"),
                        nomListe = reader.GetString("nom_liste"),
                        adminId = reader.GetInt16("admin_id"),
                        nomAdmin = reader.GetString("nom_admin"),
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

        public void Update(string content, int archiveId) {
            MySqlConnection connection = Database.Db_connection();
            string query = "UPDATE archives SET content = @Content WHERE id = @ArchiveId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Content", content);
                command.Parameters.AddWithValue("@ArchiveId", archiveId);
                command.ExecuteNonQuery();
            }
            catch(Exception e) {
                Console.WriteLine("Erreur, connexion à la base de données !\n" + e.Message);
            }
            finally {
                connection.Close();
            }
        }

        public void Delete(int archive_id) {
            MySqlConnection connection = Database.Db_connection();
            string query = "DELETE FROM archives WHERE id = @ArchiveId";

            try {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ArchiveId", archive_id);
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
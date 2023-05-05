using MySql.Data.MySqlClient;

namespace kavy {
    class Database {
        public static MySqlConnection Db_connection() {
            string dbHost = "localhost";
            int dbPort = 3306;
            string dbUser = "root";
            string dbPassword = "";
            string dbName = "kavy";

            return new MySqlConnection($"server={dbHost};port={dbPort};user id={dbUser};password={dbPassword};database={dbName}");
        }
    }
}

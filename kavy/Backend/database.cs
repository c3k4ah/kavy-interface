using MySql.Data.MySqlClient;

namespace kavy {
    class Database {
        public static MySqlConnection db_connection() {
            string dbHost = "localhost";
            int dbPort = 3137;
            string dbUser = "";
            string dbPassword = "";
            string dbName = "KAVY";

            return new MySqlConnection($"server={dbHost};port={dbPort};user id={dbUser};password={dbPassword};database={dbName}");
        }
    }
}

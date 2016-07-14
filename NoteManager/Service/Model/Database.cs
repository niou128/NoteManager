using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Service.Model
{
    class Database
    {
        private static Database instance;
        private SqlConnection connection;

        private Database()
        {
            connection = new SqlConnection();
            connection.ConnectionString =
                @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                "AttachDbFilename=C:\\Users\\Edwige\\Documents\\Etna-altnernance\\Master\\IDV-PNET_NoteManager\\NoteManager\\Service\\Database.mdf;" +
                "Integrated Security=True;" +
                "Connect Timeout=30";
            connection.Open();
        }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public string query(string sql_query)
        {
            SqlCommand command = new SqlCommand(sql_query, connection);
            string t = "";

            Regex regex_for_read = new Regex(@"^(?i:select)");
            if (regex_for_read.Match(sql_query).Success)
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    t += string.Format("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
                return t;
            }
            else
            {
                throw new Exception("pas implémenté");
            }
        }

    }
}

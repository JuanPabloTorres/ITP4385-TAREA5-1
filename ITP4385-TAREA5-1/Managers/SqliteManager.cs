using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITP4385_TAREA5_1.Managers
{
    public class SqliteManager
    {

        string _connectionString = "Data Source=C:\\EDP\\ITP-4385\\database.sqlite;Version=3;";

        SQLiteConnection SQLiteConnection;

        SQLiteCommand SQLiteCommand;



        public SqliteManager()
        {
            SQLiteConnection SQLiteConnection = new SQLiteConnection(_connectionString);
        }

        public bool InsertCustomer()
        {
            string sqlInsert = "";


            return true;
        }

        public bool DeleteCustomer()
        {
            string sqlDelete = "";


            return true;
        }

        public int CounterCustomer()
        {
            string sqlCounterCustomer = "";

            return 0;
        }
    }
}

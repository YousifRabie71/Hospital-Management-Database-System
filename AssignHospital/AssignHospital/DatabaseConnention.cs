using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;

namespace AssignHospital
{
    internal class DatabaseConnention
    {
        private MySqlConnection HosConnection;

        public DatabaseConnention()
        {
            string connectionstring = "server= 127.0.0.1;port=3306;Database=hosdb;uid=root;Pwd=mysql";
            HosConnection = new MySqlConnection(connectionstring);
        }

        public MySqlConnection GetConnection()
        {

            return HosConnection;
        }
   
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public sealed class Database
    {
        private static Database instance = null;
        public static Database GetInstance
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
        private Database()
        {
        }
        private MySqlConnection GetConnection()
        {
            string conString = @"server=localhost;userid=root;password=12345;database=account";

            var con = new MySqlConnection(conString);
            return con;
        }
    }
}
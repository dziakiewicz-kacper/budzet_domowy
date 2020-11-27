using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Login
    {
        private string login;
        private string password;
        public string GetLogin { get => this.login; }
        // TODO: Change access for password field!
        public string GetPassword { get => this.password; }
        public Login()
        {
            this.login = string.Empty;
            this.password = string.Empty;
        }
        public Login(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public void ChangePassword(string password)
        {
            if (password.Length < 8 && password.Length >= 30)
            {
                throw new ArgumentOutOfRangeException();
            }
            this.password = password;
        }
        public static bool CheckIsExist(string login)
        {
            Database database = Database.GetInstance;
            var con = database.GetConnection();
            var query = "SELECT id FROM account where login = @login";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@login", login);
            con.Open();
            var result = cmd.ExecuteScalar();
            con.Close();
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //public static Login Examples(Person person)
        //{
        //    string mail = person.LastName.ToLower() + "." + person.FirstName.ToLower() + "@ebudzet.pl";
        //    string password = DateGenerate.random.Next(00000000, 99999999).ToString();
        //    Login login = new Login(mail, password);
        //    return login;
        //}
    }
}
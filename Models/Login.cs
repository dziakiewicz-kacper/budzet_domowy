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
        //TESTY
        public string GetLogin { get => this.login; }
        //TESTY
        public string GetPassword { get => this.password; }
        private Login()
        {
            this.login = string.Empty;
            this.password = string.Empty;
        }
        public Login(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
        public static Login Examples(Person person)
        {
            string mail = person.LastName.ToLower() + "." + person.FirstName.ToLower() + "@ebudzet.pl";
            Random random = new Random();
            string password = random.Next(00000000, 99999999).ToString();
            Login login = new Login(mail, password);
            return login;
        }
    }
}
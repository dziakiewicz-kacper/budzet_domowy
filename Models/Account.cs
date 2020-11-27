using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Account
    {
        private int id;
        private Login login;
        private Person person;
        private Budget budget;
        private ICommandAccount command;
        private List<Goal> goals;
        private AccountMode mode;
        public static List<Account> ListAccount = null;
        public int ID { get => this.id; set => this.id = value; }
        public Login Login { get => this.login; }
        public Person Person { get => this.person; }
        public Budget Budget { get => this.budget; }
        public ICommandAccount Command { get => this.command; }
        public List<Goal> Goals { get => this.goals; }
        public AccountMode Mode { get => this.mode; }
        public Account()
        {
            this.id = 0;
            this.login = null;
            this.person = null;
            this.budget = null;
            this.command = null;
            this.goals = null;
            this.mode = AccountMode.user;
        }
        public Account(int id, Person person, Budget budget) : this()
        {
            this.id = id;
            this.person = person;
            this.budget = budget;
        }
        public void AddGoal(Goal goal)
        {
            this.goals.Add(goal);
            //insert do bazy danych
        }
        public void UpdateGoal()
        {
            throw new NotImplementedException();
        }
        public void DeleteGoal(Goal goal)
        {
            int id = goal.ID;
            goals.RemoveAll(g => g.ID == id);
            //delete do bazy danych
        }
        public void ExecuteCommand(ICommandAccount command)
        {
            try
            {
                command.Execute(this);
            }
            catch
            {
                return;
            }
        }
        public void SetLogin(Login login)
        {
            if (login == null)
            {
                throw new ArgumentNullException();
            }
            this.login = login;
        }
        public void SetGoals(List<Goal> goals)
        {
            this.goals = goals;
        }
        public void SetBudget(Budget budget)
        {
            this.budget = budget;
        }
        public void SetPerson(Person person)
        {
            this.person = person;
        }
        public void SetMode(AccountMode mode)
        {
            this.mode = mode;
        }
        public void InsertAccount()
        {
            InsertCommandAccount command = new InsertCommandAccount(Database.GetInstance);
            ExecuteCommand(command);
        }
        public void ReadAccount()
        {
            ReadCommandAccount command = new ReadCommandAccount(Database.GetInstance);
            ExecuteCommand(command);
        }
        //public static void RegisterAccount()
        //{
        //    Person person = Person.Examples();
        //    Budget budget = new Budget(1);
        //    Account account = new Account(1, person, budget);
        //    UpdateCommandAccount command = new UpdateCommandAccount(Database.GetInstance);
        //    account.ExecuteCommand(command);
        //}
        //public static List<Account> Examples(int count)
        //{
        //    List<Account> listAccounts = new List<Account>();
        //    for (int i = 0; i <= count; i++)
        //    {
        //        Person person = Person.Examples();
        //        var budget = new Budget(i);
        //        Account account = new Account(i, person, budget);
        //        listAccounts.Add(account);
        //    }
        //    return listAccounts;
        //}
        public static bool VerifyAccount(out int id, string login, string password)
        {
            id = 0;
            Database database = Database.GetInstance;
            var con = database.GetConnection();
            var query = "SELECT id FROM account where login = @login and password = @password";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@password", password);
            con.Open();
            var result = cmd.ExecuteScalar();
            con.Close();
            if (result == null)
            {
                return false;
            }
            else
            {
                id = (int)result;
                return true;
            }
        }
    }
}
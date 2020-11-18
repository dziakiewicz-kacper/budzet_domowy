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
        public MySqlConnection GetConnection()
        {
            string conString = @"server=localhost;userid=root;password=12345;database=home_budget";

            var con = new MySqlConnection(conString);
            return con;
        }
        public void Search(Account account)
        {
            var query = "SELECT * FROM account where id = " + account.ID + ";";
            List<string> result = Single(query);
            string loginFromDb = result[1];
            string password = result[2];
            Login login = new Login(loginFromDb, password);

            query = "SELECT * FROM person where id_account = " + account.ID + ";";
            result = Single(query);
            int idPerson = Convert.ToInt32(result[0]);
            string firstName = result[2];
            string lastName = result[3];
            DateTime dateOfBirth = DateTime.Parse(result[4]);
            Person person = new Person(idPerson, firstName, lastName, dateOfBirth);

            query = "SELECT * FROM budget where id_account = " + account.ID + ";";
            result = Single(query);
            int idBudget = Convert.ToInt32(result[0]);
            Budget budget = new Budget(idBudget);

            query = "SELECT * FROM address where id_person = " + idPerson + ";";
            result = Single(query);
            string street = result[2];
            string zipCode = result[3];
            string number = result[4];
            string town = result[5];
            Address address = new Address(street, zipCode, number, town);

            query = "SELECT * FROM cost where id_budget = " + budget.ID + ";";
            List<Cost> costs = GetCosts(query);

            query = "SELECT * FROM income where id_budget = " + budget.ID + ";";
            List<Income> incomes = GetIncomes(query);


            person.SetAddress(address);
            account.SetLogin(login);
            account.SetPerson(person);
            account.SetBudget(budget);
            account.Budget.SetCosts(costs);
            account.Budget.SetIncomes(incomes);
        }
        private List<Cost> GetCosts(string query)
        {
            List<Cost> costs = new List<Cost>();

            var con = Database.GetInstance.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                int value = Convert.ToInt32(reader[1]);
                string category = reader[2].ToString();
                DateTime date = new DateTime(1990, 1, 1);
                CostCategory costCategory = CostCategory.Alcohol;

                Cost cost = new Cost(id, value, costCategory, date);
                costs.Add(cost);
            }
            con.Close();
            return costs;
        }
        private List<Income> GetIncomes(string query)
        {
            List<Income> incomes = new List<Income>();

            var con = Database.GetInstance.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader[0]);
                int value = Convert.ToInt32(reader[1]);
                string category = reader[2].ToString();
                DateTime date = new DateTime(1990, 1, 1);
                IncomeCategory costCategory = IncomeCategory.Other;

                Income income = new Income(id, value, costCategory, date);
                incomes.Add(income);
            }
            con.Close();
            return incomes;
        }
        private List<string> Single(string query)
        {
            var con = Database.GetInstance.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            List<string> results = new List<string>();
            string value = "";
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    value = reader[i].ToString();
                    results.Add(value);
                }
            }
            con.Close();
            return results;
        }
        public void Update(Account account)
        {

        }
    }
}
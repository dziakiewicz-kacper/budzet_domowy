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
        public void InsertAccount(Account account)
        {
            string queryMaxIdAccount = "SELECT MAX(id) from account;";
            var maxIdAccount = Select(queryMaxIdAccount);
            string queryMaxIdPerson = "SELECT MAX(id) from person;";
            var maxIdPerson = Select(queryMaxIdPerson);
            int idAccount = Convert.ToInt32(maxIdAccount[0]) + 1;
            int idPerson = Convert.ToInt32(maxIdPerson[0]) + 1;
            string query = "INSERT INTO account(id,login, password, mode) VALUES (@id, @login, @password, 1);";
            var con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", idAccount);
            cmd.Parameters.AddWithValue("@login", account.Login.GetLogin);
            cmd.Parameters.AddWithValue("@password", account.Login.GetPassword);
            cmd.ExecuteNonQuery();

            string queryPerson = "INSERT INTO person(id, id_account, first_name, last_name, date_of_birth) VALUES (@id, @id_account, @firstname, @lastname, @dateOfBirth);";
            cmd.CommandText = queryPerson;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id", idPerson);
            cmd.Parameters.AddWithValue("@id_account", idAccount);
            cmd.Parameters.AddWithValue("@firstname", account.Person.FirstName);
            cmd.Parameters.AddWithValue("@lastname", account.Person.LastName);
            cmd.Parameters.AddWithValue("@dateOfBirth", account.Person.DateOfBirth);
            cmd.ExecuteNonQuery();

            string queryAddress = "INSERT INTO address(id_person, street, zip_code, number, town) VALUES(@id_person, @street, @zip_code, @number, @town);";
            cmd.CommandText = queryAddress;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_person", idPerson);
            cmd.Parameters.AddWithValue("@street", account.Person.Address.Street);
            cmd.Parameters.AddWithValue("@zip_code", account.Person.Address.ZipCode);
            cmd.Parameters.AddWithValue("@number", account.Person.Address.Number);
            cmd.Parameters.AddWithValue("@town", account.Person.Address.Town);
            cmd.ExecuteNonQuery();

            string queryBudget = "INSERT INTO budget(id_account) VALUES(@id_account);";
            cmd.CommandText = queryBudget;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@id_account", idAccount);
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void ReadAccount(Account account)
        {
            var query = "SELECT * FROM account where id = " + account.ID + ";";
            List<string> result = Select(query);
            Login login = new Login(result[1], result[2]);

            AccountMode mode = (AccountMode)Enum.Parse(typeof(AccountMode), result[3]);

            query = "SELECT * FROM person where id_account = " + account.ID + ";";
            result = Select(query);
            int idPerson = Convert.ToInt32(result[0]);
            string firstName = result[2];
            string lastName = result[3];
            DateTime dateOfBirth = DateTime.Parse(result[4]);
            Person person = new Person(firstName, lastName, dateOfBirth);
            person.ID = idPerson;

            query = "SELECT * FROM address where id_person = " + idPerson + ";";
            result = Select(query);
            string street = result[2];
            string zipCode = result[3];
            string number = result[4];
            string town = result[5];
            Address address = new Address(street, zipCode, number, town);

            query = "SELECT * FROM budget where id_account = " + account.ID + ";";
            result = Select(query);
            int idBudget = Convert.ToInt32(result[0]);
            Budget budget = new Budget(idBudget);

            query = "SELECT * FROM cost where id_budget = " + budget.ID + ";";
            result = Select(query);
            if (result != null)
            {
                List<Cost> costs = new List<Cost>();
                for (int i = 0; i < result.Count / 5; i++)
                {
                    int id = Convert.ToInt32(result[0 + i * 5]);
                    int value = Convert.ToInt32(result[2 + i * 5]);
                    CostCategory category = (CostCategory)Enum.Parse(typeof(CostCategory), result[3 + i * 5]);
                    DateTime date = DateTime.Parse(result[4 + i * 5]);
                    Cost cost = new Cost(id, value, category, date);
                    costs.Add(cost);
                }
                budget.SetList(costs);
            }

            query = "SELECT * FROM income where id_budget = " + budget.ID + ";";
            result = Select(query);
            if (result != null)
            {
                List<Income> incomes = new List<Income>();
                for (int i = 0; i < result.Count / 5; i++)
                {
                    int id = Convert.ToInt32(result[0 + i * 5]);
                    int value = Convert.ToInt32(result[2 + i * 5]);
                    IncomeCategory category = (IncomeCategory)Enum.Parse(typeof(IncomeCategory), result[3 + i * 5]);
                    DateTime date = DateTime.Parse(result[4 + i * 5]);
                    Income income = new Income(id, value, category, date);
                    incomes.Add(income);
                }
                budget.SetList(incomes);
            }
            person.SetAddress(address);
            account.SetLogin(login);
            account.SetPerson(person);
            account.SetBudget(budget);
            account.SetMode(mode);
        }
        private List<string> Select(string query)
        {
            var con = GetConnection();
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
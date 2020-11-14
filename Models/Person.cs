using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private Address address;
        private Login login;
        public string FirstName { get => this.firstName; }
        public string LastName { get => this.lastName; }
        public DateTime DateOfBirth { get => this.dateOfBirth; }
        public Address GetAddress { get => this.address; }
        public Login GetLogin { get => this.login; }
        private Person()
        {
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.address = null;
            this.login = null;
        }
        public Person(string firstName, string lastName, DateTime dateOfBirth) : this()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
        public static Person Examples()
        {
            Person person = GeneratePerson();
            Address address = Address.Examples();
            Login login = Login.Examples(person);
            person.SetAddress(address);
            person.SetLogin(login);
            return person;
        }
        private static Person GeneratePerson()
        {
            Random random = new Random();
            string file = "";
            int sexPerson = random.Next(1, 2);
            if (sexPerson == 1)
                file = "man.json";
            else
                file = "woman.json";
            var dateOfBirth = GenerateDateOfBirth();
            using (StreamReader sr = new StreamReader(file, Encoding.Default))
            {
                string json = sr.ReadToEnd();
                var dictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
                string firstname = dictionary["firstname"][random.Next(0, dictionary["firstname"].Count)];
                string lastname = dictionary["lastname"][random.Next(0, dictionary["lastname"].Count)];
                Person person = new Person(firstname, lastname, dateOfBirth);
                return person;
            }
        }
        private static DateTime GenerateDateOfBirth()
        {
            var date = DateTime.Today;
            Random random = new Random();
            double days = random.Next(2000, 30000);
            var dateOfBirht = date.AddDays(-days);
            return dateOfBirht;
        }
        public void SetAddress(Address address) => this.address = address;
        public void SetLogin(Login login) => this.login = login;
    }
}
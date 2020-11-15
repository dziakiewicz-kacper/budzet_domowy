using System;
using System.Collections.Generic;

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

        public Person()
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
            Dictionary<string, List<string>> dictionary;
            int sexPerson = DateGenerate.random.Next(1, 2);
            if (sexPerson == 1)
            {
                dictionary = DateGenerate.manDictionary;
            }
            else
            {
                dictionary = DateGenerate.womanDictionary;
            }
            DateTime dateOfBirth = GenerateDateOfBirth();
            string firstName = dictionary["firstname"][DateGenerate.random.Next(0, dictionary["firstname"].Count)];
            string lastName = dictionary["lastname"][DateGenerate.random.Next(0, dictionary["lastname"].Count)];
            Person person = new Person(firstName, lastName, dateOfBirth);
            return person;
        }
        private static DateTime GenerateDateOfBirth()
        {
            var date = DateTime.Today;
            double days = DateGenerate.random.Next(2000, 30000);
            var dateOfBirht = date.AddDays(-days);
            return dateOfBirht;
        }
        public void SetAddress(Address address) => this.address = address;
        public void SetLogin(Login login) => this.login = login;
    }
}
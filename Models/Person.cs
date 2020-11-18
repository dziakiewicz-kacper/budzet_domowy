using System;
using System.Collections.Generic;

namespace BudzetDomowy.Models
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private Address address;
        public int ID { get => this.id; }
        public string FirstName { get => this.firstName; }
        public string LastName { get => this.lastName; }
        public DateTime DateOfBirth { get => this.dateOfBirth; }
        public Address Address { get => this.address; }

        public Person()
        {
            this.id = 0;
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.dateOfBirth = new DateTime(1990,1,1);
            this.address = null;
        }
        public Person(int id, string firstName, string lastName, DateTime dateOfBirth) : this()
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
        public static Person Examples()
        {
            DateGenerate.ShowList();
            Person person = GeneratePerson();
            Address address = Address.Examples();
            person.SetAddress(address);
            return person;
        }
        private static Person GeneratePerson()
        {
            int id = 1;
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
            Person person = new Person(id, firstName, lastName, dateOfBirth);
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
    }
}
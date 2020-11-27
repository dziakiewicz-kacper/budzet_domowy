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
        public int ID { get => this.id; set => this.id = value; }
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
        public Person(string firstName, string lastName, DateTime dateOfBirth) : this()
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
        }
        public void SetAddress(Address address) => this.address = address;
    }
}
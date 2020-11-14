using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Account
    {
        private int id;
        private Person person;
        private Budget budget;
        private ICommand command;
        private List<Goal> goals;
        public int ID { get => this.id; }
        public Person Person { get => this.person; }
        public Budget Budget { get => this.budget; }
        public ICommand Command { get => this.command; }
        public List<Goal> Goals { get => this.goals; }
        private Account()
        {
            this.id = 0;
            this.person = null;
            this.budget = null;
            this.command = null;
            this.goals = null;
        }
        public Account(int id, Person person, Budget budget) : this()
        {
            this.id = id;
            this.person = person;
            this.budget = budget;
        }
        public void SetCommand(ICommand command)
        {
            throw new NotImplementedException();
        }
        public void SetGoal(Goal goal)
        {
            throw new NotImplementedException();
        }
        public static List<Account> Examples(int count)
        {
            List<Account> accounts = new List<Account>();
            DateTime date = new DateTime(2000, 12, 1);
            for (int i = 0; i <= count; i++)
            {
                var person = Person.Examples();
                var budget = new Budget(i);
                Account account = new Account(i, person, budget);
                accounts.Add(account);
            }
            return accounts;
        }
    }
}
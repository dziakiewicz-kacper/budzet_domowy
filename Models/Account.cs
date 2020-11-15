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
        public static List<Account> ListAccount = null;
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
            List<Account> listAccounts = new List<Account>();
            for (int i = 0; i <= count; i++)
            {
                Person person = Person.Examples();
                var budget = new Budget(i);
                Account account = new Account(i, person, budget);
                listAccounts.Add(account);
            }
            return listAccounts;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Budget
    {
        private int id;
        private List<Income> incomes;
        private List<Cost> costs;
        public int ID { get => this.id; }
        public List<Income> Incomes { get => this.incomes; }
        public List<Cost> Costs { get => this.costs; }
        private Budget()
        {
            this.id = 0;
            this.incomes = new List<Income>();
            this.costs = new List<Cost>();
        }
        public Budget(int id) : this()
        {
            this.id = id;
        }
        public void SetCosts(List<Cost> costs)
        {
            this.costs = costs;
        }
        public void SetIncomes(List<Income> incomes)
        {
            this.incomes = incomes;
        }
    }
}
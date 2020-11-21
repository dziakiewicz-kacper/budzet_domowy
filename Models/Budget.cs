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
        public Budget()
        {
            this.id = 0;
            this.incomes = new List<Income>();
            this.costs = new List<Cost>();
        }
        public Budget(int id) : this()
        {
            this.id = id;
        }
        public void AddToList(object item)
        {
            if (item is Cost)
            {
                this.costs.Add(item as Cost);
            } else
            {
                this.incomes.Add(item as Income);
            }
        }
        public void DeleteFromList(object item)
        {
            if (item is Cost)
            {
                Cost cost = item as Cost;
                int id = cost.ID;
                costs.RemoveAll(c => c.ID == id);
            } else
            {
                Income income = item as Income;
                int id = income.ID;
                incomes.RemoveAll(i => i.ID == id);
            }
        }
        public void SetList(object item)
        {
            if (item is List<Cost>)
            {
                this.costs = item as List<Cost>;
            } else
            {
                this.incomes = item as List<Income>;
            }
        }
    }
}
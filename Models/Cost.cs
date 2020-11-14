using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Cost
    {
        private int id;
        private int value;
        private CostCategory category;
        private DateTime? date;
        public int ID { get => this.id; }
        public int Value { get => this.value; }
        public CostCategory Category { get => this.category; }
        public DateTime? Date { get => this.date; }
        private Cost()
        {
            this.id = 0;
            this.value = 0;
            this.category = CostCategory.None;
            this.date = null;
        }
        public Cost(int id, int value, CostCategory category, DateTime date) : this()
        {
            this.id = id;
            this.value = value;
            this.category = category;
            this.date = date;
        }

    }
}
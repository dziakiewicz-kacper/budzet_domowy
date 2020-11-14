using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Income
    {
        private int id;
        private int value;
        private IncomeCategory category;
        private DateTime? date;
        public int ID { get => this.id; }
        public int Value { get => this.value; }
        public IncomeCategory Category { get => this.category; }
        public DateTime? Date { get => this.date; }
        private Income()
        {
            this.id = 0;
            this.value = 0;
            this.category = IncomeCategory.None;
            this.date = null;
        }
        public Income(int id, int value, IncomeCategory category, DateTime date) : this()
        {
            this.id = id;
            this.value = value;
            this.category = category;
            this.date = date;
        }

    }
}
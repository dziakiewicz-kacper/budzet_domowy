using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class Goal
    {
        private int id;
        private string name;
        private int value;
        private GoalStatus status;
        private DateTime? date;
        public int ID { get => this.id; }
        public string Name { get => this.name; }
        public int Value { get => this.value; }
        public GoalStatus Status { get => this.status; }
        public DateTime? Date { get => this.date; }
        private Goal()
        {
            this.id = 0;
            this.name = string.Empty;
            this.value = 0;
            this.status = GoalStatus.None;
            this.date = null;
        }
        public Goal(int id, string name, int value, GoalStatus status, DateTime date) : this()
        {
            this.id = id;
            this.name = name;
            this.value = value;
            this.status = status;
            this.date = date;
        }
        public void ChangeStatus(GoalStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class InsertCommandAccount : ICommandAccount
    {
        private Database database;
        public InsertCommandAccount(Database database)
        {
            this.database = database;
        }
        public void Execute(Account account)
        {
            this.database.InsertAccount(account);
        }
    }
}
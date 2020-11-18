using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudzetDomowy.Models
{
    public class UpdateCommand : ICommand
    {
        private Database database;
        public UpdateCommand(Database database)
        {
            this.database = database;
        }
        public void Execute(Account account)
        {
            this.database.Update(account);
        }
    }
}
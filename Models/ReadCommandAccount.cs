using BudzetDomowy.Models;

namespace BudzetDomowy
{
    public class ReadCommandAccount : ICommandAccount
    {
        private Database database;
        public ReadCommandAccount(Database database)
        {
            this.database = database;
        }
        public void Execute(Account account)
        {
            this.database.ReadAccount(account);
        }
    }
}
using BudzetDomowy.Models;

namespace BudzetDomowy
{
    public class SearchCommand : ICommand
    {
        private Database database;
        public SearchCommand(Database database)
        {
            this.database = database;
        }
        public void Execute(Account account)
        {
            this.database.Search(account);
        }
    }
}
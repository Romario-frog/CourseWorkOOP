namespace CourseWork
{
    public class AccountHistoryCommand : ICommand
    {
        private readonly Account _account;

        public AccountHistoryCommand(Account account)
        {
            _account = account;
        }

        public void Execute()
        {
            Console.WriteLine("Історія покупок:");
            foreach (var entry in _account.PurchaseHistory)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
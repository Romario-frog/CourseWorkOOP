namespace CourseWork
{
    public class MakeDepositCommand : ICommand
    {
        private readonly AccountService _accountService;
        private readonly int _accountId;

        public MakeDepositCommand(AccountService accountService, int accountId)
        {
            _accountService = accountService;
            _accountId = accountId;
        }

        public void Execute()
        {
            try
            {
                Console.Write("Введіть суму для поповнення: ");
                var amount = decimal.Parse(Console.ReadLine());
                _accountService.Deposit(_accountId, amount);
                Console.WriteLine("Баланс успішно поповнено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
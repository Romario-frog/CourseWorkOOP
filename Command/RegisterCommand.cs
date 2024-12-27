namespace CourseWork
{
    public class RegisterCommand : ICommand
    {
        private readonly AccountService _accountService;
            
        public RegisterCommand(AccountService accountService)
        {
            _accountService = accountService;
        }

        public void Execute()
        {
            try
            {
                Console.Write("Введіть ім'я користувача: ");
                var username = Console.ReadLine();
                Console.Write("Введіть пароль: ");
                var password = Console.ReadLine();

                _accountService.Register(username, password);
                Console.WriteLine($"Реєстрація успішна!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
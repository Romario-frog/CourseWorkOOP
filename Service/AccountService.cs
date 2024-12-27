namespace CourseWork
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        private static int _nextId = 1; 

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Register(string username, string password)
        {
            if (_accountRepository.GetAccountByUsername(username) != null)
                throw new Exception("Користувач вже існує.");
            
           Account newAccount=new Account
           {
               Username = username,
               Password = password,
           };
            
            _accountRepository.AddAccount(newAccount);
        }

        public Account Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Ім'я користувача та пароль не можуть бути порожніми.");
            }
            var account = _accountRepository.GetAccountByUsername(username);
            if (account == null)
            {
                throw new Exception("Користувача з таким іменем не знайдено.");
            }
            if (account.Password != password)
            {
                throw new Exception("Невірний пароль.");
            }
            Console.WriteLine("Ласкаво просимо!");
            return account;
        }


        public void Deposit(int accountId, decimal amount)
        {
            var account = _accountRepository.GetAccountById(accountId);
            if (account == null)
                throw new Exception("Користувача не знайдено.");

            account.Balance += amount;
            _accountRepository.UpdateAccount(account);
        }

        public Account GetAccountById(int accountId)
        {
            var account = _accountRepository.GetAccountById(accountId);
            if (account == null)
                throw new Exception("Користувача не знайдено.");
            return account;
        }
    }
}

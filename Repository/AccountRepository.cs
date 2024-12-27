using System.Linq;

namespace CourseWork
{
    public class AccountRepository : IAccountRepository
    {
        private readonly List<Account> _accounts = new List<Account>();
        private readonly DbContext _dbContext;

        public AccountRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Account GetAccountByUsername(string username)
        {
            return _accounts.FirstOrDefault(a => a.Username == username);
        }

        public Account GetAccountById(int id)
        {
            return _accounts.FirstOrDefault(a => a.Id == id);
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(account);
        }

        public void UpdateAccount(Account account)
        {
            var existing = GetAccountById(account.Id);
            if (existing != null)
            {
                _accounts.Remove(existing);
                _accounts.Add(account);
            }
        }
    }
}
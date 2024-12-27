namespace CourseWork
{
    public interface IAccountRepository
    {
        Account GetAccountByUsername(string username);
        Account GetAccountById(int id);
        void AddAccount(Account account);
        void UpdateAccount(Account account);
    }

}
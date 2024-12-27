namespace CourseWork
{
    public interface IAccountService
    {
        Account Register(string username, string password);
        Account Login(string username, string password);
        void Deposit(int accountId, decimal amount);
        Account GetAccountById(int accountId);
    }
}
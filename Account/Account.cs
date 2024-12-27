namespace CourseWork
{
    
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }
        public List<string> PurchaseHistory { get; set; } = new List<string>();
    }
}
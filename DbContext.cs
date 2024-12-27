namespace CourseWork
{
    public class DbContext
    {
        public List<Account> Accounts { get; set; }
        public List<Product> Products { get; set; }

        public DbContext()
        {
            Accounts = new List<Account>();
            
            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Цемент", Price = 100, Quantity = 50 },
                new Product { Id = 2, Name = "Цегла", Price = 10, Quantity = 500 },
                new Product { Id = 3, Name = "Гіпс", Price = 50, Quantity = 30 }
            };
        }
    }
}
namespace CourseWork
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Цемент", Price = 100, Quantity = 50 },
            new Product { Id = 2, Name = "Цегла", Price = 10, Quantity = 500 },
            new Product { Id = 3, Name = "Гіпс", Price = 50, Quantity = 30 }
        };
        private readonly DbContext _dbContext;

        public ProductRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public void UpdateProduct(Product product)
        {
            var existing = GetProductById(product.Id);
            if (existing != null)
            {
                _products.Remove(existing);
                _products.Add(product);
            }
        }
    }
}
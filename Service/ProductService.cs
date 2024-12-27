namespace CourseWork
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void BuyProduct(int productId, int quantity, Account account)
        {
            var product = _productRepository.GetProductById(productId);
            if (product == null || product.Quantity < quantity)
                throw new Exception("Недостатньо товару на складі.");

            var totalCost = product.Price * quantity;
            if (account.Balance < totalCost)
                throw new Exception("Недостатньо коштів на рахунку.");

            product.Quantity -= quantity;
            account.Balance -= totalCost;
            account.PurchaseHistory.Add($"{product.Name} x{quantity} - {totalCost} грн");

            _productRepository.UpdateProduct(product);
        }
    }
}
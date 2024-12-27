namespace CourseWork
{
    public class ShowProductsCommand : ICommand
    {
        private readonly ProductService _productService;

        public ShowProductsCommand(ProductService productService)
        {
            _productService = productService;
        }

        public void Execute()
        {
            var products = _productService.GetAllProducts();
            Console.WriteLine("Список доступних товарів:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}. {product.Name} - {product.Price} грн (Кількість: {product.Quantity})");
            }
        }
    }
}
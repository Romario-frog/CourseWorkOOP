namespace CourseWork
{
    public class BuyProductCommand : ICommand
    {
        private readonly ProductService _productService;
        private readonly Account _account;

        public BuyProductCommand(ProductService productService, Account account)
        {
            _productService = productService;
            _account = account;
        }

        public void Execute()
        {
            try
            {
                Console.Write("Введіть ID товару: ");
                var productId = int.Parse(Console.ReadLine());
                Console.Write("Введіть кількість: ");
                var quantity = int.Parse(Console.ReadLine());

                _productService.BuyProduct(productId, quantity, _account);
                Console.WriteLine("Покупка успішна!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
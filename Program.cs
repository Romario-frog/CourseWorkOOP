namespace CourseWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new DbContext();
            var accountRepository = new AccountRepository(dbContext);
            var productRepository = new ProductRepository(dbContext);
            var accountService = new AccountService(accountRepository);
            var productService = new ProductService(productRepository);

            Console.WriteLine("Вітаємо в магазині будматеріалів!");

            Account currentAccount = null; 

            string choice;
            do
            {
                if (currentAccount == null) 
                {
                    Console.WriteLine("1. Реєстрація\n2. Вхід\n5. Вихід");
                    choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        var registerCommand = new RegisterCommand(accountService);
                        registerCommand.Execute();
                    }
                    else if (choice == "2")
                    {
                        try
                        {
                            Console.Write("Введіть ім'я користувача для входу: ");
                            var username = Console.ReadLine();
                            Console.Write("Введіть пароль: ");
                            var password = Console.ReadLine();

                            currentAccount = accountService.Login(username, password);
                            Console.WriteLine($"Вітаємо, {currentAccount.Username}!"); 
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                    }
                    else if (choice == "5")
                    {
                        Console.WriteLine("Дякуємо за використання магазину!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Невірна команда. Спробуйте ще раз.");
                    }
                }
                else
                {
                    string option;
                    do
                    {
                        Console.WriteLine(
                            "1. Поповнити баланс\n2. Переглянути товари\n3. Купити товар\n4. Історія покупок\n5. Вийти з облікового запису");
                        option = Console.ReadLine();

                        try
                        {
                            if (option == "1")
                            {
                                var makeDepositCommand = new MakeDepositCommand(accountService, currentAccount.Id);
                                makeDepositCommand.Execute();
                            }
                            else if (option == "2")
                            {
                                var showProductsCommand = new ShowProductsCommand(productService);
                                showProductsCommand.Execute();
                            }
                            else if (option == "3")
                            {
                                var buyProductCommand = new BuyProductCommand(productService, currentAccount);
                                buyProductCommand.Execute();
                            }
                            else if (option == "4")
                            {
                                var accountHistoryCommand = new AccountHistoryCommand(currentAccount);
                                accountHistoryCommand.Execute();
                            }
                            else if (option == "5")
                            {
                                Console.WriteLine($"До побачення, {currentAccount.Username}!");
                                currentAccount = null; 
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Невірна команда. Спробуйте ще раз.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                    } while (option != "5");
                }
            } while (true);
        }
    }
}

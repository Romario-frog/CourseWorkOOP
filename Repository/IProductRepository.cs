namespace CourseWork
{
    public interface IProductRepository
    {
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        void UpdateProduct(Product product);
    }
}
public interface IProductRepository
{
    void Create(Product product);
    List<Product> GetAll();
    Product GetById(int id);
    void Update(int id,Product product);
    void Delete(int id);
}

public class ProductRepository : IProductRepository
{
    private AppDbContext appDbContext;
    public ProductRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public void Create(Product product)
    {
        appDbContext.Products.Add(product);
        appDbContext.SaveChanges();
    }
    public List<Product> GetAll()
    {
        return appDbContext.Products.ToList();
    }
    public Product GetById(int id)
    {
        return appDbContext.Products.Find(id);
    }
    public void Update(int id, Product product)
    {
        var existingProduct = appDbContext.Products.Find(id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            appDbContext.SaveChanges();             
        }
    }
    public void Delete(int id)
    {
        var product = appDbContext.Products.Find(id);
        if (product != null)
        {
            appDbContext.Products.Remove(product);
            appDbContext.SaveChanges();
        }
    }

}
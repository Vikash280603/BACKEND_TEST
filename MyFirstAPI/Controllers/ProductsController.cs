using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    // private static List<Product> products = new List<Product>
    // {
    //     new Product{Id = 1 , Name = "Pen" , Price = 50},
    //     new Product{Id = 2 , Name = "Pencil" , Price = 25}
    // };

    //Dependency Injection
    private IProductRepository productRepository;
    public ProductsController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }
    [HttpGet]
    public List<Product> GetAll()
    {
        return productRepository.GetAll();
    }

    [HttpPost]
    public void Post(Product product)
    {
        //products.Add(product);
        productRepository.Create(product);
    }

    [HttpPut]
    public void Put(int id , Product product)
    {
        // var oldProduct = products.Find(p=>p.Id==id);
        // oldProduct.Name = product.Name;
        // oldProduct.Price = product.Price;
        // var oldProduct = appDbContext.Products.Find(id);
        // oldProduct.Name = product.Name;
        // oldProduct.Price = product.Price;
        // appDbContext.SaveChanges();
        productRepository.Update(id, product);
    }

    [HttpDelete]

    public void Delete(int id)
    {
        // var oldProduct = products.Find(p=>p.Id==id);
        // products.Remove(oldProduct);
        // var oldProduct = appDbContext.Products.Find(id);
        // appDbContext.Products.Remove(oldProduct);
        // appDbContext.SaveChanges();
        productRepository.Delete(id);

    }

}
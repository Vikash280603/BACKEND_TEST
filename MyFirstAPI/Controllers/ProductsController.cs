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
    private AppDbContext appDbContext;
    public ProductsController(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    [HttpGet]
    public List<Product> GetAll()
    {
        return appDbContext.Products.ToList();
    }

    [HttpPost]
    public void Post(Product product)
    {
        //products.Add(product);
        appDbContext.Products.Add(product);
        appDbContext.SaveChanges();
    }

    [HttpPut]
    public void Put(int id , Product product)
    {
        // var oldProduct = products.Find(p=>p.Id==id);
        // oldProduct.Name = product.Name;
        // oldProduct.Price = product.Price;
        var oldProduct = appDbContext.Products.Find(id);
        oldProduct.Name = product.Name;
        oldProduct.Price = product.Price;
        appDbContext.SaveChanges();
    }

    [HttpDelete]

    public void Delete(int id)
    {
        // var oldProduct = products.Find(p=>p.Id==id);
        // products.Remove(oldProduct);
        var oldProduct = appDbContext.Products.Find(id);
        appDbContext.Products.Remove(oldProduct);
        appDbContext.SaveChanges();

    }

}
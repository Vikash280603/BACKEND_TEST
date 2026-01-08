using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using MyFirstMVC.Models;

public class ProductsController : Controller
{

    //Dependency Injection
    private AppDbContext appDbContext;
    public ProductsController(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return View(appDbContext.Products.ToList());
    }

    [HttpPost]
    public IActionResult Post(Product product)
    {
        appDbContext.Products.Add(product);
        appDbContext.SaveChanges();
        return RedirectToAction("GetAll");
    }
     [HttpGet]
    public IActionResult Post()
    {
        return View();
       
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        var exisitingProduct = appDbContext.Products.Find(product.Id);
        exisitingProduct.Name = product.Name;
        exisitingProduct.Price = product.Price;
        appDbContext.SaveChanges();
        return RedirectToAction("GetAll");
    }
     [HttpGet]
    public IActionResult Edit(int id)
    {
        var product = appDbContext.Products.Find(id);
        return View(product);
       
    }

    // [HttpPut]
    // public void Put(int id , Product product)
    // {
    //     // var oldProduct = products.Find(p=>p.Id==id);
    //     // oldProduct.Name = product.Name;
    //     // oldProduct.Price = product.Price;
    //     var oldProduct = appDbContext.Products.Find(id);
    //     oldProduct.Name = product.Name;
    //     oldProduct.Price = product.Price;
    //     appDbContext.SaveChanges();
    // }

    // [HttpDelete]

    // public void Delete(int id)
    // {
    //     // var oldProduct = products.Find(p=>p.Id==id);
    //     // products.Remove(oldProduct);
    //     var oldProduct = appDbContext.Products.Find(id);
    //     appDbContext.Products.Remove(oldProduct);
    //     appDbContext.SaveChanges();

    // }

}
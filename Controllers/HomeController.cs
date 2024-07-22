using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormApp.Controllers;

public class HomeController : Controller
{

    [HttpGet]
    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;
        ViewBag.searchString = searchString;
        if (!String.IsNullOrEmpty(searchString))
        {
            products = products.Where(p => p.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        if (!String.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }
        ViewBag.Categories = new SelectList(Repository.Categores, "CategoryId", "Name", category);
        return View(products);
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categores, "CategoryId", "Name");
        return View();
    }
    [HttpPost]
    //public IActionResult Create([Bind("Name, Price")] Product model)
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)
    {
        var extention = Path.GetExtension(imageFile.FileName);
        var randomFileName = string.Format($"{Guid.NewGuid()}{extention}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);

        if (ModelState.IsValid)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categores, "CategoryId", "Name");
        return View(model);

    }


}

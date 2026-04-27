using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = db.Products.ToList();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product p)
    {
        db.Products.Add(p);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product p)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        
        product.Id = p.Id;
        product.Name = p.Name;
        product.Description = p.Description;
        product.Price = p.Price;
        product.Count = p.Count;
        product.MinCount = p.MinCount;
        product.Tendetion = p.Tendetion;

        db.SaveChanges();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        db.Products.Remove(product);
        db.SaveChanges();
        return Ok(product);
    }

}

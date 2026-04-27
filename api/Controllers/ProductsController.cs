using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dto;
using api.Models;

namespace api.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(new ApiResponse<List<Product>> { Data = db.Products.ToList() });

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound(new ApiResponse<Product> { Error = "Продукт не найден" });
        return Ok(new ApiResponse<Product> { Data = product });
    }

    [HttpPost]
    public IActionResult Create(Product p)
    {
        db.Products.Add(p);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = p.Id }, new ApiResponse<Product> { Data = p, Message = "Продукт создан" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product p)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound(new ApiResponse<Product> { Error = "Продукт не найден" });

        product.Name = p.Name;
        product.Description = p.Description;
        product.Price = p.Price;
        product.Count = p.Count;
        product.MinCount = p.MinCount;
        product.Tendetion = p.Tendetion;
        db.SaveChanges();
        return Ok(new ApiResponse<Product> { Data = product, Message = "Продукт обновлён" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = db.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound(new ApiResponse<Product> { Error = "Продукт не найден" });
        db.Products.Remove(product);
        db.SaveChanges();
        return Ok(new ApiResponse<Product> { Data = product, Message = "Продукт удалён" });
    }
}

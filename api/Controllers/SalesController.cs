using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var sales = db.Sales.ToList();
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var sale = db.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    [HttpPost]
    public IActionResult Create(Sale s)
    {
        db.Sales.Add(s);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = s.Id }, s);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Sale s)
    {
        var sale = db.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null)
        {
            return NotFound();
        }
        
        sale.Id = s.Id;
        sale.VendingMachineId = s.VendingMachineId;
        sale.ProductId = s.ProductId;
        sale.Count = s.Count;
        sale.Earning = s.Earning;
        sale.Date = s.Date;
        sale.PaymentMethod = s.PaymentMethod;

        db.SaveChanges();
        return Ok(sale);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sale = db.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null)
        {
            return NotFound();
        }
        db.Sales.Remove(sale);
        db.SaveChanges();
        return Ok(sale);
    }

}
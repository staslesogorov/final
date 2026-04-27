using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dto;
using api.Models;

namespace api.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class SalesController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(new ApiResponse<List<Sale>> { Data = db.Sales.ToList() });

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var sale = db.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null) return NotFound(new ApiResponse<Sale> { Error = "Продажа не найдена" });
        return Ok(new ApiResponse<Sale> { Data = sale });
    }

    [HttpPost]
    public IActionResult Create(Sale s)
    {
        db.Sales.Add(s);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = s.Id }, new ApiResponse<Sale> { Data = s, Message = "Продажа создана" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Sale s)
    {
        var sale = db.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null) return NotFound(new ApiResponse<Sale> { Error = "Продажа не найдена" });

        sale.VendingMachineId = s.VendingMachineId;
        sale.ProductId = s.ProductId;
        sale.Count = s.Count;
        sale.Earning = s.Earning;
        sale.Date = s.Date;
        sale.PaymentMethod = s.PaymentMethod;
        db.SaveChanges();
        return Ok(new ApiResponse<Sale> { Data = sale, Message = "Продажа обновлена" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sale = db.Sales.FirstOrDefault(s => s.Id == id);
        if (sale == null) return NotFound(new ApiResponse<Sale> { Error = "Продажа не найдена" });
        db.Sales.Remove(sale);
        db.SaveChanges();
        return Ok(new ApiResponse<Sale> { Data = sale, Message = "Продажа удалена" });
    }
}

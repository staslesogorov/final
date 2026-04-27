using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dto;
using api.Models;

namespace api.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class ServicesController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(new ApiResponse<List<Service>> { Data = db.Services.ToList() });

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var service = db.Services.FirstOrDefault(s => s.Id == id);
        if (service == null) return NotFound(new ApiResponse<Service> { Error = "Сервис не найден" });
        return Ok(new ApiResponse<Service> { Data = service });
    }

    [HttpPost]
    public IActionResult Create(Service s)
    {
        db.Services.Add(s);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = s.Id }, new ApiResponse<Service> { Data = s, Message = "Сервис создан" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Service s)
    {
        var service = db.Services.FirstOrDefault(s => s.Id == id);
        if (service == null) return NotFound(new ApiResponse<Service> { Error = "Сервис не найден" });

        service.VendingMachineId = s.VendingMachineId;
        service.Date = s.Date;
        service.Description = s.Description;
        service.Error = s.Error;
        service.UserId = s.UserId;
        db.SaveChanges();
        return Ok(new ApiResponse<Service> { Data = service, Message = "Сервис обновлён" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var service = db.Services.FirstOrDefault(s => s.Id == id);
        if (service == null) return NotFound(new ApiResponse<Service> { Error = "Сервис не найден" });
        db.Services.Remove(service);
        db.SaveChanges();
        return Ok(new ApiResponse<Service> { Data = service, Message = "Сервис удалён" });
    }
}

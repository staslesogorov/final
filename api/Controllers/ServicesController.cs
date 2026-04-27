using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var services = db.Services.ToList();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var service = db.Services.FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound();
        }
        return Ok(service);
    }

    [HttpPost]
    public IActionResult Create(Service s)
    {
        db.Services.Add(s);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = s.Id }, s);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Service s)
    {
        var service = db.Services.FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound();
        }
        
        service.Id = s.Id;
        service.VendingMachineId = s.VendingMachineId;
        service.Date = s.Date;
        service.Description = s.Description;
        service.Error = s.Error;
        service.UserId = s.UserId;

        db.SaveChanges();
        return Ok(service);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var service = db.Services.FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound();
        }
        db.Services.Remove(service);
        db.SaveChanges();
        return Ok(service);
    }

}
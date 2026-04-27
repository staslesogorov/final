using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendingMachinesController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var vendingMachines = db.VendingMachines.ToList();
        return Ok(vendingMachines);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var vendingMachine = db.VendingMachines.FirstOrDefault(vm => vm.Id == id);
        if (vendingMachine == null)
        {
            return NotFound();
        }
        return Ok(vendingMachine);
    }

    [HttpPost]
    public IActionResult Create(VendingMachine vm)
    {
        db.VendingMachines.Add(vm);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = vm.Id }, vm);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, VendingMachine vm)
    {
        var vendingMachine = db.VendingMachines.FirstOrDefault(vm => vm.Id == id);
        if (vendingMachine == null)
        {
            return NotFound();
        }

        vendingMachine.Place = vm.Place;
        vendingMachine.Model = vm.Model;
        vendingMachine.Type = vm.Type;
        vendingMachine.Status = vm.Status;
        vendingMachine.Date = vm.Date;
        vendingMachine.ServiceDate = vm.ServiceDate;
        vendingMachine.Earning = vm.Earning;

        db.SaveChanges();
        return Ok(vendingMachine);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var vendingMachine = db.VendingMachines.FirstOrDefault(vm => vm.Id == id);
        if (vendingMachine == null)
        {
            return NotFound();
        }
        db.VendingMachines.Remove(vendingMachine);
        db.SaveChanges();
        return Ok(vendingMachine);
    }
}
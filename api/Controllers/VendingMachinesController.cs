using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dto;
using api.Models;

namespace api.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public class VendingMachinesController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(new ApiResponse<List<VendingMachine>> { Data =  db.VendingMachines.ToList() });

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var vm = db.VendingMachines.FirstOrDefault(v => v.Id == id);
        if (vm == null) return NotFound(new ApiResponse<VendingMachine> { Error = "Автомат не найден" });
        return Ok(new ApiResponse<VendingMachine> { Data = vm });
    }

    [HttpPost]
    public IActionResult Create(VendingMachine vm)
    {
        db.VendingMachines.Add(vm);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = vm.Id }, new ApiResponse<VendingMachine> { Data = vm, Message = "Автомат создан" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, VendingMachine vm)
    {
        var v = db.VendingMachines.FirstOrDefault(v => v.Id == id);
        if (v == null) return NotFound(new ApiResponse<VendingMachine> { Error = "Автомат не найден" });

        v.Place = vm.Place;
        v.Model = vm.Model;
        v.Type = vm.Type;
        v.Status = vm.Status;
        v.Date = vm.Date;
        v.ServiceDate = vm.ServiceDate;
        v.Earning = vm.Earning;
        db.SaveChanges();
        return Ok(new ApiResponse<VendingMachine> { Data = v, Message = "Автомат обновлён" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var vm = db.VendingMachines.FirstOrDefault(v => v.Id == id);
        if (vm == null) return NotFound(new ApiResponse<VendingMachine> { Error = "Автомат не найден" });
        db.VendingMachines.Remove(vm);
        db.SaveChanges();
        return Ok(new ApiResponse<VendingMachine> { Data = vm, Message = "Автомат удалён" });
    }
}

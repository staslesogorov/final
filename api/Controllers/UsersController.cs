using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Models;
using api;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(AppDb db) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = db.Users.ToList();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(User u)
    {
        db.Users.Add(u);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = u.Id }, u);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, User u)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.Id = u.Id;
        user.FIO = u.FIO;
        user.Email = u.Email;
        user.Phone = u.Phone;
        user.Role = u.Role;

        db.SaveChanges();
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        db.Users.Remove(user);
        db.SaveChanges();
        return Ok(user);
    }

}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using api.Data;
using api.Dto;
using api.Models;

namespace api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController(AppDb db) : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetAll() =>
        Ok(new ApiResponse<List<User>> { Data = db.Users.ToList() });

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound(new ApiResponse<User> { Error = "Пользователь не найден" });
        return Ok(new ApiResponse<User> { Data = user });
    }

    [HttpPost]
    public IActionResult Create(User u)
    {
        u.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
        db.Users.Add(u);
        db.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = u.Id }, new ApiResponse<User> { Data = u, Message = "Пользователь создан" });
    }

    [Authorize]
    [HttpPut("{id}")]
    public IActionResult Update(int id, User u)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound(new ApiResponse<User> { Error = "Пользователь не найден" });

        user.FIO = u.FIO;
        user.Email = u.Email;
        user.Phone = u.Phone;
        user.Role = u.Role;
        db.SaveChanges();
        return Ok(new ApiResponse<User> { Data = user, Message = "Пользователь обновлён" });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user == null) return NotFound(new ApiResponse<User> { Error = "Пользователь не найден" });
        db.Users.Remove(user);
        db.SaveChanges();
        return Ok(new ApiResponse<User> { Data = user, Message = "Пользователь удалён" });
    }
}

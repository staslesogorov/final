using api.Data;
using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController(AppDb db) : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(LoginDto dto)
    {
        var user = db.Users.FirstOrDefault(u => u.Login == dto.Login);
        if (user == null)
            return NotFound(new ApiResponse<string> { Error = "Пользователь не найден" });
        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            return Unauthorized(new ApiResponse<string> { Error = "Неверный пароль" });

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnmqwerty"));
        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddHours(24),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return Ok(new ApiResponse<Object> {  Data = new { token = new JwtSecurityTokenHandler().WriteToken(token), user = user }, Message = "Успешный вход" });
    }
}

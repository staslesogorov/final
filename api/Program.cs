using api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDb>();

var app = builder.Build();
app.UseCors(c => c.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

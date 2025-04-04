using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ Đăng ký DbContext với cấu hình từ appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

<<<<<<< HEAD
app.Run();
=======
app.Run();
>>>>>>> 9fae4ce55b2735e28fb3aaf2de6efcdeed3b1bfa

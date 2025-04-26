using Microsoft.EntityFrameworkCore;
using NguyenManhHung_2122110438_asp.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Kết nối Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

<<<<<<< HEAD
// Cấu hình CORS để cho phép frontend React truy cập từ một domain khác
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // Địa chỉ frontend của bạn (React + Vite chạy trên port 3000)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

=======
>>>>>>> 7b7392b0c7ab2ccda59f96e27d30087dc7670d2e
// Fix lỗi JSON vòng lặp (nếu có quan hệ navigation giữa các model)
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Swagger hỗ trợ test API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Cấu hình CORS
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

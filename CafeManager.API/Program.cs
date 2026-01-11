using CafeManager.DAL.Models;
using Microsoft.EntityFrameworkCore;
using CafeManager.DAL;
using CafeManager.BUS;

var builder = WebApplication.CreateBuilder(args);

// --- 1. Đăng ký các Dịch vụ (Services) ---

builder.Services.AddControllers();

// Lấy chuỗi kết nối từ biến môi trường trên Render hoặc appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Đăng ký DbContext sử dụng PostgreSQL
builder.Services.AddDbContext<CafeContext>(options =>
    options.UseNpgsql(connectionString));

// Đăng ký các lớp Business Logic và Data Access (DI)
builder.Services.AddScoped<AccountDAL>();
builder.Services.AddScoped<AccountBUS>();

// Cấu hình Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- 2. Cấu hình HTTP Request Pipeline ---

// Bật Swagger cho TẤT CẢ các môi trường (Quan trọng để chạy trên Render)
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    // Thiết lập này giúp khi bạn vào thẳng link Render nó sẽ hiện Swagger luôn
    options.RoutePrefix = string.Empty;
});

// Cho phép API trả về dữ liệu (JSON) cho WinForms
app.UseAuthorization();

app.MapControllers();

app.Run();
using CafeManager.DAL.Models;
using Microsoft.EntityFrameworkCore;
using CafeManager.DAL;
using CafeManager.BUS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// 1. Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Đăng ký CafeContext vào hệ thống Dependency Injection
builder.Services.AddDbContext<CafeContext>(options =>options.UseNpgsql(connectionString));

builder.Services.AddScoped<AccountDAL>();
builder.Services.AddScoped<AccountBUS>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

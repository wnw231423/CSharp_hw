using Microsoft.EntityFrameworkCore;
using OrderCLI.Models;

var builder = WebApplication.CreateBuilder(args);

// 添加数据库上下文，使用 SQLite
builder.Services.AddDbContext<OrderContext>();

// 其他服务保持不变
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
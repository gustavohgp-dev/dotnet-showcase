using DotNetGameInventoryAPI.Data;
using DotNetGameInventoryAPI.Middleware;
using DotNetGameInventoryAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Builder
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IInventoryService, InventoryService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=inventory.db"));

//App
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using DotNetGameInventoryAPI.Services;

var builder = WebApplication.CreateBuilder(args);
//Builder
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<IInventoryService, InventoryService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
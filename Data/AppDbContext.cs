using DotNetGameInventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetGameInventoryAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<InventoryItem> InventoryItems { get; set; }
}
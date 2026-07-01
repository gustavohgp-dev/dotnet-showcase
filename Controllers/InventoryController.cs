namespace DotNetGameInventoryAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class InventoryController: ControllerBase
{
    private readonly ILogger<InventoryController> _logger;

    public InventoryController(ILogger<InventoryController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet(Name = "GetInventory")]
    public IEnumerable<InventoryItem> Get()
    {
        List<InventoryItem> inventory = new()
        {
            new InventoryItem { Id = 0, Name = "Iron Sword", Quantity = 1 },
            new InventoryItem { Id = 1, Name = "Health Potion", Quantity = 5 },
            new InventoryItem{Id = 2, Name = "Iron Shield", Quantity = 1}
        };

        return inventory;
    }
}
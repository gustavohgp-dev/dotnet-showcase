using DotNetGameInventoryAPI.Models;
using DotNetGameInventoryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetGameInventoryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController: ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }
    
    [HttpGet(Name = "GetInventory")]
    public IEnumerable<InventoryItem> Get()
    {
        return _inventoryService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<InventoryItem> GetById(int id)
    {
        var item = _inventoryService.GetById(id);
        
        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public ActionResult<InventoryItem> Create([FromBody] CreateInventoryItemDto dto)
    {
        var createdItem = _inventoryService.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
    }

    [HttpPut("{id}")]
    public ActionResult<InventoryItem> Update(int id, [FromBody] UpdateInventoryItemDto dto)
    {
       InventoryItem? updatedItem = _inventoryService.Update(id, dto);
       
       if (updatedItem == null)
       {
           return NotFound();
       }

       return Ok(updatedItem);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        bool deletionResult = _inventoryService.Delete(id);

        if (!deletionResult)
        {
            return NotFound();
        }

        return NoContent();
    }
}
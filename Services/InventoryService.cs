using DotNetGameInventoryAPI.Data;
using DotNetGameInventoryAPI.Models;

namespace DotNetGameInventoryAPI.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<InventoryItem> GetAll()
    {
        return _context.InventoryItems.ToList();
    }
    
    public InventoryItem? GetById(int id)
    {
        return _context.InventoryItems.FirstOrDefault(i => i.Id == id);
    }
    
    public InventoryItem Create(CreateInventoryItemDto dto)
    {
        var item = new InventoryItem { Name = dto.Name, Quantity = dto.Quantity };
        _context.InventoryItems.Add(item);
        _context.SaveChanges();
        return item;
    }

    public InventoryItem? Update(int id, UpdateInventoryItemDto dto)
    {
        InventoryItem? targetItem =  _context.InventoryItems.FirstOrDefault(i => i.Id == id);

        if (targetItem == null)
        {
            return null;
        }

        targetItem.Name = dto.Name;
        targetItem.Quantity = dto.Quantity;

        _context.SaveChanges();
        return targetItem;
    }

    public bool Delete(int id)
    {
        InventoryItem? item =  _context.InventoryItems.FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            return false;
        }
        _context.InventoryItems.Remove(item);
        _context.SaveChanges();
        return true;
    }
}
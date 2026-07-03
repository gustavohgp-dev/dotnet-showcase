namespace DotNetGameInventoryAPI.Services;

public class InventoryService : IInventoryService
{
    private List<InventoryItem> _inventory = new()
    {
        new InventoryItem { Id = 0, Name = "Iron Sword", Quantity = 1 },
        new InventoryItem { Id = 1, Name = "Health Potion", Quantity = 5 },
        new InventoryItem { Id = 2, Name = "Iron Shield", Quantity = 1 }
    };
    
    public IEnumerable<InventoryItem> GetAll()
    {
        return _inventory;
    }
    
    public InventoryItem? GetById(int id)
    {
        return _inventory.FirstOrDefault(i => i.Id == id);
    }
    
    public InventoryItem Create(InventoryItem item)
    {
        item.Id = _inventory.Count > 0 ? _inventory.Max(i => i.Id) + 1 : 0;
        _inventory.Add(item);
        return item;
    }

    public InventoryItem? Update(int id, InventoryItem item)
    {
        InventoryItem? targetItem =  _inventory.FirstOrDefault(i => i.Id == id);

        if (targetItem == null)
        {
            return null;
        }

        targetItem.Name = item.Name;
        targetItem.Quantity = item.Quantity;
        
        return targetItem;
    }

    public bool Delete(int id)
    {
        InventoryItem? item =  _inventory.FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            return false;
        }
        _inventory.Remove(item);
        return true;
    }
}
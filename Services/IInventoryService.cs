using DotNetGameInventoryAPI.Models;

namespace DotNetGameInventoryAPI.Services;

public interface IInventoryService
{
    IEnumerable<InventoryItem> GetAll();
    InventoryItem? GetById(int id);
    InventoryItem Create(CreateInventoryItemDto dto);
    InventoryItem? Update(int id, UpdateInventoryItemDto dto);
    bool Delete(int id);
}
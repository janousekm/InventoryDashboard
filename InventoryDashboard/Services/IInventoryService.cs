using InventoryReport.Data;

namespace InventoryReport.Services;

public interface IInventoryService
{
    Task<List<InventoryItem>> GetInventoryItemsAsync();
}

using InventoryReport.Data;
using InventoryReport.Services;


public class InventoryService : IInventoryService
{
    public Task<List<InventoryItem>> GetInventoryItemsAsync()
    {
        // mock data - replace with real DB or API call
        var items = new List<InventoryItem>
        {
            new InventoryItem
            {
                Id = 1,
                Date = DateTime.Now.AddDays(-5),
                CI = "CI001",
                DocType = "Invoice",
                Cargo = "Apples",
                Weight = 100.5,
                Parcels = 10,
                Value = 500,
                Customer = "Customer A",
                DateLeft = DateTime.Now.AddDays(10)
            },
            new InventoryItem
            {
                Id = 2,
                Date = DateTime.Now.AddDays(-2),
                CI = "CI002",
                DocType = "Bill",
                Cargo = "Oranges",
                Weight = 200,
                Parcels = 15,
                Value = 700,
                Customer = "Customer B",
                DateLeft = null
            }
        };

        return Task.FromResult(items);
    }
}

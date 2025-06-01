using InventoryReport.Data;
using InventoryReport.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InventoryService : IInventoryService
{
    public Task<List<InventoryItem>> GetInventoryItemsAsync()
    {
        var items = new List<InventoryItem>
        {
            // 1. Electronics (Laptops)
            new InventoryItem
            {
                Id = 1,
                Date = DateTime.Now.AddDays(-3),
                CI = "CI001",
                DocType = "Invoice",
                Cargo = "Laptops",
                Weight = 25.2,
                Parcels = 5,
                Value = 12000,
                Customer = "Tech Corp",
                DateLeft = DateTime.Now.AddDays(7)
            },

            // 2. Electronics (Smartphones)
            new InventoryItem
            {
                Id = 2,
                Date = DateTime.Now.AddDays(-1),
                CI = "CI002",
                DocType = "Receipt",
                Cargo = "Smartphones",
                Weight = 10.5,
                Parcels = 20,
                Value = 15000,
                Customer = "Mobile Inc",
                DateLeft = null
            },

            // 3. Heavy Machinery (Excavator)
            new InventoryItem
            {
                Id = 3,
                Date = DateTime.Now.AddDays(-10),
                CI = "CI003",
                DocType = "Contract",
                Cargo = "Excavator",
                Weight = 5000,
                Parcels = 1,
                Value = 250000,
                Customer = "Construction Ltd",
                DateLeft = DateTime.Now.AddDays(30)
            },

            // 4. Food (Fresh Fish)
            new InventoryItem
            {
                Id = 4,
                Date = DateTime.Now.AddHours(-12),
                CI = "CI004",
                DocType = "Invoice",
                Cargo = "Fresh Fish",
                Weight = 150,
                Parcels = 8,
                Value = 800,
                Customer = "Seafood Market",
                DateLeft = DateTime.Now.AddDays(1)
            },

            // 5. Clothing (T-Shirts)
            new InventoryItem
            {
                Id = 5,
                Date = DateTime.Now.AddDays(-5),
                CI = "CI005",
                DocType = "Order",
                Cargo = "T-Shirts",
                Weight = 30,
                Parcels = 50,
                Value = 1500,
                Customer = "Fashion Store",
                DateLeft = DateTime.Now.AddDays(14)
            },

            // 6. Furniture (Office Chairs)
            new InventoryItem
            {
                Id = 6,
                Date = DateTime.Now.AddDays(-7),
                CI = "CI006",
                DocType = "Invoice",
                Cargo = "Office Chairs",
                Weight = 200,
                Parcels = 10,
                Value = 5000,
                Customer = "Corporate Solutions",
                DateLeft = null
            },

            // 7. Automotive (Car Parts)
            new InventoryItem
            {
                Id = 7,
                Date = DateTime.Now.AddDays(-2),
                CI = "CI007",
                DocType = "Bill",
                Cargo = "Car Parts",
                Weight = 180.5,
                Parcels = 15,
                Value = 3500,
                Customer = "AutoZone",
                DateLeft = DateTime.Now.AddDays(5)
            },

            // 8. Pharmaceuticals (Medicines)
            new InventoryItem
            {
                Id = 8,
                Date = DateTime.Now.AddDays(-1),
                CI = "CI008",
                DocType = "Prescription",
                Cargo = "Medicines",
                Weight = 5.2,
                Parcels = 30,
                Value = 4200,
                Customer = "PharmaCare",
                DateLeft = DateTime.Now.AddDays(60)
            },

            // 9. Books (Textbooks)
            new InventoryItem
            {
                Id = 9,
                Date = DateTime.Now.AddDays(-14),
                CI = "CI009",
                DocType = "Order",
                Cargo = "Textbooks",
                Weight = 120,
                Parcels = 25,
                Value = 3000,
                Customer = "University Store",
                DateLeft = DateTime.Now.AddDays(21)
            },

            // 10. Chemicals (Cleaning Supplies)
            new InventoryItem
            {
                Id = 10,
                Date = DateTime.Now.AddDays(-3),
                CI = "CI010",
                DocType = "Invoice",
                Cargo = "Cleaning Supplies",
                Weight = 75.3,
                Parcels = 12,
                Value = 950,
                Customer = "Janitorial Services",
                DateLeft = null
            },

            // 11. Jewelry (Gold Rings)
            new InventoryItem
            {
                Id = 11,
                Date = DateTime.Now.AddDays(-1),
                CI = "CI011",
                DocType = "Valuation",
                Cargo = "Gold Rings",
                Weight = 0.5,
                Parcels = 5,
                Value = 25000,
                Customer = "Luxury Gems",
                DateLeft = DateTime.Now.AddDays(7)
            },

            // 12. Toys (Action Figures)
            new InventoryItem
            {
                Id = 12,
                Date = DateTime.Now.AddDays(-5),
                CI = "CI012",
                DocType = "Order",
                Cargo = "Action Figures",
                Weight = 15.8,
                Parcels = 40,
                Value = 2000,
                Customer = "Toy World",
                DateLeft = DateTime.Now.AddDays(14)
            },

            // 13. Agricultural (Wheat)
            new InventoryItem
            {
                Id = 13,
                Date = DateTime.Now.AddDays(-30),
                CI = "CI013",
                DocType = "Contract",
                Cargo = "Wheat",
                Weight = 5000,
                Parcels = 100,
                Value = 10000,
                Customer = "Farm Co-op",
                DateLeft = DateTime.Now.AddDays(90)
            },

            // 14. Beverages (Wine)
            new InventoryItem
            {
                Id = 14,
                Date = DateTime.Now.AddDays(-7),
                CI = "CI014",
                DocType = "Invoice",
                Cargo = "Wine Bottles",
                Weight = 85,
                Parcels = 24,
                Value = 4800,
                Customer = "Vineyard Estates",
                DateLeft = DateTime.Now.AddDays(365)
            },

            // 15. Miscellaneous (Misc. Goods)
            new InventoryItem
            {
                Id = 15,
                Date = DateTime.Now.AddDays(-2),
                CI = "CI015",
                DocType = "Bill",
                Cargo = "Miscellaneous Goods",
                Weight = 250,
                Parcels = 18,
                Value = 6200,
                Customer = "General Store",
                DateLeft = null
            }
        };

        return Task.FromResult(items);
    }
}
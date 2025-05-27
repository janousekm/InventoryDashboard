namespace InventoryReport.Data;

public class InventoryItem
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string CI { get; set; }
    public string DocType { get; set; }
    public string Cargo { get; set; }
    public double Weight { get; set; }
    public int Parcels { get; set; }
    public double Value { get; set; }
    public string Customer { get; set; }
    public DateTime? DateLeft { get; set; }
}

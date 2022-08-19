namespace StatisticsAnalysisTool.Models.NetworkModel;

public class ChestLogObject
{
    public ChestLogObject(string name, long itemId, int quantity, long ticks)
    {
        Name = name;
        ItemId = itemId;
        Quantity = quantity;
        Ticks = ticks;
    }

    public string Name { get; set; }
    public long ItemId { get; set; }
    public int Quantity { get; set; }
    public long Ticks { get; set; }
}
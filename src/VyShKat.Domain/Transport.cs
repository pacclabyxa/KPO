using VyShKat.Domain.Abstractions;

namespace VyShKat.Domain;

public abstract class Transport : IInventoryItem, IEnergyConsumer
{
    protected Transport(
        string inventoryNumber,
        string name,
        double dailyEnergyConsumptionKwh,
        int noviceSimplicity)
    {
        if (string.IsNullOrWhiteSpace(inventoryNumber))
            throw new ArgumentException("Inventory number is required.", nameof(inventoryNumber));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        if (dailyEnergyConsumptionKwh < 0)
            throw new ArgumentOutOfRangeException(nameof(dailyEnergyConsumptionKwh));

        if (noviceSimplicity is < 1 or > 10)
            throw new ArgumentOutOfRangeException(nameof(noviceSimplicity));

        InventoryNumber = inventoryNumber;
        Name = name;
        DailyEnergyConsumptionKwh = dailyEnergyConsumptionKwh;
        NoviceSimplicity = noviceSimplicity;
    }

    public string InventoryNumber { get; }
    public string Name { get; }
    public double DailyEnergyConsumptionKwh { get; }
    public int NoviceSimplicity { get; }
}
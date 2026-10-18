using VyShKat.Domain.Abstractions;

namespace VyShKat.Domain.Things;

public sealed class ChargingStation : IInventoryItem, IEnergyConsumer
{
    public ChargingStation(
        string inventoryNumber,
        string name,
        double dailyEnergyConsumptionKwh)
    {
        if (string.IsNullOrWhiteSpace(inventoryNumber))
            throw new ArgumentException("Inventory number is required.", nameof(inventoryNumber));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        if (dailyEnergyConsumptionKwh < 0)
            throw new ArgumentOutOfRangeException(nameof(dailyEnergyConsumptionKwh));

        InventoryNumber = inventoryNumber;
        Name = name;
        DailyEnergyConsumptionKwh = dailyEnergyConsumptionKwh;
    }

    public string InventoryNumber { get; }
    public string Name { get; }
    public double DailyEnergyConsumptionKwh { get; }
}

using VyShKat.Domain.Abstractions;

namespace VyShKat.Domain.Things;

public sealed class Helmet : IInventoryItem
{
    public Helmet(string inventoryNumber, string name)
    {
        if (string.IsNullOrWhiteSpace(inventoryNumber))
            throw new ArgumentException("Inventory number is required.", nameof(inventoryNumber));

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        InventoryNumber = inventoryNumber;
        Name = name;
    }

    public string InventoryNumber { get; }
    public string Name { get; }
}

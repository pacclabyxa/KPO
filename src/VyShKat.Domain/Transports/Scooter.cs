namespace VyShKat.Domain.Transports;

public sealed class Scooter : Transport
{
    public Scooter(
        string inventoryNumber,
        string name,
        double dailyEnergyConsumptionKwh,
        int noviceSimplicity)
        : base(inventoryNumber, name, dailyEnergyConsumptionKwh, noviceSimplicity)
    {
    }
}

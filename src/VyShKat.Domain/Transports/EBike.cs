namespace VyShKat.Domain.Transports;

public sealed class EBike : Transport
{
    public EBike(
        string inventoryNumber,
        string name,
        double dailyEnergyConsumptionKwh,
        int noviceSimplicity)
        : base(inventoryNumber, name, dailyEnergyConsumptionKwh, noviceSimplicity)
    {
    }
}

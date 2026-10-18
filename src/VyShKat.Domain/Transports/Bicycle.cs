namespace VyShKat.Domain.Transports;

public sealed class Bicycle : Transport
{
    public Bicycle(
        string inventoryNumber,
        string name,
        int noviceSimplicity)
        : base(inventoryNumber, name, 0, noviceSimplicity)
    {
    }
}

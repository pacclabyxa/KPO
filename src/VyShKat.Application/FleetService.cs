using VyShKat.Domain;
using VyShKat.Domain.Abstractions;

namespace VyShKat.Application;

public sealed class FleetService
{
    private readonly IInspectionService _inspectionService;
    private readonly List<IInventoryItem> _items = new();
    private readonly List<Transport> _transports = new();

    public FleetService(IInspectionService inspectionService)
    {
        _inspectionService = inspectionService;
    }

    public int TransportCount => _transports.Count;

    public int ThingCount => _items.Count - _transports.Count;

    public double TotalDailyEnergyKwh =>
        _items
            .OfType<IEnergyConsumer>()
            .Sum(item => item.DailyEnergyConsumptionKwh);

    public bool TryAddTransport(Transport transport)
    {
        ArgumentNullException.ThrowIfNull(transport);

        if (!_inspectionService.IsAccepted(transport))
            return false;

        _transports.Add(transport);
        _items.Add(transport);
        return true;
    }

    public void AddThing(IInventoryItem thing)
    {
        ArgumentNullException.ThrowIfNull(thing);
        _items.Add(thing);
    }

    public IReadOnlyList<Transport> GetTransportsForNovices()
    {
        return _transports
            .Where(t => t.NoviceSimplicity >= 6)
            .ToList();
    }

    public IReadOnlyList<IInventoryItem> GetAllInventoryItems()
    {
        return _items.ToList();
    }
}

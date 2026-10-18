using VyShKat.Application;
using VyShKat.Domain.Transports;
using VyShKat.Domain.Things;

namespace VyShKat.Presentation;

public sealed class App
{
    private readonly FleetService _fleet;

    public App(FleetService fleet)
    {
        _fleet = fleet;
    }

    public void Run()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;

        System.Console.WriteLine("=== ВышКат: учёт парка ===");

        var scooter = new Scooter("SC-001", "Самокат городской", 0.8, 7);
        var eBike = new EBike("EB-001", "Электровелосипед", 1.4, 5);
        var bike = new Bicycle("BK-001", "Велосипед", 9);
        var badScooter = new Scooter("SC-999", "Самокат с утечкой", 120, 7);

        var helmet = new Helmet("HL-001", "Шлем");
        var charger = new ChargingStation("CH-001", "Зарядная станция", 2.5);

        _fleet.AddThing(helmet);
        _fleet.AddThing(charger);

        PrintAddResult("SC-001", _fleet.TryAddTransport(scooter));
        PrintAddResult("EB-001", _fleet.TryAddTransport(eBike));
        PrintAddResult("BK-001", _fleet.TryAddTransport(bike));
        PrintAddResult("SC-999", _fleet.TryAddTransport(badScooter));

        System.Console.WriteLine($"\nТранспорт: {_fleet.TransportCount}, вещи: {_fleet.ThingCount}");
        System.Console.WriteLine($"Суммарное суточное потребление: {_fleet.TotalDailyEnergyKwh:F2} кВт·ч");

        System.Console.WriteLine("\nТранспорт для новичков, простота >= 6:");
        foreach (var transport in _fleet.GetTransportsForNovices())
        {
            System.Console.WriteLine(
                $"  {transport.Name} [{transport.InventoryNumber}], простота={transport.NoviceSimplicity}");
        }

        System.Console.WriteLine("\nВсе инвентарные объекты:");
        foreach (var item in _fleet.GetAllInventoryItems())
        {
            System.Console.WriteLine($"  {item.Name} [{item.InventoryNumber}]");
        }
    }

    private static void PrintAddResult(string inventoryNumber, bool accepted)
    {
        System.Console.WriteLine(accepted
            ? $"Принято: {inventoryNumber}"
            : $"Отклонено техосмотром: {inventoryNumber}");
    }
}

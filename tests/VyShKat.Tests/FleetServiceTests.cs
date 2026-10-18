using VyShKat.Application;
using VyShKat.Domain.Transports;
using VyShKat.Domain.Things;
using Xunit;

namespace VyShKat.Tests;

public class FleetServiceTests
{
    [Fact]
    public void TryAddTransport_WhenInspectionRejects_DoesNotAdd()
    {
        var fleet = new FleetService(new FakeInspectionService(false));
        var scooter = new Scooter("SC-1", "Scooter", 0.5, 7);

        var accepted = fleet.TryAddTransport(scooter);

        Assert.False(accepted);
        Assert.Equal(0, fleet.TransportCount);
    }

    [Fact]
    public void TryAddTransport_WhenInspectionAccepts_Adds()
    {
        var fleet = new FleetService(new FakeInspectionService(true));
        var scooter = new Scooter("SC-1", "Scooter", 0.5, 7);

        var accepted = fleet.TryAddTransport(scooter);

        Assert.True(accepted);
        Assert.Equal(1, fleet.TransportCount);
        Assert.Contains(scooter, fleet.GetAllInventoryItems());
    }

    [Fact]
    public void TotalDailyEnergy_SumsOnlyEnergyConsumers()
    {
        var fleet = new FleetService(new FakeInspectionService(true));

        fleet.AddThing(new Helmet("HL-1", "Helmet"));
        fleet.AddThing(new ChargingStation("CH-1", "Charger", 2.0));
        fleet.TryAddTransport(new Scooter("SC-1", "Scooter", 0.5, 7));

        Assert.Equal(2.5, fleet.TotalDailyEnergyKwh, precision: 2);
    }

    [Fact]
    public void GetTransportsForNovices_ReturnsOnlySimplicityAtLeastSix()
    {
        var fleet = new FleetService(new FakeInspectionService(true));

        fleet.TryAddTransport(new Scooter("SC-1", "Easy", 0.5, 6));
        fleet.TryAddTransport(new Scooter("SC-2", "Hard", 0.5, 5));

        var result = fleet.GetTransportsForNovices();

        Assert.Single(result);
        Assert.Equal("SC-1", result[0].InventoryNumber);
    }

    [Fact]
    public void ServiceCenter_RejectsTooPowerfulTransport()
    {
        var center = new ServiceCenter();
        var bad = new Scooter("SC-999", "Bad", 100, 10);

        Assert.False(center.IsAccepted(bad));
    }
}

using VyShKat.Domain;

namespace VyShKat.Application;

public sealed class ServiceCenter : IInspectionService
{
    public bool IsAccepted(Transport transport)
    {
        return transport.DailyEnergyConsumptionKwh <= 50;
    }
}
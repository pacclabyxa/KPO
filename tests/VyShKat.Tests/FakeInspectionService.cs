using VyShKat.Application;
using VyShKat.Domain;

namespace VyShKat.Tests;

public sealed class FakeInspectionService : IInspectionService
{
    private readonly bool _result;

    public FakeInspectionService(bool result)
    {
        _result = result;
    }

    public int Calls { get; private set; }

    public bool IsAccepted(Transport transport)
    {
        Calls++;
        return _result;
    }
}


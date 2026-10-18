using VyShKat.Domain;

namespace VyShKat.Application;

public interface IInspectionService
{
    bool IsAccepted(Transport transport);
}

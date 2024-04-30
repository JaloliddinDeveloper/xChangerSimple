using xChangerSimple.Models.Foundations;

namespace Importer.Services.Orchestrations
{
    public interface IOrchestrationService
    {
        ValueTask<List<Talaba>> ProcessImportRequest(MemoryStream memoryStream);
    }
}

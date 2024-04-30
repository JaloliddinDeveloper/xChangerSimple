using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Brokers.Sheet
{
    public interface ISheetBroker
    {
        List<ExternalTalaba> ImportTalabalar(MemoryStream memoryStream);
    }
}

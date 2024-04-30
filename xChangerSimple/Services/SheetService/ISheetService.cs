using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Services.Spreadsheets
{
    public interface ISheetService
    {
        List<ExternalTalaba> GetExternalTalabalar(MemoryStream memoryStream);
    }
}

using xChangerSimple.Brokers.Sheet;
using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Services.Spreadsheets
{
    public class SheetService:ISheetService
    {
        private readonly ISheetBroker sheetBroker;

        public SheetService(ISheetBroker sheetBroker)
        {
            this.sheetBroker = sheetBroker;
        }

        public List<ExternalTalaba> GetExternalTalabalar(MemoryStream memoryStream)
        {
            List<ExternalTalaba> externalTalabalar = this.sheetBroker.ImportTalabalar(memoryStream);

            return externalTalabalar;
        }
    }
}

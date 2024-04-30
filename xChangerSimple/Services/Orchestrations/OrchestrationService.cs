using System.Xml.Serialization;
using xChangerSimple.Brokers.Sheet;
using xChangerSimple.Models.Foundations;
using xChangerSimple.Services.Foundations;
using xChangerSimple.Services.Spreadsheets;

namespace Importer.Services.Orchestrations
{
    public class OrchestrationService : IOrchestrationService
    {
        private readonly ISheetService sheetService;
        private readonly ITalabaService talabaService;

        public OrchestrationService(ISheetService sheetService, ITalabaService talabaService)
        {
            this.sheetService = sheetService;
            this.talabaService = talabaService;
        }
        public async ValueTask<List<Talaba>> ProcessImportRequest(MemoryStream memoryStream)
        {
            List<Talaba> clients = new List<Talaba>();

            List<ExternalTalaba> externalTalabalar = 
                this.sheetService.GetExternalTalabalar(memoryStream);

            foreach(ExternalTalaba externalTalaba in externalTalabalar)
            {
                Talaba talaba = MapToTalaba(externalTalaba);

                clients.Add(talaba);

                await this.talabaService.AddAsyncTalaba(talaba);
            }

            return clients;
        }
       
        private Talaba MapToTalaba(ExternalTalaba externalTalaba)
        {
            return new Talaba
            {
                ID = externalTalaba.ID,
                FirstName = externalTalaba.FirstName,
                LastName = externalTalaba.LastName,
                Age = externalTalaba.Age,
                Secialty = externalTalaba.Secialty,
                Experience = externalTalaba.Experience,
            };
        }
    }
}

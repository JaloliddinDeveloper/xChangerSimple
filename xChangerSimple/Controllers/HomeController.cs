using Importer.Services.Orchestrations;
using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System.Text;
using xChangerSimple.Models.Foundations;
using xChangerSimple.Services.Foundations;

namespace xChangerSimple.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        private readonly IOrchestrationService orchestrationService;
        private readonly ITalabaService talabaService;

        public HomeController(IOrchestrationService orchestrationService, ITalabaService talabaService)
        {
            this.orchestrationService = orchestrationService;
            this.talabaService = talabaService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<List<Talaba>>> ImprotTalabalarAsync(IFormFile formFile)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);

                memoryStream.Position = 0;

                return Ok(await this.orchestrationService.ProcessImportRequest(memoryStream));
            }
        }
        [HttpGet]
        public async ValueTask<ActionResult<List<Talaba>>> GetStoredPersons()
        {
            IQueryable<Talaba> talabalar = talabaService.RetrieveAllTalabalar();

            List<Talaba> talabas = talabalar.ToList();

            string xmlString = talabaService.SerializeToXml(talabas);
            return File(Encoding.UTF8.GetBytes(xmlString), "application/xml", "Talabalar/xml");
        }
    }
}


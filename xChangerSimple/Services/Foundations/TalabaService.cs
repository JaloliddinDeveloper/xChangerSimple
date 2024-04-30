using System.Xml.Serialization;
using xChangerSimple.Brokers.Storage;
using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Services.Foundations
{
    public class TalabaService : ITalabaService
    {
        private readonly IStorageBroker storageBroker;
        public TalabaService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }
        public async ValueTask<Talaba> AddAsyncTalaba(Talaba talaba)
        {
            return await this.storageBroker.InsertAsyncTalaba(talaba);
        }
        public IQueryable<Talaba> RetrieveAllTalabalar()
        {
            return this.storageBroker.SelectAllTalabalar();
        }
        public string SerializeToXml(List<Talaba> talabalar)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Talaba>));
            StringWriter stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, talabalar);
            return stringWriter.ToString();
        }
    }
}
      



using xChangerSimple.Models.Foundations;
namespace xChangerSimple.Services.Foundations
{
    public interface ITalabaService
    {
        ValueTask<Talaba> AddAsyncTalaba(Talaba talaba);
        IQueryable<Talaba> RetrieveAllTalabalar();
        string SerializeToXml(List<Talaba> talabalar);
    }
}

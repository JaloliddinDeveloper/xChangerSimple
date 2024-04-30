using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Brokers.Storage
{
    public partial interface IStorageBroker
    {
        ValueTask<Talaba> InsertAsyncTalaba(Talaba talaba);
        IQueryable<Talaba> SelectAllTalabalar();   
    }
}

using Microsoft.EntityFrameworkCore;
using xChangerSimple.Models.Foundations;

namespace xChangerSimple.Brokers.Storage
{
    public partial class StorageBroker
    {
        public DbSet<Talaba> Talabalar { get; set; }
        public  async ValueTask<Talaba> InsertAsyncTalaba(Talaba talaba)
        {
            return await InsertAsync(talaba);
        }
        public IQueryable<Talaba> SelectAllTalabalar()
        {
             return SelectAll<Talaba>();
        }
    }
}

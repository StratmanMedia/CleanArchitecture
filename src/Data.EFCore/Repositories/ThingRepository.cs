using System.Threading.Tasks;
using Domain.Contracts.Things;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using StratmanMedia.Repositories.EFCore;

namespace Data.EFCore.Repositories
{
    public class ThingRepository : Repository<DatabaseContext, Thing>, IThingRepository
    {
        public ThingRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Thing> ReadOneAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
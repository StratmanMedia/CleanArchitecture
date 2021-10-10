using System.Threading.Tasks;
using Domain.Entities;
using StratmanMedia.Repositories.EFCore;

namespace Domain.Contracts.Things
{
    public interface IThingRepository : IRepository<Thing>
    {
        Task<Thing> ReadOneAsync(int id);
    }
}
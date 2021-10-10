using System.Threading.Tasks;
using Domain.Entities;
using StratmanMedia.ResponseObjects;

namespace Domain.Contracts.Things
{
    public interface ICreateThingCommand
    {
        Task<Response> ExecuteAsync(Thing thing);
    }
}
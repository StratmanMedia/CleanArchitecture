using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using StratmanMedia.ResponseObjects;

namespace Domain.Contracts.Things
{
    public interface IReadAllThingsQuery
    {
        Task<Response<IEnumerable<Thing>>> ExecuteAsync();
    }
}
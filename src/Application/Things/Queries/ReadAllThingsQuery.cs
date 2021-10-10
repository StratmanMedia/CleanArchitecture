using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts.Things;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using StratmanMedia.ResponseObjects;

namespace Application.Things.Queries
{
    public class ReadAllThingsQuery : IReadAllThingsQuery
    {
        private readonly ILogger<ReadAllThingsQuery> _logger;
        private readonly IThingRepository _thingRepository;

        public ReadAllThingsQuery(
            ILogger<ReadAllThingsQuery> logger,
            IThingRepository thingRepository)
        {
            _logger = logger;
            _thingRepository = thingRepository;
        }

        public async Task<Response<IEnumerable<Thing>>> ExecuteAsync()
        {
            try
            {
                var things = await _thingRepository.GetAllAsync();

                return new Response<IEnumerable<Thing>>(things);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An exception occurred in {nameof(ReadAllThingsQuery)}");
                return new Response<IEnumerable<Thing>>(ex.Message);
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using Domain.Contracts.Things;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StratmanMedia.ResponseObjects;

namespace Application.Things.Commands
{
    public class CreateThingCommand : ICreateThingCommand
    {
        private readonly ILogger<CreateThingCommand> _logger;
        private readonly IThingRepository _thingRepository;

        public CreateThingCommand(
            ILogger<CreateThingCommand> logger,
            IThingRepository thingRepository)
        {
            _logger = logger;
            _thingRepository = thingRepository;
        }

        public async Task<Response> ExecuteAsync(Thing thing)
        {
            try
            {
                _logger.LogDebug($"BEGIN {nameof(CreateThingCommand)} : {JsonConvert.SerializeObject(thing)}");

                var validation = await ValidateRequest(thing);
                if (!string.IsNullOrWhiteSpace(validation)) return new Response(validation);

                await _thingRepository.CreateAsync(thing);

                return new Response();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred in {nameof(CreateThingCommand)}");
                return new Response(ex.Message);
            }
        }

        private async Task<string> ValidateRequest(Thing thing)
        {
            return null;
        }
    }
}

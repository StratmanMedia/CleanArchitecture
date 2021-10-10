using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Api.Infrastructure.Canary.Models;
using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StratmanMedia.Endpoints;

namespace Api.Infrastructure.Canary.Endpoints
{
    public class GetCanaryEndpoint : BaseEndpoint.WithoutRequest.WithResponse<CanaryResponseDto>
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<GetCanaryEndpoint> _logger;

        public GetCanaryEndpoint(
            IConfiguration configuration,
            ILogger<GetCanaryEndpoint> logger)
        {
            _configuration = Guard.Against.Null(configuration, nameof(configuration));
            _logger = Guard.Against.Null(logger, nameof(logger));
        }

        [HttpGet("/api/v1/canary")]
        public override async Task<ActionResult<CanaryResponseDto>> HandleAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _logger.LogDebug($"ENTER {nameof(GetCanaryEndpoint)}");

            var dbCanaryTask = DatabaseCanary();
            var canaryTasks = new Task[]
            {
                dbCanaryTask
            };
            Task.WaitAll(canaryTasks, cancellationToken);
            var databaseStatus = dbCanaryTask.Result;

            var serverStatus = new CanaryDto
            {
                Service = "My API",
                Status = "OK",
                Timestamp = DateTime.Now
            };

            var response = new CanaryResponseDto
            {
                Server = serverStatus,
                Database = databaseStatus
            };

            stopwatch.Stop();
            serverStatus.Milliseconds = stopwatch.ElapsedMilliseconds;

            return Ok(response);
        }

        private async Task<CanaryDto> DatabaseCanary()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var databaseStatus = new CanaryDto
            {
                Service = "My Database",
                Status = "Failed"
            };

            try
            {
                using (var conn = new SqlConnection(_configuration.GetConnectionString("SqlServerConnection")))
                {
                    await conn.OpenAsync();
                    var sql = "SELECT getdate() as Timestamp";
                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                databaseStatus.Status = "OK";
                                databaseStatus.Timestamp = reader.GetDateTime("Timestamp");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                databaseStatus.Messages = new[] { ex.Message };
            }

            stopwatch.Stop();
            databaseStatus.Milliseconds = stopwatch.ElapsedMilliseconds;

            return databaseStatus;
        }
    }
}
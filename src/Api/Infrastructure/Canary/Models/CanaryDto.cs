using System;

namespace Api.Infrastructure.Canary.Models
{
    public record CanaryDto
    {
        public string Service { get; set; }
        public string Status { get; set; }
        public long Milliseconds { get; set; }
        public string[] Messages { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
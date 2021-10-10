namespace Api.Infrastructure.Canary.Models
{
    public record CanaryResponseDto
    {
        public CanaryDto Server { get; set; }
        public CanaryDto Database { get; set; }
    }
}
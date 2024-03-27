using Newtonsoft.Json;

namespace DogShelter.Infrastructure;
internal record MeasureUnit
{
    [JsonProperty("imperial")]
    public string? Imperial { get; set; }

    [JsonProperty("metric")]
    public string? Metric { get; set; }
}

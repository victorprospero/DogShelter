using Newtonsoft.Json;

namespace DogShelter.Infrastructure;
internal record Breed
{
    [JsonProperty("id")]
    public int Id { get; init; }

    [JsonProperty("name")]
    public string? Name { get; init; }

    [JsonProperty("bred_for")]
    public string? BredFor { get; init; }

    [JsonProperty("breed_group")]
    public string? BreedGroup { get; init; }

    [JsonProperty("life_span")]
    public string? LifeSpan { get; init; }

    [JsonProperty("temperament")]
    public string? Temperament { get; init; }

    [JsonProperty("weight")]
    public MeasureUnit Weight { get; init; }

    [JsonProperty("height")]
    public MeasureUnit Height { get; init; }
}

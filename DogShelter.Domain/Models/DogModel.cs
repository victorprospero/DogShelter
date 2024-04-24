using System.Text.RegularExpressions;

namespace DogShelter.Domain.Models;
public class DogModel
{
    public ulong? Id { get; set; }
    public string? Name { get; set; }
    public string? Breed { get; set; }
    public string? Temperament { get; set; }
    public decimal? MinHeight { get; set; }
    public decimal? MaxHeight { get; set; }
}
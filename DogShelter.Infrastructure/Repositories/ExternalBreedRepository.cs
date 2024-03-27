using DogShelter.Application;
using Newtonsoft.Json;

namespace DogShelter.Infrastructure;

public class ExternalBreedRepository : IExternalBreedRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExternalBreedRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<BreedDTO> GetAsync(string parameter, string value)
    {
        HttpClient client = _httpClientFactory.CreateClient("Breeds");
        HttpResponseMessage response = await client.GetAsync(client.BaseAddress + parameter + value);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(responseBody))
                throw new Exception("No response body from Breed");

            Breed breed = JsonConvert.DeserializeObject<IEnumerable<Breed>>(responseBody).FirstOrDefault();

            if (breed is null)
                throw new Exception("Breed does not exist");

            return new BreedDTO(breed.Id, breed.Name, breed.Weight.Metric, breed.Height.Metric, breed.Temperament);
        }
        else
            throw new Exception("Error getting Breed");
    }
}

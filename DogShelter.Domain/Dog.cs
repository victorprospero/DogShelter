namespace DogShelter.Domain;
public record Dog
{
    public Guid Id { get; init; }
    public string? Name { get; init; }
    public string? Breed { get; init; }
    public string? Size { get; init; }
    public string? Temperament { get; init; }
    public int? HeightAverage { get; init; }

    private Dog(Guid id, string name, string breed, int heightAverage, string temperament) 
    {
        Id = id;
        Name = name;
        Breed = breed;
        HeightAverage = heightAverage;
        Size = SetSizeCategory(heightAverage);
        Temperament = temperament;
    }
    public static Dog NewDog(string name, string breed, string height, string temperament)
    {
        return new(Guid.NewGuid(), name, breed, SetHeightAverage(height), temperament);
    }
    private static int SetHeightAverage(string height)
    {
        if(string.IsNullOrEmpty(height))
            throw new ArgumentNullException("there is no height");

        int minHeight = Convert.ToInt32(height.Split('-')[0].Trim());
        int maxHeight = Convert.ToInt32(height.Split('-')[1].Trim());

        return (minHeight + maxHeight) / 2;
    }
    private string SetSizeCategory(int heightAverage)
    {
        if (heightAverage < 35)
            return Sizes.Small;
        if (heightAverage >= 35 && heightAverage <= 55)
            return Sizes.Medium;

        return Sizes.Large;
    }
}
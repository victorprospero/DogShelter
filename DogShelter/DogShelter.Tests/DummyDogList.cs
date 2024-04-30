using DogShelter.Domain.Models;

namespace DogShelter.Tests;

public class DummyDogList
{
    private List<DogModel> _dogList = new();

    public List<DogModel> CreateDummyDogList()
    {
        DogModel bobbyDog = DogModel.NewDog("Bobby", "Canaan", "48 - 61", "Cautious, Devoted, Alert, Quick, Intelligent, Vigilant"); //Medium
        DogModel snoopyDog = DogModel.NewDog("Snoopy", "Afghan Hound", "37 - 41", "Aloof, Clownish, Dignified, Independent, Happy"); //Medium
        DogModel lassieDog = DogModel.NewDog("Lassie", "Doberman", "69 - 75", "Fearless, Energetic, Alert, Loyal, Obedient, Confident, Intelligent"); //Large
        DogModel cookieDog = DogModel.NewDog("Cookie", "English Toy Spaniel", "4 - 6", "Affectionate, Reserved, Playful, Gentle, Happy, Loving"); //Small

        _dogList.Add(bobbyDog);
        _dogList.Add(snoopyDog);
        _dogList.Add(lassieDog);
        _dogList.Add(cookieDog);

        return _dogList;
    }
}

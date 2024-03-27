using DogShelter.Domain;

namespace DogShelter.Tests;

public class DummyDogList
{
    private List<Dog> _dogList = new();

    public List<Dog> CreateDummyDogList()
    {
        Dog bobbyDog = Dog.NewDog("Bobby", "Canaan", "48 - 61", "Cautious, Devoted, Alert, Quick, Intelligent, Vigilant"); //Medium
        Dog snoopyDog = Dog.NewDog("Snoopy", "Afghan Hound", "37 - 41", "Aloof, Clownish, Dignified, Independent, Happy"); //Medium
        Dog lassieDog = Dog.NewDog("Lassie", "Doberman", "69 - 75", "Fearless, Energetic, Alert, Loyal, Obedient, Confident, Intelligent"); //Large
        Dog cookieDog = Dog.NewDog("Cookie", "English Toy Spaniel", "4 - 6", "Affectionate, Reserved, Playful, Gentle, Happy, Loving"); //Small

        _dogList.Add(bobbyDog);
        _dogList.Add(snoopyDog);
        _dogList.Add(lassieDog);
        _dogList.Add(cookieDog);

        return _dogList;
    }
}

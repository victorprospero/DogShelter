﻿namespace DogShelter.Application.Models
{
    public class DogAppModel
    {
        public ulong? Id { get; set; }
        public string? Name { get; set; }
        public BreedAppModel? Breed { get; set; }
    }
}

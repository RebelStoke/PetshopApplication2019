using System;
using System.Collections.Generic;
using System.Text;
using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        List<Pet> GetPetsByType(string type);
        Pet NewPet(string type, string name, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price);
        Pet CreatePet(Pet pet);
        Pet DeletePet(int id);
        Pet UpdatePet(int id, Pet pet);
        List<Pet> get5CheapestPets();
        List<Pet> sortPetsByPrice();

        Pet getPetByID(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        IPetRepository _petRepository;
        public PetService(IPetRepository petRepository) {
            _petRepository = petRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.Create(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet getPetByID(int id) {
           return _petRepository.ReadByID(id);
        }

        public List<Pet> get5CheapestPets()
        {
            List<Pet> cheapestPets = new List<Pet>(); 
            List<Pet> petsByPrice = sortPetsByPrice();
            for (int i = 0; i < 5; i++) {
                cheapestPets.Add(petsByPrice[i]);
            }
            return cheapestPets;
        }

        public FilteredList<Pet> GetPets(Filter filter)
        {
           return _petRepository.ReadPets(filter);
        }
        public List<Pet> GetPetsByType(string type) {
            var list = _petRepository.ReadPets(null);
            var listByType = list.List.Where(pet => pet.Type.Equals(type));
            return listByType.ToList();
        }

        public Pet NewPet(string type, string name, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            var newPet = new Pet()
            {
                Type = type,
                Name = name,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price,
            };
            return newPet;
        }

        public List<Pet> sortPetsByPrice()
        {
            var pets = GetPets(null);
            var sortedPets = pets.List.OrderBy(pet => pet.Price);
            return sortedPets.ToList();
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            return _petRepository.Update(id, pet);
        }
    }
}

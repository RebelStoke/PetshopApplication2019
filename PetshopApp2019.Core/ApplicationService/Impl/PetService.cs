using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetshopApp2019.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IOwnerService _ownerService;
        public PetService(IPetRepository petRepository, IOwnerService ownerService)
        {
            _petRepository = petRepository;
            _ownerService = ownerService;
        }

        public Pet CreatePet(Pet pet)
        {
            pet.PreviousOwner = _ownerService.getOwnerByID(pet.PreviousOwner.Id);
            return _petRepository.Create(pet);
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet getPetByID(int id)
        {
            return _petRepository.ReadByID(id);
        }

        public List<Pet> get5CheapestPets()
        {
            List<Pet> cheapestPets = new List<Pet>();
            List<Pet> petsByPrice = sortPetsByPrice();
            for (int i = 0; i < 5; i++)
            {
                cheapestPets.Add(petsByPrice[i]);
            }
            return cheapestPets;
        }

        public FilteredList<Pet> GetPets(Filter filter)
        {
            return _petRepository.ReadPets(filter);
        }
        public List<Pet> GetPetsByType(string type)
        {
            FilteredList<Pet> list = _petRepository.ReadPets(null);
            IEnumerable<Pet> listByType = list.List.Where(pet => pet.Type.Equals(type));
            return listByType.ToList();
        }

        public Pet NewPet(string type, string name, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner, double price)
        {
            Pet newPet = new Pet()
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
            FilteredList<Pet> pets = GetPets(null);
            IOrderedEnumerable<Pet> sortedPets = pets.List.OrderBy(pet => pet.Price);
            return sortedPets.ToList();
        }

        public Pet UpdatePet(int id, Pet pet)
        {
            return _petRepository.Update(id, pet);
        }
    }
}

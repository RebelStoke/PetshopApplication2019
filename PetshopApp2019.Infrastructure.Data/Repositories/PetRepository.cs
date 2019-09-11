using System;
using System.Collections.Generic;
using System.Text;
using PetshopApp2019.Core.DomainService;
using PetshopApp2019.Core.Entity;

namespace PetshopApp2019.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public PetRepository() {
            FakeDB.InitData();
        }

        public Pet Create(Pet pet)
        {
           pet.ID = FakeDB.petID++;
           FakeDB.listOfPets.Add(pet);
           return pet;
        }

        public Pet Delete(int id)
        {
            foreach (Pet pet in FakeDB.listOfPets) {
                if (pet.ID == id) {
                    FakeDB.listOfPets.Remove(pet);
                    return pet;
                }
            }
            return null;
        }

        public Pet ReadByID(int id)
        {
            foreach (Pet pet in FakeDB.listOfPets)
            {
                if (pet.ID == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.listOfPets;
        }

        public Pet Update(int id, Pet pet)
        {
            if (Delete(id) != null) {
                pet.ID = id;
                FakeDB.listOfPets.Add(pet);
                return pet;
            }
            return null;
        }
    }
}
